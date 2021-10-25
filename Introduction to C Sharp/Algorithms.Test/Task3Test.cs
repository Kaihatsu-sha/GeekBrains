using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms;
using System;

namespace Algorithms.Test
{
    [TestClass]
    public class Task3Test
    {
        #region Recursion
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void FibonacciRecursion_inNegativeNumber_outException()
        {
            //arrange

            //actual            
            Task3 task = new Task3();
            int actual = task.FibonacciRecursion(-1);

            //assert
        }

        [TestMethod]
        public void FibonacciRecursion_in2_out1()
        {
            //arrange
            int expected = 1;

            //actual            
            Task3 task = new Task3();
            int actual = task.FibonacciRecursion(2);

            //assert
            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void FibonacciRecursion_in3_out2()
        {
            //arrange
            int expected = 2;

            //actual            
            Task3 task = new Task3();
            int actual = task.FibonacciRecursion(3);

            //assert
            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void FibonacciRecursion_in10_out55()
        {
            //arrange
            int expected = 55;

            //actual            
            Task3 task = new Task3();
            int actual = task.FibonacciRecursion(10);

            //assert
            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void FibonacciRecursion_in0_out0()
        {
            //arrange
            int expected = 0;

            //actual            
            Task3 task = new Task3();
            int actual = task.FibonacciRecursion(0);

            //assert
            Assert.AreEqual<int>(expected, actual);
        }
        #endregion

        #region Cycle
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void Fibonacci_inNegativeNumber_outException()
        {
            //arrange

            //actual            
            Task3 task = new Task3();
            int actual = task.Fibonacci(-1);

            //assert
        }

        [TestMethod]
        public void Fibonacci_in2_out1()
        {
            //arrange
            int expected = 1;

            //actual            
            Task3 task = new Task3();
            int actual = task.Fibonacci(2);

            //assert
            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void Fibonacci_in3_out2()
        {
            //arrange
            int expected = 2;

            //actual            
            Task3 task = new Task3();
            int actual = task.Fibonacci(3);

            //assert
            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void Fibonacci_in10_out55()
        {
            //arrange
            int expected = 55;

            //actual            
            Task3 task = new Task3();
            int actual = task.Fibonacci(10);

            //assert
            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void Fibonacci_in0_out0()
        {
            //arrange
            int expected = 0;

            //actual            
            Task3 task = new Task3();
            int actual = task.Fibonacci(0);

            //assert
            Assert.AreEqual<int>(expected, actual);
        }
        #endregion
    }
}
