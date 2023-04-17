using Data.API;
using Data.Implementation;
using Logic.API;

namespace LogicTest
{
    [TestClass]
    public class TestLogicRandom
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
        public void BuyBookTestRandom()
        {
            Random rand = new Random();

            var randBookId = generateString(2);
            var randCusId = generateString(2);
            var randStaId = generateString(2);
            var testDataRep = IDataRepository.CDataRepository();
            ICustomer customer1 = new Customer(randCusId, generateString(10), generateString(20), rand.Next(1,500), generateString(25), generateString(10));
            testDataRep.AddCustomer(customer1);
            IBook book1 = new Book(randBookId, generateString(20), generateString(20), rand.Next(1, 1000), generateString(5), generateString(25), generateString(25));
            testDataRep.AddBook(book1);
            IStatus status1 = new Status(randStaId, book1);
            testDataRep.AddStatus(status1);
            var logic = IBookShopLogic.CreateBookShopLogic(testDataRep);
            logic.BuyBook(randBookId, randCusId, randStaId);

            Assert.IsFalse(testDataRep.IsAvailable(randStaId));

        }

        [TestMethod]
        public void ReturnBookTest()
        {
            Random rand = new Random();

            var randBookId = generateString(2);
            var randCusId = generateString(2);
            var randStaId = generateString(2);

            var testDataRep = IDataRepository.CDataRepository();
            ICustomer customer1 = new Customer(randCusId, generateString(10), generateString(20), rand.Next(1, 500), generateString(25), generateString(10));
            testDataRep.AddCustomer(customer1);
            IBook book1 = new Book(randBookId, generateString(20), generateString(20), rand.Next(1, 1000), generateString(5), generateString(25), generateString(25));
            testDataRep.AddBook(book1);
            IStatus status1 = new Status(randStaId, book1);
            testDataRep.AddStatus(status1);
            var logic = IBookShopLogic.CreateBookShopLogic(testDataRep);
            logic.BuyBook(randBookId, randCusId, randStaId);

            Assert.IsFalse(testDataRep.IsAvailable(randStaId));

            logic.ReturnBook(randBookId, randCusId, randStaId);
            Assert.IsTrue(testDataRep.IsAvailable(randStaId));

        }
        [TestMethod]
        public void ReviewBookRand()
        {

            Random rand = new Random();

            var randBookId = generateString(2);
            var randCusId = generateString(2);
            var randStaId = generateString(2);

            var testDataRep = IDataRepository.CDataRepository();
            ICustomer customer1 = new Customer(randCusId, generateString(10), generateString(20), rand.Next(1, 500), generateString(25), generateString(10));
            testDataRep.AddCustomer(customer1);
            IBook book1 = new Book(randBookId, generateString(20), generateString(20), rand.Next(1, 1000), generateString(5), generateString(25), generateString(25));
            testDataRep.AddBook(book1);
            IStatus status1 = new Status(randStaId, book1);
            testDataRep.AddStatus(status1);
            var logic = IBookShopLogic.CreateBookShopLogic(testDataRep);

            logic.ReviewBook(randStaId, randCusId, randBookId, "Great book!");

            Assert.IsTrue(testDataRep.EventExists(randStaId));
        }

        [TestMethod]
        public void ComplaintTestRand()
        {
            Random rand = new Random();

            var randBookId = generateString(2);
            var randCusId = generateString(2);
            var randStaId = generateString(2);

            var testDataRep = IDataRepository.CDataRepository();
            ICustomer customer1 = new Customer(randCusId, generateString(10), generateString(20), rand.Next(1, 500), generateString(25), generateString(10));
            testDataRep.AddCustomer(customer1);
            IBook book1 = new Book(randBookId, generateString(20), generateString(20), rand.Next(1, 1000), generateString(5), generateString(25), generateString(25));
            testDataRep.AddBook(book1);
            IStatus status1 = new Status(randStaId, book1);
            testDataRep.AddStatus(status1);
            var logic = IBookShopLogic.CreateBookShopLogic(testDataRep);

            logic.Complaint(randStaId, randCusId, randBookId, "Boooring!");

            Assert.IsTrue(testDataRep.EventExists(randStaId));
        }
    }
}
