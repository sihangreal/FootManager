namespace StaffManager.UI
{
    partial class AddStaffForm
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
            this.textPlace = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.textIdNum = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.checkCommsion = new DevExpress.XtraEditors.CheckEdit();
            this.textSalary = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.textId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comLevel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboPartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comSex.Properties)).BeginInit();
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
            // textPlace
            // 
            this.textPlace.Location = new System.Drawing.Point(269, 89);
            this.textPlace.Name = "textPlace";
            this.textPlace.Size = new System.Drawing.Size(110, 20);
            this.textPlace.TabIndex = 26;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(203, 92);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(52, 14);
            this.labelControl7.TabIndex = 27;
            this.labelControl7.Text = "员工籍贯:";
            // 
            // textIdNum
            // 
            this.textIdNum.Location = new System.Drawing.Point(70, 133);
            this.textIdNum.Name = "textIdNum";
            this.textIdNum.Size = new System.Drawing.Size(309, 20);
            this.textIdNum.TabIndex = 28;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(12, 136);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(40, 14);
            this.labelControl8.TabIndex = 29;
            this.labelControl8.Text = "护证号:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(27, 282);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(135, 37);
            this.btnAdd.TabIndex = 31;
            this.btnAdd.Tag = "添加员工";
            this.btnAdd.Text = "添加";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(217, 282);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(135, 37);
            this.btnReset.TabIndex = 32;
            this.btnReset.Text = "重置";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.checkCommsion);
            this.groupControl1.Controls.Add(this.textSalary);
            this.groupControl1.Controls.Add(this.labelControl9);
            this.groupControl1.Location = new System.Drawing.Point(12, 177);
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
            // AddStaffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 337);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.textIdNum);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.textPlace);
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
            this.Name = "AddStaffForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加员工";
            ((System.ComponentModel.ISupportInitialize)(this.textId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comLevel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboPartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comSex.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit textPlace;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit textIdNum;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnReset;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckEdit checkCommsion;
        private DevExpress.XtraEditors.TextEdit textSalary;
        private DevExpress.XtraEditors.LabelControl labelControl9;
    }
}