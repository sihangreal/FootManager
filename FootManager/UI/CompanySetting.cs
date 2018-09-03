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
using ClientCenter.Enity;
using ClientCenter.DB;
using ClientCenter.Core;
using System.Configuration;

namespace FootManager.UI
{
    public partial class CompanySetting : DevExpress.XtraEditors.XtraUserControl
    {
        private static Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        public CompanySetting()
        {
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            this.Load += CompanySetting_Load;
            this.btnQuery.Click += BtnQuery_Click;
            this.btnCancel.Click += BtnCancel_Click;
        }

        private void CompanySetting_Load(object sender, EventArgs e)
        {
            int companyId = SystemConst.companyId;
            CompanyVo vo= SelectDao.SelectDataByID<CompanyVo>(companyId).FirstOrDefault();
            if(vo!=null)
            {
                this.textEdit1.Text = vo.Name;
                this.textEdit2.Text = vo.Address;
                this.textEdit3.Text = vo.Manager;
                this.memoRemark.Text = vo.Remark;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            return;
        }

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(this.textEdit1.Text))
            {
                XtraMessageBox.Show("公司名称不能为空！");
                return;
            }
            CompanyVo vo = new CompanyVo()
            {
                Name = this.textEdit1.Text,
                Address=this.textEdit2.Text,
                Manager=this.textEdit3.Text
            };
            object id;
            if ((id = InsertDao.InsertDataRetrunID(vo))!=null)
            {
                config.AppSettings.Settings["CompanyId"].Value = id.ToString();
                XtraMessageBox.Show("操作成功！");
            }
        }
    }
}
