using Services.API;
using Services.Implementation;
using ServiceTest.Instrumentation;
using Moq;
using Data.API;

namespace TestService
{
    [TestClass]
    public class TestService
    {
        [TestMethod]
        public void AddingEntitiesTest()
        {

            // Arrange
            var mockDataRepo = new Mock<IDataRepository>();
            
            IServices testService = IServices.Create(mockDataRepo.Object);

            // Act

            IBook book1 = new Book("9", "Pan Tadeusz", "Adam Mickiewicz", 400, "SR2", "Greg", "Polish");

            ICustomer customer1 = new Customer("10", "Marek", "Maerkk", 21, "Al.Politechniki", "Lodz");

            IStatus status1 = new Status("1", book1, true);

            testService.AddBook(book1.Title, book1.Author, book1.Id, book1.Pages, book1.ISBN, book1.Publisher, book1.Language);

            testService.AddCustomer(customer1.FirstName, customer1.LastName, customer1.Id, customer1.Age, customer1.Address, customer1.City);

            testService.AddStatus(status1.Id, status1.Book.Id, status1.Availability);

            // Assert

            mockDataRepo.Verify(m => m.InsertBook(book1.Id, book1.Title, book1.Author, book1.Pages,
                book1.ISBN, book1.Publisher, book1.Language), Times.Once);

            mockDataRepo.Verify(m => m.InsertCustomer(customer1.Id, customer1.FirstName, customer1.LastName,
                customer1.Age, customer1.Address, customer1.City), Times.Once);

            mockDataRepo.Verify(m => m.InsertStatus(status1.Id, status1.Book.Id, status1.Availability), Times.Once);


        }

        [TestMethod]
        public void DeletingEntitiesTest()
        {
            // Arrange
            var mockDataRepo = new Mock<IDataRepository>();

            IServices testService = IServices.Create(mockDataRepo.Object);

            // Act

            testService.DeleteBook("9");

            testService.DeleteCustomer("10");

            testService.DeleteStatus("1");

            // Assert

            mockDataRepo.Verify(m => m.DeleteBook(9), Times.Once);

            mockDataRepo.Verify(m => m.DeleteCustomer(10), Times.Once);

            mockDataRepo.Verify(m => m.DeleteStatus(1), Times.Once);

        }

        [TestMethod]
        public void GettersTest()
        {
            // Arrange
            var mockDataRepo = new Mock<IDataRepository>();

            IServices testService = IServices.Create(mockDataRepo.Object);

            // Act

            testService.GetAllBooks();

            testService.GetAllCustomers();

            testService.GetAllStatuses();

            testService.GetBookById("9");

            testService.GetCustomerById("10");

            testService.GetStatusById("1");

            // Assert

            mockDataRepo.Verify(m => m.GetAllBooks(), Times.Once);

            mockDataRepo.Verify(m => m.GetAllCustomers(), Times.Once);

            mockDataRepo.Verify(m => m.GetAllStatuses(), Times.Once);

            mockDataRepo.Verify(m => m.GetBook(9), Times.Once);

            mockDataRepo.Verify(m => m.GetCustomer(10), Times.Once);

            mockDataRepo.Verify(m => m.GetStatus(1), Times.Once);

        }
        
    }
}