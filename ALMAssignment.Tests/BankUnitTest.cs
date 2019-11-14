using ALMAssignment.WebUI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ALMAssignment.Tests
{
    [TestClass]
    public class BankUnitTest
    {
        [TestMethod]
        public void Deposit()
        {
            //Arrange
            decimal depositAmount = 20m;

            //Act
            var account = new Account();
            account.Deposit(depositAmount);
            var actualAmount = account.Balance;

            //Assert
            Assert.AreEqual(depositAmount, actualAmount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DepositNegative()
        {
            //Arrange
            decimal depositAmount = -20m;

            //Act
            var account = new Account();
            account.Deposit(depositAmount);
            var actualAmount = account.Balance;

            //Assert ArgumentOutOfRangeException
        }

        [TestMethod]
        public void Withdraw()
        {
            //Arrange
            decimal withdrawAmount = 20m;
            decimal expectedAmount = 5m;

            //Act
            var account = new Account();
            account.Balance = 25m;
            account.Withdraw(withdrawAmount);
            var actualAmount = account.Balance;

            //Assert
            Assert.AreEqual(expectedAmount, actualAmount);
        }

        [TestMethod]
        public void WithdrawAll()
        {
            //Arrange
            decimal withdrawAmount = 20m;
            decimal expectedAmount = 0m;

            //Act
            var account = new Account();
            account.Balance = 20m;
            account.Withdraw(withdrawAmount);
            var actualAmount = account.Balance;

            //Assert
            Assert.AreEqual(expectedAmount, actualAmount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WithdrawExceeded()
        {
            //Arrange
            decimal withdrawAmount = 20m;

            //Act
            var account = new Account();
            account.Balance = 19.99m;
            account.Withdraw(withdrawAmount);

            //Assert ArgumentOutOfRangeException
        }

        [TestMethod]
        public void Transfer()
        {
            //Arrange
            decimal transferAmount = 20.25m;
            var accountFrom = new Account();
            accountFrom.Balance = 1500.23m;
            var accountTo = new Account();
            accountTo.Balance = 1234.44m;
            //Act
            accountFrom.Transfer(transferAmount, accountFrom, accountTo);
            //Assert
            Assert.AreEqual(1500.23m-transferAmount, accountFrom.Balance);
            Assert.AreEqual(1234.44m+transferAmount, accountTo.Balance);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TransferTooMuchMoney()
        {
            //Arrange
            decimal transferAmount = 20000m;
            var accountFrom = new Account();
            accountFrom.Balance = 0;
            var accountTo = new Account();
            accountTo.Balance = 1000m;
            //Act
            accountFrom.Transfer(transferAmount, accountFrom, accountTo);
            //Assert ArgumentOutOfRangeException
        }

        //Arrange
        //Act
        //Assert
    }
}
