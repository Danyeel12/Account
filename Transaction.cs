using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_04_Account
{
    public class Transaction
    {
        public string AccountNumber { get; }
        public double Amount { get; }
        public Person Originator { get; }
        public DayTime Time { get; }
        public Transaction(string accountNumber, double amount, Person person)
        {
            AccountNumber = accountNumber;
            Amount = amount;
            Originator= person;
            Time = Utils.Time;
        }
        public override string ToString()
        {
            return $"{AccountNumber} {Math.Abs(Amount):C2} {(Amount > 0 ? "deposited" : "withdrawn")} by {Originator.Name} on {Time}";
        }
    }
}
