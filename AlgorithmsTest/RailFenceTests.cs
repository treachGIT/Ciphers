using AlgorithmsLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace AlgorithmsTest
{
    [TestClass]
    public class RailFenceTests
    {
        [TestMethod]
        public void RailFenceTest1()
        {
            string result = RailFence.Encrypt("CRYPTOGRAPHY", 3);
            string expectedResult = "CTARPORPYYGH";
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void RailFenceTest2()
        {
            string result = RailFence.Decrypt("CTARPORPYYGH", 3);
            string expectedResult = "CRYPTOGRAPHY";
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void RailFenceTest3()
        {
            string result = RailFence.Encrypt("TEXT TO CHECK RAIL FENCE", 7);
            string expectedResult = "TKEC EXERCTHAN CIET LFO ";
            Assert.AreEqual(expectedResult, result);
        }

    }
}
