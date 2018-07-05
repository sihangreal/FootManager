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
using ClientCenter.Core;
using StaffManager.Enity;
using ClientCenter.DB;
using ClientCenter.Enity;

namespace StaffManager.UI
{
    public partial class ServerForm : DevExpress.XtraEditors.XtraForm
    {
        Type type;
        //ServerSkillForm shipForm;

        public ServerForm(Type type)
        {
            InitializeComponent();
            InitEvents();
            this.type = type;
        }

        #region private method
        private void InitEvents()
        {
            this.Load += ServerForm_Load;
            this.btnAdd.Click += BtnAdd_Click;
            this.btnAddSkill.ItemClick += BtnAddSkill_ItemClick;
            this.gridView1.MouseUp += GridView1_MouseUp;
        }
        private void FillTime()
        {
            this.comTime.Properties.Items.AddRange(new string[] { "30分钟","60分钟","90分钟","120分钟"});
        }
        #endregion

        #region events
        private void ServerForm_Load(object sender, EventArgs e)
        {
            GridViewUtil.CreateColumnForData(this.gridView1, type);
            FillTime();
            List<ServerVo> severVoList = new List<ServerVo>();
            SelectDao.SelectData(ref severVoList);
            this.gridControl1.DataSource = severVoList;
            this.gridControl1.RefreshDataSource();
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            //ServerVo serverVo = new ServerVo()
            //{
            //    ServerName = this.textServer.Text,
            //    Price = Convert.ToDouble(this.textPrice.Text),
            //    ServerTime=this.comTime.Text
            //};
            //if(InsertDao.InsertData(serverVo,typeof(ServerVo))>0)
            //{
            //    DataTable dt=SelectDao.GetServerByName(this.textServer.Text);
            //    DataRow dr = dt.Rows[0];
            //    ServerVo vo = new ServerVo()
            //    {
            //        ServerId= Convert.ToInt32(dr["ServerId"]),
            //        ServerName = dr["ServerName"].ToString(),
            //        Price = Convert.ToDouble(dr["Price"]),
            //        ServerTime = dr["ServerTime"].ToString()
            //    };
            //    List<SeverVo> serverList = (List<SeverVo>)this.gridControl1.DataSource;
            //    serverList.Add(vo);
            //    this.gridControl1.RefreshDataSource();
            //}
        }
        private void BtnAddSkill_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //SeverVo vo = (SeverVo)this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
            //ServerSkillForm  shipForm = new ServerSkillForm(typeof(ServerSkillVo)) { ServerId = vo.ServerId, ServerName = vo.ServerName };
            //shipForm.ShowDialog();
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