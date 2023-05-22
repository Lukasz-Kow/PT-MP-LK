using Services.API;
using Services.Implementation;
using Data.API;
using Data.Implementation;

namespace TestService
{
    [TestClass]
    public class TestService
    {
        [TestMethod]
        public void AddCustomerBookAndStatusAndRetrieveThem()
        {

            IServices testService = IServices.Create();

            testService.DropTables();

            ICustomer customer1 = new Customer("10", "Lukasz", "Kowalczyk", 21, "Al.Politechniki", "Lodz");
            testService.AddCustomer(customer1.FirstName, customer1.LastName, customer1.Id, customer1.Age, customer1.Address, customer1.City);
            IBook book1 = new Book("9", "Pan Tadeusz", "Adam Mickiewicz", 400, "SR2", "Greg", "Polish");
            testService.AddBook(book1.Title, book1.Author, book1.Id, book1.Pages, book1.ISBN, book1.Publisher, book1.Language);
            IStatus status1 = new Status("1", book1, true);
            testService.AddStatus(status1.Id, status1.Book, status1.Availability);

            List<IBook> booksFromDB = testService.GetAllBooks();
            List<ICustomer> customersFromDB = testService.GetAllCustomers();

            Assert.IsNotNull(booksFromDB);
            Assert.IsNotNull(customersFromDB);

            Assert.AreEqual(1, booksFromDB.Count);
            Assert.AreEqual(1, customersFromDB.Count);

            Assert.AreEqual("10", customersFromDB[0].Id);
            Assert.AreEqual("9", booksFromDB[0].Id);
        }
        
    }
}