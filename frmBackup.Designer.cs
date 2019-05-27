namespace ChargeWin
{
    partial class frmBackup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBackup));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBackup = new System.Windows.Forms.Button();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.btnBrower2 = new System.Windows.Forms.Button();
            this.txtBackPath = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBackup);
            this.groupBox1.Controls.Add(this.labelX3);
            this.groupBox1.Controls.Add(this.btnBrower2);
            this.groupBox1.Controls.Add(this.txtBackPath);
            this.groupBox1.Location = new System.Drawing.Point(16, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 142);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "备份";
            // 
            // btnBackup
            // 
            this.btnBackup.Image = global::ChargeWin.Properties.Resources.备份图标;
            this.btnBackup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBackup.Location = new System.Drawing.Point(303, 113);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(56, 23);
            this.btnBackup.TabIndex = 6;
            this.btnBackup.Text = "备份";
            this.btnBackup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(21, 36);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(138, 23);
            this.labelX3.TabIndex = 5;
            this.labelX3.Text = "请选择备份位置";
            // 
            // btnBrower2
            // 
            this.btnBrower2.Image = global::ChargeWin.Properties.Resources.浏览2;
            this.btnBrower2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrower2.Location = new System.Drawing.Point(305, 65);
            this.btnBrower2.Name = "btnBrower2";
            this.btnBrower2.Size = new System.Drawing.Size(54, 23);
            this.btnBrower2.TabIndex = 4;
            this.btnBrower2.Text = "浏览";
            this.btnBrower2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBrower2.UseVisualStyleBackColor = true;
            this.btnBrower2.Click += new System.EventHandler(this.btnBrower2_Click);
            // 
            // txtBackPath
            // 
            this.txtBackPath.Location = new System.Drawing.Point(21, 65);
            this.txtBackPath.Name = "txtBackPath";
            this.txtBackPath.Size = new System.Drawing.Size(269, 21);
            this.txtBackPath.TabIndex = 3;
            // 
            // frmBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(412, 175);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBackup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据备份";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBackup;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.Button btnBrower2;
        private System.Windows.Forms.TextBox txtBackPath;
    }
}