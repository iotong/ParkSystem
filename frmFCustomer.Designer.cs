namespace ChargeWin
{
    partial class frmFCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFCustomer));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.sfdDataToExcel = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ctrlpanel = new System.Windows.Forms.Panel();
            this.ucPageBar1 = new www.gzwulian.com.Common.ucPageBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tspbtnUpdate = new System.Windows.Forms.ToolStripButton();
            this.tspbtnDelete = new System.Windows.Forms.ToolStripButton();
            this.tspbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolBtn = new System.Windows.Forms.ToolStripButton();
            this.dgvFCustomerInfo = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grbSelect = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbxFalseTime = new System.Windows.Forms.CheckBox();
            this.cbxTrueTime = new System.Windows.Forms.CheckBox();
            this.cbxFalseFC = new System.Windows.Forms.CheckBox();
            this.cbxTrueFc = new System.Windows.Forms.CheckBox();
            this.btnReset = new System.Windows.Forms.Button();
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
            this.gbenquip = new System.Windows.Forms.GroupBox();
            this.btgetall = new System.Windows.Forms.Button();
            this.btseleall = new System.Windows.Forms.Button();
            this.cListEquip = new System.Windows.Forms.CheckedListBox();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFCustomerInfo)).BeginInit();
            this.panel3.SuspendLayout();
            this.grbSelect.SuspendLayout();
            this.panel4.SuspendLayout();
            this.gbenquip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.ctrlpanel);
            this.panel1.Controls.Add(this.ucPageBar1);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.dgvFCustomerInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(864, 613);
            this.panel1.TabIndex = 4;
            // 
            // ctrlpanel
            // 
            this.ctrlpanel.Location = new System.Drawing.Point(608, 106);
            this.ctrlpanel.Name = "ctrlpanel";
            this.ctrlpanel.Size = new System.Drawing.Size(35, 24);
            this.ctrlpanel.TabIndex = 15;
            // 
            // ucPageBar1
            // 
            this.ucPageBar1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ucPageBar1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ucPageBar1.CurrentPage = ((uint)(1u));
            this.ucPageBar1.Location = new System.Drawing.Point(3, 581);
            this.ucPageBar1.Name = "ucPageBar1";
            this.ucPageBar1.PageSize = ((uint)(10u));
            this.ucPageBar1.RecordCount = ((uint)(0u));
            this.ucPageBar1.Size = new System.Drawing.Size(418, 27);
            this.ucPageBar1.TabIndex = 11;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.tspbtnUpdate,
            this.tspbtnDelete,
            this.tspbtnRefresh,
            this.toolStripButton2,
            this.toolBtn});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(3, 96);
            this.toolStrip1.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 5, 1, 0);
            this.toolStrip1.Size = new System.Drawing.Size(568, 34);
            this.toolStrip1.TabIndex = 14;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Margin = new System.Windows.Forms.Padding(50, 1, 0, 2);
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.toolStripButton1.Size = new System.Drawing.Size(88, 26);
            this.toolStripButton1.Text = "增加新客户";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tspbtnUpdate
            // 
            this.tspbtnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("tspbtnUpdate.Image")));
            this.tspbtnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspbtnUpdate.Name = "tspbtnUpdate";
            this.tspbtnUpdate.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.tspbtnUpdate.Size = new System.Drawing.Size(100, 26);
            this.tspbtnUpdate.Text = "修改车主信息";
            this.tspbtnUpdate.Click += new System.EventHandler(this.tspbtnUpdate_Click);
            // 
            // tspbtnDelete
            // 
            this.tspbtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("tspbtnDelete.Image")));
            this.tspbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspbtnDelete.Name = "tspbtnDelete";
            this.tspbtnDelete.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.tspbtnDelete.Size = new System.Drawing.Size(100, 26);
            this.tspbtnDelete.Text = "删除车主信息";
            this.tspbtnDelete.Click += new System.EventHandler(this.tspbtnDelete_Click);
            // 
            // tspbtnRefresh
            // 
            this.tspbtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tspbtnRefresh.Image")));
            this.tspbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspbtnRefresh.Name = "tspbtnRefresh";
            this.tspbtnRefresh.Size = new System.Drawing.Size(52, 26);
            this.tspbtnRefresh.Text = "刷新";
            this.tspbtnRefresh.Click += new System.EventHandler(this.tspbtnRefresh_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(90, 26);
            this.toolStripButton2.Text = "导出Excel...";
            this.toolStripButton2.Click += new System.EventHandler(this.btnToExcel_Click);
            // 
            // toolBtn
            // 
            this.toolBtn.Image = global::ChargeWin.Properties.Resources.import;
            this.toolBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtn.Name = "toolBtn";
            this.toolBtn.Size = new System.Drawing.Size(76, 26);
            this.toolBtn.Text = "导入数据";
            this.toolBtn.Click += new System.EventHandler(this.toolBtn_Click);
            // 
            // dgvFCustomerInfo
            // 
            this.dgvFCustomerInfo.AllowUserToAddRows = false;
            this.dgvFCustomerInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgvFCustomerInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvFCustomerInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFCustomerInfo.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvFCustomerInfo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvFCustomerInfo.Location = new System.Drawing.Point(3, 136);
            this.dgvFCustomerInfo.Name = "dgvFCustomerInfo";
            this.dgvFCustomerInfo.ReadOnly = true;
            this.dgvFCustomerInfo.RowTemplate.Height = 23;
            this.dgvFCustomerInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFCustomerInfo.Size = new System.Drawing.Size(857, 447);
            this.dgvFCustomerInfo.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.grbSelect);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(864, 101);
            this.panel3.TabIndex = 6;
            // 
            // grbSelect
            // 
            this.grbSelect.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grbSelect.Controls.Add(this.gbenquip);
            this.grbSelect.Controls.Add(this.panel4);
            this.grbSelect.Controls.Add(this.btnReset);
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
            this.grbSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbSelect.Location = new System.Drawing.Point(0, 0);
            this.grbSelect.Name = "grbSelect";
            this.grbSelect.Size = new System.Drawing.Size(860, 97);
            this.grbSelect.TabIndex = 9;
            this.grbSelect.TabStop = false;
            this.grbSelect.Text = "查询条件";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cbxFalseTime);
            this.panel4.Controls.Add(this.cbxTrueTime);
            this.panel4.Controls.Add(this.cbxFalseFC);
            this.panel4.Controls.Add(this.cbxTrueFc);
            this.panel4.Location = new System.Drawing.Point(19, 72);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(324, 25);
            this.panel4.TabIndex = 47;
            // 
            // cbxFalseTime
            // 
            this.cbxFalseTime.AutoSize = true;
            this.cbxFalseTime.Location = new System.Drawing.Point(163, 7);
            this.cbxFalseTime.Name = "cbxFalseTime";
            this.cbxFalseTime.Size = new System.Drawing.Size(72, 16);
            this.cbxFalseTime.TabIndex = 9;
            this.cbxFalseTime.Text = "过期客户";
            this.cbxFalseTime.UseVisualStyleBackColor = true;
            this.cbxFalseTime.Click += new System.EventHandler(this.cbxFalseTime_CheckedChanged);
            // 
            // cbxTrueTime
            // 
            this.cbxTrueTime.AutoSize = true;
            this.cbxTrueTime.Location = new System.Drawing.Point(260, 6);
            this.cbxTrueTime.Name = "cbxTrueTime";
            this.cbxTrueTime.Size = new System.Drawing.Size(60, 16);
            this.cbxTrueTime.TabIndex = 10;
            this.cbxTrueTime.Text = "未过期";
            this.cbxTrueTime.UseVisualStyleBackColor = true;
            this.cbxTrueTime.Click += new System.EventHandler(this.cbxTrueTime_CheckedChanged);
            // 
            // cbxFalseFC
            // 
            this.cbxFalseFC.AutoSize = true;
            this.cbxFalseFC.Location = new System.Drawing.Point(13, 6);
            this.cbxFalseFC.Name = "cbxFalseFC";
            this.cbxFalseFC.Size = new System.Drawing.Size(60, 16);
            this.cbxFalseFC.TabIndex = 7;
            this.cbxFalseFC.Text = "未启用";
            this.cbxFalseFC.UseVisualStyleBackColor = true;
            this.cbxFalseFC.Click += new System.EventHandler(this.cbxFalseFC_CheckedChanged);
            // 
            // cbxTrueFc
            // 
            this.cbxTrueFc.AutoSize = true;
            this.cbxTrueFc.Location = new System.Drawing.Point(90, 6);
            this.cbxTrueFc.Name = "cbxTrueFc";
            this.cbxTrueFc.Size = new System.Drawing.Size(48, 16);
            this.cbxTrueFc.TabIndex = 8;
            this.cbxTrueFc.Text = "启用";
            this.cbxTrueFc.UseVisualStyleBackColor = true;
            this.cbxTrueFc.Click += new System.EventHandler(this.cbxTrueFc_CheckedChanged);
            // 
            // btnReset
            // 
            this.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnReset.Font = new System.Drawing.Font("宋体", 9F);
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset.Location = new System.Drawing.Point(437, 73);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 22);
            this.btnReset.TabIndex = 46;
            this.btnReset.Text = "  重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.tspbtnRefresh_Click);
            // 
            // btnProQuery
            // 
            this.btnProQuery.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnProQuery.Font = new System.Drawing.Font("宋体", 9F);
            this.btnProQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnProQuery.Image")));
            this.btnProQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProQuery.Location = new System.Drawing.Point(351, 73);
            this.btnProQuery.Name = "btnProQuery";
            this.btnProQuery.Size = new System.Drawing.Size(75, 22);
            this.btnProQuery.TabIndex = 11;
            this.btnProQuery.Text = "  查询";
            this.btnProQuery.UseVisualStyleBackColor = true;
            this.btnProQuery.Click += new System.EventHandler(this.btnProQuery_Click);
            // 
            // tbxCode
            // 
            this.tbxCode.Location = new System.Drawing.Point(410, 47);
            this.tbxCode.Name = "tbxCode";
            this.tbxCode.Size = new System.Drawing.Size(102, 21);
            this.tbxCode.TabIndex = 6;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(348, 51);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(59, 12);
            this.lblCode.TabIndex = 12;
            this.lblCode.Text = "客户代码:";
            // 
            // lblPlateId
            // 
            this.lblPlateId.AutoSize = true;
            this.lblPlateId.Location = new System.Drawing.Point(349, 26);
            this.lblPlateId.Name = "lblPlateId";
            this.lblPlateId.Size = new System.Drawing.Size(59, 12);
            this.lblPlateId.TabIndex = 11;
            this.lblPlateId.Text = "车牌号码:";
            // 
            // tbxPlateId
            // 
            this.tbxPlateId.Location = new System.Drawing.Point(410, 22);
            this.tbxPlateId.Name = "tbxPlateId";
            this.tbxPlateId.Size = new System.Drawing.Size(102, 21);
            this.tbxPlateId.TabIndex = 5;
            // 
            // tbxTelphone
            // 
            this.tbxTelphone.Location = new System.Drawing.Point(229, 47);
            this.tbxTelphone.Name = "tbxTelphone";
            this.tbxTelphone.Size = new System.Drawing.Size(114, 21);
            this.tbxTelphone.TabIndex = 4;
            // 
            // lblTelphone
            // 
            this.lblTelphone.AutoSize = true;
            this.lblTelphone.Location = new System.Drawing.Point(156, 51);
            this.lblTelphone.Name = "lblTelphone";
            this.lblTelphone.Size = new System.Drawing.Size(59, 12);
            this.lblTelphone.TabIndex = 8;
            this.lblTelphone.Text = "联系电话:";
            // 
            // tbxIdCard
            // 
            this.tbxIdCard.Location = new System.Drawing.Point(229, 21);
            this.tbxIdCard.Name = "tbxIdCard";
            this.tbxIdCard.Size = new System.Drawing.Size(114, 21);
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
            this.cbbSex.Size = new System.Drawing.Size(75, 20);
            this.cbbSex.TabIndex = 2;
            // 
            // lblIdCard
            // 
            this.lblIdCard.AutoSize = true;
            this.lblIdCard.Location = new System.Drawing.Point(153, 25);
            this.lblIdCard.Name = "lblIdCard";
            this.lblIdCard.Size = new System.Drawing.Size(71, 12);
            this.lblIdCard.TabIndex = 5;
            this.lblIdCard.Text = "身份证号码:";
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Location = new System.Drawing.Point(17, 53);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(53, 12);
            this.lblSex.TabIndex = 2;
            this.lblSex.Text = "性   别:";
            // 
            // tbxFcName
            // 
            this.tbxFcName.Location = new System.Drawing.Point(72, 23);
            this.tbxFcName.Name = "tbxFcName";
            this.tbxFcName.Size = new System.Drawing.Size(75, 21);
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
            // gbenquip
            // 
            this.gbenquip.Controls.Add(this.btgetall);
            this.gbenquip.Controls.Add(this.btseleall);
            this.gbenquip.Controls.Add(this.cListEquip);
            this.gbenquip.Location = new System.Drawing.Point(518, 10);
            this.gbenquip.Name = "gbenquip";
            this.gbenquip.Size = new System.Drawing.Size(344, 94);
            this.gbenquip.TabIndex = 49;
            this.gbenquip.TabStop = false;
            this.gbenquip.Text = "设备列表";
            // 
            // btgetall
            // 
            this.btgetall.Location = new System.Drawing.Point(238, 20);
            this.btgetall.Name = "btgetall";
            this.btgetall.Size = new System.Drawing.Size(75, 23);
            this.btgetall.TabIndex = 52;
            this.btgetall.Text = "获取设备";
            this.btgetall.UseVisualStyleBackColor = true;
            this.btgetall.Click += new System.EventHandler(this.btgetall_Click);
            // 
            // btseleall
            // 
            this.btseleall.Location = new System.Drawing.Point(238, 61);
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
            this.cListEquip.Size = new System.Drawing.Size(221, 68);
            this.cListEquip.TabIndex = 50;
            this.cListEquip.ThreeDCheckBoxes = true;
            // 
            // frmFCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 613);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFCustomer";
            this.Text = "车主管理";
            this.Load += new System.EventHandler(this.frmFCustomer_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFCustomerInfo)).EndInit();
            this.panel3.ResumeLayout(false);
            this.grbSelect.ResumeLayout(false);
            this.grbSelect.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.gbenquip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog sfdDataToExcel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton tspbtnUpdate;
        private System.Windows.Forms.ToolStripButton tspbtnDelete;
        private System.Windows.Forms.ToolStripButton tspbtnRefresh;
        private www.gzwulian.com.Common.ucPageBar ucPageBar1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox grbSelect;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox cbxFalseTime;
        private System.Windows.Forms.CheckBox cbxTrueTime;
        private System.Windows.Forms.CheckBox cbxFalseFC;
        private System.Windows.Forms.CheckBox cbxTrueFc;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnProQuery;
        private System.Windows.Forms.TextBox tbxCode;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblPlateId;
        private System.Windows.Forms.TextBox tbxPlateId;
        private System.Windows.Forms.TextBox tbxTelphone;
        private System.Windows.Forms.Label lblTelphone;
        private System.Windows.Forms.TextBox tbxIdCard;
        private System.Windows.Forms.ComboBox cbbSex;
        private System.Windows.Forms.Label lblIdCard;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.TextBox tbxFcName;
        private System.Windows.Forms.Label lblFCName;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvFCustomerInfo;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Panel ctrlpanel;
        private System.Windows.Forms.ToolStripButton toolBtn;
        private System.Windows.Forms.GroupBox gbenquip;
        private System.Windows.Forms.Button btgetall;
        private System.Windows.Forms.Button btseleall;
        private System.Windows.Forms.CheckedListBox cListEquip;
    }
}