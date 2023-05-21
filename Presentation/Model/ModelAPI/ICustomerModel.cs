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

        Task AddAsync();
        Task DeleteAsync();
    }
}
