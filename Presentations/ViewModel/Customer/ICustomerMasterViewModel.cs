

using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using Presentations.Model.API;

namespace Presentations.ViewModel
{
    public interface ICustomerMasterViewModel
    {

        static ICustomerMasterViewModel Create(ICustomerModelOperations model)
        {
            return new CustomerMasterViewModel(model);
        }

        ICommand SwitchToProductMasterPage { get; set; }
        ICommand SwitchToStateMasterPage { get; set; }
        ICommand SwitchToEventMasterPage { get; set; }
        ICommand CreateCustomer { get; set; }
        ICommand RemoveCustomer { get; set; }
        ObservableCollection<ICustomerDetailViewModel> Customers { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Id { get; set; }
        int Age { get; set; }
        string Address { get; set; }
        string City { get; set; }
        bool IsCustomerSelected { get; set; }
        Visibility IsCustomerDetailVisible { get; set; }
        ICustomerDetailViewModel SelectedDetailViewModel { get; set; }
    }
}
