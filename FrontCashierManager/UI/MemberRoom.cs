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
using FrontCashierManager.Enity;
using ClientCenter.Core;

namespace FrontCashierManager.UI
{
    public partial class MemberRoom : DevExpress.XtraEditors.XtraUserControl
    {
        public MemberRoom(Type type)
        {
            InitializeComponent();
            InitEvents();
            GridViewUtil.CreateColumnForData(this.gridView1, type);
        }

        #region private method
        private void InitEvents()
        {
            this.Load += MemberRoom_Load;
        }
        #endregion

        #region public method
        public void SetData(List<MemberRoomVo> voList)
        {
            this.gridControl1.DataSource = voList;
            this.gridControl1.RefreshDataSource();
        }
        #endregion

        #region events
        private void MemberRoom_Load(object sender, EventArgs e)
        {
            //test
            List<MemberRoomVo> voList = new List<MemberRoomVo>() {
                new MemberRoomVo() { RoomId=1,RoomName="杭州",ProjectName="按摩",MemberName="李四" ,MemberId=1, },
                new MemberRoomVo() { RoomId=2,RoomName="上海",ProjectName="按摩" ,MemberName="王五",MemberId=2},
            };
            SetData(voList);
        }
        #endregion
    }
}
