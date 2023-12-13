using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_04_Account
{
    public class VisaAccount:Account,ITransaction
    {
        private double CreditLimit;
        private static double INTEREST_RATE = 0.1995;
        public VisaAccount(double balance = 0, double creditLimit = 1200) : base($"{Utils.ACCOUNT_TYPE[AccountType.Visa]}-", balance)
        {
            CreditLimit = creditLimit;
        }
        public void Pay(double amount, Person person)
        {
            base.Deposit(amount, person);
            base.OnTransactionOccur(this, new TransactionEventArgs(person.Name, amount, true));
        }
        public void Purchase(double amount, Person person)
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
            if (amount > Balance)
            {
                base.OnTransactionOccur(this, new TransactionEventArgs(person.Name, -amount, false));
                throw new AccountException(ExceptionType.CREDIT_LIMIT_HAS_BEEN_EXCEEDED);
            }

                base.OnTransactionOccur(this, new TransactionEventArgs(person.Name, -amount, true));
                base.Deposit(-amount, person);

        }
        public void Withdraw(double amount, Person person)
        {

        }
            public override void PrepareMonthlyReport()
        {
            double interest = LowestBalance * INTEREST_RATE / 12;
            Balance -= interest;
            transactions.Clear();
        }
        

    }
}
