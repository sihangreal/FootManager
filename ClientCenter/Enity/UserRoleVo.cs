using ClientCenter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCenter.Enity
{
    [DataAttr("userRole")]
    public class UserRoleVo
    {
        private int id;
        [ColumnAttr("用户编号", true)]
        [DataAttr(false,true)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name;
        [ColumnAttr("用户姓名", true)]
        [DataAttr(true)]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string role;
        [ColumnAttr("所属权限组", true)]
        [DataAttr(true)]
        public string Role
        {
            get { return role; }
            set { role = value; }
        }
        private string psword;
        [ColumnAttr("用户密码", true)]
        [DataAttr(true)]
        public string Psword
        {
            get { return psword; }
            set { psword = value; }
        }
    }
}
