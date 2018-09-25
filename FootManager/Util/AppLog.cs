using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Core;

namespace FootManager.Util
{
    /// <summary>
    /// 日志处理
    /// </summary>
    public class AppLog
    {
        #region 变量及属性
        /// <summary>
        /// 程序基础信息Log对象
        /// </summary>
        private static ILog _appLogger = LogManager.GetLogger("AppAppender");
        /// <summary>
        /// 错误信息Log对象
        /// </summary>
        private static ILog _errorLogger = LogManager.GetLogger("ErrorAppender");
        /// <summary>
        /// 交易信息Log对象
        /// </summary>
        private static ILog _tradeLogger = LogManager.GetLogger("TradeAppender");
        /// <summary>
        /// 读入数据库
        /// </summary>
        private static ILog _adoLogger = LogManager.GetLogger("ADONetAppender");
        #endregion

        #region 初始化
        /// <summary>
        /// 读取配置文件
        /// 初始化日志系统
        /// 在系统运行开始初始化
        /// Global.asax Application_Start内
        /// </summary>
        public static void InitConfig()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        /// <summary>
        /// 设置配置文件
        /// </summary>
        /// <param name="configFile">配置文件信息</param>
        public static void SetConfig(FileInfo configFile)
        {
            log4net.Config.XmlConfigurator.Configure(configFile);
        }

        /// <summary>
        /// 设置启用日志级别
        /// </summary>
        /// <param name="level">日志级别</param>
        public static void IsEnabledFor(Level level)
        {
            _appLogger.Logger.IsEnabledFor(level);
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 写入Debug信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void Debug(string message, Exception ex = null)
        {
            Write(message, LogMessageType.Debug, ex);
        }
        /// <summary>
        /// 写入Info信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void Info(string message, Exception ex = null)
        {
            Write(message, LogMessageType.Info, ex);
        }
        /// <summary>
        /// 写入Warn信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void Warn(string message, Exception ex = null)
        {
            Write(message, LogMessageType.Warn, ex);
        }
        /// <summary>
        /// 写入Error信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void Error(string message, Exception ex = null)
        {
            Write(message, LogMessageType.Error, ex);
        }
        /// <summary>
        /// 写入Error信息,以规范化格式显示
        /// </summary>
        /// <param name="ex"></param>
        public static void Error(Exception ex)
        {
            Write(string.Empty, LogMessageType.Error, ex);
        }
        /// <summary>
        /// 写入Fatal(致命错误)信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void Fatal(string message, Exception ex = null)
        {
            Write(message, LogMessageType.Fatal, ex);
        }
        /// <summary>
        /// 写入Fatal(致命错误)信息,以规范化格式显示
        /// </summary>
        /// <param name="ex"></param>
        public static void Fatal(Exception ex)
        {
            Write(string.Empty, LogMessageType.Fatal, ex);
        }
        /// <summary>
        /// 写入交易信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void Trade(string message, Exception ex = null)
        {
            Write(message, LogMessageType.Trade, ex);
        }
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="messageType">日志类型</param>
        /// <param name="ex">异常对象</param>
        public static void Write(string message, LogMessageType messageType, Exception ex = null)
        {
            WriteLog(message, messageType, ex);
        }
        /// <summary>
        /// 断言
        /// </summary>
        /// <param name="condition">条件</param>
        /// <param name="message">日志信息</param>
        /// <param name="type">日志类型</param>
        public static void Assert(bool condition, string message)
        {
            if (condition == false)
                Write(message, LogMessageType.Info);
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 保存日志
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="messageType">日志类型</param>
        /// <param name="ex">异常</param>
        /// <param name="type">日志类型</param>
        private static void WriteLog(string message, LogMessageType messageType, Exception ex)
        {
            switch (messageType)
            {
                //一般信息
                case LogMessageType.Debug:
                    _appLogger.Debug(message, ex);
                    break;
                case LogMessageType.Info:
                    _appLogger.Info(message, ex);
                    break;
                case LogMessageType.Warn:
                    _appLogger.Warn(message, ex);
                    break;

                //错误信息
                case LogMessageType.Error:
                    _errorLogger.Error(GetExceptionMessage("捕获到异常错误信息", ex, message));
                    break;
                case LogMessageType.Fatal:
                    _errorLogger.Fatal(GetExceptionMessage("捕获到致命错误信息", ex, message));
                    break;

                //交易相关信息
                case LogMessageType.Trade:
                    _tradeLogger.Info(message, ex);
                    break;
                default:
                    _appLogger.Info(message, ex);
                    break;
            }
        }

        /// <summary>
        /// 设置异常信息
        /// </summary>
        /// <param name="errorTitle"></param>
        /// <param name="ex"></param>
        /// <param name="backMessage"></param>
        /// <returns></returns>
        private static string GetExceptionMessage(string errorTitle, Exception ex, string backMessage)
        {
            string errorGuid = Guid.NewGuid().ToString().Replace("-", "").Trim();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine(string.Format("****************************{0}****************************", errorTitle));
            sb.AppendLine(string.Format("【GUID】：{0}", errorGuid));
            sb.AppendLine("【出现时间】：" + DateTime.Now);
            if (ex != null)
            {
                sb.AppendLine("【异常类型】：" + ex.GetType().Name);
                sb.AppendLine("【异常信息】：" + ex.Message);
                sb.AppendLine("【堆栈调用】：" + ex.StackTrace);
                sb.AppendLine("【异常方法】：" + ex.TargetSite);
            }
            else
            {
                sb.AppendLine("【未处理异常】：" + backMessage);
            }
            sb.AppendLine("***********************************************************************");
            return sb.ToString();
        }
        #endregion
    }

    public enum LogMessageType
    {
        /// <summary>
        /// 调试
        /// </summary>
        Debug,
        /// <summary>
        /// 信息
        /// </summary>
        Info,
        /// <summary>
        /// 警告
        /// </summary>
        Warn,
        /// <summary>
        /// 错误
        /// </summary>
        Error,
        /// <summary>
        /// 致命错误
        /// </summary>
        Fatal,
        /// <summary>
        /// 交易信息(单独存放交易操作)
        /// </summary>
        Trade,
    }
}
