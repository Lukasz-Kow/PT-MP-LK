
using System.Windows.Input;

namespace Presentations.ViewModel
{
    public interface ICustomerDetailViewModel
    {
        ICommand UpdateCustomer { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Id { get; set; }
        int Age { get; set; }
        string Address { get; set; }
        string City { get; set; }
    }
}
