using System;
using System.Collections.Generic;
using System.Data;
using ClientCenter.Core;
using ClientCenter.Event;
using ClientCenter.DB;
using DevExpress.XtraTreeList.Nodes;
using ClientCenter.Enity;

namespace MemberManager.UI
{
    public partial class MemberInfoUI : DevExpress.XtraEditors.XtraUserControl
    {
        List<MemberInfoVo> memberVoList = new List<MemberInfoVo>();

        public MemberInfoUI()
        {
            EventBus.RegisterEvent(this);
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            this.Load += MemberInfoUI_Load;
            this.treeList1.FocusedNodeChanged += TreeList1_FocusedNodeChanged;
        }

        private void TreeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node.ParentNode == null)
            {
                FillMember();
            }
            else
            {
                string level = e.Node.GetValue(0).ToString();
                DataTable dt = SelectDao.GetMemberGroupByLevel(level);
                this.gridControl1.DataSource = dt;
                this.gridControl1.RefreshDataSource();
            }
        }

        private void MemberInfoUI_Load(object sender, EventArgs e)
        {
            GridViewUtil.CreateColumnForData(this.gridView1, typeof(MemberInfoVo));

            FillCardLevel();
            FillMember();
        }

        private void FillCardLevel()
        {
            DataTable dt = SelectDao.GetCardName();
            this.treeList1.BeginUnboundLoad();
            TreeListNode parentNode = this.treeList1.AppendNode(new object[] { "所有会员" }, -1);
            foreach (DataRow dr in dt.Rows)
            {
                string level = dr[0].ToString();
                this.treeList1.AppendNode(new object[] { level }, parentNode);
            }
            this.treeList1.EndUnboundLoad();
        }

        private void FillMember()
        {
            memberVoList.Clear();
            memberVoList = SelectDao.SelectData<MemberInfoVo>();
            this.gridControl1.DataSource = memberVoList;
            this.gridControl1.RefreshDataSource();

            this.gridView1.BestFitColumns();
        }

        //增加会员
        [EventAttr("AddMemberSuccess")]
        public void AddMemberSuccess()
        {
            FillMember();
        }
    }
}
