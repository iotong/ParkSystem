namespace ChargeWin
{
    partial class frmLimitMag
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLimitMag));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grbSelect = new System.Windows.Forms.GroupBox();
            this.ctrlpanel = new System.Windows.Forms.Panel();
            this.gbenquip = new System.Windows.Forms.GroupBox();
            this.btgetall = new System.Windows.Forms.Button();
            this.btseleall = new System.Windows.Forms.Button();
            this.cListEquip = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbxFalseTime = new System.Windows.Forms.CheckBox();
            this.cbxTrueTime = new System.Windows.Forms.CheckBox();
            this.cbxFalseFC = new System.Windows.Forms.CheckBox();
            this.cbxTrueFc = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnProQuery = new System.Windows.Forms.Button();
            this.tbxCode = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblPlateId = new System.Windows.Forms.Label();
            this.tbxPlateId = new System.Windows.Forms.TextBox();
            this.tbxTelphone = new System.Windows.Forms.TextBox();
            this.lblTelphone = new System.Windows.Forms.Label();
            this.tbxIdCard = new System.Windows.Forms.TextBox();
            this.cbbSex = new System.Windows.Forms.ComboBox();
            this.lblIdCard = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.tbxFcName = new System.Windows.Forms.TextBox();
            this.lblFCName = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tspbtnUpdateTime = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tspbtnSyn = new System.Windows.Forms.ToolStripButton();
            this.sfdDataToExcel = new System.Windows.Forms.SaveFileDialog();
            this.ucPageBar1 = new www.gzwulian.com.Common.ucPageBar();
            this.dgvFCustomerInfo = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.grbSelect.SuspendLayout();
            this.gbenquip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFCustomerInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // grbSelect
            // 
            this.grbSelect.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grbSelect.Controls.Add(this.ctrlpanel);
            this.grbSelect.Controls.Add(this.gbenquip);
            this.grbSelect.Controls.Add(this.panel1);
            this.grbSelect.Controls.Add(this.button2);
            this.grbSelect.Controls.Add(this.btnProQuery);
            this.grbSelect.Controls.Add(this.tbxCode);
            this.grbSelect.Controls.Add(this.lblCode);
            this.grbSelect.Controls.Add(this.lblPlateId);
            this.grbSelect.Controls.Add(this.tbxPlateId);
            this.grbSelect.Controls.Add(this.tbxTelphone);
            this.grbSelect.Controls.Add(this.lblTelphone);
            this.grbSelect.Controls.Add(this.tbxIdCard);
            this.grbSelect.Controls.Add(this.cbbSex);
            this.grbSelect.Controls.Add(this.lblIdCard);
            this.grbSelect.Controls.Add(this.lblSex);
            this.grbSelect.Controls.Add(this.tbxFcName);
            this.grbSelect.Controls.Add(this.lblFCName);
            this.grbSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbSelect.Location = new System.Drawing.Point(0, 0);
            this.grbSelect.Name = "grbSelect";
            this.grbSelect.Size = new System.Drawing.Size(848, 135);
            this.grbSelect.TabIndex = 2;
            this.grbSelect.TabStop = false;
            this.grbSelect.Text = "查询条件";
            // 
            // ctrlpanel
            // 
            this.ctrlpanel.Location = new System.Drawing.Point(364, 109);
            this.ctrlpanel.Name = "ctrlpanel";
            this.ctrlpanel.Size = new System.Drawing.Size(55, 26);
            this.ctrlpanel.TabIndex = 16;
            // 
            // gbenquip
            // 
            this.gbenquip.Controls.Add(this.btgetall);
            this.gbenquip.Controls.Add(this.btseleall);
            this.gbenquip.Controls.Add(this.cListEquip);
            this.gbenquip.Location = new System.Drawing.Point(489, 9);
            this.gbenquip.Name = "gbenquip";
            this.gbenquip.Size = new System.Drawing.Size(353, 126);
            this.gbenquip.TabIndex = 48;
            this.gbenquip.TabStop = false;
            this.gbenquip.Text = "设备列表";
            // 
            // btgetall
            // 
            this.btgetall.Location = new System.Drawing.Point(267, 17);
            this.btgetall.Name = "btgetall";
            this.btgetall.Size = new System.Drawing.Size(75, 23);
            this.btgetall.TabIndex = 52;
            this.btgetall.Text = "获取设备";
            this.btgetall.UseVisualStyleBackColor = true;
            this.btgetall.Click += new System.EventHandler(this.btgetall_Click);
            // 
            // btseleall
            // 
            this.btseleall.Location = new System.Drawing.Point(267, 94);
            this.btseleall.Name = "btseleall";
            this.btseleall.Size = new System.Drawing.Size(75, 23);
            this.btseleall.TabIndex = 51;
            this.btseleall.Tag = "0";
            this.btseleall.Text = "全  选";
            this.btseleall.UseVisualStyleBackColor = true;
            this.btseleall.Click += new System.EventHandler(this.btseleall_Click);
            // 
            // cListEquip
            // 
            this.cListEquip.CheckOnClick = true;
            this.cListEquip.FormattingEnabled = true;
            this.cListEquip.Location = new System.Drawing.Point(11, 17);
            this.cListEquip.Name = "cListEquip";
            this.cListEquip.Size = new System.Drawing.Size(250, 100);
            this.cListEquip.TabIndex = 50;
            this.cListEquip.ThreeDCheckBoxes = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbxFalseTime);
            this.panel1.Controls.Add(this.cbxTrueTime);
            this.panel1.Controls.Add(this.cbxFalseFC);
            this.panel1.Controls.Add(this.cbxTrueFc);
            this.panel1.Location = new System.Drawing.Point(6, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 25);
            this.panel1.TabIndex = 47;
            // 
            // cbxFalseTime
            // 
            this.cbxFalseTime.AutoSize = true;
            this.cbxFalseTime.Location = new System.Drawing.Point(140, 6);
            this.cbxFalseTime.Name = "cbxFalseTime";
            this.cbxFalseTime.Size = new System.Drawing.Size(72, 16);
            this.cbxFalseTime.TabIndex = 9;
            this.cbxFalseTime.Text = "过期客户";
            this.cbxFalseTime.UseVisualStyleBackColor = true;
            this.cbxFalseTime.CheckedChanged += new System.EventHandler(this.cbxFalseTime_CheckedChanged);
            // 
            // cbxTrueTime
            // 
            this.cbxTrueTime.AutoSize = true;
            this.cbxTrueTime.Location = new System.Drawing.Point(229, 6);
            this.cbxTrueTime.Name = "cbxTrueTime";
            this.cbxTrueTime.Size = new System.Drawing.Size(60, 16);
            this.cbxTrueTime.TabIndex = 10;
            this.cbxTrueTime.Text = "未过期";
            this.cbxTrueTime.UseVisualStyleBackColor = true;
            this.cbxTrueTime.CheckedChanged += new System.EventHandler(this.cbxTrueTime_CheckedChanged);
            // 
            // cbxFalseFC
            // 
            this.cbxFalseFC.AutoSize = true;
            this.cbxFalseFC.Location = new System.Drawing.Point(12, 6);
            this.cbxFalseFC.Name = "cbxFalseFC";
            this.cbxFalseFC.Size = new System.Drawing.Size(60, 16);
            this.cbxFalseFC.TabIndex = 7;
            this.cbxFalseFC.Text = "未启用";
            this.cbxFalseFC.UseVisualStyleBackColor = true;
            this.cbxFalseFC.CheckedChanged += new System.EventHandler(this.cbxFalseFC_CheckedChanged);
            // 
            // cbxTrueFc
            // 
            this.cbxTrueFc.AutoSize = true;
            this.cbxTrueFc.Location = new System.Drawing.Point(86, 6);
            this.cbxTrueFc.Name = "cbxTrueFc";
            this.cbxTrueFc.Size = new System.Drawing.Size(48, 16);
            this.cbxTrueFc.TabIndex = 8;
            this.cbxTrueFc.Text = "启用";
            this.cbxTrueFc.UseVisualStyleBackColor = true;
            this.cbxTrueFc.CheckedChanged += new System.EventHandler(this.cbxTrueFc_CheckedChanged);
            // 
            // button2
            // 
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.Font = new System.Drawing.Font("宋体", 9F);
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(402, 75);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 22);
            this.button2.TabIndex = 46;
            this.button2.Text = "  重置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnProQuery
            // 
            this.btnProQuery.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnProQuery.Font = new System.Drawing.Font("宋体", 9F);
            this.btnProQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnProQuery.Image")));
            this.btnProQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProQuery.Location = new System.Drawing.Point(315, 76);
            this.btnProQuery.Name = "btnProQuery";
            this.btnProQuery.Size = new System.Drawing.Size(81, 22);
            this.btnProQuery.TabIndex = 11;
            this.btnProQuery.Text = "  查询";
            this.btnProQuery.UseVisualStyleBackColor = true;
            this.btnProQuery.Click += new System.EventHandler(this.btnProQuery_Click);
            // 
            // tbxCode
            // 
            this.tbxCode.Location = new System.Drawing.Point(397, 49);
            this.tbxCode.Name = "tbxCode";
            this.tbxCode.Size = new System.Drawing.Size(86, 21);
            this.tbxCode.TabIndex = 6;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(338, 53);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(59, 12);
            this.lblCode.TabIndex = 12;
            this.lblCode.Text = "客户代码:";
            // 
            // lblPlateId
            // 
            this.lblPlateId.AutoSize = true;
            this.lblPlateId.Location = new System.Drawing.Point(337, 28);
            this.lblPlateId.Name = "lblPlateId";
            this.lblPlateId.Size = new System.Drawing.Size(59, 12);
            this.lblPlateId.TabIndex = 11;
            this.lblPlateId.Text = "车牌号码:";
            // 
            // tbxPlateId
            // 
            this.tbxPlateId.Location = new System.Drawing.Point(397, 24);
            this.tbxPlateId.Name = "tbxPlateId";
            this.tbxPlateId.Size = new System.Drawing.Size(86, 21);
            this.tbxPlateId.TabIndex = 5;
            // 
            // tbxTelphone
            // 
            this.tbxTelphone.Location = new System.Drawing.Point(192, 47);
            this.tbxTelphone.Name = "tbxTelphone";
            this.tbxTelphone.Size = new System.Drawing.Size(140, 21);
            this.tbxTelphone.TabIndex = 4;
            // 
            // lblTelphone
            // 
            this.lblTelphone.AutoSize = true;
            this.lblTelphone.Location = new System.Drawing.Point(134, 52);
            this.lblTelphone.Name = "lblTelphone";
            this.lblTelphone.Size = new System.Drawing.Size(59, 12);
            this.lblTelphone.TabIndex = 8;
            this.lblTelphone.Text = "联系电话:";
            // 
            // tbxIdCard
            // 
            this.tbxIdCard.Location = new System.Drawing.Point(192, 21);
            this.tbxIdCard.Name = "tbxIdCard";
            this.tbxIdCard.Size = new System.Drawing.Size(140, 21);
            this.tbxIdCard.TabIndex = 3;
            // 
            // cbbSex
            // 
            this.cbbSex.FormattingEnabled = true;
            this.cbbSex.Items.AddRange(new object[] {
            "",
            "男",
            "女"});
            this.cbbSex.Location = new System.Drawing.Point(71, 48);
            this.cbbSex.Name = "cbbSex";
            this.cbbSex.Size = new System.Drawing.Size(57, 20);
            this.cbbSex.TabIndex = 2;
            // 
            // lblIdCard
            // 
            this.lblIdCard.AutoSize = true;
            this.lblIdCard.Location = new System.Drawing.Point(136, 27);
            this.lblIdCard.Name = "lblIdCard";
            this.lblIdCard.Size = new System.Drawing.Size(59, 12);
            this.lblIdCard.TabIndex = 5;
            this.lblIdCard.Text = "身份证号:";
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Location = new System.Drawing.Point(11, 52);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(59, 12);
            this.lblSex.TabIndex = 2;
            this.lblSex.Text = "性    别:";
            // 
            // tbxFcName
            // 
            this.tbxFcName.Location = new System.Drawing.Point(72, 23);
            this.tbxFcName.Name = "tbxFcName";
            this.tbxFcName.Size = new System.Drawing.Size(56, 21);
            this.tbxFcName.TabIndex = 1;
            // 
            // lblFCName
            // 
            this.lblFCName.AutoSize = true;
            this.lblFCName.Location = new System.Drawing.Point(13, 26);
            this.lblFCName.Name = "lblFCName";
            this.lblFCName.Size = new System.Drawing.Size(59, 12);
            this.lblFCName.TabIndex = 0;
            this.lblFCName.Text = "客户姓名:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspbtnUpdateTime,
            this.toolStripButton1,
            this.tspbtnSyn});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 106);
            this.toolStrip1.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 5, 1, 0);
            this.toolStrip1.Size = new System.Drawing.Size(383, 29);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tspbtnUpdateTime
            // 
            this.tspbtnUpdateTime.Image = ((System.Drawing.Image)(resources.GetObject("tspbtnUpdateTime.Image")));
            this.tspbtnUpdateTime.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspbtnUpdateTime.Margin = new System.Windows.Forms.Padding(50, 1, 0, 2);
            this.tspbtnUpdateTime.Name = "tspbtnUpdateTime";
            this.tspbtnUpdateTime.Size = new System.Drawing.Size(100, 21);
            this.tspbtnUpdateTime.Text = "修改有效期限";
            this.tspbtnUpdateTime.Click += new System.EventHandler(this.tspbtnUpdateTime_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(90, 21);
            this.toolStripButton1.Text = "导出Excel...";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tspbtnSyn
            // 
            this.tspbtnSyn.Image = ((System.Drawing.Image)(resources.GetObject("tspbtnSyn.Image")));
            this.tspbtnSyn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspbtnSyn.Name = "tspbtnSyn";
            this.tspbtnSyn.Size = new System.Drawing.Size(100, 21);
            this.tspbtnSyn.Text = "同步到一体机";
            this.tspbtnSyn.Click += new System.EventHandler(this.tspbtnSyn_Click);
            // 
            // ucPageBar1
            // 
            this.ucPageBar1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ucPageBar1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ucPageBar1.CurrentPage = ((uint)(1u));
            this.ucPageBar1.Location = new System.Drawing.Point(0, 581);
            this.ucPageBar1.Name = "ucPageBar1";
            this.ucPageBar1.PageSize = ((uint)(10u));
            this.ucPageBar1.RecordCount = ((uint)(0u));
            this.ucPageBar1.Size = new System.Drawing.Size(419, 29);
            this.ucPageBar1.TabIndex = 5;
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
            this.dgvFCustomerInfo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvFCustomerInfo.Location = new System.Drawing.Point(0, 141);
            this.dgvFCustomerInfo.Name = "dgvFCustomerInfo";
            this.dgvFCustomerInfo.ReadOnly = true;
            this.dgvFCustomerInfo.RowTemplate.Height = 23;
            this.dgvFCustomerInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFCustomerInfo.Size = new System.Drawing.Size(848, 441);
            this.dgvFCustomerInfo.TabIndex = 7;
            // 
            // frmLimitMag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(848, 610);
            this.Controls.Add(this.dgvFCustomerInfo);
            this.Controls.Add(this.ucPageBar1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.grbSelect);
            this.Name = "frmLimitMag";
            this.Text = "车辆期限管理";
            this.Load += new System.EventHandler(this.frmFCustomer_Load);
            this.grbSelect.ResumeLayout(false);
            this.grbSelect.PerformLayout();
            this.gbenquip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFCustomerInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbSelect;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tspbtnSyn;
        private www.gzwulian.com.Common.ucPageBar ucPageBar1;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.TextBox tbxFcName;
        private System.Windows.Forms.Label lblFCName;
        private System.Windows.Forms.Label lblIdCard;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnProQuery;
        private System.Windows.Forms.TextBox tbxCode;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblPlateId;
        private System.Windows.Forms.TextBox tbxPlateId;
        private System.Windows.Forms.TextBox tbxTelphone;
        private System.Windows.Forms.Label lblTelphone;
        private System.Windows.Forms.TextBox tbxIdCard;
        private System.Windows.Forms.ComboBox cbbSex;
        private System.Windows.Forms.SaveFileDialog sfdDataToExcel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbxFalseFC;
        private System.Windows.Forms.CheckBox cbxTrueFc;
        private System.Windows.Forms.CheckBox cbxFalseTime;
        private System.Windows.Forms.CheckBox cbxTrueTime;
        private System.Windows.Forms.ToolStripButton tspbtnUpdateTime;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvFCustomerInfo;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Panel ctrlpanel;
        private System.Windows.Forms.GroupBox gbenquip;
        private System.Windows.Forms.Button btgetall;
        private System.Windows.Forms.Button btseleall;
        private System.Windows.Forms.CheckedListBox cListEquip;
    }
}