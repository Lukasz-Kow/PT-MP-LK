using Presentations.ViewModel.MVVMLight;
using Presentations.Model;

namespace Presentations.ViewModel
{
    public class CustomerDetailViewModel: ViewModelBase
    {
        private CustomerModel _customerModel;

        public CustomerDetailViewModel(CustomerModel customerModel)
        {
            _customerModel = customerModel;
        }

        public string FirstName
        {
            get => _customerModel.FirstName;
            set
            {
                _customerModel.FirstName = value;
                RaisePropertyChanged();
            }
        }

        public string LastName
        {
            get => _customerModel.LastName;
            set
            {
                _customerModel.LastName = value;
                RaisePropertyChanged();
            }
        }

        public string Id
        {
            get => _customerModel.Id;
            set
            {
                _customerModel.Id = value;
                RaisePropertyChanged();
            }
        }

        public int Age
        {
            get => _customerModel.Age;
            set
            {
                _customerModel.Age = value;
                RaisePropertyChanged();
            }
        }

        public string Address
        {
            get => _customerModel.Address;
            set
            {
                _customerModel.Address = value;
                RaisePropertyChanged();
            }
        }

        public string City
        {
            get => _customerModel.City;
            set
            {
                _customerModel.City = value;
                RaisePropertyChanged();
            }
        }
    }
}
