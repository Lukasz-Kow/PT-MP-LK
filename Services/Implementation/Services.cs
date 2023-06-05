using Data.API;
using Microsoft.Identity.Client;
using Services.API;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ServicesTests")]

namespace Services.Implementation
{
    internal class dataServices : IServices
    {
        private IDataRepository repository;

        internal dataServices(string connectionString)
        {
            this.repository = IDataRepository.CDataRepository(connectionString);
        }

        // TODO Add another constructor which only takes data

        internal dataServices(IDataRepository repository)
        {
            this.repository = repository;
        }

        private IBookDTO MAP(IBook book)
        {
            return new BookDTO(book.Id, book.Title, book.Author, book.Pages, book.ISBN, book.Publisher, book.Language);
        }   
        
        private ICustomerDTO MAP(ICustomer customer)
        {
            return new CustomerDTO(customer.Id, customer.FirstName, customer.LastName, customer.Age, customer.Address, customer.City);
        }

        private IStatusDTO MAP(IStatus status)
        {
            return new StatusDTO(status.Id, status.Book.Id, status.Availability);
        }

        private IEventDTO MAP(IEvent eventO)
        {
            if (eventO is IBuy)
            {
                return new EventDTO(eventO.Id, eventO.Status.Id, eventO.Customer.Id, "Buy", eventO.Time);
            }
            else if (eventO is IReturn)
            {
                return new EventDTO(eventO.Id, eventO.Status.Id, eventO.Customer.Id, "Return", eventO.Time);
            }
            else if (eventO is IComplaint complaintEvent)
            {
                return new EventDTO(eventO.Id, eventO.Status.Id, eventO.Customer.Id, "Complaint", eventO.Time, complaintEvent.Reason);
            } 
            else if (eventO is IReview reviewEvent)
            {
                return new EventDTO(eventO.Id, eventO.Status.Id, eventO.Customer.Id, "Review", eventO.Time, reviewEvent.Description);
            } 
            else
            {
                throw new Exception("Impossinble to map event"); 
            }
            
        }

        public void AddBook(string Title, string Author, string Id, int Pages, string ISBN, string Publisher, string Language)
        {
            repository.InsertBook(Id, Title, Author, Pages, ISBN, Publisher, Language);
        }

        public void AddBuy(string Id, string statusId, string customerId, DateTime Time)
        {
            repository.InsertEvent(Id, customerId, statusId, Time, "Buy");
        }

        public void AddCustomer(string FirstName, string LastName, string Id, int Age, string Address, string City)
        {
            repository.InsertCustomer(Id, FirstName, LastName, Age, Address, City);
        }

        public void DeleteBook(string Id)
        {
            repository.DeleteBook(int.Parse(Id));
        }

        public void DeleteEvent(string Id)
        {
            repository.DeleteEvent(int.Parse(Id));
        }

        public void DeleteStatus(string Id)
        {
            repository.DeleteStatus(int.Parse(Id));
        }

        public void DeleteCustomer(string Id)
        {
              repository.DeleteCustomer(int.Parse(Id));
        }



        public List<IBookDTO> GetAllBooks()
        {
            List<IBook> books = repository.GetAllBooks();
            List<IBookDTO> bookDTOs = new List<IBookDTO>();
            try
            {
                foreach (IBook book in books)
                {
                    bookDTOs.Add(MAP(book));
                }

                return bookDTOs;
            } 
            catch (Exception e)
            {
                return null;
            }
        }

        public List<ICustomerDTO> GetAllCustomers()
        {
            List<ICustomer> customers = repository.GetAllCustomers();
            List<ICustomerDTO> customerDTOs = new List<ICustomerDTO>();

            try
            {
                foreach (ICustomer customer in customers)
                {
                    customerDTOs.Add(MAP(customer));
                }
                return customerDTOs;
            } 
            catch (Exception e)
            {
                return null;
            }
        }

        public void AddStatus(string StatusId, string bookId, bool availability)
        {
            repository.InsertStatus(StatusId, bookId, availability);
        }

        public void DropTables()
        {
            repository.DropAll();
        }


        public List<IStatusDTO> GetAllStatuses()
        {
            List<IStatus> statuses = repository.GetAllStatuses();
            List<IStatusDTO> statusDTOs = new List<IStatusDTO>();

            try
            {
                foreach (IStatus status in statuses)
                {
                    statusDTOs.Add(MAP(status));
                }
                return statusDTOs;
            } 
            catch (Exception e)
            {
                return null;
            }
        }

        public List<IEventDTO> GetAllEvents()
        {
            List<IEvent> events = repository.GetAllEvents();
            List<IEventDTO> eventDTOs = new List<IEventDTO>();

            try
            {
                foreach (IEvent eventO in events)
                {
                    eventDTOs.Add(MAP(eventO));
                }
                return eventDTOs;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public IBookDTO GetBookById(string Id)
        {
            try
            {
                return MAP(repository.GetBook(int.Parse(Id)));
            }
            catch (Exception e)
            {
                return null;
            }

            
        }

        public ICustomerDTO GetCustomerById(string Id)
        {
            try
            {
                return MAP(repository.GetCustomer(int.Parse(Id)));
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public IStatusDTO GetStatusById(string Id)
        {
            try
            {
                return MAP(repository.GetStatus(int.Parse(Id)));
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IEventDTO GetEventById(string Id)
        {
            try
            {
                return MAP(repository.GetEvent(int.Parse(Id)));
            } 
            catch (Exception e)
            {
                return null;
            }
        }

        public void AddComplaint(string Id, string statusId, string customerId, DateTime Time, string Reason)
        {
            repository.InsertEvent(Id, customerId, statusId, Time, "Complaint", Reason);
        }

        public void AddReview(string Id, string statusId, string customerId, DateTime Time, string description)
        {
            repository.InsertEvent(
                Id,
                customerId,
                statusId,
                Time,
                "Review",
                description
            );
        }

        public void AddReturn(string Id, string statusId, string customerId, DateTime Time)
        {
            repository.InsertEvent(
                Id,
                statusId,
                customerId,
                Time,
                "Return"
            );
        }

        public void UpdateBook(string Title, string Author, string Id, int Pages, string ISBN, string Publisher, string Language)
        {
            repository.UpdateBook(Id, Title, Author, Pages, ISBN, Publisher, Language);
        }

        public void UpdateCustomer(string FirstName, string LastName, string Id, int Age, string Address, string City)
        {
            repository.UpdateCustomer(Id, FirstName, LastName, Age, Address, City);
        }

        public void UpdateStatus(string StatusId, string bookId, bool availability)
        {
            repository.UpdateStatus(StatusId, bookId, availability);
        }

        public void UpdateBuy(string Id, string statusId, string customerId, DateTime Time)
        {
            repository.UpdateEvent(Id, customerId, statusId, Time, "Buy");
        }

        public void UpdateComplaint(string Id, string statusId, string customerId, DateTime Time, string Reason)
        {
            repository.UpdateEvent(Id, customerId, statusId, Time, "Complaint", Reason);
        }

        public void UpdateReview(string Id, string statusId, string customerId, DateTime Time, string description)
        {
            repository.UpdateEvent(Id, customerId, statusId, Time, "Review", description);
        }

        public void UpdateReturn(string Id, string statusId, string customerId, DateTime Time)
        {
            repository.UpdateEvent(Id, customerId, statusId, Time, "Return");
        }

      
    }

}