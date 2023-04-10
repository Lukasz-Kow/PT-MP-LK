using Data.API;
using Data.Implementation;

namespace TestData {
    
public class TestBook : IBook
{
    public TestBook(string id, string title, string author, int pages, string ISBN, string publisher, string language)
    {
        Title = title;
        Author = author;
        Id = id;
        Pages = pages;
        this.ISBN = ISBN;
        Publisher = publisher;
        Language = language;
    }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Id { get; set; }
    public int Pages { get; set; }
    public string ISBN { get; set; }
    public string Publisher { get; set; }
    public string Language { get; set; }
    
}

[TestClass]
public class DataTests
{
        [TestMethod]
        public void TestAddCatalog()
        {
            var testDataRepository = IDataRepository.CDataRepository();
            IBook testBook1 = new TestBook("1", "Maly ksiaze", "Antoine de Saint-Exupery", 200, "123456789", "Penguin", "English");
            testDataRepository.AddBook(testBook1);
            Assert.IsTrue(testDataRepository.BookExists("1"));
            
            IBook testBook2 = new TestBook("21", "Hobbit", "Tolkien", 300, "1236789", "Penguin", "English");
            testDataRepository.AddBook(testBook2);
            Assert.IsTrue(testDataRepository.BookExists("21"));
            
            Assert.IsFalse(testDataRepository.BookExists("3"));

        }

        [TestMethod]
        public void TestCustomer()
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
        public void TestState()
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
}
}
