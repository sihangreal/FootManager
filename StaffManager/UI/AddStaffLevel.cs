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
using ClientCenter.Enity;
using ClientCenter.DB;
using ClientCenter.Event;

namespace StaffManager.UI
{
    public partial class AddStaffLevel : DevExpress.XtraEditors.XtraForm
    {
        public AddStaffLevel()
        {
            InitializeComponent();
            InitEvents();
        }
        private void InitEvents()
        {
            this.Load += AddStaffLevel_Load;
            this.btnAdd.Click += BtnAdd_Click;
            this.btnCancel.Click += BtnCancel_Click;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            StaffLevelVo vo = new StaffLevelVo()
            {
                StaffLevel = this.textLevel.Text,
                Remark = this.memoRemark.Text
            };
            if (InsertDao.InsertData(vo, typeof(StaffLevelVo)) > 0)
            {
                XtraMessageBox.Show("添加员工级别成功!!");
                EventBus.PublishEvent("AddLevelSuccessed");
            }
        }

        private void AddStaffLevel_Load(object sender, EventArgs e)
        {

        }
    }
}