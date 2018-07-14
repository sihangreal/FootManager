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
        private MemberOperationForm operationFrm;

        private MemberGrid memberConsume; //会员消费
        private MemberGrid memberRecharge;//会员充值

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
            this.navigationPage1.CustomButtonClick += NavigationPage1_CustomButtonClick;
        }

        private void NavigationPage1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            if (e.Button.Properties.Caption=="添加")
            {
                if (operationFrm == null)
                {
                    operationFrm = new MemberOperationForm();
                }
                operationFrm.ShowDialog();
            }
        }
        private void MemberMainNew_Load(object sender, EventArgs e)
        {
            memberInfoUI = new MemberInfoUI();
            memberInfoUI.Dock = DockStyle.Fill;
            this.navigationPage1.Controls.Add(memberInfoUI);

            memberConsume = new MemberGrid(typeof(MemberConsumeVo), "会员消费记录");
            memberRecharge = new MemberGrid(typeof(MemberRechargeVo), "会员充值记录");
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

            FillRecharge();
            FillConsume();
        }

        private void FillRecharge()
        {
            List<MemberRechargeVo> voList = SelectDao.SelectData<MemberRechargeVo >();
            memberRecharge.SetData<MemberRechargeVo>(voList);
        }

        private void FillConsume()
        {
            List<MemberConsumeVo> voList = SelectDao.SelectData<MemberConsumeVo>();
            memberConsume.SetData<MemberConsumeVo>(voList);
        }

        [EventAttr("MemberRechargeSuccess")]
        public void MemberRechargeSuccess()
        {
            FillRecharge();
        }
    }
}
