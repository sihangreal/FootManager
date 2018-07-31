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
using ClientCenter.DB;
using ClientCenter.Enity;
using ClientCenter.GridViews;

namespace FootManager.UI
{
    public partial class OperatSetting : DevExpress.XtraEditors.XtraUserControl
    {
        public OperatSetting()
        {
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            this.Load += OperatSetting_Load;
            this.btnAddPermission.Click += BtnAddPermission_Click;
            this.btnModifyPermission.Click += BtnModifyPermission_Click;
            this.btnDelPermission.Click += BtnDelPermission_Click;

            this.btnUser.Click += BtnUser_Click;
            this.btnDelUser.Click += BtnDelUser_Click;
            this.btnUpdateUser.Click += BtnUpdateUser_Click;
        }

        #region 权限组操作
        private void BtnAddPermission_Click(object sender, EventArgs e)
        {
            PermissionForm form = new PermissionForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                FillPermission();
            }
        }

        private void BtnModifyPermission_Click(object sender, EventArgs e)
        {
            PermissionVo vo = (PermissionVo)this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
            if (vo == null)
                return;
            PermissionForm form = new PermissionForm(vo);
            if (form.ShowDialog() == DialogResult.OK)
            {
                FillPermission();
            }
        }
        private void BtnDelPermission_Click(object sender, EventArgs e)
        {
            PermissionVo vo = (PermissionVo)this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
            if (vo == null)
                return;
            if (DeleteDao.DelPermissionByName(vo.Name) < 0)
            {
                XtraMessageBox.Show("操作失败!");
                return;
            }
            else
                FillPermission();
        }
        private void FillPermission()
        {
            List<PermissionVo> voList = SelectDao.SelectData<PermissionVo>();
            this.gridControl1.DataSource = voList;
            this.gridControl1.RefreshDataSource();
        }
        #endregion

        #region 用户操作
        private void BtnUpdateUser_Click(object sender, EventArgs e)
        {
            UserRoleVo vo = (UserRoleVo)this.gridView2.GetRow(this.gridView2.FocusedRowHandle);
            if (vo == null)
                return;
            UserForm form = new UserForm(vo);
            if (form.ShowDialog() == DialogResult.OK)
            {
                FillUser();
            }
        }

        private void BtnDelUser_Click(object sender, EventArgs e)
        {
            UserRoleVo vo = (UserRoleVo)this.gridView2.GetRow(this.gridView2.FocusedRowHandle);
            if (vo == null)
                return;
            if(DeleteDao.DeleteByID(vo.Id,typeof(UserRoleVo))>0)
            {
                XtraMessageBox.Show("删除成功！");
                FillUser();
            }
        }

        private void BtnUser_Click(object sender, EventArgs e)
        {
            UserForm form = new UserForm();
            if(form.ShowDialog()==DialogResult.OK)
            {
                FillUser();
            }
        }
        private void FillUser()
        {
            List<UserRoleVo> voList = SelectDao.SelectData<UserRoleVo>();
            this.gridControl2.DataSource = voList;
            this.gridControl2.RefreshDataSource();
        }
        #endregion

        private void OperatSetting_Load(object sender, EventArgs e)
        {
            GridViewUtil.InitGridView(this.gridView1, typeof(PermissionVo));
            GridViewUtil.InitGridView(this.gridView2,typeof(UserRoleVo));
           
            this.gridView2.Columns["Psword"].Visible = false;
            this.gridView2.Columns["Id"].Visible = false;
            FillPermission();
            FillUser();

            UserRight instance = UserRight.GetInstance();
            foreach (Control ctr in this.Controls)
            {
                instance.CheckControl(ctr);
            }
        }
    }
}
