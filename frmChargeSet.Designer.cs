namespace ChargeWin
{
    partial class frmChargeSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChargeSet));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnApp = new System.Windows.Forms.Button();
            this.btnSetCharge = new System.Windows.Forms.Button();
            this.cbCarType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gbPerView = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPerViewFee = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gbDayNight = new System.Windows.Forms.GroupBox();
            this.dgvDayNight = new System.Windows.Forms.DataGridView();
            this.Iterm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Night = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbFeeSet = new System.Windows.Forms.GroupBox();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.txtSTOverNightFee = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.txtSTUnieFee = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.txtSTTimeUnie = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbStandard = new System.Windows.Forms.GroupBox();
            this.dgvFee = new System.Windows.Forms.DataGridView();
            this.ParkTime = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.ParkFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbType = new System.Windows.Forms.GroupBox();
            this.rdPerView = new System.Windows.Forms.RadioButton();
            this.rdDayNight = new System.Windows.Forms.RadioButton();
            this.rdStandard = new System.Windows.Forms.RadioButton();
            this.rdSetTime = new System.Windows.Forms.RadioButton();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txtFreeMinutes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtFeetop = new System.Windows.Forms.TextBox();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panel2.SuspendLayout();
            this.gbPerView.SuspendLayout();
            this.gbDayNight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDayNight)).BeginInit();
            this.panel1.SuspendLayout();
            this.gbFeeSet.SuspendLayout();
            this.gbStandard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFee)).BeginInit();
            this.gbType.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnApp);
            this.panel2.Controls.Add(this.btnSetCharge);
            this.panel2.Controls.Add(this.cbCarType);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.gbPerView);
            this.panel2.Controls.Add(this.gbDayNight);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.gbType);
            this.panel2.Controls.Add(this.labelX4);
            this.panel2.Controls.Add(this.txtFreeMinutes);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.labelX3);
            this.panel2.Controls.Add(this.labelX2);
            this.panel2.Controls.Add(this.txtFeetop);
            this.panel2.Controls.Add(this.labelX1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(938, 558);
            this.panel2.TabIndex = 52;
            // 
            // btnApp
            // 
            this.btnApp.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnApp.Image = ((System.Drawing.Image)(resources.GetObject("btnApp.Image")));
            this.btnApp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApp.Location = new System.Drawing.Point(220, 476);
            this.btnApp.Name = "btnApp";
            this.btnApp.Size = new System.Drawing.Size(197, 42);
            this.btnApp.TabIndex = 66;
            this.btnApp.Text = "保存";
            this.btnApp.UseVisualStyleBackColor = true;
            this.btnApp.Click += new System.EventHandler(this.btnApp_Click);
            // 
            // btnSetCharge
            // 
            this.btnSetCharge.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetCharge.Image = ((System.Drawing.Image)(resources.GetObject("btnSetCharge.Image")));
            this.btnSetCharge.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetCharge.Location = new System.Drawing.Point(480, 476);
            this.btnSetCharge.Name = "btnSetCharge";
            this.btnSetCharge.Size = new System.Drawing.Size(211, 42);
            this.btnSetCharge.TabIndex = 67;
            this.btnSetCharge.Text = "设为收费标准";
            this.btnSetCharge.UseVisualStyleBackColor = true;
            this.btnSetCharge.Click += new System.EventHandler(this.btnSetCharge_Click);
            // 
            // cbCarType
            // 
            this.cbCarType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCarType.FormattingEnabled = true;
            this.cbCarType.Location = new System.Drawing.Point(231, 138);
            this.cbCarType.Name = "cbCarType";
            this.cbCarType.Size = new System.Drawing.Size(121, 20);
            this.cbCarType.TabIndex = 65;
            this.cbCarType.SelectedIndexChanged += new System.EventHandler(this.cbCarType_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(165, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 64;
            this.label7.Text = "车辆类型";
            // 
            // gbPerView
            // 
            this.gbPerView.Controls.Add(this.label6);
            this.gbPerView.Controls.Add(this.txtPerViewFee);
            this.gbPerView.Controls.Add(this.label5);
            this.gbPerView.Location = new System.Drawing.Point(165, 386);
            this.gbPerView.Name = "gbPerView";
            this.gbPerView.Size = new System.Drawing.Size(298, 57);
            this.gbPerView.TabIndex = 63;
            this.gbPerView.TabStop = false;
            this.gbPerView.Text = "按次收费";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(237, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "（元）";
            // 
            // txtPerViewFee
            // 
            this.txtPerViewFee.Location = new System.Drawing.Point(131, 22);
            this.txtPerViewFee.Name = "txtPerViewFee";
            this.txtPerViewFee.Size = new System.Drawing.Size(100, 21);
            this.txtPerViewFee.TabIndex = 1;
            this.txtPerViewFee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPerViewFee_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "每次收费金额（元）:";
            // 
            // gbDayNight
            // 
            this.gbDayNight.Controls.Add(this.dgvDayNight);
            this.gbDayNight.Location = new System.Drawing.Point(445, 51);
            this.gbDayNight.Name = "gbDayNight";
            this.gbDayNight.Size = new System.Drawing.Size(373, 232);
            this.gbDayNight.TabIndex = 62;
            this.gbDayNight.TabStop = false;
            this.gbDayNight.Text = "按设定时间段收费";
            // 
            // dgvDayNight
            // 
            this.dgvDayNight.AllowUserToAddRows = false;
            this.dgvDayNight.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvDayNight.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDayNight.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Iterm,
            this.Day,
            this.Night});
            this.dgvDayNight.Location = new System.Drawing.Point(6, 25);
            this.dgvDayNight.Name = "dgvDayNight";
            this.dgvDayNight.RowTemplate.Height = 23;
            this.dgvDayNight.Size = new System.Drawing.Size(343, 178);
            this.dgvDayNight.TabIndex = 0;
            this.dgvDayNight.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvFee_EditingControlShowing);
            // 
            // Iterm
            // 
            this.Iterm.HeaderText = "";
            this.Iterm.Name = "Iterm";
            this.Iterm.ReadOnly = true;
            this.Iterm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Day
            // 
            this.Day.HeaderText = "时间段一";
            this.Day.Name = "Day";
            this.Day.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Night
            // 
            this.Night.HeaderText = "时间段二";
            this.Night.Name = "Night";
            this.Night.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbFeeSet);
            this.panel1.Controls.Add(this.gbStandard);
            this.panel1.Location = new System.Drawing.Point(445, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(345, 319);
            this.panel1.TabIndex = 61;
            // 
            // gbFeeSet
            // 
            this.gbFeeSet.Controls.Add(this.labelX7);
            this.gbFeeSet.Controls.Add(this.txtSTOverNightFee);
            this.gbFeeSet.Controls.Add(this.label4);
            this.gbFeeSet.Controls.Add(this.labelX6);
            this.gbFeeSet.Controls.Add(this.txtSTUnieFee);
            this.gbFeeSet.Controls.Add(this.label3);
            this.gbFeeSet.Controls.Add(this.labelX5);
            this.gbFeeSet.Controls.Add(this.txtSTTimeUnie);
            this.gbFeeSet.Controls.Add(this.label2);
            this.gbFeeSet.Location = new System.Drawing.Point(3, 3);
            this.gbFeeSet.Name = "gbFeeSet";
            this.gbFeeSet.Size = new System.Drawing.Size(287, 156);
            this.gbFeeSet.TabIndex = 9;
            this.gbFeeSet.TabStop = false;
            this.gbFeeSet.Text = "按设定时间收费";
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(221, 104);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(44, 26);
            this.labelX7.TabIndex = 15;
            this.labelX7.Text = "(元)";
            // 
            // txtSTOverNightFee
            // 
            this.txtSTOverNightFee.Location = new System.Drawing.Point(118, 104);
            this.txtSTOverNightFee.Name = "txtSTOverNightFee";
            this.txtSTOverNightFee.Size = new System.Drawing.Size(100, 21);
            this.txtSTOverNightFee.TabIndex = 14;
            this.txtSTOverNightFee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPerViewFee_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "0点后加收过夜费:";
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(221, 63);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(44, 26);
            this.labelX6.TabIndex = 12;
            this.labelX6.Text = "(元)";
            // 
            // txtSTUnieFee
            // 
            this.txtSTUnieFee.Location = new System.Drawing.Point(118, 63);
            this.txtSTUnieFee.Name = "txtSTUnieFee";
            this.txtSTUnieFee.Size = new System.Drawing.Size(100, 21);
            this.txtSTUnieFee.TabIndex = 11;
            this.txtSTUnieFee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPerViewFee_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "每计时单位收费:";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(221, 28);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(44, 26);
            this.labelX5.TabIndex = 9;
            this.labelX5.Text = "(分钟)";
            // 
            // txtSTTimeUnie
            // 
            this.txtSTTimeUnie.Location = new System.Drawing.Point(118, 28);
            this.txtSTTimeUnie.Name = "txtSTTimeUnie";
            this.txtSTTimeUnie.Size = new System.Drawing.Size(100, 21);
            this.txtSTTimeUnie.TabIndex = 8;
            this.txtSTTimeUnie.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIntInput_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "计时单位:";
            // 
            // gbStandard
            // 
            this.gbStandard.Controls.Add(this.dgvFee);
            this.gbStandard.Location = new System.Drawing.Point(121, 165);
            this.gbStandard.Name = "gbStandard";
            this.gbStandard.Size = new System.Drawing.Size(287, 406);
            this.gbStandard.TabIndex = 60;
            this.gbStandard.TabStop = false;
            this.gbStandard.Text = "标准收费";
            // 
            // dgvFee
            // 
            this.dgvFee.AllowUserToAddRows = false;
            this.dgvFee.AllowUserToDeleteRows = false;
            this.dgvFee.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvFee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ParkTime,
            this.ParkFee});
            this.dgvFee.Location = new System.Drawing.Point(5, 29);
            this.dgvFee.Name = "dgvFee";
            this.dgvFee.RowTemplate.Height = 23;
            this.dgvFee.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvFee.Size = new System.Drawing.Size(262, 283);
            this.dgvFee.TabIndex = 0;
            this.dgvFee.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvFee_EditingControlShowing);
            // 
            // ParkTime
            // 
            this.ParkTime.HeaderText = "时间（小时）";
            this.ParkTime.Name = "ParkTime";
            this.ParkTime.ReadOnly = true;
            this.ParkTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ParkFee
            // 
            this.ParkFee.HeaderText = "收费（元）";
            this.ParkFee.Name = "ParkFee";
            this.ParkFee.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // gbType
            // 
            this.gbType.Controls.Add(this.rdPerView);
            this.gbType.Controls.Add(this.rdDayNight);
            this.gbType.Controls.Add(this.rdStandard);
            this.gbType.Controls.Add(this.rdSetTime);
            this.gbType.Location = new System.Drawing.Point(165, 185);
            this.gbType.Name = "gbType";
            this.gbType.Size = new System.Drawing.Size(200, 185);
            this.gbType.TabIndex = 59;
            this.gbType.TabStop = false;
            this.gbType.Text = "收费类型";
            // 
            // rdPerView
            // 
            this.rdPerView.AutoSize = true;
            this.rdPerView.Location = new System.Drawing.Point(6, 143);
            this.rdPerView.Name = "rdPerView";
            this.rdPerView.Size = new System.Drawing.Size(71, 16);
            this.rdPerView.TabIndex = 11;
            this.rdPerView.TabStop = true;
            this.rdPerView.Text = "按次收费";
            this.rdPerView.UseVisualStyleBackColor = true;
            this.rdPerView.CheckedChanged += new System.EventHandler(this.rdSetTime_CheckedChanged);
            // 
            // rdDayNight
            // 
            this.rdDayNight.AutoSize = true;
            this.rdDayNight.Location = new System.Drawing.Point(6, 103);
            this.rdDayNight.Name = "rdDayNight";
            this.rdDayNight.Size = new System.Drawing.Size(119, 16);
            this.rdDayNight.TabIndex = 10;
            this.rdDayNight.TabStop = true;
            this.rdDayNight.Text = "按设定时间段收费";
            this.rdDayNight.UseVisualStyleBackColor = true;
            this.rdDayNight.CheckedChanged += new System.EventHandler(this.rdSetTime_CheckedChanged);
            // 
            // rdStandard
            // 
            this.rdStandard.AutoSize = true;
            this.rdStandard.Location = new System.Drawing.Point(6, 61);
            this.rdStandard.Name = "rdStandard";
            this.rdStandard.Size = new System.Drawing.Size(71, 16);
            this.rdStandard.TabIndex = 8;
            this.rdStandard.TabStop = true;
            this.rdStandard.Text = "标准收费";
            this.rdStandard.UseVisualStyleBackColor = true;
            // 
            // rdSetTime
            // 
            this.rdSetTime.AutoSize = true;
            this.rdSetTime.Location = new System.Drawing.Point(6, 20);
            this.rdSetTime.Name = "rdSetTime";
            this.rdSetTime.Size = new System.Drawing.Size(107, 16);
            this.rdSetTime.TabIndex = 7;
            this.rdSetTime.TabStop = true;
            this.rdSetTime.Text = "按设定时间收费";
            this.rdSetTime.UseVisualStyleBackColor = true;
            this.rdSetTime.CheckedChanged += new System.EventHandler(this.rdSetTime_CheckedChanged);
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(337, 103);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(44, 26);
            this.labelX4.TabIndex = 58;
            this.labelX4.Text = "(分钟)";
            // 
            // txtFreeMinutes
            // 
            this.txtFreeMinutes.Location = new System.Drawing.Point(231, 103);
            this.txtFreeMinutes.Name = "txtFreeMinutes";
            this.txtFreeMinutes.Size = new System.Drawing.Size(100, 21);
            this.txtFreeMinutes.TabIndex = 57;
            this.txtFreeMinutes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIntInput_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(165, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 56;
            this.label1.Text = "免费时间";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(337, 54);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(38, 26);
            this.labelX3.TabIndex = 55;
            this.labelX3.Text = "(元)";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(165, 63);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(60, 26);
            this.labelX2.TabIndex = 54;
            this.labelX2.Text = "收费限额";
            // 
            // txtFeetop
            // 
            this.txtFeetop.Location = new System.Drawing.Point(231, 54);
            this.txtFeetop.Name = "txtFeetop";
            this.txtFeetop.Size = new System.Drawing.Size(100, 21);
            this.txtFeetop.TabIndex = 53;
            this.txtFeetop.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPerViewFee_KeyPress);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(165, 40);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(76, 26);
            this.labelX1.TabIndex = 52;
            this.labelX1.Text = "每日最高";
            // 
            // frmChargeSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(938, 558);
            this.Controls.Add(this.panel2);
            this.Name = "frmChargeSet";
            this.Text = "收费标准设置";
            this.Load += new System.EventHandler(this.frmChargeSet_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.gbPerView.ResumeLayout(false);
            this.gbPerView.PerformLayout();
            this.gbDayNight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDayNight)).EndInit();
            this.panel1.ResumeLayout(false);
            this.gbFeeSet.ResumeLayout(false);
            this.gbFeeSet.PerformLayout();
            this.gbStandard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFee)).EndInit();
            this.gbType.ResumeLayout(false);
            this.gbType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnApp;
        private System.Windows.Forms.Button btnSetCharge;
        private System.Windows.Forms.ComboBox cbCarType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gbPerView;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPerViewFee;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbStandard;
        private System.Windows.Forms.DataGridView dgvFee;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ParkTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParkFee;
        private System.Windows.Forms.GroupBox gbDayNight;
        private System.Windows.Forms.DataGridView dgvDayNight;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbFeeSet;
        private DevComponents.DotNetBar.LabelX labelX7;
        private System.Windows.Forms.TextBox txtSTOverNightFee;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.LabelX labelX6;
        private System.Windows.Forms.TextBox txtSTUnieFee;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.LabelX labelX5;
        private System.Windows.Forms.TextBox txtSTTimeUnie;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbType;
        private System.Windows.Forms.RadioButton rdPerView;
        private System.Windows.Forms.RadioButton rdDayNight;
        private System.Windows.Forms.RadioButton rdStandard;
        private System.Windows.Forms.RadioButton rdSetTime;
        private DevComponents.DotNetBar.LabelX labelX4;
        private System.Windows.Forms.TextBox txtFreeMinutes;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.TextBox txtFeetop;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iterm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Day;
        private System.Windows.Forms.DataGridViewTextBoxColumn Night;
    }
}