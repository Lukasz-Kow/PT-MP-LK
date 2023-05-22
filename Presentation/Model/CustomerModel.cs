using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Presentation.Model.ModelAPI;
using Services.API;

namespace Presentation.Model
{
    internal class CustomerModel : ICustomerModel
    {

        public CustomerModel(string firstName, string lastName, string id, int age, string address, string city) 
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
            Age = age;
            Address = address;
            City = city;

            Service = IServices.Create();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public IServices Service { get; }

        public void AddCustomer(string FirstName, string LastName, string Id, int Age, string Address, string City)
        {
            Service.AddCustomer(FirstName, LastName, Id, Age, Address, City);
        }
    }
}
