using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{   
    /// <summary>
    /// Represents a single checking account
    /// </summary>
    public class Account
    {
        public double Balance { get; private set; }

        /// <summary>
        /// Deposits the amount in the bank account and returns the new balance
        /// </summary>
        /// <param name="amt">The amount to deposit</param>
        /// <returns></returns>
        public double Deposit(double amt)
        {
            if (amt <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(amt)} must be a positive value");
            }
            if (amt >= 10000)
            {
                throw new ArgumentOutOfRangeException($"{nameof(amt)} must be less than 10000");
            }
            Balance += amt;
            return Balance;
        }
        /// <summary>
        /// Gets the current balance
        /// </summary>
        public void Withdraw(double amt)
        {
            if (amt > Balance)
            {
                throw new ArgumentException("Insufficient funds");
            }
            if (amt < 0)
            {
                throw new ArgumentOutOfRangeException("Cannot withdaw a negative amount");
            }
            Balance -= amt;
        }
    }
}
