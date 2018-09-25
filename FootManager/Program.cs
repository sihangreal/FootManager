using FootManager.UI;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace FootManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2007 Black");

            //跨线程调用窗体控件，禁止监控线程问题
            //DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
            //汉化
            new ChineseLanguage();
           Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-CN");

            try
            {
                //设置应用程序处理异常方式：ThreadException处理
                //Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //处理UI线程异常
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                //处理非UI线程异常
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                LoginFormNew loginForm = new LoginFormNew();
                Application.Run(loginForm);
                if (loginForm.DialogResult == DialogResult.OK)
                {
                    Application.Run(new MainForm());
                }
            }
            catch (Exception ex)
            {
                string str = GetExceptionMsg(ex, string.Empty);
                MessageBox.Show(str, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string str = GetExceptionMsg(e.Exception, e.ToString());
            MessageBox.Show(str, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //LogManager.WriteLog(str);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string str = GetExceptionMsg(e.ExceptionObject as Exception, e.ToString());
            MessageBox.Show(str, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
           // LogManager.WriteLog(str);
        }
        static string GetExceptionMsg(Exception ex, string backStr)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine("****************************异常文本****************************");
            sb.AppendLine("【出现时间】：" + DateTime.Now.ToString());
            if (ex != null)
            {
                sb.AppendLine("【异常类型】：" + ex.GetType().Name);
                sb.AppendLine("【异常信息】：" + ex.Message);
                sb.AppendLine("【堆栈调用】：" + ex.StackTrace);
            }
            else
            {
                sb.AppendLine("【未处理异常】：" + backStr);
            }
            sb.AppendLine("***************************************************************");
            return sb.ToString();
        }
    }
}
