using ClientCenter.Core;
using ClientCenter.GridViews;

namespace ClientCenter.Enity
{
    [DataAttr("Skill")]
    public class SkillVo
    {
        private int skillId;
        [ColumnAttr("项目ID", false)]
        [DataAttr(false, true)]
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
        private string secondName;
        [ColumnAttr("项目别名", true)]
        [DataAttr(true)]
        public string SecondName
        {
            get { return secondName; }
            set { secondName = value; }
        }
        private string serverTime;
        [ColumnAttr("项目时长", true)]
        [DataAttr(true)]
        public string ServerTime
        {
            get { return serverTime; }
            set { serverTime = value; }
        }
        private string remark;
        [ColumnAttr("备注", true)]
        [DataAttr(true)]
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
    }
}
