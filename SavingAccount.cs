using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_04_Account
{
    class SavingAccount:Account,ITransaction
    {
        double COST_PER_TRANSACTION = 0.5;
        double INTEREST_RATE = 0.015;
        public SavingAccount(double balance = 0) : base($"{Utils.ACCOUNT_TYPE[AccountType.Saving]}-",balance)
        {
            
        }
        public void Deposit(double amount, Person person)
        {
            base.Deposit(amount, person);
            base.OnTransactionOccur(this, new TransactionEventArgs(person.Name, amount, true));
        }
        public void Withdraw(double amount, Person person)
        {
            if (!IsUser(person.Name))
            {
                base.OnTransactionOccur(this,new TransactionEventArgs(person.Name, -amount, false));
                throw new AccountException(ExceptionType.NAME_NOT_ASSOCIATED_WITH_ACCOUNT);
            }
            if(!person.IsAuthenticated)
            {
                base.OnTransactionOccur(this, new TransactionEventArgs(person.Name,-amount, false));
                throw new AccountException(ExceptionType.USER_NOT_LOGGED_IN);
            }
            if(amount > Balance)
            {
                base.OnTransactionOccur(this, new TransactionEventArgs(person.Name, -amount, false));
                throw new AccountException(ExceptionType.NO_OVERDRAFT);
            }

                base.OnTransactionOccur(this, new TransactionEventArgs(person.Name, -amount, true));
                base.Deposit(-amount, person);

        }
        public override void PrepareMonthlyReport()
        {
            int numberOfTransactions = transactions.Count;
            double serviceCharge = COST_PER_TRANSACTION * numberOfTransactions;
            double interest = LowestBalance * INTEREST_RATE/12;
            Balance = Balance - interest - serviceCharge;
            transactions.Clear();
        }
    }
}
