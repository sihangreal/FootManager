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
            this.btnDel.Click += BtnSave_Click;
        }

        private void SetCardInfoGrid()
        {
            GridViewUtil.CreateColumnForData(this.gridView1,typeof(CardVo));
            cardVoList = SelectDao.SelectData<CardVo>();
            this.gridControl1.DataSource = cardVoList;
            this.gridControl1.RefreshDataSource();
        }
        private bool CheckParam(List<CardVo> changeList)
        {
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
                    result = InsertDao.InsertData(vo);
                    if (result <= 0)
                    {
                        XtraMessageBox.Show(vo.CardName + "保存失败！");
                        break;
                    }
                }
            }
            XtraMessageBox.Show("保存成功！");
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            CardVo vo = (CardVo)this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
            if (vo == null)
                return;
            cardVoList.Remove(vo);
            if (DeleteDao.DeleteByID(vo, typeof(CardVo)) > 0)
            {
                XtraMessageBox.Show("删除卡失败!");
            }
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
