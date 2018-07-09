using DevExpress.XtraNavBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FootManager{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        UIFactory factory;

        public MainForm()
        {
            InitializeComponent();
            InitEvents();
        }

        #region private method
        private void InitEvents()
        {
            this.Load += MainForm_Load;
            this.cashierItem.LinkClicked += NavItem_LinkClicked;
            this.guestItem.LinkClicked += NavItem_LinkClicked;
            this.reportItem.LinkClicked += NavItem_LinkClicked;
            this.repertoryItem.LinkClicked += NavItem_LinkClicked;
            this.memberItem.LinkClicked += NavItem_LinkClicked;
            this.staffItem.LinkClicked += NavItem_LinkClicked;
            this.businesstem.LinkClicked += NavItem_LinkClicked;
            this.reservationItem.LinkClicked += NavItem_LinkClicked;
        }

        #endregion

        #region events
        private void MainForm_Load(object sender, EventArgs e)
        {
            factory = UIFactory.GetUIFactory();
        }

        private void NavItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            factory.ShowControl(this.mainPanel, (int)(sender as NavBarItem).Tag);
        }
        #endregion
    }
}
