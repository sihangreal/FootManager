using ClientCenter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCenter.Enity
{
    [DataAttr("Company")]
    public class CompanyVo
    {
        private int companyId;
        [DataAttr(false,true)]
        public int CompanyId
        {
            get { return companyId; }
            set { companyId = value; }
        }
        private string name;
        [DataAttr(true)]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string manager;
        [DataAttr(true)]
        public string Manager
        {
            get { return manager; }
            set { manager = value; }
        }
        private string address;
        [DataAttr(true)]
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string remark;
        [DataAttr(true)]
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
    }
}
