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
using System.Configuration;

namespace FootManager.UI
{
    public partial class SetDataBaseForm : DevExpress.XtraEditors.XtraForm
    {
        Configuration _config =ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        public SetDataBaseForm()
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
            _config.AppSettings.Settings["Server"].Value= this.textEdit1.Text;
            _config.AppSettings.Settings[ "Server"].Value= this.textEdit1.Text;
            _config.AppSettings.Settings[ "DataBase"].Value= this.textEdit2.Text;
            _config.AppSettings.Settings[ "User"].Value= this.textEdit3.Text;
            _config.AppSettings.Settings[ "Password"].Value= this.textEdit4.Text;
            XtraMessageBox.Show("保存成功！");
        }

        private void DataBaseSetting_Load(object sender, EventArgs e)
        {
            this.textEdit1.Text = ConfigurationManager.AppSettings["Server"];
            this.textEdit2.Text = ConfigurationManager.AppSettings["DataBase"];
            this.textEdit3.Text = ConfigurationManager.AppSettings["DataUser"];
            this.textEdit4.Text = ConfigurationManager.AppSettings["DataPassword"];
        }
    }
}