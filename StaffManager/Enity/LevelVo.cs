using ClientCenter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientCenter.GridViews;

namespace StaffManager.Enity
{
    [DataAttr("Level")]
    public class LevelVo
    {
        private string levelName;
        [ColumnAttr("级别名字",true)]
        [DataAttr(true)]
        public string LevelName
        {
            get { return levelName; }
            set { levelName = value; }
        }
        private string commmision;
        [ColumnAttr("提成",true)]
        [DataAttr(true)]
        public string CommmisionV
        {
            get { return commmision; }
            set { commmision = value; }
        }
    }
}
