using ClientCenter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientCenter.GridViews;

namespace ClientCenter.Enity
{
    [DataAttr("CustomServer")]
    public class ServerVo
    {
        private string serverName;
        [ColumnAttr("服务名字", true)]
        [DataAttr(true)]
        public string ServerName
        {
            get { return serverName; }
            set { serverName = value; }
        }
        private int skillId;
        [ColumnAttr("项目ID", true)]
        [DataAttr(true)]
        public int SkillId
        {
            get { return skillId; }
            set { skillId = value; }
        }
        private string skillName;
        [ColumnAttr("项目名字", true)]
        [DataAttr(true)]
        public string SkillName
        {
            get { return skillName; }
            set { skillName = value; }
        }
    }
}
