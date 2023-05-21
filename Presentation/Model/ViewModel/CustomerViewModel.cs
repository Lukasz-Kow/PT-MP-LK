
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Presentation.Model.ModelAPI;

namespace Presentation.Model.ViewModel
{
    public partial class CustomerViewModel : ObservableObject
    {
        private ICustomerModel _customer;
        public CustomerViewModel() { }
        public CustomerViewModel(ICustomerModel customer)
        {
            _customer = customer;
        }

        public string CustomerId
        {
            get => _customer.Id;
            set
            {
                _customer.Id = value;
                OnPropertyChanged();
            }
        }
        public string FisrstName
        {
            get => _customer.FirstName;
            set
            {
                _customer.FirstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get => _customer.LastName;
            set
            {
                _customer.LastName = value;
                OnPropertyChanged();
            }
        }

        [ICommand]
        private async Task AddCustomer()
        {
            await _customer.AddAsync();
        }
        [ICommand]
        private async Task DeleteCustomer()
        {
            await _customer.DeleteAsync();
        }
    }
}
