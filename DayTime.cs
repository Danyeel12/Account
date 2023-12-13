using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_04_Account
{
    public struct DayTime
    {
        private long Minutes;
        public DayTime(long minutes)
        {
            Minutes = minutes;
        }
        public static DayTime operator +(DayTime lhs, int minutes)
        {
            return new DayTime(lhs.Minutes + minutes);
        }
        public override string ToString()
        {
            int year = Convert.ToInt32(Minutes) / 518_400;
            int month = (Convert.ToInt32(Minutes) - year * 518_400) / 43_200;
            int day = (Convert.ToInt32(Minutes) - year * 518_400 - month * 43_200) / 1_440;
            int hour = (Convert.ToInt32(Minutes) - year * 518_400 - month * 43_200 - day * 1_440) / 60;
            int minute = Convert.ToInt32(Minutes) - year * 518_400 - month * 43_200 - day * 1_440 - hour * 60;
            return $"{year:D2}-{month:D2}-{day:D2} {hour:D2}:{minute:D2}";
        }
    }

}
