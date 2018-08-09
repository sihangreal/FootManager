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
using ClientCenter.Enity;
using ClientCenter.Core;
using ClientCenter.DB;
using ClientCenter.GridViews;
using ClientCenter.Event;

namespace StaffManager.UI
{

    public partial class DepartmentUI : BaseInfoUI
    {
        private List<DepartmentVo> departmentVoList = new List<DepartmentVo>();
        public DepartmentUI()
        {
            InitializeComponent();
            GridViewUtil.InitGridView(this.gridView1, typeof(DepartmentVo));
            RefreshDepartment();
        }
        private void RefreshDepartment()
        {
            departmentVoList = SelectDao.SelectData<DepartmentVo>();
            this.gridControl1.DataSource = departmentVoList;
            this.gridControl1.RefreshDataSource();
        }
        private bool CheckParam(List<DepartmentVo> changeList)
        {
            foreach (DepartmentVo vo in changeList)
            {
                if (string.IsNullOrWhiteSpace(vo.DepName))
                {
                    XtraMessageBox.Show("部门名称不能为空！");
                    return false;
                }
            }
            var list = changeList.GroupBy(v => v.DepName).Where(v => v.Count() > 1).ToList();
            if (list.Count > 0)
            {
                XtraMessageBox.Show("部门名称不能相同！");
                return false;
            }
            return true;
        }
        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            List<DepartmentVo> staffOldInfoList = SelectDao.SelectData<DepartmentVo>();
            List<DepartmentVo> changeList = GenericUtil.GetChanges(departmentVoList, staffOldInfoList);
            int result = 0;
            if (!CheckParam(changeList))
                return;
            foreach (DepartmentVo vo in changeList)
            {
                if (SelectDao.IsRepeatedDepartmentId(vo.Id))
                {
                    //更新
                    result = UpdateDao.UpdateByID(vo);
                    if (result <= 0)
                    {
                        XtraMessageBox.Show(vo.Id + "更新失败！");
                        break;
                    }
                }
                else
                {
                    vo.CompanyId = SystemConst.companyId;
                    result =InsertDao.InsertData(vo);
                    if (result <= 0)
                    {
                        XtraMessageBox.Show(vo.Id + "保存失败！");
                        break;
                    }
                }
            }
            EventBus.PublishEvent("UpdateDepartment");
            XtraMessageBox.Show("保存成功！");
        }
        protected override void BtnDel_Click(object sender, EventArgs e)
        {
            DepartmentVo vo = (DepartmentVo)this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
            if (vo == null)
                return;
            departmentVoList.Remove(vo);
            if (DeleteDao.DeleteByID(vo.Id, typeof(DepartmentVo)) > 0)
            {
                XtraMessageBox.Show("删除成功");
                RefreshDepartment();
            }
            this.gridControl1.RefreshDataSource();
        }
        protected override void BtnAdd_Click(object sender, EventArgs e)
        {
            DepartmentVo depVo = new DepartmentVo();
            departmentVoList.Add(depVo);
            this.gridControl1.RefreshDataSource();
        }
    }
}
