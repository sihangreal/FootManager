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
            GridViewUtil.CreateColumnForData(this.gridView1, typeof(TempOrderVo));
            this.gridControl1.DataSource = tempVoList;
            FillPriceType();
        }
        private void InitEvents()
        {
            this.btnQuery.Click += BtnQuery_Click;
            this.btnReadCard.Click += BtnReadCard_Click;
            this.Load += CheckCashierForm_Load;
            this.gridView1.SelectionChanged += GridView1_SelectionChanged;
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

        private List<DetailedOrderVo> RelationDetailedOrder(string orderId)
        {
            List<DetailedOrderVo> detailedVoList = new List<DetailedOrderVo>();
            string priceType = this.comboType.Text;
            foreach (TempOrderVo vo in selectedVoList)
            {
                DetailedOrderVo detVo = new DetailedOrderVo();
                detVo.DetailID = GenrateIDUtil.GenerateDetailOrderID();
                detVo.OrderID = orderId;
                detVo.SkillId = vo.SkillId;
                //detVo.Price = SelectDao.GetSkillPriceDetail(vo.SkillName, vo.WorkType, priceType);
                double gstPrice = (detVo.Price * 6) / 106;
                detVo.Tax = Math.Round(gstPrice, 2, MidpointRounding.AwayFromZero);
                detVo.TotalPrice = detVo.Price + detVo.Tax;
                detailedVoList.Add(detVo);
            }
            return detailedVoList;
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

        }
    }
}
