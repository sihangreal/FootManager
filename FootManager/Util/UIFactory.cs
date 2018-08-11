using DevExpress.XtraEditors;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FootManager
{
    public class UIFactory
    {
        private static UIFactory instance;
        private static Dictionary<string, Mode> controlDict = new Dictionary<string, Mode>();

        private UIFactory()
        {
            InitControlDic();
        }

        private void InitControlDic()
        {
            Mode mode = new Mode("StaffManager.dll", "StaffManager.StaffMainUI") { Id = 3, ModeName = "员工管理" };
            controlDict.Add("员工管理", mode);
            mode = new Mode("MemberManager.dll", "MemberManager.MemberMainUI") { Id = 4, ModeName = "会员管理" };
            controlDict.Add("会员管理", mode);
            mode = new Mode("ReportManager.dll", "ReportManager.ReportMainUI") { Id = 6, ModeName = "报表分析" };
            controlDict.Add("报表分析", mode);
            mode = new Mode("BusinessManger.dll", "BusinessManger.BusinessMainUI") { Id = 7, ModeName = "商品管理" };
            controlDict.Add("商品管理", mode);
            mode = new Mode("ClockRoomManager.dll", "ClockRoomManager.ClockRoomMainUI") { Id = 9, ModeName = "钟房管理" };
            controlDict.Add("钟房管理", mode);
            mode = new Mode("SettlementCenter.dll", "SettlementCenter.SettlementMainUI") { Id = 10, ModeName = "钟房管理" };
            controlDict.Add("结账中心", mode);
            mode = new Mode("OrderInfoManager.dll", "OrderInfoManager.OrderInfoMainUI") { Id = 11, ModeName = "订单查询" };
            controlDict.Add("订单查询", mode);
           
        }

        public static UIFactory GetUIFactory()
        {
            if(instance==null)
            {
                instance= new UIFactory();
            }
            return instance;
        }

        public void ShowControl(PanelControl panel,string id)
        {
            panel.Controls.Clear();
            Control control = controlDict[id].ModeControl;
            control.Dock = DockStyle.Fill;
            panel.Controls.Add(control);
        }
    }
}
