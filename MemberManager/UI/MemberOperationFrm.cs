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
using ClientCenter.DB;
using ClientCenter.Event;
using ClientCenter.Core;
using ClientCenter.Enity;

namespace MemberManager.UI
{
    public partial class MemberOperationFrm : DevExpress.XtraEditors.XtraForm
    {
        private MemberInfoVo memberVo;
        public MemberOperationFrm(MemberInfoVo memberVo = null)
        {
            this.memberVo = memberVo;
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
            return (!this.textMName.Text.Equals("") && !this.textBalance.Text.Equals(""));
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!CheckParam())
            {
                XtraMessageBox.Show("信息不完整请检查", "提示");
                return;
            }
            if (memberVo==null)
            {
                    //添加会员
                List<object> infoList = new List<object>() { this.textMId.Text, this.textMName.Text, this.comCardLevel.Text, this.textPhone.Text, this.comStatus.Text, Convert.ToDouble  (this.textBalance.Text), SystemConst.companyId};
                if (ProcedureDao.MemberRegister(infoList) > 0)
                {
                    XtraMessageBox.Show("添加会员成功!", "提示");
                    EventBus.PublishEvent("AddMemberSuccess");
                    EventBus.PublishEvent("MemberRechargeSuccess");
                 }
                  else
                 {
                     XtraMessageBox.Show("添加会员失败!", "提示");
                     return;
                 }
            }
            else
            {
                 memberVo.MName = this.textMName.Text;
                 memberVo.MPhone = this.textPhone.Text;
                 memberVo.CardName = this.comCardLevel.Text;
                 memberVo.CompanyId = SystemConst.companyId;
                 if (InsertDao.InsertData(memberVo, typeof(MemberInfoVo))>0)
                 {
                     XtraMessageBox.Show("更新会员成功!", "提示");
                 }
                 else
                 {
                     XtraMessageBox.Show("更新会员失败!", "提示");
                 }
             }
            this.DialogResult = DialogResult.OK;
        }

        private void MemberOperationForm_Load(object sender, EventArgs e)
        {
            FillMemberLevel();
            FillMemberSataus();
            if (memberVo == null)
            {
                this.textMId.Text = GenrateIDUtil.GenerateMemberID();
            }
            else
            {
                this.textMId.Text = memberVo.MId;
                this.textMId.Enabled = false;
                this.textBalance.Text = memberVo.MBalance.ToString();
                this.textBalance.Enabled = false;
            }
        }

        private void FillMemberLevel()
        {
            List<CardVo> cardDaoList = SelectDao.SelectData<CardVo>();
            foreach (CardVo vo in cardDaoList)
            {
                this.comCardLevel.Properties.Items.Add(vo.CardName);
            }
        }

        private void FillMemberSataus()
        {
            this.comStatus.Properties.Items.AddRange(new string[] { "正常", "停止", "挂失" });
        }
    }
}
