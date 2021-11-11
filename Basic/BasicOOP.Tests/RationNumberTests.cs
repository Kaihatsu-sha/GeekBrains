using System;
using Xunit;

namespace BasicOOP.Tests
{
    public class RationNumberTests
    {
        [Fact]
        public void CreateValid_ReturnsOk()
        {
            //Arrange
            RationNumber value = new RationNumber(10,2);
            //Assert
            Assert.NotNull(value);
        }

        [Fact]
        public void CreateNotValid_ReturnsError()
        {
            //Assert
            Assert.Throws<ArgumentException>(()=>new RationNumber(10, 0));
        }

        [Fact]
        public void Equals_ReturnsTrue()
        {
            //Arrange
            RationNumber valueA = new RationNumber(10, 2);
            RationNumber valueB = new RationNumber(10, 2);
            //Act
            bool result = valueA.Equals(valueB);
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Equals_ReturnsFalse()
        {
            //Arrange
            RationNumber valueA = new RationNumber(10, 2);
            RationNumber valueB = new RationNumber(11, 2);
            //Act
            bool result = valueA.Equals(valueB);
            //Assert
            Assert.False(result);
        }

        [Fact]
        public void N1D2PlusN1D2_ReturnsN2D2()
        {
            //Arrange
            RationNumber valueA = new RationNumber(1, 2);
            RationNumber valueB = new RationNumber(1, 2);
            //Act
            var result = valueA + valueB;
            //Assert
            Assert.Equal(expected: new RationNumber(2,2),result);
        }

        [Fact]
        public void N1D3PlusN1D4_ReturnsN7D12()
        {
            //Arrange
            RationNumber valueA = new RationNumber(1, 3);
            RationNumber valueB = new RationNumber(1, 4);
            //Act
            var result = valueA + valueB;
            //Assert
            Assert.Equal(expected: new RationNumber(7, 12), result);
        }

        [Fact]
        public void N1D2MinusN1D2_ReturnsN0D2()
        {
            //Arrange
            RationNumber valueA = new RationNumber(1, 2);
            RationNumber valueB = new RationNumber(1, 2);
            //Act
            var result = valueA - valueB;
            //Assert
            Assert.Equal(expected: new RationNumber(0, 2), result);
        }

        [Fact]
        public void N1D3MinusN1D4_ReturnsN1D12()
        {
            //Arrange
            RationNumber valueA = new RationNumber(1, 3);
            RationNumber valueB = new RationNumber(1, 4);
            //Act
            var result = valueA - valueB;
            //Assert
            Assert.Equal(expected: new RationNumber(1, 12), result);
        }

        [Fact]
        public void N1D2GreaterN1D3_ReturnsTrue()
        {
            //Arrange
            RationNumber valueA = new RationNumber(1, 2);
            RationNumber valueB = new RationNumber(1, 3);
            //Act
            bool result = valueA > valueB;
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void N1D3LessN1D2_ReturnsTrue()
        {
            //Arrange
            RationNumber valueA = new RationNumber(1, 3);
            RationNumber valueB = new RationNumber(1, 2);
            //Act
            bool result = valueA < valueB;
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void N1D2GreaterN1D2_ReturnsFalse()
        {
            //Arrange
            RationNumber valueA = new RationNumber(1, 2);
            RationNumber valueB = new RationNumber(1, 2);
            //Act
            bool result = valueA > valueB;
            //Assert
            Assert.False(result);
        }

        [Fact]
        public void N1D3LessN1D3_ReturnsFalse()
        {
            //Arrange
            RationNumber valueA = new RationNumber(1, 3);
            RationNumber valueB = new RationNumber(1, 3);
            //Act
            bool result = valueA < valueB;
            //Assert
            Assert.False(result);
        }

        [Fact]
        public void N1D2GreaterOrEqualN1D3_ReturnsTrue()
        {
            //Arrange
            RationNumber valueA = new RationNumber(1, 2);
            RationNumber valueB = new RationNumber(1, 3);
            //Act
            bool result = valueA >= valueB;
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void N1D3LessOrEqualN1D2_ReturnsTrue()
        {
            //Arrange
            RationNumber valueA = new RationNumber(1, 3);
            RationNumber valueB = new RationNumber(1, 2);
            //Act
            bool result = valueA <= valueB;
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void N1D2GreaterOrEqualN1D2_ReturnsTrue()
        {
            //Arrange
            RationNumber valueA = new RationNumber(1, 2);
            RationNumber valueB = new RationNumber(1, 2);
            //Act
            bool result = valueA >= valueB;
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void N1D3LessOrEqualN1D3_ReturnsTrue()
        {
            //Arrange
            RationNumber valueA = new RationNumber(1, 3);
            RationNumber valueB = new RationNumber(1, 3);
            //Act
            bool result = valueA <= valueB;
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void N1D2Increment_ReturnsN2D3()
        {
            //Arrange
            RationNumber valueA = new RationNumber(1, 2);
            //Act
            var result = valueA++;
            //Assert
            Assert.Equal(expected: new RationNumber(2,3), result);
        }

        [Fact]
        public void N2D3Decrement_ReturnsN1D2()
        {
            //Arrange
            RationNumber valueA = new RationNumber(2, 3);
            //Act
            var result = valueA--;
            //Assert
            Assert.Equal(expected: new RationNumber(1,2),result);
        }

        [Fact]
        public void N1D2MultiplicationN4D5_ReturnsN4D10()
        {
            //Arrange
            RationNumber valueA = new RationNumber(1, 2);
            RationNumber valueB = new RationNumber(4, 5);
            //Act
            var result = valueA *  valueB;
            //Assert
            Assert.Equal(expected: new RationNumber(4, 10), result);
        }

        [Fact] 
        public void N2D3DivisionN4D5_ReturnsN10D12()
        {
            //Arrange
            RationNumber valueA = new RationNumber(2, 3);
            RationNumber valueB = new RationNumber(4, 5);
            //Act
            var result = valueA / valueB;
            //Assert
            Assert.Equal(expected: new RationNumber(10, 12), result);
        }

        [Fact]
        public void N10D2DTakingRemainderN4D2_ReturnsN16D16()
        {
            //Arrange
            RationNumber valueA = new RationNumber(10, 2);
            RationNumber valueB = new RationNumber(4, 2);
            //Act
            var result = valueA % valueB;
            //Assert
            Assert.Equal(expected: new RationNumber(16, 16), result);
        }

        [Fact]
        public void N10D3ConvertToFloat_Returns33333()
        {
            //Arrange
            RationNumber valueA = new RationNumber(10, 3);
            //Act
            var result = (float)valueA;
            //Assert
            Assert.Equal(expected: (float)(10/3), result);
        }

        [Fact]
        public void N10D3ConvertToInt_Returns3()
        {
            //Arrange
            RationNumber valueA = new RationNumber(10, 3);
            //Act
            var result = (float)valueA;
            //Assert
            Assert.Equal(expected: (int)(10 / 3), result);
        }

        [Fact]
        public void _10ConvertToRationNumber_ReturnsN10D1()
        {;
            //Act
            var result = (RationNumber)10;
            //Assert
            Assert.Equal(expected: new RationNumber(10, 1), result);
        }
    }
}
