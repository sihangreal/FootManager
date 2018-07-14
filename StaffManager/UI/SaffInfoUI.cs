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
using ClientCenter.Core;
using DevExpress.XtraEditors.Repository;
using ClientCenter.Enity;
using DevExpress.XtraEditors.Controls;
using ClientCenter.DB;
using ClientCenter.Event;

namespace StaffManager.UI
{
    public partial class SaffInfoUI : BaseInfoUI
    {
        private List<StaffInfoVo> staffInfoList = new List<StaffInfoVo>();

        public SaffInfoUI()
        {
            InitializeComponent();
            SetStaffInfoGrid();
        }
        private void SetStaffInfoGrid()
        {
            GridViewUtil.CreateColumnForData(gridView1, typeof(StaffInfoVo));
            RepositoryItemComboBox repositoryItemComboLevel = new RepositoryItemComboBox();
            RepositoryItemComboBox repositoryItemComboSex = new RepositoryItemComboBox();
            RepositoryItemComboBox repositoryItemComboDepartment = new RepositoryItemComboBox();
            repositoryItemComboLevel.BeginInit();
            repositoryItemComboSex.BeginInit();
            repositoryItemComboDepartment.BeginInit();

            repositoryItemComboLevel.TextEditStyle = TextEditStyles.DisableTextEditor;
            repositoryItemComboSex.TextEditStyle = TextEditStyles.DisableTextEditor;
            repositoryItemComboDepartment.TextEditStyle = TextEditStyles.DisableTextEditor;

            gridControl1.RepositoryItems.AddRange(new RepositoryItem[] { repositoryItemComboLevel, repositoryItemComboDepartment });

            repositoryItemComboLevel.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            repositoryItemComboSex.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            repositoryItemComboDepartment.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            //填充员工级别
            foreach (StaffLevelVo vo in SelectDao.SelectData<StaffLevelVo>())
            {
                repositoryItemComboLevel.Items.Add(vo.StaffLevel);
            }
            repositoryItemComboSex.Items.AddRange(new string[] { "男", "女" });
            //员工性别
            this.gridView1.Columns["StaffSex"].ColumnEdit = repositoryItemComboSex;
            this.gridView1.Columns["StaffLevel"].ColumnEdit = repositoryItemComboLevel;
            //填充员工部门 Department
            foreach (DepartmentVo vo in SelectDao.SelectData<DepartmentVo>())
            {
                repositoryItemComboDepartment.Items.Add(vo.DepName);
            }
            this.gridView1.Columns["Department"].ColumnEdit = repositoryItemComboDepartment;

            repositoryItemComboLevel.EndInit();
            repositoryItemComboSex.EndInit();
            repositoryItemComboDepartment.EndInit();

            RefreshStaff();
        }
        private void RefreshStaff()
        {
            staffInfoList = SelectDao.SelectData<StaffInfoVo>();
            this.gridControl1.DataSource = staffInfoList;
            this.gridControl1.RefreshDataSource();
        }
        private bool CheckParam(List<StaffInfoVo> voList)
        {
            foreach (StaffInfoVo vo in voList)
            {
                if (string.IsNullOrWhiteSpace(vo.StaffName))
                {
                    XtraMessageBox.Show("员工姓名不能为空！");
                    return false;
                }
            }
            var list = voList.GroupBy(v => v.StaffName).Where(v => v.Count() > 1).ToList();
            if (list.Count > 0)
            {
                XtraMessageBox.Show("员工姓名不能相同！");
                return false;
            }
            return true;
        }
        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            List<StaffInfoVo> staffOldInfoList = SelectDao.SelectData<StaffInfoVo>();
            List<StaffInfoVo> changeList = GenericUtil.GetChanges(staffInfoList, staffOldInfoList);
            int result = 0;
            if (!CheckParam(changeList))
                return;
            foreach (StaffInfoVo vo in changeList)
            {
                if (SelectDao.IsRepeatedStaffId(vo.StaffId))
                {
                    //更新
                    result = UpdateDao.UpdateByID(vo);
                    if (result <= 0)
                    {
                        XtraMessageBox.Show(vo.StaffName + "更新失败！");
                        continue;
                    }
                }
                else
                {
                    //员工注册
                    object[] infoArry = new object[] { vo.StaffId, vo.StaffName, vo.StaffSex, vo.StaffPlace ,
                                                   vo.StaffLevel,vo.Department,vo.IdNumber,vo.BasicSalary,vo.Commision};
                    result = ProcedureDao.StaffRegister(infoArry);
                    if (result <= 0)
                    {
                        XtraMessageBox.Show(vo.StaffName + "保存失败！");
                        continue;
                    }
                }
            }
            EventBus.PublishEvent("StaffWorkStatusChange");
            //RefreshWorkInfo();
            XtraMessageBox.Show("保存成功！");
        }

        protected override void BtnDel_Click(object sender, EventArgs e)
        {
            StaffInfoVo vo = (StaffInfoVo)this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
            if (vo == null)
                return;
            if (DeleteDao.DelStaffInfoByID(vo.StaffId) > 0)
            {
                XtraMessageBox.Show("删除成功");
                RefreshStaff();
            }
        }

        protected override void BtnAdd_Click(object sender, EventArgs e)
        {
            StaffInfoVo staffInfoVo = new StaffInfoVo();
            staffInfoVo.StaffSex = "男";
            staffInfoVo.StaffId = GenrateIDUtil.GenerateStaffID();
            staffInfoList.Add(staffInfoVo);
            this.gridControl1.RefreshDataSource();
        }

    }
}
