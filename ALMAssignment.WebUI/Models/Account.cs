using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALMAssignment.WebUI.Models
{
    public class Account
    {
        public int AccountID { get; set; }
        public decimal Balance { get; set; }
        public int CustomerID { get; set; }

        public void Deposit(decimal depositAmount)
        {
            if(depositAmount <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            Balance += depositAmount;
        }

        public void Withdraw(decimal withdrawAmount)
        {
            if (withdrawAmount <= 0 || (Balance - withdrawAmount) < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            Balance -= withdrawAmount;
        }

        public void Transfer(decimal transferAmount, Account accountFrom, Account accountTo)
        {
            if (transferAmount > 0 && accountFrom.Balance >= transferAmount)
            {
                accountFrom.Withdraw(transferAmount);
                accountTo.Deposit(transferAmount);
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
