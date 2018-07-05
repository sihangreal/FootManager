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
using StaffManager.Enity;

namespace StaffManager.UI
{
    public partial class Staff : DevExpress.XtraEditors.XtraUserControl
    {
        StaffVo staffVo;
        Color redColor = Color.FromArgb(220, 120, 120);
        Color greenColor = Color.FromArgb(120, 220, 120);

        Image redImg = StaffManager.Properties.Resources.red;
        Image buleImg = StaffManager.Properties.Resources.bule;

        public Staff(StaffVo staffVo)
        {
            this.staffVo = staffVo;
            InitializeComponent();
            InitEvents();
        }

        #region private method
        private void InitEvents()
        {
            this.Load += Staff_Load;
          
        }
        #endregion

        #region events
        private void Staff_Load(object sender, EventArgs e)
        {
            this.labId.Text = staffVo.StaffId.ToString();
            //this.labName.Text = staffVo.StaffName.ToString();
            //this.BackColor = staffVo.StaffSex == 0 ? redColor : greenColor;
            this.BackgroundImage = staffVo.StaffSex == 0 ? redImg : buleImg;
        }
        #endregion
    }
}
