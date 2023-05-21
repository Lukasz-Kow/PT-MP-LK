using Services.API;
using Data.API;
using Services.Model;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ServicesTests")]

namespace Services.Implementation
{
    internal class dataServices : IServices
    {
        private IDataContext dataContext;

        internal dataServices(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task AddBook(string Title, string Author, string Id, int Pages, string ISBN, string Publisher, string Language)
        {
            await dataContext.AddBookAsync(new Book(Title, Author, Id, Pages, ISBN, Publisher, Language));
        }

        public async Task AddBuy(string Id, string StatusId, string CustomerId, DateTime Time)
        {
            await dataContext.AddBuyAsync(new Buy()
            {
                Id= Id,
                Status = dataContext.Statuses.Where(s => s.Id == StatusId).First(),
                Customer = dataContext.Customers.Where(c => c.Id == CustomerId).First(),
                Time = Time
            });
        }

        public async Task AddComplaint(string Id, string StatusId, string CustomerId, DateTime Time, string Reason)
        {
            await dataContext.AddComplaintAsync(new Complaint()
            {
                Id = Id,
                Status = dataContext.Statuses.Where(s => s.Id == StatusId).First(),
                Customer = dataContext.Customers.Where(c => c.Id == CustomerId).First(),
                Time = Time,
                Reason = Reason
            });
        }

        public async Task AddCustomer(string FirstName, string LastName, string Id, int Age, string Address, string City)
        {
            await dataContext.AddCustomerAsync(new Customer(FirstName, LastName, Id, Age, Address, City));
        }

        public async Task AddReturn(string Id, string StatusId, string CustomerId, DateTime Time)
        {
            await dataContext.AddReturnAsync(new Return()
            {
                Status = (from status in dataContext.Statuses where status.Id == StatusId select status).First(),
                Id = Id,
                Customer = dataContext.Customers.Where(c => c.Id == CustomerId).First()

            });
        }
                
        

        public async Task AddStatus(string StatusId, string BookId)
        {
            await dataContext.AddStatusAsync(new Status(StatusId,
                dataContext.Books.Where(c => c.Id == BookId).First()
                ));
        }

        public Task DeleteBook(string Id)
        {
            return dataContext.DeleteBookAsync(Id);
        }

        public Task DeleteBuy(string Id)
        {
            return dataContext.DeleteBuyAsync(Id);
        }

        public Task DeleteComplaint(string Id)
        {
            return dataContext.DeleteComplaintAsync(Id);
        }

        public Task DeleteCustomer(string Id)
        {
            return dataContext.DeleteCustomerAsync(Id);
        }

        public Task DeleteReturn(string Id)
        {
            return dataContext.DeleteReturnAsync(Id);
        }

        public Task DeleteStatus(string Id)
        {
            return dataContext.DeleteStatusAsync(Id);
        }

        public async Task<IEnumerable<API.IBook>> GetAllBooks()
        {
            return dataContext.Books.Select(b => new BookModel(b.Title, b.Author, b.Id, b.Pages, b.ISBN, b.Publisher, b.Language, this)).ToList();
        }

        public async Task<IEnumerable<API.ICustomer>> GetAllCustomers()
        {
            return dataContext.Customers.Select(c => new CustomerModel(c.Id, c.FirstName, c.LastName, c.Age, c.Address, c.City, this)).ToList();
        }

    }

}