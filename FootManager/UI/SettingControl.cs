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

namespace FootManager.UI
{
    public partial class SettingControl : DevExpress.XtraEditors.XtraUserControl
    {
        Dictionary<string, Control> controlDic = new Dictionary<string, Control>();

        public SettingControl()
        {
            InitializeComponent();
            InitEvents();
        }

        #region private
        private void InitEvents()
        {
            this.Load += SettingForm_Load;

            this.btnUserSetting.Click += SimpleButton_Click;
            this.btnDataServer.Click += SimpleButton_Click;
            this.btnCompany.Click += SimpleButton_Click;
        }

        private void FillControl()
        {
            //controlDic.Add("会员设置", new MemberSetting());
            //controlDic.Add("员工设置", new StaffSetting());
            //controlDic.Add("服务项目设置", new SkillSettingNew());
            controlDic.Add("用户权限设置", new OperatSetting());
            controlDic.Add("数据库设置",new DataBaseSetting());
            controlDic.Add("公司信息设置", new CompanySetting());
        }
        #endregion

        #region events
        private void SimpleButton_Click(object sender, EventArgs e)
        {
            string key = (sender as SimpleButton).Tag.ToString();
            ShowControl(key);
        }

        private Control ShowControl(string id)
        {
            this.panelControl1.Controls.Clear();
            Control control= null;
            if (controlDic.ContainsKey(id))
            {
                control = controlDic[id];
                control.Dock = DockStyle.Fill;
                this.panelControl1.Controls.Add(control);
            }
            return control;
        }
        private void SettingForm_Load(object sender, EventArgs e)
        {
            FillControl();
            ShowControl("用户权限设置");
        }
        #endregion

    }
}