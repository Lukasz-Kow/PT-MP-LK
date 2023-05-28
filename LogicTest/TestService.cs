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

            IServices testService = IServices.Create("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Studia\\PrijectPT\\TestData\\Instrumentation\\UnitTestDataDB.mdf;Integrated Security=True");

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

        [TestMethod]
        public void AddCustomerBookAndStatusAndDeleteThem()
        {

            IServices testService = IServices.Create("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Studia\\PrijectPT\\TestData\\Instrumentation\\UnitTestDataDB.mdf;Integrated Security=True");

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

            testService.DeleteStatus(status1.Id);
            testService.DeleteBook(book1.Id);
            testService.DeleteCustomer(customer1.Id);
            

            booksFromDB = testService.GetAllBooks();
            customersFromDB = testService.GetAllCustomers();

            Assert.AreEqual(0, booksFromDB.Count);
            Assert.AreEqual(0, customersFromDB.Count);
        }

        [TestMethod]
        public void Add2BooksAndGetASingleOne()
        {
            IServices testService = IServices.Create("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Studia\\PrijectPT\\TestData\\Instrumentation\\UnitTestDataDB.mdf;Integrated Security=True");

            testService.DropTables();
            
            IBook book1 = new Book("9", "Pan Tadeusz", "Adam Mickiewicz", 400, "SR2", "Greg", "Polish");
            testService.AddBook(book1.Title, book1.Author, book1.Id, book1.Pages, book1.ISBN, book1.Publisher, book1.Language);
            IBook book2 = new Book("10", "Pan Tadeusz", "Adam Mickiewicz", 400, "SR2", "Greg", "Polish");
            testService.AddBook(book2.Title, book2.Author, book2.Id, book2.Pages, book2.ISBN, book2.Publisher, book2.Language);

            IBook bookFromDB = testService.GetBookById(book2.Id);

            Assert.AreEqual(book2.Id, bookFromDB.Id);
            Assert.AreEqual(book2.Title, bookFromDB.Title);
            Assert.AreEqual(book2.Author, bookFromDB.Author);
            Assert.AreEqual(book2.Pages, bookFromDB.Pages);
            
        }
        
    }
}