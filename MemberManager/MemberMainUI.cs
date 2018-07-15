using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MemberManager.UI;
using ClientCenter.DB;
using ClientCenter.Event;
using ClientCenter.Enity;

namespace MemberManager
{
    public partial class MemberMainUI : DevExpress.XtraEditors.XtraUserControl
    {
        private MemberInfoUI memberInfoUI;
        //private MemberOperationForm operationFrm;

        private ConsumeInfoUI memberConsume;//会员消费
        private RechargeInfoUI memberRecharge;//会员充值

        private MemberRecharge memberRechargeQuery;//会员充值与查询
        private CradOperiation cardOperiation;//会员卡设置

        public MemberMainUI()
        {
            EventBus.RegisterEvent(this);
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            this.Load += MemberMainNew_Load;
        }

        private void MemberMainNew_Load(object sender, EventArgs e)
        {
            memberInfoUI = new MemberInfoUI();
            memberInfoUI.Dock = DockStyle.Fill;
            this.navigationPage1.Controls.Add(memberInfoUI);

            memberConsume = new ConsumeInfoUI();
            memberRecharge = new RechargeInfoUI();
            this.navigationPage2.Controls.Add(memberConsume);
            memberConsume.Dock = DockStyle.Fill;
            this.navigationPage3.Controls.Add(memberRecharge);
            memberRecharge.Dock = DockStyle.Fill;


            memberRechargeQuery = new MemberRecharge();
            memberRechargeQuery.Dock = DockStyle.Fill;
            this.navigationPage4.Controls.Add(memberRechargeQuery);

            cardOperiation = new CradOperiation();
            cardOperiation.Dock = DockStyle.Fill;
            this.navigationPage5.Controls.Add(cardOperiation);

            this.navigationPane1.SelectedPage = this.navigationPage1;
        }
    }
}
