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
using ClientCenter.DB;
using ClientCenter.Core;
using ClientCenter.GridViews;

namespace StaffManager.UI
{
    public partial class ClassInfoUI : BaseInfoUI
    {
        private List<StaffClassVo> classList = new List<StaffClassVo>();
        public ClassInfoUI()
        {
            InitializeComponent();
            GridViewUtil.InitGridView(this.gridView1, typeof(StaffClassVo));
            RefreshClass();
        }

        private void RefreshClass()
        {
            classList = SelectDao.SelectData<StaffClassVo>();
            this.gridControl1.DataSource = classList;
            this.gridControl1.RefreshDataSource();
        }
        private bool CheckParam(List<StaffClassVo> changeList)
        {
            foreach (StaffClassVo vo in changeList)
            {
                if (string.IsNullOrWhiteSpace(vo.StaffClassName))
                {
                    XtraMessageBox.Show("班次名称不能为空！");
                    return false;
                }
            }
            var list = changeList.GroupBy(v => v.StaffClassName).Where(v => v.Count() > 1).ToList();
            if (list.Count > 0)
            {
                XtraMessageBox.Show("班次名称不能相同！");
                return false;
            }
            return true;
        }
        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            List<StaffClassVo> staffOldInfoList = SelectDao.SelectData<StaffClassVo>();
            List<StaffClassVo> changeList = GenericUtil.GetChanges(classList, staffOldInfoList);
            int result = 0;
            if (!CheckParam(changeList))
                return;
            foreach (StaffClassVo vo in changeList)
            {
                if (SelectDao.IsRepeatedClassId(vo.StaffClassID))
                {
                    //更新
                    result = UpdateDao.UpdateByID(vo);
                    if (result <= 0)
                    {
                        XtraMessageBox.Show(vo.StaffClassID + "更新失败！");
                        break;
                    }
                }
                else
                {
                    result = InsertDao.InsertData(vo);
                    if (result <= 0)
                    {
                        XtraMessageBox.Show(vo.StaffClassID + "保存失败！");
                        break;
                    }
                }
            }
            XtraMessageBox.Show("保存成功！");
        }
        protected override void BtnDel_Click(object sender, EventArgs e)
        {
            StaffClassVo vo = (StaffClassVo)this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
            if (vo == null)
                return;
            classList.Remove(vo);
            if (DeleteDao.DeleteByID(vo.StaffClassID, typeof(StaffClassVo)) > 0)
            {
                XtraMessageBox.Show("删除成功");
                RefreshClass();
            }
            this.gridControl1.DataSource = classList;
            this.gridControl1.RefreshDataSource();
        }
        protected override void BtnAdd_Click(object sender, EventArgs e)
        {
            StaffClassVo depVo = new StaffClassVo();
            classList.Add(depVo);
            this.gridControl1.RefreshDataSource();
        }
    }
}
