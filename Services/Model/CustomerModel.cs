using Services.API;

namespace Services.Model
{
    internal class CustomerModel : ICustomer
    {
        public CustomerModel(string id, string firstName, string lastName, int age, string address, string city, IServices service)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Address = address;
            City = city;
            Service = service;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Id { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Service { get; }

        public async Task AddAsync()
        {
            await Service.AddCustomer(Id, FirstName, LastName, Age, Address, City);
        }

        public async Task DeleteAsync()
        {
            await Service.DeleteCustomer(Id);
        }
    }
}

