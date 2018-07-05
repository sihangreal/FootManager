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

namespace ClockRoomManager.UI
{
    public partial class RemarkForm : DevExpress.XtraEditors.XtraForm
    {
        public string remark;
        public RemarkForm()
        {
            InitializeComponent();
        }

        private void InitEvents()
        {
            this.btnQuery.Click += BtnQuery_Click;
            this.btnCancel.Click += BtnCancel_Click;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            remark = this.memoEdit1.Text;
        }
    }
}