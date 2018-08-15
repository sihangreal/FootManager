using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ClientCenter.Enity;
using ClientCenter.DB;
using ClientCenter.Core;
using ClientCenter.Event;

namespace ClockRoomManager.UI
{
    public partial class PayOrderForm : DevExpress.XtraEditors.XtraForm
    {
        private List<TempOrderVo> tempOrderList;//单
        private int  roomId;

        public PayOrderForm(int roomId)
        {
            this.roomId = roomId;
            InitializeComponent();
            InitData();
            InitEvents();
        }
        private void InitEvents()
        {
            this.Load += PayOrderForm_Load;
            this.comboType.SelectedValueChanged += ComboType_SelectedValueChanged;
            this.btnReadCard.Click += BtnReadCard_Click;
            this.btnQuery.Click += BtnQuery_Click;
        }
        public void InitData()
        {
            tempOrderList = SelectDao.GetTempOrderByRoomID<TempOrderVo>(roomId);
        }
        private void FillComType()
        {
            this.comboType.Properties.Items.AddRange(new string[] { "现金", "Visa卡" });
            List<CardVo> cardList = SelectDao.SelectData<CardVo>();
            foreach (CardVo vo in cardList)
            {
                if (vo.DisCount > 0)
                    this.comboType.Properties.Items.Add(vo.CardName);
            }
            this.comboType.SelectedIndex = 0;
        }
        #region events
        private void PayOrderForm_Load(object sender, EventArgs e)
        {
            FillComType();
        }
        private void ComboType_SelectedValueChanged(object sender, EventArgs e)
        {
            double serverPrice=0;
            double gstPrice = 0;
            double totalPrice = 0;
            string priceType = this.comboType.Text;

            foreach (TempOrderVo vo in tempOrderList)
            {
                serverPrice +=SelectDao.GetSkillPriceDetail(vo.SkillName,vo.WorkType,priceType);
            }
            if(priceType.Equals("现金")||priceType.Equals("Visa卡"))
            {
                gstPrice=(serverPrice * 6) / 106;
            }
            gstPrice = Math.Round(gstPrice, 2,MidpointRounding.AwayFromZero);
            totalPrice = serverPrice + gstPrice;
            this.textPrice.Text = serverPrice.ToString();
            this.textGst.Text = gstPrice.ToString();
            this.textTotal.Text = totalPrice.ToString();
        }
        private void BtnReadCard_Click(object sender, EventArgs e)
        {
            string errorStr = default(string);
            string memberId=D3Core.ReadMemberCard(out errorStr);
            if (memberId != null)
                this.textMemberId.Text = memberId;
            else
                XtraMessageBox.Show(errorStr);
        }
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            OrderInfoVo vo = new OrderInfoVo();
            vo.OrderID = GenrateIDUtil.GenerateOrderID();
            vo.Price = Convert.ToDouble(this.textPrice.Text);
            vo.Tax = Convert.ToDouble(this.textGst.Text);
            vo.TotalPrice = Convert.ToDouble(this.textTotal.Text);
            vo.PriceType = this.comboType.Text;
            vo.EndTime = DateTime.Now;
            vo.CompanyId = SystemConst.companyId;
       
            if (TransactionDao.DealOrder(vo, tempOrderList, this.comboType.Text))
            {
                //删除临时订单
                DeleteDao.DeleteTempOrderByRoomId(roomId);
                //会员消费记录
                if(!string.IsNullOrWhiteSpace(this.textMemberId.Text))
                {
                    MemberConsumeVo consumeVo = new MemberConsumeVo();
                    string consumeId = GenrateIDUtil.GenerateConsumeID();
                    consumeVo.Id = consumeId;
                    consumeVo.MId = this.textMemberId.Text;
                    consumeVo.MName = SelectDao.GetMemberNameByID(this.textMemberId.Text);
                    consumeVo.Amount = double.Parse(this.textTotal.Text);
                    consumeVo.ConsumeTime = DateTime.Now;
                    consumeVo.CompanyId = SystemConst.companyId;
                    InsertDao.InsertData(consumeVo);
                }
                XtraMessageBox.Show("买单成功!");
                RoomVo updateVo = SelectDao.GetRoomByRoomId<RoomVo>(roomId);
                EventBus.PublishEvent("StaffWorkStatusChange");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                XtraMessageBox.Show("买单失败!");
            }
        }
        private double CalculationPrice(TempOrderVo vo)
        {
            string priceType = this.comboType.Text;
            double serverPrice = SelectDao.GetSkillPriceDetail(vo.SkillName, vo.WorkType, priceType);
            double gstPrice = 0;
            double totalPrice= 0;
            if (priceType.Equals("现金") || priceType.Equals("Visa卡"))
            {
                gstPrice = (serverPrice * 6) / 106;
            }
            gstPrice = Math.Round(gstPrice, 2, MidpointRounding.AwayFromZero);
            totalPrice = serverPrice + gstPrice;
            return totalPrice;
        }
        #endregion
    }
}