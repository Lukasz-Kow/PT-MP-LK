using Logic.API;
using Data.API;
using Data.Implementation;
using Logic.Implementation;

namespace TestLogic
{
    [TestClass]
    public class TestLogic
    {
        [TestMethod]
        public void BuyBook()
        {
            var testDataRep = IDataRepository.CDataRepository();
            ICustomer customer1 = new Customer("1", "Lukasz", "Kowalczyk", 21, "Al.Politechniki", "Lodz");
            testDataRep.AddCustomer(customer1);
            IBook book1 = new Book("1", "Pan Tadeusz", "Adam Mickiewicz", 400, "SR2", "Greg", "Polish");
            testDataRep.AddBook(book1);
            IStatus status1 = new Status("1", book1);
            testDataRep.AddStatus(status1);
            var logic = new BussinesLogic(testDataRep);
            logic.BuyBook("1", "1");
            
            Assert.IsFalse(testDataRep.IsAvailable("1"));


        }
        [TestMethod]
        public void ReturnBook()
        {
            var testDataRep = IDataRepository.CDataRepository();
            ICustomer customer1 = new Customer("1", "Lukasz", "Kowalczyk", 21, "Al.Politechniki", "Lodz");
            testDataRep.AddCustomer(customer1);
            IBook book1 = new Book("1", "Pan Tadeusz", "Adam Mickiewicz", 400, "SR2", "Greg", "Polish");
            testDataRep.AddBook(book1);
            IStatus status1 = new Status("1", book1);
            testDataRep.AddStatus(status1);
            var logic = new BussinesLogic(testDataRep);
            logic.BuyBook("1", "1");

            Assert.IsFalse(testDataRep.IsAvailable("1"));

            logic.ReturnBook("1", "1");

            Assert.IsTrue(testDataRep.IsAvailable("1"));


        }
    }
}