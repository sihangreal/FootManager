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
using ClientCenter.Event;

namespace MemberManager.UI
{
    public partial class CardInfoUI : DevExpress.XtraEditors.XtraUserControl
    {
        private List<CardVo> cardVoList = new List<CardVo>();
        public CardInfoUI()
        {
            InitializeComponent();
            InitEvents();
            SetCardInfoGrid();
        }

        private void InitEvents()
        {
            this.btnAdd.Click += BtnAdd_Click;
            this.btnSave.Click += BtnSave_Click;
            this.btnDel.Click += BtnDel_Click;
        }

        private void SetCardInfoGrid()
        {
            GridViewUtil.InitGridView(this.gridView1,typeof(CardVo));
            cardVoList = SelectDao.SelectData<CardVo>();
            this.gridControl1.DataSource = cardVoList;
            this.gridControl1.RefreshDataSource();
        }
        private bool CheckParam(List<CardVo> changeList)
        {
            var result = cardVoList.GroupBy(v => v.CardName).Select(v=>new { count=v.Count(),key=v.Key});
            foreach(var s in result)
            {
                if (s.count > 2)
                    return false;
            }
            return true;
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            List<CardVo> staffOldInfoList = SelectDao.SelectData<CardVo>();
            List<CardVo> changeList = GenericUtil.GetChanges(cardVoList, staffOldInfoList);
            int result = 0;
            if (!CheckParam(changeList))
                return;
            foreach (CardVo vo in changeList)
            {
                if (SelectDao.IsRepeatedCardId(vo.CardId))
                {
                    //更新
                    result = UpdateDao.UpdateByID(vo);
                    if (result <= 0)
                    {
                        XtraMessageBox.Show(vo.CardName + "更新失败！");
                        break;
                    }
                }
                else
                {
                    vo.CompanyId = SystemConst.companyId;
                    result = InsertDao.InsertData(vo);
                    if (result <= 0)
                    {
                        XtraMessageBox.Show(vo.CardName + "保存失败！");
                        break;
                    }
                }
            }
            EventBus.PublishEvent("UpdateLevelCard");
            XtraMessageBox.Show("保存成功！");
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            CardVo vo = (CardVo)this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
            if (vo == null)
                return;
            cardVoList.Remove(vo);
            if (DeleteDao.DeleteByID(vo.CardId, typeof(CardVo)) <= 0)
            {
                XtraMessageBox.Show("删除卡失败!");
                return;
            }
            EventBus.PublishEvent("UpdateLevelCard");
            XtraMessageBox.Show("删除卡成功!");
            this.gridControl1.RefreshDataSource();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            CardVo addVo = new CardVo();
            cardVoList.Add(addVo);
            this.gridControl1.RefreshDataSource();
        }
    }
}
