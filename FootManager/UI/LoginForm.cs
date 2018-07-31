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
using ClientCenter.Core;
using System.Threading;

namespace FootManager
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        int iToltal = 10;
        public LoginForm()
        {
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //设定字体大小为12px 
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            InitializeComponent();
            InitEvents();
        }

        #region private method
        private void InitEvents()
        {
            this.loginBtn.Click += LoginBtn_Click;
            this.textName.KeyDown += TextName_KeyDown;
            this.textPsw.KeyDown += TextPsw_KeyDown;
            this.Load += LoginForm_Load;

            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += BackgroundWorker1_DoWork;
            this.backgroundWorker1.ProgressChanged += BackgroundWorker1_ProgressChanged;

            this.progressBarControl1.Properties.Maximum = iToltal;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            string appPath = System.AppDomain.CurrentDomain.BaseDirectory + "FootConfig.xml";
            if(("true").Equals(XmlUtil.ReadDataInfo(appPath, "Remember")))
            {
                this.checkEdit1.Checked = true;
            }
            if (this.checkEdit1.Checked)
            {
                this.textName.Text = XmlUtil.ReadDataInfo(appPath, "User");
                string password = XmlUtil.ReadDataInfo(appPath, "Password");
                this.textPsw.Text = XmlUtil.Decrypt(password);
            }
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarControl1.Position = e.ProgressPercentage;
            if (progressBarControl1.Position == progressBarControl1.Properties.Maximum)
            {
                LoginFreshShow();
            }
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for(int i=0;i<=10;i++)
            {
                if(backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    backgroundWorker1.ReportProgress(i);
                    Thread.Sleep(100);
                }
            }
        }
        #endregion

        #region public method
        public void LoginFreshShow()
        {
            if (SelectDao.UserLogion(this.textName.Text, this.textPsw.Text))
            {
                this.DialogResult = DialogResult.OK;
                UserRight instance = UserRight.GetInstance();
                instance.GetUserRight(this.textName.Text);
                string appPath = System.AppDomain.CurrentDomain.BaseDirectory + "FootConfig.xml";
                XmlUtil.SavaDataInfo(appPath, "User", this.textName.Text);
                //加密
                if (this.checkEdit1.Checked)
                {
                    string password=XmlUtil.Encryption(this.textPsw.Text);
                    XmlUtil.SavaDataInfo(appPath, "Password", password);
                    XmlUtil.SavaDataInfo(appPath, "Remember", "true");
                }
                this.Close();
            }
            else
            {
                progressBarControl1.Position = 0;
                backgroundWorker1.CancelAsync();
                XtraMessageBox.Show("登录失败!");
            }
        }
        #endregion

        #region events
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
                return;
            backgroundWorker1.RunWorkerAsync();
        }
        private void TextPsw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                backgroundWorker1.RunWorkerAsync();
        }

        private void TextName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
                backgroundWorker1.RunWorkerAsync();
        }
        //test

        #endregion
    }
}