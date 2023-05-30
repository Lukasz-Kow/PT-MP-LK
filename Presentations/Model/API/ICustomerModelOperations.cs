using Presentations.Model.Implementation;
using System.Collections.Generic;

namespace Presentations.Model.API
{
    interface ICustomerModelOperations
    {

        static ICustomerModelOperations CreateModelOperation()
        {
            return new CustomerModelOperations();
        }

        public void AddCustomer(string firstName, string lastName, string id, int age, string address, string city);
        public void DeleteCustomer(string customerId);
        public IEnumerable<ICustomerModel> GetAllCustomers();
    }
}
