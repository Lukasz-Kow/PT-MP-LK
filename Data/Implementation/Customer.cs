using Data.API;
using System.Runtime.CompilerServices;
[assembly:InternalsVisibleTo("TestData")]
[assembly:InternalsVisibleTo("LogicTest")]

namespace Data.Implementation;

internal class Customer : ICustomer
{
    public Customer(string id, string firstName, string lastName, int age, string address, string city)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Address = address;
        City = city;
    }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Id { get; set; }
    
    public int Age { get; set; }
    
    public string Address { get; set; }
    
    public string City { get; set; }
}