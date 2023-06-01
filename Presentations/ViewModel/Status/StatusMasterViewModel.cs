using Presentations.Model.API;
using Presentations.ViewModel;
using Presentations.ViewModel.Commands;
using Presentations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Presentations.ViewModel;

internal class StatusMasterViewModel : ViewModelBase
{
    public ICommand SwitchToCustomerMasterPage { get; set; }

    public ICommand SwitchToProductMasterPage { get; set; }

    public ICommand SwitchToEventMasterPage { get; set; }

    public ICommand CreateStatus { get; set; }

    public ICommand RemoveStatus { get; set; }

    private readonly IStatusModelOperations _modelOperation;

    private readonly IErrorPopup _informer;

    private ObservableCollection<StatusDetailViewModel> _Statuses;

    public ObservableCollection<StatusDetailViewModel> Statuses
    {
        get => _Statuses;
        set
        {
            _Statuses = value;
            OnPropertyChanged(nameof(Statuses));
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

    private bool _isStatuseselected;

    public bool IsStatuseselected
    {
        get => _isStatuseselected;
        set
        {
            this.IsStatusDetailVisible = value ? Visibility.Visible : Visibility.Hidden;

            _isStatuseselected = value;
            OnPropertyChanged(nameof(IsStatuseselected));
        }
    }

    private Visibility _isStatusDetailVisible;

    public Visibility IsStatusDetailVisible
    {
        get => _isStatusDetailVisible;
        set
        {
            _isStatusDetailVisible = value;
            OnPropertyChanged(nameof(IsStatusDetailVisible));
        }
    }

    private StatusDetailViewModel _selectedDetailViewModel;

    public StatusDetailViewModel SelectedDetailViewModel
    {
        get => _selectedDetailViewModel;
        set
        {
            _selectedDetailViewModel = value;
            this.IsStatuseselected = true;

            OnPropertyChanged(nameof(SelectedDetailViewModel));
        }
    }

    public StatusMasterViewModel(IStatusModelOperations? model = null, IErrorPopup? informer = null)
    {
        this.SwitchToCustomerMasterPage = new SwitchViewCommand("CustomerMasterView");
        this.SwitchToProductMasterPage = new SwitchViewCommand("ProductMasterView");
        this.SwitchToEventMasterPage = new SwitchViewCommand("EventMasterView");

        this.CreateStatus = new OnClickCommand(e => this.StoreStatus(), c => this.CanStoreStatus());
        this.RemoveStatus = new OnClickCommand(e => this.DeleteStatus());

        this.Statuses = new ObservableCollection<StatusDetailViewModel>();

        this._modelOperation = IStatusModelOperations.CreateModelOperation();
        this._informer = informer ?? new ErrorPopupHandler();

        this.IsStatuseselected = false;
        
        this.LoadStatuses();
    }

    private bool CanStoreStatus()
    {
        return !(
            string.IsNullOrWhiteSpace(this.BookId.ToString()) ||
            string.IsNullOrWhiteSpace(this.Id.ToString())
        );
    }

    private void StoreStatus()
    {
        
        try
        {
            this._modelOperation.AddStatus(Id, BookId, Available);

            this.LoadStatuses();

            this._informer.InformSuccess("Status successfully created!");
        }
        catch (Exception e)
        {
            this._informer.InformError(e.Message);
        }
        
    }

    private void DeleteStatus()
    { 
        try
        {
            this._modelOperation.DeleteStatus(this.SelectedDetailViewModel.Id);

            this.LoadStatuses();

            this._informer.InformSuccess("Status successfully deleted!");
        }
        catch (Exception e)
        {
            this._informer.InformError("Error while deleting Status :(");
        }
        
    }

    private async void LoadStatuses()
    {
        List<IStatusModel> Statuses = (List<IStatusModel>)this._modelOperation.GetAllStatuses();

        
        this._Statuses.Clear();

        foreach (IStatusModel s in Statuses)
        {
            this._Statuses.Add(new StatusDetailViewModel(s));
        }
        

        OnPropertyChanged(nameof(Statuses));
    }
}