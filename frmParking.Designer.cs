namespace ChargeWin
{
    partial class frmParking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParking));
            this.comPanel = new System.Windows.Forms.Panel();
            this.comGB = new System.Windows.Forms.GroupBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtCompanyCode = new System.Windows.Forms.TextBox();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.parkPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.parkGB = new System.Windows.Forms.GroupBox();
            this.txtLeftBerth = new System.Windows.Forms.TextBox();
            this.lbLeftBerth = new DevComponents.DotNetBar.LabelX();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtSumBerthCount = new System.Windows.Forms.TextBox();
            this.labelX13 = new DevComponents.DotNetBar.LabelX();
            this.txtLat = new System.Windows.Forms.TextBox();
            this.txtFBerthCount = new System.Windows.Forms.TextBox();
            this.labelX17 = new DevComponents.DotNetBar.LabelX();
            this.labelX18 = new DevComponents.DotNetBar.LabelX();
            this.labelX15 = new DevComponents.DotNetBar.LabelX();
            this.txtBerthCount = new System.Windows.Forms.TextBox();
            this.txtLon = new System.Windows.Forms.TextBox();
            this.labelX16 = new DevComponents.DotNetBar.LabelX();
            this.btnSelectPoint = new System.Windows.Forms.Button();
            this.txtParkCounty = new System.Windows.Forms.TextBox();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.txtParkOwner = new System.Windows.Forms.TextBox();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.txtParkStreet = new System.Windows.Forms.TextBox();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.labelX14 = new DevComponents.DotNetBar.LabelX();
            this.txtParkType = new System.Windows.Forms.TextBox();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.txtBusinessTime = new System.Windows.Forms.TextBox();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.txtOwnerTel = new System.Windows.Forms.TextBox();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.txtParkCity = new System.Windows.Forms.TextBox();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.txtParkName = new System.Windows.Forms.TextBox();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txtParkId = new System.Windows.Forms.TextBox();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.comPanel.SuspendLayout();
            this.comGB.SuspendLayout();
            this.parkPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.parkGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // comPanel
            // 
            this.comPanel.Controls.Add(this.comGB);
            this.comPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.comPanel.Location = new System.Drawing.Point(0, 0);
            this.comPanel.Name = "comPanel";
            this.comPanel.Size = new System.Drawing.Size(876, 69);
            this.comPanel.TabIndex = 0;
            // 
            // comGB
            // 
            this.comGB.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.comGB.Controls.Add(this.txtName);
            this.comGB.Controls.Add(this.labelX2);
            this.comGB.Controls.Add(this.txtCompanyCode);
            this.comGB.Controls.Add(this.labelX1);
            this.comGB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comGB.Location = new System.Drawing.Point(0, 0);
            this.comGB.Name = "comGB";
            this.comGB.Size = new System.Drawing.Size(876, 69);
            this.comGB.TabIndex = 0;
            this.comGB.TabStop = false;
            this.comGB.Text = "经营单位信息";
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(296, 18);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(470, 21);
            this.txtName.TabIndex = 3;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(227, 18);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(88, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "单位名称：";
            // 
            // txtCompanyCode
            // 
            this.txtCompanyCode.Enabled = false;
            this.txtCompanyCode.Location = new System.Drawing.Point(86, 20);
            this.txtCompanyCode.Name = "txtCompanyCode";
            this.txtCompanyCode.Size = new System.Drawing.Size(135, 21);
            this.txtCompanyCode.TabIndex = 1;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(17, 20);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(88, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "单位编号：";
            // 
            // parkPanel
            // 
            this.parkPanel.Controls.Add(this.panel2);
            this.parkPanel.Controls.Add(this.parkGB);
            this.parkPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parkPanel.Location = new System.Drawing.Point(0, 69);
            this.parkPanel.Name = "parkPanel";
            this.parkPanel.Size = new System.Drawing.Size(876, 494);
            this.parkPanel.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 300);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(876, 194);
            this.panel2.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(876, 194);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 51;
            this.pictureBox1.TabStop = false;
            // 
            // parkGB
            // 
            this.parkGB.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.parkGB.Controls.Add(this.txtLeftBerth);
            this.parkGB.Controls.Add(this.lbLeftBerth);
            this.parkGB.Controls.Add(this.btnSave);
            this.parkGB.Controls.Add(this.txtSumBerthCount);
            this.parkGB.Controls.Add(this.labelX13);
            this.parkGB.Controls.Add(this.txtLat);
            this.parkGB.Controls.Add(this.txtFBerthCount);
            this.parkGB.Controls.Add(this.labelX17);
            this.parkGB.Controls.Add(this.labelX18);
            this.parkGB.Controls.Add(this.labelX15);
            this.parkGB.Controls.Add(this.txtBerthCount);
            this.parkGB.Controls.Add(this.txtLon);
            this.parkGB.Controls.Add(this.labelX16);
            this.parkGB.Controls.Add(this.btnSelectPoint);
            this.parkGB.Controls.Add(this.txtParkCounty);
            this.parkGB.Controls.Add(this.labelX6);
            this.parkGB.Controls.Add(this.txtParkOwner);
            this.parkGB.Controls.Add(this.labelX8);
            this.parkGB.Controls.Add(this.txtParkStreet);
            this.parkGB.Controls.Add(this.labelX7);
            this.parkGB.Controls.Add(this.txtRemark);
            this.parkGB.Controls.Add(this.labelX14);
            this.parkGB.Controls.Add(this.txtParkType);
            this.parkGB.Controls.Add(this.labelX12);
            this.parkGB.Controls.Add(this.txtBusinessTime);
            this.parkGB.Controls.Add(this.labelX10);
            this.parkGB.Controls.Add(this.txtOwnerTel);
            this.parkGB.Controls.Add(this.labelX9);
            this.parkGB.Controls.Add(this.txtParkCity);
            this.parkGB.Controls.Add(this.labelX5);
            this.parkGB.Controls.Add(this.txtParkName);
            this.parkGB.Controls.Add(this.labelX4);
            this.parkGB.Controls.Add(this.txtParkId);
            this.parkGB.Controls.Add(this.labelX3);
            this.parkGB.Dock = System.Windows.Forms.DockStyle.Top;
            this.parkGB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.parkGB.Location = new System.Drawing.Point(0, 0);
            this.parkGB.Name = "parkGB";
            this.parkGB.Size = new System.Drawing.Size(876, 300);
            this.parkGB.TabIndex = 0;
            this.parkGB.TabStop = false;
            this.parkGB.Text = "停车场信息";
            // 
            // txtLeftBerth
            // 
            this.txtLeftBerth.Location = new System.Drawing.Point(538, 143);
            this.txtLeftBerth.Name = "txtLeftBerth";
            this.txtLeftBerth.Size = new System.Drawing.Size(100, 21);
            this.txtLeftBerth.TabIndex = 51;
            this.txtLeftBerth.Visible = false;
            // 
            // lbLeftBerth
            // 
            // 
            // 
            // 
            this.lbLeftBerth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbLeftBerth.Location = new System.Drawing.Point(453, 142);
            this.lbLeftBerth.Name = "lbLeftBerth";
            this.lbLeftBerth.Size = new System.Drawing.Size(79, 23);
            this.lbLeftBerth.TabIndex = 50;
            this.lbLeftBerth.Text = "剩余泊位数：";
            this.lbLeftBerth.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(661, 255);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 39);
            this.btnSave.TabIndex = 47;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtSumBerthCount
            // 
            this.txtSumBerthCount.Location = new System.Drawing.Point(83, 112);
            this.txtSumBerthCount.Name = "txtSumBerthCount";
            this.txtSumBerthCount.Size = new System.Drawing.Size(138, 21);
            this.txtSumBerthCount.TabIndex = 46;
            this.txtSumBerthCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDigit_KeyPress);
            // 
            // labelX13
            // 
            // 
            // 
            // 
            this.labelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX13.Location = new System.Drawing.Point(17, 112);
            this.labelX13.Name = "labelX13";
            this.labelX13.Size = new System.Drawing.Size(88, 23);
            this.labelX13.TabIndex = 45;
            this.labelX13.Text = "总泊位数：";
            // 
            // txtLat
            // 
            this.txtLat.Location = new System.Drawing.Point(584, 89);
            this.txtLat.Name = "txtLat";
            this.txtLat.Size = new System.Drawing.Size(92, 21);
            this.txtLat.TabIndex = 44;
            // 
            // txtFBerthCount
            // 
            this.txtFBerthCount.Location = new System.Drawing.Point(538, 114);
            this.txtFBerthCount.Name = "txtFBerthCount";
            this.txtFBerthCount.Size = new System.Drawing.Size(100, 21);
            this.txtFBerthCount.TabIndex = 42;
            this.txtFBerthCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDigit_KeyPress);
            // 
            // labelX17
            // 
            // 
            // 
            // 
            this.labelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX17.Location = new System.Drawing.Point(453, 112);
            this.labelX17.Name = "labelX17";
            this.labelX17.Size = new System.Drawing.Size(79, 23);
            this.labelX17.TabIndex = 41;
            this.labelX17.Text = "固定泊位数：";
            // 
            // labelX18
            // 
            // 
            // 
            // 
            this.labelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX18.Location = new System.Drawing.Point(547, 87);
            this.labelX18.Name = "labelX18";
            this.labelX18.Size = new System.Drawing.Size(46, 23);
            this.labelX18.TabIndex = 43;
            this.labelX18.Text = "纬度：";
            // 
            // labelX15
            // 
            // 
            // 
            // 
            this.labelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX15.Location = new System.Drawing.Point(405, 86);
            this.labelX15.Name = "labelX15";
            this.labelX15.Size = new System.Drawing.Size(42, 23);
            this.labelX15.TabIndex = 28;
            this.labelX15.Text = "经度：";
            // 
            // txtBerthCount
            // 
            this.txtBerthCount.Location = new System.Drawing.Point(309, 112);
            this.txtBerthCount.Name = "txtBerthCount";
            this.txtBerthCount.Size = new System.Drawing.Size(138, 21);
            this.txtBerthCount.TabIndex = 40;
            this.txtBerthCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDigit_KeyPress);
            // 
            // txtLon
            // 
            this.txtLon.Location = new System.Drawing.Point(453, 88);
            this.txtLon.Name = "txtLon";
            this.txtLon.Size = new System.Drawing.Size(88, 21);
            this.txtLon.TabIndex = 29;
            // 
            // labelX16
            // 
            // 
            // 
            // 
            this.labelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX16.Location = new System.Drawing.Point(227, 113);
            this.labelX16.Name = "labelX16";
            this.labelX16.Size = new System.Drawing.Size(88, 23);
            this.labelX16.TabIndex = 39;
            this.labelX16.Text = "临时泊位数：";
            // 
            // btnSelectPoint
            // 
            this.btnSelectPoint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectPoint.Location = new System.Drawing.Point(691, 88);
            this.btnSelectPoint.Name = "btnSelectPoint";
            this.btnSelectPoint.Size = new System.Drawing.Size(75, 23);
            this.btnSelectPoint.TabIndex = 30;
            this.btnSelectPoint.Text = "选择…";
            this.btnSelectPoint.UseVisualStyleBackColor = true;
            this.btnSelectPoint.Click += new System.EventHandler(this.btnSelectPoint_Click);
            // 
            // txtParkCounty
            // 
            this.txtParkCounty.Location = new System.Drawing.Point(289, 55);
            this.txtParkCounty.Name = "txtParkCounty";
            this.txtParkCounty.Size = new System.Drawing.Size(107, 21);
            this.txtParkCounty.TabIndex = 38;
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(227, 54);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(88, 23);
            this.labelX6.TabIndex = 37;
            this.labelX6.Text = "区（县）：";
            // 
            // txtParkOwner
            // 
            this.txtParkOwner.Location = new System.Drawing.Point(83, 81);
            this.txtParkOwner.Name = "txtParkOwner";
            this.txtParkOwner.Size = new System.Drawing.Size(138, 21);
            this.txtParkOwner.TabIndex = 36;
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(28, 83);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(76, 23);
            this.labelX8.TabIndex = 35;
            this.labelX8.Text = "经营者：";
            // 
            // txtParkStreet
            // 
            this.txtParkStreet.Location = new System.Drawing.Point(453, 54);
            this.txtParkStreet.Name = "txtParkStreet";
            this.txtParkStreet.Size = new System.Drawing.Size(313, 21);
            this.txtParkStreet.TabIndex = 34;
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(405, 55);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(49, 23);
            this.labelX7.TabIndex = 33;
            this.labelX7.Text = "街道：";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(86, 171);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(680, 67);
            this.txtRemark.TabIndex = 25;
            // 
            // labelX14
            // 
            // 
            // 
            // 
            this.labelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX14.Location = new System.Drawing.Point(39, 168);
            this.labelX14.Name = "labelX14";
            this.labelX14.Size = new System.Drawing.Size(52, 23);
            this.labelX14.TabIndex = 24;
            this.labelX14.Text = "备注：";
            // 
            // txtParkType
            // 
            this.txtParkType.Location = new System.Drawing.Point(289, 83);
            this.txtParkType.Name = "txtParkType";
            this.txtParkType.Size = new System.Drawing.Size(107, 21);
            this.txtParkType.TabIndex = 21;
            // 
            // labelX12
            // 
            // 
            // 
            // 
            this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX12.Location = new System.Drawing.Point(227, 83);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(81, 23);
            this.labelX12.TabIndex = 20;
            this.labelX12.Text = "车场类型：";
            // 
            // txtBusinessTime
            // 
            this.txtBusinessTime.Location = new System.Drawing.Point(81, 140);
            this.txtBusinessTime.Name = "txtBusinessTime";
            this.txtBusinessTime.Size = new System.Drawing.Size(140, 21);
            this.txtBusinessTime.TabIndex = 17;
            // 
            // labelX10
            // 
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Location = new System.Drawing.Point(19, 140);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(88, 23);
            this.labelX10.TabIndex = 16;
            this.labelX10.Text = "营业时间：";
            // 
            // txtOwnerTel
            // 
            this.txtOwnerTel.Location = new System.Drawing.Point(309, 142);
            this.txtOwnerTel.Name = "txtOwnerTel";
            this.txtOwnerTel.Size = new System.Drawing.Size(138, 21);
            this.txtOwnerTel.TabIndex = 15;
            // 
            // labelX9
            // 
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(227, 143);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(88, 23);
            this.labelX9.TabIndex = 14;
            this.labelX9.Text = "经营者电话：";
            // 
            // txtParkCity
            // 
            this.txtParkCity.Location = new System.Drawing.Point(83, 54);
            this.txtParkCity.Name = "txtParkCity";
            this.txtParkCity.Size = new System.Drawing.Size(138, 21);
            this.txtParkCity.TabIndex = 7;
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(28, 54);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(77, 23);
            this.labelX5.TabIndex = 6;
            this.labelX5.Text = "所在市：";
            // 
            // txtParkName
            // 
            this.txtParkName.Location = new System.Drawing.Point(289, 21);
            this.txtParkName.Name = "txtParkName";
            this.txtParkName.Size = new System.Drawing.Size(477, 21);
            this.txtParkName.TabIndex = 5;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(227, 20);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(88, 23);
            this.labelX4.TabIndex = 4;
            this.labelX4.Text = "车场名称：";
            // 
            // txtParkId
            // 
            this.txtParkId.Location = new System.Drawing.Point(83, 21);
            this.txtParkId.Name = "txtParkId";
            this.txtParkId.Size = new System.Drawing.Size(138, 21);
            this.txtParkId.TabIndex = 3;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(17, 20);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(76, 23);
            this.labelX3.TabIndex = 2;
            this.labelX3.Text = "车场编号：";
            // 
            // frmParking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 563);
            this.Controls.Add(this.parkPanel);
            this.Controls.Add(this.comPanel);
            this.Name = "frmParking";
            this.Text = "停车场设置";
            this.Load += new System.EventHandler(this.frmParking_Load);
            this.comPanel.ResumeLayout(false);
            this.comGB.ResumeLayout(false);
            this.comGB.PerformLayout();
            this.parkPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.parkGB.ResumeLayout(false);
            this.parkGB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel comPanel;
        private System.Windows.Forms.GroupBox comGB;
        private System.Windows.Forms.TextBox txtName;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.TextBox txtCompanyCode;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.Panel parkPanel;
        private System.Windows.Forms.GroupBox parkGB;
        private System.Windows.Forms.TextBox txtRemark;
        private DevComponents.DotNetBar.LabelX labelX14;
        private System.Windows.Forms.TextBox txtParkType;
        private DevComponents.DotNetBar.LabelX labelX12;
        private System.Windows.Forms.TextBox txtBusinessTime;
        private DevComponents.DotNetBar.LabelX labelX10;
        private System.Windows.Forms.TextBox txtOwnerTel;
        private DevComponents.DotNetBar.LabelX labelX9;
        private System.Windows.Forms.TextBox txtParkCity;
        private DevComponents.DotNetBar.LabelX labelX5;
        private System.Windows.Forms.TextBox txtParkName;
        private DevComponents.DotNetBar.LabelX labelX4;
        private System.Windows.Forms.TextBox txtParkId;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.Button btnSelectPoint;
        private DevComponents.DotNetBar.LabelX labelX15;
        private System.Windows.Forms.TextBox txtParkCounty;
        private DevComponents.DotNetBar.LabelX labelX6;
        private System.Windows.Forms.TextBox txtParkOwner;
        private DevComponents.DotNetBar.LabelX labelX8;
        private System.Windows.Forms.TextBox txtParkStreet;
        private DevComponents.DotNetBar.LabelX labelX7;
        private System.Windows.Forms.TextBox txtFBerthCount;
        private DevComponents.DotNetBar.LabelX labelX17;
        private System.Windows.Forms.TextBox txtBerthCount;
        private DevComponents.DotNetBar.LabelX labelX16;
        public System.Windows.Forms.TextBox txtLon;
        public System.Windows.Forms.TextBox txtLat;
        private DevComponents.DotNetBar.LabelX labelX18;
        private System.Windows.Forms.TextBox txtSumBerthCount;
        private DevComponents.DotNetBar.LabelX labelX13;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtLeftBerth;
        private DevComponents.DotNetBar.LabelX lbLeftBerth;
    }
}