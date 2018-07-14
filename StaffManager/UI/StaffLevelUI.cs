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

namespace StaffManager.UI
{
    public partial class StaffLevelUI : BaseInfoUI
    {
        private List<StaffLevelVo> staffLevelList = new List<StaffLevelVo>();
        public StaffLevelUI()
        {
            InitializeComponent();
            GridViewUtil.CreateColumnForData(this.gridView1,typeof(StaffLevelVo));
            RefreshLevel();
        }
        private void RefreshLevel()
        {
            staffLevelList = SelectDao.SelectData<StaffLevelVo>();
            this.gridControl1.DataSource = staffLevelList;
            this.gridControl1.RefreshDataSource();
        }
        private bool CheckParam(List<StaffLevelVo> changeList)
        {
            foreach (StaffLevelVo vo in changeList)
            {
                if (string.IsNullOrWhiteSpace(vo.StaffLevel))
                {
                    XtraMessageBox.Show("级别名称不能为空！");
                    return false;
                }
            }
            var list = changeList.GroupBy(v => v.StaffLevel).Where(v => v.Count() > 1).ToList();
            if (list.Count > 0)
            {
                XtraMessageBox.Show("级别名称不能相同！");
                return false;
            }
            return true;
        }
        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            List<StaffLevelVo> staffOldInfoList = SelectDao.SelectData<StaffLevelVo>();
            List<StaffLevelVo> changeList = GenericUtil.GetChanges(staffLevelList, staffOldInfoList);
            int result = 0;
            if (!CheckParam(changeList))
                return;
            foreach (StaffLevelVo vo in changeList)
            {
                if (SelectDao.IsRepeatedLevelId(vo.Id))
                {
                    //更新
                    result = UpdateDao.UpdateByID(vo);
                    if (result <= 0)
                    {
                        XtraMessageBox.Show(vo.Id + "更新失败！");
                        continue;
                    }
                }
                else
                {
                    result = InsertDao.InsertData(vo);
                    if (result <= 0)
                    {
                        XtraMessageBox.Show(vo.Id + "保存失败！");
                        continue;
                    }
                }
            }
            XtraMessageBox.Show("保存成功！");
        }
        protected override void BtnDel_Click(object sender, EventArgs e)
        {
            StaffLevelVo vo = (StaffLevelVo)this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
            if (DeleteDao.DeleteByID(vo.Id, typeof(StaffLevelVo)) > 0)
            {
                XtraMessageBox.Show("删除成功");
                RefreshLevel();
            }
        }
        protected override void BtnAdd_Click(object sender, EventArgs e)
        {
            StaffLevelVo depVo = new StaffLevelVo();
            staffLevelList.Add(depVo);
            this.gridControl1.RefreshDataSource();
        }

    }
}
