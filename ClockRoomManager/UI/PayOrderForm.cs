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
        private int iType;//轮钟0，点钟1， 加钟2
        private string orderId;//订单编号
        private string staffName;
        private string staffId;
        private RoomVo roomVo;

        public PayOrderForm()
        {
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            this.Load += PayOrderForm_Load;
            this.comboType.SelectedValueChanged += ComboType_SelectedValueChanged;
            this.btnReadCard.Click += BtnReadCard_Click;
            this.btnQuery.Click += BtnQuery_Click;
        }
        public void SetData(List<TempOrderVo> tempOrderList, int iType,string orderId,string staffName,string staffId,RoomVo vo)
        {
            this.tempOrderList = tempOrderList;
            this.iType = iType;
            this.orderId = orderId;
            this.staffName = staffName;
            this.staffId = staffId;
            this.roomVo = vo;
        }

        private void FillComType()
        {
            this.comboType.Properties.Items.AddRange(new string[] { "现金", "Visa卡" });
            List<CardVo> cardList = new List<CardVo>();
            SelectDao.SelectData<CardVo>(ref cardList);
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
            foreach(TempOrderVo vo in tempOrderList)
            {
                serverPrice +=SelectDao.GetSkillPriceDetail(vo.SkillName,iType,priceType);
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
            vo.OrderID = orderId;
            vo.Price = Convert.ToDouble(this.textPrice.Text);
            vo.Status = "完成";
            vo.PriceType = this.comboType.Text;
            vo.EndTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            if(InsertDao.InsertData(vo, typeof(OrderInfoVo))>0)
            {
                //改变员工的工作状态
                UpdateWorkInfo();
                //改变房间的状态
                UpdataRoom();
                XtraMessageBox.Show("买单成功!");
            }
        }
        private double CalculationPrice(TempOrderVo vo)
        {
            string priceType = this.comboType.Text;
            double serverPrice = SelectDao.GetSkillPriceDetail(vo.SkillName, iType, priceType);
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
        private void RelationDetailedOrder()
        {
            List<DetailedOrderVo> detailedVoList = new List<DetailedOrderVo>();
            string priceType = this.comboType.Text;
            foreach (TempOrderVo vo in tempOrderList)
            {
                DetailedOrderVo detVo = new DetailedOrderVo();
                detVo.OrderID = orderId;
                detVo.SkillId = vo.SkillId;
                detVo.Price = CalculationPrice(vo);
                vo.StartTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                //string strTime = SelectDao.GetSkillTime(vo.SkillId);
                //vo.EndTime = TimeUtil.AddMinute(DateTime.Now, strTime).ToString("yyyy-MM-dd HH:mm");
                int id = Convert.ToInt32(InsertDao.InsertDataRetrunID(vo));
                if (id <= 0)
                {
                    XtraMessageBox.Show("下单失败！");
                    return;
                }
                else
                    vo.Id = id;
            }
        }

        private void UpdataRoom()
        {
            this.roomVo.RoomStatus = "空闲";
            UpdateDao.UpdateByID(this.roomVo);
        }

        private void UpdateWorkInfo()
        {
            StaffWorkInfoVo workVo = new StaffWorkInfoVo();
            workVo.StaffID = staffId;
            workVo.StaffName = staffName;
            workVo.StaffSex = SelectDao.GetStaffSexByID(staffId);
            workVo.StaffStatus = "工作中";
            workVo.RoomId = roomVo.RoomId;
            workVo.RoomName = roomVo.RoomName;
            if (UpdateDao.UpdateByID(workVo) > 0)
            {
                EventBus.PublishEvent("StaffWorkStatusChange");
            }
        }
        #endregion
    }
}