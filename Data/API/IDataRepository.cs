using Data.Implementation;
using System.Data.Linq;

namespace Data.API;

public interface IDataRepository
{

    public static IDataRepository CDataRepository(string connectStr)
    {
        return new DataRepository(connectStr);
    }

    // Customers
    List<ICustomer> GetAllCustomers();
    ICustomer GetCustomer(int id);
    ICustomer GetCustomer_QuerySyntax(int id);
    void InsertCustomer(string id, string firstName, string lastName, int age, string address, string city);
    void UpdateCustomer(string id, string firstName, string lastName, int age, string address, string city);
    void DeleteCustomer(int customerId);

    // Books
    List<IBook> GetAllBooks();
    public List<IBook> GetAllBooks_QuerySyntax();
    IBook GetBook(int id);
    public IBook GetBook_QuerySyntax(int id);
    void InsertBook(string id, string title, string author, int pages, string ISBN, string publisher, string language);
    void UpdateBook(string id, string title, string author, int pages, string ISBN, string publisher, string language);
    void DeleteBook(int bookId);

    // Statuses
    List<IStatus> GetAllStatuses();
    IStatus GetStatus(int id);
    public IStatus GetStatus_QuerySyntax(int id);
    void InsertStatus(string statusId, string book, bool available);
    void UpdateStatus(string statusId, string book, bool available);
    void DeleteStatus(int statusId);

    // Events
    List<IEvent> GetAllEvents();
    IEvent GetEvent(int id);
    public IEvent GetEvent_QuerySyntax(int id);
    void InsertEvent(string id, string customer, string status, DateTime date, string type, string reasonOrDescription = "");
    void UpdateEvent(string id, string customer, string status, DateTime date, string type, string reasonOrDescription = "");
    void DeleteEvent(int eventId);

    // Other methods
    void DropAllCustomers();
    void DropAllBooks();
    void DropAllStatuses();
    void DropAllEvents();
    void DropAll();
}