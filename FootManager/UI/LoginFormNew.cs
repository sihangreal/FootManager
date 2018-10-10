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
using DevExpress.XtraSplashScreen;
using FootManager.Util;
using System.Diagnostics;

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

        /// <summary>
        /// 加载服务
        /// </summary>
        private void InitServer()
        {
            SplashScreenManager.ShowForm(this, typeof(SplashScreenLogin), true, true, false);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            SplashScrennHelper.SetInfo("加载基础信息...", 0, 20, 10, null);
            stopwatch.Stop();
            AppLog.Info(string.Format("加载基础数据所耗时间：{0}毫秒", stopwatch.ElapsedMilliseconds));
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
        
            if(SelectDao.UserLogion(this.txtUserName.Text, this.txtPassWord.Text))
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["User"].Value = this.txtUserName.Text;
                if (this.checkEdit1.Checked)
                {
                    string password = XmlUtil.Encryption(this.txtPassWord.Text);
                    config.AppSettings.Settings["Password"].Value = password;
                    config.AppSettings.Settings["Remember"].Value = "true";
                    config.Save();
                }
                this.Hide();
                InitServer();
                this.DialogResult = DialogResult.OK;
                this.Close();
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
            if (("true").Equals(ConfigurationManager.AppSettings["Remember"]))
            {
                this.checkEdit1.Checked = true;
            }
            if (this.checkEdit1.Checked)
            {
                this.txtUserName.Text = ConfigurationManager.AppSettings["User"];
                string password = ConfigurationManager.AppSettings["Password"];
                this.txtPassWord.Text = XmlUtil.Decrypt(password);
            }
        }
        #endregion
    }
}