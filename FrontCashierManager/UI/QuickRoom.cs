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

namespace FrontCashierManager.UI
{
    public partial class QuickRoom : DevExpress.XtraEditors.XtraUserControl
    {
        private HandRoom handRoom;
        private MemberRoom memberRoom;

        public QuickRoom()
        {
            InitializeComponent();
            InitEvents();
        }

        #region private method
        private void InitEvents()
        {
            this.Load += QuickRoom_Load;
        }
        #endregion

        #region  events
        private void QuickRoom_Load(object sender, EventArgs e)
        {
            handRoom = new HandRoom(typeof(HandRoomVo));
            memberRoom = new MemberRoom(typeof(MemberRoomVo));
            handRoom.Dock = DockStyle.Fill;
            memberRoom.Dock = DockStyle.Fill;
            this.xtraTabPage1.Controls.Add(handRoom);
            this.xtraTabPage2.Controls.Add(memberRoom);
        }
        #endregion
    }
}
