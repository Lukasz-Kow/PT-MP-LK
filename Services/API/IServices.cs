using Services.Implementation;
using Data.API;

namespace Services.API
{
    public interface IServices
    {
        public static IServices Create() => new dataServices("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Studia\\PrijectPT\\Data\\BookShopDB.mdf;Integrated Security=True");

        public void AddBook(string Title, string Author, string Id, int Pages, string ISBN, string Publisher, string Language);
        public void AddBuy(string Id, IStatus status, ICustomer customer, DateTime Time);
        public void AddComplaint(string Id, IStatus status, ICustomer customer, DateTime Time, string Reason);
        public void AddReview(string Id, IStatus status, ICustomer customer, DateTime Time, string description);
        public void AddCustomer(string FirstName, string LastName, string Id, int Age, string Address, string City);
        public void AddReturn(string Id, IStatus status, ICustomer customer, DateTime Time);
        public Task AddStatus(string StatusId, IBook book, bool availability);

        public void DeleteBook(string Id);
        public void DeleteBuy(string Id);
        public void DeleteStatus(string Id);

        public List<IBook> GetAllBooks();
        public List<ICustomer> GetAllCustomers();

        public void DropTables();
    }
}
    