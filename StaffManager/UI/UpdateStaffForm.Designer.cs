namespace StaffManager.UI
{
    partial class UpdateStaffForm
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
            this.textId = new DevExpress.XtraEditors.TextEdit();
            this.textName = new DevExpress.XtraEditors.TextEdit();
            this.comLevel = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboPartment = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.comSex = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.textBirthDay = new DevExpress.XtraEditors.DateEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.textPlace = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.textIdNum = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.checkCommsion = new DevExpress.XtraEditors.CheckEdit();
            this.textSalary = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.textId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comLevel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboPartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comSex.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBirthDay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBirthDay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPlace.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textIdNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkCommsion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textSalary.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textId
            // 
            this.textId.Enabled = false;
            this.textId.Location = new System.Drawing.Point(70, 9);
            this.textId.Name = "textId";
            this.textId.Size = new System.Drawing.Size(110, 20);
            this.textId.TabIndex = 5;
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(269, 9);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(110, 20);
            this.textName.TabIndex = 6;
            // 
            // comLevel
            // 
            this.comLevel.Location = new System.Drawing.Point(269, 48);
            this.comLevel.Name = "comLevel";
            this.comLevel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comLevel.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comLevel.Size = new System.Drawing.Size(110, 20);
            this.comLevel.TabIndex = 12;
            // 
            // comboPartment
            // 
            this.comboPartment.Location = new System.Drawing.Point(70, 48);
            this.comboPartment.Name = "comboPartment";
            this.comboPartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboPartment.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboPartment.Size = new System.Drawing.Size(110, 20);
            this.comboPartment.TabIndex = 17;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 18;
            this.labelControl1.Text = "员工编号:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(203, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 14);
            this.labelControl2.TabIndex = 19;
            this.labelControl2.Text = "员工姓名:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 51);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(52, 14);
            this.labelControl3.TabIndex = 20;
            this.labelControl3.Text = "所属部门:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(203, 51);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(52, 14);
            this.labelControl4.TabIndex = 21;
            this.labelControl4.Text = "员工职称:";
            // 
            // comSex
            // 
            this.comSex.Location = new System.Drawing.Point(70, 89);
            this.comSex.Name = "comSex";
            this.comSex.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comSex.Properties.Items.AddRange(new object[] {
            "男",
            "女"});
            this.comSex.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comSex.Size = new System.Drawing.Size(110, 20);
            this.comSex.TabIndex = 22;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 92);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(52, 14);
            this.labelControl5.TabIndex = 23;
            this.labelControl5.Text = "员工性别:";
            // 
            // textBirthDay
            // 
            this.textBirthDay.EditValue = null;
            this.textBirthDay.Location = new System.Drawing.Point(267, 89);
            this.textBirthDay.Name = "textBirthDay";
            this.textBirthDay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.textBirthDay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.textBirthDay.Properties.DisplayFormat.FormatString = "";
            this.textBirthDay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.textBirthDay.Properties.EditFormat.FormatString = "";
            this.textBirthDay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.textBirthDay.Properties.Mask.EditMask = "";
            this.textBirthDay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.textBirthDay.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.textBirthDay.Size = new System.Drawing.Size(112, 20);
            this.textBirthDay.TabIndex = 24;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(203, 92);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(52, 14);
            this.labelControl6.TabIndex = 25;
            this.labelControl6.Text = "员工生日:";
            // 
            // textPlace
            // 
            this.textPlace.Location = new System.Drawing.Point(70, 130);
            this.textPlace.Name = "textPlace";
            this.textPlace.Size = new System.Drawing.Size(110, 20);
            this.textPlace.TabIndex = 26;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(12, 133);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(52, 14);
            this.labelControl7.TabIndex = 27;
            this.labelControl7.Text = "员工籍贯:";
            // 
            // textIdNum
            // 
            this.textIdNum.Location = new System.Drawing.Point(70, 173);
            this.textIdNum.Name = "textIdNum";
            this.textIdNum.Size = new System.Drawing.Size(309, 20);
            this.textIdNum.TabIndex = 28;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(12, 176);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(52, 14);
            this.labelControl8.TabIndex = 29;
            this.labelControl8.Text = "身份证号:";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(27, 321);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(135, 37);
            this.btnQuery.TabIndex = 31;
            this.btnQuery.Tag = "修改员工信息";
            this.btnQuery.Text = "确认";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(214, 321);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 37);
            this.btnCancel.TabIndex = 32;
            this.btnCancel.Text = "取消";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.checkCommsion);
            this.groupControl1.Controls.Add(this.textSalary);
            this.groupControl1.Controls.Add(this.labelControl9);
            this.groupControl1.Location = new System.Drawing.Point(12, 209);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(367, 86);
            this.groupControl1.TabIndex = 33;
            this.groupControl1.Text = "工资组成";
            // 
            // checkCommsion
            // 
            this.checkCommsion.Location = new System.Drawing.Point(233, 42);
            this.checkCommsion.Name = "checkCommsion";
            this.checkCommsion.Properties.Caption = "是否参加提成";
            this.checkCommsion.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.checkCommsion.Size = new System.Drawing.Size(95, 19);
            this.checkCommsion.TabIndex = 2;
            // 
            // textSalary
            // 
            this.textSalary.Location = new System.Drawing.Point(58, 42);
            this.textSalary.Name = "textSalary";
            this.textSalary.Size = new System.Drawing.Size(150, 20);
            this.textSalary.TabIndex = 1;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(15, 42);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(24, 14);
            this.labelControl9.TabIndex = 0;
            this.labelControl9.Text = "底薪";
            // 
            // UpdateStaffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 380);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.textIdNum);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.textPlace);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.textBirthDay);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.comSex);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.comboPartment);
            this.Controls.Add(this.comLevel);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.textId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateStaffForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改";
            ((System.ComponentModel.ISupportInitialize)(this.textId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comLevel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboPartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comSex.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBirthDay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBirthDay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPlace.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textIdNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkCommsion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textSalary.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textId;
        private DevExpress.XtraEditors.TextEdit textName;
        private DevExpress.XtraEditors.ComboBoxEdit comLevel;
        private DevExpress.XtraEditors.ComboBoxEdit comboPartment;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ComboBoxEdit comSex;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.DateEdit textBirthDay;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit textPlace;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit textIdNum;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckEdit checkCommsion;
        private DevExpress.XtraEditors.TextEdit textSalary;
        private DevExpress.XtraEditors.LabelControl labelControl9;
    }
}