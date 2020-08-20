using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Tests
{
    [TestClass()]
    public class AccountTests
    {
        private Account acc;

        [TestInitialize] // Run code before each test
        public void Initialize()
        {
            acc = new Account();
        }

        [TestMethod]
        [TestCategory("Deposit")]
        [DataRow(10_000)]
        [DataRow(16486.43)]
        [DataRow(double.MaxValue)]
        public void Deposit_TooLarge_ArgumentOutOfRangeException(double tooLargeDeposit)
        { 
            Assert.ThrowsException<ArgumentOutOfRangeException>( () => acc.Deposit(tooLargeDeposit) );
        }

        [TestMethod]
        [TestCategory("Deposit")]
        [DataRow(.01)]
        [DataRow(100)]
        [DataRow(9999.99)]
        public void Deposit_PostitiveAmount_AddsToBalance(double initialDeposit)
        {
            // AAA - Arrange Act Assert

            // Arange - Creating variables/object
            const double startBalance = 0;

            // Act - Execute method under test
            acc.Deposit(initialDeposit);

            // Assert - Check a condition
            Assert.AreEqual(startBalance + initialDeposit, acc.Balance);
        }

        [TestMethod]
        [TestCategory("Deposit")]
        public void Deposit_PositiveAmount_ReturnsUpdatedBalance()
        {
            // Arrange
            double initialBalance = 0;
            double depositAmount = 10.55;

            // Act
            double newBalance = acc.Deposit(depositAmount);

            // Assert
            double expectedBalance = initialBalance + depositAmount;
            Assert.AreEqual(expectedBalance, newBalance);
        }

        [TestMethod]
        [TestCategory("Deposit")]
        public void Deposit_MultipleAmounts_ReturnsAccumulatedBalance()
        {
            // Arrange
            double deposit1 = 10;
            double deposit2 = 25;
            double expectedBalance = deposit1 + deposit2;

            // Act
            acc.Deposit(deposit1);
            double finalBalance = acc.Deposit(deposit2);

            // Assert
            Assert.AreEqual(expectedBalance, finalBalance);
        }

        [TestMethod]
        [TestCategory("Deposit")]
        public void Deposit_NegativeAmount_ArgumentOutOfRangeException()
        {
            double negativeDeposit = -1;

            // Assert => Act
            Assert.ThrowsException<ArgumentOutOfRangeException>( ()=>acc.Deposit(negativeDeposit) );
        }

        [TestMethod]
        [TestCategory("Withdraw")]
        [DataRow(100, 50)]
        [DataRow(50, 50)]
        [DataRow(9.99, 9.99)]
        public void Withdraw_PositiveAmount_SubtractsFromBalance(double initialDeposit, double withdrawAmount)
        {
            double expectedBalance = initialDeposit - withdrawAmount;
            
            acc.Deposit(initialDeposit);
            acc.Withdraw(withdrawAmount);

            Assert.AreEqual(expectedBalance, acc.Balance);
        }

        [TestMethod]
        [TestCategory("Withdraw")]
        public void Withdraw_MoreThanBalance_ThrowsArgumentException()
        {   
            // double initialBalance = 0
            // An account created with the default constructor has a 0 balance
            Account myAccount = new Account();
            double withdrawAmount = 1000;

            Assert.ThrowsException<ArgumentException>(() => myAccount.Withdraw(withdrawAmount));
        }

        [TestMethod]
        [TestCategory("Withdraw")]
        [DataRow(-0.01)]
        [DataRow(-5946.45)]
        public void Withdraw_NegativeAmount_ThrowsArgumentException(double negativeWithdrawAmount)
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => acc.Withdraw(negativeWithdrawAmount));
        }
    }
}