using Data.Implementation;

namespace Data.API;

public abstract class IDataRepository
{

 public static IDataRepository CDataRepository()
 {
  return new DataRepository();
 }

    /*
     * Customer methods
     */
    public abstract void AddCustomer(ICustomer customer);
    
    public abstract ICustomer GetCustomerById(string id);
    public abstract ICollection<ICustomer> GetAllUsers();
    
    public abstract void DeleteCustomerWithId(string id);
    
    public abstract bool CustomerExists(string id);
    
    /*
     * Book methods
     */
    public abstract void AddBook(IBook book);
    
    public abstract IBook GetBookById(string id);
    
    public abstract ICollection<IBook> GetAllBooks();
    
    public abstract void DeleteBookWithId(string id);
    
    public abstract bool BookExists(string id);
    
    /*
     * Event methods
     */
    public abstract void AddEvent(IEvent e);
    
    public abstract IEvent GetEventById(string id);
    public abstract ICollection<IEvent> GetAllEvents();
    
    public abstract void DeleteEventWithId(string id);
    
    public abstract bool EventExists(string id);
    
    
    /*
     * Status methods
     */
    public abstract void AddStatus(IStatus status);
    
    public abstract IStatus GetStatusById(string id);
    
    public abstract ICollection<IStatus> GetAllStatuses();
    
    public abstract void DeleteStatusWithId(string id);
    
    public abstract bool StatusExists(string id);
    public abstract bool IsAvailable(string id);
    public abstract void ChangeAvailability(string id);

}