using System;
using System.Collections.Generic;
using System.Data;
using ClientCenter.Core;
using ClientCenter.Event;
using ClientCenter.DB;
using DevExpress.XtraTreeList.Nodes;
using ClientCenter.Enity;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using System.Linq;
using System.Windows.Forms;
using ClientCenter.GridViews;

namespace MemberManager.UI
{
    public partial class MemberInfoUI : DevExpress.XtraEditors.XtraUserControl
    {
        List<MemberInfoVo> memberVoList = new List<MemberInfoVo>();
        List<string> cardNameList = new List<string>();

        public MemberInfoUI()
        {
            EventBus.RegisterEvent(this);
            InitializeComponent();
            InitEvents();
            SetMemberInfoGrid();
        }

        private void SetMemberInfoGrid()
        {
            GridViewUtil.InitGridView(this.gridView1, typeof(MemberInfoVo));
            //RepositoryItemComboBox repositoryItemComboStatus = new RepositoryItemComboBox();
            //RepositoryItemComboBox repositoryItemComboLevel = new RepositoryItemComboBox();
            //repositoryItemComboStatus.BeginInit();
            //repositoryItemComboLevel.BeginInit();
            //repositoryItemComboStatus.TextEditStyle = TextEditStyles.DisableTextEditor;
            //repositoryItemComboLevel.TextEditStyle = TextEditStyles.DisableTextEditor;
            //gridControl1.RepositoryItems.AddRange(new RepositoryItem[] { repositoryItemComboStatus, repositoryItemComboLevel });

            //repositoryItemComboStatus.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            //repositoryItemComboLevel.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            ////填充状态
            //repositoryItemComboStatus.Items.AddRange(new string[] { "正常", "停止", "挂失" });
            ////填充会员级别
            //List<CardVo> cardDaoList = SelectDao.SelectData<CardVo>();
            //foreach (CardVo vo in cardDaoList)
            //{
            //    repositoryItemComboLevel.Items.Add(vo.CardName);
            //}

            //this.gridView1.Columns["MStatus"].ColumnEdit = repositoryItemComboStatus;
            //this.gridView1.Columns["CardName"].ColumnEdit = repositoryItemComboLevel;
           
            //repositoryItemComboLevel.EndInit();
            //repositoryItemComboStatus.EndInit();

            RefreshMember();
        }
        private void InitEvents()
        {
            this.Load += MemberInfoUI_Load;
            this.treeList1.FocusedNodeChanged += TreeList1_FocusedNodeChanged;
            this.btnAdd.Click += BtnAdd_Click;
            this.btnDel.Click += BtnDel_Click;
            this.btnSave.Click += BtnSave_Click;
        }

        private bool CheckParam(List<MemberInfoVo> voList)
        {
            foreach (MemberInfoVo vo in voList)
            {
                if (string.IsNullOrWhiteSpace(vo.MName))
                {
                    XtraMessageBox.Show("会员名称不能为空！");
                    return false;
                }
            }
            var list = voList.GroupBy(v => v.MName).Where(v => v.Count() > 1).ToList();
            if (list.Count > 0)
            {
                XtraMessageBox.Show("会员名称不能相同！");
                return false;
            }
            return true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            MemberInfoVo updateVo = (MemberInfoVo)this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
            MemberOperationFrm operationFrm = new MemberOperationFrm(updateVo);
            if (operationFrm.ShowDialog() == DialogResult.OK)
            {
                RefreshMember();
            }
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            MemberInfoVo vo = (MemberInfoVo)this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
            if (vo == null)
                return;
            memberVoList.Remove(vo);
            if(DeleteDao.DeleteByID(vo, typeof(MemberInfoVo))>0)
            {
                XtraMessageBox.Show("删除会员失败!");
            }
            this.gridControl1.RefreshDataSource();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            MemberOperationFrm operationFrm = new MemberOperationFrm();
            if(operationFrm.ShowDialog()==DialogResult.OK)
            {
                RefreshMember();
            }
        }

        private void TreeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node.ParentNode == null)
            {
                RefreshMember();
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
            RefreshCardLevel();
            RefreshMember();
        }

        private void RefreshCardLevel()
        {
            DataTable dt = SelectDao.GetCardName();
            this.treeList1.BeginUnboundLoad();
            TreeListNode parentNode = this.treeList1.AppendNode(new object[] { "所有会员" }, -1);
            foreach (DataRow dr in dt.Rows)
            {
                string level = dr[0].ToString();
                cardNameList.Add(level);
                this.treeList1.AppendNode(new object[] { level }, parentNode);
            }
            this.treeList1.EndUnboundLoad();
        }

        private void RefreshMember()
        {
            memberVoList.Clear();
            memberVoList = SelectDao.SelectData<MemberInfoVo>();
            this.gridControl1.DataSource = memberVoList;
            this.gridControl1.RefreshDataSource();

            this.gridView1.BestFitColumns();
        }
    }
}
