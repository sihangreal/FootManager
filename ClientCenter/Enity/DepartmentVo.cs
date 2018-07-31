using ClientCenter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientCenter.GridViews;

namespace ClientCenter.Enity
{
    [DataAttr("department")]
    public class DepartmentVo
    {
        private int id;
        [ColumnAttr("部门编号", false)]
        [DataAttr(false,true)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string depName;
        [ColumnAttr("部门名称", true)]
        [DataAttr(true)]
        public string DepName
        {
            get { return depName; }
            set { depName = value; }
        }
        private string remark;
        [ColumnAttr("部门说明", true)]
        [DataAttr(true)]
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
    }
}
