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
    public override void AddCustomer(ICustomer customer)
    {
        dataContext.Customers.Add(customer);
    }
    
    public override ICustomer GetCustomerById(string id)
    {
        return dataContext.Customers.Single(u => u.Id == id);
    }
    
    public override ICollection<ICustomer> GetAllUsers()
    {
        return dataContext.Customers;
    }
    
    public override void DeleteCustomerWithId(string id)
    {
        dataContext.Customers.Remove(GetCustomerById(id));
    }
    
    public override bool CustomerExists(string id)
    {
        return dataContext.Customers.Any(u => u.Id == id);
    }
    
    /*
     * Books
     */
    public override void AddBook(IBook book)
    {
        dataContext.Books.Add(book.Id, book);
    }
    
    public override IBook GetBookById(string id)
    {
        return dataContext.Books[id];
    }
    
    public override ICollection<IBook> GetAllBooks()
    {
        return dataContext.Books.Values;
    }
    
    public override void DeleteBookWithId(string id)
    {
        dataContext.Books.Remove(id);
    }
    
    public override bool BookExists(string id)
    {
        return dataContext.Books.ContainsKey(id);
    }
    
    /*
     * Events
     */
    public override void AddEvent(IEvent e)
    {
        dataContext.Events.Add(e);
    }
    
    public override IEvent GetEventById(string id)
    {
        return dataContext.Events.Single(e => e.Id == id);
    }
    
    public override ICollection<IEvent> GetAllEvents()
    {
        return dataContext.Events;
    }
    
    public override void DeleteEventWithId(string id)
    {
        dataContext.Events.Remove(GetEventById(id));
    }
    
    public override bool EventExists(string id)
    {
        return dataContext.Events.Any(e => e.Id == id);
    }
    
    /*
     * Statuses
     */
    public override void AddStatus(IStatus status)
    {
        dataContext.States.Add(status);
    }
    
    public override IStatus GetStatusById(string id)
    {
        return dataContext.States.Single(s => s.StatusId == id);
    }
    
    public override ICollection<IStatus> GetAllStatuses()
    {
        return dataContext.States;
    }
    
    public override void DeleteStatusWithId(string id)
    {
        dataContext.States.Remove(GetStatusById(id));
    }
    
    public override bool StatusExists(string id)
    {
        return dataContext.States.Any(s => s.StatusId == id);
    }

    public override bool IsAvailable(string id, string statusId)
    {
        var status = dataContext.States.SingleOrDefault(s => s.StatusId == statusId && s.BookId == id);
        if (status == null) return false;
        return status.Availability;
    }

    public override void ChangeAvailability(string id)
    {
        dataContext.States.Single(s => s.StatusId == id).Availability = !GetStatusById(id).Availability;
    }

}