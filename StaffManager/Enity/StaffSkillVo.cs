using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientCenter.Core;
using ClientCenter.GridViews;

namespace StaffManager.Enity
{
    public class StaffSkillVo
    {
        private string staffName;
        [ColumnAttr("员工姓名", true)]
        public string StaffName
        {
            get { return staffName; }
            set { staffName = value; }
        }
        private string skillName;
        [ColumnAttr("员工技能",true)]
        public string SkillName
        {
            get { return skillName; }
            set { skillName = value; }
        }
    }
}
