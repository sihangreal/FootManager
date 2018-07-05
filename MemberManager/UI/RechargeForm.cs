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
using ClientCenter.DB;
using MemberManager.Enity;
using ClientCenter.Core;
using ClientCenter.Event;

namespace MemberManager.UI
{
    public partial class RechargeForm : DevExpress.XtraEditors.XtraForm
    {
        private string mId, mName;

        public RechargeForm(string mId,string mName)
        {
            InitializeComponent();
            InitEvents();
            this.mId = mId;
            this.mName = mName;
        }

        #region private method
        private void InitEvents()
        {
            this.btnQuery.Click += BtnQuery_Click;
            this.btnCancel.Click += BtnCancel_Click;
        }
        #endregion

        #region  events
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textEdit1.Text))
                return;
            if(!FilterUtil.isNumberic(this.textEdit1.Text))
            {
                XtraMessageBox.Show("请输入正确的金额!","提示");
                return;
            }
            double amount = Convert.ToDouble(this.textEdit1.Text);
            int companyId = 1;
            if(ProcedureDao.MemberRechargeByID(this.mId,this.mName, companyId, amount)>0)
            {
                XtraMessageBox.Show("充值成功!","提示");
                EventBus.PublishEvent("UpdateMemberInfoChanged",this,this.mId);
                this.Close();
            }
        }
        #endregion
    }
}