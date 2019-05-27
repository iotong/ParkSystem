namespace ChargeWin
{
    partial class Frmimgshow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmimgshow));
            this.pbl_tom = new System.Windows.Forms.Panel();
            this.close = new System.Windows.Forms.Button();
            this.pal_top = new System.Windows.Forms.Panel();
            this.pbox = new System.Windows.Forms.PictureBox();
            this.pbl_tom.SuspendLayout();
            this.pal_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox)).BeginInit();
            this.SuspendLayout();
            // 
            // pbl_tom
            // 
            this.pbl_tom.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pbl_tom.Controls.Add(this.close);
            this.pbl_tom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbl_tom.Location = new System.Drawing.Point(0, 726);
            this.pbl_tom.Name = "pbl_tom";
            this.pbl_tom.Size = new System.Drawing.Size(1024, 42);
            this.pbl_tom.TabIndex = 0;
            // 
            // close
            // 
            this.close.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.close.Image = ((System.Drawing.Image)(resources.GetObject("close.Image")));
            this.close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.close.Location = new System.Drawing.Point(905, 6);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(91, 28);
            this.close.TabIndex = 4;
            this.close.Text = "关闭";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // pal_top
            // 
            this.pal_top.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pal_top.Controls.Add(this.pbox);
            this.pal_top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pal_top.Location = new System.Drawing.Point(0, 0);
            this.pal_top.Name = "pal_top";
            this.pal_top.Size = new System.Drawing.Size(1024, 726);
            this.pal_top.TabIndex = 1;
            // 
            // pbox
            // 
            this.pbox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbox.Location = new System.Drawing.Point(0, 0);
            this.pbox.Name = "pbox";
            this.pbox.Size = new System.Drawing.Size(1020, 722);
            this.pbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox.TabIndex = 0;
            this.pbox.TabStop = false;
            this.pbox.DoubleClick += new System.EventHandler(this.close_Click);
            // 
            // Frmimgshow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.pal_top);
            this.Controls.Add(this.pbl_tom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frmimgshow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frmimgshow";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Frmimgshow_Load);
            this.pbl_tom.ResumeLayout(false);
            this.pal_top.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pbl_tom;
        private System.Windows.Forms.Panel pal_top;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.PictureBox pbox;
    }
}