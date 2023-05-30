using Services.Implementation;
using Data.API;

namespace Services.API
{
    public interface IServices
    {
        //Mati
        //public static IServices Create() => new dataServices("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Studia\\PrijectPT\\Data\\BookShopDB.mdf;Integrated Security=True");

        //Lukasz
        // Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\4IT\\Programming Technologies\\GIT\\ProjectPT\\Data\\BookShopDB.mdf\";Integrated Security=True
        
        public static IServices Create(string connectionLink) => new dataServices(connectionLink);

        public void AddBook(string Title, string Author, string Id, int Pages, string ISBN, string Publisher, string Language);
        public void AddBuy(string Id, string statusId, string customerId, DateTime Time);
        public void AddComplaint(string Id, string statusId, string customerId, DateTime Time, string Reason);
        public void AddReview(string Id, string statusId, string customerId, DateTime Time, string description);
        public void AddCustomer(string FirstName, string LastName, string Id, int Age, string Address, string City);
        public void AddReturn(string Id, string statusId, string customerId, DateTime Time);
        public void AddStatus(string StatusId, string bookId, bool availability);

        public void UpdateBook(string Title, string Author, string Id, int Pages, string ISBN, string Publisher, string Language);
        public void UpdateCustomer(string FirstName, string LastName, string Id, int Age, string Address, string City);
        public void UpdateStatus(string StatusId, string bookId, bool availability);
        public void UpdateBuy(string Id, string statusId, string customerId, DateTime Time);
        public void UpdateComplaint(string Id, string statusId, string customerId, DateTime Time, string Reason);
        public void UpdateReview(string Id, string statusId, string customerId, DateTime Time, string description);
        public void UpdateReturn(string Id, string statusId, string customerId, DateTime Time);

        public void DeleteBook(string Id);
        public void DeleteEvent(string Id);
        public void DeleteStatus(string Id);
        public void DeleteCustomer(string Id);

        public List<IBook> GetAllBooks();
        public List<ICustomer> GetAllCustomers();
        public List<IStatus> GetAllStatuses();
        public List<IEvent> GetAllEvents();

        public IBook GetBookById(string Id);
        public ICustomer GetCustomerById(string Id);
        public IStatus GetStatusById(string Id);
        public IEvent GetEventById(string Id);


        public void DropTables();
    }
}
    