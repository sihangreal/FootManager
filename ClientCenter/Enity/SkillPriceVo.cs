using ClientCenter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientCenter.GridViews;

namespace ClientCenter.Enity
{
    [DataAttr("SkillPrice")]
    public class SkillPriceVo
    {
        private int id;
        [ColumnAttr("编号",true)]
        [DataAttr(false,true)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string skillName;
        [ColumnAttr("项目名字", true)]
        [DataAttr(true)]
        public string SkillName
        {
            get { return skillName; }
            set { skillName = value; }
        }
        private string priceType;
        [ColumnAttr("售价类别", true)]
        [DataAttr(true)]
        public string PriceType
        {
            get { return priceType; }
            set { priceType = value; }
        }
        private double priceA;
        [ColumnAttr("轮钟", true)]
        [DataAttr(true)]
        public double PriceA
        {
            get { return priceA; }
            set { priceA = value; }
        }
        private double priceB;
        [ColumnAttr("点钟", true)]
        [DataAttr(true)]
        public double PriceB
        {
            get { return priceB; }
            set { priceB = value; }
        }
        private double priceC;
        [ColumnAttr("加钟", true)]
        [DataAttr(true)]
        public double PriceC
        {
            get { return priceC; }
            set { priceC = value; }
        }
        private string remark;
        [ColumnAttr("备注", true)]
        [DataAttr(true)]
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        [DataAttr(true)]
        public int CompanyId { get; set; }
    }
}
