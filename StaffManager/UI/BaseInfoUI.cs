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

namespace StaffManager.UI
{
    public partial class BaseInfoUI : DevExpress.XtraEditors.XtraUserControl
    {
        public BaseInfoUI()
        {
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            this.btnAdd.Click += BtnAdd_Click;
            this.btnSave.Click += BtnSave_Click;
            this.btnDel.Click += BtnDel_Click;
            this.btnQueueUp.Click += BtnQueueUp_Click;
            this.btnQueueDown.Click += BtnQueueDown_Click;
            this.btnQueueFirst.Click += BtnQueueFirst_Click;
            this.btnQueueLast.Click += BtnQueueLast_Click;
            this.btnRandomQueue.Click += BtnRandomQueue_Click;
        }

        protected virtual void BtnRandomQueue_Click(object sender, EventArgs e) { }
        protected virtual void BtnQueueLast_Click(object sender, EventArgs e) { }
        protected virtual void BtnQueueFirst_Click(object sender, EventArgs e) { }
        protected virtual void BtnQueueUp_Click(object sender, EventArgs e) { }
        protected virtual void BtnQueueDown_Click(object sender, EventArgs e) { }
        protected virtual void BtnSave_Click(object sender, EventArgs e) { }
        protected virtual void BtnDel_Click(object sender, EventArgs e) { }
        protected virtual void BtnAdd_Click(object sender, EventArgs e) { }


        protected void HidePanel()
        {
            this.panelControl1.Visible = false;
        }

        protected void ShowQueueButton()
        {
            this.btnQueueLast.Visible = true;
            this.btnQueueFirst.Visible = true;
            this.btnQueueUp.Visible = true;
            this.btnQueueDown.Visible = true;
            this.btnRandomQueue.Visible = true;
        }
    }
}
