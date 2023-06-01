using Castle.Core.Resource;
using Data;
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

            repository.InsertCustomer("1", "John", "Poe", 10, "lalalal", "Lodz");

            ICustomer testCustomer = repository.GetCustomer(1);
           
            Assert.IsNotNull(testCustomer);

            Assert.AreEqual("1", testCustomer.Id);

            Assert.IsTrue(string.Equals(testCustomer.FirstName, "John"));
            Assert.IsTrue(string.Equals(testCustomer.LastName, "Poe"));


        }

        [TestMethod]
        public void InsertCustomer_ThenGet_ThenDropTable_QuerySyntax()
        {
            IDataRepository repository = new DataRepository("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Studia\\PrijectPT\\TestData\\Instrumentation\\UnitTestDataDB.mdf;Integrated Security=True");

            repository.DropAll();

            repository.InsertCustomer("1", "John", "Poe", 10, "lalalal", "Lodz");

            ICustomer testCustomer = repository.GetCustomer_QuerySyntax(1);

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

            repository.InsertBook("1", "The Great Gatsby", "F. Scott Fitzgerald", 320, "9780743273565", "Scribner", "English");

            IBook testBook = repository.GetBook(1);

            Assert.IsNotNull(testBook);
            Assert.AreEqual("1", testBook.Id);
            Assert.IsTrue(string.Equals(testBook.Title, "The Great Gatsby"));
            Assert.IsTrue(string.Equals(testBook.Author, "F. Scott Fitzgerald"));



        }

        [TestMethod]
        public void InsertBook_ThenGet_ThenDropTable_QuerySyntax()
        {
            IDataRepository repository = new DataRepository("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Studia\\PrijectPT\\TestData\\Instrumentation\\UnitTestDataDB.mdf;Integrated Security=True");

            repository.DropAll();

            repository.InsertBook("1", "The Great Gatsby", "F. Scott Fitzgerald", 320, "9780743273565", "Scribner", "English");


            IBook testBook = repository.GetBook_QuerySyntax(1);

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

            
            repository.InsertBook("1", "The Great Gatsby", "F. Scott Fitzgerald", 320, "9780743273565", "Scribner", "English");

            IBook testBook = repository.GetBook(1);


            
            repository.InsertStatus("1", "1", true);

            IStatus testStatus = repository.GetStatus(1);

            Assert.IsNotNull(testStatus);
            Assert.AreEqual("1", testStatus.Id);
            Assert.AreEqual(testBook.Id, testStatus.Book.Id);
            Assert.IsTrue(testStatus.Availability);

        }

        [TestMethod]
        public void InsertStatus_ThenGet_ThenDropTable_QuerySyntax()
        {
            IDataRepository repository = new DataRepository("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Studia\\PrijectPT\\TestData\\Instrumentation\\UnitTestDataDB.mdf;Integrated Security=True");

            repository.DropAll();

            
            repository.InsertBook("1", "The Great Gatsby", "F. Scott Fitzgerald", 320, "9780743273565", "Scribner", "English");

            IBook book = repository.GetBook(1);

            repository.InsertStatus("1", "1", true);

            IStatus testStatus = repository.GetStatus_QuerySyntax(1);

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

            repository.InsertCustomer("1", "John", "Doe", 25, "123 Main St", "New York");

            ICustomer customer = repository.GetCustomer(1);
            repository.InsertBook("1", "The Great Gatsby", "F. Scott Fitzgerald", 320, "9780743273565", "Scribner", "English");
            IBook book = repository.GetBook(1);

            repository.InsertStatus("1", "1", true);
            IStatus status = repository.GetStatus(1);

            repository.InsertEvent("1", "1", "1", DateTime.Now, "Buy");

            IEvent testEvent = repository.GetEvent(1);

            Assert.IsNotNull(testEvent);
            Assert.AreEqual("1", testEvent.Id);
            Assert.AreEqual(customer.Id, testEvent.Customer.Id);
            Assert.AreEqual(status.Id, testEvent.Status.Id);
        }

        [TestMethod]
        public void InsertEvent_ThenGet_ThenDropTable_QuerySyntax()
        {
            IDataRepository repository = new DataRepository("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Studia\\PrijectPT\\TestData\\Instrumentation\\UnitTestDataDB.mdf;Integrated Security=True");

            repository.DropAll();

            repository.InsertCustomer("1", "John", "Doe", 25, "123 Main St", "New York");

            ICustomer customer = repository.GetCustomer(1);

            repository.InsertBook("1", "The Great Gatsby", "F. Scott Fitzgerald", 320, "9780743273565", "Scribner", "English");

            IBook book = repository.GetBook(1);

            repository.InsertStatus("1", "1", true);

            IStatus status = repository.GetStatus(1);

            repository.InsertEvent("1", "1", "1", DateTime.Now, "Buy");

            IEvent testEvent = repository.GetEvent_QuerySyntax(1);

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

            repository.InsertCustomer("1", "John", "Doe", 25, "123 Main St", "New York");

            ICustomer customer = repository.GetCustomer(1);

            repository.UpdateCustomer("1", "Jane", "Smith", 25, "123 Main St", "New York");

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

            repository.InsertBook("1", "The Great Gatsby", "F. Scott Fitzgerald", 320, "9780743273565", "Scribner", "English");

            IBook book = repository.GetBook(1);


            repository.UpdateBook("1", "Pride and Prejudice", "Jane Austen", 320, "9780743273565", "Scribner", "English");

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

            repository.InsertBook("1", "The Great Gatsby", "F. Scott Fitzgerald", 320, "9780743273565", "Scribner", "English");

            IBook book = repository.GetBook(1);

            repository.InsertStatus("1", "1", true);

            IStatus status = repository.GetStatus(1);

            repository.UpdateStatus("1", "1", false);

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

            repository.InsertCustomer("1", "John", "Doe", 25, "123 Main St", "New York");

            ICustomer customer = repository.GetCustomer(1);

            repository.InsertBook("1", "The Great Gatsby", "F. Scott Fitzgerald", 320, "9780743273565", "Scribner", "English");

            IBook book = repository.GetBook(1);

            repository.InsertStatus("1", "1", true);

            IStatus status = repository.GetStatus(1);

            repository.InsertEvent("1", "1", "1", DateTime.Now, "Buy");

            IEvent testEvent = repository.GetEvent(1);

            repository.UpdateEvent("1", "1", "1", DateTime.Now.AddDays(-1), "Buy");

            IEvent updatedEvent = repository.GetEvent(1);

            Assert.IsNotNull(updatedEvent);
            Assert.AreEqual("1", updatedEvent.Id);
            Assert.AreEqual(customer.Id, updatedEvent.Customer.Id);
            Assert.AreEqual(status.Id, updatedEvent.Status.Id);
        }


    }
}
