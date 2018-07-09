using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootManager
{
    public class Mode
    {
        //模板ID
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        //模板名
        private string modeName;
        public string ModeName
        {
            get { return modeName; }
            set { modeName = value; }
        }
        //Dll路径
        private string dllPath;
        public string DllPath
        {
            get { return dllPath; }
            set { dllPath = value; }
        }
        //主控件名
        private string className;
        public string ClassName
        {
            get { return className; }
            set { className = value; }
        }
        //主控件
        private Control modeControl;
        public Control ModeControl
        {
            get { return modeControl; }
            set { modeControl = value; }
        }
        public Mode(string dllPath,string className)
        {
            this.dllPath = dllPath;
            this.className = className;
            Assembly assembly = Assembly.LoadFrom(dllPath);
            Type type = assembly.GetType(className);
            modeControl = (Control)Activator.CreateInstance(type);
        }
    }
}
