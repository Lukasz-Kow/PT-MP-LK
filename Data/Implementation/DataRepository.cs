using Data.API;

namespace Data.Implementation;
internal class DataRepository : IDataRepository
{
    private readonly DataContext dataContext;

    public DataRepository()
    {
        dataContext = new DataContext();
    }
    
    /*
     * Customers
     */
    public void AddCustomer(ICustomer customer)
    {
        dataContext.Customers.Add(customer);
    }
    
    public ICustomer GetCustomerById(string id)
    {
        return dataContext.Customers.Single(u => u.Id == id);
    }
    
    public ICollection<ICustomer> GetAllUsers()
    {
        return dataContext.Customers;
    }
    
    public void DeleteCustomerWithId(string id)
    {
        dataContext.Customers.Remove(GetCustomerById(id));
    }
    
    public bool CustomerExists(string id)
    {
        return dataContext.Customers.Any(u => u.Id == id);
    }
    
    /*
     * Books
     */
    public void AddBook(IBook book)
    {
        dataContext.Books.Add(book.Id, book);
    }
    
    public IBook GetBookById(string id)
    {
        return dataContext.Books[id];
    }
    
    public ICollection<IBook> GetAllBooks()
    {
        return dataContext.Books.Values;
    }
    
    public void DeleteBookWithId(string id)
    {
        dataContext.Books.Remove(id);
    }
    
    public bool BookExists(string id)
    {
        return dataContext.Books.ContainsKey(id);
    }
    
    /*
     * Events
     */
    public void AddEvent(IEvent e)
    {
        dataContext.Events.Add(e);
    }
    
    public IEvent GetEventById(string id)
    {
        return dataContext.Events.Single(e => e.Id == id);
    }
    
    public ICollection<IEvent> GetAllEvents()
    {
        return dataContext.Events;
    }
    
    public void DeleteEventWithId(string id)
    {
        dataContext.Events.Remove(GetEventById(id));
    }
    
    public bool EventExists(string id)
    {
        return dataContext.Events.Any(e => e.Id == id);
    }
    
    /*
     * Statuses
     */
    public void AddStatus(IStatus status)
    {
        dataContext.States.Add(status);
    }
    
    public IStatus GetStatusById(string id)
    {
        return dataContext.States.Single(s => s.StatusId == id);
    }
    
    public ICollection<IStatus> GetAllStatuses()
    {
        return dataContext.States;
    }
    
    public void DeleteStatusWithId(string id)
    {
        dataContext.States.Remove(GetStatusById(id));
    }
    
    public bool StatusExists(string id)
    {
        return dataContext.States.Any(s => s.StatusId == id);
    }

    public bool IsAvailable(string statusId)
    {
        return GetStatusById(statusId).Availability;
    }

    public void ChangeAvailability(string id)
    {
        dataContext.States.Single(s => s.StatusId == id).Availability = !GetStatusById(id).Availability;
    }

}