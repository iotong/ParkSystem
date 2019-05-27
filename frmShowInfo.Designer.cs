namespace ChargeWin
{
    partial class frmShowInfo
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPlateId = new System.Windows.Forms.TextBox();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOutTime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.picPlate = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPlate)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "车牌号码：";
            // 
            // txtPlateId
            // 
            this.txtPlateId.Location = new System.Drawing.Point(87, 7);
            this.txtPlateId.Name = "txtPlateId";
            this.txtPlateId.Size = new System.Drawing.Size(100, 21);
            this.txtPlateId.TabIndex = 1;
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(87, 70);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(100, 21);
            this.txtColor.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "车牌颜色：";
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(87, 137);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(100, 21);
            this.txtType.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "车牌类型：";
            // 
            // txtInTime
            // 
            this.txtInTime.Location = new System.Drawing.Point(87, 200);
            this.txtInTime.Name = "txtInTime";
            this.txtInTime.Size = new System.Drawing.Size(100, 21);
            this.txtInTime.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "进场时间：";
            // 
            // txtOutTime
            // 
            this.txtOutTime.Location = new System.Drawing.Point(87, 257);
            this.txtOutTime.Name = "txtOutTime";
            this.txtOutTime.Size = new System.Drawing.Size(100, 21);
            this.txtOutTime.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "出场时间：";
            // 
            // picPlate
            // 
            this.picPlate.Location = new System.Drawing.Point(206, 7);
            this.picPlate.Name = "picPlate";
            this.picPlate.Size = new System.Drawing.Size(356, 276);
            this.picPlate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPlate.TabIndex = 10;
            this.picPlate.TabStop = false;
            // 
            // frmShowInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(572, 292);
            this.Controls.Add(this.picPlate);
            this.Controls.Add(this.txtOutTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtInTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPlateId);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShowInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "车辆详细";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.picPlate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPlateId;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOutTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox picPlate;

    }
}