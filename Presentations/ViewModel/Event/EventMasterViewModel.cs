using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Presentations.Model.API;
using Presentations.ViewModel.Commands;
using Presentations.ViewModel;
using Presentations;

namespace Presentations.ViewModel;

internal class EventMasterViewModel : ViewModelBase, IEventMasterViewModel
{
    public ICommand SwitchToUserMasterPage { get; set; }

    public ICommand SwitchToProductMasterPage { get; set; }

    public ICommand SwitchToStateMasterPage { get; set; }

    public ICommand AddEvent { get; set; }

    public ICommand RemoveEvent { get; set; }

    private readonly IEventModelOperations _modelOperation;

    private readonly IErrorPopup _informer;

    private ObservableCollection<IEventDetailViewModel> _events;

    public ObservableCollection<IEventDetailViewModel> Events
    {
        get => _events;
        set
        {
            _events = value;
            OnPropertyChanged(nameof(Events));
        }
    }

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

    private bool _isEventSelected;

    public bool IsEventSelected
    {
        get => _isEventSelected;
        set
        {
            this.IsEventDetailVisible = value ? Visibility.Visible : Visibility.Hidden;

            _isEventSelected = value;
            OnPropertyChanged(nameof(IsEventSelected));
        }
    }

    private Visibility _isEventDetailVisible;

    public Visibility IsEventDetailVisible
    {
        get => _isEventDetailVisible;
        set
        {
            _isEventDetailVisible = value;
            OnPropertyChanged(nameof(IsEventDetailVisible));
        }
    }

    private IEventDetailViewModel _selectedDetailViewModel;

    public IEventDetailViewModel SelectedDetailViewModel
    {
        get => _selectedDetailViewModel;
        set
        {
            _selectedDetailViewModel = value;
            this.IsEventSelected = true;

            OnPropertyChanged(nameof(SelectedDetailViewModel));
        }
    }

    public EventMasterViewModel(IEventModelOperations? model = null, bool? showPopups = true, IErrorPopup? informer = null)
    {
        this.SwitchToUserMasterPage = new SwitchViewCommand("CustomerMasterView");
        this.SwitchToStateMasterPage = new SwitchViewCommand("StatusMasterView");
        this.SwitchToProductMasterPage = new SwitchViewCommand("BookMasterView");

        this.AddEvent = new OnClickCommand(e => this.StoreEvent(), c => this.CanEvent());
        this.RemoveEvent = new OnClickCommand(e => this.DeleteEvent());

        this.Events = new ObservableCollection<IEventDetailViewModel>();

        this._modelOperation = model ?? IEventModelOperations.CreateModelOperation();

        if (showPopups == true)
            this._informer = informer ?? new ErrorPopupHandler();

        this.IsEventSelected = false;

        this.LoadEvents();
    }

    private bool CanEvent()
    {
        return !(
            string.IsNullOrWhiteSpace(this.StatusId.ToString()) ||
            string.IsNullOrWhiteSpace(this.CustomerId.ToString()) || 
            string.IsNullOrWhiteSpace(this.Type.ToString())
        );
    }

    private void StoreEvent()
    {
       
        try
        {
            
            this._modelOperation.AddEvent(Id, StatusId, CustomerId, DateTime.Now, Type, ReasonOrDescription);

            this.LoadEvents();

            if (this._informer != null)
                this._informer.InformSuccess("Event successfully created!");
        }
        catch (Exception e)
        {
            if (this._informer != null)
                this._informer.InformError(e.Message);
        }
        
    }

    private void DeleteEvent()
    {
        this._modelOperation.DeleteEvent(this.SelectedDetailViewModel.Id);

        this.LoadEvents();

        if (this._informer != null)
            this._informer.InformSuccess("Event successfully deleted!");
       
    }

    private void LoadEvents()
    {
        IEnumerable<IEventModel> Events = this._modelOperation.GetAllEvents();

        this._events.Clear();

        foreach (IEventModel e in Events)
        {
                
            this._events.Add(new EventDetailViewModel(e));
        }

        OnPropertyChanged(nameof(Events));
    }
}