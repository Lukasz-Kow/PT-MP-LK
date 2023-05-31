
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

    public void InsertCustomer(string id, string firstName, string lastName, int age, string address, string city)
    {
        using (BookShopDBLDataContext dbContext = new BookShopDBLDataContext(this._connectionString))
        {
            Customers customerEntity = new Customers()
            {
                Id = Convert.ToInt32(id),
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Address = address,
                City = city
            };

            dbContext.Customers.InsertOnSubmit(customerEntity);
            dbContext.SubmitChanges();

        }
    }

    public void UpdateCustomer(string id, string firstName, string lastName, int age, string address, string city)
    {
        using (var dbContext = new BookShopDBLDataContext(_connectionString))
        {
            var existingCustomer = dbContext.Customers.FirstOrDefault(c => c.Id.ToString() == id);

            if (existingCustomer != null)
            {
                // Update the properties of the existing customer with the new values
                existingCustomer.FirstName = firstName;
                existingCustomer.LastName = lastName;
                existingCustomer.Age = age;
                existingCustomer.Address = address;
                existingCustomer.City = city;

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

    public void InsertBook(string id, string title, string author, int pages, string ISBN, string publisher, string language)
    {
        using (var dbContext = new BookShopDBLDataContext(_connectionString))
        {
            Books bookEntity = new Books()
            {
                Id = int.Parse(id),
                Title = title,
                Author = author,
                Pages = pages,
                ISBN = ISBN,
                Publisher = publisher,
                Language = language,
            };

            dbContext.Books.InsertOnSubmit(bookEntity);
            dbContext.SubmitChanges();
        }
    }

    public void UpdateBook(string id, string title, string author, int pages, string ISBN, string publisher, string language)
    {
        using (var dbContext = new BookShopDBLDataContext(_connectionString))
        {
            var existingBook = dbContext.Books.FirstOrDefault(c => c.Id.ToString() == id);

            if (existingBook != null)
            {
                // Update the properties of the existing customer with the new values
                existingBook.Title = title;
                existingBook.Author = author;
                existingBook.Pages = pages;
                existingBook.ISBN = ISBN;
                existingBook.Publisher = publisher;
                existingBook.Language = language;

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
            var statusEntity = dbContext.Statuses.Where(s => s.Id == id);
            if (statusEntity is not null)
            {
                var statusToReturn_Entity = statusEntity.First();

                IBook assignedBook = GetBook(statusToReturn_Entity.BookId ?? 0);

                return new Status(statusToReturn_Entity.Id.ToString(), assignedBook, statusToReturn_Entity.Availability ?? true);
            }
            else
            {
                throw new Exception("Status not found");
            }
        }
    }

    public IStatus GetStatus_QuerySyntax(int id)
    {
        using (var dbContext = new BookShopDBLDataContext(_connectionString))
        {
            IQueryable<Statuses> query =
                from s in dbContext.Statuses
                where s.Id == id
                select s;

            if (query == null)
            {
                throw new Exception("Status not found");
            }
            IStatus statusToReturn = new Status(query.First().Id.ToString(), GetBook(query.First().BookId ?? 0), query.First().Availability ?? true);

            return statusToReturn;
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

    public void InsertStatus(string statusId, IBook book, bool available)
    {
        using (var dbContext = new BookShopDBLDataContext(_connectionString))
        {
            var statusEntity = new Statuses()
            {
                Id = int.Parse(statusId),
                BookId = int.Parse(book.Id),
                Availability = available
            };

            dbContext.Statuses.InsertOnSubmit(statusEntity);
            dbContext.SubmitChanges();
        }
    }

    public void UpdateStatus(string statusId, IBook book, bool available)
    {
        using (var dbContext = new BookShopDBLDataContext(_connectionString))
        {
            var existingStatus = dbContext.Statuses.FirstOrDefault(s => s.Id.ToString() == statusId);

            if (existingStatus != null)
            {
                // Update the properties of the existing status with the new values
                existingStatus.BookId = int.Parse(book.Id);
                existingStatus.Availability = available;

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

            var eventEntity = dbContext.Events.Where(e => e.Id == id);
            if (eventEntity == null)
            {
                return null;
            }

            var eventToReturn_Entity = eventEntity.First();

            if(eventToReturn_Entity.Type.TrimEnd() == "Buy")
            {
                IStatus status = GetStatus(eventToReturn_Entity.StatusId);
                ICustomer customer = GetCustomer(eventToReturn_Entity.CustomerId);
                return new Buy(eventToReturn_Entity.Id.ToString(), customer, status, eventToReturn_Entity.Time);
            } 
               else if (eventToReturn_Entity.Type.TrimEnd() == "Return")
            {
                IStatus status = GetStatus(eventToReturn_Entity.StatusId);
                ICustomer customer = GetCustomer(eventToReturn_Entity.CustomerId);
                return new Return(eventToReturn_Entity.Id.ToString(), customer, status, eventToReturn_Entity.Time);
            }
                else if (eventToReturn_Entity.Type.TrimEnd() == "Review")
            {
                IStatus status = GetStatus(eventToReturn_Entity.StatusId);
                ICustomer customer = GetCustomer(eventToReturn_Entity.CustomerId);
                return new Review(eventToReturn_Entity.Id.ToString(), customer, status, eventToReturn_Entity.Description, eventToReturn_Entity.Time);
            }
                else if (eventToReturn_Entity.Type.TrimEnd() == "Complaint")
            {
                IStatus status = GetStatus(eventToReturn_Entity.StatusId);
                ICustomer customer = GetCustomer(eventToReturn_Entity.CustomerId);
                return new Complaint(eventToReturn_Entity.Id.ToString(), customer, status, eventToReturn_Entity.Reason, eventToReturn_Entity.Time);
            } 
                else
            {
                return null;
            }

        }
    }

    public IEvent GetEvent_QuerySyntax(int id)
    {
        IQueryable<Events> query =
                from e in dbContext.Events
                where e.Id == id
                select e;

        if (query == null)
        {
            throw new Exception("Event not found");
        }

        var eventToReturn_Entity = query.First();

        if (eventToReturn_Entity.Type.TrimEnd() == "Buy")
        {
            IStatus status = GetStatus(eventToReturn_Entity.StatusId);
            ICustomer customer = GetCustomer(eventToReturn_Entity.CustomerId);
            return new Buy(eventToReturn_Entity.Id.ToString(), customer, status, eventToReturn_Entity.Time);
        }
        else if (eventToReturn_Entity.Type.TrimEnd() == "Return")
        {
            IStatus status = GetStatus(eventToReturn_Entity.StatusId);
            ICustomer customer = GetCustomer(eventToReturn_Entity.CustomerId);
            return new Return(eventToReturn_Entity.Id.ToString(), customer, status, eventToReturn_Entity.Time);
        }
        else if (eventToReturn_Entity.Type.TrimEnd() == "Review")
        {
            IStatus status = GetStatus(eventToReturn_Entity.StatusId);
            ICustomer customer = GetCustomer(eventToReturn_Entity.CustomerId);
            return new Review(eventToReturn_Entity.Id.ToString(), customer, status, eventToReturn_Entity.Description, eventToReturn_Entity.Time);
        }
        else if (eventToReturn_Entity.Type.TrimEnd() == "Complaint")
        {
            IStatus status = GetStatus(eventToReturn_Entity.StatusId);
            ICustomer customer = GetCustomer(eventToReturn_Entity.CustomerId);
            return new Complaint(eventToReturn_Entity.Id.ToString(), customer, status, eventToReturn_Entity.Reason, eventToReturn_Entity.Time);
        }
        else
        {
            return null;
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

    public void InsertEvent(string id, ICustomer customer, IStatus status, DateTime date, string type, string reasonOrDescription = "")
    {
        using (var dbContext = new BookShopDBLDataContext(_connectionString))
        {
            
            if (type == "Complaint")
            {
                var eventEntity = new Events()
                {
                    Id = int.Parse(id),
                    StatusId = int.Parse(status.Id),
                    CustomerId = int.Parse(customer.Id),
                    Time = date,
                    Type = type,
                    Reason = reasonOrDescription
                };

                dbContext.Events.InsertOnSubmit(eventEntity);
                dbContext.SubmitChanges();

            } else if (type == "Review")
            {
                var eventEntity = new Events()
                {
                    Id = int.Parse(id),
                    StatusId = int.Parse(status.Id),
                    CustomerId = int.Parse(customer.Id),
                    Time = date,
                    Type = type,
                    Description = reasonOrDescription
                };

                dbContext.Events.InsertOnSubmit(eventEntity);
                dbContext.SubmitChanges();

            } else
            {
                var eventEntity = new Events()
                {
                    Id = int.Parse(id),
                    StatusId = int.Parse(status.Id),
                    CustomerId = int.Parse(customer.Id),
                    Time = date,
                    Type = type
                };

                dbContext.Events.InsertOnSubmit(eventEntity);
                dbContext.SubmitChanges();

            }          
            
        }
    }

    public void UpdateEvent(string id, ICustomer customer, IStatus status, DateTime date, string type, string reasonOrDescription = "")
    {
        using (var dbContext = new BookShopDBLDataContext(_connectionString))
        {
            var existingEvent = dbContext.Events.FirstOrDefault(e => e.Id == int.Parse(id));

            if (existingEvent != null)
            {
                existingEvent.StatusId = int.Parse(status.Id);
                existingEvent.CustomerId = int.Parse(customer.Id);
                existingEvent.Time = date;

                if (type ==  "Review")
                {
                    existingEvent.Type = "Review";
                    existingEvent.Description = reasonOrDescription;
                    existingEvent.Reason = null;
                }
                else if (type == "Complaint")
                {
                    existingEvent.Type = "Complaint";
                    existingEvent.Description = null;
                    existingEvent.Reason = reasonOrDescription;
                }
                else
                {
                    existingEvent.Type = type;
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