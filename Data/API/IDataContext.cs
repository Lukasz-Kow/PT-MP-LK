using Data.Implementation;

namespace Data.API;

public interface IDataContext
{
    public IQueryable<ICustomer> Customers { get;}

    public IQueryable<IBook> Books { get;}

    public IQueryable<IStatus> Statuses { get;}
  
    public IQueryable<IReturn> Returns { get;}
    public IQueryable<IBuy> Buys { get; }
    
    public IQueryable<IComplaint> Complaints { get; }
    
    public IQueryable<IReview> Reviews { get; }


    public static IDataContext CreateContext(string? connectionString = null) => new DataContext(connectionString);
    Task AddBookAsync(IBook book);
    Task AddBuyAsync(IBuy buy);
    Task AddReturnAsync(IReturn @return);
    Task AddComplaintAsync(IComplaint complaint);
    Task AddReviewAsync(IReview review);
    Task AddStatusAsync(IStatus status);
    Task AddCustomerAsync(ICustomer customer);
    Task DeleteBookAsync(string Id);
    Task DeleteBuyAsync(string Id);
    Task DeleteReturnAsync(string Id);
    Task DeleteComplaintAsync(string Id);
    Task DeleteReviewAsync(string Id);
    Task DeleteStatusAsync(string Id);
    Task DeleteCustomerAsync(string Id);
}