using Services.API;
using System.Collections.Generic;

namespace Presentations.Model
{
    public class CustomerModelOperations
    {
        private readonly IServices services;

        public CustomerModelOperations()
        {
            services = IServices.Create("");
        }

        public void AddCustomer(string firstName, string lastName, string id, int age, string address, string city)
        {
            services.AddCustomer(firstName, lastName, id, age, address, city);
        }

        public void DeleteCustomer(string customerId)
        {
            services.DeleteCustomer(customerId);
        }

        public List<CustomerModel> GetAllCustomers()
        {
            var customers = services.GetAllCustomers();
            var customerModels = new List<CustomerModel>();

            foreach (var customer in customers)
            {
                customerModels.Add(new CustomerModel(customer.FirstName, customer.LastName, customer.Id, customer.Age, customer.Address, customer.City));
            }

            return customerModels;
        }
    }
}
