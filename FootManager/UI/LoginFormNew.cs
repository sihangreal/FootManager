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
using ClientCenter.Core;
using ClientCenter.DB;
using System.Configuration;

namespace FootManager.UI
{
    public partial class LoginFormNew : DevExpress.XtraEditors.XtraForm
    {
        public LoginFormNew()
        {
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            this.Load += LoginFormNew_Load;
            this.dropBtnSwitchDataBase.Click += DropBtnSwitchDataBase_Click;
            this.btnLogin.Click += BtnLogin_Click;
        }

        #region events
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtUserName.Text))
            {
                XtraMessageBox.Show("用户名不能为空！", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtUserName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(this.txtPassWord.Text))
            {
                XtraMessageBox.Show("密码不能为空！", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtPassWord.Focus();
                return;
            }
            string password = XmlUtil.Encryption(this.txtPassWord.Text);
            if(SelectDao.UserLogion(this.txtUserName.Text, password))
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["User"].Value = this.txtUserName.Text;
                if (this.checkEdit1.Checked)
                {
                    config.AppSettings.Settings["Password"].Value = password;
                    config.AppSettings.Settings["Remember"].Value = "true";
                }
            }
            else
            {
                XtraMessageBox.Show("登录失败!");
            }
        }

        private void DropBtnSwitchDataBase_Click(object sender, EventArgs e)
        {
            SetDataBaseForm databaseForm = new SetDataBaseForm();
            databaseForm.ShowDialog();
        }

        private void LoginFormNew_Load(object sender, EventArgs e)
        {

        }
        #endregion
    }
}