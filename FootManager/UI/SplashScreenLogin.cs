using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using ClientCenter.Core;

namespace FootManager.UI
{
    public partial class SplashScreenLogin : SplashScreen
    {
        public SplashScreenLogin()
        {
            InitializeComponent();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
            SplashScreenCommand command = (SplashScreenCommand)cmd;
            if (command == SplashScreenCommand.SetInfo)
            {
                Info info = (Info)arg;
                if (!string.IsNullOrEmpty(info.ProgressTitle))
                    labelControl2.Text = info.ProgressTitle;
                if (info.ProgressPosition > 0)
                    progressBarControl1.Position = info.ProgressPosition;
                if (info.BackImage != null)
                    pictureEdit2.Image = info.BackImage;
            }
        }

        #endregion
    }
}