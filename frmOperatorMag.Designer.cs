namespace ChargeWin
{
    partial class frmOperatorMag
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOperatorMag));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tsRightsManager = new System.Windows.Forms.ToolStrip();
            this.tsbtnRefreshOperator = new System.Windows.Forms.ToolStripButton();
            this.tsSpr1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnAddOperator = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDeleteOperator = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tsSpr2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsSpr3 = new System.Windows.Forms.ToolStripSeparator();
            this.dgvOperatorList = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnProQuery = new System.Windows.Forms.Button();
            this.tbxRealName = new System.Windows.Forms.TextBox();
            this.lblRealName = new System.Windows.Forms.Label();
            this.tbxOperatorName = new System.Windows.Forms.TextBox();
            this.lblOperatorName = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.tsRightsManager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperatorList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.tsRightsManager);
            this.panel2.Controls.Add(this.dgvOperatorList);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(859, 619);
            this.panel2.TabIndex = 1;
            // 
            // tsRightsManager
            // 
            this.tsRightsManager.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tsRightsManager.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tsRightsManager.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsRightsManager.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnRefreshOperator,
            this.tsSpr1,
            this.tsbtnAddOperator,
            this.tsbtnDeleteOperator,
            this.toolStripButton1,
            this.tsSpr2,
            this.tsSpr3});
            this.tsRightsManager.Location = new System.Drawing.Point(0, 563);
            this.tsRightsManager.Name = "tsRightsManager";
            this.tsRightsManager.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.tsRightsManager.Size = new System.Drawing.Size(859, 56);
            this.tsRightsManager.TabIndex = 8;
            this.tsRightsManager.Text = "权限管理工具栏";
            // 
            // tsbtnRefreshOperator
            // 
            this.tsbtnRefreshOperator.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnRefreshOperator.Image")));
            this.tsbtnRefreshOperator.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnRefreshOperator.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRefreshOperator.Margin = new System.Windows.Forms.Padding(100, 1, 0, 2);
            this.tsbtnRefreshOperator.Name = "tsbtnRefreshOperator";
            this.tsbtnRefreshOperator.Size = new System.Drawing.Size(60, 53);
            this.tsbtnRefreshOperator.Text = "刷新用户";
            this.tsbtnRefreshOperator.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnRefreshOperator.Click += new System.EventHandler(this.tsbtnRefreshOperator_Click);
            // 
            // tsSpr1
            // 
            this.tsSpr1.Name = "tsSpr1";
            this.tsSpr1.Size = new System.Drawing.Size(6, 56);
            // 
            // tsbtnAddOperator
            // 
            this.tsbtnAddOperator.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnAddOperator.Image")));
            this.tsbtnAddOperator.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnAddOperator.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAddOperator.Name = "tsbtnAddOperator";
            this.tsbtnAddOperator.Size = new System.Drawing.Size(60, 53);
            this.tsbtnAddOperator.Text = "添加用户";
            this.tsbtnAddOperator.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnAddOperator.Click += new System.EventHandler(this.tsbtnAddOperator_Click);
            // 
            // tsbtnDeleteOperator
            // 
            this.tsbtnDeleteOperator.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDeleteOperator.Image")));
            this.tsbtnDeleteOperator.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnDeleteOperator.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDeleteOperator.Name = "tsbtnDeleteOperator";
            this.tsbtnDeleteOperator.Size = new System.Drawing.Size(60, 53);
            this.tsbtnDeleteOperator.Text = "删除用户";
            this.tsbtnDeleteOperator.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnDeleteOperator.Click += new System.EventHandler(this.tsbtnDeleteOperator_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(60, 53);
            this.toolStripButton1.Text = "修改用户";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tsSpr2
            // 
            this.tsSpr2.Name = "tsSpr2";
            this.tsSpr2.Size = new System.Drawing.Size(6, 56);
            // 
            // tsSpr3
            // 
            this.tsSpr3.Name = "tsSpr3";
            this.tsSpr3.Size = new System.Drawing.Size(6, 56);
            // 
            // dgvOperatorList
            // 
            this.dgvOperatorList.AllowUserToAddRows = false;
            this.dgvOperatorList.BackgroundColor = System.Drawing.Color.White;
            this.dgvOperatorList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvOperatorList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOperatorList.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOperatorList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvOperatorList.Location = new System.Drawing.Point(3, 70);
            this.dgvOperatorList.Name = "dgvOperatorList";
            this.dgvOperatorList.ReadOnly = true;
            this.dgvOperatorList.RowTemplate.Height = 23;
            this.dgvOperatorList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOperatorList.Size = new System.Drawing.Size(853, 490);
            this.dgvOperatorList.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btnProQuery);
            this.groupBox1.Controls.Add(this.tbxRealName);
            this.groupBox1.Controls.Add(this.lblRealName);
            this.groupBox1.Controls.Add(this.tbxOperatorName);
            this.groupBox1.Controls.Add(this.lblOperatorName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(859, 64);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // button2
            // 
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.Font = new System.Drawing.Font("宋体", 9F);
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(582, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 22);
            this.button2.TabIndex = 48;
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
            this.btnProQuery.Location = new System.Drawing.Point(459, 27);
            this.btnProQuery.Name = "btnProQuery";
            this.btnProQuery.Size = new System.Drawing.Size(81, 22);
            this.btnProQuery.TabIndex = 47;
            this.btnProQuery.Text = "  查询";
            this.btnProQuery.UseVisualStyleBackColor = true;
            this.btnProQuery.Click += new System.EventHandler(this.btnProQuery_Click);
            // 
            // tbxRealName
            // 
            this.tbxRealName.Location = new System.Drawing.Point(290, 27);
            this.tbxRealName.Name = "tbxRealName";
            this.tbxRealName.Size = new System.Drawing.Size(100, 21);
            this.tbxRealName.TabIndex = 5;
            // 
            // lblRealName
            // 
            this.lblRealName.AutoSize = true;
            this.lblRealName.Location = new System.Drawing.Point(230, 31);
            this.lblRealName.Name = "lblRealName";
            this.lblRealName.Size = new System.Drawing.Size(59, 12);
            this.lblRealName.TabIndex = 4;
            this.lblRealName.Text = "真实姓名:";
            // 
            // tbxOperatorName
            // 
            this.tbxOperatorName.Location = new System.Drawing.Point(95, 27);
            this.tbxOperatorName.Name = "tbxOperatorName";
            this.tbxOperatorName.Size = new System.Drawing.Size(129, 21);
            this.tbxOperatorName.TabIndex = 3;
            // 
            // lblOperatorName
            // 
            this.lblOperatorName.AutoSize = true;
            this.lblOperatorName.Location = new System.Drawing.Point(21, 31);
            this.lblOperatorName.Name = "lblOperatorName";
            this.lblOperatorName.Size = new System.Drawing.Size(71, 12);
            this.lblOperatorName.TabIndex = 2;
            this.lblOperatorName.Text = "操作员名称:";
            // 
            // frmOperatorMag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 619);
            this.Controls.Add(this.panel2);
            this.Name = "frmOperatorMag";
            this.Text = "用户管理";
            this.Load += new System.EventHandler(this.FrmOperatorMag_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tsRightsManager.ResumeLayout(false);
            this.tsRightsManager.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperatorList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxOperatorName;
        private System.Windows.Forms.Label lblOperatorName;
        private System.Windows.Forms.TextBox tbxRealName;
        private System.Windows.Forms.Label lblRealName;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnProQuery;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvOperatorList;
        private System.Windows.Forms.ToolStrip tsRightsManager;
        private System.Windows.Forms.ToolStripButton tsbtnRefreshOperator;
        private System.Windows.Forms.ToolStripSeparator tsSpr1;
        private System.Windows.Forms.ToolStripButton tsbtnAddOperator;
        private System.Windows.Forms.ToolStripButton tsbtnDeleteOperator;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator tsSpr2;
        private System.Windows.Forms.ToolStripSeparator tsSpr3;

    }
}