using Data.API;
using Data.Implementation;

namespace TestData

{
    [TestClass]
    public class TestsDataRandom
    {

        private string generateString(int length)
        {
            Random rand = new Random();
            
            int stringlen = rand.Next(length, length);
            int randValue;
            string str = "";
            char letter;
            for (int i = 0; i < stringlen; i++)
            {
                randValue = rand.Next(0, 26);

                letter = Convert.ToChar(randValue + 65);

                str = str + letter;
            }

            return str;
        }

        [TestMethod]
        public void TestAddBook()
        {
            Random rand = new Random();
            
            string bookId = generateString(2);
            var testDataRepository = IDataRepository.CDataRepository();
            IBook testBook1 = new Book(bookId, generateString(6), generateString(3),
                rand.Next(1, 1000), generateString(9), generateString(3),
                generateString(7));
            testDataRepository.AddBook(testBook1);
            Assert.IsTrue(testDataRepository.BookExists(bookId));
            Assert.IsFalse(testDataRepository.BookExists(generateString(3)));

        }

        [TestMethod]
        public void TestAddCustomer()
        {
            Random rand = new Random();
            
            string customerId = generateString(2);
            var testDataRepository = IDataRepository.CDataRepository();
            ICustomer testCustomer1 = new Customer(customerId, generateString(6), generateString(3),
                rand.Next(1, 1000), generateString(9), generateString(3));
            testDataRepository.AddCustomer(testCustomer1);
            Assert.IsTrue(testDataRepository.CustomerExists(customerId));
            Assert.IsFalse(testDataRepository.CustomerExists(generateString(3)));
        }
        
        [TestMethod]
        public void TestAddStatus()
        {
            Random rand = new Random();
            
            string statusId = generateString(2);
            var testDataRepository = IDataRepository.CDataRepository();
            IBook testBook = new Book(generateString(2), generateString(6), generateString(3),
                rand.Next(1, 1000), generateString(9), generateString(3),
                generateString(7));
            IStatus testStatus = new Status(statusId, testBook);
            testDataRepository.AddStatus(testStatus);
            Assert.IsTrue(testDataRepository.StatusExists(statusId));
            Assert.IsFalse(testDataRepository.StatusExists(generateString(3)));
        }

        [TestMethod]
        public void TestAddAndDeleteBook()
        {
            Random rand = new Random();
            
            string bookId = generateString(2);
            var testDataRepository = IDataRepository.CDataRepository();
            IBook testBook1 = new Book(bookId, generateString(6), generateString(3),
                rand.Next(1, 1000), generateString(9), generateString(3),
                generateString(7));
            
            testDataRepository.AddBook(testBook1);
            Assert.IsTrue(testDataRepository.BookExists(bookId));
            
            testDataRepository.DeleteBookWithId(bookId);
            Assert.IsFalse(testDataRepository.BookExists(bookId));
        }
        
        [TestMethod]
        public void TestAddAndDeleteCustomer()
        {
            Random rand = new Random();
            
            string customerId = generateString(2);
            var testDataRepository = IDataRepository.CDataRepository();
            ICustomer testCustomer1 = new Customer(customerId, generateString(6), generateString(3),
                rand.Next(1, 1000), generateString(9), generateString(3));
            testDataRepository.AddCustomer(testCustomer1);
            
            Assert.IsTrue(testDataRepository.CustomerExists(customerId));
            
            testDataRepository.DeleteCustomerWithId(customerId);
            Assert.IsFalse(testDataRepository.CustomerExists(customerId));
        }
        
        [TestMethod]
        public void TestAddAndDeleteStatus()
        {
            Random rand = new Random();
            
            string statusId = generateString(2);
            var testDataRepository = IDataRepository.CDataRepository();
            IBook testBook = new Book(generateString(2), generateString(6), generateString(3),
                rand.Next(1, 1000), generateString(9), generateString(3),
                generateString(7));
            IStatus testStatus = new Status(statusId, testBook);
            testDataRepository.AddStatus(testStatus);
            
            Assert.IsTrue(testDataRepository.StatusExists(statusId));
            
            testDataRepository.DeleteStatusWithId(statusId);
            Assert.IsFalse(testDataRepository.StatusExists(statusId));
        }
        
    }  
    
}
