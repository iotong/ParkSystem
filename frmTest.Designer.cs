namespace ChargeWin
{
    partial class frmTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTest));
            this.dtpOutTime = new System.Windows.Forms.DateTimePicker();
            this.lblOutTime = new System.Windows.Forms.Label();
            this.dtpInTime = new System.Windows.Forms.DateTimePicker();
            this.lblInTime = new System.Windows.Forms.Label();
            this.btnProQuery = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCarType = new System.Windows.Forms.ComboBox();
            this.txtSumMoney = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtpOutTime
            // 
            this.dtpOutTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpOutTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOutTime.Location = new System.Drawing.Point(73, 53);
            this.dtpOutTime.Name = "dtpOutTime";
            this.dtpOutTime.Size = new System.Drawing.Size(155, 21);
            this.dtpOutTime.TabIndex = 58;
            // 
            // lblOutTime
            // 
            this.lblOutTime.AutoSize = true;
            this.lblOutTime.Location = new System.Drawing.Point(12, 56);
            this.lblOutTime.Name = "lblOutTime";
            this.lblOutTime.Size = new System.Drawing.Size(59, 12);
            this.lblOutTime.TabIndex = 57;
            this.lblOutTime.Text = "出场时间:";
            // 
            // dtpInTime
            // 
            this.dtpInTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpInTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInTime.Location = new System.Drawing.Point(73, 6);
            this.dtpInTime.Name = "dtpInTime";
            this.dtpInTime.Size = new System.Drawing.Size(156, 21);
            this.dtpInTime.TabIndex = 56;
            // 
            // lblInTime
            // 
            this.lblInTime.AutoSize = true;
            this.lblInTime.Location = new System.Drawing.Point(11, 9);
            this.lblInTime.Name = "lblInTime";
            this.lblInTime.Size = new System.Drawing.Size(59, 12);
            this.lblInTime.TabIndex = 55;
            this.lblInTime.Text = "入场时间:";
            // 
            // btnProQuery
            // 
            this.btnProQuery.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnProQuery.Font = new System.Drawing.Font("宋体", 9F);
            this.btnProQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnProQuery.Image")));
            this.btnProQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProQuery.Location = new System.Drawing.Point(14, 140);
            this.btnProQuery.Name = "btnProQuery";
            this.btnProQuery.Size = new System.Drawing.Size(81, 22);
            this.btnProQuery.TabIndex = 53;
            this.btnProQuery.Text = "计算";
            this.btnProQuery.UseVisualStyleBackColor = true;
            this.btnProQuery.Click += new System.EventHandler(this.btnProQuery_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 59;
            this.label1.Text = "车辆类型:";
            // 
            // cbCarType
            // 
            this.cbCarType.FormattingEnabled = true;
            this.cbCarType.Items.AddRange(new object[] {
            "小型车",
            "中大型车",
            "公务车"});
            this.cbCarType.Location = new System.Drawing.Point(76, 94);
            this.cbCarType.Name = "cbCarType";
            this.cbCarType.Size = new System.Drawing.Size(152, 20);
            this.cbCarType.TabIndex = 60;
            this.cbCarType.Text = "内部车辆";
            // 
            // txtSumMoney
            // 
            this.txtSumMoney.Location = new System.Drawing.Point(112, 140);
            this.txtSumMoney.Name = "txtSumMoney";
            this.txtSumMoney.Size = new System.Drawing.Size(116, 21);
            this.txtSumMoney.TabIndex = 61;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(467, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 62;
            this.button1.Text = "入场";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(467, 140);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 63;
            this.button2.Text = "出场";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 377);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSumMoney);
            this.Controls.Add(this.cbCarType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpOutTime);
            this.Controls.Add(this.lblOutTime);
            this.Controls.Add(this.dtpInTime);
            this.Controls.Add(this.lblInTime);
            this.Controls.Add(this.btnProQuery);
            this.Name = "frmTest";
            this.Text = "frmTest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpOutTime;
        private System.Windows.Forms.Label lblOutTime;
        private System.Windows.Forms.DateTimePicker dtpInTime;
        private System.Windows.Forms.Label lblInTime;
        private System.Windows.Forms.Button btnProQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCarType;
        private System.Windows.Forms.TextBox txtSumMoney;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}