using System;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using ClientCenter.DB;
using ClientCenter.Event;
using ClientCenter.Enity;
using ClientCenter.Core;

namespace MemberManager.UI
{
    public partial class MemberOperationForm : DevExpress.XtraEditors.XtraForm
    {
        public MemberOperationForm()
        {
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            this.Load += MemberOperationForm_Load;
            this.btnAdd.Click += BtnAdd_Click;
            this.btnCancel.Click += BtnCancel_Click;
        }

        private bool CheckParam()
        {
            return ( !this.textMName.Text.Equals("") && !this.textBalance.Text.Equals(""));
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (CheckParam())
            {
                //添加会员
                List<object> infoList = new List<object>() { this.textMId.Text, this.textMName.Text, this.comCardLevel.Text, this.textPhone.Text, this.comStatus.Text, Convert.ToDouble(this.textBalance.Text), 1 };
                if (ProcedureDao.MemberRegister(infoList) > 0)
                {
                    XtraMessageBox.Show("添加会员成功!", "提示");
                    EventBus.PublishEvent("AddMemberSuccess");
                    EventBus.PublishEvent("MemberRechargeSuccess");
                }
                else
                {
                    XtraMessageBox.Show("添加会员失败!", "提示");
                }
            }
            else
            {
                XtraMessageBox.Show("信息不完整请检查", "提示");
            }
        }

        private void MemberOperationForm_Load(object sender, EventArgs e)
        {
            FillMemberLevel();
            FillMemberSataus();
           this.textMId.Text = GenrateIDUtil.GenerateMemberID();
        }

        private void FillMemberLevel()
        {
            List<CardVo> cardDaoList = SelectDao.SelectData<CardVo>();
            foreach(CardVo vo in cardDaoList)
            {
                this.comCardLevel.Properties.Items.Add(vo.CardName);
            }
        }

        private void FillMemberSataus()
        {
            this.comStatus.Properties.Items.AddRange(new string[] { "正常","停止","挂失"});
        }
    }
}