namespace ChargeWin
{
    partial class frmConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfig));
            this.gbFee = new System.Windows.Forms.GroupBox();
            this.txtOverTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbIsOutSelectFreeFee = new System.Windows.Forms.CheckBox();
            this.cbIsFCustomerFee = new System.Windows.Forms.CheckBox();
            this.gbMonitor = new System.Windows.Forms.GroupBox();
            this.delData = new System.Windows.Forms.Button();
            this.cbAutoOpen = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDeleteDay = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOverDay = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbIsOpenNotConfirm = new System.Windows.Forms.CheckBox();
            this.cbIsExistByPwd = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbox_movecar = new System.Windows.Forms.CheckBox();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.gbPlay = new System.Windows.Forms.GroupBox();
            this.cbLplay = new System.Windows.Forms.CheckBox();
            this.cbFplay = new System.Windows.Forms.CheckBox();
            this.gbLoad = new System.Windows.Forms.GroupBox();
            this.cbHandOff = new System.Windows.Forms.CheckBox();
            this.cbcarUpload = new System.Windows.Forms.CheckBox();
            this.buttools = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.butInit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.butAddFree = new System.Windows.Forms.Button();
            this.txtFree = new System.Windows.Forms.TextBox();
            this.lboxfree = new System.Windows.Forms.ListBox();
            this.butSaveFree = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbox_winstoptime = new System.Windows.Forms.TextBox();
            this.gbFee.SuspendLayout();
            this.gbMonitor.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbPlay.SuspendLayout();
            this.gbLoad.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFee
            // 
            this.gbFee.Controls.Add(this.txtOverTime);
            this.gbFee.Controls.Add(this.label1);
            this.gbFee.Controls.Add(this.cbIsOutSelectFreeFee);
            this.gbFee.Controls.Add(this.cbIsFCustomerFee);
            this.gbFee.Location = new System.Drawing.Point(13, 13);
            this.gbFee.Name = "gbFee";
            this.gbFee.Size = new System.Drawing.Size(275, 115);
            this.gbFee.TabIndex = 0;
            this.gbFee.TabStop = false;
            this.gbFee.Text = "收费设置";
            // 
            // txtOverTime
            // 
            this.txtOverTime.Location = new System.Drawing.Point(212, 77);
            this.txtOverTime.Name = "txtOverTime";
            this.txtOverTime.Size = new System.Drawing.Size(45, 21);
            this.txtOverTime.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "超过多少（分钟）按一计时单位计算";
            // 
            // cbIsOutSelectFreeFee
            // 
            this.cbIsOutSelectFreeFee.AutoSize = true;
            this.cbIsOutSelectFreeFee.Location = new System.Drawing.Point(11, 52);
            this.cbIsOutSelectFreeFee.Name = "cbIsOutSelectFreeFee";
            this.cbIsOutSelectFreeFee.Size = new System.Drawing.Size(144, 16);
            this.cbIsOutSelectFreeFee.TabIndex = 1;
            this.cbIsOutSelectFreeFee.Text = "临时车出场可选择免费";
            this.cbIsOutSelectFreeFee.UseVisualStyleBackColor = true;
            // 
            // cbIsFCustomerFee
            // 
            this.cbIsFCustomerFee.AutoSize = true;
            this.cbIsFCustomerFee.Location = new System.Drawing.Point(11, 25);
            this.cbIsFCustomerFee.Name = "cbIsFCustomerFee";
            this.cbIsFCustomerFee.Size = new System.Drawing.Size(96, 16);
            this.cbIsFCustomerFee.TabIndex = 0;
            this.cbIsFCustomerFee.Text = "月卡过期收费";
            this.cbIsFCustomerFee.UseVisualStyleBackColor = true;
            // 
            // gbMonitor
            // 
            this.gbMonitor.Controls.Add(this.tbox_winstoptime);
            this.gbMonitor.Controls.Add(this.label2);
            this.gbMonitor.Controls.Add(this.delData);
            this.gbMonitor.Controls.Add(this.cbAutoOpen);
            this.gbMonitor.Controls.Add(this.label8);
            this.gbMonitor.Controls.Add(this.label7);
            this.gbMonitor.Controls.Add(this.label5);
            this.gbMonitor.Controls.Add(this.txtDeleteDay);
            this.gbMonitor.Controls.Add(this.label6);
            this.gbMonitor.Controls.Add(this.label3);
            this.gbMonitor.Controls.Add(this.txtOverDay);
            this.gbMonitor.Controls.Add(this.label4);
            this.gbMonitor.Controls.Add(this.cbIsOpenNotConfirm);
            this.gbMonitor.Controls.Add(this.cbIsExistByPwd);
            this.gbMonitor.Location = new System.Drawing.Point(294, 13);
            this.gbMonitor.Name = "gbMonitor";
            this.gbMonitor.Size = new System.Drawing.Size(210, 204);
            this.gbMonitor.TabIndex = 1;
            this.gbMonitor.TabStop = false;
            this.gbMonitor.Text = "在线监控设置";
            // 
            // delData
            // 
            this.delData.ForeColor = System.Drawing.Color.Red;
            this.delData.Location = new System.Drawing.Point(128, 172);
            this.delData.Name = "delData";
            this.delData.Size = new System.Drawing.Size(75, 23);
            this.delData.TabIndex = 14;
            this.delData.Text = "现在清除";
            this.delData.UseVisualStyleBackColor = true;
            this.delData.Click += new System.EventHandler(this.delData_Click);
            // 
            // cbAutoOpen
            // 
            this.cbAutoOpen.AutoSize = true;
            this.cbAutoOpen.Checked = true;
            this.cbAutoOpen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoOpen.Location = new System.Drawing.Point(19, 84);
            this.cbAutoOpen.Name = "cbAutoOpen";
            this.cbAutoOpen.Size = new System.Drawing.Size(156, 16);
            this.cbAutoOpen.TabIndex = 13;
            this.cbAutoOpen.Text = "免费时间内出场自动开闸";
            this.cbAutoOpen.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(91, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "（天）";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(14, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "设置系统自动删除多少天前的数据";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(122, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 12);
            this.label5.TabIndex = 10;
            // 
            // txtDeleteDay
            // 
            this.txtDeleteDay.Location = new System.Drawing.Point(19, 175);
            this.txtDeleteDay.Name = "txtDeleteDay";
            this.txtDeleteDay.Size = new System.Drawing.Size(66, 21);
            this.txtDeleteDay.TabIndex = 9;
            this.txtDeleteDay.Text = "30";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 12);
            this.label6.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(125, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "（天）";
            // 
            // txtOverDay
            // 
            this.txtOverDay.Location = new System.Drawing.Point(19, 125);
            this.txtOverDay.Name = "txtOverDay";
            this.txtOverDay.Size = new System.Drawing.Size(100, 21);
            this.txtOverDay.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "固定车临近到期几天提示续费";
            // 
            // cbIsOpenNotConfirm
            // 
            this.cbIsOpenNotConfirm.AutoSize = true;
            this.cbIsOpenNotConfirm.Location = new System.Drawing.Point(19, 46);
            this.cbIsOpenNotConfirm.Name = "cbIsOpenNotConfirm";
            this.cbIsOpenNotConfirm.Size = new System.Drawing.Size(120, 16);
            this.cbIsOpenNotConfirm.TabIndex = 2;
            this.cbIsOpenNotConfirm.Text = "软件开闸无需确认";
            this.cbIsOpenNotConfirm.UseVisualStyleBackColor = true;
            // 
            // cbIsExistByPwd
            // 
            this.cbIsExistByPwd.AutoSize = true;
            this.cbIsExistByPwd.Location = new System.Drawing.Point(19, 22);
            this.cbIsExistByPwd.Name = "cbIsExistByPwd";
            this.cbIsExistByPwd.Size = new System.Drawing.Size(156, 16);
            this.cbIsExistByPwd.TabIndex = 1;
            this.cbIsExistByPwd.Text = "凭登陆密码退出在线监控";
            this.cbIsExistByPwd.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbox_movecar);
            this.groupBox1.Controls.Add(this.rb2);
            this.groupBox1.Controls.Add(this.rb1);
            this.groupBox1.Location = new System.Drawing.Point(13, 134);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 83);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "        ";
            // 
            // chbox_movecar
            // 
            this.chbox_movecar.AutoSize = true;
            this.chbox_movecar.Checked = true;
            this.chbox_movecar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbox_movecar.Location = new System.Drawing.Point(11, 0);
            this.chbox_movecar.Name = "chbox_movecar";
            this.chbox_movecar.Size = new System.Drawing.Size(78, 16);
            this.chbox_movecar.TabIndex = 7;
            this.chbox_movecar.Text = " 一户多车";
            this.chbox_movecar.UseVisualStyleBackColor = true;
            this.chbox_movecar.CheckedChanged += new System.EventHandler(this.chbox_movecar_CheckedChanged);
            // 
            // rb2
            // 
            this.rb2.AutoSize = true;
            this.rb2.Checked = true;
            this.rb2.Location = new System.Drawing.Point(11, 54);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(251, 16);
            this.rb2.TabIndex = 1;
            this.rb2.TabStop = true;
            this.rb2.Text = "车位空置，车主名下车辆自动转为固定车辆";
            this.rb2.UseVisualStyleBackColor = true;
            // 
            // rb1
            // 
            this.rb1.AutoSize = true;
            this.rb1.Location = new System.Drawing.Point(11, 24);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(215, 16);
            this.rb1.TabIndex = 0;
            this.rb1.TabStop = true;
            this.rb1.Text = "先进场为固定车，后进场为临时车。";
            this.rb1.UseVisualStyleBackColor = true;
            // 
            // gbPlay
            // 
            this.gbPlay.Controls.Add(this.cbLplay);
            this.gbPlay.Controls.Add(this.cbFplay);
            this.gbPlay.Location = new System.Drawing.Point(24, 223);
            this.gbPlay.Name = "gbPlay";
            this.gbPlay.Size = new System.Drawing.Size(264, 74);
            this.gbPlay.TabIndex = 7;
            this.gbPlay.TabStop = false;
            this.gbPlay.Text = "播报内容设置";
            // 
            // cbLplay
            // 
            this.cbLplay.AutoSize = true;
            this.cbLplay.Checked = true;
            this.cbLplay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLplay.Location = new System.Drawing.Point(6, 52);
            this.cbLplay.Name = "cbLplay";
            this.cbLplay.Size = new System.Drawing.Size(192, 16);
            this.cbLplay.TabIndex = 1;
            this.cbLplay.Text = "临时车辆进出播报显示车牌号码";
            this.cbLplay.UseVisualStyleBackColor = true;
            // 
            // cbFplay
            // 
            this.cbFplay.AutoSize = true;
            this.cbFplay.Location = new System.Drawing.Point(6, 24);
            this.cbFplay.Name = "cbFplay";
            this.cbFplay.Size = new System.Drawing.Size(192, 16);
            this.cbFplay.TabIndex = 0;
            this.cbFplay.Text = "月租车辆进出播报显示车牌号码";
            this.cbFplay.UseVisualStyleBackColor = true;
            // 
            // gbLoad
            // 
            this.gbLoad.Controls.Add(this.cbHandOff);
            this.gbLoad.Controls.Add(this.cbcarUpload);
            this.gbLoad.Location = new System.Drawing.Point(294, 223);
            this.gbLoad.Name = "gbLoad";
            this.gbLoad.Size = new System.Drawing.Size(210, 74);
            this.gbLoad.TabIndex = 8;
            this.gbLoad.TabStop = false;
            this.gbLoad.Text = "其它设置";
            // 
            // cbHandOff
            // 
            this.cbHandOff.AutoSize = true;
            this.cbHandOff.Location = new System.Drawing.Point(10, 48);
            this.cbHandOff.Name = "cbHandOff";
            this.cbHandOff.Size = new System.Drawing.Size(96, 16);
            this.cbHandOff.TabIndex = 2;
            this.cbHandOff.Text = "启用手动开闸";
            this.cbHandOff.UseVisualStyleBackColor = true;
            // 
            // cbcarUpload
            // 
            this.cbcarUpload.AutoSize = true;
            this.cbcarUpload.Location = new System.Drawing.Point(10, 24);
            this.cbcarUpload.Name = "cbcarUpload";
            this.cbcarUpload.Size = new System.Drawing.Size(156, 16);
            this.cbcarUpload.TabIndex = 1;
            this.cbcarUpload.Text = "本地数据允许上传到云端";
            this.cbcarUpload.UseVisualStyleBackColor = true;
            // 
            // buttools
            // 
            this.buttools.Image = global::ChargeWin.Properties.Resources.设置_1png;
            this.buttools.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttools.Location = new System.Drawing.Point(168, 312);
            this.buttools.Name = "buttools";
            this.buttools.Size = new System.Drawing.Size(155, 23);
            this.buttools.TabIndex = 9;
            this.buttools.Text = "摄像机更多配置...";
            this.buttools.UseVisualStyleBackColor = true;
            this.buttools.Click += new System.EventHandler(this.buttools_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(695, 312);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "退出";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(340, 310);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(120, 27);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "保存参数";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // butInit
            // 
            this.butInit.Image = global::ChargeWin.Properties.Resources.import;
            this.butInit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butInit.Location = new System.Drawing.Point(24, 312);
            this.butInit.Name = "butInit";
            this.butInit.Size = new System.Drawing.Size(138, 23);
            this.butInit.TabIndex = 10;
            this.butInit.Text = "初始化配置文件";
            this.butInit.UseVisualStyleBackColor = true;
            this.butInit.Click += new System.EventHandler(this.butInit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.butAddFree);
            this.groupBox2.Controls.Add(this.txtFree);
            this.groupBox2.Controls.Add(this.lboxfree);
            this.groupBox2.Location = new System.Drawing.Point(510, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(268, 284);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "免费放行原因自定义";
            // 
            // butAddFree
            // 
            this.butAddFree.Image = global::ChargeWin.Properties.Resources.setting;
            this.butAddFree.Location = new System.Drawing.Point(227, 23);
            this.butAddFree.Name = "butAddFree";
            this.butAddFree.Size = new System.Drawing.Size(38, 23);
            this.butAddFree.TabIndex = 2;
            this.butAddFree.UseVisualStyleBackColor = true;
            this.butAddFree.Click += new System.EventHandler(this.butAddFree_Click);
            // 
            // txtFree
            // 
            this.txtFree.Location = new System.Drawing.Point(4, 25);
            this.txtFree.Name = "txtFree";
            this.txtFree.Size = new System.Drawing.Size(219, 21);
            this.txtFree.TabIndex = 1;
            this.txtFree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFree_KeyDown);
            // 
            // lboxfree
            // 
            this.lboxfree.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lboxfree.FormattingEnabled = true;
            this.lboxfree.ItemHeight = 12;
            this.lboxfree.Location = new System.Drawing.Point(3, 49);
            this.lboxfree.Name = "lboxfree";
            this.lboxfree.Size = new System.Drawing.Size(262, 232);
            this.lboxfree.TabIndex = 0;
            this.lboxfree.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lboxfree_MouseDoubleClick);
            // 
            // butSaveFree
            // 
            this.butSaveFree.Image = global::ChargeWin.Properties.Resources.save;
            this.butSaveFree.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSaveFree.Location = new System.Drawing.Point(510, 310);
            this.butSaveFree.Name = "butSaveFree";
            this.butSaveFree.Size = new System.Drawing.Size(135, 29);
            this.butSaveFree.TabIndex = 12;
            this.butSaveFree.Text = "保存免费原因";
            this.butSaveFree.UseVisualStyleBackColor = true;
            this.butSaveFree.Click += new System.EventHandler(this.butSaveFree_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "窗口停留时间:     秒";
            // 
            // tbox_winstoptime
            // 
            this.tbox_winstoptime.Location = new System.Drawing.Point(118, 61);
            this.tbox_winstoptime.Name = "tbox_winstoptime";
            this.tbox_winstoptime.Size = new System.Drawing.Size(21, 21);
            this.tbox_winstoptime.TabIndex = 16;
            this.tbox_winstoptime.Text = "60";
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(794, 361);
            this.Controls.Add(this.butSaveFree);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.butInit);
            this.Controls.Add(this.buttools);
            this.Controls.Add(this.gbLoad);
            this.Controls.Add(this.gbPlay);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbMonitor);
            this.Controls.Add(this.gbFee);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "参数设置";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.gbFee.ResumeLayout(false);
            this.gbFee.PerformLayout();
            this.gbMonitor.ResumeLayout(false);
            this.gbMonitor.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbPlay.ResumeLayout(false);
            this.gbPlay.PerformLayout();
            this.gbLoad.ResumeLayout(false);
            this.gbLoad.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFee;
        private System.Windows.Forms.TextBox txtOverTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbIsOutSelectFreeFee;
        private System.Windows.Forms.CheckBox cbIsFCustomerFee;
        private System.Windows.Forms.GroupBox gbMonitor;
        private System.Windows.Forms.CheckBox cbIsOpenNotConfirm;
        private System.Windows.Forms.CheckBox cbIsExistByPwd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOverDay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDeleteDay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbAutoOpen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb2;
        private System.Windows.Forms.RadioButton rb1;
        private System.Windows.Forms.Button delData;
        private System.Windows.Forms.CheckBox chbox_movecar;
        private System.Windows.Forms.GroupBox gbPlay;
        private System.Windows.Forms.CheckBox cbLplay;
        private System.Windows.Forms.CheckBox cbFplay;
        private System.Windows.Forms.GroupBox gbLoad;
        private System.Windows.Forms.CheckBox cbHandOff;
        private System.Windows.Forms.CheckBox cbcarUpload;
        private System.Windows.Forms.Button buttools;
        private System.Windows.Forms.Button butInit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lboxfree;
        private System.Windows.Forms.Button butSaveFree;
        private System.Windows.Forms.Button butAddFree;
        private System.Windows.Forms.TextBox txtFree;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbox_winstoptime;
    }
}