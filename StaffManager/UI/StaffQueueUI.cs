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
    public partial class StaffQueueUI : BaseInfoUI
    {
        public StaffQueueUI()
        {
            InitializeComponent();
            ShowQueueButton();
            GridViewUtil.InitGridView(this.gridView1, typeof(StaffQueueVo));
            RefreshStaffQueue();
        }

        private void RefreshStaffQueue()
        {
            List<StaffQueueVo> voList = SelectDao.SelectData<StaffQueueVo>();
            this.gridControl1.DataSource = voList;
            this.gridControl1.RefreshDataSource();
        }
        protected override void BtnRandomQueue_Click(object sender, EventArgs e)
        {
            List<StaffInfoVo> infoList = SelectDao.SelectData<StaffInfoVo>();
            List<StaffQueueVo> queueList = new List<StaffQueueVo>();
            for (int i = 1; i <= infoList.Count; ++i)
            {
                StaffInfoVo infoVo = infoList[i - 1];
                StaffQueueVo queueVo = new StaffQueueVo();
                queueVo.QueueId = i;
                queueVo.StaffID = infoVo.StaffId;
                queueVo.StaffName = infoVo.StaffName;
                queueVo.StaffSex = infoVo.StaffSex;
                queueVo.CompanyId = infoVo.CompanyId;
                queueList.Add(queueVo);
            }
            List<StaffQueueVo> newqueueList = RandomSortList(queueList);
            this.gridControl1.DataSource = newqueueList;
            this.gridControl1.RefreshDataSource();
            SaveStaffQueue(newqueueList);
        }

        protected override void BtnQueueDown_Click(object sender, EventArgs e)
        {
            List<StaffQueueVo> itemList = (List<StaffQueueVo>)this.gridView1.DataSource;
            StaffQueueVo item = (StaffQueueVo)this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
            if (item == null)
                return;
            int index = itemList.IndexOf(item);
            if (index == itemList.Count - 1)
                return;

            itemList.RemoveAt(index);
            itemList.Insert(index + 1, item);
            ReSortList(ref itemList);
            this.gridView1.FocusedRowHandle = index + 1;
            this.gridControl1.RefreshDataSource();
            SaveStaffQueue(itemList);
        }

        protected override void BtnQueueUp_Click(object sender, EventArgs e)
        {
            List<StaffQueueVo> itemList = (List<StaffQueueVo>)this.gridView1.DataSource;
            StaffQueueVo item = (StaffQueueVo)this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
            if (item == null)
                return;
            int index = itemList.IndexOf(item);
            if (index == 0)
                return;

            itemList.RemoveAt(index);
            itemList.Insert(index - 1, item);
            ReSortList(ref itemList);
            this.gridView1.FocusedRowHandle = index - 1;
            this.gridControl1.RefreshDataSource();
            SaveStaffQueue(itemList);
        }
        protected override void BtnQueueLast_Click(object sender, EventArgs e)
        {
            List<StaffQueueVo> itemList = (List<StaffQueueVo>)this.gridView1.DataSource;
            StaffQueueVo item = (StaffQueueVo)this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
            if (item == null)
                return;

            itemList.Remove(item);
            itemList.Add(item);

            ReSortList(ref itemList);
            this.gridView1.FocusedRowHandle = itemList.Count - 1;
            this.gridControl1.RefreshDataSource();
            SaveStaffQueue(itemList);
        }

        protected override void BtnQueueFirst_Click(object sender, EventArgs e)
        {
            List<StaffQueueVo> itemList = (List<StaffQueueVo>)this.gridView1.DataSource;
            StaffQueueVo item = (StaffQueueVo)this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
            if (item == null)
                return;
            itemList.Remove(item);
            itemList.Insert(0, item);

            ReSortList(ref itemList);
            this.gridView1.FocusedRowHandle = 0;
            this.gridControl1.RefreshDataSource();
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
    }
}
