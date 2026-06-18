using WebApplication1.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace WebApplication1.Tests
{
    // my name is  mani
    [TestClass]
    public class CalculatorServiceTests
    {
        [TestMethod]
        public void Add_Should_Return_4()
        {
            var service = new CalculaterService();

            var result = service.Add(2, 2);

            Assert.AreEqual(4, result);
        }
    }
}
