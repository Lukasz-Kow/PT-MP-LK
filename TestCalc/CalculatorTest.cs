using System.Data;

namespace TestCalc
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void AddingTest()
        {
            int a = 1;
            int b = 2;

            int expected = 3;
            int result = a + b;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void SubtractionTest() 
        {
            int a = 5;
            int b = 3;
            int expected = 2;

            int result = a - b;
            Assert.AreEqual(expected, result);


        }
    }
}