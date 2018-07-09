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

namespace FootManager.UI
{
    public partial class MainForm :  DevExpress.XtraEditors.XtraForm
    {
        string[] skinNames = new string[] { "Black", "Office 2013","Seven Classic", "Coffee", "Seven"};
        UIFactory factory;

        public MainForm()
        {
            InitializeComponent();
            InitEvents();
        }

        #region
        private void InitEvents()
        {
            this.Load += MainFormNew_Load;
            //this.btnCashier.ItemClick += RibbonBtn_ItemClick;
            this.btnRoom.ItemClick += RibbonBtn_ItemClick;
            this.btnStaff.ItemClick += RibbonBtn_ItemClick;
            this.btnMember.ItemClick += RibbonBtn_ItemClick;
            this.btnReport.ItemClick += RibbonBtn_ItemClick;
            this.btnStore.ItemClick += RibbonBtn_ItemClick;
            this.btnSettlement.ItemClick += RibbonBtn_ItemClick;

            this.btnExit.ItemClick += BtnExit_ItemClick;
            this.btnUserSet.ItemClick += BtnUserSet_ItemClick;
            this.btnCheck.ItemClick += BtnCheck_ItemClick;
            this.btnSetting.ItemClick += BtnSetting_ItemClick         ;
        }

        /// <summary>
        /// 结账
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCheck_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CheckCashierForm cashierForm = new CheckCashierForm();
            cashierForm.ShowDialog();
        }

        private void SetSkin()
        {
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            foreach (string name in skinNames)
            {
                DevExpress.XtraBars.BarButtonItem barSkin=new DevExpress.XtraBars.BarButtonItem();
                barSkin.ItemClick += BarSkin_ItemClick;
                barSkin.Caption = name;
                barSkin.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                this.barManager1.Items.Add(barSkin);
                this.popupMenu1.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(barSkin));
            }
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
        }
        #endregion


        #region event
        private void MainFormNew_Load(object sender, EventArgs e)
        {
            factory = UIFactory.GetUIFactory();
            factory.ShowControl(this.mainPanel, "钟房管理");
            SetSkin();
        }
        private void RibbonBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            factory.ShowControl(this.mainPanel, e.Item.Caption);
        }
        //权限用户设置
        private void BtnUserSet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.mainPanel.Controls.Clear();
            //OperatSetting operate = new OperatSetting();
            //operate.Dock = DockStyle.Fill;
            //this.mainPanel.Controls.Add(operate);

            SettingControl settingForm = new SettingControl();
            settingForm.Dock = DockStyle.Fill;
            this.mainPanel.Controls.Add(settingForm);
        }
        private void BtnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        private void BarSkin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = e.Item.Caption;
        }
        //系统设置
        private void BtnSetting_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SettingControl  settingForm = new SettingControl();
            settingForm.Show();
        }
        #endregion
    }
}