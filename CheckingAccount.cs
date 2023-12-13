using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_04_Account
{
    public class CheckingAccount:Account, ITransaction
    {
        static private double COST_PER_TRANSACTION = 0.05;
        static private double INTEREST_RATE = 0.005;
        private bool HasOverdraft;
        public CheckingAccount(double balance = 0, bool hasOverdraft = false) : base($"{Utils.ACCOUNT_TYPE[AccountType.Checking]}-",balance)
        {
            HasOverdraft= hasOverdraft;
        }
        public new void Deposit(double amount, Person person)
        {
            base.Deposit(amount, person);
            base.OnTransactionOccur(this, new TransactionEventArgs(person.Name, amount, true));
        }
        public void Withdraw(double amount, Person person)
        {
            if (!IsUser(person.Name))
            {
                base.OnTransactionOccur(this, new TransactionEventArgs(person.Name, -amount, false));
                throw new AccountException(ExceptionType.NAME_NOT_ASSOCIATED_WITH_ACCOUNT);
            }
            if (!person.IsAuthenticated)
            {
                base.OnTransactionOccur(this, new TransactionEventArgs(person.Name, -amount, false));
                throw new AccountException(ExceptionType.USER_NOT_LOGGED_IN);
            }
            if(HasOverdraft = false && amount > Balance)
            {
                base.OnTransactionOccur(this, new TransactionEventArgs(person.Name, -amount, true));
                throw new AccountException(ExceptionType.NO_OVERDRAFT);
            }

                base.OnTransactionOccur(this, new TransactionEventArgs(person.Name, -amount, true));
                base.Deposit(-amount, person);



        }
        public override void PrepareMonthlyReport()
        {
            int numberOfTransaction = transactions.Count;
            double serviceCharge = numberOfTransaction * COST_PER_TRANSACTION;
            double interest = LowestBalance * INTEREST_RATE/12;
            Balance = Balance - serviceCharge + interest;
            transactions.Clear();
        }
    }
}
