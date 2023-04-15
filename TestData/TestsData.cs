using Data.API;
using Data.Implementation;

namespace TestData {

    [TestClass]
public class DataTests
{
        [TestMethod]
        public void TestAddAndDeleteBook()
        {
            var testDataRepository = IDataRepository.CDataRepository();
            IBook testBook1 = new Book("1", "Maly ksiaze", "Antoine de Saint-Exupery", 200, "123456789", "Penguin", "English");
            testDataRepository.AddBook(testBook1);
            Assert.IsTrue(testDataRepository.BookExists("1"));
            
            IBook testBook2 = new Book("21", "Hobbit", "Tolkien", 300, "1236789", "Penguin", "English");
            testDataRepository.AddBook(testBook2);
            Assert.IsTrue(testDataRepository.BookExists("21"));
            Assert.IsFalse(testDataRepository.BookExists("3"));
            
            testDataRepository.DeleteBookWithId("1");
            Assert.IsFalse(testDataRepository.BookExists("1"));
            
            testDataRepository.DeleteBookWithId("21");
            Assert.IsFalse(testDataRepository.BookExists("21"));

        }

        [TestMethod]
        public void TestAddAndDeleteCustomer()
        {
            var testDataRepository = IDataRepository.CDataRepository();
            ICustomer testCustomer1 = new Customer("1", "Michael", "Jordan", 40, "adress", "New York");
            testDataRepository.AddCustomer(testCustomer1);
            
            Assert.IsTrue(testDataRepository.CustomerExists("1"));
            Assert.IsFalse(testDataRepository.CustomerExists("2"));
            
            testDataRepository.DeleteCustomerWithId("1");
            Assert.IsFalse(testDataRepository.CustomerExists("1"));
            
        }
        
        [TestMethod]
        public void TestStatus()
        {
            var testDataRepository = IDataRepository.CDataRepository();
            IBook testBook = new Book("1", "Maly ksiaze", "Antoine de Saint-Exupery", 200, "123456789", "Penguin", "English" );
            IStatus testStatus = new Status("1", testBook);
            testDataRepository.AddStatus(testStatus);
            
            Assert.IsTrue(testDataRepository.StatusExists("1"));
            Assert.IsFalse(testDataRepository.StatusExists("2"));
            testDataRepository.DeleteStatusWithId("1");
            Assert.IsFalse(testDataRepository.StatusExists("1"));
        }

        [TestMethod]
        public void TestGetters()
        {
            var testDataRepository = IDataRepository.CDataRepository();
            IBook testBook = new Book("1", "Maly ksiaze", "Antoine de Saint-Exupery", 200, "123456789", "Penguin", "English" );
            testDataRepository.AddBook(testBook);
            Assert.AreEqual(testBook, testDataRepository.GetBookById("1"));
            
            IStatus testStatus = new Status("1", testBook);
            testDataRepository.AddStatus(testStatus);
            Assert.AreEqual(testStatus, testDataRepository.GetStatusById("1"));
            
            ICustomer testCustomer = new Customer("1", "Michael", "Jordan", 40, "adress", "New York");
            testDataRepository.AddCustomer(testCustomer);
            Assert.AreEqual(testCustomer, testDataRepository.GetCustomerById("1"));
        }
}
}
