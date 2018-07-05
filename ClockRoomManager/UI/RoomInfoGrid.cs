using System;
using ClientCenter.Core;
using DevExpress.XtraBars;
using ClientCenter.Enity;

namespace ClockRoomManager.UI
{
    public partial class RoomInfoGrid : DevExpress.XtraEditors.XtraUserControl
    {
        Type type;
        public RoomInfoGrid(Type type)
        {
            this.type = type;
            InitializeComponent();
            InitEvents();
            GridViewUtil.CreateColumnForData(this.gridView1,type);
        }

        private void InitEvents()
        {
            this.Load += RoomInfoGrid_Load;
        }

        private void RoomInfoGrid_Load(object sender, EventArgs e)
        {
            if(type==typeof(RoomVo))
            {
                this.barEditLook.Visibility = BarItemVisibility.Always;
            }
            else if(type==typeof(BusyRoomVo))
            {
                this.bar2.Visible = false;
                this.barEditLook.Visibility = BarItemVisibility.Never;
                this.gridView1.ViewCaption = "繁忙房间";
                this.gridView1.OptionsView.ShowViewCaption = true;
            }
            else
            {
                this.bar2.Visible = false;
                this.barEditLook.Visibility = BarItemVisibility.Never;
                this.gridView1.ViewCaption = "空闲房间";
                this.gridView1.OptionsView.ShowViewCaption = true;
            }
        }
    }
}
