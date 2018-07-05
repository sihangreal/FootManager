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
using ClientCenter.Enity;
using ClientCenter.DB;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;

namespace ClockRoomManager.UI
{
    public partial class AddOrderForm : DevExpress.XtraEditors.XtraForm
    {
        List<RoomVo> roomList = new List<RoomVo>();
        List<RoomVo> selectedList = new List<RoomVo>();

        public AddOrderForm()
        {
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            this.Load += AddOrderForm_Load;
            this.btnAdd.Click += BtnAdd_Click;
            this.btnDel.Click += BtnDel_Click;
            this.btnOpenOder.Click += BtnOpenOder_Click;
            this.btnCancel.Click += BtnCancel_Click;
        }

        #region events
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnOpenOder_Click(object sender, EventArgs e)
        {
            string memberId = this.textMemberId.Text;
            if (!SelectDao.IsMemberExist(memberId))
            {
                XtraMessageBox.Show("该会员不存在!");
                return;
            }
            foreach(RoomVo vo in selectedList)
            {
                OrderInfoVo orderVo = new OrderInfoVo();
                orderVo.RoomID = vo.RoomId;
                orderVo.Remark = this.memoRemark.Text;
                orderVo.StartTime = DateTime.Now.ToString();
            }
        }
        private void BtnDel_Click(object sender, EventArgs e)
        {
            TreeListNode node = this.treeList2.FocusedNode;
            if (node == null)
                return;
            var roomName = node.GetValue(0);
            this.treeList1.AppendNode(new object[] { roomName }, -1);
            
            this.treeList2.DeleteNode(node);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            TreeListNode node=this.treeList1.FocusedNode;
            if (node == null)
                return;
            string roomName= node.GetValue(0).ToString();
            this.treeList2.AppendNode(new object[] { roomName},-1);
            RoomVo selectVo = roomList.Where(v => v.RoomName == roomName).FirstOrDefault();
            selectedList.Add(selectVo);
            this.treeList1.DeleteNode(node);
        }

        private void AddOrderForm_Load(object sender, EventArgs e)
        {
            SelectDao.SelectData<RoomVo>(ref roomList);
            foreach(RoomVo vo in roomList)
            {
                if(vo.RoomStatus.Equals("空闲"))
                    this.treeList1.AppendNode(new object[] {vo.RoomName },-1);
            }
        }
        #endregion
    }
}