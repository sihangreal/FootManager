using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCenter.Core
{
    public class TimeUtil
    {
        public static DateTime AddMinute(DateTime time,string strMinute)
        {
            DateTime newTime = new DateTime();
              switch (strMinute)
            {
                case "30分钟":
                    newTime = time.AddMinutes(30);break;
                case "60分钟":
                    newTime = time.AddMinutes(60); break;
                case "90分钟":
                    newTime = time.AddMinutes(90); break;
                case "120分钟":
                    newTime = time.AddMinutes(120); break;
                case "150分钟":
                    newTime = time.AddMinutes(150); break;
                case "180分钟":
                    newTime = time.AddMinutes(180); break;
            }
            return newTime;
        }

        public static TimeSpan GetTimeSpan(DateTime time)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0, 0));
            long ltime= (long)(time - startTime).TotalSeconds;
            return new TimeSpan(ltime);
        }
    }
}
