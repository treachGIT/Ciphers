using AlgorithmsLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsTest
{
    [TestClass]
    public class LFSR_Tests
    {
        [TestMethod]
        public void StreamCipherTest1()
        {
            string result = StreamCipher.Encrypt("11101001", "0010", "1001");
            string expectedResult = "10010011";
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void StreamCipherTest2()
        {
            string result = StreamCipher.Encrypt("1010", "0110", "1011");
            string expectedResult = "0111";
            Assert.AreEqual(result, expectedResult);
        }
    }
}
