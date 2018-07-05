namespace StaffManager.UI
{
    partial class Staff
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labId = new DevExpress.XtraEditors.LabelControl();
            this.labName = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("楷体", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(21, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(75, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "技术编号：";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("楷体", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Location = new System.Drawing.Point(21, 72);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(75, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "技师姓名：";
            // 
            // labId
            // 
            this.labId.Appearance.Font = new System.Drawing.Font("楷体", 10F, System.Drawing.FontStyle.Bold);
            this.labId.Location = new System.Drawing.Point(111, 29);
            this.labId.Name = "labId";
            this.labId.Size = new System.Drawing.Size(16, 13);
            this.labId.TabIndex = 2;
            this.labId.Text = "11";
            // 
            // labName
            // 
            this.labName.Appearance.Font = new System.Drawing.Font("楷体", 10F, System.Drawing.FontStyle.Bold);
            this.labName.Location = new System.Drawing.Point(98, 72);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(45, 14);
            this.labName.TabIndex = 3;
            this.labName.Text = "哎哎哎";
            // 
            // Staff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::StaffManager.Properties.Resources.bule;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.labName);
            this.Controls.Add(this.labId);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.DoubleBuffered = true;
            this.Name = "Staff";
            this.Size = new System.Drawing.Size(180, 125);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labId;
        private DevExpress.XtraEditors.LabelControl labName;
    }
}
