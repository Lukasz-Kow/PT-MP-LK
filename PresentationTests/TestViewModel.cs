using Moq;
using Presentations.Model.API;
using Presentations.ViewModel;
using PresentationTests.Generators;

namespace PresentationTests
{
    [TestClass]
    public class TestViewModel
    {

        [TestMethod]
        public void BookModelOperationsTest()
        {

            // Arrange
            var mockBookModelOperations = new Mock<IBookModelOperations>();

            IBookMasterViewModel bookMasterViewModel = IBookMasterViewModel.Create(mockBookModelOperations.Object, false);
           

            // Act

            bookMasterViewModel.Author = "Author";
            bookMasterViewModel.Title = "Title";
            bookMasterViewModel.Id = "Id";
            bookMasterViewModel.Pages = 1;
            bookMasterViewModel.ISBN = "ISBN";
            bookMasterViewModel.Publisher = "Publisher";
            bookMasterViewModel.Language = "Language";

            bookMasterViewModel.AddBook.Execute(bookMasterViewModel.Author);


            // Assert

            Assert.AreEqual("Author", bookMasterViewModel.Author);
            Assert.AreEqual("Title", bookMasterViewModel.Title);
            Assert.AreEqual("Id", bookMasterViewModel.Id);

            mockBookModelOperations.Verify(x => x.GetAllBooks(), Times.AtLeastOnce);

            mockBookModelOperations.Verify(x => x.AddBook(bookMasterViewModel.Title, bookMasterViewModel.Author,
                bookMasterViewModel.Id, bookMasterViewModel.Pages, bookMasterViewModel.ISBN, bookMasterViewModel.Publisher,
                bookMasterViewModel.Language), Times.Once);
        }


        [TestMethod]
        public void CustomerModelOperationsTest()
        {

            // Arrange
            var mockCustomerModelOperations = new Mock<ICustomerModelOperations>();

            ICustomerMasterViewModel customerMasterViewModel = ICustomerMasterViewModel.Create(mockCustomerModelOperations.Object, false);

            // Act

            customerMasterViewModel.FirstName = "FirstName";
            customerMasterViewModel.LastName = "LastName";
            customerMasterViewModel.Id = "Id";
            customerMasterViewModel.Age = 1;
            customerMasterViewModel.Address = "Address";
            customerMasterViewModel.City = "City";

            customerMasterViewModel.CreateCustomer.Execute(customerMasterViewModel.FirstName);

            
            // Assert

            Assert.AreEqual("FirstName", customerMasterViewModel.FirstName);
            Assert.AreEqual("LastName", customerMasterViewModel.LastName);
            Assert.AreEqual("Id", customerMasterViewModel.Id);

            mockCustomerModelOperations.Verify(x => x.GetAllCustomers(), Times.AtLeastOnce);

            mockCustomerModelOperations.Verify(x => x.AddCustomer(customerMasterViewModel.FirstName, customerMasterViewModel.LastName,
                               customerMasterViewModel.Id, customerMasterViewModel.Age, customerMasterViewModel.Address, customerMasterViewModel.City), Times.Once);
        }

        [TestMethod]
        public void EventMasterViewModelOpertationsTest()
        {
            // Arrange
            var mockEventModelOperations = new Mock<IEventModelOperations>();

            IEventMasterViewModel eventMasterViewModel = IEventMasterViewModel.Create(mockEventModelOperations.Object, false);

            // Act
            eventMasterViewModel.Id = "EventId";
            eventMasterViewModel.StatusId = "StatusId";
            eventMasterViewModel.CustomerId = "CustomerId";
            eventMasterViewModel.Type = "EventType";
            eventMasterViewModel.ReasonOrDescription = "EventDescription";

            eventMasterViewModel.AddEvent.Execute("test");

            // Assert
            Assert.AreEqual("EventId", eventMasterViewModel.Id);
            Assert.AreEqual("StatusId", eventMasterViewModel.StatusId);
            Assert.AreEqual("CustomerId", eventMasterViewModel.CustomerId);

            mockEventModelOperations.Verify(x => x.GetAllEvents(), Times.AtLeastOnce);

            mockEventModelOperations.Verify(x => x.AddEvent(
                eventMasterViewModel.Id,
                eventMasterViewModel.StatusId,
                eventMasterViewModel.CustomerId,
                It.IsAny<DateTime>(),
                eventMasterViewModel.Type,
                eventMasterViewModel.ReasonOrDescription
            ), Times.Once);

            //mockEventModelOperations.Verify(x => x.AddEvent(eventMasterViewModel.Id, eventMasterViewModel.StatusId, eventMasterViewModel.CustomerId, It.IsAny<DateTime>(), eventMasterViewModel.Type, eventMasterViewModel.ReasonOrDescription), Times.Once);
        }

        [TestMethod]
        public void StatusMasterViewModelTest()
        {
            // Arrange
            var mockModelOperations = new Mock<IStatusModelOperations>();

            IStatusMasterViewModel statusMasterViewModel = IStatusMasterViewModel.Create(mockModelOperations.Object, false);

            // Act
            statusMasterViewModel.Id = "Id";
            statusMasterViewModel.BookId = "BookId";
            statusMasterViewModel.Available = true;

            statusMasterViewModel.CreateStatus.Execute("test");

            // Assert
            Assert.AreEqual("Id", statusMasterViewModel.Id);
            Assert.AreEqual("BookId", statusMasterViewModel.BookId);
            Assert.AreEqual(true, statusMasterViewModel.Available);

            mockModelOperations.Verify(x => x.GetAllStatuses(), Times.AtLeastOnce);
            mockModelOperations.Verify(x => x.AddStatus(statusMasterViewModel.Id, statusMasterViewModel.BookId, statusMasterViewModel.Available), Times.Once);
        }

        [TestMethod]
        public void BookModelOperationsRandomData()
        {
            // Arrange
            var mockBookModelOperations = new Mock<IBookModelOperations>();

            IBookMasterViewModel bookMasterViewModel = IBookMasterViewModel.Create(mockBookModelOperations.Object, false);

            RandomDataGenerator bookGenerator = new RandomDataGenerator();

            // Act

            string author = bookGenerator.GenerateRandomString(10);
            string title = bookGenerator.GenerateRandomString(20);
            string id = bookGenerator.GenerateRandomString(2);
            int pages = bookGenerator.GenerateRandomInt(1, 500);
            string isbn = bookGenerator.GenerateRandomString(10);
            string publisher = bookGenerator.GenerateRandomString(10);
            string language = bookGenerator.GenerateRandomString(10);

            bookMasterViewModel.Author = author;
            bookMasterViewModel.Title = title;
            bookMasterViewModel.Id = id;
            bookMasterViewModel.Pages = pages;
            bookMasterViewModel.ISBN = isbn;
            bookMasterViewModel.Publisher = publisher;
            bookMasterViewModel.Language = language;

            bookMasterViewModel.AddBook.Execute(bookMasterViewModel.Author);

            // Assert

            Assert.AreEqual(author, bookMasterViewModel.Author);
            Assert.AreEqual(title, bookMasterViewModel.Title);
            Assert.AreEqual(id, bookMasterViewModel.Id);

            mockBookModelOperations.Verify(x => x.GetAllBooks(), Times.AtLeastOnce);

            mockBookModelOperations.Verify(x => x.AddBook(bookMasterViewModel.Title, bookMasterViewModel.Author,
                bookMasterViewModel.Id, bookMasterViewModel.Pages, bookMasterViewModel.ISBN, bookMasterViewModel.Publisher,
                bookMasterViewModel.Language), Times.Once);
        }

        [TestMethod]
        public void CustomerModelOperationsRandomData()
        {
            // Arrange
            var mockCustomerModelOperations = new Mock<ICustomerModelOperations>();

            ICustomerMasterViewModel customerMasterViewModel = ICustomerMasterViewModel.Create(mockCustomerModelOperations.Object, false);

            RandomDataGenerator customerGenerator = new RandomDataGenerator();

            // Act

            string firstName = customerGenerator.GenerateRandomString(10);
            string lastName = customerGenerator.GenerateRandomString(10);
            string id = customerGenerator.GenerateRandomString(2);
            int age = customerGenerator.GenerateRandomInt(1, 100);
            string address = customerGenerator.GenerateRandomString(10);
            string city = customerGenerator.GenerateRandomString(10);

            customerMasterViewModel.FirstName = firstName;
            customerMasterViewModel.LastName = lastName;
            customerMasterViewModel.Id = id;
            customerMasterViewModel.Age = age;
            customerMasterViewModel.Address = address;
            customerMasterViewModel.City = city;

            customerMasterViewModel.CreateCustomer.Execute(customerMasterViewModel.FirstName);

            // Assert

            Assert.AreEqual(firstName, customerMasterViewModel.FirstName);
            Assert.AreEqual(lastName, customerMasterViewModel.LastName);
            Assert.AreEqual(id, customerMasterViewModel.Id);

            mockCustomerModelOperations.Verify(x => x.GetAllCustomers(), Times.AtLeastOnce);

            mockCustomerModelOperations.Verify(x => x.AddCustomer(customerMasterViewModel.FirstName, customerMasterViewModel.LastName,
                               customerMasterViewModel.Id, customerMasterViewModel.Age, customerMasterViewModel.Address, customerMasterViewModel.City), Times.Once);
        }

        [TestMethod]
        public void EventModelOperationsRandomData()
        {
            // Arrange
            var mockEventModelOperations = new Mock<IEventModelOperations>();

            IEventMasterViewModel eventMasterViewModel = IEventMasterViewModel.Create(mockEventModelOperations.Object, false);

            // Act

            RandomDataGenerator eventGenerator = new RandomDataGenerator();

            string id = eventGenerator.GenerateRandomString(2);
            string statusId = eventGenerator.GenerateRandomString(2);
            string customerId = eventGenerator.GenerateRandomString(2);
            string type = eventGenerator.GenerateRandomString(10);
            string reasonOrDescription = eventGenerator.GenerateRandomString(10);
            
            eventMasterViewModel.Id = id;
            eventMasterViewModel.StatusId = statusId;
            eventMasterViewModel.CustomerId = customerId;
            eventMasterViewModel.Type = type;
            eventMasterViewModel.ReasonOrDescription = reasonOrDescription;

            eventMasterViewModel.AddEvent.Execute(eventMasterViewModel.Id);

            // Assert

            Assert.AreEqual(id, eventMasterViewModel.Id);
            Assert.AreEqual(statusId, eventMasterViewModel.StatusId);
            Assert.AreEqual(customerId, eventMasterViewModel.CustomerId);
            Assert.AreEqual(type, eventMasterViewModel.Type);
            Assert.AreEqual(reasonOrDescription, eventMasterViewModel.ReasonOrDescription);

            mockEventModelOperations.Verify(x => x.GetAllEvents(), Times.AtLeastOnce);

            mockEventModelOperations.Verify(x => x.AddEvent(eventMasterViewModel.Id, eventMasterViewModel.StatusId, eventMasterViewModel.CustomerId,
                It.IsAny<DateTime>(), eventMasterViewModel.Type, eventMasterViewModel.ReasonOrDescription), Times.Once);

        }

        [TestMethod]
        public void StatusModelOperationsRandomData()
        {
            // Arrange
            var mockModelOperations = new Mock<IStatusModelOperations>();

            IStatusMasterViewModel statusMasterViewModel = IStatusMasterViewModel.Create(mockModelOperations.Object, false);

            RandomDataGenerator randomDataGenerator = new RandomDataGenerator();
            // Act

            string id = randomDataGenerator.GenerateRandomString(2);
            string bookId = randomDataGenerator.GenerateRandomString(2);
            bool available = randomDataGenerator.GenerateRandomBool();

            statusMasterViewModel.Id = id;
            statusMasterViewModel.BookId = bookId;
            statusMasterViewModel.Available = available;

            statusMasterViewModel.CreateStatus.Execute(statusMasterViewModel.Id);

            // Assert

            Assert.AreEqual(id, statusMasterViewModel.Id);
            Assert.AreEqual(bookId, statusMasterViewModel.BookId);
            Assert.AreEqual(available, statusMasterViewModel.Available);

            mockModelOperations.Verify(x => x.GetAllStatuses(), Times.AtLeastOnce);

            mockModelOperations.Verify(x => x.AddStatus(statusMasterViewModel.Id, statusMasterViewModel.BookId,
                statusMasterViewModel.Available), Times.Once);

        }
    }
}


