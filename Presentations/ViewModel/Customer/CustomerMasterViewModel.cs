using Presentations.Model;

using Presentations.ViewModel.MVVMLight;

using System.Collections.ObjectModel;

namespace Presentations.ViewModel.Customer
{
    public class CustomerMasterViewModel : ViewModelBase
    {
        private ObservableCollection<CustomerModel> _customers;
        private CustomerModel _selectedCustomer;
        private CustomerModelOperations _customerModelOperations;
        private string _actionText;

        public CustomerMasterViewModel()
        {
            _customers = new ObservableCollection<CustomerModel>();
            _customerModelOperations = new CustomerModelOperations();
            AddCustomerCommand = new RelayCommand(AddCustomer);
            DeleteCustomerCommand = new RelayCommand(DeleteCustomer);
            FetchDataCommand = new RelayCommand(FetchData);
        }

        private string _firstName;
        private string _lastName;
        private string _id;
        private int _age;
        private string _address;
        private string _city;

        public ObservableCollection<CustomerModel> Customers
        {
            get => _customers;
            set
            {
                _customers = value;
                RaisePropertyChanged();
            }
        }

        public CustomerModel SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                RaisePropertyChanged();
                LoadDetailViewModel();
            }
        }

        public string ActionText
        {
            get => _actionText;
            set
            {
                _actionText = value;
                DisplayTextCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged();
            }
        }

        public RelayCommand AddCustomerCommand { get; }
        public RelayCommand DeleteCustomerCommand { get; }
        public RelayCommand FetchDataCommand { get; }
        public RelayCommand DisplayTextCommand { get; }

        private void AddCustomer()
        {
            var customerModel = new CustomerModel(_firstName, _lastName, _id, _age, _address, _city);
            Customers.Add(customerModel);
            _customerModelOperations.AddCustomer(_firstName, _lastName, _id, _age, _address, _city);
        }

        private void DeleteCustomer()
        {
            if (SelectedCustomer != null)
            {
                Customers.Remove(SelectedCustomer);
                _customerModelOperations.DeleteCustomer(SelectedCustomer.Id);
                SelectedCustomer = null;
            }
        }

        private void FetchData()
        {
            var customers = _customerModelOperations.GetAllCustomers();
            Customers = new ObservableCollection<CustomerModel>(customers);
        }

        private void LoadDetailViewModel()
        {
            if (SelectedCustomer != null)
            {
                var detailViewModel = new CustomerDetailViewModel(SelectedCustomer);
                // TODO: Pass the detailViewModel instance to the View for displaying additional info
            }
        }

    }
}
