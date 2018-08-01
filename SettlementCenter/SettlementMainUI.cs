using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ClientCenter.Core;
using ClientCenter.Enity;
using ClientCenter.DB;
using ClientCenter.GridViews;
using ClientCenter.Event;

namespace SettlementCenter
{
    public partial class SettlementMainUI : DevExpress.XtraEditors.XtraUserControl
    {
        List<TempOrderVo> tempVoList = new List<TempOrderVo>();
        List<TempOrderVo> selectedVoList = new List<TempOrderVo>();
        bool bcheckAll;
        public SettlementMainUI()
        {
            InitializeComponent();
            Init();
            InitEvents();
        }
        private void Init()
        {
            GridViewUtil.InitGridView(this.gridView1, typeof(TempOrderVo));
            this.gridControl1.DataSource = tempVoList;
            FillPriceType();
        }
        private void InitEvents()
        {
            this.btnQuery.Click += BtnQuery_Click;
            this.btnReadCard.Click += BtnReadCard_Click;
            this.Load += CheckCashierForm_Load;
            this.gridView1.SelectionChanged += GridView1_SelectionChanged;
            this.comboType.SelectedIndexChanged += ComboType_SelectedIndexChanged;
        }

        private void FillPriceType()
        {
            List<CardVo> cardList = SelectDao.SelectData<CardVo>();
            foreach (CardVo vo in cardList)
            {
                //if (vo.DisCount > 0)
                this.comboType.Properties.Items.Add(vo.CardName);
            }
            if (cardList.Count > 0)
                this.comboType.SelectedIndex = 0;
        }


        private void CheckCashierForm_Load(object sender, EventArgs e)
        {
            tempVoList = SelectDao.SelectData<TempOrderVo>();
            this.gridView1.BestFitColumns();
            this.gridControl1.DataSource = tempVoList;
            this.gridControl1.RefreshDataSource();
        }

        private void GridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            TempOrderVo selectVo = (TempOrderVo)this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
            if (e.Action == CollectionChangeAction.Add)
                selectedVoList.Add(selectVo);
            else if (e.Action == CollectionChangeAction.Remove)
                selectedVoList.Remove(selectVo);
            else
            {
                if (!bcheckAll)
                {
                    bcheckAll = true;
                    foreach (TempOrderVo vo in tempVoList)
                    {
                        selectedVoList.Add(vo);
                    }
                }
                else
                {
                    bcheckAll = false;
                    foreach (TempOrderVo vo in tempVoList)
                    {
                        selectedVoList.Remove(vo);
                    }
                }
            }
        }

        private void ComboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            double serverPrice = 0;
            double gstPrice = 0;
            double totalPrice = 0;
            string priceType = this.comboType.Text;

            foreach (TempOrderVo vo in selectedVoList)
            {
                serverPrice += SelectDao.GetSkillPriceDetail(vo.SkillName, vo.WorkType, priceType);
            }
            if (priceType.Equals("现金") || priceType.Equals("Visa卡"))
            {
                gstPrice = (serverPrice * 6) / 106;
            }
            gstPrice = Math.Round(gstPrice, 2, MidpointRounding.AwayFromZero);
            totalPrice = serverPrice + gstPrice;
            this.textPrice.Text = serverPrice.ToString();
            this.textGst.Text = gstPrice.ToString();
            this.textTotal.Text = totalPrice.ToString();
        }

        private void BtnReadCard_Click(object sender, EventArgs e)
        {
            string errorStr = default(string);
            string memberId = D3Core.ReadMemberCard(out errorStr);
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
            vo.Tax = Convert.ToDouble(this.textTotal.Text);
            vo.TotalPrice = Convert.ToDouble(this.textTotal.Text);
            vo.PriceType = this.comboType.Text;
            vo.EndTime = DateTime.Now;
            if (TransactionDao.DealOrder(vo, selectedVoList, this.comboType.Text))
            {
                //删除临时订单
                foreach(TempOrderVo tempVo in selectedVoList)
                {
                    DeleteDao.DeleteByID(tempVo.Id,typeof(TempOrderVo));
                }
                //会员消费记录
                if (!string.IsNullOrWhiteSpace(this.textMemberId.Text))
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
                EventBus.PublishEvent("StaffWorkStatusChange");
            }
            else
            {
                XtraMessageBox.Show("买单失败!");
            }
        }
    }
}
