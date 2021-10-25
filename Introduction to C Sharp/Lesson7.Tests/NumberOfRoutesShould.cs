using NUnit.Framework;
using System;

namespace Lesson7.Tests
{
    [TestFixture]
    class NumberOfRoutesShould
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CountingNumberOfRoutes_5x5_return70()
        {
            // Arrange
            int expected = 70;
            NumberOfRoutes routes = new NumberOfRoutes();

            // Act
            int actual = routes.CountingNumberOfRoutes();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountingNumberOfRoutes_2x2_return2()
        {
            // Arrange
            int expected = 2;
            NumberOfRoutes routes = new NumberOfRoutes();

            // Act
            int actual = routes.CountingNumberOfRoutes(numberOfRows: 2, numberOfColumns: 2);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountingNumberOfRoutes_1x1_return0()
        {
            // Arrange
            int expected = 0;
            NumberOfRoutes routes = new NumberOfRoutes();

            // Act
            int actual = routes.CountingNumberOfRoutes(numberOfRows: 1, numberOfColumns: 1);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountingNumberOfRoutes_1x1_returnNot1()
        {
            // Arrange
            int expected = 1;
            NumberOfRoutes routes = new NumberOfRoutes();

            // Act
            int actual = routes.CountingNumberOfRoutes(numberOfRows: 1, numberOfColumns: 1);

            // Assert
            Assert.AreNotEqual(expected, actual);
        }

        [Test]
        public void CountingNumberOfRoutes_0x0_Exception()
        {
            // Arrange
            NumberOfRoutes routes = new NumberOfRoutes();
            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => routes.CountingNumberOfRoutes(numberOfRows: 1, numberOfColumns: 0));
        }

        [Test]
        public void CalculationPathsWithObstacles()
        {
            // Arrange
            int expected = 35;
            NumberOfRoutes routes = new NumberOfRoutes();
            int[,] mapOfObstacles = new int[,] {
                { 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1 },
                { 1, 1, 1, 0, 1 }};

            // Act
            int actual = routes.CountingNumberOfRoutesWithObstacles(mapOfObstacles);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
