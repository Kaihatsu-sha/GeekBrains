using NUnit.Framework;
using System;

namespace Lesson7.Tests
{
    [TestFixture]
    public class NumberOfVariantsShould
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CountingOfVariants_16_out36()
        {
            // Arrange
            int expected = 36;

            // Act
            var actual = new NumberOfVariants().CountingOfVariants(16);

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void CountingOfVariants_4_out9()
        {
            // Arrange
            int expected = 4;

            // Act
            var actual = new NumberOfVariants().CountingOfVariants(4);

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void CountingOfVariants_1_out1()
        {
            // Arrange
            int expected = 1;

            // Act
            var actual = new NumberOfVariants().CountingOfVariants(1);

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void CountingOfVariants_1_out2()
        {
            // Arrange
            int expected = 2;

            // Act
            var actual = new NumberOfVariants().CountingOfVariants(1);

            // Assert
            Assert.AreNotEqual(expected, actual);
        }
        [Test]
        public void CountingOfVariants_0_Exception()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => new NumberOfVariants().CountingOfVariants(0));
        }
    }
}