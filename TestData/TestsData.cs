using Data.API;
using Data.Implementation;

namespace TestData {

    [TestClass]
public class DataTests
{
        [TestMethod]
        public void TestGetPredefinedCustomer()
        {
            IDataRepository repository = IDataRepository.CDataRepository("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Studia\\PrijectPT\\Data\\BookShopDB.mdf;Integrated Security=True");

            // ICustomer c = new Customer("1", "John", "Poe", 10, "lalalal", "Lodz");

            ICustomer testCustomer = repository.GetCustomer(1);
           
            Assert.IsNotNull(testCustomer);

            Assert.AreEqual("1", testCustomer.Id);
            Type type = testCustomer.FirstName.GetType();
            Console.WriteLine(type);
            Assert.IsTrue(string.Equals(testCustomer.FirstName, "John"));
            Assert.IsTrue(string.Equals(testCustomer.LastName, "Poe"));


        }

        
}
}
