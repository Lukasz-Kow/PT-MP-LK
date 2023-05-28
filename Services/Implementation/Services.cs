﻿using Services.API;
using Data.API;
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

        public void AddBook(string Title, string Author, string Id, int Pages, string ISBN, string Publisher, string Language)
        {
            repository.InsertBook(new Book(Id, Title, Author, Pages, ISBN, Publisher, Language));
        }

        public void AddBuy(string Id, IStatus status, ICustomer customer, DateTime Time)
        {
            repository.InsertEvent(new Buy(Id, status, customer, Time));
        }

        public void AddComplaint(string Id, IStatus status, ICustomer customer, DateTime Time, string Reason)
        {
            repository.InsertEvent(new Complaint(Id, status, customer, Reason, Time));
        }

        public void AddReview(string Id, IStatus status, ICustomer customer, DateTime Time, string description)
        {
            repository.InsertEvent(new Review(Id, status, customer,description, Time));
        }

        public void AddCustomer(string FirstName, string LastName, string Id, int Age, string Address, string City)
        {
            repository.InsertCustomer(new Customer(Id, FirstName, LastName, Age, Address, City));
        }

        public void AddReturn(string Id, IStatus status, ICustomer customer, DateTime Time)
        {
            repository.InsertEvent(new Return(Id, status, customer, Time));
        }

        public void DeleteBook(string Id)
        {
            repository.DeleteBook(int.Parse(Id));
        }

        public void DeleteBuy(string Id)
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



        public List<IBook> GetAllBooks()
        {
            return repository.GetAllBooks();
        }

        public List<ICustomer> GetAllCustomers()
        {
            return repository.GetAllCustomers();
        }

        public void AddStatus(string StatusId, IBook book, bool availability)
        {
            repository.InsertStatus(new Status(StatusId, book, availability));
        }

        public void DropTables()
        {
            repository.DropAll();
        }


        public List<IStatus> GetAllStatuses()
        {
            return repository.GetAllStatuses();
        }

        public List<IEvent> GetAllEvents()
        {
            return repository.GetAllEvents();
        }

        public IBook GetBookById(string Id)
        {
            return repository.GetBook(int.Parse(Id));
        }

        public ICustomer GetCustomerById(string Id)
        {
            return repository.GetCustomer(int.Parse(Id));
        }

        public IStatus GetStatusById(string Id)
        {
            return repository.GetStatus(int.Parse(Id));
        }

        public IEvent GetEventById(string Id)
        {
            return repository.GetEvent(int.Parse(Id));
        }
    }

}