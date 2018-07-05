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
using FrontCashierManager.Enity;

namespace FrontCashierManager.UI
{
    public partial class HandRoom : DevExpress.XtraEditors.XtraUserControl
    {
        public HandRoom(Type type)
        {
            InitializeComponent();
            InitEvents();
            GridViewUtil.CreateColumnForData(this.gridView1, type);
        }
        #region private method
        private void InitEvents()
        {
            this.Load += HandRoom_Load;
        }
        #endregion

        #region public method
        public void SetData(List<HandRoomVo> voList)
        {
            this.gridControl1.DataSource = voList;
            this.gridControl1.RefreshDataSource();
        }
        #endregion

        #region events
        private void HandRoom_Load(object sender, EventArgs e)
        {
            //test
            List<HandRoomVo> voList = new List<HandRoomVo>() {
                new HandRoomVo() { RoomId=1,RoomName="杭州",ProjectName="按摩" },
                new HandRoomVo() { RoomId=2,RoomName="上海",ProjectName="按摩" },
            };
            SetData(voList);
        }
        #endregion
    }
}
