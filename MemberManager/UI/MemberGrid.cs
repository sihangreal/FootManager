using System;
using System.Collections.Generic;
using ClientCenter.Core;

namespace MemberManager.UI
{
    public partial class MemberGrid : DevExpress.XtraEditors.XtraUserControl
    {
        public MemberGrid(Type type,string caption)
        {
            InitializeComponent();
            InitEvents();
            GridViewUtil.CreateColumnForData(this.gridView1, type);
            this.gridView1.ViewCaption = caption;
        }

        #region private method
        private void InitEvents()
        {
            this.Load += MemberGrid_Load;
        }
        #endregion

        #region public method
        public void SetData<T>(List<T> voList)
        {
            this.gridControl1.DataSource = voList;
            this.gridControl1.RefreshDataSource();
            this.gridView1.BestFitColumns();
        }
        #endregion

        #region events
        private void MemberGrid_Load(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
