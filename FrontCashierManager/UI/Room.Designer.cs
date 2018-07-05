namespace FrontCashierManager.UI
{
    partial class Room
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
            this.labroomId = new DevExpress.XtraEditors.LabelControl();
            this.labroomName = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(3, 20);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "钟房编号：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(3, 60);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "钟房名字：";
            // 
            // labroomId
            // 
            this.labroomId.Location = new System.Drawing.Point(60, 20);
            this.labroomId.Name = "labroomId";
            this.labroomId.Size = new System.Drawing.Size(70, 14);
            this.labroomId.TabIndex = 3;
            this.labroomId.Text = "labelControl4";
            // 
            // labroomName
            // 
            this.labroomName.Location = new System.Drawing.Point(60, 60);
            this.labroomName.Name = "labroomName";
            this.labroomName.Size = new System.Drawing.Size(70, 14);
            this.labroomName.TabIndex = 4;
            this.labroomName.Text = "labelControl5";
            // 
            // Room
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labroomName);
            this.Controls.Add(this.labroomId);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "Room";
            this.Size = new System.Drawing.Size(130, 100);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labroomId;
        private DevExpress.XtraEditors.LabelControl labroomName;
    }
}
