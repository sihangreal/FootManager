using System;
using ClientCenter.Core;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace FootManager.UI
{
    public partial class DataBaseSetting : DevExpress.XtraEditors.XtraUserControl
    {
        public DataBaseSetting()
        {
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            this.Load += DataBaseSetting_Load;
            this.simpleButton1.Click += SimpleButton1_Click;
        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            string appPath = System.AppDomain.CurrentDomain.BaseDirectory + "FootConfig.xml";
            XmlUtil.SavaDataInfo(appPath, "Server", this.textEdit1.Text);
            XmlUtil.SavaDataInfo(appPath, "DataBase", this.textEdit2.Text);
            XmlUtil.SavaDataInfo(appPath, "User", this.textEdit3.Text);
            XmlUtil.SavaDataInfo(appPath, "Password", this.textEdit4.Text);
            XtraMessageBox.Show("保存成功！");
        }

        private void DataBaseSetting_Load(object sender, EventArgs e)
        {
            string appPath = System.AppDomain.CurrentDomain.BaseDirectory + "FootConfig.xml";
            this.textEdit1.Text = XmlUtil.ReadDataInfo(appPath, "Server");
            this.textEdit2.Text = XmlUtil.ReadDataInfo(appPath, "DataBase");
            this.textEdit3.Text = XmlUtil.ReadDataInfo(appPath, "DataUser");
            this.textEdit4.Text = XmlUtil.ReadDataInfo(appPath, "DataPassword");
        }
    }
}
