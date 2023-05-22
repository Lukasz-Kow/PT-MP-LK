using Data.API;
using Data.Implementation;

namespace TestData {

    [TestClass]
    [DeploymentItem(@"Instrumentation\UnitTestDataDB.mdf", @"Instrumentation")]
    public class DataTests
{

        //private static string m_ConnectionString;

        
        /*[ClassInitialize]
        public static void ClassInitializeMethod()
        {
            string _DBRelativePath = @"Instrumentation\UnitTestDataDB.mdf";
            string _TestingWorkingFolder = Environment.CurrentDirectory;
            string _DBPath = Path.Combine(_TestingWorkingFolder, _DBRelativePath);
            FileInfo _databaseFile = new FileInfo(_DBPath);
            Assert.IsTrue(_databaseFile.Exists, $"{Environment.CurrentDirectory}");
            m_ConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={_DBPath};Integrated Security = True;";
        }*/
        

        // DB Connection string needs to be adjusted to work on a different computer
        [TestMethod]
        public void InsertCustomer_ThenGet_ThenDropTable()
        {
            IDataRepository repository = IDataRepository.CDataRepository("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Studia\\PrijectPT\\TestData\\Instrumentation\\UnitTestDataDB.mdf;Integrated Security=True");

            repository.DropAll();

            ICustomer c = new Customer("1", "John", "Poe", 10, "lalalal", "Lodz");
            repository.InsertCustomer(c);

            ICustomer testCustomer = repository.GetCustomer(1);
           
            Assert.IsNotNull(testCustomer);

            Assert.AreEqual("1", testCustomer.Id);
            Type type = testCustomer.FirstName.GetType();
            Console.WriteLine(type);
            Assert.IsTrue(string.Equals(testCustomer.FirstName, "John"));
            Assert.IsTrue(string.Equals(testCustomer.LastName, "Poe"));
        }

        [TestMethod]
        public void InsertBook_ThenGet_ThenDropTable()
        {
            IDataRepository repository = new DataRepository("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Studia\\PrijectPT\\TestData\\Instrumentation\\UnitTestDataDB.mdf;Integrated Security=True");

            repository.DropAll();

            IBook book = new Book("1", "The Great Gatsby", "F. Scott Fitzgerald", 320, "9780743273565", "Scribner", "English");
            repository.InsertBook(book);

            IBook testBook = repository.GetBook(1);

            Assert.IsNotNull(testBook);
            Assert.AreEqual("1", testBook.Id);
            Assert.IsTrue(string.Equals(testBook.Title, "The Great Gatsby"));
            Assert.IsTrue(string.Equals(testBook.Author, "F. Scott Fitzgerald"));
        }

        [TestMethod]
        public void InsertStatus_ThenGet_ThenDropTable()
        {
            IDataRepository repository = new DataRepository("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Studia\\PrijectPT\\TestData\\Instrumentation\\UnitTestDataDB.mdf;Integrated Security=True");

            repository.DropAll();

            IBook book = new Book("1", "The Great Gatsby", "F. Scott Fitzgerald", 320, "9780743273565", "Scribner", "English");
            repository.InsertBook(book);

            IStatus status = new Status("1", book, true);
            repository.InsertStatus(status);

            IStatus testStatus = repository.GetStatus(1);

            Assert.IsNotNull(testStatus);
            Assert.AreEqual("1", testStatus.Id);
            Assert.AreEqual(book.Id, testStatus.Book.Id);
            Assert.IsTrue(testStatus.Availability);
        }

        [TestMethod]
        public void InsertEvent_ThenGet_ThenDropTable()
        {
            IDataRepository repository = new DataRepository("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Studia\\PrijectPT\\TestData\\Instrumentation\\UnitTestDataDB.mdf;Integrated Security=True");

            repository.DropAll();

            ICustomer customer = new Customer("1", "John", "Doe", 25, "123 Main St", "New York");
            repository.InsertCustomer(customer);

            IBook book = new Book("1", "The Great Gatsby", "F. Scott Fitzgerald", 320, "9780743273565", "Scribner", "English");
            repository.InsertBook(book);

            IStatus status = new Status("1", book, true);
            repository.InsertStatus(status);

            IEvent evnt = new Buy("1", customer, status, DateTime.Now);
            repository.InsertEvent(evnt);

            IEvent testEvent = repository.GetEvent(1);

            Assert.IsNotNull(testEvent);
            Assert.AreEqual("1", testEvent.Id);
            Assert.AreEqual(customer.Id, testEvent.Customer.Id);
            Assert.AreEqual(status.Id, testEvent.Status.Id);
        }

        [TestMethod]
        public void UpdateCustomer_ThenGet()
        {
            IDataRepository repository = new DataRepository("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Studia\\PrijectPT\\TestData\\Instrumentation\\UnitTestDataDB.mdf;Integrated Security=True");

            repository.DropAll();

            ICustomer customer = new Customer("1", "John", "Doe", 25, "123 Main St", "New York");
            repository.InsertCustomer(customer);

            customer.FirstName = "Jane";
            customer.LastName = "Smith";
            repository.UpdateCustomer(customer);

            ICustomer updatedCustomer = repository.GetCustomer(1);

            Assert.IsNotNull(updatedCustomer);
            Assert.AreEqual("1", updatedCustomer.Id);
            Assert.AreEqual("Jane", updatedCustomer.FirstName);
            Assert.AreEqual("Smith", updatedCustomer.LastName);
        }

        [TestMethod]
        public void UpdateBook_ThenGet()
        {
            IDataRepository repository = new DataRepository("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Studia\\PrijectPT\\TestData\\Instrumentation\\UnitTestDataDB.mdf;Integrated Security=True");

            repository.DropAll();

            IBook book = new Book("1", "The Great Gatsby", "F. Scott Fitzgerald", 320, "9780743273565", "Scribner", "English");
            repository.InsertBook(book);

            book.Title = "Pride and Prejudice";
            book.Author = "Jane Austen";
            repository.UpdateBook(book);

            IBook updatedBook = repository.GetBook(1);

            Assert.IsNotNull(updatedBook);
            Assert.AreEqual("1", updatedBook.Id);
            Assert.AreEqual("Pride and Prejudice", updatedBook.Title);
            Assert.AreEqual("Jane Austen", updatedBook.Author);
        }

        [TestMethod]
        public void UpdateStatus_ThenGet()
        {
            IDataRepository repository = new DataRepository("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Studia\\PrijectPT\\TestData\\Instrumentation\\UnitTestDataDB.mdf;Integrated Security=True");

            repository.DropAll();

            IBook book = new Book("1", "The Great Gatsby", "F. Scott Fitzgerald", 320, "9780743273565", "Scribner", "English");
            repository.InsertBook(book);

            IStatus status = new Status("1", book, true);
            repository.InsertStatus(status);

            status.Availability = false;
            repository.UpdateStatus(status);

            IStatus updatedStatus = repository.GetStatus(1);

            Assert.IsNotNull(updatedStatus);
            Assert.AreEqual("1", updatedStatus.Id);
            Assert.AreEqual(book.Id, updatedStatus.Book.Id);
            Assert.IsFalse(updatedStatus.Availability);
        }

        [TestMethod]
        public void UpdateEvent_ThenGet()
        {
            IDataRepository repository = new DataRepository("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Studia\\PrijectPT\\TestData\\Instrumentation\\UnitTestDataDB.mdf;Integrated Security=True");

            repository.DropAll();

            ICustomer customer = new Customer("1", "John", "Doe", 25, "123 Main St", "New York");
            repository.InsertCustomer(customer);

            IBook book = new Book("1", "The Great Gatsby", "F. Scott Fitzgerald", 320, "9780743273565", "Scribner", "English");
            repository.InsertBook(book);

            IStatus status = new Status("1", book, true);
            repository.InsertStatus(status);

            IEvent evnt = new Buy("1", customer, status, DateTime.Now);
            repository.InsertEvent(evnt);

            evnt.Time = DateTime.Now.AddDays(-1);
            repository.UpdateEvent(evnt);

            IEvent updatedEvent = repository.GetEvent(1);

            Assert.IsNotNull(updatedEvent);
            Assert.AreEqual("1", updatedEvent.Id);
            Assert.AreEqual(customer.Id, updatedEvent.Customer.Id);
            Assert.AreEqual(status.Id, updatedEvent.Status.Id);
        }


    }
}
