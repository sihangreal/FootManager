using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClientCenter.Core;
using ClientCenter.DB;
using ClientCenter.Enity;
using DevExpress.XtraEditors;
using ClientCenter.Event;
using System.Linq;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace ClockRoomManager.UI
{
    public partial class OrderInfoForm : DevExpress.XtraEditors.XtraForm
    {
        private RoomVo roomVo;
        private List<TempOrderVo> orderList = new List<TempOrderVo>();
        //private string remark;
        private double price;
        private int itype;//轮钟0，点钟1， 加钟2
        private string orderId;//订单编号
        private string staffName;
        private string staffId;

        public OrderInfoForm(RoomVo roomVo)
        {
            this.roomVo = roomVo;
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
                        itype = 0;
                    }
                    break;
                case "点钟":
                    {
                        this.comboStaff.Enabled = true;
                        checkEdit1.Checked = false;
                        checkEdit3.Checked = false;
                        itype = 1;
                    }
                    break;
                case "加钟":
                    {
                        this.comboStaff.Enabled = false;
                        checkEdit1.Checked = false;
                        checkEdit2.Checked = false;
                        itype = 2;
                    }
                    break;
            }
        }

        private void RefreshSkill()
        {
            List<SkillVo> voList = new List<SkillVo>();
            SelectDao.SelectData(ref voList);
            this.gridControl2.DataSource = voList;
            this.gridView2.BestFitColumns();
            this.gridControl2.RefreshDataSource();
        }

        private void FillComboStaff()
        {
            List<StaffWorkInfoVo> voList = new List<StaffWorkInfoVo>();
            SelectDao.SelectData(ref voList);
            List<StaffWorkInfoVo> newVoList = voList.Where(v => v.StaffStatus.Equals("空闲")).ToList();
            foreach (StaffWorkInfoVo vo in newVoList)
            {
                string temp = vo.StaffID + "_"+vo.StaffName;
                comboStaff.Properties.Items.Add(temp);
            }
        }
        private double GetPriceByType(double[] prices)
        {
            switch(itype)
            {
                case 0:
                    price += prices[0]; break;
                case 1:
                    price += prices[1]; break;
                case 2:
                    price += prices[2]; break;
            }
            return price;
        }
        #region events
        private void OrderInfoForm_Load(object sender, EventArgs e)
        {
            GridViewUtil.CreateColumnForData(this.gridView1,typeof(TempOrderVo));
            GridViewUtil.CreateColumnForData(this.gridView2, typeof(SkillVo));

            RefreshSkill();
            FillComboStaff();

            if (roomVo.RoomStatus.Equals("占用"))
            {
                this.btnOrder.Enabled = false;
                List<TempOrderVo> tempList = new List<TempOrderVo>();
                SelectDao.GetTempOrderByRoomID(roomVo.RoomId, ref tempList);
                this.gridControl1.DataSource = tempList;
                this.gridControl1.RefreshDataSource();

                StaffWorkInfoVo workVo=(StaffWorkInfoVo) SelectDao.GetWorkStaffInfoByRoomId(roomVo.RoomId);


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
                int index = comboStaff.Text.LastIndexOf('_');
                string staffName = comboStaff.Text.Substring(index+1);
                string staffId = comboStaff.Text.Substring(0,index);
                orderId = SelectDao.CreateOrderHandle();
                TempOrderVo tempVo = new TempOrderVo()
                {
                    Id=0,
                    RoomID = roomVo.RoomId,
                    OrderID=orderId,
                    SkillId = vo.SkillId,
                    SkillName = vo.SkillName,
                    StaffID = staffId,
                    StaffName = staffName,
                    PriceA = prices[0],
                    PriceB=prices[1],
                    PriceC=prices[2]
                };
                orderList.Add(tempVo);
                this.gridControl1.DataSource = orderList;
                this.gridControl1.RefreshDataSource();
                this.gridView1.BestFitColumns();

                GetPriceByType(prices);
                this.labelPrice.Text = price.ToString("f8");
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
            this.roomVo.RoomStatus = "占用";
            if (UpdateDao.UpdateByID(this.roomVo) < 0)
            {
                XtraMessageBox.Show("下单失败！");
                return;
            }
            int index = comboStaff.Text.LastIndexOf('_');
            staffName = comboStaff.Text.Substring(index + 1);
            staffId = comboStaff.Text.Substring(0, index);
            StaffWorkInfoVo workVo = new StaffWorkInfoVo();
            workVo.StaffID = staffId;
            workVo.StaffName = staffName;
            workVo.StaffSex = SelectDao.GetStaffSexByID(staffId);
            workVo.StaffStatus = "工作中";
            workVo.RoomId = roomVo.RoomId;
            workVo.RoomName = roomVo.RoomName;
            workVo.OrderID = orderId;
            //报单
            OrderInfoVo orderVo = new OrderInfoVo();
            orderVo.OrderID = orderId;
            orderVo.RoomID = roomVo.RoomId;
            orderVo.StaffName = staffName;
            orderVo.StartTime = DateTime.Now.ToString();
            orderVo.Status = "未完成";

            if(!TransactionDao.SendStartOrder(workVo, orderVo))
            {
                XtraMessageBox.Show("下单失败！");
                return;
            }
            this.btnCancelOrder1.Enabled = true;
            this.btnOrder.Enabled = false;
            this.roomVo.RoomStatus = "占用";
            EventBus.PublishEvent("StaffWorkStatusChange");
            XtraMessageBox.Show("下单成功！");
        }
        private bool InsertOrder()
        {
            OrderInfoVo orderVo = new OrderInfoVo();
            orderId = SelectDao.CreateOrderHandle();
            orderVo.OrderID = orderId;
            orderVo.RoomID = roomVo.RoomId;
            orderVo.StaffName = staffName;
            orderVo.StartTime = DateTime.Now.ToString();
            orderVo.Status = "未完成";
            if (InsertDao.InsertData(orderVo, typeof(OrderInfoVo)) > 0)
                return true;
            else
                return false;
        }
        private void BtnPay_Click(object sender, EventArgs e)
        {
            PayOrderForm payForm = new PayOrderForm();
            List<TempOrderVo> tempOrderList= (List<TempOrderVo>)this.gridControl1.DataSource;
            payForm.SetData(tempOrderList, itype, orderId, staffName, staffId, roomVo);
            payForm.ShowDialog();
        }
        private void GridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (string.Equals(e.Column.FieldName, "EndTime"))
            {
                TempOrderVo vo = (TempOrderVo)this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
                if (string.IsNullOrWhiteSpace(vo.EndTime))
                {
                    e.DisplayText = "------";
                }
            }
            if(string.Equals(e.Column.FieldName,"StartTime"))
            {
                TempOrderVo vo = (TempOrderVo)this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
                if (string.IsNullOrWhiteSpace(vo.StartTime))
                {
                    e.DisplayText = "------";
                }
            }
        }
      #endregion
    }
}