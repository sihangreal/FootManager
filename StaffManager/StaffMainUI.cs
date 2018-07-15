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
using StaffManager.UI;

namespace StaffManager
{
    public partial class StaffMainUI : DevExpress.XtraEditors.XtraUserControl
    {
        private SaffInfoUI staffInfoUI=new SaffInfoUI();
        private StaffWorkUI staffWorkUI=new StaffWorkUI();
        private StaffQueueUI staffQueueUI = new StaffQueueUI();
        private DepartmentUI departmentUI = new DepartmentUI();
        private StaffLevelUI levelUI = new StaffLevelUI();
        private ClassInfoUI classUI = new ClassInfoUI();
        private StaffWorkQueryUI staffRecordUI = new StaffWorkQueryUI();
        public StaffMainUI()
        {
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            this.Load += StaffMainUI_Load;
        }

        private void StaffMainUI_Load(object sender, EventArgs e)
        {
            this.navigationPane1.SelectedPage = this.staffInfoPage;
            staffInfoUI.Dock = DockStyle.Fill;
            this.staffInfoPage.Controls.Add(staffInfoUI);
            staffWorkUI.Dock = DockStyle.Fill;
            staffWorkPage.Controls.Add(staffWorkUI);
            staffQueueUI.Dock = DockStyle.Fill;
            staffQuePage.Controls.Add(staffQueueUI);
            departmentUI.Dock = DockStyle.Fill;
            departmentPage.Controls.Add(departmentUI);
            levelUI.Dock = DockStyle.Fill;
            staffLevelPage.Controls.Add(levelUI);
            classUI.Dock = DockStyle.Fill;
            classPage.Controls.Add(classUI);
            staffRecordUI.Dock = DockStyle.Fill;
            workRecordPage.Controls.Add(staffRecordUI);
        }
    }
}
