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
using ClientCenter.DB;
using ClientCenter.Event;
using ClientCenter.Enity;

namespace FootManager.UI
{
    public partial class UserForm : DevExpress.XtraEditors.XtraForm
    {
        UserRoleVo userVo;
        public UserForm(UserRoleVo userVo=null)
        {
            InitializeComponent();
            InitEvents();
            this.userVo = userVo;
        }

        private void InitEvents()
        {
            this.Load += AddUserForm_Load;
            this.btnAdd.Click += BtnAdd_Click;
            this.btnCancel.Click += BtnCancel_Click;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(this.textUserName.Text)||string.IsNullOrWhiteSpace(this.comMode.Text)||string.IsNullOrWhiteSpace(this.textPassword.Text))
                XtraMessageBox.Show("请填写完整信息!");
            else
            {
                //更新
                if(userVo!=null)
                {
                    userVo.Name = this.textUserName.Text;
                    userVo.Role = this.comMode.Text;
                    userVo.Psword = this.textPassword.Text;
                    UpdateDao.UpdateByID(userVo);
                    XtraMessageBox.Show("保存成功!");
                    this.DialogResult = DialogResult.OK;
                    return;
                }
                //新增
                UserRoleVo vo = new UserRoleVo() { Name = this.textUserName.Text, Role = this.comMode.Text, Psword = this.textPassword.Text };
                if (SelectDao.IsUserExist(vo.Name))
                {
                    XtraMessageBox.Show("该用户已经存在!");
                    return;
                }
                if (InsertDao.InsertData(vo, typeof(UserRoleVo)) > 0)
                {
                    XtraMessageBox.Show("保存成功!");
                    this.DialogResult=DialogResult.OK;
                    return;
                }
            }
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {
            FillComMode();
            if(userVo != null)
            {
                this.textUserName.Text = userVo.Name;
                this.comMode.Text = userVo.Role;
                this.textPassword.Text = userVo.Psword;
            }
        }

        private void FillComMode()
        {
            List<PermissionVo> voList = new List<PermissionVo>();
            DataTable dt = SelectDao.GetPermission();
            foreach(DataRow dr in dt.Rows)
            {
                comMode.Properties.Items.Add(dr[0].ToString());
            }
        }
    }
}