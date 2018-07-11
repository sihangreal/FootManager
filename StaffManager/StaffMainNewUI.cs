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
using ClientCenter.Enity;
using ClientCenter.DB;
using ClientCenter.Event;
using StaffManager.UI;
using StaffManager.Enity;

namespace StaffManager
{
    public partial class StaffMainNewUI : DevExpress.XtraEditors.XtraUserControl
    {
        //DataTable workDataSource;
        DataTable preDataSource;
        DataTable queueDataSource;

        public StaffMainNewUI()
        {
            InitializeComponent();
            EventBus.RegisterEvent(this);
            InitEvents();
            InitTable();
        }

        #region private
        private void InitEvents()
        {
            this.Load += StaffMainNewUI_Load;
            this.btnFind.Click += BtnFind_Click;
            this.btnPai.Click += BtnPai_Click;
     
            this.comboStatus.SelectedIndexChanged += ComboStatus_SelectedIndexChanged;

            this.btnAdd.Click += BtnAdd_Click;
            this.btnModify.Click += BtnModify_Click;
            this.btnDel.Click += BtnDel_Click;

            this.btnAddLevel.Click += BtnAddLevel_Click;
            this.btnDelLevel.Click += BtnDelLevel_Click;
            this.btnUpdateLevel.Click += BtnUpdateLevel_Click;

            this.btnAddDepartment.Click += BtnAddDepartment_Click;
            this.btnDelDepart.Click += BtnDelDepart_Click;
            this.btnUpdateDepart.Click += BtnUpdateDepart_Click;

            this.btnAddClass.Click += BtnAddClass_Click;
            this.btnDelClass.Click += BtnDelClass_Click;
            this.btnUpdateClass.Click += BtnUpdateClass_Click;

            this.btnRandomQueue.Click += BtnRandomQueue_Click;
            this.btnQueueUp.Click += BtnQueueUp_Click;
            this.btnQueueDown.Click += BtnQueueDown_Click;
            this.btnQueueFirst.Click += BtnQueueFirst_Click;
            this.btnQueueLast.Click += BtnQueueLast_Click;

            this.btnWorkUp.Click += BtnWorkUp_Click;
        }
        private void InitTable()
        {
            //workDataSource = GridViewUtil.CreateDataTabelForData(this.gridView1,typeof(StaffWorkInfoVo));
            preDataSource = GridViewUtil.CreateDataTabelForData(this.gridView2,typeof(StaffPreBookVo));
            queueDataSource = GridViewUtil.CreateDataTabelForData(this.gridView3, typeof(StaffQueueVo));

            GridViewUtil.CreateColumnForData(this.gridView1, typeof(StaffWorkInfoVo));
            GridViewUtil.CreateColumnForData(this.gridView4, typeof(StaffInfoVo));
            GridViewUtil.CreateColumnForData(this.gridView5, typeof(StaffLevelVo));
            GridViewUtil.CreateColumnForData(this.gridView6, typeof(DepartmentVo));
            GridViewUtil.CreateColumnForData(this.gridView7, typeof(StaffClassVo));

            RefreshStaff();
            RefreshLevel();
            RefreshDepartment();
            RefreshClass();


            UserRight instance = UserRight.GetInstance();
            foreach (Control ctr in this.Controls)
            {
                instance.CheckControl(ctr);
            }
        }
        private void FillComStatus()
        {
            comboStatus.Properties.Items.AddRange(new object[] { "所有技师", "空闲", "上钟", "请假" });
            comboStatus.SelectedIndex = 0;
        }
        private void RefreshWorkInfo()
        {
            List<StaffWorkInfoVo> voList=new List<StaffWorkInfoVo>();
            SelectDao.SelectData(ref voList);
            this.gridControl1.DataSource = voList;
            this.gridControl1.RefreshDataSource();
        }
        private void RefreshStaffPreBook()
        {
            preDataSource = SelectDao.SelectData(typeof(StaffPreBookVo));
            this.gridControl2.DataSource = preDataSource;
            this.gridControl2.RefreshDataSource();
        }
        #endregion

        #region 员工信息维护
        private void RefreshStaff()
        {
            List<StaffInfoVo> voList = new List<StaffInfoVo>();
            SelectDao.SelectData(ref voList);
            this.gridControl4.DataSource = voList;
            this.gridControl4.RefreshDataSource();
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddStaffForm addForm = new AddStaffForm();
            if(addForm.ShowDialog()==DialogResult.OK)
            {
                RefreshStaff();
                RefreshWorkInfo();
            }
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            StaffInfoVo vo = (StaffInfoVo)this.gridView4.GetRow(this.gridView4.FocusedRowHandle);
            if (vo == null)
                return;
            UpdateStaffForm updateForm = new UpdateStaffForm(vo);
            updateForm.ShowDialog();
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            StaffInfoVo vo = (StaffInfoVo)this.gridView4.GetRow(this.gridView4.FocusedRowHandle);
            if (vo == null)
                return;
            if (DeleteDao.DelStaffInfoByID(vo.StaffId) > 0)
            {
                XtraMessageBox.Show("删除成功");
                RefreshStaff();
            }
        }
        #endregion

        #region 员工级别维护
        private void RefreshLevel()
        {
            List<StaffLevelVo> voList = new List<StaffLevelVo>();
            SelectDao.SelectData(ref voList);
            this.gridControl5.DataSource = voList;
            this.gridControl5.RefreshDataSource();
        }
        private void BtnAddLevel_Click(object sender, EventArgs e)
        {
            AddStaffLevel addLevel = new AddStaffLevel();
            addLevel.ShowDialog();
        }

        private void BtnUpdateLevel_Click(object sender, EventArgs e)
        {
            StaffLevelVo vo = (StaffLevelVo)this.gridView5.GetRow(this.gridView5.FocusedRowHandle);
            if (vo == null)
                return;
            UpdateStaffLevel updateLevel = new UpdateStaffLevel(vo);
            updateLevel.ShowDialog();
        }

        private void BtnDelLevel_Click(object sender, EventArgs e)
        {
            StaffLevelVo vo = (StaffLevelVo)this.gridView5.GetRow(this.gridView5.FocusedRowHandle);
            if (vo == null)
                return;
            if (DeleteDao.DelStaffLevelByID(vo.Id) > 0)
            {
                XtraMessageBox.Show("删除成功");
                RefreshLevel();
            }
        }
        #endregion

        #region 员工班次维护
        private void RefreshClass()
        {
            List<StaffClassVo> voList = new List<StaffClassVo>();
            SelectDao.SelectData(ref voList);
            this.gridControl7.DataSource = voList;
            this.gridControl7.RefreshDataSource();
        }
        private void BtnAddClass_Click(object sender, EventArgs e)
        {
            AddStaffClassForm classForm = new AddStaffClassForm();
            classForm.ShowDialog();
        }

        private void BtnUpdateClass_Click(object sender, EventArgs e)
        {
            StaffClassVo vo = (StaffClassVo)this.gridView7.GetRow(this.gridView7.FocusedRowHandle);
            if (vo == null)
                return;
            UpdateStaffClassForm updateForm = new UpdateStaffClassForm(vo);
            updateForm.ShowDialog();
        }
        private void BtnDelClass_Click(object sender, EventArgs e)
        {
            StaffClassVo vo = (StaffClassVo)this.gridView7.GetRow(this.gridView7.FocusedRowHandle);
            if (vo == null)
                return;
            if (DeleteDao.DeleteByID(vo.StaffClassID, typeof(StaffClassVo)) > 0)
            {
                XtraMessageBox.Show("删除成功");
                RefreshClass();
            }
        }
        #endregion

        #region 员工状态维护
        private void BtnWorkUp_Click(object sender, EventArgs e)
        {
            StaffWorkInfoVo vo = (StaffWorkInfoVo)this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
            if (vo == null)
                return;
            if(UpdateDao.StaffWorkDown(vo.StaffID)>0)
            {
                RefreshWorkInfo();
                XtraMessageBox.Show("操作成功！");
            }
        }
        #endregion

        #region 部门维护
        private void RefreshDepartment()
        {
            List<DepartmentVo> voList = new List<DepartmentVo>();
            SelectDao.SelectData(ref voList);
            this.gridControl6.DataSource = voList;
            this.gridControl6.RefreshDataSource();
        }

        private void BtnAddDepartment_Click(object sender, EventArgs e)
        {
            AddDepartmentForm addDepartment = new AddDepartmentForm();
            addDepartment.ShowDialog();
        }
        private void BtnUpdateDepart_Click(object sender, EventArgs e)
        {
            DepartmentVo vo = (DepartmentVo)this.gridView6.GetRow(this.gridView6.FocusedRowHandle);
            UpdateDepartmentForm updateDepform = new UpdateDepartmentForm(vo);
            updateDepform.ShowDialog();
        }

        private void BtnDelDepart_Click(object sender, EventArgs e)
        {
            DepartmentVo vo = (DepartmentVo)this.gridView6.GetRow(this.gridView6.FocusedRowHandle);
            if (DeleteDao.DeleteByID(vo.Id, typeof(DepartmentVo)) > 0)
            {
                XtraMessageBox.Show("删除成功");
                RefreshDepartment();
            }
        }
        #endregion

        #region 员工轮钟顺序
        private void RefreshStaffQueue()
        {
            List<StaffQueueVo> voList = new List<StaffQueueVo>();
            SelectDao.SelectData(ref voList);
            this.gridControl3.DataSource = voList;
            this.gridControl3.RefreshDataSource();
        }
        private void BtnRandomQueue_Click(object sender, EventArgs e)
        {
            List<StaffInfoVo> infoList = new List<StaffInfoVo>();
            SelectDao.SelectData(ref infoList);
            List<StaffQueueVo> queueList = new List<StaffQueueVo>();
            for (int i = 1; i <= infoList.Count; ++i)
            {
                StaffInfoVo infoVo = infoList[i - 1];
                StaffQueueVo queueVo = new StaffQueueVo();
                queueVo.QueueId = i;
                queueVo.StaffID = infoVo.StaffId;
                queueVo.StaffName = infoVo.StaffName;
                queueVo.StaffSex = infoVo.StaffSex;
                queueList.Add(queueVo);
            }
            List<StaffQueueVo> newqueueList = RandomSortList(queueList);
            this.gridControl3.DataSource = newqueueList;
            this.gridControl3.RefreshDataSource();
            SaveStaffQueue(newqueueList);
        }

        private void BtnQueueDown_Click(object sender, EventArgs e)
        {
            List<StaffQueueVo> itemList = (List<StaffQueueVo>)this.gridView3.DataSource;
            StaffQueueVo item = (StaffQueueVo)this.gridView3.GetRow(this.gridView3.FocusedRowHandle);
            if (item == null)
                return;
            int index = itemList.IndexOf(item);
            if (index == itemList.Count - 1)
                return;

            itemList.RemoveAt(index);
            itemList.Insert(index + 1, item);
            ReSortList(ref itemList);
            this.gridView3.FocusedRowHandle = index + 1;
            this.gridControl3.RefreshDataSource();
            SaveStaffQueue(itemList);
        }

        private void BtnQueueUp_Click(object sender, EventArgs e)
        {
            List<StaffQueueVo> itemList = (List<StaffQueueVo>)this.gridView3.DataSource;
            StaffQueueVo item = (StaffQueueVo)this.gridView3.GetRow(this.gridView3.FocusedRowHandle);
            if (item == null)
                return;
            int index = itemList.IndexOf(item);
            if (index == 0)
                return;

            itemList.RemoveAt(index);
            itemList.Insert(index - 1, item);
            ReSortList(ref itemList);
            this.gridView3.FocusedRowHandle = index - 1;
            this.gridControl3.RefreshDataSource();
            SaveStaffQueue(itemList);
        }
        private void BtnQueueLast_Click(object sender, EventArgs e)
        {
            List<StaffQueueVo> itemList = (List<StaffQueueVo>)this.gridView3.DataSource;
            StaffQueueVo item = (StaffQueueVo)this.gridView3.GetRow(this.gridView3.FocusedRowHandle);
            if (item == null)
                return;

            itemList.Remove(item);
            itemList.Add(item);

            ReSortList(ref itemList);
            this.gridView3.FocusedRowHandle = itemList.Count - 1;
            this.gridControl3.RefreshDataSource();
            SaveStaffQueue(itemList);
        }

        private void BtnQueueFirst_Click(object sender, EventArgs e)
        {
            List<StaffQueueVo> itemList = (List<StaffQueueVo>)this.gridView3.DataSource;
            StaffQueueVo item = (StaffQueueVo)this.gridView3.GetRow(this.gridView3.FocusedRowHandle);
            if (item == null)
                return;
            itemList.Remove(item);
            itemList.Insert(0, item);

            ReSortList(ref itemList);
            this.gridView3.FocusedRowHandle = 0;
            this.gridControl3.RefreshDataSource();
            SaveStaffQueue(itemList);
        }
        private void SaveStaffQueue(List<StaffQueueVo> newqueueList)
        {
            //先删除之前的
            DeleteDao.DeleteStaffQueue();
            foreach (StaffQueueVo vo in newqueueList)
            {
                InsertDao.InsertData(vo, typeof(StaffQueueVo));
            }
        }

        //重新排序
        private void ReSortList(ref List<StaffQueueVo> ListT)
        {
            for (int i = 1; i <= ListT.Count; ++i)
            {
                StaffQueueVo vo = ListT[i - 1];
                vo.QueueId = i;
            }
        }
        //对一个List进行随机排序
        private List<StaffQueueVo> RandomSortList(List<StaffQueueVo> ListT)
        {
            Random random = new Random();
            List<StaffQueueVo> newList = new List<StaffQueueVo>();
            for (int i = 1; i <= ListT.Count; ++i)
            {
                StaffQueueVo item = ListT[i - 1];
                StaffQueueVo newItem = new StaffQueueVo();
                newItem.QueueId = i;
                newItem.StaffID = item.StaffID;
                newItem.StaffName = item.StaffName;
                newItem.StaffSex = item.StaffSex;
                newList.Insert(random.Next(newList.Count + 1), item);
            }
            for (int j = 1; j <= newList.Count; j++)
            {
                StaffQueueVo item = newList[j - 1];
                item.QueueId = j;
            }
            return newList;
        }
        #endregion

        #region eventbus
        [EventAttr("AddLevelSuccessed")]
        public void AddLevelSuccessed()
        {
            RefreshLevel();
        }
        [EventAttr("AddDepartmentSuccessed")]
        public void AddDepartmentSuccessed()
        {
            RefreshDepartment();
        }
        [EventAttr("AddClassSuccessed")]
        public void AddClassSuccessed()
        {
            RefreshClass();
        }
        [EventAttr("AddStaffSuccessed")]
        public void AddStaffSuccessed()
        {
            RefreshStaff();
        }
        [EventAttr("AddStaffWorkSuccessed")]
        public void AddStaffWorkSuccessed()
        {
            RefreshWorkInfo();
        }
        #endregion

        #region events
        private void ComboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboStatus.SelectedIndex == 0)
            {
                RefreshWorkInfo();
            }
            else
            {
                List<StaffWorkInfoVo> voList =  (List<StaffWorkInfoVo>)this.gridControl1.DataSource;
                voList = voList.Where(v => v.StaffStatus == comboStatus.Text).ToList();
                this.gridControl1.RefreshDataSource();
            }
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.textName.Text))
            {
                XtraMessageBox.Show("姓名不能为空!");
                return;
            }
            DataTable dt = SelectDao.SelectStaffWorkByName(this.textName.Text);
        }

        private void BtnPai_Click(object sender, EventArgs e)
        {

        }
        private void StaffMainNewUI_Load(object sender, EventArgs e)
        {
            RefreshWorkInfo();
            RefreshStaffPreBook();
            RefreshStaffQueue();
            FillComStatus();
        }
        #endregion
    }
}
