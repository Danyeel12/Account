using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_04_Account
{
    public static class Utils
    {
        static private DayTime _time = new DayTime(1_048_000_000);
        static private Random random = new Random();
        static readonly public Dictionary<AccountType, string> ACCOUNT_TYPE = new Dictionary<AccountType, string> {
            { AccountType.Checking , "CK" },
            { AccountType.Saving , "SV" },
            { AccountType.Visa , "VS" }};
        
        public static DayTime Time { get { return _time += random.Next(1000); } }
        public static DayTime Now { get { return _time += 0; } }

    }
}
