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
using StaffManager.Enity;
using ClientCenter.Event;
using ClientCenter.Enity;

namespace StaffManager.UI
{
    public partial class DepartmentForm : DevExpress.XtraEditors.XtraForm
    {
        public DepartmentForm(Type type)
        {
            InitializeComponent();
            InitEvents();
            GridViewUtil.CreateColumnForData(this.gridView1, type);
        }

        #region private method
        private void InitEvents()
        {
            this.Load += SkillForm_Load;
            this.btnAdd.Click += BtnAdd_Click;
            this.btnDel.ItemClick += BtnDel_ItemClick;
            this.gridView1.MouseDown += GridView1_MouseDown;
            this.gridView1.MouseUp += GridView1_MouseUp;
        }
        #endregion

        #region events
        private void SkillForm_Load(object sender, EventArgs e)
        {
            List<DepartmentVo> daoVoList = new List<DepartmentVo>();
            SelectDao.SelectData(ref daoVoList);
            this.gridControl1.DataSource = daoVoList;
            this.gridControl1.RefreshDataSource();
        }
        private void BtnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DepartmentVo vo = (DepartmentVo)this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
            if(DeleteDao.DelDepartmentByID(vo.Id)>0)
            {
                List<DepartmentVo> daoVoList = (List<DepartmentVo>)this.gridView1.DataSource;
                daoVoList.Remove(vo);
                this.gridControl1.RefreshDataSource();
                EventBus.PublishEvent("DelDepartmentSuccess");
            }

        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textName.Text))
                return;
            DepartmentVo daoVo = new DepartmentVo()
            {
                DepName = this.textName.Text,
            };
            if (InsertDao.InsertData(daoVo, typeof(DepartmentVo)) > 0)
            {
                XtraMessageBox.Show("操作成功!", "提示");
                List<DepartmentVo> voList = (List<DepartmentVo>)this.gridView1.DataSource;
                voList.Add(daoVo);
                this.gridControl1.RefreshDataSource();
                EventBus.PublishEvent("AddDepartmentSuccess");
            }
            else
            {
                XtraMessageBox.Show("操作失败!", "提示");
            }
        }
        private void GridView1_MouseUp(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = this.gridView1.CalcHitInfo(e.Location);
            if (hi.InRow && e.Button == MouseButtons.Right)
            {
                this.popupMenu1.ShowPopup(Control.MousePosition);
            }
        }
        private void GridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 2)
            {
                DepartmentVo vo = (DepartmentVo)this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
                this.textName.Text = vo.DepName;
            }
        }
        #endregion
    }
}