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

        public async Task AddBuy(string id, string statusId, string customerId, DateTime time)
        {
            /*await dataContext.AddBuyAsync(new Buy(
                Id = id,
                StatusId = dataContext.Statuses.Where(s => s.Id == statusId).First(),
                CustomerId = dataContext.Customers.Where(c => c.Id == customerId).First(),
                Time = time
                )); */
        }

        public async Task AddComplaint(string id, string statusId, string customerId, DateTime time, string reason)
        {
            
        }

        public async Task AddCustomer(string FirstName, string LastName, string Id, int Age, string Address, string City)
        {
            await dataContext.AddCustomerAsync(new Customer(FirstName, LastName, Id, Age, Address, City));
        }

        public async Task AddReturn(string Id, string StatusId, string CustomerId, DateTime Time)
        {
        }

        public async Task AddStatus(string StatusId, string BookId)
        {
            await dataContext.AddStatusAsync(new Status(StatusId,
                dataContext.Books.Where(c => c.Id == BookId).First()
                ));
        }

        public async Task DeleteBook(string Id)
        {
            
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

        public Task<IEnumerable<API.IBook>> GetAllBooks()
        {
            return dataContext.Books.Select(c => new BookModel(c.Title, c.Author, c.Id, c.Pages, c.ISBN, c.Publisher, c.Language, this)).ToList();

        }

        public Task<IEnumerable<API.ICustomer>> GetAllCustomers()
        {
            
        }
    }
}
