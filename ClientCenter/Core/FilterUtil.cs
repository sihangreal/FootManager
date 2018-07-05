using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCenter.Core
{
    public class FilterUtil
    {
        public static bool isNumberic(string message)
        {
            System.Text.RegularExpressions.Regex rex = new System.Text.RegularExpressions.Regex(@"^\d+$");
            if (rex.IsMatch(message))
            {
                return true;
            }
            else
                return false;
        }
        public static bool isDouble(string message)
        {
            System.Text.RegularExpressions.Regex rex = new System.Text.RegularExpressions.Regex(@"^([01](\.0+)?|0\.[0-9]+)$");
            if (rex.IsMatch(message))
            {
                return true;
            }
            else
                return false;
        }
    }
}
