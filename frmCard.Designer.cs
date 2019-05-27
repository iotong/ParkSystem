namespace ChargeWin
{
    partial class frmCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbCardCode = new System.Windows.Forms.RadioButton();
            this.txtPlateId = new System.Windows.Forms.TextBox();
            this.txtCardCode = new System.Windows.Forms.TextBox();
            this.rbPlateId = new System.Windows.Forms.RadioButton();
            this.lbCardCode = new System.Windows.Forms.Label();
            this.lbPlateId = new System.Windows.Forms.Label();
            this.cbReason = new System.Windows.Forms.ComboBox();
            this.cbCarType = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.cbReason);
            this.panel1.Controls.Add(this.cbCarType);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(311, 237);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbCardCode);
            this.groupBox1.Controls.Add(this.txtPlateId);
            this.groupBox1.Controls.Add(this.txtCardCode);
            this.groupBox1.Controls.Add(this.rbPlateId);
            this.groupBox1.Controls.Add(this.lbCardCode);
            this.groupBox1.Controls.Add(this.lbPlateId);
            this.groupBox1.Location = new System.Drawing.Point(12, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "进场方式";
            // 
            // rbCardCode
            // 
            this.rbCardCode.AutoSize = true;
            this.rbCardCode.Location = new System.Drawing.Point(160, 20);
            this.rbCardCode.Name = "rbCardCode";
            this.rbCardCode.Size = new System.Drawing.Size(71, 16);
            this.rbCardCode.TabIndex = 77;
            this.rbCardCode.Text = "刷卡进场";
            this.rbCardCode.UseVisualStyleBackColor = true;
            this.rbCardCode.Visible = false;
            this.rbCardCode.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // txtPlateId
            // 
            this.txtPlateId.Font = new System.Drawing.Font("楷体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPlateId.ForeColor = System.Drawing.Color.Blue;
            this.txtPlateId.Location = new System.Drawing.Point(75, 47);
            this.txtPlateId.Name = "txtPlateId";
            this.txtPlateId.Size = new System.Drawing.Size(189, 23);
            this.txtPlateId.TabIndex = 0;
            this.txtPlateId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPlateId_KeyPress);
            // 
            // txtCardCode
            // 
            this.txtCardCode.Font = new System.Drawing.Font("楷体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCardCode.ForeColor = System.Drawing.Color.Blue;
            this.txtCardCode.Location = new System.Drawing.Point(75, 47);
            this.txtCardCode.Name = "txtCardCode";
            this.txtCardCode.Size = new System.Drawing.Size(189, 23);
            this.txtCardCode.TabIndex = 42;
            this.txtCardCode.Visible = false;
            this.txtCardCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCardCode_KeyPress);
            this.txtCardCode.Validated += new System.EventHandler(this.txtCardCode_Validated);
            // 
            // rbPlateId
            // 
            this.rbPlateId.AutoSize = true;
            this.rbPlateId.Checked = true;
            this.rbPlateId.Location = new System.Drawing.Point(34, 20);
            this.rbPlateId.Name = "rbPlateId";
            this.rbPlateId.Size = new System.Drawing.Size(83, 16);
            this.rbPlateId.TabIndex = 76;
            this.rbPlateId.TabStop = true;
            this.rbPlateId.Text = "输入车牌号";
            this.rbPlateId.UseVisualStyleBackColor = true;
            this.rbPlateId.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // lbCardCode
            // 
            this.lbCardCode.AutoSize = true;
            this.lbCardCode.Font = new System.Drawing.Font("宋体", 10F);
            this.lbCardCode.Location = new System.Drawing.Point(10, 50);
            this.lbCardCode.Name = "lbCardCode";
            this.lbCardCode.Size = new System.Drawing.Size(63, 14);
            this.lbCardCode.TabIndex = 41;
            this.lbCardCode.Text = "卡片号码";
            this.lbCardCode.Visible = false;
            // 
            // lbPlateId
            // 
            this.lbPlateId.AutoSize = true;
            this.lbPlateId.Font = new System.Drawing.Font("宋体", 10F);
            this.lbPlateId.Location = new System.Drawing.Point(6, 50);
            this.lbPlateId.Name = "lbPlateId";
            this.lbPlateId.Size = new System.Drawing.Size(63, 14);
            this.lbPlateId.TabIndex = 74;
            this.lbPlateId.Text = "车牌号码";
            // 
            // cbReason
            // 
            this.cbReason.Font = new System.Drawing.Font("楷体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbReason.ForeColor = System.Drawing.Color.Blue;
            this.cbReason.FormattingEnabled = true;
            this.cbReason.Items.AddRange(new object[] {
            "新车未上牌",
            "车牌不全",
            "其它"});
            this.cbReason.Location = new System.Drawing.Point(87, 142);
            this.cbReason.Name = "cbReason";
            this.cbReason.Size = new System.Drawing.Size(189, 20);
            this.cbReason.TabIndex = 40;
            this.cbReason.Text = "新车未上牌";
            this.cbReason.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPlateId_KeyPress);
            // 
            // cbCarType
            // 
            this.cbCarType.Font = new System.Drawing.Font("楷体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbCarType.ForeColor = System.Drawing.Color.Blue;
            this.cbCarType.FormattingEnabled = true;
            this.cbCarType.Items.AddRange(new object[] {
            "小型车",
            "中大型车"});
            this.cbCarType.Location = new System.Drawing.Point(87, 97);
            this.cbCarType.Name = "cbCarType";
            this.cbCarType.Size = new System.Drawing.Size(189, 20);
            this.cbCarType.TabIndex = 38;
            this.cbCarType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPlateId_KeyPress);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 10F);
            this.label18.Location = new System.Drawing.Point(12, 144);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(63, 14);
            this.label18.TabIndex = 36;
            this.label18.Text = "原    因";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F);
            this.label3.Location = new System.Drawing.Point(13, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 27;
            this.label3.Text = "车辆类型";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 193);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(311, 44);
            this.panel2.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(68, 9);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(61, 23);
            this.btnOK.TabIndex = 22;
            this.btnOK.Text = "    确定";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(182, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(61, 23);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "    退出";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 237);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCard";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "无";
            this.Text = "输入车牌号或刷卡进场";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmCard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbCarType;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtCardCode;
        private System.Windows.Forms.Label lbCardCode;
        private System.Windows.Forms.ComboBox cbReason;
        private System.Windows.Forms.TextBox txtPlateId;
        private System.Windows.Forms.Label lbPlateId;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbCardCode;
        private System.Windows.Forms.RadioButton rbPlateId;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}