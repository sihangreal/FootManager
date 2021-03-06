﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClientCenter.Core;
using ClientCenter.DB;
using ClientCenter.Enity;
using DevExpress.XtraEditors;
using ClientCenter.Event;
using System.Linq;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ClientCenter.GridViews;

namespace ClockRoomManager.UI
{
    public partial class OrderInfoForm : DevExpress.XtraEditors.XtraForm
    {
        private RoomVo _rommVo;
        private List<TempOrderVo> _tempOrderList = new List<TempOrderVo>();
        //private string remark;
        private double _price;
        private int _itype = 0;//轮钟0，点钟1， 加钟2
        //private string orderId;//订单编号
        //private string staffName;
        //private string staffId;

        public OrderInfoForm(RoomVo roomVo)
        {
            this._rommVo = roomVo;
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            this.Load += OrderInfoForm_Load;
            this.gridView2.MouseUp += GridView2_MouseUp;
            this.btnRemark.Click += BtnRemark_Click;
            this.btnOrder.Click += BtnOrder_Click;
            this.btnCancelOrder.ItemClick += BtnCancelOrder_ItemClick;
            this.btnPay.Click += BtnPay_Click;


            this.gridView1.CustomDrawCell += GridView1_CustomDrawCell;
            this.gridView1.MouseUp += GridView1_MouseUp;

            this.checkEdit1.CheckedChanged += CheckEdit1_CheckedChanged;
            this.checkEdit2.CheckedChanged += CheckEdit1_CheckedChanged;
            this.checkEdit3.CheckedChanged += CheckEdit1_CheckedChanged;
        }

        private void BtnCancelOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            List<TempOrderVo> tempVoList = (List<TempOrderVo>)this.gridView1.DataSource;
            TempOrderVo vo = (TempOrderVo)this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
            tempVoList.Remove(vo);
            this.gridControl1.RefreshDataSource();
        }

        //右键退单
        private void GridView1_MouseUp(object sender, MouseEventArgs e)
        {
            GridHitInfo gridHitInfo = this.gridView1.CalcHitInfo(e.Location);
            if(gridHitInfo.InRow && e.Button==MouseButtons.Right)
            {
                this.popupMenu1.ShowPopup(Control.MousePosition);
            }
        }

        private void ChangeType(string caption)
        {
            switch (caption)
            {
                case "轮钟":
                    {
                        this.comboStaff.Enabled = false;
                        checkEdit2.Checked = false;
                        checkEdit3.Checked = false;
                    }
                    break;
                case "点钟":
                    {
                        this.comboStaff.Enabled = true;
                        checkEdit1.Checked = false;
                        checkEdit3.Checked = false;
                    }
                    break;
                case "加钟":
                    {
                        this.comboStaff.Enabled = false;
                        checkEdit1.Checked = false;
                        checkEdit2.Checked = false;
                    }
                    break;
            }
        }

        private void RefreshSkill()
        {
            List<SkillVo> voList = SelectDao.SelectData<SkillVo>();
            this.gridControl2.DataSource = voList;
            this.gridView2.BestFitColumns();
            this.gridControl2.RefreshDataSource();
        }

        private void FillComboStaff()
        {
            List<StaffQueueVo> voList = SelectDao.SelectData<StaffQueueVo>();
            if (voList.Count == 0)
                return;
            foreach (StaffQueueVo vo in voList)
            {
                string temp =vo.StaffName;
                comboStaff.Properties.Items.Add(temp);
            }
            
            comboStaff.SelectedIndex = 0;
        }
        private double GetPriceByType(double[] prices)
        {
            switch(_itype)
            {
                case 0:
                    _price += prices[0]; break;
                case 1:
                    _price += prices[1]; break;
                case 2:
                    _price += prices[2]; break;
            }
            return _price;
        }
        #region events
        private void OrderInfoForm_Load(object sender, EventArgs e)
        {
            GridViewUtil.InitGridView(this.gridView1,typeof(TempOrderVo));
            GridViewUtil.InitGridView(this.gridView2, typeof(SkillVo));

            RefreshSkill();
            FillComboStaff();

            if (_rommVo.RoomStatus.Equals("占用"))
            {
                this.btnOrder.Enabled = false;
                List<TempOrderVo> tempList = SelectDao.GetTempOrderByRoomID<TempOrderVo>(_rommVo.RoomId);
                this.gridControl1.DataSource = tempList;
                this.gridControl1.RefreshDataSource();

                StaffWorkInfoVo workVo=SelectDao.GetWorkStaffInfoByRoomId<StaffWorkInfoVo>(_rommVo.RoomId);


                this.gridView1.BestFitColumns();
                this.panelControl3.Visible = false;
                this.checkEdit1.Enabled = false;
                this.checkEdit2.Enabled = false;
                this.checkEdit3.Enabled = false;
                this.comboStaff.Enabled = false;
                this.btnCancelOrder1.Enabled = false;
            }
            else
            {
                this.btnPay.Enabled = false;
            }
        }
        private void CheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            string caption = (sender as CheckEdit).Text;
            CheckEdit checkEdit = (CheckEdit)sender;
            if (checkEdit.Checked)
            {
                ChangeType(checkEdit.Text);
            }
        }
        private void GridView2_MouseUp(object sender, MouseEventArgs e)
        { 
            if(string.IsNullOrWhiteSpace(comboStaff.Text))
            {
                XtraMessageBox.Show("请选择技师");
                return;
            }
            if(e.Button== MouseButtons.Left)
            {
                SkillVo vo = (SkillVo)this.gridView2.GetRow(this.gridView2.FocusedRowHandle);
                double[] prices = SelectDao.GetSkillPrice(vo.SkillName,"现金");
          
                string staffName = comboStaff.Text;
                string staffId = SelectDao.SelectSatffIDByName(staffName);
                //创建ID
                //orderId = GenrateIDUtil.GenerateOrderID();

                DateTime tempTime = new DateTime();
                if (_tempOrderList.Count > 0)
                    tempTime = _tempOrderList[_tempOrderList.Count - 1].EndTime;
                else
                    tempTime = DateTime.Now;
                TempOrderVo tempVo = new TempOrderVo()
                {
                    Id = 0,
                    RoomID = _rommVo.RoomId,
                    //OrderID = orderId,
                    SkillId = vo.SkillId,
                    SkillName = vo.SkillName,
                    StaffID = staffId,
                    StaffName = staffName,
                    WorkType = _itype,
                    StartTime = tempTime,
                    EndTime = SelectDao.GetTempOrderEndTime(vo.SkillId, tempTime),
                    PriceA = prices[0],
                    PriceB = prices[1],
                    PriceC = prices[2],
                    CompanyId = SystemConst.companyId
                };
                _tempOrderList.Add(tempVo);
                this.gridControl1.DataSource = _tempOrderList;
                this.gridControl1.RefreshDataSource();
                this.gridView1.BestFitColumns();

                GetPriceByType(prices);
                this.labelPrice.Text = _price.ToString("f8");
            }
        }
        private void BtnRemark_Click(object sender, EventArgs e)
        {
            RemarkForm remarkForm = new RemarkForm();
            if(remarkForm.ShowDialog()==DialogResult.OK)
            {
                //emark = remarkForm.remark;
            }
        }
        private void BtnCancelOrder_Click(object sender, EventArgs e)
        {
            //List<TempOrderVo> tempVoList = (List<TempOrderVo>)this.gridView1.DataSource;
            //foreach (TempOrderVo vo in tempVoList)
            //{
            //    if (DeleteDao.DeleteByID(vo.Id, typeof(TempOrderVo)) <= 0)
            //    {
            //        XtraMessageBox.Show("退单失败！");
            //        return;
            //    }
            //}
            //this.btnCancelOrder1.Enabled = false;
            //this.btnOrder.Enabled = true;
            //tempVoList.Clear();
            //this.gridControl1.RefreshDataSource();
        }
        private void BtnOrder_Click(object sender, EventArgs e)
        {
            List<TempOrderVo> tempVoList = (List<TempOrderVo>)this.gridView1.DataSource;
            if (tempVoList == null || tempVoList.Count == 0)
            {
                XtraMessageBox.Show("请选择服务项目！");
                return;
            }
            if(!TransactionDao.SendTempOrder(tempVoList))
            {
                XtraMessageBox.Show("下单失败！");
                return;
            }
            this.btnCancelOrder1.Enabled = true;
            this.btnOrder.Enabled = false;
            this._rommVo.RoomStatus = "占用";

            EventBus.PublishEvent("StaffWorkStatusChange");
            XtraMessageBox.Show("下单成功！");

            this.DialogResult = DialogResult.OK;
        }
        private void BtnPay_Click(object sender, EventArgs e)
        {
            PayOrderForm payForm = new PayOrderForm(_rommVo.RoomId);
            if(payForm.ShowDialog()==DialogResult.OK)
            {
                this.DialogResult = DialogResult.Ignore;
            }
   
        }
        private void GridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (string.Equals(e.Column.FieldName, "EndTime"))
            {
                TempOrderVo vo = (TempOrderVo)this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
                if (vo.EndTime==default(DateTime))
                {
                    e.DisplayText = "------";
                }
            }
            if(string.Equals(e.Column.FieldName,"StartTime"))
            {
                TempOrderVo vo = (TempOrderVo)this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
                if (vo.StartTime== default(DateTime))
                {
                    e.DisplayText = "------";
                }
            }
        }
      #endregion
    }
}