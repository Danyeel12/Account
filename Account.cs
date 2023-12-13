using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_04_Account
{
    abstract public class Account
    {
        static private int LAST_NUMBER = 100_000;
        protected readonly List<Person> users;
        public readonly List<Transaction> transactions;
        public virtual event EventHandler<EventArgs> OnTransaction;
        public double Balance { get; protected set; }
        public double LowestBalance { get; protected set; }
        public string Number { get; }

        public Account(string type, double balance)
        {
            Number = type + LAST_NUMBER;
            LAST_NUMBER++;
            Balance = balance;
            LowestBalance = balance;
            transactions = new List<Transaction>();
            users = new List<Person>();
        }
        public void Deposit(double amount, Person person)
        {
            Balance += amount;
            if(amount < LowestBalance)
            {
                LowestBalance = Balance;
            }
            Transaction transaction = new Transaction(Number, amount, person);
            transactions.Add(transaction);
        }
        public void AddUser(Person person)
        {
            users.Add(person);
        }
        public bool IsUser(string name)
        {
            var r1 = from u in users where u.Name == name select u;
            return r1.Any();
        }
        public abstract void PrepareMonthlyReport();
        public virtual void OnTransactionOccur(object sender, EventArgs args)
        {
            OnTransaction.Invoke(sender, args);
        }
        public override string ToString()
        {
            string namesOfUser = "";
            string listofTransactions = "";
            foreach( Person names in users)
            {
                namesOfUser += names + ", ";
            }
            foreach(Transaction trans in transactions)
            {
                listofTransactions += trans + ", \n";

            }
            return $"{Number} {namesOfUser} {Balance:C2}, transaction: {transactions.Count()}\n{listofTransactions}";
        }

    }
}
