using ClientCenter.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientCenter.Core
{
    public class UserRight
    {
        private static UserRight instance;
        private static Dictionary<string, bool> rightDic = new Dictionary<string, bool>();
        public static Dictionary<string, bool> RightDic
        {
            get { return rightDic; }
            set { rightDic = value; }
        }

        private UserRight()
        {
            InitUserRight();
        }

        private void InitUserRight()
        {
            rightDic.Add("添加会员卡", false);
            rightDic.Add("删除会员卡", false);
            rightDic.Add("修改会员卡", false);

            rightDic.Add("添加权限组",false);
            rightDic.Add("删除权限组",false);
            rightDic.Add("修改权限组",false);

            rightDic.Add("添加用户",false);
            rightDic.Add("删除用户",false);
            rightDic.Add("修改用户",false);

            rightDic.Add("添加项目", false);
            rightDic.Add("删除项目",false);
            rightDic.Add("修改项目", false);

            rightDic.Add("添加服务", false);
            rightDic.Add("删除服务",false);
            rightDic.Add("修改服务", false);

            rightDic.Add("添加员工", false);
            rightDic.Add("删除员工",false);
            rightDic.Add("修改员工",false);

            rightDic.Add("添加员工级别",false);
            rightDic.Add("删除员工级别",false);
            rightDic.Add("修改员工级别",false);

            rightDic.Add("添加部门",false);
            rightDic.Add("删除部门",false);
            rightDic.Add("修改部门",false);

            rightDic.Add("添加班次", false);
            rightDic.Add("删除班次", false);
            rightDic.Add("修改班次", false);
        }

        public static UserRight GetInstance()
        {
            if (instance == null)
            {
                instance = new UserRight();
            }
            return instance;
        }

        public void GetUserRight(string userName)
        {
            DataTable dt = SelectDao.GetPermission(userName);
            foreach (DataRow dr in dt.Rows)
            {
                string mode = dr[0].ToString();
                if (RightDic.ContainsKey(mode))
                    RightDic[mode] = true;
            }
        }

        public void CheckControl(Control control)
        {
            foreach (string key in rightDic.Keys)
            {
                if (control.Tag == null)
                    break;
                if (control.Tag.ToString().Equals(key))
                    control.Enabled = rightDic[key];
            }
            foreach (Control ctr in control.Controls)
            {
                CheckControl(ctr);
            }
        }

    }
 }
