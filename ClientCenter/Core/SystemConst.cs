using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCenter.Core
{
    public class SystemConst
    {
        public static int companyId=Convert.ToInt32(ConfigurationManager.AppSettings["CompanyId"]);
    }
}
