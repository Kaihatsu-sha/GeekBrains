using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms;

namespace Algorithms.Tests
{
    [TestClass]
    public class MockDataTests
    {
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void PointStructFloat_inCount0_outExeption()
        {
            //arrange
            //actual 
            PointStruct<float>[] massiv = MockData.GetFloatStruct(0);
            //assert
        }
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void PointStructFloat_inCountM1_outExeption()
        {
            //arrange
            //actual 
            PointStruct<float>[] massiv = MockData.GetFloatStruct(-1);
            //assert
        }
        [TestMethod]
        public void PointStructFloat_inCount1_outCount1()
        {
            //arrange
            int expected = 1;
            //actual 
            PointStruct<float>[] massiv = MockData.GetFloatStruct(1);
            int actual = massiv.Length;
            //assert
            Assert.AreEqual<int>(expected, actual);
        }
        [TestMethod]
        public void PointStructFloat_inCount3_outCount3()
        {
            //arrange
            int expected = 3;
            //actual 
            PointStruct<float>[] massiv = MockData.GetFloatStruct(3);
            int actual = massiv.Length;
            //assert
            Assert.AreEqual<int>(expected, actual);
        }
        [TestMethod]
        public void PointStructFloat_inCount1000_outCount1000()
        {
            //arrange
            int expected = 1000;
            //actual 
            PointStruct<float>[] massiv = MockData.GetFloatStruct(1000);
            int actual = massiv.Length;
            //assert
            Assert.AreEqual<int>(expected, actual);
        }


        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void PointStructDouble_inCount0_outExeption()
        {
            //arrange
            //actual 
            PointStruct<double>[] massiv = MockData.GetDoubleStruct(0);
            //assert
        }
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void PointStructDouble_inCountM1_outExeption()
        {
            //arrange
            //actual 
            PointStruct<double>[] massiv = MockData.GetDoubleStruct(-1);
            //assert
        }
        [TestMethod]
        public void PointStructDouble_inCount1_outCount1()
        {
            //arrange
            int expected = 1;
            //actual 
            PointStruct<double>[] massiv = MockData.GetDoubleStruct(1);
            int actual = massiv.Length;
            //assert
            Assert.AreEqual<int>(expected, actual);
        }
        [TestMethod]
        public void PointStructDouble_inCount3_outCount3()
        {
            //arrange
            int expected = 3;
            //actual 
            PointStruct<double>[] massiv = MockData.GetDoubleStruct(3);
            int actual = massiv.Length;
            //assert
            Assert.AreEqual<int>(expected, actual);
        }
        [TestMethod]
        public void PointStructDouble_inCount1000_outCount1000()
        {
            //arrange
            int expected = 1000;
            //actual 
            PointStruct<double>[] massiv = MockData.GetDoubleStruct(1000);
            int actual = massiv.Length;
            //assert
            Assert.AreEqual<int>(expected, actual);
        }


        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void PointClassFloat_inCount0_outExeption()
        {
            //arrange
            //actual 
            PointClass<float>[] massiv = MockData.GetFloatClass(0);
            //assert
        }
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void PointClassFloat_inCountM1_outExeption()
        {
            //arrange
            //actual 
            PointClass<float>[] massiv = MockData.GetFloatClass(-1);
            //assert
        }
        [TestMethod]
        public void PointClassFloat_inCount1_outCount1()
        {
            //arrange
            int expected = 1;
            //actual 
            PointClass<float>[] massiv = MockData.GetFloatClass(1);
            int actual = massiv.Length;
            //assert
            Assert.AreEqual<int>(expected, actual);
        }
        [TestMethod]
        public void PointClassFloat_inCount3_outCount3()
        {
            //arrange
            int expected = 3;
            //actual 
            PointClass<float>[] massiv = MockData.GetFloatClass(3);
            int actual = massiv.Length;
            //assert
            Assert.AreEqual<int>(expected, actual);
        }
        [TestMethod]
        public void PointClassFloat_inCount1000_outCount1000()
        {
            //arrange
            int expected = 1000;
            //actual 
            PointClass<float>[] massiv = MockData.GetFloatClass(1000);
            int actual = massiv.Length;
            //assert
            Assert.AreEqual<int>(expected, actual);
        }
    }
}