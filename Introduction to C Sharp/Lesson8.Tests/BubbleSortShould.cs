using NUnit.Framework;
using System;

namespace Lesson8.Tests
{
    public class BubbleSortShould
    {
        int[] _massiv;
        [SetUp]
        public void Setup()
        {
            _massiv = new int[] {10,9,8,7,6,5,4,3,2,1 };
        }

        [Test]
        public void Sort_10Item()
        {
            // Arrange
            int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            // Act
            new BubbleSort().Sort(_massiv);
            int[] actual = _massiv;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Sort_returnExecptionNULLArray()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => new BubbleSort().Sort(null));
        }

        [Test]
        public void Sort_returnExecptionArrayLen0()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => new BubbleSort().Sort(new int[0]));
        }

        [Test]
        public void Sort_4Item()
        {
            // Arrange
            int[] expected = new int[] { 1, 2, 3, 4};
            _massiv = new int[] { 4, 1, 2, 3 };
            // Act
            new BubbleSort().Sort(_massiv);
            int[] actual = _massiv;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Sort_13Item()
        {
            // Arrange
            int[] expected = new int[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            _massiv = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 11, 12 };
            // Act
            new BubbleSort().Sort(_massiv);
            int[] actual = _massiv;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}