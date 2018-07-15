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
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using ClientCenter.Event;

namespace StaffManager.UI
{
    public partial class StaffWorkUI : BaseInfoUI
    {
        List<StaffWorkInfoVo> staffWorkList = new List<StaffWorkInfoVo>();
        public StaffWorkUI()
        {
            EventBus.RegisterEvent(this);
            InitializeComponent();
            SetStaffWorkGrid();
        }

        private void SetStaffWorkGrid()
        {
            GridViewUtil.CreateColumnForData(gridView1, typeof(StaffWorkInfoVo));
            RepositoryItemComboBox repositoryItemComboStatus = new RepositoryItemComboBox();

            repositoryItemComboStatus.BeginInit();

            repositoryItemComboStatus.TextEditStyle = TextEditStyles.DisableTextEditor;
            gridControl1.RepositoryItems.AddRange(new RepositoryItem[] { repositoryItemComboStatus });

            repositoryItemComboStatus.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });

            repositoryItemComboStatus.Items.AddRange(new string[] { "休息", "请假" });

            //员工状态
            this.gridView1.Columns["StaffStatus"].ColumnEdit = repositoryItemComboStatus;
            repositoryItemComboStatus.EndInit();

            RefreshStaffWork();
        }

        private void RefreshStaffWork()
        {
            staffWorkList = SelectDao.SelectData<StaffWorkInfoVo>();
            this.gridControl1.DataSource = staffWorkList;
            this.gridControl1.RefreshDataSource();
        }

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            List<StaffWorkInfoVo> staffOldInfoList = SelectDao.SelectData<StaffWorkInfoVo>();
            List<StaffWorkInfoVo> changeList = GenericUtil.GetChanges(staffWorkList, staffOldInfoList);
            int  result=0;
            foreach (StaffWorkInfoVo vo in changeList)
            {
                 //更新
                result = UpdateDao.UpdateByID(vo);
                if (result <= 0)
                {
                    XtraMessageBox.Show(vo.StaffName + "更新失败！");
                    continue;
                }
                else
                {
                    XtraMessageBox.Show(vo.StaffName + "更新成功！");
                }
            }
            EventBus.PublishEvent("StaffWorkStatusChange");
        }

        [EventAttr("StaffWorkStatusChange")]
        public void StaffWorkStatusChange()
        {
            RefreshStaffWork();
        }
    }
}
