using Logic.API;
using Data.API;
using Data.Implementation;
using Logic.Implementation;

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
            var logic = new BookShopLogic(testDataRep);
            logic.BuyBook("1", "10", "9");

            Assert.IsFalse(testDataRep.IsAvailable("1", "9"));


        }
        [TestMethod]
        public void ReturnBookTest()
        {
            var testDataRep = IDataRepository.CDataRepository();
            ICustomer customer1 = new Customer("10", "Lukasz", "Kowalczyk", 21, "Al.Politechniki", "Lodz");
            testDataRep.AddCustomer(customer1);
            IBook book1 = new Book("9", "Pan Tadeusz", "Adam Mickiewicz", 400, "SR2", "Greg", "Polish");
            testDataRep.AddBook(book1);
            var logic = new BookShopLogic(testDataRep);
            logic.BuyBook("1", "10", "9");

            Assert.IsFalse(testDataRep.IsAvailable("1", "9"));

            logic.ReturnBook("1", "10", "9");

            Assert.IsTrue(testDataRep.IsAvailable("1", "9"));

        }
    }
}