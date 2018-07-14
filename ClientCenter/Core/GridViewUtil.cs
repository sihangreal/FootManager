using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Reflection;

namespace ClientCenter.Core
{
    public class GridViewUtil
    {
        public static void CreateColumnForData(GridView gridView, Type type)
        {
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach(PropertyInfo info in propertyInfos)
            {
                GridColumn column = new GridColumn();
                gridView.Columns.Add(column);
                column.Name = info.Name;
                column.FieldName= info.Name;
                ColumnAttr columnAttr=(ColumnAttr)info.GetCustomAttribute(typeof(ColumnAttr),false);
                if (columnAttr == null)
                    continue;
                column.Caption = columnAttr.Caption;
                column.Visible = columnAttr.Visble;
                //column.OptionsColumn.AllowEdit = false;
                //column.OptionsColumn.AllowFocus = false;
                //column.OptionsColumn.AllowSort = DefaultBoolean.False;
                column.DisplayFormat.FormatString="yyyy/MM/dd HH:mm";
                //column.BestFit();
                column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                column.AppearanceHeader.TextOptions.HAlignment= HorzAlignment.Center;
            }
            gridView.Name = type.Name;
        }

        public static DataTable CreateDataTabelForData(GridView gridView, Type type)
        {
            DataTable table = new DataTable();
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (PropertyInfo info in propertyInfos)
            {
                DataColumn tablecolumn = new DataColumn(info.Name);
                table.Columns.Add(tablecolumn);
                GridColumn column = new GridColumn();
                gridView.Columns.Add(column);
                column.Name = info.Name;
                column.FieldName = info.Name;
                ColumnAttr columnAttr = (ColumnAttr)info.GetCustomAttribute(typeof(ColumnAttr), false);
                if (columnAttr == null)
                    continue;
                column.Caption = columnAttr.Caption;
                column.Visible = columnAttr.Visble;
                column.OptionsColumn.AllowEdit = false;
                column.OptionsColumn.AllowFocus = false;
                column.OptionsColumn.AllowSort = DefaultBoolean.False;
                column.DisplayFormat.FormatString = "yyyy/MM/dd HH:mm";
                column.BestFit();
                column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                column.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            }
            table.TableName = type.Name;
            return table;
        }
    }
}
