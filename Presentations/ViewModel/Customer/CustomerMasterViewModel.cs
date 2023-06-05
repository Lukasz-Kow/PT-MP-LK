using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Presentations.Model.API;
using Presentations.ViewModel.Commands;


namespace Presentations.ViewModel;

internal class CustomerMasterViewModel : ViewModelBase, ICustomerMasterViewModel
{
    public ICommand SwitchToProductMasterPage { get; set; }

    public ICommand SwitchToStateMasterPage { get; set; }

    public ICommand SwitchToEventMasterPage { get; set; }

    public ICommand CreateCustomer { get; set; }

    public ICommand RemoveCustomer { get; set; }

    private readonly ICustomerModelOperations _modelOperation;

    private readonly IErrorPopup _informer;

    private ObservableCollection<ICustomerDetailViewModel> _customers;

    public ObservableCollection<ICustomerDetailViewModel> Customers
    {
        get => _customers;
        set
        {
            _customers = value;
            OnPropertyChanged(nameof(Customers));
        }
    }

    private string _firstName;

    public string FirstName
    {
        get => _firstName;
        set
        {
            _firstName = value;
            OnPropertyChanged(nameof(FirstName));
        }
    }

    private string _lastName;

    public string LastName
    {
        get => _lastName;
        set
        {
            _lastName = value;
            OnPropertyChanged(nameof(LastName));
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

    private int _age;

    public int Age
    {
        get => _age;
        set
        {
            _age = value;
            OnPropertyChanged(nameof(Age));
        }
    }

    private string _address;

    public string Address
    {
        get => _address;
        set
        {
            _address = value;
            OnPropertyChanged(nameof(Address));
        }
    }

    private string _city;

    public string City
    {
        get => _city;
        set
        {
            _city = value;
            OnPropertyChanged(nameof(City));
        }
    }

    private bool _isCustomerSelected;

    public bool IsCustomerSelected
    {
        get => _isCustomerSelected;
        set
        {
            this.IsCustomerDetailVisible = value ? Visibility.Visible : Visibility.Hidden;

            _isCustomerSelected = value;
            OnPropertyChanged(nameof(IsCustomerSelected));
        }
    }

    private Visibility _isCustomerDetailVisible;

    public Visibility IsCustomerDetailVisible
    {
        get => _isCustomerDetailVisible;
        set
        {
            _isCustomerDetailVisible = value;
            OnPropertyChanged(nameof(IsCustomerDetailVisible));
        }
    }

    private ICustomerDetailViewModel _selectedDetailViewModel;

    public ICustomerDetailViewModel SelectedDetailViewModel
    {
        get => _selectedDetailViewModel;
        set
        {
            _selectedDetailViewModel = value;
            this.IsCustomerSelected = true;

            OnPropertyChanged(nameof(SelectedDetailViewModel));
        }
    }

    public CustomerMasterViewModel(ICustomerModelOperations? model = null, bool? showPopups = true, IErrorPopup? informer = null)
    {
        this.SwitchToProductMasterPage = new SwitchViewCommand("BookMasterView");
        this.SwitchToStateMasterPage = new SwitchViewCommand("StatusMasterView");
        this.SwitchToEventMasterPage = new SwitchViewCommand("EventMasterView");

        this.CreateCustomer = new OnClickCommand(e => this.StoreCustomer(), c => this.CanStoreCustomer());
        this.RemoveCustomer = new OnClickCommand(e => this.DeleteCustomer());

        this.Customers = new ObservableCollection<ICustomerDetailViewModel>();

        this._modelOperation = model ?? ICustomerModelOperations.CreateModelOperation();

        if (showPopups == true)
        {
            this._informer = informer ?? new ErrorPopupHandler();
        }

        this.IsCustomerSelected = false;

        this.LoadCustomers();
    }

    private bool CanStoreCustomer()
    {
        return !(
            string.IsNullOrWhiteSpace(this.FirstName) ||
            string.IsNullOrWhiteSpace(this.LastName) ||
            string.IsNullOrWhiteSpace(this.Id) ||
            string.IsNullOrWhiteSpace(this.Address) ||
            string.IsNullOrWhiteSpace(this.City) ||
            this.Age <= 0
        );
    }

    private void StoreCustomer()
    {
        

        this._modelOperation.AddCustomer(FirstName, LastName, Id, Age, Address, City);

        if (this._informer != null)
        {
            this._informer.InformSuccess("Customer successfully created!");
        }

        this.LoadCustomers();
     
    }

    private void DeleteCustomer()
    {
       
        try
        {
            this._modelOperation.DeleteCustomer(this.SelectedDetailViewModel.Id);

            if (this._informer != null)
                this._informer.InformSuccess("Customer successfully deleted!");

            this.LoadCustomers();
        }
        catch (Exception e)
        {
            if (this._informer != null)
                this._informer.InformError("Error while deleting customer :(");
        }
        
    }

    private async void LoadCustomers()
    {
        IEnumerable<ICustomerModel> Customers = this._modelOperation.GetAllCustomers();

        
        this._customers.Clear();

        foreach (ICustomerModel u in Customers)
        {
            this._customers.Add(new CustomerDetailViewModel(u));
        }
        

        OnPropertyChanged(nameof(Customers));
    }
}