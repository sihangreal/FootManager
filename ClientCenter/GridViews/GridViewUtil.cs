using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraSplashScreen;

namespace ClientCenter.GridViews
{
    public class GridViewUtil
    {
        private static SplashScreenManager _splashScreenManager;

        #region 初始化gridView
        public static void InitGridView(GridView gridView, Type type)
        {
            gridView.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            gridView.OptionsBehavior.EditorShowMode = EditorShowMode.Click;
            gridView.OptionsBehavior.AllowDeleteRows = DefaultBoolean.False;
            gridView.Appearance.EvenRow.BackColor = Color.LightYellow;
            gridView.OptionsView.EnableAppearanceEvenRow = true;
            gridView.OptionsView.ColumnAutoWidth = true;
            gridView.HorzScrollVisibility = ScrollVisibility.Auto;
            CreateColumnForData(gridView, type);
        }

        private static void CreateColumnForData(GridView gridView, Type type)
        {
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (PropertyInfo info in propertyInfos)
            {
                GridColumn column = new GridColumn();
                gridView.Columns.Add(column);
                column.Name = info.Name;
                column.FieldName = info.Name;
                ColumnAttr columnAttr = (ColumnAttr)info.GetCustomAttribute(typeof(ColumnAttr), false);
                if (columnAttr == null)
                    continue;
                column.Caption = columnAttr.Caption;
                column.Visible = columnAttr.Visble;

                column.OptionsColumn.AllowEdit = columnAttr.IsEdit;
                column.OptionsColumn.AllowFocus = columnAttr.IsEdit;
                column.DisplayFormat.FormatString = "yyyy/MM/dd HH:mm";
                column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                column.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            }
            gridView.Name = type.Name;
        }
        #endregion

        #region 等待界面
        public static void ShowWaitForm()
        {
            if (_splashScreenManager == null)
            {
                return;
            }
            _splashScreenManager.ShowWaitForm();
        }
        public static void ShowWaitForm(Type splashFormType, Form parentForm, string caption = "", string description = "")
        {
            if (_splashScreenManager == null)
            {
                SplashFormProperties info = new SplashFormProperties(parentForm, false, false);

                _splashScreenManager = new SplashScreenManager(splashFormType, info);
            }
            else
            {
                if (_splashScreenManager.Properties.ParentForm != parentForm)
                {
                    _splashScreenManager.Properties = new SplashFormProperties(parentForm, false, false);

                }

                _splashScreenManager.ActiveSplashFormTypeInfo = DevExpress.XtraSplashScreen.TypeInfo.FromType(splashFormType);

            }

            _splashScreenManager.ShowWaitForm();

            if (!String.IsNullOrEmpty(caption))
            {
                _splashScreenManager.SetWaitFormCaption(caption);
            }

            if (!String.IsNullOrEmpty(description))
            {
                _splashScreenManager.SetWaitFormDescription(description);
            }
        }
        public static void CloseWaitForm()
        {
            if (_splashScreenManager == null)
            {
                return;
            }

            _splashScreenManager.CloseWaitForm();

            _splashScreenManager = null;
        }
        public static bool IsWaitFormShowing()
        {
            if (_splashScreenManager == null)
            {
                return false;
            }

            return _splashScreenManager.IsSplashFormVisible;
        }
        #endregion
    }
}
