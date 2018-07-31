using ClientCenter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientCenter.GridViews;

namespace StaffManager.Enity
{
    [DataAttr("ServerSkillShip")]
    public class ServerSkillVo
    {
        private int shipId;
        [ColumnAttr("ID", false)]
        public int ShipId
        {
            get { return shipId; }
            set { shipId = value; }
        }
        private int serverId;
        [ColumnAttr("服务ID", false)]
        [DataAttr(true)]
        public int ServerId
        {
            get { return serverId; }
            set { serverId = value; }
        }
        private string serverName;
        [ColumnAttr("服务名字", true)]
        public string ServerName
        {
            get { return serverName; }
            set { serverName = value; }
        }
        private int skillId;
        [DataAttr(true)]
        public int SkillId
        {
            get { return skillId; }
            set { skillId = value; }
        }
        private string skillName;
        [ColumnAttr("包含项目", true)]
        public string SkillName
        {
            get { return skillName; }
            set { skillName = value; }
        }
    }
}
