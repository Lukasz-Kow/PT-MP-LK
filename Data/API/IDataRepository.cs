using Data.Implementation;

namespace Data.API;

public interface IDataRepository
{

 public static IDataRepository CDataRepository()
 {
  return new DataRepository();
 }

    /*
     * Customer methods
     */
    public void AddCustomer(ICustomer customer);
    
    public ICustomer GetCustomerById(string id);
    public ICollection<ICustomer> GetAllUsers();
    
    public void DeleteCustomerWithId(string id);
    
    public bool CustomerExists(string id);
    
    /*
     * Book methods
     */
    public void AddBook(IBook book);
    
    public IBook GetBookById(string id);
    
    public ICollection<IBook> GetAllBooks();
    
    public void DeleteBookWithId(string id);
    
    public bool BookExists(string id);
    
    /*
     * Event methods
     */
    public void AddEvent(IEvent e);
    
    public IEvent GetEventById(string id);
    public ICollection<IEvent> GetAllEvents();
    
    public void DeleteEventWithId(string id);
    
    public bool EventExists(string id);
    
    
    /*
     * Status methods
     */
    public void AddStatus(IStatus status);
    
    public IStatus GetStatusById(string id);
    
    public ICollection<IStatus> GetAllStatuses();
    
    public void DeleteStatusWithId(string id);
    
    public bool StatusExists(string id);
    public bool IsAvailable(string statusId);
    public void ChangeAvailability(string id);

}