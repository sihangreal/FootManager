using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DevExpress.XtraSplashScreen;

namespace ClientCenter.Core
{
    public class SplashScrennHelper
    {
        /// <summary>
        /// 设置初始化窗体文字
        /// </summary>
        /// <param name="labeltext">显示文字信息</param>
        /// <param name="formpos">显示文字信息开始位置</param>
        /// <param name="topos">显示文字信息结束位置</param>
        /// <param name="sleeptime">文字更改后暂停程序时间</param>
        /// <param name="image">背景</param>
        public static void SetInfo(string labeltext, int formpos, int topos, int sleeptime, Bitmap image)
        {
            if (image != null)
            {
                SplashScreenManager.Default.SendCommand(SplashScreenCommand.SetInfo, new Info() { BackImage = image });
            }
            for (int i = formpos; i < topos; i++)
            {
                SplashScreenManager.Default.SendCommand(SplashScreenCommand.SetInfo, new Info() { ProgressTitle = labeltext, ProgressPosition = i });
                Thread.Sleep(sleeptime);
            }
        }
    }

    /// <summary>
    /// 自定义枚举类型
    /// </summary>
    public enum SplashScreenCommand
    {
        SetInfo
    }

    public class Info
    {
        //滚动条上对应的文字信息
        public string ProgressTitle { get; set; }

        //滚动条的位置信息
        public int ProgressPosition { get; set; }

        //设置背景图标
        public System.Drawing.Bitmap BackImage { get; set; }
    }
}
