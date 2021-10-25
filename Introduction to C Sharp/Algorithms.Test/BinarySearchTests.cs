using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms;

namespace Algorithms.Tests
{
    [TestClass]
    public class BinarySearchTests
    {
        [TestMethod]
        public void BinarySearch_searchValue0_out0()
        {
            //arrange
            int expected = 0;
            //actual 
            int[] massive = new int[4] { 1, 5, 0, 3 };
            int actual = -1;
            BinarySearch search = new BinarySearch(massive, 0, out actual);
            //assert
            Assert.AreEqual<int>(expected, actual);
        }


        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void BinarySearch_EmptyMassiv_outException()
        {
            //arrange
            int expected = -1;
            //actual 
            int[] massive = new int[0] {};
            int actual = -1;
            BinarySearch search = new BinarySearch(massive, 0, out actual);
            //assert
            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void BinarySearch_Negative_outM1()
        {
            //arrange
            int expected = 0;//Ожидаем все, кроме -1
            //actual 
            int[] massive = new int[5] { 1,2,3,4,5};
            int actual = -1;
            BinarySearch search = new BinarySearch(massive, 0, out actual);
            //assert
            Assert.AreEqual<int>(expected, actual,"Ождалось {0}",parameters: actual);
        }

        [TestMethod]
        public void BinarySearch_SearchValue5_out2()
        {
            //arrange
            int expected = 2;
            //actual 
            int[] massive = new int[10] {56,2,0,8,5,18, 7, 34, 11,23 };
            int actual = -1;
            BinarySearch search = new BinarySearch(massive, 5, out actual);

            //int actual = 0;
            //assert
            Assert.AreEqual<int>(expected, actual, "Ождалось {0}", parameters: actual);
        }

        [TestMethod]
        public void BinarySearch_SearchValueH_outH()
        {
            //arrange
            int expected = 9;
            //actual 
            int[] massive = new int[10] { 56, 2, 0, 8, (int)'H', 18, 7, 34, 11, 23 };
            int actual = -1;
            BinarySearch search = new BinarySearch(massive, (int)'H', out actual);

            //int actual = 0;
            //assert
            Assert.AreEqual<int>(expected, actual, "Ождалось {0}", parameters: actual);
        }

    }
}
