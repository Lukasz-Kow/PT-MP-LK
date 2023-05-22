using System.Threading.Tasks;

namespace Presentation.Model.ModelAPI
{
    public interface ICustomerModel
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Id { get; set; }

        int Age { get; set; }

        string Address { get; set; }

        string City { get; set; }

        public void AddCustomer(string FirstName, string LastName, string Id, int Age, string Address, string City);

    }
}
