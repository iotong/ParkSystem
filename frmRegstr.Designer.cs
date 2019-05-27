namespace ChargeWin
{
    partial class frmRegstr
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegstr));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbox_key1 = new System.Windows.Forms.TextBox();
            this.tbox_key2 = new System.Windows.Forms.TextBox();
            this.tbox_res = new System.Windows.Forms.TextBox();
            this.but_ok = new System.Windows.Forms.Button();
            this.but_close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(2, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(221, 251);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(243, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "KEY1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(243, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "KEY2:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(243, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "RegCode:";
            // 
            // tbox_key1
            // 
            this.tbox_key1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbox_key1.Location = new System.Drawing.Point(305, 21);
            this.tbox_key1.Name = "tbox_key1";
            this.tbox_key1.Size = new System.Drawing.Size(296, 26);
            this.tbox_key1.TabIndex = 4;
            // 
            // tbox_key2
            // 
            this.tbox_key2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbox_key2.Location = new System.Drawing.Point(305, 69);
            this.tbox_key2.Name = "tbox_key2";
            this.tbox_key2.Size = new System.Drawing.Size(296, 26);
            this.tbox_key2.TabIndex = 5;
            // 
            // tbox_res
            // 
            this.tbox_res.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbox_res.Location = new System.Drawing.Point(305, 119);
            this.tbox_res.Name = "tbox_res";
            this.tbox_res.Size = new System.Drawing.Size(296, 26);
            this.tbox_res.TabIndex = 6;
            // 
            // but_ok
            // 
            this.but_ok.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_ok.Image = ((System.Drawing.Image)(resources.GetObject("but_ok.Image")));
            this.but_ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_ok.Location = new System.Drawing.Point(305, 191);
            this.but_ok.Name = "but_ok";
            this.but_ok.Size = new System.Drawing.Size(99, 32);
            this.but_ok.TabIndex = 7;
            this.but_ok.Text = "注册";
            this.but_ok.UseVisualStyleBackColor = true;
            this.but_ok.Click += new System.EventHandler(this.but_ok_Click);
            // 
            // but_close
            // 
            this.but_close.DialogResult = System.Windows.Forms.DialogResult.No;
            this.but_close.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_close.Image = ((System.Drawing.Image)(resources.GetObject("but_close.Image")));
            this.but_close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_close.Location = new System.Drawing.Point(501, 191);
            this.but_close.Name = "but_close";
            this.but_close.Size = new System.Drawing.Size(100, 32);
            this.but_close.TabIndex = 8;
            this.but_close.Text = "关闭";
            this.but_close.UseVisualStyleBackColor = true;
            this.but_close.Click += new System.EventHandler(this.but_close_Click);
            // 
            // frmRegstr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(624, 252);
            this.ControlBox = false;
            this.Controls.Add(this.but_close);
            this.Controls.Add(this.but_ok);
            this.Controls.Add(this.tbox_res);
            this.Controls.Add(this.tbox_key2);
            this.Controls.Add(this.tbox_key1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegstr";
            this.Text = "软件注册";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbox_key1;
        private System.Windows.Forms.TextBox tbox_key2;
        private System.Windows.Forms.TextBox tbox_res;
        private System.Windows.Forms.Button but_ok;
        private System.Windows.Forms.Button but_close;
    }
}

