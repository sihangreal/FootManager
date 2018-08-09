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
using ClientCenter.Core;

namespace FootManager.UI
{
    public partial class PermissionForm : DevExpress.XtraEditors.XtraForm
    {
        PermissionVo vo;
        DataTable dataSrouce= new DataTable();
        List<string> modeList = new List<string>();

        public PermissionForm(PermissionVo vo=null)
        {
            InitializeComponent();
            InitEvents();
            this.vo = vo;
        }

        private void InitTable()
        {
            dataSrouce.Columns.Add("Mode");

            dataSrouce.Rows.Add("添加会员卡");
            dataSrouce.Rows.Add("删除会员卡");
            dataSrouce.Rows.Add("修改会员卡");

            dataSrouce.Rows.Add("添加权限组");
            dataSrouce.Rows.Add("删除权限组");
            dataSrouce.Rows.Add("修改权限组");

            dataSrouce.Rows.Add("添加用户");
            dataSrouce.Rows.Add("删除用户");
            dataSrouce.Rows.Add("修改用户");

            dataSrouce.Rows.Add("添加项目");
            dataSrouce.Rows.Add("删除项目");
            dataSrouce.Rows.Add("修改项目");

            dataSrouce.Rows.Add("添加服务");
            dataSrouce.Rows.Add("删除服务");
            dataSrouce.Rows.Add("修改服务");

            dataSrouce.Rows.Add("添加员工");
            dataSrouce.Rows.Add("删除员工");
            dataSrouce.Rows.Add("修改员工");

            dataSrouce.Rows.Add("添加员工级别");
            dataSrouce.Rows.Add("删除员工级别");
            dataSrouce.Rows.Add("修改员工级别");

            dataSrouce.Rows.Add("添加部门");
            dataSrouce.Rows.Add("删除部门");
            dataSrouce.Rows.Add("修改部门");

            dataSrouce.Rows.Add("添加班次");
            dataSrouce.Rows.Add("删除班次");
            dataSrouce.Rows.Add("修改班次");

            this.gridControl1.DataSource = dataSrouce;
            this.gridControl1.RefreshDataSource();
        }

        private void InitEvents()
        {
            this.Load += AddPermissionForm_Load;
            this.btnSave.Click += BtnSave_Click;
            this.btnCancel.Click += BtnCancel_Click;
            this.gridView1.SelectionChanged += GridView1_SelectionChanged;
        }

        bool bcheckAll = false;
        private void GridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            DataRow dr = this.gridView1.GetDataRow(this.gridView1.FocusedRowHandle);
            if (e.Action == CollectionChangeAction.Add)
                modeList.Add(dr[0].ToString());
            else if (e.Action == CollectionChangeAction.Remove)
                modeList.Remove(dr[0].ToString());
            else
            {
                if(!bcheckAll)
                {
                    bcheckAll = true;
                    foreach (DataRow info in dataSrouce.Rows)
                    {
                        modeList.Add(info[0].ToString());
                    }
                }
                else
                {
                    bcheckAll = false;
                    foreach (DataRow info in dataSrouce.Rows)
                    {
                        modeList.Remove(info[0].ToString());
                    }
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.textName.Text) || modeList.Count <= 0)
                XtraMessageBox.Show("请填写完整信息!");
            if(vo!=null)
            {
                if (DeleteDao.DelPermissionByName(vo.Name) < 1)
                {
                    XtraMessageBox.Show("操作失败!");
                    return;
                }
            }
             foreach(string name in modeList)
            {
                PermissionVo vo = new PermissionVo() { Name=this.textName.Text,ModeName =name, CompanyId = SystemConst.companyId };
                InsertDao.InsertData(vo, typeof(PermissionVo));
            }
            XtraMessageBox.Show("保存权限组成功!");
            this.DialogResult = DialogResult.OK;
        }

        private void AddPermissionForm_Load(object sender, EventArgs e)
        {
            InitTable();
            if(vo!=null)
            {
                this.textName.Text = vo.Name;
                DataTable dt = SelectDao.GetPermissionByName(vo.Name);

                ////比较两个数据源的交集
                //IEnumerable<DataRow> query2 = dt.AsEnumerable().Intersect(dataSrouce.AsEnumerable(), DataRowComparer.Default);
                ////两个数据源的交集集合      
                //DataTable dt3 = query2.CopyToDataTable();
                
                //将已经有的勾选上
                for (int i =0;i< dataSrouce.Rows.Count;++i)
                {
                    string modeName = dataSrouce.Rows[i][0].ToString();
                    foreach (DataRow dr in dt.Rows)
                    {
                        string compareName = dr[0].ToString();
                        if(modeName.Equals(compareName))
                        {
                            this.gridView1.SelectRow(i);
                            modeList.Add(compareName);
                        }
                    }
                } 
            }
        }

    }
}