using Services.Implementation;
using Data.API;

namespace Services.API
{
    public interface IServices
    {
        public static IServices Create() => new dataServices(IDataContext.CreateContext());

        //Books
        Task<IEnumerable<IBook>> GetAllBooks();
        Task AddBook(string Title, string Author, string Id, int Pages, string ISBN, string Publisher, string Language);
        Task DeleteBook(string Id);

        //Customer
        Task<IEnumerable<ICustomer>> GetAllCustomers();
        Task AddCustomer(string FirstName, string LastName, string Id, int Age, string Address, string City);
        Task DeleteCustomer(string Id);

        //Status
        Task AddStatus(string BookId, string StatusId);
        Task DeleteStatus(string StatusId);

        //Buy
        Task AddBuy(string id, string statusId, string customerId, DateTime time);
        Task DeleteBuy(string id);

        //Return
        Task AddReturn(string Id, string StatusId, string CustomerId, DateTime Time);
        Task DeleteReturn(string Id);

        //Complaint
        Task AddComplaint(string Id, string StatusId, string CustomerId, DateTime Time, string Reason);
        Task DeleteComplaint(string Id);
    }
}
    