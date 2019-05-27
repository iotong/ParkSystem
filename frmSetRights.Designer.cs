namespace ChargeWin
{
    partial class frmSetRights
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetRights));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddRole = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ucPageBar1 = new www.gzwulian.com.Common.ucPageBar();
            this.label1 = new System.Windows.Forms.Label();
            this.cbRoleList = new System.Windows.Forms.ComboBox();
            this.tvRightsList = new System.Windows.Forms.TreeView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnAddRole);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(618, 504);
            this.panel1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(78, 452);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 26);
            this.btnSave.TabIndex = 48;
            this.btnSave.Text = "  保存权限";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(316, 452);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(83, 26);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "   删除角色";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddRole
            // 
            this.btnAddRole.Image = ((System.Drawing.Image)(resources.GetObject("btnAddRole.Image")));
            this.btnAddRole.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddRole.Location = new System.Drawing.Point(202, 452);
            this.btnAddRole.Name = "btnAddRole";
            this.btnAddRole.Size = new System.Drawing.Size(83, 26);
            this.btnAddRole.TabIndex = 10;
            this.btnAddRole.Text = "   添加角色";
            this.btnAddRole.UseVisualStyleBackColor = true;
            this.btnAddRole.Click += new System.EventHandler(this.btnAddRole_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ucPageBar1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbRoleList);
            this.groupBox1.Controls.Add(this.tvRightsList);
            this.groupBox1.Location = new System.Drawing.Point(71, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 435);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "角色权限设置";
            // 
            // ucPageBar1
            // 
            this.ucPageBar1.CurrentPage = ((uint)(1u));
            this.ucPageBar1.Location = new System.Drawing.Point(369, 73);
            this.ucPageBar1.Name = "ucPageBar1";
            this.ucPageBar1.PageSize = ((uint)(10u));
            this.ucPageBar1.RecordCount = ((uint)(0u));
            this.ucPageBar1.Size = new System.Drawing.Size(489, 27);
            this.ucPageBar1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "角色名称";
            // 
            // cbRoleList
            // 
            this.cbRoleList.FormattingEnabled = true;
            this.cbRoleList.Location = new System.Drawing.Point(75, 29);
            this.cbRoleList.Name = "cbRoleList";
            this.cbRoleList.Size = new System.Drawing.Size(258, 20);
            this.cbRoleList.TabIndex = 2;
            this.cbRoleList.SelectedIndexChanged += new System.EventHandler(this.cbRoleList_SelectedIndexChanged);
            // 
            // tvRightsList
            // 
            this.tvRightsList.CheckBoxes = true;
            this.tvRightsList.Location = new System.Drawing.Point(18, 55);
            this.tvRightsList.Name = "tvRightsList";
            this.tvRightsList.Size = new System.Drawing.Size(315, 374);
            this.tvRightsList.TabIndex = 0;
            this.tvRightsList.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvRightsList_AfterCheck);
            // 
            // frmSetRights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 504);
            this.Controls.Add(this.panel1);
            this.Name = "frmSetRights";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置权限";
            this.Load += new System.EventHandler(this.frmSetRights_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddRole;
        private System.Windows.Forms.GroupBox groupBox1;
        private www.gzwulian.com.Common.ucPageBar ucPageBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbRoleList;
        private System.Windows.Forms.TreeView tvRightsList;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;

    }
}