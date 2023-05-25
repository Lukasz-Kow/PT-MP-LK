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
    void InsertCustomer(ICustomer newCustomer);
    void UpdateCustomer(ICustomer updatedCustomer);
    void DeleteCustomer(int customerId);

    // Books
    List<IBook> GetAllBooks();
    public List<IBook> GetAllBooks_QuerySyntax();
    IBook GetBook(int id);
    public IBook GetBook_QuerySyntax(int id);
    void InsertBook(IBook newBook);
    void UpdateBook(IBook updatedBook);
    void DeleteBook(int bookId);

    // Statuses
    List<IStatus> GetAllStatuses();
    IStatus GetStatus(int id);
    void InsertStatus(IStatus newStatus);
    void UpdateStatus(IStatus updatedStatus);
    void DeleteStatus(int statusId);

    // Events
    List<IEvent> GetAllEvents();
    IEvent GetEvent(int id);
    void InsertEvent(IEvent newEvent);
    void UpdateEvent(IEvent updatedEvent);
    void DeleteEvent(int eventId);

    // Other methods
    void DropAllCustomers();
    void DropAllBooks();
    void DropAllStatuses();
    void DropAllEvents();
    void DropAll();
}