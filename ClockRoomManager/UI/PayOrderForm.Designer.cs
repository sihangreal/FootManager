namespace ClockRoomManager.UI
{
    partial class PayOrderForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textMemberId = new DevExpress.XtraEditors.TextEdit();
            this.btnReadCard = new DevExpress.XtraEditors.SimpleButton();
            this.comboType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.textPrice = new DevExpress.XtraEditors.TextEdit();
            this.textGst = new DevExpress.XtraEditors.TextEdit();
            this.textTotal = new DevExpress.XtraEditors.TextEdit();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textMemberId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textGst.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textTotal.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "会员：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 53);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "付款方式：";
            // 
            // textMemberId
            // 
            this.textMemberId.Location = new System.Drawing.Point(99, 12);
            this.textMemberId.Name = "textMemberId";
            this.textMemberId.Size = new System.Drawing.Size(135, 20);
            this.textMemberId.TabIndex = 2;
            // 
            // btnReadCard
            // 
            this.btnReadCard.Location = new System.Drawing.Point(250, 10);
            this.btnReadCard.Name = "btnReadCard";
            this.btnReadCard.Size = new System.Drawing.Size(61, 23);
            this.btnReadCard.TabIndex = 3;
            this.btnReadCard.Text = "读卡";
            // 
            // comboType
            // 
            this.comboType.Location = new System.Drawing.Point(99, 51);
            this.comboType.Name = "comboType";
            this.comboType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboType.Size = new System.Drawing.Size(135, 20);
            this.comboType.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 102);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 14);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "服务消费：";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 144);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(81, 14);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "消费税(GST)：";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 183);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(36, 14);
            this.labelControl5.TabIndex = 7;
            this.labelControl5.Text = "总价：";
            // 
            // textPrice
            // 
            this.textPrice.Location = new System.Drawing.Point(99, 96);
            this.textPrice.Name = "textPrice";
            this.textPrice.Properties.ReadOnly = true;
            this.textPrice.Size = new System.Drawing.Size(135, 20);
            this.textPrice.TabIndex = 8;
            // 
            // textGst
            // 
            this.textGst.Location = new System.Drawing.Point(99, 141);
            this.textGst.Name = "textGst";
            this.textGst.Properties.ReadOnly = true;
            this.textGst.Size = new System.Drawing.Size(135, 20);
            this.textGst.TabIndex = 9;
            // 
            // textTotal
            // 
            this.textTotal.Location = new System.Drawing.Point(99, 182);
            this.textTotal.Name = "textTotal";
            this.textTotal.Properties.ReadOnly = true;
            this.textTotal.Size = new System.Drawing.Size(135, 20);
            this.textTotal.TabIndex = 10;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(126, 226);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(78, 23);
            this.btnQuery.TabIndex = 11;
            this.btnQuery.Text = "确定";
            // 
            // PayOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 261);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.textTotal);
            this.Controls.Add(this.textGst);
            this.Controls.Add(this.textPrice);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.comboType);
            this.Controls.Add(this.btnReadCard);
            this.Controls.Add(this.textMemberId);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PayOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "买单";
            ((System.ComponentModel.ISupportInitialize)(this.textMemberId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textGst.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textTotal.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit textMemberId;
        private DevExpress.XtraEditors.SimpleButton btnReadCard;
        private DevExpress.XtraEditors.ComboBoxEdit comboType;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit textPrice;
        private DevExpress.XtraEditors.TextEdit textGst;
        private DevExpress.XtraEditors.TextEdit textTotal;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
    }
}