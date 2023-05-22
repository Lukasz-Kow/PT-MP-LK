using Castle.Core.Resource;
using Data.API;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Linq;

namespace Data.Implementation;
internal class DataRepository : IDataRepository
{
    private readonly BookShopDBLDataContext dbContext;
    private readonly string _connectionString;

    public DataRepository(string connectionString)
    {
        // dbContext = new BookShopDBLDataContext("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Studia\\PrijectPT\\Data\\BookShopDB.mdf;Integrated Security=True");
        _connectionString = connectionString;
    }


    public ICustomer GetCustomer(int id)
    {
        using (BookShopDBLDataContext dbContext = new BookShopDBLDataContext(this._connectionString))
        {
            var customerEntity = dbContext.Customers.FirstOrDefault(c => c.Id == id);
            if (customerEntity == null)
            {
                return null;
            }
            return new Customer(customerEntity.Id.ToString(), customerEntity.FirstName.TrimEnd(), customerEntity.LastName.TrimEnd(),
                customerEntity.Age ?? 0, customerEntity.Address.TrimEnd(), customerEntity.City.TrimEnd());
        }
    }

    public void InsertCustomer(ICustomer customer)
    {
        using (BookShopDBLDataContext dbContext = new BookShopDBLDataContext(this._connectionString))
        {
            Customers customerEntity = new Customers()
            {
                Id = Convert.ToInt32(customer.Id),
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Age = customer.Age,
                Address = customer.Address,
                City = customer.City
            };

            dbContext.Customers.InsertOnSubmit(customerEntity);
            dbContext.SubmitChanges();

        }
    }

    public void UpdateCustomer(ICustomer updatedCustomer)
    {
        using (var dbContext = new BookShopDBLDataContext(_connectionString))
        {
            var existingCustomer = dbContext.Customers.FirstOrDefault(c => c.Id.ToString() == updatedCustomer.Id);

            if (existingCustomer != null)
            {
                // Update the properties of the existing customer with the new values
                existingCustomer.FirstName = updatedCustomer.FirstName;
                existingCustomer.LastName = updatedCustomer.LastName;
                existingCustomer.Age = updatedCustomer.Age;
                existingCustomer.Address = updatedCustomer.Address;
                existingCustomer.City = updatedCustomer.City;

                dbContext.SubmitChanges();
            }
        }
    }

   


}