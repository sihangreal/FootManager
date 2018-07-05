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
    public partial class AddStaffClassForm : DevExpress.XtraEditors.XtraForm
    {
        public AddStaffClassForm()
        {
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            this.Load += AddStaffClassForm_Load;
            this.btnAdd.Click += BtnAdd_Click;
            this.btnCancel.Click += BtnCancel_Click;
        }
        private void FillComTime()
        {
            for (int i = 1; i <= 24; ++i)
            {
                this.dateStart.Properties.Items.Add(i);
                this.dateEnd.Properties.Items.Add(i);
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txetName.Text))
            {
                XtraMessageBox.Show("信息不完整，请重新输入！");
                return;
            }
            StaffClassVo vo = new StaffClassVo()
            {
                StaffClassName = this.txetName.Text,
                StartTime = Convert.ToInt32(this.dateStart.Text),
                EndTime = Convert.ToInt32(this.dateEnd.Text),
                Remark = this.memoRemark.Text
            };
            if (InsertDao.InsertData(vo, typeof(StaffClassVo)) > 0)
            {
                XtraMessageBox.Show("添加班次成功!");
                EventBus.PublishEvent("AddClassSuccessed");
            }
        }

        private void AddStaffClassForm_Load(object sender, EventArgs e)
        {
            FillComTime();
        }
    }
}