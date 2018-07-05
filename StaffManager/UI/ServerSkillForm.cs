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
using StaffManager.Enity;
using ClientCenter.DB;
using ClientCenter.Core;
using ClientCenter.Enity;

namespace StaffManager.UI
{
    public partial class ServerSkillForm : DevExpress.XtraEditors.XtraForm
    {
        Type type;
        List<SkillVo> skillVoList;
        int serverId;
        public int ServerId
        {
            get { return serverId; }
            set { serverId = value; }
        }
        string serverName;
        public string ServerName
        {
            get { return serverName; }
            set { serverName = value; }
        }
        public ServerSkillForm(Type type)
        {
            this.type = type;
            InitializeComponent();
            InitEvents();
        }
        #region private method
        private void InitEvents()
        {
            this.Load += ServerSkillForm_Load;
            this.btnAdd.Click += BtnAdd_Click;
            this.gridView1.MouseUp += GridView1_MouseUp;
        }
        private void FillSkill()
        {
            skillVoList = new List<SkillVo>();
            SelectDao.SelectData(ref skillVoList);
            foreach (SkillVo vo in skillVoList)
            {
                this.comSkill.Properties.Items.Add(vo.SkillName);
            }
        }
        #endregion

        #region events
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            int id = skillVoList.Where(v=>v.SkillName==this.comSkill.Text).FirstOrDefault().SkillId;
            ServerSkillVo shipVo = new ServerSkillVo()
            {
                ServerName = serverName,
                ServerId = serverId,
                SkillId = id,
                SkillName = this.comSkill.Text
            };
            if (InsertDao.InsertData(shipVo, typeof(ServerSkillVo)) > 0)
            {
                List<ServerSkillVo> voList = (List<ServerSkillVo>)this.gridView1.DataSource;
                voList.Add(shipVo);
                this.gridControl1.RefreshDataSource();
            }
        }
        private void ServerSkillForm_Load(object sender, EventArgs e)
        {
            GridViewUtil.CreateColumnForData(this.gridView1, this.type);
            this.gridView1.Columns["ServerName"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            FillSkill();
            DataTable dt=SelectDao.GetServerShipByID(this.ServerId);
            List<ServerSkillVo> shipVoList = new List<ServerSkillVo>(); 
            foreach(DataRow dr in dt.Rows)
            {
                ServerSkillVo shipVo = new ServerSkillVo()
                {
                    ServerId = serverId,
                    ServerName = serverName,
                    SkillId=Convert.ToInt32(dr["skillId"]),
                    SkillName = dr["skillName"].ToString()
                };
                shipVoList.Add(shipVo);
            }
            this.gridControl1.DataSource = shipVoList;
            this.gridControl1.RefreshDataSource();
        }
        private void GridView1_MouseUp(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = this.gridView1.CalcHitInfo(e.Location);
            if (hi.InRow && e.Button == MouseButtons.Right)
            {
                this.popupMenu1.ShowPopup(Control.MousePosition);
            }
        }
        #endregion
    }
}