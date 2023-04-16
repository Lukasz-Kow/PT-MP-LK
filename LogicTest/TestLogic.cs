using Logic.API;
using Data.API;
using Data.Implementation;

namespace LogicTest
{
    [TestClass]
    public class TestLogic
    {
        [TestMethod]
        public void BuyBookTest()
        {
            var testDataRep = IDataRepository.CDataRepository();
            ICustomer customer1 = new Customer("10", "Lukasz", "Kowalczyk", 21, "Al.Politechniki", "Lodz");
            testDataRep.AddCustomer(customer1);
            IBook book1 = new Book("9", "Pan Tadeusz", "Adam Mickiewicz", 400, "SR2", "Greg", "Polish");
            testDataRep.AddBook(book1);
            IStatus status1 = new Status("1", book1);
            testDataRep.AddStatus(status1);
            var logic = IBookShopLogic.CreateBookShopLogic(testDataRep);
            logic.BuyBook("1", "10", "1");

            Assert.IsFalse(testDataRep.IsAvailable ("1"));

        }
        [TestMethod]
        public void ReturnBookTest()
        {
            var testDataRep = IDataRepository.CDataRepository();
            ICustomer customer1 = new Customer("10", "Lukasz", "Kowalczyk", 21, "Al.Politechniki", "Lodz");
            testDataRep.AddCustomer(customer1);
            IBook book1 = new Book("9", "Pan Tadeusz", "Adam Mickiewicz", 400, "SR2", "Greg", "Polish");
            testDataRep.AddBook(book1);
            IStatus status1 = new Status("1", book1);
            testDataRep.AddStatus(status1);
            var logic = IBookShopLogic.CreateBookShopLogic(testDataRep);
            logic.BuyBook("1", "10", "1");

            Assert.IsFalse(testDataRep.IsAvailable("1"));

            logic.ReturnBook("1", "10", "1");
            Assert.IsTrue(testDataRep.IsAvailable("1"));

        }

        [TestMethod]
        public void ReviewBook()
        {
            var testDataRep = IDataRepository.CDataRepository();
            ICustomer customer1 = new Customer("10", "Lukasz", "Kowalczyk", 21, "Al.Politechniki", "Lodz");
            testDataRep.AddCustomer(customer1);
            IBook book1 = new Book("9", "Pan Tadeusz", "Adam Mickiewicz", 400, "SR2", "Greg", "Polish");
            testDataRep.AddBook(book1);
            IStatus status1 = new Status("1", book1);
            testDataRep.AddStatus(status1);
            var logic = IBookShopLogic.CreateBookShopLogic(testDataRep);

            logic.ReviewBook("1", "10", "1", "Great book!");

            Assert.IsTrue(testDataRep.EventExists("1"));
        }

        [TestMethod]
        public void ComplaintTest()
        {
            var testDataRep = IDataRepository.CDataRepository();
            ICustomer customer1 = new Customer("10", "Lukasz", "Kowalczyk", 21, "Al.Politechniki", "Lodz");
            testDataRep.AddCustomer(customer1);
            IBook book1 = new Book("9", "Pan Tadeusz", "Adam Mickiewicz", 400, "SR2", "Greg", "Polish");
            testDataRep.AddBook(book1);
            IStatus status1 = new Status("1", book1);
            testDataRep.AddStatus(status1);
            var logic = IBookShopLogic.CreateBookShopLogic(testDataRep);

            logic.Complaint("1", "10", "1", "Boooring!");

            Assert.IsTrue(testDataRep.EventExists("1"));
        }
    }
}