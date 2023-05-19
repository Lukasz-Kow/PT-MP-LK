using Data.API;

namespace Data.Implementation;

internal class CustomerDTO: ICustomer
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Id { get; set; } = null!;
    public int Age { get; set; } = 0;
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    
}