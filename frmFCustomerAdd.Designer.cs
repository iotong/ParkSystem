namespace ChargeWin
{
    partial class frmFCustomerAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFCustomerAdd));
            this.lblName = new System.Windows.Forms.Label();
            this.tbxFcName = new System.Windows.Forms.TextBox();
            this.tbxCode = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblPlateId = new System.Windows.Forms.Label();
            this.tbxPlateId = new System.Windows.Forms.TextBox();
            this.tbxTelphone = new System.Windows.Forms.TextBox();
            this.lblTelphone = new System.Windows.Forms.Label();
            this.tbxIdCard = new System.Windows.Forms.TextBox();
            this.lblIdCard = new System.Windows.Forms.Label();
            this.cbbSex = new System.Windows.Forms.ComboBox();
            this.lblSex = new System.Windows.Forms.Label();
            this.grbInfo = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCarType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxPlateColor = new System.Windows.Forms.TextBox();
            this.lblPlateColor = new System.Windows.Forms.Label();
            this.lblCreateTime = new System.Windows.Forms.Label();
            this.dtpCreateTime = new System.Windows.Forms.DateTimePicker();
            this.lblOverTime = new System.Windows.Forms.Label();
            this.dtpOverTime = new System.Windows.Forms.DateTimePicker();
            this.cbxEnable = new System.Windows.Forms.CheckBox();
            this.lblTimeSeg = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grbInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(55, 72);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(59, 12);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "客户姓名:";
            // 
            // tbxFcName
            // 
            this.tbxFcName.Location = new System.Drawing.Point(123, 68);
            this.tbxFcName.Name = "tbxFcName";
            this.tbxFcName.Size = new System.Drawing.Size(83, 21);
            this.tbxFcName.TabIndex = 1;
            // 
            // tbxCode
            // 
            this.tbxCode.Location = new System.Drawing.Point(123, 31);
            this.tbxCode.Name = "tbxCode";
            this.tbxCode.Size = new System.Drawing.Size(83, 21);
            this.tbxCode.TabIndex = 0;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(57, 35);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(59, 12);
            this.lblCode.TabIndex = 20;
            this.lblCode.Text = "车主编号:";
            // 
            // lblPlateId
            // 
            this.lblPlateId.AutoSize = true;
            this.lblPlateId.Location = new System.Drawing.Point(55, 167);
            this.lblPlateId.Name = "lblPlateId";
            this.lblPlateId.Size = new System.Drawing.Size(59, 12);
            this.lblPlateId.TabIndex = 19;
            this.lblPlateId.Text = "车牌号码:";
            // 
            // tbxPlateId
            // 
            this.tbxPlateId.Location = new System.Drawing.Point(123, 163);
            this.tbxPlateId.Name = "tbxPlateId";
            this.tbxPlateId.Size = new System.Drawing.Size(78, 21);
            this.tbxPlateId.TabIndex = 5;
            // 
            // tbxTelphone
            // 
            this.tbxTelphone.Location = new System.Drawing.Point(125, 130);
            this.tbxTelphone.Name = "tbxTelphone";
            this.tbxTelphone.Size = new System.Drawing.Size(237, 21);
            this.tbxTelphone.TabIndex = 4;
            this.tbxTelphone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxTelphone_KeyPress);
            // 
            // lblTelphone
            // 
            this.lblTelphone.AutoSize = true;
            this.lblTelphone.Location = new System.Drawing.Point(53, 133);
            this.lblTelphone.Name = "lblTelphone";
            this.lblTelphone.Size = new System.Drawing.Size(59, 12);
            this.lblTelphone.TabIndex = 16;
            this.lblTelphone.Text = "联系电话:";
            // 
            // tbxIdCard
            // 
            this.tbxIdCard.Location = new System.Drawing.Point(125, 98);
            this.tbxIdCard.Name = "tbxIdCard";
            this.tbxIdCard.Size = new System.Drawing.Size(237, 21);
            this.tbxIdCard.TabIndex = 3;
            // 
            // lblIdCard
            // 
            this.lblIdCard.AutoSize = true;
            this.lblIdCard.Location = new System.Drawing.Point(51, 104);
            this.lblIdCard.Name = "lblIdCard";
            this.lblIdCard.Size = new System.Drawing.Size(59, 12);
            this.lblIdCard.TabIndex = 14;
            this.lblIdCard.Text = "身份证号:";
            // 
            // cbbSex
            // 
            this.cbbSex.FormattingEnabled = true;
            this.cbbSex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.cbbSex.Location = new System.Drawing.Point(279, 68);
            this.cbbSex.Name = "cbbSex";
            this.cbbSex.Size = new System.Drawing.Size(83, 20);
            this.cbbSex.TabIndex = 2;
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Location = new System.Drawing.Point(225, 72);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(53, 12);
            this.lblSex.TabIndex = 22;
            this.lblSex.Text = "性   别:";
            // 
            // grbInfo
            // 
            this.grbInfo.Controls.Add(this.label7);
            this.grbInfo.Controls.Add(this.label6);
            this.grbInfo.Controls.Add(this.label5);
            this.grbInfo.Controls.Add(this.label4);
            this.grbInfo.Controls.Add(this.cbCarType);
            this.grbInfo.Controls.Add(this.label3);
            this.grbInfo.Controls.Add(this.label2);
            this.grbInfo.Controls.Add(this.label1);
            this.grbInfo.Controls.Add(this.tbxPlateColor);
            this.grbInfo.Controls.Add(this.lblPlateColor);
            this.grbInfo.Controls.Add(this.cbbSex);
            this.grbInfo.Controls.Add(this.lblName);
            this.grbInfo.Controls.Add(this.lblSex);
            this.grbInfo.Controls.Add(this.tbxFcName);
            this.grbInfo.Controls.Add(this.tbxCode);
            this.grbInfo.Controls.Add(this.lblIdCard);
            this.grbInfo.Controls.Add(this.lblCode);
            this.grbInfo.Controls.Add(this.tbxIdCard);
            this.grbInfo.Controls.Add(this.lblPlateId);
            this.grbInfo.Controls.Add(this.lblTelphone);
            this.grbInfo.Controls.Add(this.tbxPlateId);
            this.grbInfo.Controls.Add(this.tbxTelphone);
            this.grbInfo.Location = new System.Drawing.Point(12, 12);
            this.grbInfo.Name = "grbInfo";
            this.grbInfo.Size = new System.Drawing.Size(410, 234);
            this.grbInfo.TabIndex = 24;
            this.grbInfo.TabStop = false;
            this.grbInfo.Text = "基本信息";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(38, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 32;
            this.label7.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(210, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(173, 12);
            this.label6.TabIndex = 31;
            this.label6.Text = "一户多车用户以此为标识依据。";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(236, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 12);
            this.label5.TabIndex = 30;
            this.label5.Text = "此编号为车主唯一编号，";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(40, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 29;
            this.label4.Text = "*";
            // 
            // cbCarType
            // 
            this.cbCarType.FormattingEnabled = true;
            this.cbCarType.Items.AddRange(new object[] {
            "固定车辆",
            "内部车辆"});
            this.cbCarType.Location = new System.Drawing.Point(123, 190);
            this.cbCarType.Name = "cbCarType";
            this.cbCarType.Size = new System.Drawing.Size(78, 20);
            this.cbCarType.TabIndex = 27;
            this.cbCarType.Text = "固定车辆";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 28;
            this.label3.Text = "车辆类型:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(41, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 26;
            this.label2.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(38, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 25;
            this.label1.Text = "*";
            // 
            // tbxPlateColor
            // 
            this.tbxPlateColor.Location = new System.Drawing.Point(280, 164);
            this.tbxPlateColor.Name = "tbxPlateColor";
            this.tbxPlateColor.Size = new System.Drawing.Size(81, 21);
            this.tbxPlateColor.TabIndex = 6;
            // 
            // lblPlateColor
            // 
            this.lblPlateColor.AutoSize = true;
            this.lblPlateColor.Location = new System.Drawing.Point(218, 168);
            this.lblPlateColor.Name = "lblPlateColor";
            this.lblPlateColor.Size = new System.Drawing.Size(59, 12);
            this.lblPlateColor.TabIndex = 24;
            this.lblPlateColor.Text = "车牌颜色:";
            // 
            // lblCreateTime
            // 
            this.lblCreateTime.AutoSize = true;
            this.lblCreateTime.Location = new System.Drawing.Point(22, 262);
            this.lblCreateTime.Name = "lblCreateTime";
            this.lblCreateTime.Size = new System.Drawing.Size(59, 12);
            this.lblCreateTime.TabIndex = 25;
            this.lblCreateTime.Text = "建档时间:";
            // 
            // dtpCreateTime
            // 
            this.dtpCreateTime.Location = new System.Drawing.Point(84, 258);
            this.dtpCreateTime.Name = "dtpCreateTime";
            this.dtpCreateTime.Size = new System.Drawing.Size(129, 21);
            this.dtpCreateTime.TabIndex = 10;
            // 
            // lblOverTime
            // 
            this.lblOverTime.AutoSize = true;
            this.lblOverTime.Location = new System.Drawing.Point(224, 264);
            this.lblOverTime.Name = "lblOverTime";
            this.lblOverTime.Size = new System.Drawing.Size(59, 12);
            this.lblOverTime.TabIndex = 27;
            this.lblOverTime.Text = "过期时间:";
            // 
            // dtpOverTime
            // 
            this.dtpOverTime.Location = new System.Drawing.Point(293, 258);
            this.dtpOverTime.Name = "dtpOverTime";
            this.dtpOverTime.Size = new System.Drawing.Size(129, 21);
            this.dtpOverTime.TabIndex = 11;
            // 
            // cbxEnable
            // 
            this.cbxEnable.AutoSize = true;
            this.cbxEnable.Checked = true;
            this.cbxEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxEnable.Location = new System.Drawing.Point(374, 290);
            this.cbxEnable.Name = "cbxEnable";
            this.cbxEnable.Size = new System.Drawing.Size(48, 16);
            this.cbxEnable.TabIndex = 12;
            this.cbxEnable.Text = "启用";
            this.cbxEnable.UseVisualStyleBackColor = true;
            // 
            // lblTimeSeg
            // 
            this.lblTimeSeg.AutoSize = true;
            this.lblTimeSeg.Location = new System.Drawing.Point(15, 262);
            this.lblTimeSeg.Name = "lblTimeSeg";
            this.lblTimeSeg.Size = new System.Drawing.Size(59, 12);
            this.lblTimeSeg.TabIndex = 30;
            this.lblTimeSeg.Text = "时 间 段:";
            this.lblTimeSeg.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(78, 352);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(80, 23);
            this.btnUpdate.TabIndex = 36;
            this.btnUpdate.Text = "   保存(&S)";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(273, 320);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 26);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "   退出(&E)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(78, 320);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 26);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "   添加(&A)";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmFCustomerAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(434, 391);
            this.ControlBox = false;
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblTimeSeg);
            this.Controls.Add(this.cbxEnable);
            this.Controls.Add(this.dtpOverTime);
            this.Controls.Add(this.lblOverTime);
            this.Controls.Add(this.dtpCreateTime);
            this.Controls.Add(this.lblCreateTime);
            this.Controls.Add(this.grbInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(450, 430);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 420);
            this.Name = "frmFCustomerAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmFCustomerAdd";
            this.Load += new System.EventHandler(this.frmFCustomerAdd_Load);
            this.grbInfo.ResumeLayout(false);
            this.grbInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbxFcName;
        private System.Windows.Forms.TextBox tbxCode;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblPlateId;
        private System.Windows.Forms.TextBox tbxPlateId;
        private System.Windows.Forms.TextBox tbxTelphone;
        private System.Windows.Forms.Label lblTelphone;
        private System.Windows.Forms.TextBox tbxIdCard;
        private System.Windows.Forms.Label lblIdCard;
        private System.Windows.Forms.ComboBox cbbSex;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.GroupBox grbInfo;
        private System.Windows.Forms.TextBox tbxPlateColor;
        private System.Windows.Forms.Label lblPlateColor;
        private System.Windows.Forms.Label lblCreateTime;
        private System.Windows.Forms.DateTimePicker dtpCreateTime;
        private System.Windows.Forms.Label lblOverTime;
        private System.Windows.Forms.DateTimePicker dtpOverTime;
        private System.Windows.Forms.CheckBox cbxEnable;
        private System.Windows.Forms.Label lblTimeSeg;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbCarType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
    }
}