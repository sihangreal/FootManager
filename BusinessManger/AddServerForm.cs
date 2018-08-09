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
using ClientCenter.Core;
using ClientCenter.DB;
using ClientCenter.Event;
using ClientCenter.GridViews;

namespace BusinessManger
{
    public partial class AddServerForm : DevExpress.XtraEditors.XtraForm
    {
        private List<SkillVo> skillVoList = new List<SkillVo>();
        private string proname;

        public AddServerForm(string proname)
        {
            this.proname = proname;
            InitializeComponent();
            GridViewUtil.InitGridView(gridView1, typeof(ServerVo));
            InitEvents();
        }

        private void InitEvents()
        {
            this.Load += AddServerForm_Load;
            this.btnAdd.Click += BtnAdd_Click;
            this.btnCancel.Click += BtnCancel_Click;
            this.gridView1.SelectionChanged += GridView1_SelectionChanged;
        }

        private void GridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            SkillVo vo = (SkillVo)this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
            if (e.Action == CollectionChangeAction.Add)
                skillVoList.Add(vo);
            else if (e.Action == CollectionChangeAction.Remove)
                skillVoList.Remove(vo);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.textName.Text) || skillVoList.Count <= 0)
            {
                XtraMessageBox.Show("请将信息填写完整!");
                return;
            }
            foreach (SkillVo skill in skillVoList)
            {
                ServerVo vo = new ServerVo() { ServerName = this.textName.Text, SkillId = skill.SkillId, SkillName = skill.SkillName ,CompanyId=SystemConst.companyId};
                InsertDao.InsertData(vo, typeof(ServerVo));
            }
            XtraMessageBox.Show("添加项目成功!");
            EventBus.PublishEvent("AddServerSuccessed");
        }

        private void AddServerForm_Load(object sender, EventArgs e)
        {
            this.textName.Text = proname;
            FillSKill();
        }

        private void FillSKill()
        {
            List<SkillVo> voList = SelectDao.SelectData<SkillVo>();
            this.gridControl1.DataSource = voList;
            this.gridControl1.RefreshDataSource();

            //this.gridView1.Columns["SkillId"].Visible = false;
            //this.gridView1.Columns["SecondName"].Visible = false;
            //this.gridView1.Columns["ServerTime"].Visible = false;
            //this.gridView1.Columns["Remark"].Visible = false;
        }
    }
}