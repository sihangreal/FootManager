using ClientCenter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCenter.Enity
{
    [DataAttr("Permission")]
    public class PermissionVo
    {
        private string name;
        [ColumnAttr("权限组名", true)]
        [DataAttr(true)]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string modeName;
        [ColumnAttr("包含模块", true)]
        [DataAttr(true)]
        public string ModeName
        {
            get { return modeName; }
            set { modeName = value; }
        }
    }
}
