using System;

namespace ChargeWin
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.statusInfo = new System.Windows.Forms.StatusStrip();
            this.stalUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.stalTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.stalConpany = new System.Windows.Forms.ToolStripStatusLabel();
            this.stalAddress = new System.Windows.Forms.ToolStripStatusLabel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.NavTabControl = new DevComponents.DotNetBar.SuperTabControl();
            this.tabMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.关闭所有窗体ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭除此之外的窗体ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.superTabItem2 = new DevComponents.DotNetBar.SuperTabItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sideBar1 = new Aptech.UI.SideBar();
            this.tsOper = new System.Windows.Forms.ToolStrip();
            this.tsbtnForegrounding = new System.Windows.Forms.ToolStripButton();
            this.tsmiBookManage = new System.Windows.Forms.ToolStripButton();
            this.tsmiCashierManage = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tsbtnExit = new System.Windows.Forms.ToolStripButton();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.superTabItem1 = new DevComponents.DotNetBar.SuperTabItem();
            this.timerCunt = new System.Windows.Forms.Timer(this.components);
            this.statusInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NavTabControl)).BeginInit();
            this.NavTabControl.SuspendLayout();
            this.tabMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tsOper.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusInfo
            // 
            this.statusInfo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.statusInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stalUser,
            this.stalTime,
            this.stalConpany,
            this.stalAddress});
            this.statusInfo.Location = new System.Drawing.Point(0, 711);
            this.statusInfo.Name = "statusInfo";
            this.statusInfo.Size = new System.Drawing.Size(1018, 22);
            this.statusInfo.TabIndex = 1;
            this.statusInfo.Text = "statusStrip1";
            // 
            // stalUser
            // 
            this.stalUser.AutoSize = false;
            this.stalUser.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.stalUser.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.stalUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.stalUser.Name = "stalUser";
            this.stalUser.Size = new System.Drawing.Size(177, 17);
            this.stalUser.Text = "                            ";
            // 
            // stalTime
            // 
            this.stalTime.AutoSize = false;
            this.stalTime.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.stalTime.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.stalTime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.stalTime.Name = "stalTime";
            this.stalTime.Size = new System.Drawing.Size(190, 17);
            // 
            // stalConpany
            // 
            this.stalConpany.AutoSize = false;
            this.stalConpany.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.stalConpany.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.stalConpany.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.stalConpany.Name = "stalConpany";
            this.stalConpany.Size = new System.Drawing.Size(200, 17);
            this.stalConpany.Text = "单位名称";
            // 
            // stalAddress
            // 
            this.stalAddress.AutoSize = false;
            this.stalAddress.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.stalAddress.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.stalAddress.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.stalAddress.Name = "stalAddress";
            this.stalAddress.Size = new System.Drawing.Size(436, 17);
            this.stalAddress.Spring = true;
            this.stalAddress.Text = "公司地址";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "button18.Image.gif");
            this.imageList1.Images.SetKeyName(1, "button48.Image.gif");
            this.imageList1.Images.SetKeyName(2, "button44.Image.gif");
            this.imageList1.Images.SetKeyName(3, "注销.png");
            this.imageList1.Images.SetKeyName(4, "Exit1.png");
            this.imageList1.Images.SetKeyName(5, "user-remove.png");
            this.imageList1.Images.SetKeyName(6, "button37.Image.gif");
            this.imageList1.Images.SetKeyName(7, "button29.Image.gif");
            this.imageList1.Images.SetKeyName(8, "table.png");
            this.imageList1.Images.SetKeyName(9, "button26.Image.gif");
            this.imageList1.Images.SetKeyName(10, "button25.Image.gif");
            this.imageList1.Images.SetKeyName(11, "button90.Image.gif");
            this.imageList1.Images.SetKeyName(12, "button124.Image.bmp");
            this.imageList1.Images.SetKeyName(13, "button74.Image.gif");
            this.imageList1.Images.SetKeyName(14, "button18.Image.gif");
            this.imageList1.Images.SetKeyName(15, "button19.Image.gif");
            this.imageList1.Images.SetKeyName(16, "button17.Image.gif");
            this.imageList1.Images.SetKeyName(17, "button113.Image.gif");
            this.imageList1.Images.SetKeyName(18, "gif_47_003.gif");
            this.imageList1.Images.SetKeyName(19, "Monitor.png");
            this.imageList1.Images.SetKeyName(20, "admin.png");
            this.imageList1.Images.SetKeyName(21, "app_edit.png");
            this.imageList1.Images.SetKeyName(22, "app_largeicons.png");
            this.imageList1.Images.SetKeyName(23, "app_options.png");
            this.imageList1.Images.SetKeyName(24, "applications.png");
            this.imageList1.Images.SetKeyName(25, "block1.png");
            this.imageList1.Images.SetKeyName(26, "calculator.png");
            this.imageList1.Images.SetKeyName(27, "calendar.png");
            this.imageList1.Images.SetKeyName(28, "cam.png");
            this.imageList1.Images.SetKeyName(29, "chart.png");
            this.imageList1.Images.SetKeyName(30, "dollar.png");
            this.imageList1.Images.SetKeyName(31, "files_find.png");
            this.imageList1.Images.SetKeyName(32, "user.png");
            this.imageList1.Images.SetKeyName(33, "users.png");
            this.imageList1.Images.SetKeyName(34, "config.png");
            this.imageList1.Images.SetKeyName(35, "info.png");
            this.imageList1.Images.SetKeyName(36, "doc_info.png");
            this.imageList1.Images.SetKeyName(37, "car.png");
            this.imageList1.Images.SetKeyName(38, "key.png");
            this.imageList1.Images.SetKeyName(39, "saveas2.png");
            this.imageList1.Images.SetKeyName(40, "statistics3.png");
            this.imageList1.Images.SetKeyName(41, "statistics4.png");
            this.imageList1.Images.SetKeyName(42, "usergroup.png");
            this.imageList1.Images.SetKeyName(43, "unlock.png");
            this.imageList1.Images.SetKeyName(44, "statistics3.png");
            this.imageList1.Images.SetKeyName(45, "statistics4.png");
            this.imageList1.Images.SetKeyName(46, "set.gif");
            this.imageList1.Images.SetKeyName(47, "clear.gif");
            this.imageList1.Images.SetKeyName(48, "back.gif");
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelMain);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.tsOper);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1018, 711);
            this.panel1.TabIndex = 5;
            // 
            // panelMain
            // 
            this.panelMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelMain.BackgroundImage")));
            this.panelMain.Controls.Add(this.NavTabControl);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(170, 72);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(848, 639);
            this.panelMain.TabIndex = 5;
            // 
            // NavTabControl
            // 
            this.NavTabControl.BackColor = System.Drawing.Color.White;
            this.NavTabControl.CloseButtonOnTabsVisible = true;
            this.NavTabControl.ContextMenuStrip = this.tabMenu;
            // 
            // 
            // 
            // 
            // 
            // 
            this.NavTabControl.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.NavTabControl.ControlBox.MenuBox.Name = "";
            this.NavTabControl.ControlBox.Name = "";
            this.NavTabControl.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.NavTabControl.ControlBox.MenuBox,
            this.NavTabControl.ControlBox.CloseBox});
            this.NavTabControl.Controls.Add(this.superTabControlPanel2);
            this.NavTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NavTabControl.ForeColor = System.Drawing.Color.Black;
            this.NavTabControl.Location = new System.Drawing.Point(0, 0);
            this.NavTabControl.Name = "NavTabControl";
            this.NavTabControl.ReorderTabsEnabled = true;
            this.NavTabControl.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.NavTabControl.SelectedTabIndex = 0;
            this.NavTabControl.Size = new System.Drawing.Size(848, 639);
            this.NavTabControl.TabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NavTabControl.TabIndex = 0;
            this.NavTabControl.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem2});
            this.NavTabControl.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            this.NavTabControl.Text = "superTabControl1";
            // 
            // tabMenu
            // 
            this.tabMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关闭所有窗体ToolStripMenuItem,
            this.关闭除此之外的窗体ToolStripMenuItem});
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.Size = new System.Drawing.Size(185, 48);
            // 
            // 关闭所有窗体ToolStripMenuItem
            // 
            this.关闭所有窗体ToolStripMenuItem.Name = "关闭所有窗体ToolStripMenuItem";
            this.关闭所有窗体ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.关闭所有窗体ToolStripMenuItem.Text = "关闭所有窗体";
            this.关闭所有窗体ToolStripMenuItem.Click += new System.EventHandler(this.关闭所有窗体ToolStripMenuItem_Click);
            // 
            // 关闭除此之外的窗体ToolStripMenuItem
            // 
            this.关闭除此之外的窗体ToolStripMenuItem.Name = "关闭除此之外的窗体ToolStripMenuItem";
            this.关闭除此之外的窗体ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.关闭除此之外的窗体ToolStripMenuItem.Text = "关闭除此之外的窗体";
            this.关闭除此之外的窗体ToolStripMenuItem.Click += new System.EventHandler(this.关闭除此之外的窗体ToolStripMenuItem_Click);
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2000;
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 30);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(848, 609);
            this.superTabControlPanel2.TabIndex = 1;
            this.superTabControlPanel2.TabItem = this.superTabItem2;
            // 
            // superTabItem2
            // 
            this.superTabItem2.AttachedControl = this.superTabControlPanel2;
            this.superTabItem2.GlobalItem = false;
            this.superTabItem2.Name = "superTabItem2";
            this.superTabItem2.Text = "superTabItem2";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.sideBar1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(170, 639);
            this.panel2.TabIndex = 4;
            // 
            // sideBar1
            // 
            this.sideBar1.AllowDragItem = false;
            this.sideBar1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.sideBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sideBar1.FlatStyle = Aptech.UI.SbFlatStyle.Normal;
            this.sideBar1.GroupHeaderBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.sideBar1.GroupTextColor = System.Drawing.Color.Black;
            this.sideBar1.ImageList = this.imageList1;
            this.sideBar1.ItemContextMenuStrip = null;
            this.sideBar1.ItemStyle = Aptech.UI.SbItemStyle.PushButton;
            this.sideBar1.ItemTextColor = System.Drawing.SystemColors.MenuText;
            this.sideBar1.Location = new System.Drawing.Point(0, 0);
            this.sideBar1.Name = "sideBar1";
            this.sideBar1.RadioSelectedItem = null;
            this.sideBar1.Size = new System.Drawing.Size(170, 639);
            this.sideBar1.TabIndex = 4;
            this.sideBar1.View = Aptech.UI.SbView.LargeIcon;
            this.sideBar1.VisibleGroup = null;
            this.sideBar1.VisibleGroupIndex = -1;
            this.sideBar1.ItemClick += new Aptech.UI.SbItemEventHandler(this.sideBar1_ItemClick);
            // 
            // tsOper
            // 
            this.tsOper.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tsOper.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsOper.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnForegrounding,
            this.tsmiBookManage,
            this.tsmiCashierManage,
            this.toolStripButton1,
            this.tsbtnExit});
            this.tsOper.Location = new System.Drawing.Point(0, 0);
            this.tsOper.Name = "tsOper";
            this.tsOper.Size = new System.Drawing.Size(1018, 72);
            this.tsOper.TabIndex = 3;
            // 
            // tsbtnForegrounding
            // 
            this.tsbtnForegrounding.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnForegrounding.Image")));
            this.tsbtnForegrounding.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnForegrounding.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnForegrounding.Name = "tsbtnForegrounding";
            this.tsbtnForegrounding.Size = new System.Drawing.Size(90, 69);
            this.tsbtnForegrounding.Text = "有效期管理(&O)";
            this.tsbtnForegrounding.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnForegrounding.Click += new System.EventHandler(this.tsbtnForegrounding_Click);
            // 
            // tsmiBookManage
            // 
            this.tsmiBookManage.Image = ((System.Drawing.Image)(resources.GetObject("tsmiBookManage.Image")));
            this.tsmiBookManage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiBookManage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiBookManage.Name = "tsmiBookManage";
            this.tsmiBookManage.Size = new System.Drawing.Size(80, 69);
            this.tsmiBookManage.Text = "在线监控(&M)";
            this.tsmiBookManage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsmiBookManage.Click += new System.EventHandler(this.tsmiBookManage_Click);
            // 
            // tsmiCashierManage
            // 
            this.tsmiCashierManage.Image = ((System.Drawing.Image)(resources.GetObject("tsmiCashierManage.Image")));
            this.tsmiCashierManage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiCashierManage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiCashierManage.Name = "tsmiCashierManage";
            this.tsmiCashierManage.Size = new System.Drawing.Size(97, 69);
            this.tsmiCashierManage.Text = "车辆进出记录(&J)";
            this.tsmiCashierManage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsmiCashierManage.Click += new System.EventHandler(this.tsmiCashierManage_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(52, 69);
            this.toolStripButton1.Text = "计算器";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tsbtnExit
            // 
            this.tsbtnExit.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnExit.Image")));
            this.tsbtnExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnExit.Name = "tsbtnExit";
            this.tsbtnExit.Size = new System.Drawing.Size(55, 69);
            this.tsbtnExit.Text = "退 出(&E)";
            this.tsbtnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnExit.Click += new System.EventHandler(this.tsbtnExit_Click);
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 26);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(848, 583);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.superTabItem1;
            // 
            // superTabItem1
            // 
            this.superTabItem1.AttachedControl = this.superTabControlPanel1;
            this.superTabItem1.GlobalItem = false;
            this.superTabItem1.Name = "superTabItem1";
            this.superTabItem1.Text = "superTabItem1";
            // 
            // timerCunt
            // 
            this.timerCunt.Tick += new System.EventHandler(this.timerCunt_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1018, 733);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "智能停车场管理系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.SizeChanged += new System.EventHandler(this.frmMain_SizeChanged);
            this.statusInfo.ResumeLayout(false);
            this.statusInfo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NavTabControl)).EndInit();
            this.NavTabControl.ResumeLayout(false);
            this.tabMenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tsOper.ResumeLayout(false);
            this.tsOper.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.StatusStrip statusInfo;
        private System.Windows.Forms.ToolStripStatusLabel stalUser;
        private System.Windows.Forms.ToolStripStatusLabel stalTime;
        private System.Windows.Forms.ToolStripStatusLabel stalConpany;
        private System.Windows.Forms.ToolStripStatusLabel stalAddress;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip tsOper;
        private System.Windows.Forms.ToolStripButton tsbtnForegrounding;
        private System.Windows.Forms.ToolStripButton tsmiBookManage;
        private System.Windows.Forms.ToolStripButton tsmiCashierManage;
        private System.Windows.Forms.ToolStripButton tsbtnExit;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Panel panelMain;
        private DevComponents.DotNetBar.SuperTabControl NavTabControl;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private DevComponents.DotNetBar.SuperTabItem superTabItem2;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.SuperTabItem superTabItem1;
        private System.Windows.Forms.ContextMenuStrip tabMenu;
        private System.Windows.Forms.ToolStripMenuItem 关闭所有窗体ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭除此之外的窗体ToolStripMenuItem;
        private Aptech.UI.SideBar sideBar1;
        private System.Windows.Forms.Timer timerCunt;
    }
}