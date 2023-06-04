using Moq;
using Presentations.Model.API;
using Presentations.View;
using Presentations.ViewModel;

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

            IBookMasterViewModel bookMasterViewModel = IBookMasterViewModel.Create(mockBookModelOperations.Object);
           

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

            ICustomerMasterViewModel customerMasterViewModel = ICustomerMasterViewModel.Create(mockCustomerModelOperations.Object);

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


    }
}