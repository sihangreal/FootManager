using ClientCenter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCenter.Enity
{
    [DataAttr("WorkType")]
    public class WorkTypeVo
    {
        [DataAttr(false,true)]
        [ColumnAttr("编号",false)]
        public int TypeId { get; set; }
        [DataAttr(true)]
        [ColumnAttr("类别",true)]
        public string TypeName { get; set; }
    }
}
