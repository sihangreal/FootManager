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
using ClientCenter.Event;

namespace MemberManager.UI
{
    public partial class UpdateCardForm : DevExpress.XtraEditors.XtraForm
    {
        int m_cardId;
        string m_cardName;
        double m_discount;

        public UpdateCardForm(int cardId, string cardName, double discount)
        {
            this.m_cardId = cardId;
            this.m_cardName = cardName;
            this.m_discount = discount;
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            this.Load += UpdateCardForm_Load;
            this.btnQuery.Click += BtnQuery_Click;
            this.btnCancel.Click += BtnCancel_Click;
        }

        private void UpdateCardForm_Load(object sender, EventArgs e)
        {
            this.textCardName.Text = m_cardName;
            this.textDisCount.Text = m_discount.ToString();
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            if (this.textDisCount.Text == null)
                return;
            double discount = Convert.ToDouble(textDisCount.Text);
            string cardName = this.textCardName.Text;
            if (UpdateDao.UpdateCardByID(m_cardId, cardName, discount) > 0)
            {
                XtraMessageBox.Show("更新会员卡成功!!", "提示");
                EventBus.PublishEvent("AddCardSuccessed");
            }
            else
            {
                XtraMessageBox.Show("更新会员卡失败!!", "提示");
            }
        }
    }
}