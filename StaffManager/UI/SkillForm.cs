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
using ClientCenter.Event;
using ClientCenter.Enity;

namespace StaffManager.UI
{
    public partial class SkillForm : DevExpress.XtraEditors.XtraForm
    {
        public SkillForm(Type type)
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
            this.btnDel.ItemClick += BtnDel_Click;
            this.gridView1.MouseDown += GridView1_MouseDown;
            this.gridView1.MouseUp += GridView1_MouseUp;
        }
        #endregion

        #region events
        private void SkillForm_Load(object sender, EventArgs e)
        {
            List<SkillVo> daoVoList = new List<SkillVo>();
            SelectDao.SelectData(ref daoVoList);
            this.gridControl1.DataSource = daoVoList;
            this.gridControl1.RefreshDataSource();
        }
        private void BtnDel_Click(object sender, EventArgs e)
        {
            SkillVo vo = (SkillVo)this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
            if(DeleteDao.DelSkillByID(vo.SkillId)>0)
            {
                List<SkillVo> daoVoList = (List<SkillVo>)this.gridView1.DataSource;
                daoVoList.Remove(vo);
                this.gridControl1.RefreshDataSource();
                EventBus.PublishEvent("DelSkillSuccess");
            }
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textName.Text))
                return;
            SkillVo daoVo = new SkillVo()
            {
                SkillName = this.textName.Text,
                Remark = this.textRemark.Text
            };
            if(InsertDao.InsertData(daoVo,typeof(SkillVo))>0)
            {
                XtraMessageBox.Show("操作成功!", "提示");
                List<SkillVo> voList = (List<SkillVo>)this.gridView1.DataSource;
                voList.Add(daoVo);
                this.gridControl1.RefreshDataSource();
                EventBus.PublishEvent("AddSkillSuccess");
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
                SkillVo vo = (SkillVo)this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
                this.textName.Text = vo.SkillName;
                this.textRemark.Text = vo.Remark;
            }
        }
        #endregion

    }
}