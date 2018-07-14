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
       // private string orderId;//订单编号
        private string staffName;
        private string staffId;
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
            //orderId = SelectDao.GetOrderByRoomId(roomId);
            staffId = SelectDao.GetStaffIdByRoomId(roomId);
            staffName = SelectDao.GetStaffNameByRoomId(roomId);
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
            OrderInfoVo vo = SelectDao.GetOrderByRoomId<OrderInfoVo>(roomId);
            vo.Price = Convert.ToDouble(this.textPrice.Text);
            vo.Status = "完成";
            vo.PriceType = this.comboType.Text;
            vo.EndTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            StaffWorkInfoVo workInfoVo = UpdateWorkInfo();
            List<DetailedOrderVo> delOrderList = RelationDetailedOrder(vo.OrderID);
            if (TransactionDao.DealOrder(vo, workInfoVo, delOrderList))
            {
                //会员消费记录
                MemberConsumeVo consumeVo = new MemberConsumeVo();
                string consumeId = GenrateIDUtil.GenerateConsumeID();
                consumeVo.Id = consumeId;
                consumeVo.MId = this.textMemberId.Text;
                consumeVo.MName= SelectDao.GetMemberNameByID(this.textMemberId.Text);
                consumeVo.Amount = double.Parse(this.textTotal.Text);
                consumeVo.ConsumeTime = DateTime.Now;
                consumeVo.CompanyId = SystemConst.companyId;
                InsertDao.InsertData(consumeVo);
                //员工做工记录
                StaffWorkRecordVo recordVo = new StaffWorkRecordVo();
                recordVo.ID = GenrateIDUtil.GenerateWorkRecordID();
                recordVo.StaffId = staffId;
                recordVo.StaffName = SelectDao.SelectStaffNameByID(staffId);
                recordVo.OrderID = vo.OrderID;
                recordVo.Amount= double.Parse(this.textTotal.Text);
                recordVo.WorkTime = DateTime.Now;
                InsertDao.InsertData(recordVo);

                XtraMessageBox.Show("买单成功!");
            }
            else
            {
                XtraMessageBox.Show("买单失败!");
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
        private List<DetailedOrderVo> RelationDetailedOrder(string orderId)
        {
            List<DetailedOrderVo> detailedVoList = new List<DetailedOrderVo>();
            string priceType = this.comboType.Text;
            foreach (TempOrderVo vo in tempOrderList)
            {
                DetailedOrderVo detVo = new DetailedOrderVo();
                detVo.DetailID = GenrateIDUtil.GenerateDetailOrderID();
                detVo.OrderID = orderId;
                detVo.SkillId = vo.SkillId;
                detVo.Price = CalculationPrice(vo);
                detailedVoList.Add(detVo);
            }
            return detailedVoList;
        }

        private StaffWorkInfoVo UpdateWorkInfo()
        {
            StaffWorkInfoVo workVo = new StaffWorkInfoVo();
            workVo.StaffID = staffId;
            workVo.StaffName = staffName;
            workVo.StaffSex = SelectDao.GetStaffSexByID(staffId);
            workVo.StaffStatus = "空闲";
            workVo.RoomId = null;
            workVo.RoomName = "";
            return workVo;
        }
        #endregion
    }
}