using Data.API;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementation;

internal class DataContext : DbContext, IDataContext
{
    private const string defaultConnectionString = 
        // Mateusz
        @"Server=(localdb)\LocalDBApp1";
    

    private readonly string _connectionString;
    
    public DataContext( string? connectionString = null)
    {
        this._connectionString = connectionString ?? defaultConnectionString;
    }

    public DbSet<CustomerDTO> _customers { get; set; }
    public IQueryable<ICustomer> Customers { get; }
    
    public DbSet<BookDTO> _books { get; set; }
    public IQueryable<IBook> Books { get; }
    public IQueryable<IStatus> Statuses { get; }

    public DbSet<StatusDTO> _statuses { get; set; }
    public IQueryable<IStatus> States { get; }
    
    public DbSet<ReturnDTO> _returns { get; set; }
    public IQueryable<IReturn> Returns { get; }
    
    public DbSet<BuyDTO> _buys { get; set; }
    public IQueryable<IBuy> Buys { get; }
    
    public DbSet<ComplaintDTO> _complaints { get; set; }
    public IQueryable<IComplaint> Complaints { get; }
    
    public DbSet<ReviewDTO> _reviews { get; set; }
    public IQueryable<IReview> Reviews { get; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<StatusDTO>().HasOne(state => (BookDTO)state.Book);
        
        modelBuilder.Entity<ReturnDTO>().HasOne(@return => @return.Status);
        modelBuilder.Entity<ReturnDTO>().HasOne(@return => @return.CustomerId);
        
        modelBuilder.Entity<BuyDTO>().HasOne(buy => buy.CustomerId);
        modelBuilder.Entity<BuyDTO>().HasOne(buy => buy.StatusId);
        
        modelBuilder.Entity<ComplaintDTO>().HasOne(complaint => complaint.CustomerId);
        modelBuilder.Entity<ComplaintDTO>().HasOne(review => review.StatusId);
        
        modelBuilder.Entity<ReviewDTO>().HasOne(review => review.CustomerId);
        modelBuilder.Entity<ReviewDTO>().HasOne(review => review.StatusId);

    }
    public async Task AddBookAsync(IBook book)
    {
        BookDTO bookToAdd = new() { Id = book.Id, Author = book.Author, Title = book.Title};
        await _books.AddAsync(bookToAdd);
        await SaveChangesAsync();
    }

    public async Task AddBuyAsync(IBuy buy)
    {
        BuyDTO buyToAdd = new() { Id = buy.Id, CustomerId = buy.Customer, StatusId = buy.Status,
            Time = DateTime.Now};
        await _buys.AddAsync(buyToAdd);
        await SaveChangesAsync();
    }

    public async Task AddReturnAsync(IReturn @return)
    {
        ReturnDTO returnToAdd = new() { Id = @return.Id, CustomerId = @return.Customer, Status = @return.Status,
            Time = DateTime.Now};
        await _returns.AddAsync(returnToAdd);
        await SaveChangesAsync();
    }

    public async Task AddComplaintAsync(IComplaint complaint)
    {
        ComplaintDTO complaintToAdd = new() { Id = complaint.Id, CustomerId = complaint.Customer,
            StatusId = complaint.Status, Time = DateTime.Now, Reason = complaint.Reason};
        await _complaints.AddAsync(complaintToAdd);
        await SaveChangesAsync();
    }

    public async Task AddReviewAsync(IReview review)
    {
        ReviewDTO reviewToAdd = new() { Id = review.Id, CustomerId = review.CustomerId, StatusId = review.StatusId,
            Time = DateTime.Now, Description = review.Description};
        await _reviews.AddAsync(reviewToAdd);
        await SaveChangesAsync();
    }

    public async Task AddStatusAsync(IStatus status)
    {
        StatusDTO statusToAdd = new() { Status = status.Status, Book = status.Book,
            Availability = status.Availability};
        await _statuses.AddAsync(statusToAdd);
        await SaveChangesAsync();
    }

    public async Task AddCustomerAsync(ICustomer customer)
    {
        CustomerDTO userToAdd = new() { FirstName = customer.FirstName, LastName = customer.LastName, Id = customer.Id };
        await _customers.AddAsync(userToAdd);
        await SaveChangesAsync();
    }

    public async Task DeleteBookAsync(string Id)
    {
        BookDTO? entityToRemove = await _books.FindAsync(Id);
        if(entityToRemove != null)
        {
            _books.Remove(entityToRemove);
            await SaveChangesAsync();
        }
    }

    public async Task DeleteBuyAsync(string Id)
    {
        BuyDTO? entityToRemove = _buys.FindAsync(Id).Result;
        if(entityToRemove != null)
        {
            _buys.Remove(entityToRemove);
            await SaveChangesAsync();
        }
    }

    public async Task DeleteReturnAsync(string Id)
    {
        ReturnDTO? entityToRemove = _returns.FindAsync(Id).Result;
        if(entityToRemove != null)
        {
            _returns.Remove(entityToRemove);
            await SaveChangesAsync();
        }
    }

    public async Task DeleteComplaintAsync(string Id)
    {
        ComplaintDTO? entityToRemove = _complaints.FindAsync(Id).Result;
        if(entityToRemove != null)
        {
            _complaints.Remove(entityToRemove);
            await SaveChangesAsync();
        }
    }

    public async Task DeleteReviewAsync(string Id)
    {
        ReviewDTO? entityToRemove = _reviews.FindAsync(Id).Result;
        if(entityToRemove != null)
        {
            _reviews.Remove(entityToRemove);
            await SaveChangesAsync();
        }
    }

    public async Task DeleteStatusAsync(string Id)
    {
        StatusDTO? entityToRemove = _statuses.FindAsync(Id).Result;
        if(entityToRemove != null)
        {
            _statuses.Remove(entityToRemove);
            await SaveChangesAsync();
        }
    }

    public async Task DeleteCustomerAsync(string Id)
    {
        CustomerDTO? entityToRemove = _customers.FindAsync(Id).Result;
        if(entityToRemove != null)
        {
            _customers.Remove(entityToRemove);
            await SaveChangesAsync();
        }
    }
}