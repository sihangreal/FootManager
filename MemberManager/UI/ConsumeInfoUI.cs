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

namespace MemberManager.UI
{
    public partial class ConsumeInfoUI : BaseInfoUI
    {
        List<MemberConsumeVo> consumeVoList = new List<MemberConsumeVo>();
        public ConsumeInfoUI()
        {
            InitializeComponent();
            GridViewUtil.CreateColumnForData(this.gridView1, typeof(MemberConsumeVo));
            consumeVoList = SelectDao.SelectData<MemberConsumeVo>();
            this.gridControl1.DataSource = consumeVoList;
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
            if (string.IsNullOrWhiteSpace(this.textCard.Text))
            {
                consumeVoList = SelectDao.SelectMemberConsumeByName<MemberConsumeVo>(this.textName.Text);
            }
            else
            {
                consumeVoList = SelectDao.SelectMemberConsumeByID<MemberConsumeVo>(this.textCard.Text);
            }
            this.gridControl1.DataSource = consumeVoList;
            this.gridControl1.RefreshDataSource();
        }
    }
}
