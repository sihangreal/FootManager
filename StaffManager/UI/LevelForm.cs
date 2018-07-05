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
using StaffManager.Enity;

namespace StaffManager.UI
{
    public partial class LevelForm : DevExpress.XtraEditors.XtraForm
    {
        Type type;
        public LevelForm(Type type)
        {
            this.type = type;
            InitializeComponent();
            InitEvents();
        }
        #region private method
        private void InitEvents()
        {
            this.Load += LevelForm_Load;
            this.btnAdd.Click += BtnAdd_Click;
        }
        #endregion

        #region  events
        private void LevelForm_Load(object sender, EventArgs e)
        {
            GridViewUtil.CreateColumnForData(this.gridView1, type);
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textName.Text))
                return;
            if (!FilterUtil.isDouble(this.textCommsion.Text))
            {
                this.textCommsion.EditValue = null;
                XtraMessageBox.Show("请输入小于1的小数!", "提示");
                return ;
            }
            LevelVo daoVo = new LevelVo()
            {
                LevelName = this.textName.Text,
                CommmisionV = this.textCommsion.Text
            };
            if (InsertDao.InsertData(daoVo, typeof(LevelVo)) > 0)
            {
                XtraMessageBox.Show("操作成功!", "提示");
                List<LevelVo> voList = (List<LevelVo>)this.gridView1.DataSource;
                voList.Add(daoVo);
                this.gridControl1.RefreshDataSource();
            }
            else
            {
                XtraMessageBox.Show("操作失败!", "提示");
            }
        }
        #endregion
    }
}