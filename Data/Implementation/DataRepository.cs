using Castle.Core.Resource;
using Data.API;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations.Schema;
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
            var customerEntity = dbContext.Customers.FirstOrDefault(c => c.Id == id);
            if (customerEntity == null)
            {
                return null;
            }
            return new Customer(customerEntity.Id.ToString(), customerEntity.FirstName.TrimEnd(), customerEntity.LastName.TrimEnd(),
                customerEntity.Age ?? 0, customerEntity.Address.TrimEnd(), customerEntity.City.TrimEnd());
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
            var bookEntity = dbContext.Books.FirstOrDefault(c => c.Id == id);
            if (bookEntity == null)
            {
                return null;
            }

            return new Book(bookEntity.Id.ToString(), bookEntity.Title.TrimEnd(), bookEntity.Author.TrimEnd(), (int)bookEntity.Pages,
                bookEntity.ISBN.TrimEnd(), bookEntity.Publisher.TrimEnd(), bookEntity.Language.TrimEnd());
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

            if(eventEntity.Type == "Buy")
            {
                IStatus status = GetStatus(eventEntity.StatusId);
                ICustomer customer = GetCustomer(eventEntity.CustomerId);
                return new Buy(eventEntity.Id.ToString(), customer, status, eventEntity.Time);
            } 
               else if (eventEntity.Type == "Return")
            {
                IStatus status = GetStatus(eventEntity.StatusId);
                ICustomer customer = GetCustomer(eventEntity.CustomerId);
                return new Return(eventEntity.Id.ToString(), customer, status, eventEntity.Time);
            }
                else if (eventEntity.Type == "Review")
            {
                IStatus status = GetStatus(eventEntity.StatusId);
                ICustomer customer = GetCustomer(eventEntity.CustomerId);
                return new Review(eventEntity.Id.ToString(), customer, status, eventEntity.Description, eventEntity.Time);
            }
                else if (eventEntity.Type == "Complaint")
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

    public void InsertEvent(IEvent newEvent)
    {
        using (var dbContext = new BookShopDBLDataContext(_connectionString))
        {
            if (newEvent is Buy)
            {
                var buyEvent = (Buy)newEvent;

                var eventEntity = new Events()
                {
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

}