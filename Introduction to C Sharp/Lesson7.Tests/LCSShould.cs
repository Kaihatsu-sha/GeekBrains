using NUnit.Framework;

namespace Lesson7.Tests
{
    [TestFixture]
    class LCSShould
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Length()
        {
            // Arrange
            int expected = 4;
            string a = "ACFSYGOS";
            string b = "FSYG";

            // Act
            var actual = new LCS().GetLength(a, b);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
