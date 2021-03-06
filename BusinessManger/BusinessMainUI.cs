﻿using System;
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
using ClientCenter.Enity;
using ClientCenter.Event;
using ClientCenter.DB;
using ClientCenter.GridViews;

namespace BusinessManger
{
    public partial class BusinessMainUI : DevExpress.XtraEditors.XtraUserControl
    {
        public BusinessMainUI()
        {
            EventBus.RegisterEvent(this);
            InitializeComponent();
            InitEvents();
            GridViewUtil.InitGridView(this.gridView1, typeof(SkillVo));
            //GridViewUtil.CreateColumnForData(this.gridView2, typeof(ServerVo));
            GridViewUtil.InitGridView(this.gridView3, typeof(SkillPriceVo));
            GridViewUtil.InitGridView(this.gridView4, typeof(SkillCommisionVo));
            //GridViewUtil.InitGridView(this.gridView2,typeof(WorkTypeVo));
        }

        private void InitEvents()
        {
            this.Load += SkillSettingNew_Load;
            //服务
            this.btnAddSever.Click += BtnAddSever_Click;
            this.btnDelSever.Click += BtnDelSever_Click;
            this.btnUpdateSever.Click += BtnUpdateSever_Click;
            this.gridView1.RowClick += GridView1_RowClick;
            //项目
            //this.btnAddProject.Click += BtnAddProject_Click;
            //this.btnDelProject.Click += BtnDelProject_Click;
            //价格
            this.btnAddPrice.Click += BtnAddPrice_Click;
            this.btnUpdatePrice.Click += BtnUpdatePrice_Click;
            this.btnDelPrice.Click += BtnDelPrice_Click;
            this.gridView3.RowClick += GridView3_RowClick;
            //提成
            this.btnAddT.Click += BtnAddT_Click;
            this.btnUpdateT.Click += BtnUpdateT_Click;
            this.btnDelT.Click += BtnDelT_Click;
            this.gridView4.RowClick += GridView4_RowClick;
            //价格分类
            this.btnPriceTypeAdd.Click += BtnPriceTypeAdd_Click;
            this.btnPriceTypeSave.Click += BtnPriceTypeSave_Click;
            this.btnPriceTypeDel.Click += BtnPriceTypeDel_Click;
        }

        private void FillComTimeAndType()
        {
            this.comboTime.Properties.Items.Clear();
            this.comboType.Properties.Items.Clear();
            this.comboLevel.Properties.Items.Clear();

            this.comboTime.Properties.Items.AddRange(new string[] { "30分钟", "60分钟", "90分钟", "120分钟", "150分钟", "180分钟" });
            this.comboType.Properties.Items.AddRange(new string[] { "现金", "Visa卡" });
            List<CardVo> cardList = SelectDao.SelectData<CardVo>();
            foreach (CardVo vo in cardList)
            {
                this.comboType.Properties.Items.Add(vo.CardName);
            }
            this.comboType.SelectedIndex = 0;
            List<StaffLevelVo> levelList = SelectDao.SelectData<StaffLevelVo>();
            foreach (StaffLevelVo vo in levelList)
            {
                this.comboLevel.Properties.Items.Add(vo.StaffLevel);
            }
        }
        //刷新服务
        private void RefreshSkill()
        {
            List<SkillVo> voList = SelectDao.SelectData<SkillVo>();
            this.gridControl1.DataSource = voList;
            this.gridControl1.RefreshDataSource();
        }
        //private void RefreshSever()
        //{
        //    List<ServerVo> voList = new List<ServerVo>();
        //    SelectDao.SelectData(ref voList);
        //    this.gridControl2.DataSource = voList;
        //    this.gridControl2.RefreshDataSource();
        //}
        private void RefreshSkillPrice(string serverName)
        {
            List<SkillPriceVo> voList = new List<SkillPriceVo>();
            SelectDao.GetSkillPriceByName(serverName, ref voList);
            this.gridControl3.DataSource = voList;
            this.gridControl3.RefreshDataSource();
        }
        private void RefreshSkillCommision(string serverName)
        {
            List<SkillCommisionVo> voList = new List<SkillCommisionVo>();
            SelectDao.GetSkillCommisionByName(serverName, ref voList);
            this.gridControl4.DataSource = voList;
            this.gridControl4.RefreshDataSource();
        }

        private void RefeeshPriceType()
        {
            //List<WorkTypeVo>  priceTypeVoList = SelectDao.SelectData<WorkTypeVo>();
            //this.gridControl2.DataSource = priceTypeVoList;
            //this.gridControl2.RefreshDataSource();
        }

        //private bool CheckParam(List<WorkTypeVo> voList)
        //{
        //    foreach (WorkTypeVo vo in voList)
        //    {
        //        if (string.IsNullOrWhiteSpace(vo.TypeName))
        //        {
        //            XtraMessageBox.Show("名称不能为空！");
        //            return false;
        //        }
        //    }
        //    var list = voList.GroupBy(v => v.TypeName).Where(v => v.Count() > 1).ToList();
        //    if (list.Count > 0)
        //    {
        //        XtraMessageBox.Show("名称不能相同！");
        //        return false;
        //    }
        //    return true;
        //}

        private void GridView4_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            SkillCommisionVo vo = (SkillCommisionVo)this.gridView4.GetRow(this.gridView4.FocusedRowHandle);
            comboLevel.Text = vo.StaffLevel;
            textPriceAT.Text = vo.PriceA.ToString();
            textPriceBT.Text = vo.PriceB.ToString();
            textPriceCT.Text = vo.PriceC.ToString();
            textreamark.Text = vo.Remark;
        }

        private void BtnDelT_Click(object sender, EventArgs e)
        {
            SkillCommisionVo vo = (SkillCommisionVo)this.gridView4.GetRow(this.gridView4.FocusedRowHandle);
            if (DeleteDao.DeleteByID(vo.Id, typeof(SkillCommisionVo)) > 0)
            {
                XtraMessageBox.Show("删除提成成功!");
                RefreshSkillCommision(this.textSkillName.Text);
            }
            else
            {
                XtraMessageBox.Show("删除提成失败!");
            }
        }

        private void BtnUpdateT_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.textPriceA.Text) || string.IsNullOrWhiteSpace(this.textPriceB.Text) || string.IsNullOrWhiteSpace(this.textPriceC.Text))
            {
                XtraMessageBox.Show("价格信息不完整！");
                return;
            }
            if (!FilterUtil.isNumberic(this.textPriceA.Text) || !FilterUtil.isNumberic(this.textPriceB.Text) || !FilterUtil.isNumberic(this.textPriceC.Text))
            {
                XtraMessageBox.Show("价格信息不正确！");
                return;
            }
            SkillCommisionVo vo = (SkillCommisionVo)this.gridView4.GetRow(this.gridView4.FocusedRowHandle);
            vo.SkillName = this.textSkillName.Text;
            vo.StaffLevel = this.comboLevel.Text;
            vo.PriceA = Convert.ToDouble(this.textPriceAT.Text);
            vo.PriceB = Convert.ToDouble(this.textPriceBT.Text);
            vo.PriceC = Convert.ToDouble(this.textPriceCT.Text);
            vo.Remark = this.textreamark.Text;
            if (UpdateDao.UpdateByID(vo) > 0)
            {
                XtraMessageBox.Show("更新提成成功!");
                RefreshSkillCommision(this.textSkillName.Text);
            }
        }

        private void BtnAddT_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.textPriceA.Text) || string.IsNullOrWhiteSpace(this.textPriceB.Text) || string.IsNullOrWhiteSpace(this.textPriceC.Text))
            {
                XtraMessageBox.Show("价格信息不完整！");
                return;
            }
            if (!FilterUtil.isNumberic(this.textPriceA.Text) || !FilterUtil.isNumberic(this.textPriceB.Text) || !FilterUtil.isNumberic(this.textPriceC.Text))
            {
                XtraMessageBox.Show("价格信息不正确！");
                return;
            }
            SkillCommisionVo vo = new SkillCommisionVo()
            {
                SkillName = this.textSkillName.Text,
                StaffLevel = this.comboLevel.Text,
                PriceA = Convert.ToDouble(this.textPriceAT.Text),
                PriceB = Convert.ToDouble(this.textPriceBT.Text),
                PriceC = Convert.ToDouble(this.textPriceCT.Text),
                Remark = this.textreamark.Text,
                CompanyId = SystemConst.companyId
            };
            if (InsertDao.InsertData(vo, typeof(SkillCommisionVo)) > 0)
            {
                XtraMessageBox.Show("添加技师提成成功!");
                RefreshSkillCommision(this.textSkillName.Text);
            }
        }
        private void GridView3_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            SkillPriceVo vo = (SkillPriceVo)this.gridView3.GetRow(this.gridView3.FocusedRowHandle);
            comboType.Text = vo.PriceType;
            textPriceA.Text = vo.PriceA.ToString();
            textPriceB.Text = vo.PriceB.ToString();
            textPriceC.Text = vo.PriceC.ToString();
            textreamark.Text = vo.Remark;
        }

        private void BtnDelPrice_Click(object sender, EventArgs e)
        {
            SkillPriceVo vo = (SkillPriceVo)this.gridView3.GetRow(this.gridView3.FocusedRowHandle);
            if (DeleteDao.DeleteByID(vo.Id, typeof(SkillPriceVo)) > 0)
            {
                XtraMessageBox.Show("删除价格成功!");
                RefreshSkillPrice(this.textServerNP.Text);
            }
            else
            {
                XtraMessageBox.Show("删除价格失败!");
            }
        }

        private void BtnUpdatePrice_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.textPriceA.Text) || string.IsNullOrWhiteSpace(this.textPriceB.Text) || string.IsNullOrWhiteSpace(this.textPriceC.Text))
            {
                XtraMessageBox.Show("价格信息不完整！");
                return;
            }
            if (!FilterUtil.isNumberic(this.textPriceA.Text) || !FilterUtil.isNumberic(this.textPriceB.Text) || !FilterUtil.isNumberic(this.textPriceC.Text))
            {
                XtraMessageBox.Show("价格信息不正确！");
                return;
            }
            SkillPriceVo vo = (SkillPriceVo)this.gridView3.GetRow(this.gridView3.FocusedRowHandle);
            vo.SkillName = this.textServerNP.Text;
            vo.PriceType = this.comboType.Text;
            vo.PriceA = Convert.ToDouble(this.textPriceA.Text);
            vo.PriceB = Convert.ToDouble(this.textPriceB.Text);
            vo.PriceC = Convert.ToDouble(this.textPriceC.Text);
            vo.Remark = this.textreamark.Text;
            if (UpdateDao.UpdateByID(vo) > 0)
            {
                XtraMessageBox.Show("更新价格成功!");
                RefreshSkillPrice(this.textServerNP.Text);
            }
        }

        private void BtnAddPrice_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.textPriceA.Text) || string.IsNullOrWhiteSpace(this.textPriceB.Text) || string.IsNullOrWhiteSpace(this.textPriceC.Text))
            {
                XtraMessageBox.Show("价格信息不完整！");
                return;
            }
            if (!FilterUtil.isNumberic(this.textPriceA.Text) || !FilterUtil.isNumberic(this.textPriceB.Text) || !FilterUtil.isNumberic(this.textPriceC.Text))
            {
                XtraMessageBox.Show("价格信息不正确！");
                return;
            }
            SkillPriceVo vo = new SkillPriceVo()
            {
                SkillName = this.textServerNP.Text,
                PriceType = this.comboType.Text,
                PriceA = Convert.ToDouble(this.textPriceA.Text),
                PriceB = Convert.ToDouble(this.textPriceB.Text),
                PriceC = Convert.ToDouble(this.textPriceC.Text),
                Remark = this.textreamark.Text,
                CompanyId = SystemConst.companyId
            };

            if(SelectDao.IsExistSkillPrice(vo.SkillName,vo.PriceType))
            {
                XtraMessageBox.Show("此价格已经存在!");
                return;
            }
            if (InsertDao.InsertData(vo, typeof(SkillPriceVo)) > 0)
            {
                XtraMessageBox.Show("添加价格成功!");
                RefreshSkillPrice(this.textServerNP.Text);
            }
        }
        //private void BtnDelProject_Click(object sender, EventArgs e)
        //{
        //    ServerVo vo = (ServerVo)this.gridView2.GetRow(this.gridView2.FocusedRowHandle);
        //    if (vo == null)
        //        return;
        //    if (DeleteDao.DelSeverByName(vo.ServerName, vo.SkillName) > 0)
        //    {
        //        XtraMessageBox.Show("删除成功!");
        //        RefreshSever();
        //    }
        //    else
        //    {
        //        XtraMessageBox.Show("删除失败!");
        //    }
        //}

        //private void BtnAddProject_Click(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(this.textProName.Text))
        //    {
        //        XtraMessageBox.Show("请填写项目名！");
        //        return;
        //    }
        //    AddServerForm serverForm = new AddServerForm(this.textProName.Text);
        //    serverForm.ShowDialog();
        //}

        private void BtnUpdateSever_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.textServerName.Text))
            {
                XtraMessageBox.Show("请填写项目名!");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.textSecond.Text))
            {
                XtraMessageBox.Show("请填写项目别名!");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.comboTime.Text))
            {
                XtraMessageBox.Show("请填写项目时长!");
                return;
            }
            SkillVo vo = (SkillVo)this.gridView1.GetFocusedRow();
            vo.SkillName = this.textServerName.Text;
            vo.SecondName = this.textSecond.Text;
            vo.ServerTime = this.comboTime.Text;
            vo.Remark = this.memoSerRemark.Text;
            vo.CompanyId = SystemConst.companyId;
            if (UpdateDao.UpdateByID(vo)>0)
            {
                XtraMessageBox.Show("更新项目成功!");
                RefreshSkill();
            }
        }
        private void GridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            SkillVo vo = (SkillVo)this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
            if (vo == null)
                return;
            this.textServerName.Text = vo.SkillName;
            this.textSecond.Text = vo.SecondName;
            this.comboTime.Text = vo.ServerTime;
            this.memoSerRemark.Text = vo.Remark;

            this.textServerIdP.Text = vo.SkillId.ToString();
            this.textServerNP.Text = vo.SkillName;
            RefreshSkillPrice(vo.SkillName);

            this.textSkillId.Text = vo.SkillId.ToString();
            this.textSkillName.Text = vo.SkillName;
            RefreshSkillCommision(vo.SkillName);
        }
        private void BtnDelSever_Click(object sender, EventArgs e)
        {
            SkillVo vo = (SkillVo)this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
            if (vo == null)
                return;
            if (DeleteDao.DelSkillByID(vo.SkillId) > 0)
            {
                XtraMessageBox.Show("删除成功!");
                RefreshSkill();
            }
            else
            {
                XtraMessageBox.Show("删除失败!");
            }
        }

        private void BtnAddSever_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.textServerName.Text))
            {
                XtraMessageBox.Show("请填写服务名!");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.textSecond.Text))
            {
                XtraMessageBox.Show("请填写服务别名!");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.comboTime.Text))
            {
                XtraMessageBox.Show("请填写服务时长!");
                return;
            }
            if (SelectDao.IsServerNameExist(this.textServerName.Text))
            {
                XtraMessageBox.Show("该服务名已经存在!");
                return;
            }
            SkillVo vo = new SkillVo();
            vo.SkillName = this.textServerName.Text;
            vo.SecondName = this.textSecond.Text;
            vo.ServerTime = this.comboTime.Text;
            vo.Remark = this.memoSerRemark.Text;
            vo.CompanyId = SystemConst.companyId;
            if (InsertDao.InsertData(vo, typeof(SkillVo)) > 0)
            {
                XtraMessageBox.Show("添加项目成功!");
                RefreshSkill();
            }
        }
        private void SkillSettingNew_Load(object sender, EventArgs e)
        {
            RefeeshPriceType();
            RefreshSkill();
            //RefreshSever();
            FillComTimeAndType();
        }
        private void BtnPriceTypeDel_Click(object sender, EventArgs e)
        {
            //WorkTypeVo delVo =(WorkTypeVo)this.gridView2.GetRow(this.gridView2.FocusedRowHandle);
            //if (delVo == null)
            //    return;
            //List<WorkTypeVo> workTypeVoList = (List<WorkTypeVo>)this.gridControl2.DataSource;
            //workTypeVoList.Remove(delVo);
            //this.gridView1.RefreshRow(this.gridView2.FocusedRowHandle);
            //if (DeleteDao.DeleteByID(delVo.TypeId,typeof(WorkTypeVo)) > 0)
            //{
            //    XtraMessageBox.Show("删除成功");
            //}
            //this.gridControl2.RefreshDataSource();
        }

        private void BtnPriceTypeSave_Click(object sender, EventArgs e)
        {
            //List<WorkTypeVo> priceTypeOldVoList = SelectDao.SelectData<WorkTypeVo>();
            //List<WorkTypeVo> workTypeVoList = (List<WorkTypeVo>)this.gridControl2.DataSource;
            //List<WorkTypeVo> changeList = GenericUtil.GetChanges(workTypeVoList, priceTypeOldVoList);
            //int result = 0;
            //if (!CheckParam(changeList))
            //    return;
            //foreach (WorkTypeVo vo in changeList)
            //{
            //    if (SelectDao.IsRepeatedPirceTypeId(vo.TypeId)&&vo.TypeId!=0)
            //    {
            //        //更新
            //        result = UpdateDao.UpdateByID(vo);
            //        if (result <= 0)
            //        {
            //            XtraMessageBox.Show(vo.TypeName + "更新失败！");
            //            break;
            //        }
            //    }
            //    else
            //    {
            //        result = InsertDao.InsertData(vo,typeof(WorkTypeVo));
            //        if (result <= 0)
            //        {
            //            XtraMessageBox.Show(vo.TypeName + "保存失败！");
            //            break;
            //        }
            //    }
            //}
            //XtraMessageBox.Show("保存成功！");
        }

        private void BtnPriceTypeAdd_Click(object sender, EventArgs e)
        {
            //WorkTypeVo addVo = new WorkTypeVo();
            ////addVo.TypeName = "xxx";
            //List<WorkTypeVo> workTypeVoList = (List<WorkTypeVo>)this.gridControl2.DataSource;
            //workTypeVoList.Add(addVo);
            //this.gridControl2.RefreshDataSource();
        }

        #region eventbus
        [EventAttr("UpdateLevelCard")]
        public void UpdateLevelCard()
        {
            FillComTimeAndType();
        }
        #endregion
    }
}
