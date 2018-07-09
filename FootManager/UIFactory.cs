using DevExpress.XtraEditors;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FootManager
{
    public class UIFactory
    {
        private static UIFactory instance;
        private static Dictionary<int, Mode> controlDict = new Dictionary<int, Mode>();

        private UIFactory()
        {
            InitControlDic();
        }

        private void InitControlDic()
        {
            Mode mode = new Mode("FrontCashierManager.dll", "FrontCashierManager.ForntCashierMainUI") { Id = 1, ModeName = "前台收银"  };
            controlDict.Add(1,mode);
            mode = new Mode("ReservationManager.dll", "ReservationManager.ReservationMainUI") { Id = 2, ModeName = "预约管理" };
            controlDict.Add(2, mode);
            mode = new Mode("StaffManager.dll", "StaffManager.StaffMainUI") { Id = 3, ModeName = "员工管理" };
            controlDict.Add(3, mode);
            mode = new Mode("MemberManager.dll", "MemberManager.MemberMainUI") { Id = 4, ModeName = "会员管理" };
            controlDict.Add(4, mode);
            mode = new Mode("RepertoryManager.dll", "RepertoryManager.RepertoryMainUI") { Id = 5, ModeName = "库存管理" };
            controlDict.Add(5, mode);
            mode = new Mode("ReportManager.dll", "ReportManager.ReportMainUI") { Id = 6, ModeName = "报表分析" };
            controlDict.Add(6, mode);
            mode = new Mode("BusinessManger.dll", "BusinessManger.BusinessMainUI") { Id = 7, ModeName = "营业收入" };
            controlDict.Add(7, mode);
            mode = new Mode("GuestManager.dll", "GuestManager.GuestMainUI") { Id = 8, ModeName = "客情分析" };
            controlDict.Add(8, mode);
        }

        public static UIFactory GetUIFactory()
        {
            if(instance==null)
            {
                instance= new UIFactory();
            }
            return instance;
        }

        public void ShowControl(PanelControl panel,int id)
        {
            panel.Controls.Clear();
            Control control = controlDict[id].ModeControl;
            control.Dock = DockStyle.Fill;
            panel.Controls.Add(control);
        }
    }
}
