

namespace Presentations.Model.API
{
    public interface ICustomerModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}
