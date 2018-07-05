namespace ClockRoomManager.UI
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
            this.labelControl1.Appearance.Font = new System.Drawing.Font("楷体", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(18, 31);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(75, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "钟房编号：";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("楷体", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Location = new System.Drawing.Point(17, 76);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(75, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "钟房名字：";
            // 
            // labroomId
            // 
            this.labroomId.Appearance.Font = new System.Drawing.Font("楷体", 10F, System.Drawing.FontStyle.Bold);
            this.labroomId.Location = new System.Drawing.Point(88, 32);
            this.labroomId.Name = "labroomId";
            this.labroomId.Size = new System.Drawing.Size(24, 13);
            this.labroomId.TabIndex = 3;
            this.labroomId.Text = "100";
            // 
            // labroomName
            // 
            this.labroomName.Appearance.Font = new System.Drawing.Font("楷体", 10F, System.Drawing.FontStyle.Bold);
            this.labroomName.Location = new System.Drawing.Point(88, 76);
            this.labroomName.Name = "labroomName";
            this.labroomName.Size = new System.Drawing.Size(30, 14);
            this.labroomName.TabIndex = 4;
            this.labroomName.Text = "杭州";
            // 
            // Room
            // 
            this.Appearance.ForeColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ClockRoomManager.Properties.Resources.orange;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.labroomName);
            this.Controls.Add(this.labroomId);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.DoubleBuffered = true;
            this.Name = "Room";
            this.Size = new System.Drawing.Size(180, 120);
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
