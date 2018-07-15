using System;

namespace MemberManager.UI
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
            this.btnLook.Click += BtnLook_Click;
            this.btnReadCard.Click += BtnReadCard_Click;
        }

        protected virtual void BtnReadCard_Click(object sender, EventArgs e)
        {
         
        }

        protected virtual void BtnLook_Click(object sender, EventArgs e)
        {
           
        }
    }
}
