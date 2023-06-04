using System;
using System.Windows.Input;
using Presentations.Model.API;
using Presentations.ViewModel;
using Presentations.ViewModel.Commands;
using Presentations;

namespace Presentations.ViewModel;

internal class EventDetailViewModel : ViewModelBase, IEventDetailViewModel
{
    public ICommand UpdateEvent { get; set; }

    private readonly IEventModelOperations _modelOperation;

    private readonly IErrorPopup _informer;

    private string _id;

    public string Id
    {
        get => _id;
        set
        {
            _id = value;
            OnPropertyChanged(nameof(Id));
        }
    }

    private string _statusId;

    public string StatusId
    {
        get => _statusId;
        set
        {
            _statusId = value;
            OnPropertyChanged(nameof(StatusId));
        }
    }

    private string _customerId;

    public string CustomerId
    {
        get => _customerId;
        set
        {
            _customerId = value;
            OnPropertyChanged(nameof(CustomerId));
        }
    }

    private DateTime _eventDate;

    public DateTime EventDate
    {
        get => _eventDate;
        set
        {
            _eventDate = value;
            OnPropertyChanged(nameof(EventDate));
        }
    }

    private string _type;

    public string Type
    {
        get => _type;
        set
        {
            _type = value;
            OnPropertyChanged(nameof(Type));
        }
    }

    private string _reasonOrDescription;

    public string ReasonOrDescription
    {
        get => _reasonOrDescription;
        set
        {
            _reasonOrDescription = value;
            OnPropertyChanged(nameof(ReasonOrDescription));
        }
    }

    public EventDetailViewModel(IEventModel modelEvent, IEventModelOperations? model = null, IErrorPopup? informer = null)
    {
        this.Id = modelEvent.Id;
        this.StatusId = modelEvent.StatusId;
        this.CustomerId = modelEvent.CustomerId;
        this.EventDate = modelEvent.Time;
        this.Type = modelEvent.Type;
        this.ReasonOrDescription = modelEvent.ReasonOrDescription;


        this.UpdateEvent = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

        this._modelOperation = IEventModelOperations.CreateModelOperation();
        this._informer = informer ?? new ErrorPopupHandler();
    }

    private void Update()
    {
        this._modelOperation.UpdateEvent(this.Id, this.StatusId, this.CustomerId, this.EventDate, this.Type, this.ReasonOrDescription);

        this._informer.InformSuccess("Event successfully updated!");
       
    }

    private bool CanUpdate()
    {
        return !(
            string.IsNullOrWhiteSpace(this.EventDate.ToString())
        );
    }
}