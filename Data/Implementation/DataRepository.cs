
using Data.API;

using System.Data.Linq;

namespace Data.Implementation;
internal class DataRepository : IDataRepository
{
    private readonly BookShopDBLDataContext dbContext;
    private readonly string _connectionString;

    public DataRepository(string connectionString)
    {
        // dbContext = new BookShopDBLDataContext("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Studia\\PrijectPT\\Data\\BookShopDB.mdf;Integrated Security=True");
        _connectionString = connectionString;
    }

    #region Customer CRUD
    public ICustomer GetCustomer(int id)
    {
        using (BookShopDBLDataContext dbContext = new BookShopDBLDataContext(this._connectionString))
        {
            var customerEntity = dbContext.Customers.Where(c => c.Id == id);
            if (customerEntity is not null)
            {
                var customerToReturn_Entity = customerEntity.First();

                return new Customer(customerToReturn_Entity.Id.ToString(), customerToReturn_Entity.FirstName.TrimEnd(), customerToReturn_Entity.LastName.TrimEnd(),
                                                      customerToReturn_Entity.Age ?? 0, customerToReturn_Entity.Address.TrimEnd(), customerToReturn_Entity.City.TrimEnd());
            } else
            {
                throw new Exception("Customer not found");
            }
            
        }
    }

    public ICustomer GetCustomer_QuerySyntax(int id)
    {
        using (BookShopDBLDataContext dbContext = new BookShopDBLDataContext(this._connectionString))
        {
            IQueryable<Customers> query =
                 from c in dbContext.Customers
                 where c.Id == id
                 select c;

            if (query == null)
            {
                throw new Exception("Customer not found");
            }

            ICustomer customerToReturn = new Customer(query.First().Id.ToString(), query.First().FirstName.TrimEnd(), query.First().LastName.TrimEnd(),
                               query.First().Age ?? 0, query.First().Address.TrimEnd(), query.First().City.TrimEnd());

            return customerToReturn;

        }
    }

    public List<ICustomer> GetAllCustomers()
    {
        using (var dbContext = new BookShopDBLDataContext(_connectionString))
        {
            var customerEntities = dbContext.Customers.ToList();
            List<ICustomer> customers = customerEntities
                .Select(c => new Customer(c.Id.ToString(), c.FirstName, c.LastName, c.Age ?? 0, c.Address, c.City) as ICustomer)
                .ToList();
            return customers;
        }
    }

    public void InsertCustomer(ICustomer customer)
    {
        using (BookShopDBLDataContext dbContext = new BookShopDBLDataContext(this._connectionString))
        {
            Customers customerEntity = new Customers()
            {
                Id = Convert.ToInt32(customer.Id),
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Age = customer.Age,
                Address = customer.Address,
                City = customer.City
            };

            dbContext.Customers.InsertOnSubmit(customerEntity);
            dbContext.SubmitChanges();

        }
    }

    public void UpdateCustomer(ICustomer updatedCustomer)
    {
        using (var dbContext = new BookShopDBLDataContext(_connectionString))
        {
            var existingCustomer = dbContext.Customers.FirstOrDefault(c => c.Id.ToString() == updatedCustomer.Id);

            if (existingCustomer != null)
            {
                // Update the properties of the existing customer with the new values
                existingCustomer.FirstName = updatedCustomer.FirstName;
                existingCustomer.LastName = updatedCustomer.LastName;
                existingCustomer.Age = updatedCustomer.Age;
                existingCustomer.Address = updatedCustomer.Address;
                existingCustomer.City = updatedCustomer.City;

                dbContext.SubmitChanges();
            }
        }
    }

    public void DeleteCustomer(int customerId)
    {
        using (var dbContext = new BookShopDBLDataContext(_connectionString))
        {
            var customerToDelete = dbContext.Customers.FirstOrDefault(c => c.Id == customerId);

            if (customerToDelete != null)
            {
                dbContext.Customers.DeleteOnSubmit(customerToDelete);
                dbContext.SubmitChanges();
            }
        }
    }
    #endregion

    #region Books CRUD
    public IBook GetBook(int id)
    {
        using (BookShopDBLDataContext dbContext = new BookShopDBLDataContext(this._connectionString))
        {
            var bookEntity = dbContext.Books.Where(c => c.Id == id);
            if (bookEntity == null)
            {
                return null;
            }

            if (bookEntity is not null)
            {
                var bookToReturn_entity = bookEntity.First();

                return new Book(bookToReturn_entity.Id.ToString(), bookToReturn_entity.Title.TrimEnd(), bookToReturn_entity.Author.TrimEnd(),
                    (int)bookToReturn_entity.Pages, bookToReturn_entity.ISBN.TrimEnd(), bookToReturn_entity.Publisher.TrimEnd(),
                    bookToReturn_entity.Language.TrimEnd());
            } else
            {
                throw new Exception("Book not found");
            }
 
        }
    }

    public IBook GetBook_QuerySyntax(int id)
    {
        using (BookShopDBLDataContext dbContext = new BookShopDBLDataContext(this._connectionString))
        {
            IQueryable<Books> query = 
                from b in dbContext.Books where b.Id == id
                select b; 
            
            if (query == null)
            {
                throw new Exception("Book not found");
            }
            IBook bookToReturn = new Book(query.First().Id.ToString(), query.First().Title.TrimEnd(), query.First().Author.TrimEnd(), (int)query.First().Pages,
                query.First().ISBN.TrimEnd(), query.First().Publisher.TrimEnd(), query.First().Language.TrimEnd());

            return bookToReturn;
        }
    }

    public List<IBook> GetAllBooks()
    {
        using (var dbContext = new BookShopDBLDataContext(_connectionString))
        {
            var bookEntities = dbContext.Books.ToList();
            List<IBook> books = bookEntities
                .Select(b => new Book(b.Id.ToString(), b.Title.TrimEnd(), b.Author.TrimEnd(), (int)b.Pages, b.ISBN.TrimEnd(), b.Publisher.TrimEnd(), b.Language.TrimEnd()) as IBook)
                .ToList();
            return books;
        }
    }

    public List<IBook> GetAllBooks_QuerySyntax()
    {
        using (var dbContext = new BookShopDBLDataContext(_connectionString))
        {
            return (from b in dbContext.Books
                            select new Book(b.Id.ToString(), b.Title.TrimEnd(), b.Author.TrimEnd(), (int)b.Pages, b.ISBN.TrimEnd(), b.Publisher.TrimEnd(), b.Language.TrimEnd()) as IBook)
                            .ToList();
        }   
    }

    public void InsertBook(IBook newBook)
    {
        using (var dbContext = new BookShopDBLDataContext(_connectionString))
        {
            Books bookEntity = new Books()
            {
                Id = int.Parse(newBook.Id),
                Title = newBook.Title,
                Author = newBook.Author,
                Pages = newBook.Pages,
                ISBN = newBook.ISBN,
                Publisher = newBook.Publisher,
                Language = newBook.Language,
            };

            dbContext.Books.InsertOnSubmit(bookEntity);
            dbContext.SubmitChanges();
        }
    }

    public void UpdateBook(IBook updatedBook)
    {
        using (var dbContext = new BookShopDBLDataContext(_connectionString))
        {
            var existingBook = dbContext.Books.FirstOrDefault(c => c.Id.ToString() == updatedBook.Id);

            if (existingBook != null)
            {
                // Update the properties of the existing customer with the new values
                existingBook.Title = updatedBook.Title;
                existingBook.Author = updatedBook.Author;
                existingBook.Pages = updatedBook.Pages;
                existingBook.ISBN = updatedBook.ISBN;
                existingBook.Publisher = updatedBook.Publisher;
                existingBook.Language = updatedBook.Language;

                dbContext.SubmitChanges();
            }
        }
    }

    public void DeleteBook(int bookId)
    {
        using (var dbContext = new BookShopDBLDataContext(_connectionString))
        {
            var bookToDelete = dbContext.Books.FirstOrDefault(b => b.Id == bookId);

            if (bookToDelete != null)
            {
                dbContext.Books.DeleteOnSubmit(bookToDelete);
                dbContext.SubmitChanges();
            }
        }
    }
    #endregion

    #region Statuses CRUD 
    public IStatus GetStatus(int id)
    {
        using (var dbContext = new BookShopDBLDataContext(_connectionString))
        {
            var statusEntity = dbContext.Statuses.FirstOrDefault(s => s.Id == id);
            if (statusEntity == null)
            {
                return null;
            }

            IBook assignedBook = GetBook(statusEntity.BookId ?? 0);

            return new Status(statusEntity.Id.ToString(), assignedBook, statusEntity.Availability ?? true);
        }
    }

    public List<IStatus> GetAllStatuses()
    {
        using (var dbContext = new BookShopDBLDataContext(_connectionString))
        {
            var statusEntities = dbContext.Statuses.ToList();
            List<IStatus> statuses = new List<IStatus>();
            foreach (var statusEntity in statusEntities)
            {
                IBook book = GetBook(statusEntity.BookId ?? -1);
                statuses.Add(new Status(statusEntity.Id.ToString(), book, statusEntity.Availability ?? true));
            }

            
            return statuses;
        }
    }

    public void InsertStatus(IStatus newStatus)
    {
        using (var dbContext = new BookShopDBLDataContext(_connectionString))
        {
            var statusEntity = new Statuses()
            {
                Id = int.Parse(newStatus.Id),
                BookId = int.Parse(newStatus.Book.Id),
                Availability = newStatus.Availability
            };

            dbContext.Statuses.InsertOnSubmit(statusEntity);
            dbContext.SubmitChanges();
        }
    }

    public void UpdateStatus(IStatus updatedStatus)
    {
        using (var dbContext = new BookShopDBLDataContext(_connectionString))
        {
            var existingStatus = dbContext.Statuses.FirstOrDefault(s => s.Id.ToString() == updatedStatus.Id);

            if (existingStatus != null)
            {
                // Update the properties of the existing status with the new values
                existingStatus.BookId = int.Parse(updatedStatus.Book.Id);
                existingStatus.Availability = updatedStatus.Availability;

                dbContext.SubmitChanges();
            }
        }
    }

    public void DeleteStatus(int statusId)
    {
        using (var dbContext = new BookShopDBLDataContext(_connectionString))
        {
            var statusToDelete = dbContext.Statuses.FirstOrDefault(s => s.Id == statusId);

            if (statusToDelete != null)
            {
                dbContext.Statuses.DeleteOnSubmit(statusToDelete);
                dbContext.SubmitChanges();
            }
        }
    }

    #endregion

    #region Events CRUD
    public IEvent GetEvent(int id)
    {
        using (var dbContext = new BookShopDBLDataContext(_connectionString))
        {

            var eventEntity = dbContext.Events.FirstOrDefault(e => e.Id == id);
            if (eventEntity == null)
            {
                return null;
            }

            if(eventEntity.Type.TrimEnd() == "Buy")
            {
                IStatus status = GetStatus(eventEntity.StatusId);
                ICustomer customer = GetCustomer(eventEntity.CustomerId);
                return new Buy(eventEntity.Id.ToString(), customer, status, eventEntity.Time);
            } 
               else if (eventEntity.Type.TrimEnd() == "Return")
            {
                IStatus status = GetStatus(eventEntity.StatusId);
                ICustomer customer = GetCustomer(eventEntity.CustomerId);
                return new Return(eventEntity.Id.ToString(), customer, status, eventEntity.Time);
            }
                else if (eventEntity.Type.TrimEnd() == "Review")
            {
                IStatus status = GetStatus(eventEntity.StatusId);
                ICustomer customer = GetCustomer(eventEntity.CustomerId);
                return new Review(eventEntity.Id.ToString(), customer, status, eventEntity.Description, eventEntity.Time);
            }
                else if (eventEntity.Type.TrimEnd() == "Complaint")
            {
                IStatus status = GetStatus(eventEntity.StatusId);
                ICustomer customer = GetCustomer(eventEntity.CustomerId);
                return new Complaint(eventEntity.Id.ToString(), customer, status, eventEntity.Reason, eventEntity.Time);
            } 
                else
            {
                return null;
            }

        }
    }

    public List<IEvent> GetAllEvents()
    {
        using (var dbContext = new BookShopDBLDataContext(_connectionString))
        {
            var eventEntities = dbContext.Events.ToList();
            var events = new List<IEvent>();

            foreach (var eventEntity in eventEntities)
            {
                if (eventEntity.Type == "Buy")
                {
                    var customer = GetCustomer(eventEntity.CustomerId);
                    var status = GetStatus(eventEntity.StatusId);
                    events.Add(new Buy(eventEntity.Id.ToString(), customer, status, eventEntity.Time));
                }
                else if (eventEntity.Type == "Return")
                {
                    var customer = GetCustomer(eventEntity.CustomerId);
                    var status = GetStatus(eventEntity.StatusId);
                    events.Add(new Return(eventEntity.Id.ToString(), customer, status, eventEntity.Time));
                }
                else if (eventEntity.Type == "Review")
                {
                    var customer = GetCustomer(eventEntity.CustomerId);
                    var status = GetStatus(eventEntity.StatusId);
                    events.Add(new Review(eventEntity.Id.ToString(), customer, status, eventEntity.Description, eventEntity.Time));
                }
                else if (eventEntity.Type == "Complaint")
                {
                    var customer = GetCustomer(eventEntity.CustomerId);
                    var status = GetStatus(eventEntity.StatusId);
                    events.Add(new Complaint(eventEntity.Id.ToString(), customer, status, eventEntity.Reason, eventEntity.Time));
                }
            }

            return events;
        }
    }

    public void InsertEvent(IEvent newEvent)
    {
        using (var dbContext = new BookShopDBLDataContext(_connectionString))
        {
            if (newEvent is Buy)
            {
                var buyEvent = (Buy)newEvent;

                var eventEntity = new Events()
                {
                    Id = int.Parse(buyEvent.Id),
                    StatusId = int.Parse(buyEvent.Status.Id),
                    CustomerId = int.Parse(buyEvent.Customer.Id),
                    Time = buyEvent.Time,
                    Type = "Buy"
                };

                dbContext.Events.InsertOnSubmit(eventEntity);
                dbContext.SubmitChanges();
            }
            else if (newEvent is Return)
            {
                var returnEvent = (Return)newEvent;

                var eventEntity = new Events()
                {
                    Id = int.Parse(returnEvent.Id),
                    StatusId = int.Parse(returnEvent.Status.Id),
                    CustomerId = int.Parse(returnEvent.Customer.Id),
                    Time = returnEvent.Time,
                    Type = "Return"
                };

                dbContext.Events.InsertOnSubmit(eventEntity);
                dbContext.SubmitChanges();
            }
            else if (newEvent is Review)
            {
                var reviewEvent = (Review)newEvent;

                var eventEntity = new Events()
                {
                    Id = int.Parse(reviewEvent.Id),
                    StatusId = int.Parse(reviewEvent.Status.Id),
                    CustomerId = int.Parse(reviewEvent.Customer.Id),
                    Time = reviewEvent.Time,
                    Type = "Review",
                    Description = reviewEvent.Description
                };

                dbContext.Events.InsertOnSubmit(eventEntity);
                dbContext.SubmitChanges();
            }
            else if (newEvent is Complaint)
            {
                var complaintEvent = (Complaint)newEvent;

                var eventEntity = new Events()
                {
                    Id = int.Parse(complaintEvent.Id),
                    StatusId = int.Parse(complaintEvent.Status.Id),
                    CustomerId = int.Parse(complaintEvent.Customer.Id),
                    Time = complaintEvent.Time,
                    Type = "Complaint",
                    Reason = complaintEvent.Reason
                };

                dbContext.Events.InsertOnSubmit(eventEntity);
                dbContext.SubmitChanges();
            }
            else
            {
                throw new Exception("Wrong Event type");
            }
        }
    }

    public void UpdateEvent(IEvent updatedEvent)
    {
        using (var dbContext = new BookShopDBLDataContext(_connectionString))
        {
            var existingEvent = dbContext.Events.FirstOrDefault(e => e.Id == int.Parse(updatedEvent.Id));

            if (existingEvent != null)
            {
                existingEvent.StatusId = int.Parse(updatedEvent.Status.Id);
                existingEvent.CustomerId = int.Parse(updatedEvent.Customer.Id);
                existingEvent.Time = updatedEvent.Time;

                if (updatedEvent is Review)
                {
                    var reviewEvent = (Review)updatedEvent;
                    existingEvent.Type = "Review";
                    existingEvent.Description = reviewEvent.Description;
                    existingEvent.Reason = null;
                }
                else if (updatedEvent is Complaint)
                {
                    var complaintEvent = (Complaint)updatedEvent;
                    existingEvent.Type = "Complaint";
                    existingEvent.Description = null;
                    existingEvent.Reason = complaintEvent.Reason;
                }
                else
                {
                    existingEvent.Type = updatedEvent.GetType().Name;
                    existingEvent.Description = null;
                    existingEvent.Reason = null;
                }

                dbContext.SubmitChanges();
            }
        }
    }

    public void DeleteEvent(int eventId)
    {
        using (var dbContext = new BookShopDBLDataContext(_connectionString))
        {
            var eventToDelete = dbContext.Events.FirstOrDefault(e => e.Id == eventId);

            if (eventToDelete != null)
            {
                dbContext.Events.DeleteOnSubmit(eventToDelete);
                dbContext.SubmitChanges();
            }
        }
    }

    #endregion

    #region OTHERS

    public void DropAllCustomers()
    {
        using (var dbContext = new BookShopDBLDataContext(_connectionString))
        {
            dbContext.ExecuteCommand("DELETE FROM Customers");
            dbContext.SubmitChanges();
        }
    }

    public void DropAllBooks()
    {
        using (var dbContext = new BookShopDBLDataContext(_connectionString))
        {
            dbContext.ExecuteCommand("DELETE FROM Books");
            dbContext.SubmitChanges();
        }
    }

    public void DropAllStatuses()
    {
        using (var dbContext = new BookShopDBLDataContext(_connectionString))
        {
            dbContext.ExecuteCommand("DELETE FROM Statuses");
            dbContext.SubmitChanges();
        }
    }

    public void DropAllEvents()
    {
        using (var dbContext = new BookShopDBLDataContext(_connectionString))
        {
            dbContext.ExecuteCommand("DELETE FROM Events");
            dbContext.SubmitChanges();
        }
    }

    public void DropAll()
    {
        using (var dbContext = new BookShopDBLDataContext(_connectionString))
        {
            DropAllEvents();
            DropAllStatuses();
            DropAllBooks();
            DropAllCustomers();
            dbContext.SubmitChanges();
        }
    }

    #endregion

}