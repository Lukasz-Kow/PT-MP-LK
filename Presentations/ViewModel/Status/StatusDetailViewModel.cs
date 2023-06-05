using System.Windows.Input;
using Presentations.Model.API;
using Presentations.ViewModel.Commands;


namespace Presentations.ViewModel;

internal class StatusDetailViewModel : ViewModelBase, IStatusDetailViewModel
{
    public ICommand UpdateStatus { get; set; }

    private readonly IStatusModelOperations _modelOperation;

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

    private string _bookId;

    public string BookId
    {
        get => _bookId;
        set
        {
            _bookId = value;
            OnPropertyChanged(nameof(BookId));
        }
    }

    private bool _available;

    public bool Available
    {
        get => _available;
        set
        {
            _available = value;
            OnPropertyChanged(nameof(Available));
        }
    }

    public StatusDetailViewModel(IStatusModel model, IStatusModelOperations? modelOps = null, IErrorPopup? informer = null)
    {
        this.Id = model.Id;
        this.BookId = model.BookId;
        this.Available = model.Availability;
        this._modelOperation = modelOps;

        this.UpdateStatus = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

        this._modelOperation = IStatusModelOperations.CreateModelOperation();
        this._informer = informer ?? new ErrorPopupHandler();
    }

    private void Update()
    {
        
        this._modelOperation.UpdateStatus(this.Id, this.BookId, this.Available);

        this._informer.InformSuccess("Status successfully updated!");
        
    }

    private bool CanUpdate()
    {
        return !(
            string.IsNullOrWhiteSpace(this.Available.ToString()) || 
            string.IsNullOrWhiteSpace(this.BookId)
        );
    }
}