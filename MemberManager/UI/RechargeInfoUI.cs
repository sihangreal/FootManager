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
using ClientCenter.Event;

namespace MemberManager.UI
{
    public partial class RechargeInfoUI : BaseInfoUI
    {
        List<MemberRechargeVo> rechargeVoList = new List<MemberRechargeVo>();
        public RechargeInfoUI()
        {
            EventBus.RegisterEvent(this);
            InitializeComponent();
            GridViewUtil.CreateColumnForData(this.gridView1,typeof(MemberRechargeVo));
            RefreshRecharge();
        }
        private void RefreshRecharge()
        {
            rechargeVoList = SelectDao.SelectData<MemberRechargeVo>();
            this.gridControl1.DataSource = rechargeVoList;
            this.gridControl1.RefreshDataSource();
        }
        protected override void BtnReadCard_Click(object sender, EventArgs e)
        {
            string errorStr = default(string);
            string memberId = D3Core.ReadMemberCard(out errorStr);
            if (memberId != null)
                this.textCard.Text = memberId;
            else
                XtraMessageBox.Show(errorStr);
        }

        protected override void BtnLook_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(this.textCard.Text))
            {
                rechargeVoList = SelectDao.SelectMemberRechargeByName<MemberRechargeVo>(this.textName.Text);
            }
            else
            {
                rechargeVoList = SelectDao.SelectMemberRechargeByID<MemberRechargeVo>(this.textCard.Text);
            }
            this.gridControl1.DataSource = rechargeVoList;
            this.gridControl1.RefreshDataSource();
        }
        [EventAttr("MemberRechargeSuccess")]
        public void MemberRechargeSuccess()
        {
            RefreshRecharge();
        }
    }
}
