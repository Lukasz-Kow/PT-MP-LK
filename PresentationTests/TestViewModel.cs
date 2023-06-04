using Moq;
using Presentations.Model.API;
using Presentations.View;
using Presentations.ViewModel;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Controls;

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
    }
}


