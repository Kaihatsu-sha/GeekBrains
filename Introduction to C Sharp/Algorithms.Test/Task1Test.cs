using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms;
using System;

namespace Algorithms.Test
{
    [TestClass]
    public class Task1Test
    {
        //2, 3, 5, 7, 11, 13, 17, 19, 23 - пример простых чисел
        [TestMethod]
        public void IsSimpleNumber_in10_outTrue()
        {
            //arrange
            bool expected = false;

            //actual            
            Task1 task = new Task1();
            bool actual = task.IsSimpleNumber(10);

            //assert
            Assert.AreEqual<bool>(expected, actual);
        }

        [TestMethod]
        public void IsSimpleNumber_in2_outTrue()
        {
            //arrange
            bool expected = true;

            //actual            
            Task1 task = new Task1();
            bool actual = task.IsSimpleNumber(2);

            //assert
            Assert.AreEqual<bool>(expected, actual);
        }

        [TestMethod]
        public void IsSimpleNumber_in3_outTrue()
        {
            //arrange
            bool expected = true;

            //actual            
            Task1 task = new Task1();
            bool actual = task.IsSimpleNumber(3);

            //assert
            Assert.AreEqual<bool>(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void IsSimpleNumber_in0_outException()
        {
            //arrange

            //actual            
            Task1 task = new Task1();
            bool actual = task.IsSimpleNumber(0);

            //assert            
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void IsSimpleNumber_inNegativeNumber_outException()
        {
            //arrange

            //actual            
            Task1 task = new Task1();
            bool actual = task.IsSimpleNumber(-2);

            //assert
        }
    }
}
