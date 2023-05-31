namespace Services.API;

public interface ICustomerDTO
{
    string FirstName { get; set; }
    string LastName { get; set; }
    string Id { get; set; }
    
    int Age { get; set; }
    
    string Address { get; set; }
    
    string City { get; set; }

}