using System;
using Xunit;


namespace BasicOOP.Tests
{
    public class AccountTests
    {
        [Fact]
        public void OperatorEquals_ReturnsFalse()
        {
            //Arrange
            Account accountA = new Account(100,AccountTypeEnum.Credit);
            Account accountB = new Account(100, AccountTypeEnum.Credit);
            //Act
            bool result = accountA == accountB;
            //Assert
            Assert.False(result);
        }

        [Fact]
        public void OperatorEquals_ReturnsTrue()
        {
            //Arrange
            Account accountA = new Account(100, AccountTypeEnum.Credit);
            Account accountB = accountA;
            //Act
            bool result = accountA == accountB;
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void OperatorEquals_Nulls_ReturnsTrue()
        {
            //Arrange
            Account accountA = null;
            Account accountB = null;
            //Act
            bool result = accountA == accountB;
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void OperatorEquals_NullAndNotNull_ReturnsExecption()
        {
            //Arrange
            Account accountA = null;
            Account accountB = new Account(100, AccountTypeEnum.Credit);
            //Act
            //bool result = accountA == accountB;
            //Assert
            Assert.Throws<NullReferenceException>(() => accountA == accountB);            
        }

        [Fact]
        public void OperatorEquals_NotNullAndNull_ReturnsFalse()
        {
            //Arrange
            Account accountA = new Account(100, AccountTypeEnum.Credit);
            Account accountB = null;
            //Act
            bool result = accountA == accountB;
            //Assert
            Assert.False(result);
        }

        [Fact]
        public void OperatorNotEquals_ReturnsTrue()
        {
            //Arrange
            Account accountA = new Account(100, AccountTypeEnum.Credit);
            Account accountB = new Account(100, AccountTypeEnum.Credit);
            //Act
            bool result = accountA != accountB;
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void OperatorNotEquals_ReturnsFalse()
        {
            //Arrange
            Account accountA = new Account(100, AccountTypeEnum.Credit);
            Account accountB = accountA;
            //Act
            bool result = accountA != accountB;
            //Assert
            Assert.False(result);
        }

        [Fact]
        public void OperatorNotEquals_Nulls_ReturnsFalse()
        {
            //Arrange
            Account accountA = null;
            Account accountB = null;
            //Act
            bool result = accountA != accountB;
            //Assert
            Assert.False(result);
        }

        [Fact]
        public void OperatorNotEquals_NullAndNotNull_ReturnsExecption()
        {
            //Arrange
            Account accountA = null;
            Account accountB = new Account(100, AccountTypeEnum.Credit);
            //Act
            //bool result = accountA == accountB;
            //Assert
            Assert.Throws<NullReferenceException>(() => accountA != accountB);
        }

        [Fact]
        public void OperatorNotEquals_NotNullAndNull_ReturnsTrue()
        {
            //Arrange
            Account accountA = new Account(100, AccountTypeEnum.Credit);
            Account accountB = null;
            //Act
            bool result = accountA != accountB;
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Equal_NotNull_ReturnsTrue()
        {
            //Arrange
            Account accountA = new Account(100, AccountTypeEnum.Credit);
            Account accountB = accountA;
            //Act
            bool result = accountA.Equals(accountB);
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Equal_NotNull_ReturnsFalse()
        {
            //Arrange
            Account accountA = new Account(100, AccountTypeEnum.Credit);
            Account accountB = new Account(100, AccountTypeEnum.Credit);
            //Act
            bool result = accountA.Equals(accountB);
            //Assert
            Assert.False(result);
        }

        [Fact]
        public void Equal_Null_ReturnsFalse()
        {
            //Arrange
            Account accountA = new Account(100, AccountTypeEnum.Credit);
            Account accountB = null;
            //Act
            bool result = accountA.Equals(accountB);
            //Assert
            Assert.False(result);
        }

        [Fact]
        public void Equal_Null_ReturnsExceptions()
        {
            //Arrange
            Account accountA = null;
            Account accountB = new Account(100, AccountTypeEnum.Credit);
            //Act
            //bool result = accountA.Equals(accountB);
            //Assert
            Assert.Throws<NullReferenceException>(() => accountA.Equals(accountB));
        }
    }
}
