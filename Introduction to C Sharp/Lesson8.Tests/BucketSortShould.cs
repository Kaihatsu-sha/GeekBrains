using NUnit.Framework;
using System;

namespace Lesson8.Tests
{
    public class BucketSortShould
    {
        int[] _massiv;
        [SetUp]
        public void Setup()
        {
            _massiv = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
        }

        [Test]
        public void Sort_10Item()
        {
            // Arrange
            int[] expected = new int[] { 1,2,3,4,5,6,7,8,9,10 };
            // Act
            new BucketSort().Sort( _massiv);
            int[] actual = _massiv;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Sort_numberBuckets0_exeption()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => new BucketSort(0));
        }

        [Test]
        public void Sort_10Item_numberBucket_1()
        {
            // Arrange
            int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            // Act
            new BucketSort(1).Sort(_massiv);
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
            Assert.Throws<ArgumentNullException>(() => new BucketSort().Sort(null));
        }

        [Test]
        public void Sort_returnExecptionArrayLen0()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => new BucketSort().Sort(new int[0]));
        }
        
        [Test]
        public void Sort_10Item_numberBucket_4()
        {
            // Arrange
            int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            // Act
            new BucketSort(4).Sort(_massiv);
            int[] actual = _massiv;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Sort_10Item_numberBucket_10()
        {
            // Arrange
            int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            // Act
            new BucketSort(4).Sort(_massiv);
            int[] actual = _massiv;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}