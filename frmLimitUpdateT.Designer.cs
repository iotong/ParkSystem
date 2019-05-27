namespace ChargeWin
{
    partial class frmLimitUpdateT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLimitUpdateT));
            this.grbInfo = new System.Windows.Forms.GroupBox();
            this.dtpOverTime = new System.Windows.Forms.DateTimePicker();
            this.tbxGender = new System.Windows.Forms.TextBox();
            this.lblOverTime = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.dtpCreateTime = new System.Windows.Forms.DateTimePicker();
            this.lblCreateTime = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.tbxFcName = new System.Windows.Forms.TextBox();
            this.tbxCode = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblPlateId = new System.Windows.Forms.Label();
            this.lblTelphone = new System.Windows.Forms.Label();
            this.tbxPlateId = new System.Windows.Forms.TextBox();
            this.tbxTelphone = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grbInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbInfo
            // 
            this.grbInfo.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grbInfo.Controls.Add(this.dtpOverTime);
            this.grbInfo.Controls.Add(this.tbxGender);
            this.grbInfo.Controls.Add(this.lblOverTime);
            this.grbInfo.Controls.Add(this.lblName);
            this.grbInfo.Controls.Add(this.dtpCreateTime);
            this.grbInfo.Controls.Add(this.lblCreateTime);
            this.grbInfo.Controls.Add(this.lblSex);
            this.grbInfo.Controls.Add(this.tbxFcName);
            this.grbInfo.Controls.Add(this.tbxCode);
            this.grbInfo.Controls.Add(this.lblCode);
            this.grbInfo.Controls.Add(this.lblPlateId);
            this.grbInfo.Controls.Add(this.lblTelphone);
            this.grbInfo.Controls.Add(this.tbxPlateId);
            this.grbInfo.Controls.Add(this.tbxTelphone);
            this.grbInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.grbInfo.Location = new System.Drawing.Point(1, 12);
            this.grbInfo.Name = "grbInfo";
            this.grbInfo.Size = new System.Drawing.Size(361, 247);
            this.grbInfo.TabIndex = 25;
            this.grbInfo.TabStop = false;
            this.grbInfo.Text = "基本信息";
            // 
            // dtpOverTime
            // 
            this.dtpOverTime.Location = new System.Drawing.Point(80, 186);
            this.dtpOverTime.Name = "dtpOverTime";
            this.dtpOverTime.Size = new System.Drawing.Size(275, 21);
            this.dtpOverTime.TabIndex = 40;
            // 
            // tbxGender
            // 
            this.tbxGender.Enabled = false;
            this.tbxGender.Location = new System.Drawing.Point(87, 101);
            this.tbxGender.Name = "tbxGender";
            this.tbxGender.ReadOnly = true;
            this.tbxGender.Size = new System.Drawing.Size(65, 21);
            this.tbxGender.TabIndex = 23;
            // 
            // lblOverTime
            // 
            this.lblOverTime.AutoSize = true;
            this.lblOverTime.Location = new System.Drawing.Point(18, 190);
            this.lblOverTime.Name = "lblOverTime";
            this.lblOverTime.Size = new System.Drawing.Size(59, 12);
            this.lblOverTime.TabIndex = 42;
            this.lblOverTime.Text = "过期时间:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(25, 70);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(59, 12);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "客户姓名:";
            // 
            // dtpCreateTime
            // 
            this.dtpCreateTime.Location = new System.Drawing.Point(80, 145);
            this.dtpCreateTime.Name = "dtpCreateTime";
            this.dtpCreateTime.Size = new System.Drawing.Size(275, 21);
            this.dtpCreateTime.TabIndex = 39;
            // 
            // lblCreateTime
            // 
            this.lblCreateTime.AutoSize = true;
            this.lblCreateTime.Location = new System.Drawing.Point(18, 149);
            this.lblCreateTime.Name = "lblCreateTime";
            this.lblCreateTime.Size = new System.Drawing.Size(59, 12);
            this.lblCreateTime.TabIndex = 41;
            this.lblCreateTime.Text = "建档时间:";
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Location = new System.Drawing.Point(25, 106);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(53, 12);
            this.lblSex.TabIndex = 22;
            this.lblSex.Text = "性   别:";
            // 
            // tbxFcName
            // 
            this.tbxFcName.Enabled = false;
            this.tbxFcName.Location = new System.Drawing.Point(87, 66);
            this.tbxFcName.Name = "tbxFcName";
            this.tbxFcName.ReadOnly = true;
            this.tbxFcName.Size = new System.Drawing.Size(268, 21);
            this.tbxFcName.TabIndex = 1;
            // 
            // tbxCode
            // 
            this.tbxCode.Enabled = false;
            this.tbxCode.Location = new System.Drawing.Point(87, 24);
            this.tbxCode.Name = "tbxCode";
            this.tbxCode.ReadOnly = true;
            this.tbxCode.Size = new System.Drawing.Size(93, 21);
            this.tbxCode.TabIndex = 0;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(25, 28);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(59, 12);
            this.lblCode.TabIndex = 20;
            this.lblCode.Text = "客户代码:";
            // 
            // lblPlateId
            // 
            this.lblPlateId.AutoSize = true;
            this.lblPlateId.Location = new System.Drawing.Point(186, 31);
            this.lblPlateId.Name = "lblPlateId";
            this.lblPlateId.Size = new System.Drawing.Size(59, 12);
            this.lblPlateId.TabIndex = 19;
            this.lblPlateId.Text = "车牌号码:";
            // 
            // lblTelphone
            // 
            this.lblTelphone.AutoSize = true;
            this.lblTelphone.Location = new System.Drawing.Point(158, 106);
            this.lblTelphone.Name = "lblTelphone";
            this.lblTelphone.Size = new System.Drawing.Size(59, 12);
            this.lblTelphone.TabIndex = 16;
            this.lblTelphone.Text = "联系电话:";
            // 
            // tbxPlateId
            // 
            this.tbxPlateId.Enabled = false;
            this.tbxPlateId.Location = new System.Drawing.Point(243, 28);
            this.tbxPlateId.Name = "tbxPlateId";
            this.tbxPlateId.ReadOnly = true;
            this.tbxPlateId.Size = new System.Drawing.Size(112, 21);
            this.tbxPlateId.TabIndex = 5;
            // 
            // tbxTelphone
            // 
            this.tbxTelphone.Enabled = false;
            this.tbxTelphone.Location = new System.Drawing.Point(215, 100);
            this.tbxTelphone.Name = "tbxTelphone";
            this.tbxTelphone.ReadOnly = true;
            this.tbxTelphone.Size = new System.Drawing.Size(140, 21);
            this.tbxTelphone.TabIndex = 4;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(47, 274);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(72, 24);
            this.btnUpdate.TabIndex = 38;
            this.btnUpdate.Text = "  保存(&S)";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(216, 273);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 25);
            this.btnClose.TabIndex = 37;
            this.btnClose.Text = "  退出(&E)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmLimitUpdateT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(362, 319);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grbInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(378, 357);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(378, 357);
            this.Name = "frmLimitUpdateT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改有效期限";
            this.Load += new System.EventHandler(this.frmLimitUpdateT_Load);
            this.grbInfo.ResumeLayout(false);
            this.grbInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbInfo;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.TextBox tbxFcName;
        private System.Windows.Forms.TextBox tbxCode;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblPlateId;
        private System.Windows.Forms.Label lblTelphone;
        private System.Windows.Forms.TextBox tbxPlateId;
        private System.Windows.Forms.TextBox tbxTelphone;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DateTimePicker dtpOverTime;
        private System.Windows.Forms.Label lblOverTime;
        private System.Windows.Forms.DateTimePicker dtpCreateTime;
        private System.Windows.Forms.Label lblCreateTime;
        private System.Windows.Forms.TextBox tbxGender;
    }
}