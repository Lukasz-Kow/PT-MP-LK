using System.Data;
using Calc;

namespace TestData
{
    [TestClass]
    public class CalculatorTest
    {
        private Calculator myCalc = new Calculator();
        
        [TestMethod]
        public void AddingTest()
        {
            int a = 1;
            int b = 2;

            int expected = 3;
            int result = myCalc.Adding(a, b);
            
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void SubtractionTest() 
        {
            int a = 5;
            int b = 3;
            
            int expected = 2;
            int result = myCalc.Subtraction(a, b);
            
            Assert.AreEqual(expected, result);


        }
    }
}