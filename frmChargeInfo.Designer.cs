namespace ChargeWin
{
    partial class frmChargeInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChargeInfo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpOutTime = new System.Windows.Forms.DateTimePicker();
            this.lblOutTime = new System.Windows.Forms.Label();
            this.dtpInTime = new System.Windows.Forms.DateTimePicker();
            this.lblInTime = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnProQuery = new System.Windows.Forms.Button();
            this.txtPlateId = new System.Windows.Forms.TextBox();
            this.lblPlateId = new System.Windows.Forms.Label();
            this.dgvFCustomerInfo = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnToExcel = new System.Windows.Forms.Button();
            this.ucPageBar1 = new www.gzwulian.com.Common.ucPageBar();
            this.sfdDataToExcel = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnChargeToExcel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFCustomerInfo)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnChargeToExcel);
            this.groupBox1.Controls.Add(this.dtpOutTime);
            this.groupBox1.Controls.Add(this.lblOutTime);
            this.groupBox1.Controls.Add(this.dtpInTime);
            this.groupBox1.Controls.Add(this.lblInTime);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnProQuery);
            this.groupBox1.Controls.Add(this.txtPlateId);
            this.groupBox1.Controls.Add(this.lblPlateId);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(846, 65);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // dtpOutTime
            // 
            this.dtpOutTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpOutTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOutTime.Location = new System.Drawing.Point(416, 18);
            this.dtpOutTime.Name = "dtpOutTime";
            this.dtpOutTime.ShowCheckBox = true;
            this.dtpOutTime.Size = new System.Drawing.Size(120, 21);
            this.dtpOutTime.TabIndex = 56;
            // 
            // lblOutTime
            // 
            this.lblOutTime.AutoSize = true;
            this.lblOutTime.Location = new System.Drawing.Point(354, 24);
            this.lblOutTime.Name = "lblOutTime";
            this.lblOutTime.Size = new System.Drawing.Size(59, 12);
            this.lblOutTime.TabIndex = 55;
            this.lblOutTime.Text = "结束时间:";
            // 
            // dtpInTime
            // 
            this.dtpInTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpInTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInTime.Location = new System.Drawing.Point(219, 18);
            this.dtpInTime.Name = "dtpInTime";
            this.dtpInTime.ShowCheckBox = true;
            this.dtpInTime.Size = new System.Drawing.Size(129, 21);
            this.dtpInTime.TabIndex = 54;
            // 
            // lblInTime
            // 
            this.lblInTime.AutoSize = true;
            this.lblInTime.Location = new System.Drawing.Point(159, 24);
            this.lblInTime.Name = "lblInTime";
            this.lblInTime.Size = new System.Drawing.Size(59, 12);
            this.lblInTime.TabIndex = 53;
            this.lblInTime.Text = "开始时间:";
            // 
            // btnReset
            // 
            this.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnReset.Font = new System.Drawing.Font("宋体", 9F);
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset.Location = new System.Drawing.Point(629, 20);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(81, 22);
            this.btnReset.TabIndex = 48;
            this.btnReset.Text = "  重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnProQuery
            // 
            this.btnProQuery.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnProQuery.Font = new System.Drawing.Font("宋体", 9F);
            this.btnProQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnProQuery.Image")));
            this.btnProQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProQuery.Location = new System.Drawing.Point(542, 19);
            this.btnProQuery.Name = "btnProQuery";
            this.btnProQuery.Size = new System.Drawing.Size(81, 22);
            this.btnProQuery.TabIndex = 47;
            this.btnProQuery.Text = "  查询";
            this.btnProQuery.UseVisualStyleBackColor = true;
            this.btnProQuery.Click += new System.EventHandler(this.btnProQuery_Click);
            // 
            // txtPlateId
            // 
            this.txtPlateId.Location = new System.Drawing.Point(68, 20);
            this.txtPlateId.Name = "txtPlateId";
            this.txtPlateId.Size = new System.Drawing.Size(83, 21);
            this.txtPlateId.TabIndex = 5;
            // 
            // lblPlateId
            // 
            this.lblPlateId.AutoSize = true;
            this.lblPlateId.Location = new System.Drawing.Point(8, 24);
            this.lblPlateId.Name = "lblPlateId";
            this.lblPlateId.Size = new System.Drawing.Size(59, 12);
            this.lblPlateId.TabIndex = 4;
            this.lblPlateId.Text = "车牌号码:";
            // 
            // dgvFCustomerInfo
            // 
            this.dgvFCustomerInfo.AllowUserToAddRows = false;
            this.dgvFCustomerInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgvFCustomerInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvFCustomerInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFCustomerInfo.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFCustomerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFCustomerInfo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvFCustomerInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvFCustomerInfo.Name = "dgvFCustomerInfo";
            this.dgvFCustomerInfo.ReadOnly = true;
            this.dgvFCustomerInfo.RowTemplate.Height = 23;
            this.dgvFCustomerInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFCustomerInfo.Size = new System.Drawing.Size(846, 521);
            this.dgvFCustomerInfo.TabIndex = 10;
            // 
            // btnToExcel
            // 
            this.btnToExcel.Location = new System.Drawing.Point(860, 445);
            this.btnToExcel.Name = "btnToExcel";
            this.btnToExcel.Size = new System.Drawing.Size(75, 23);
            this.btnToExcel.TabIndex = 9;
            this.btnToExcel.Text = "导出Excel";
            this.btnToExcel.UseVisualStyleBackColor = true;
            this.btnToExcel.Click += new System.EventHandler(this.btnToExcel_Click);
            // 
            // ucPageBar1
            // 
            this.ucPageBar1.CurrentPage = ((uint)(1u));
            this.ucPageBar1.Location = new System.Drawing.Point(1, 588);
            this.ucPageBar1.Name = "ucPageBar1";
            this.ucPageBar1.PageSize = ((uint)(10u));
            this.ucPageBar1.RecordCount = ((uint)(0u));
            this.ucPageBar1.Size = new System.Drawing.Size(489, 27);
            this.ucPageBar1.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(848, 59);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgvFCustomerInfo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 59);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(848, 523);
            this.panel2.TabIndex = 13;
            // 
            // btnChargeToExcel
            // 
            this.btnChargeToExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnChargeToExcel.Font = new System.Drawing.Font("宋体", 9F);
            this.btnChargeToExcel.Image = global::ChargeWin.Properties.Resources._out;
            this.btnChargeToExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChargeToExcel.Location = new System.Drawing.Point(726, 20);
            this.btnChargeToExcel.Name = "btnChargeToExcel";
            this.btnChargeToExcel.Size = new System.Drawing.Size(94, 22);
            this.btnChargeToExcel.TabIndex = 49;
            this.btnChargeToExcel.Text = "  导出Excel";
            this.btnChargeToExcel.UseVisualStyleBackColor = true;
            this.btnChargeToExcel.Click += new System.EventHandler(this.btnChargeToExcel_Click);
            // 
            // frmChargeInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(848, 610);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ucPageBar1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnToExcel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChargeInfo";
            this.Text = "收费记录";
            this.Load += new System.EventHandler(this.frmWorkRecord_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFCustomerInfo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnProQuery;
        private System.Windows.Forms.TextBox txtPlateId;
        private System.Windows.Forms.Label lblPlateId;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvFCustomerInfo;
        private System.Windows.Forms.Button btnToExcel;
        private www.gzwulian.com.Common.ucPageBar ucPageBar1;
        private System.Windows.Forms.SaveFileDialog sfdDataToExcel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnChargeToExcel;
        private System.Windows.Forms.DateTimePicker dtpOutTime;
        private System.Windows.Forms.Label lblOutTime;
        private System.Windows.Forms.DateTimePicker dtpInTime;
        private System.Windows.Forms.Label lblInTime;
    }
}