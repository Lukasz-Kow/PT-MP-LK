using System.Windows.Input;
using Presentations.Model.API;
using Presentations.ViewModel.Commands;

namespace Presentations.ViewModel;

internal class CustomerDetailViewModel : ViewModelBase, ICustomerDetailViewModel
{
    public ICommand UpdateCustomer { get; set; }

    private readonly ICustomerModelOperations _modelOperation;

    private readonly IErrorPopup _informer;

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

    public CustomerDetailViewModel(ICustomerModel model, ICustomerModelOperations? modelOps = null, IErrorPopup? informer = null)
    {

        this.Id = model.Id;
        this.FirstName = model.FirstName;
        this.LastName = model.LastName;
        this.Age = model.Age;
        this.Address = model.Address;
        this.City = model.City;

        this.UpdateCustomer = new OnClickCommand(e => this.Update(), c => this.CanUpdate());

        this._modelOperation = modelOps ?? ICustomerModelOperations.CreateModelOperation();
        this._informer = informer ?? new ErrorPopupHandler();
    }

    private void Update()
    {
        
            this._modelOperation.UpdateCustomer(this.Id, this.FirstName, this.LastName, Age, Address, City);

            this._informer.InformSuccess("Customer successfully updated!");
        
    }

    private bool CanUpdate()
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
}