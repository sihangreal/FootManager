using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientCenter.Core;

namespace MemberManager.Enity
{
    [DataAttr("card")]
    public class CardVo
    {
        private int cardId;
        [ColumnAttr("会员卡编号",true)]
        [DataAttr(false)]
        public int CardId
        {
            get { return cardId; }
            set { cardId = value; }
        }
        private string cardName;
        [ColumnAttr("会员卡级别", true)]
        [DataAttr(true)]
        public string CardName
        {
            get { return cardName; }
            set { cardName = value; }
        }
        private double disCount;
        [ColumnAttr("折扣",true)]
        [DataAttr(true)]
        public double DisCount
        {
            get { return disCount; }
            set { disCount = value; }
        }
    }
}
