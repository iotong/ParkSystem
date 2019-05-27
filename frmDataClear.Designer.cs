namespace ChargeWin
{
    partial class frmDataClear
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDataClear));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbsystem = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.chbfcarinout = new System.Windows.Forms.CheckBox();
            this.chbchargstand = new System.Windows.Forms.CheckBox();
            this.chbrecord = new System.Windows.Forms.CheckBox();
            this.chbjob = new System.Windows.Forms.CheckBox();
            this.chbcarcharge = new System.Windows.Forms.CheckBox();
            this.chblcarinout = new System.Windows.Forms.CheckBox();
            this.butOk = new System.Windows.Forms.Button();
            this.butclose = new System.Windows.Forms.Button();
            this.butSele = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbsystem);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDay);
            this.groupBox1.Controls.Add(this.chbfcarinout);
            this.groupBox1.Controls.Add(this.chbchargstand);
            this.groupBox1.Controls.Add(this.chbrecord);
            this.groupBox1.Controls.Add(this.chbjob);
            this.groupBox1.Controls.Add(this.chbcarcharge);
            this.groupBox1.Controls.Add(this.chblcarinout);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 175);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择要清理的数据";
            // 
            // chbsystem
            // 
            this.chbsystem.AutoSize = true;
            this.chbsystem.ForeColor = System.Drawing.Color.Red;
            this.chbsystem.Location = new System.Drawing.Point(20, 113);
            this.chbsystem.Name = "chbsystem";
            this.chbsystem.Size = new System.Drawing.Size(192, 16);
            this.chbsystem.TabIndex = 9;
            this.chbsystem.Text = "系统设置参数(摄像机、显示屏)";
            this.chbsystem.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "天前的数据";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(193, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "删除";
            // 
            // txtDay
            // 
            this.txtDay.Location = new System.Drawing.Point(227, 145);
            this.txtDay.Name = "txtDay";
            this.txtDay.Size = new System.Drawing.Size(23, 21);
            this.txtDay.TabIndex = 6;
            this.txtDay.Text = "30";
            // 
            // chbfcarinout
            // 
            this.chbfcarinout.AutoSize = true;
            this.chbfcarinout.Checked = true;
            this.chbfcarinout.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbfcarinout.Location = new System.Drawing.Point(20, 53);
            this.chbfcarinout.Name = "chbfcarinout";
            this.chbfcarinout.Size = new System.Drawing.Size(120, 16);
            this.chbfcarinout.TabIndex = 5;
            this.chbfcarinout.Text = "固定车辆进出记录";
            this.chbfcarinout.UseVisualStyleBackColor = true;
            // 
            // chbchargstand
            // 
            this.chbchargstand.AutoSize = true;
            this.chbchargstand.ForeColor = System.Drawing.Color.Red;
            this.chbchargstand.Location = new System.Drawing.Point(29, 150);
            this.chbchargstand.Name = "chbchargstand";
            this.chbchargstand.Size = new System.Drawing.Size(96, 16);
            this.chbchargstand.TabIndex = 4;
            this.chbchargstand.Text = "收费标准记录";
            this.chbchargstand.UseVisualStyleBackColor = true;
            this.chbchargstand.Visible = false;
            // 
            // chbrecord
            // 
            this.chbrecord.AutoSize = true;
            this.chbrecord.ForeColor = System.Drawing.Color.Red;
            this.chbrecord.Location = new System.Drawing.Point(20, 84);
            this.chbrecord.Name = "chbrecord";
            this.chbrecord.Size = new System.Drawing.Size(96, 16);
            this.chbrecord.TabIndex = 3;
            this.chbrecord.Text = "固定车辆档案";
            this.chbrecord.UseVisualStyleBackColor = true;
            // 
            // chbjob
            // 
            this.chbjob.AutoSize = true;
            this.chbjob.Checked = true;
            this.chbjob.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbjob.Location = new System.Drawing.Point(205, 53);
            this.chbjob.Name = "chbjob";
            this.chbjob.Size = new System.Drawing.Size(84, 16);
            this.chbjob.TabIndex = 2;
            this.chbjob.Text = "上下班记录";
            this.chbjob.UseVisualStyleBackColor = true;
            // 
            // chbcarcharge
            // 
            this.chbcarcharge.AutoSize = true;
            this.chbcarcharge.Checked = true;
            this.chbcarcharge.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbcarcharge.Location = new System.Drawing.Point(203, 21);
            this.chbcarcharge.Name = "chbcarcharge";
            this.chbcarcharge.Size = new System.Drawing.Size(96, 16);
            this.chbcarcharge.TabIndex = 1;
            this.chbcarcharge.Text = "车辆收费记录";
            this.chbcarcharge.UseVisualStyleBackColor = true;
            // 
            // chblcarinout
            // 
            this.chblcarinout.AutoSize = true;
            this.chblcarinout.Checked = true;
            this.chblcarinout.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chblcarinout.Location = new System.Drawing.Point(20, 21);
            this.chblcarinout.Name = "chblcarinout";
            this.chblcarinout.Size = new System.Drawing.Size(120, 16);
            this.chblcarinout.TabIndex = 0;
            this.chblcarinout.Text = "临停车辆进出记录";
            this.chblcarinout.UseVisualStyleBackColor = true;
            // 
            // butOk
            // 
            this.butOk.Image = global::ChargeWin.Properties.Resources.浏览2;
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(144, 210);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(96, 23);
            this.butOk.TabIndex = 2;
            this.butOk.Text = "确定";
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butclose
            // 
            this.butclose.Image = global::ChargeWin.Properties.Resources.退出;
            this.butclose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butclose.Location = new System.Drawing.Point(270, 210);
            this.butclose.Name = "butclose";
            this.butclose.Size = new System.Drawing.Size(96, 23);
            this.butclose.TabIndex = 3;
            this.butclose.Text = "关闭";
            this.butclose.UseVisualStyleBackColor = true;
            this.butclose.Click += new System.EventHandler(this.butclose_Click);
            // 
            // butSele
            // 
            this.butSele.Image = global::ChargeWin.Properties.Resources.还原;
            this.butSele.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSele.Location = new System.Drawing.Point(12, 210);
            this.butSele.Name = "butSele";
            this.butSele.Size = new System.Drawing.Size(82, 23);
            this.butSele.TabIndex = 1;
            this.butSele.Text = "全  选";
            this.butSele.UseVisualStyleBackColor = true;
            this.butSele.Click += new System.EventHandler(this.butSele_Click);
            // 
            // frmDataClear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 245);
            this.Controls.Add(this.butclose);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.butSele);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDataClear";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据清理";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chbjob;
        private System.Windows.Forms.CheckBox chbcarcharge;
        private System.Windows.Forms.CheckBox chblcarinout;
        private System.Windows.Forms.CheckBox chbsystem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDay;
        private System.Windows.Forms.CheckBox chbfcarinout;
        private System.Windows.Forms.CheckBox chbchargstand;
        private System.Windows.Forms.CheckBox chbrecord;
        private System.Windows.Forms.Button butSele;
        private System.Windows.Forms.Button butOk;
        private System.Windows.Forms.Button butclose;
    }
}