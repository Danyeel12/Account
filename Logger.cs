using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_04_Account
{
    public class Logger
    {
        static private List<string> loginEvents = new List<string>();
        static private List<string> transactionEvents = new List<string>();
        public static void LoginHanler(object sender, EventArgs args)
        {
            LoginEventArgs Args = args as LoginEventArgs;
            string list = $"{Args.PersonName} log in {(Args.Success?"successfully" : "unsuccessfully")} on {Utils.Now}";
            loginEvents.Add(list);
        }
        public static void TransactionHandler(object sender, EventArgs args)
        {
            TransactionEventArgs Args = args as TransactionEventArgs;
            string list = $"{Args.PersonName} {Math.Abs(Args.Amount):C2} {(Args.Amount > 0 ? "deposit" : "witdrawn")} {(Args.Success ? "successfully" : "unsuccessfully")} {Utils.Now}";
            transactionEvents.Add(list);
        }
        public static void ShowLoginEvents()
        {
            Console.WriteLine(Utils.Now.ToString());

            foreach(string items in loginEvents)
            {
                Console.WriteLine(items);
            }
        }
        public static void ShowTransactionEvents()
        {
            Console.WriteLine(Utils.Now.ToString());

            foreach(string item in transactionEvents)
            {
                Console.WriteLine(item);
            }
        }
    }
}
