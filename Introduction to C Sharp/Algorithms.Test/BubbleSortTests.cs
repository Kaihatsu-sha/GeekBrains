using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms;

namespace Algorithms.Tests
{
    [TestClass]
    public class BubbleSortTests
    {
        [TestMethod]
        public void BubbleSort_Items4_true()
        {
            //arrange
            bool expected = true;
            int[] massiveReference = new int[4] { 0, 1, 3, 5 };
            //actual 
            int[] massive = new int[4] { 1, 5, 0, 3 };
            BubbleSort sort = new BubbleSort(ref massive);

            bool actual = true;
            for (int i = 0; i < massive.Length; i++)
            {
                if (massive[i] != massiveReference[i])
                {
                    actual = false;
                    break;
                }
            }
            //assert
            Assert.AreEqual<bool>(expected, actual);
        }

        [TestMethod]
        public void BubbleSort_IdenticalItems4_true()
        {
            //arrange
            bool expected = true;
            int[] massiveReference = new int[4] { 0, 0, 0, 0 };
            //actual 
            int[] massive = new int[4] { 0, 0, 0, 0 };
            BubbleSort sort = new BubbleSort(ref massive);

            bool actual = true;
            for (int i = 0; i < massive.Length; i++)
            {
                if (massive[i] != massiveReference[i])
                {
                    actual = false;
                    break;
                }
            }
            //assert
            Assert.AreEqual<bool>(expected, actual);
        }

        [TestMethod]
        public void BubbleSort_IdenticalItems2_true()
        {
            //arrange
            bool expected = true;
            int[] massiveReference = new int[4] { 0, 0, 1, 1 };
            //actual 
            int[] massive = new int[4] { 1, 0, 1, 0 };
            BubbleSort sort = new BubbleSort(ref massive);

            bool actual = true;
            for (int i = 0; i < massive.Length; i++)
            {
                if (massive[i] != massiveReference[i])
                {
                    actual = false;
                    break;
                }
            }
            //assert
            Assert.AreEqual<bool>(expected, actual);
        }

        [TestMethod]
        public void BubbleSort_Negative1NoChange_false()
        {
            //arrange
            bool expected = false;
            int[] massiveReference = new int[4] { 1, 0, 1, 0 };
            //actual 
            int[] massive = new int[4] { 1, 0, 1, 0 };
            BubbleSort sort = new BubbleSort(ref massive);

            bool actual = true;
            for (int i = 0; i < massive.Length; i++)
            {
                if (massive[i] != massiveReference[i])
                {
                    actual = false;
                    break;
                }
            }
            //assert
            Assert.AreEqual<bool>(expected, actual);
        }


        [TestMethod]
        public void BubbleSort_Negative2NoChange_false()
        {
            //arrange
            bool expected = false;
            int[] massiveReference = new int[5] { 1, 4, 0, 9, 1 };
            //actual 
            int[] massive = new int[5] { 1, 4, 0, 9, 1 };
            BubbleSort sort = new BubbleSort(ref massive);

            bool actual = true;
            for (int i = 0; i < massive.Length; i++)
            {
                if (massive[i] != massiveReference[i])
                {
                    actual = false;
                    break;
                }
            }
            //assert
            Assert.AreEqual<bool>(expected, actual);
        }
    }
}
