namespace ChargeWin
{
    partial class frmPointSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPointSelect));
            this.label1 = new System.Windows.Forms.Label();
            this.grpboxSelectPoint = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtLatitude = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLongitude = new System.Windows.Forms.TextBox();
            this.panelGIS = new System.Windows.Forms.Panel();
            this.wbrowserGIS = new System.Windows.Forms.WebBrowser();
            this.btnOK = new System.Windows.Forms.Button();
            this.grpboxSelectPoint.SuspendLayout();
            this.panelGIS.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前经度：";
            // 
            // grpboxSelectPoint
            // 
            this.grpboxSelectPoint.Controls.Add(this.btnRefresh);
            this.grpboxSelectPoint.Controls.Add(this.txtLatitude);
            this.grpboxSelectPoint.Controls.Add(this.label2);
            this.grpboxSelectPoint.Controls.Add(this.txtLongitude);
            this.grpboxSelectPoint.Controls.Add(this.label1);
            this.grpboxSelectPoint.Location = new System.Drawing.Point(3, 12);
            this.grpboxSelectPoint.Name = "grpboxSelectPoint";
            this.grpboxSelectPoint.Size = new System.Drawing.Size(561, 60);
            this.grpboxSelectPoint.TabIndex = 1;
            this.grpboxSelectPoint.TabStop = false;
            this.grpboxSelectPoint.Text = "当前选取的坐标";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(465, 19);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtLatitude
            // 
            this.txtLatitude.Enabled = false;
            this.txtLatitude.Location = new System.Drawing.Point(313, 20);
            this.txtLatitude.Name = "txtLatitude";
            this.txtLatitude.Size = new System.Drawing.Size(121, 21);
            this.txtLatitude.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "当前纬度：";
            // 
            // txtLongitude
            // 
            this.txtLongitude.Enabled = false;
            this.txtLongitude.Location = new System.Drawing.Point(89, 20);
            this.txtLongitude.Name = "txtLongitude";
            this.txtLongitude.Size = new System.Drawing.Size(121, 21);
            this.txtLongitude.TabIndex = 4;
            // 
            // panelGIS
            // 
            this.panelGIS.Controls.Add(this.wbrowserGIS);
            this.panelGIS.Location = new System.Drawing.Point(3, 78);
            this.panelGIS.Name = "panelGIS";
            this.panelGIS.Size = new System.Drawing.Size(561, 360);
            this.panelGIS.TabIndex = 2;
            // 
            // wbrowserGIS
            // 
            this.wbrowserGIS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbrowserGIS.Location = new System.Drawing.Point(0, 0);
            this.wbrowserGIS.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbrowserGIS.Name = "wbrowserGIS";
            this.wbrowserGIS.Size = new System.Drawing.Size(561, 360);
            this.wbrowserGIS.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(489, 444);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 32);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmPointSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 477);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.panelGIS);
            this.Controls.Add(this.grpboxSelectPoint);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(592, 515);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(592, 515);
            this.Name = "frmPointSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "经纬度坐标选取";
            this.Load += new System.EventHandler(this.frmPointSelect_Load);
            this.grpboxSelectPoint.ResumeLayout(false);
            this.grpboxSelectPoint.PerformLayout();
            this.panelGIS.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpboxSelectPoint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLatitude;
        private System.Windows.Forms.TextBox txtLongitude;
        private System.Windows.Forms.Panel panelGIS;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.WebBrowser wbrowserGIS;
        private System.Windows.Forms.Button btnRefresh;
    }
}