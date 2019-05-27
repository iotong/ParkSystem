using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using Aptech.UI;
using DevComponents.DotNetBar;
using Newtonsoft.Json.Linq;
using ChargeWin.WebCarTypeInfo;
using ChargeWin.WebClearInfo;
using ChargeWin.WebOperatorInfo;
using ChargeWin.WebStandardInfo;
using ChargeWin.WebWorkInfo;
using www.gzwulian.com;
using www.gzwulian.com.BLL;
using www.gzwulian.com.Common;
using www.gzwulian.com.Model;
using Settlement = www.gzwulian.com.Model.Settlement;
using Newtonsoft.Json;
using System.IO;
using ChargeWin;
using ChargeWin;

namespace ChargeWin
{
    public partial class frmMain : Form
    {

        Aptech.UI.SbGroup SbGroup = new Aptech.UI.SbGroup();
        www.gzwulian.com.Model.RightsGroup rightsGroupModel=new RightsGroup();
        private www.gzwulian.com.BLL.RightsGroupManager rightsGroupBLL = new RightsGroupManager();
        www.gzwulian.com.BLL.MenuManager menuBLL=new MenuManager();
        private www.gzwulian.com.Model.Menu parentmenuModel = new www.gzwulian.com.Model.Menu();
        private www.gzwulian.com.Model.Menu menuModel = new www.gzwulian.com.Model.Menu();
        List<www.gzwulian.com.Model.Menu> menuModelList = new List<www.gzwulian.com.Model.Menu>();
        private ZXJK frmzxjk;
       // private frmEquipConfig eqconfig;
        string companyCode;
        public static bool strcarData=true;
        public static bool strchargData = true;
        public static bool strHandOff = true;


        private www.gzwulian.com.Model.Operator operatorModel = null;
        private OperatorManager operatorBLL = new OperatorManager();
        private www.gzwulian.com.Model.Company comModel = null;
        private CompanyManager comBLL=new CompanyManager();
        private INIMag iniinfo;
        private string configpath = Application.StartupPath + "\\Config\\SysCon.ini";
        private string rkImage,ckImage,threeImage,fourImage;
        public frmMain()
        {
            InitializeComponent();
            //清空默认的Tab
            NavTabControl.Tabs.Clear();
        }
        private string _user;
        private string _loginname;

        AutoSizeFormClass AutoSizeFrom = new AutoSizeFormClass();
        public string LoginName
        {
            set
            {
                this._loginname = value;
            }

        }

        public string User
        {
            set
            {
                this._user = value;

            }


        }

       
        private void frmMain_Load(object sender, EventArgs e)
        {


            frmFirst frmfist = new frmFirst();
            CreateTab(frmfist, "首页");
            iniinfo = new INIMag(GlobalInfo.Instance.ConfigPath);
            //  AutoSizeFrom.controllInitializeSize(this);
            SetEnable();
            InitBar();
            Init();
            InitDelData();
           
            //如果充许车辆信息下载，则开启线程
            if (iniinfo.CarinfoUpload == "True")
            {
                
                ThreadPool.QueueUserWorkItem(new WaitCallback(GetCarOverTime));
                timerCunt.Start();
            }

            //Thread th = new Thread(new ThreadStart(this.InitBar));
            //th.IsBackground = true;
            //th.Start();
        }

        private void InitDelData()
        {
            iniinfo = new INIMag(GlobalInfo.Instance.ConfigPath);
            int delDay = iniinfo.DeleteDay;
            if(delDay>=0)
            {
               ClearSqlData(delDay.ToString());
               DeleteImg(delDay);
              
            }
        }

        private void Init()
        {
            INIFile ini = new INIFile(configpath);
            string oneIp = ini.IniReadValue("EquipOneSet", "EquipIp");
            string twoIp = ini.IniReadValue("EquipTwoSet", "EquipIp");
            string threeIp = ini.IniReadValue("EquipThreeSet", "EquipIp");
            string fourIp = ini.IniReadValue("EquipFourSet", "EquipIp");
            if (!string.IsNullOrWhiteSpace(oneIp))
            {
                rkImage = ini.IniReadValue("EquipOneSet", "ImagePath"); //出口图片路径
            }
            if (!string.IsNullOrWhiteSpace(twoIp))
            {
                ckImage = ini.IniReadValue("EquipTwoSet", "ImagePath"); //出口图片路径
            }
            if (!string.IsNullOrWhiteSpace(threeIp))
            {
                threeImage = ini.IniReadValue("EquipThreeSet", "ImagePath"); //出口图片路径
            }
            if (!string.IsNullOrWhiteSpace(fourIp))
            {
                fourImage = ini.IniReadValue("EquipFourSet", "ImagePath"); //出口图片路径
            }
        }
       

        private www.gzwulian.com.BLL.SettlementManager settlementBLL = new SettlementManager();
  
       
        public void DeleteImg(int deleteday)
        {
        
            if (Directory.Exists(rkImage) && Directory.Exists(ckImage))
            {
                if (!string.IsNullOrEmpty(rkImage)) { DeletePlateImg(rkImage, deleteday);}
                if (!string.IsNullOrEmpty(ckImage)) { DeletePlateImg(ckImage, deleteday);}
                if (!string.IsNullOrEmpty(threeImage)) { DeletePlateImg(threeImage, deleteday);}
                if (!string.IsNullOrEmpty(fourImage)) { DeletePlateImg(fourImage, deleteday);}
               
                
            }
        }

        /// <summary>
        /// 删除除车牌图片
        /// </summary>
        /// <param name="path">图片路径</param>
        /// <param name="day">删除几天前的所有图片</param>
        public void DeletePlateImg(string path, int day)
        {

            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] files = di.GetFiles();
            foreach (FileInfo fi in files)
            {
                DateTime creattime = fi.CreationTime;
                DateTime deletetime = DateTime.Now.AddDays(-day);
                if (creattime < deletetime)
                {
                    fi.Delete();
                }
            }
        }


        public bool ClearSqlData(string strDay)
        {
            try {
             //清除固定车辆记录
             //   fCustomerBLL.DelWhere(strDay);
            //清除上下班记录
               settlementBLL.DelWhere(strDay);
            //清除进出场记录
               identifyInfoBLL.DelWhere(strDay);
            //清除固定车辆进出入记录
              fInOutBLL.DelWhere(strDay);
            //清除收费记录
              chargeBLL.DelWhere(strDay);
            //清除日志
              chargeBLL.DelLog();


                return true;
            }
            catch
            {
                return false;

            }



        }

        ParkInfoManager parkBLL=new ParkInfoManager();
        /// <summary>
        /// 添加停车场信息到服务端
        /// </summary>
    
        private WebFCustomerInfo.FCustomerInfo webCustomerBLL = new WebFCustomerInfo.FCustomerInfo();
        private FCustomerManager fCustomerBLL = new FCustomerManager();
   
   
        /// <summary>
        /// 设置工具是否可用
        /// </summary>
        public  void SetEnable()
        {
            int id = LoginInfo.GroupId;
            rightsGroupModel = rightsGroupBLL.GetModel(id);
            string groupRightsList = rightsGroupModel.GroupRightsList;
            if (!groupRightsList.Contains(",9"))
            {
                tsbtnForegrounding.Enabled = false;
            }
            else
            {
                tsbtnForegrounding.Enabled = true;
            }
            if (!groupRightsList.Contains("12"))
            {
                tsmiBookManage.Enabled = false;
            }
            else
            {
                tsmiBookManage.Enabled = true;

            }
            if (!groupRightsList.Contains("19"))
            {
                tsmiCashierManage.Enabled = false;
            }
            else
            {
                tsmiCashierManage.Enabled = true;

            }
            if (!groupRightsList.Contains(",8"))
            {
                strcarData = false; 
            }
            else
            {

                strcarData = true;

            }
            if (!groupRightsList.Contains(",17"))
            {
                strchargData = false; 
            }
            else
            {
                strchargData = true;

            }
         
        }

        public void InitBar()
        {
            sideBar1.Groups.Clear();
            int id =LoginInfo.GroupId;
            rightsGroupModel = rightsGroupBLL.GetModel(id);
            string groupRightsList = rightsGroupModel.GroupRightsList;
            if (groupRightsList.ToString() != null)
            {
                string[] menuGroulist = groupRightsList.Split(';');
                //子菜单id列表
                List<int> menulist = new List<int>();
                //父菜单id列表
                List<int> parentList = new List<int>();
                //for (int i = 0; i < menuGroulist.Length; i++)
                //{
                //    string[] ids = menuGroulist[i].Split(',');

                //}

                for (int i = 0; i < menuGroulist.Length ; i++)
                {
                    string[] ids = menuGroulist[i].Split(',');
                    //parentList.Add(int.Parse(ids[0]));
                    int parentId = int.Parse(ids[0]);
                    string parentMenuName = menuBLL.GetModel(int.Parse(ids[0])).Name;
                    this.sideBar1.AddGroup(parentMenuName);
                    for (int j = 1; j < ids.Length; j++)
                    {
                        //menulist.Add(int.Parse(ids[j]));
                        www.gzwulian.com.Model.Menu menu = menuBLL.GetModel(int.Parse(ids[j]));
                        this.sideBar1.Groups[i].Items.Add(menu.Name, menu.IconIndex ?? 0);
                       
                    }
                }
                this.InitStatusInfo();//加载状态栏
                //if(iniinfo.CarinfoUpload=="True")
                //{ 
                //   UploadData();// 上传信息到服务器
                //}
                //Thread.CurrentThread.Abort();
            }
        }

        private www.gzwulian.com.Model.Menu GetMenuByName(string name)
        {
            List<www.gzwulian.com.Model.Menu> menuModelList = new List<www.gzwulian.com.Model.Menu>();
            menuModel = menuBLL.GetModelList("Name=" + "'" + name + "'").First();
            return menuModel;
        }

        private List<www.gzwulian.com.Model.Menu> GetChildMenuByParentId(int id)
        {
          
            menuModelList = menuBLL.GetModelList("ParentId=" + id);
            return menuModelList;

        }

        private void IniBar()
        {
            #region
            this.sideBar1.AllowDrop = true;
            //this.sideBar1.ForeColor =System.Drawing.Color.DodgerBlue;
            this.sideBar1.AddGroup("系统设置");
            SbGroup.Text = "固定车辆管理";
            this.sideBar1.AddGroup(SbGroup);
            this.sideBar1.AddGroup("临停车辆管理");
            this.sideBar1.AddGroup("设备管理");
            this.sideBar1.AddGroup("统计报表");
            this.sideBar1.AddGroup("权限管理");
            this.sideBar1.AddGroup("帮助");

            //系统设置
            this.sideBar1.Groups[0].Items.Add("单位设置",42);
            this.sideBar1.Groups[0].Items.Add("车场设置",37);
            this.sideBar1.Groups[0].Items.Add("修改密码",38);
            this.sideBar1.Groups[0].Items.Add("系统注销",43);
            this.sideBar1.Groups[0].Items.Add("系统退出",4);

            //固定车辆管理
            this.sideBar1.Groups[1].Items.Add("车辆档案管理", 1);
            this.sideBar1.Groups[1].Items.Add("停车期限管理", 27);

            //临停车管理 
            this.sideBar1.Groups[2].Items.Add("收费设置", 30);
            this.sideBar1.Groups[2].Items.Add("在线管理", 28);
            //设备管理
            this.sideBar1.Groups[3].Items.Add("设备管理", 16);
            this.sideBar1.Groups[3].Items.Add("参数设置", 24);
          //  this.sideBar1.Groups[3].Items.Add("显示屏语音", 16);
            //统计报表
            this.sideBar1.Groups[4].Items.Add("固定车辆统计", 44);
            this.sideBar1.Groups[4].Items.Add("临停车辆统计", 45);
            this.sideBar1.Groups[4].Items.Add("车辆进出入记录",22);
            this.sideBar1.Groups[4].Items.Add("收费记录", 44);

            //权限管理
            this.sideBar1.Groups[5].Items.Add("用户管理", 32);
            this.sideBar1.Groups[5].Items.Add("角色管理", 33);
            //帮助
            this.sideBar1.Groups[6].Items.Add("使用说明", 36);
            this.sideBar1.Groups[6].Items.Add("关于我们", 35);
         
            this.RightToLeftLayout = true;
            #endregion
            this.InitStatusInfo();//加载状态栏
        
        }


        private void InitStatusInfo()
        {
            operatorModel = operatorBLL.GetModel(LoginInfo.Id);
            companyCode = operatorModel.CompanyCode;
            comModel=new www.gzwulian.com.Model.Company();
            comModel = comBLL.GetModel(companyCode);
            statusInfo.Items[0].Text=null;
            statusInfo.Items[2].Text = null;
            statusInfo.Items[3].Text = null;
            statusInfo.Items[0].Text = "当前系统操作员：" + LoginInfo.LoginName;
            if (comModel != null)
            {
                statusInfo.Items[2].Text = "公司名称: " + comModel.Name;
                statusInfo.Items[3].Text = "公司地址：" + comModel.Address;
            }
          
            timer.Start();
        }
         
        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdatePwd frmpwd = new frmUpdatePwd();
            frmpwd.ShowDialog();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.statusInfo.Items[1].Text = DateTime.Now.ToString();

        }  
          
        private void menu_Emp_depart_Click(object sender, EventArgs e)
        {
            //PersonnelSys.Form_DepartmentList depart = new FinanceSys.PersonnelSys.Form_DepartmentList();
           
            //depart.ShowDialog();
        }

        private void meun_emp_emp_Click(object sender, EventArgs e)
        {
            //FinanceSys.PersonnelSys.Form_EmployeeList emp = new FinanceSys.PersonnelSys.Form_EmployeeList();
           
            //emp.ShowDialog();
        }

        private void Menu_Sys_AppRestart_Click(object sender, EventArgs e)
        {
            if (MessageHelper.ConfirmYesNo("您确定要注销系统？"))
                Application.Restart();
        }

        private void Menu_Exit_Exit_Click(object sender, EventArgs e)
        {
            if (MessageHelper.ConfirmYesNo("您确定要退出系统？"))
            {
                Process pro = Process.GetCurrentProcess();
                if (pro != null)
                    pro.Kill();
            }
        }

        private void Menu_Tool_Notepad_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe");
        }

        private void Menu_Tool_Calc_Click(object sender, EventArgs e)
        {
            Process.Start("calc.exe");
        }

        public void CreateTab(Form form, string caption)
        {
            bool IsOpened = false;

            //遍历现有的Tab页面，如果存在，那么设置为选中即可
            foreach (SuperTabItem tabitem in NavTabControl.Tabs)
            {
                if (tabitem.Name == caption)
                {
                    NavTabControl.SelectedTab = tabitem;
                    IsOpened = true;
                    break;
                }
            }

            //如果在现有Tab页面中没有找到，那么就要初始化了Tab页面了
            if (!IsOpened)
            {
                SuperTabItem tabItem = NavTabControl.CreateTab(caption);
                if (caption=="首页")
                {
                    tabItem.CloseButtonVisible = false;
                }        
                tabItem.Name = caption;
                tabItem.Text = caption;
                form.FormBorderStyle = FormBorderStyle.None;
                form.TopLevel = false;
                form.Visible = true;
                form.Dock = DockStyle.Fill;
                //tabItem.Icon = form.Icon;
                tabItem.AttachedControl.Controls.Add(form);
                NavTabControl.SelectedTab = tabItem;
            }

        }
        private void lbl_Account_MouseEnter(object sender, EventArgs e)
        {
            Label lbl = new Label();
            lbl.BackColor = Color.LimeGreen;
        }

        private void sideBar1_ItemClick(Aptech.UI.SbItemEventArgs e)
        {
            switch (sideBar1.SeletedItem.Text)
            {
                case "车辆档案管理":
                    frmFCustomer frmfcustomer = new frmFCustomer();
                    CreateTab(frmfcustomer, "车辆档案管理");
                    break;
                case "车辆期限管理":
                     frmLimitMag frmlimtmag = new frmLimitMag();
                     CreateTab(frmlimtmag, "车辆期限管理");
                    break;
                case "收费设置":
                    frmChargeSet frmchargeset=new frmChargeSet();
                    CreateTab(frmchargeset,"收费设置");
                    break;
                case "上下班记录":
                    frmWorkRecord frmwork = new frmWorkRecord();
                    CreateTab(frmwork, "上下班记录");
                    break;
                case "设备配置":
                 frmEquipConfig frmequipconfig=new frmEquipConfig();
                 CreateTab(frmequipconfig, "设备管理");
                    break;
                case "在线监控":
 
                    if (frmzxjk == null)
                    {
                        frmzxjk =  new ZXJK();
                    }
                  //  Close();
                    frmzxjk.ShowDialog();
                    if (frmzxjk.DialogResult == DialogResult.OK)
                    {
                        SetEnable();
                        InitBar();
                    }

                    break;
                case "角色管理":
                    frmSetRights frmrights = new frmSetRights(LoginInfo.GroupId);
                    CreateTab(frmrights, "角色管理");
                    break;
                case "停车期限管理":
                    frmLimitMag frmlimit = new frmLimitMag();
                    CreateTab(frmlimit, "期限管理");
                    break;
                case "参数设置":
                    frmConfig frmconfig=new frmConfig();
                    frmconfig.ShowDialog();
                    break;
                //case "显示屏语音":
                //    frmSpeechPlay frmSpeechPlay = new frmSpeechPlay();
                //    CreateTab(frmSpeechPlay, "显示屏语音");
                //    break;
                case "系统退出":
                    if (frmzxjk!=null)
                    {
                        if (LoginInfo.isSettle)
                        {
                            MessageHelper.ShowTips("请下班结算后再退出系统！");
                        }
                        //if (frmzxjk.btnOffWork.Text == "下班结算")
                        //{
                        //    MessageHelper.ShowTips("请下班结算后再退出系统！");
                        //}
                        else
                        {
                            if (MessageHelper.ConfirmYesNo("您确定要退出系统？"))
                            {
                                Process pro = Process.GetCurrentProcess();
                                if (pro != null)
                                    pro.Kill();
                            }
                        }
                    }
                    else
                    {
                        if (MessageHelper.ConfirmYesNo("您确定要退出系统？"))
                        {
                            Process pro = Process.GetCurrentProcess();
                            if (pro != null)
                                pro.Kill();
                        }
                    }
                    break;
                case "系统注销":
                    if (frmzxjk != null)
                    {
                        if (LoginInfo.isSettle)
                        {
                            MessageHelper.ShowTips("请下班结算后再注销系统！");
                        }
                        //if (frmzxjk.btnOffWork.Text == "下班结算")
                        //{
                        //    MessageHelper.ShowTips("请下班结算后再注销系统！");
                        //}
                        else
                        {
                            if (MessageHelper.ConfirmYesNo("您确定要注销系统？"))
                                Application.Restart();
                        }
                        
                    }
                    else
                    {
                        if (MessageHelper.ConfirmYesNo("您确定要注销系统？"))
                            Application.Restart();
                    }
                  
                    break;
                case "修改密码":
                   frmUpdatePwd frmupdatepwd= new frmUpdatePwd();
                   frmupdatepwd.ShowDialog();
                    break;
                case "数据备份":
                    frmBackup frmback=new frmBackup();
                    frmback.ShowDialog();
                    break;
                    
                case "用户管理":
                   frmOperatorMag frmoperator=new frmOperatorMag();
                    CreateTab(frmoperator,"用户管理");
                    break;
                case "使用说明":
                    //frmOperation frmoperation=new frmOperation();
                    //frmoperation.ShowDialog();
                    break;
                case "关于我们":
                    frmAboutUs frmabout = new frmAboutUs();
                    frmabout.ShowDialog();
                    break;
                case "车场设置":
                    operatorModel = operatorBLL.GetModel(LoginInfo.Id);
                    companyCode = operatorModel.CompanyCode;
                    comModel = comBLL.GetModel(companyCode);
                    if (comModel==null)
                    {
                        MessageHelper.ShowTips("请添加经营单位后，再进行操作！");
                        return;
                    }
                    frmParking frmpark=new frmParking();
                    CreateTab(frmpark,"车场设置");
                    break;
                case "密码修改":
                    frmUpdatePwd frmpwd = new frmUpdatePwd();
                    frmpwd.ShowDialog();
                    break;
                case "临停车辆统计":
                   frmStatistics frmstatistics=new frmStatistics();
                   CreateTab(frmstatistics, "临停车辆统计");
                    break;
                case "单位设置":
                    frmCompany frmcompany=new frmCompany();
                    frmcompany.Owner = this;
                    CreateTab(frmcompany, "单位设置");
                    break;
                case "车辆进出记录":
                    frmFInOutInfo frminoutinfo = new frmFInOutInfo();
                    CreateTab(frminoutinfo,"车辆进出记录");
                    break;
                case "收费记录":
                    frmChargeInfo frmcharge = new frmChargeInfo();
                    CreateTab(frmcharge, "收费记录");
                    break;
                case "清除数据":
                    frmDataClear frmdataclear = new frmDataClear();
                    frmdataclear.ShowDialog();
                   // CreateTab(frmcharge, "收费记录");


                    //try
                    //{
                    //    if (MessageHelper.ConfirmYesNo("确定要清除数据吗？"))
                    //    {
                    //        ClearInfo();
                    //        MessageHelper.ShowTips("数据清除成功！");
                    //    }
                    //}
                    //catch (Exception)
                    //{
                    //    MessageHelper.ShowTips("数据清除失败！");
                    //}
                    break;
                default:
                    break;

            }
        }
   
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ((BackgroundWorker)sender).Dispose();
        }


        private void tsbtnForegrounding_Click(object sender, EventArgs e)
        {
            frmLimitMag frmlimit = new frmLimitMag();
            frmlimit.Owner = this;
            CreateTab(frmlimit, "有效期管理");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Process.Start("calc.exe");
        }

        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            if (frmzxjk != null)
            {
                if (LoginInfo.isSettle)
                {
                    MessageHelper.ShowTips("请下班结算后再退出系统！");
                }
                //if (frmzxjk.btnOffWork.Text == "下班结算")
                //{
                //    MessageHelper.ShowTips("请下班结算后再退出系统！");
                //}
                else
                {
                    Application.Exit();
                }
                
            }
            else
            {
                Application.Exit();
            }
          
        }

        private void tsmiBookManage_Click(object sender, EventArgs e)
        {
            if (frmzxjk == null)
            {
                frmzxjk = new ZXJK();
            }
            else
            {
               // frmzxjk.OpenSerialPort();
            }
            frmzxjk.Owner = this;
            frmzxjk.ShowDialog();
            if (frmzxjk.DialogResult == DialogResult.OK)
            {
                SetEnable();
                InitBar();

            }
        //    frmzxjk.CloseSerialPort();
         //   frmzxjk.CloseSocket();
        }

        private void tsmiCashierManage_Click(object sender, EventArgs e)
        {
            frmFInOutInfo frminoutinfo = new frmFInOutInfo();
            CreateTab(frminoutinfo, "车辆进出记录");
        }


        private void 关闭所有窗体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAll();
        }
        /// <summary>
        /// 关闭所有页面
        /// </summary>
        public void CloseAll()
        {
            for (int i = NavTabControl.Tabs.Count - 1; i >= 0; i--)
            {
                SuperTabItem tabitem = NavTabControl.Tabs[i] as SuperTabItem;
                if (tabitem != null&&tabitem.Name!="首页")
                {
                    tabitem.Close();
                }
            }
        }

        /// <summary>
        /// 关闭当前窗体
        /// </summary>
        public void CloseWin()
        {
            for (int i = NavTabControl.Tabs.Count - 1; i >= 0; i--)
            {
                SuperTabItem tabitem = NavTabControl.Tabs[i] as SuperTabItem;
                if (tabitem != null && tabitem == NavTabControl.SelectedTab&&tabitem.Name!="首页")
                {
                    tabitem.Close();
                }
            }
        }

        private void 关闭除此之外的窗体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = NavTabControl.Tabs.Count - 1; i >= 0; i--)
            {
                SuperTabItem tabitem = NavTabControl.Tabs[i] as SuperTabItem;
                if (tabitem != null && tabitem != NavTabControl.SelectedTab && tabitem.Name != "首页")
                {
                    tabitem.Close();
                }
            }
        }

        private void 单位管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCompany frmcompany = new frmCompany();
            CreateTab(frmcompany,"单位设置");
        }

        private void 设备管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEquipConfig frmconfig=new frmEquipConfig();
            CreateTab(frmconfig,"设备管理");
            //frmconfig.ShowDialog();
        }

        private void 在线管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           //frmZXJK frmzxjk=new frmZXJK();
           // CreateTab(frmzxjk,"在线监控");
        }

        private void 车场管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmParking frmpark=new frmParking();
            CreateTab(frmpark,"车场设置");
        }

        private void 车辆档案管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFCustomer frmfcustomer=new frmFCustomer();
            CreateTab(frmfcustomer,"车辆档案管理");
        }

        private void 收费设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChargeSet frmcharge = new frmChargeSet();
            CreateTab(frmcharge, "收费设置");
        }

        private void 有效期管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLimitMag frmlimit=new frmLimitMag();
            CreateTab(frmlimit,"有效期管理");
        }

        private void 用户管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmOperatorMag frmoperator=new frmOperatorMag();
            CreateTab(frmoperator,"用户管理");
        }

        private void 车辆进出记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWorkRecord frminout=new frmWorkRecord();
            CreateTab(frminout, "车辆进出记录");
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private www.gzwulian.com.BLL.PlateIdentifyInfoManager identifyInfoBLL = new PlateIdentifyInfoManager();
        private www.gzwulian.com.BLL.FInOutInfoManager fInOutBLL = new FInOutInfoManager();
        private www.gzwulian.com.BLL.ChargeRecordManager chargeBLL = new ChargeRecordManager();
        /// <summary>
        /// 清除测试数据
        /// </summary>
      

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frmzxjk != null)
            {
                if (LoginInfo.isSettle)
                {
                    MessageHelper.ShowTips("请下班结算后再退出系统！");
                    e.Cancel = true;
                }
                //if (frmzxjk.btnOffWork.Text == "下班结算")
                //{
                //    MessageHelper.ShowTips("请下班结算后再退出系统！");
                //    e.Cancel = true;
                //}
                else
                {
                    Application.ExitThread();
                }

            }
            else
            {
                Application.ExitThread();
            }
        }



        private void timerCunt_Tick(object sender, EventArgs e)
        {
            //if (iniinfo.CarinfoUpload == "True")
            //{
                timerCunt.Enabled = true;
                timerCunt.Interval = 3000;
            //    ThreadPool.QueueUserWorkItem(new WaitCallback(GetCarOverTime));
            //    GetCarOverTime();
            //}
        }

        public void GetCarOverTime(object state)
        {
            string values = "";
            string CompanyCode = LoginInfo.CompanyCode;
            string parkId = LoginInfo.ParkId;
            string value = CompanyCode + ":" + parkId;
            try
            {
                System.Net.WebClient wclient = new System.Net.WebClient();
                wclient.Encoding = System.Text.Encoding.UTF8;


                while (true)
                {
                    string list = string.Empty;
                    string pagestr = "0";
                    pagestr = wclient.UploadString("http://zst.gzwulian.com/ClientService/HttpRequest/GetPageCount.ashx?paraStr=" + value, " ");
                    int pagecount = int.Parse(pagestr);
                    if (pagecount > 0)
                    {
                        for (int i = 1; i < pagecount + 1; i++)
                        {

                            list = wclient.UploadString("http://zst.gzwulian.com/ClientService/HttpRequest/GetCarOverTime.ashx?paraStr=" + value + ":" + i, " ");
                            if (list.Length > 5)//有数据需要更新
                            {
                                List<CarInfo> carInfo = JsonConvert.DeserializeObject<List<CarInfo>>(list);
                                foreach (var c in carInfo)
                                {
                                    var Fcustomer = fCustomerBLL.GetModelList("PlateId='" + c.PlateId + "'and CompanyCode='" + c.CompanyCode + "' and Enable=1").FirstOrDefault();
                                    if (Fcustomer != null)
                                    {
                                        Fcustomer.OverTime = c.OverTime;
                                        fCustomerBLL.Update(Fcustomer);
                                        values = values + c.Id + ",";
                                    }
                                    else
                                    {
                                        FCustomer fc = new FCustomer();
                                        fc.PlateId = c.PlateId;
                                        fc.PlateColor = c.PlateColor;
                                        fc.ParkId = c.ParkID;
                                        fc.Name = c.UserName;
                                        fc.Telphone = c.Tel;
                                        fc.AddTime = c.AddTime;
                                        fc.CreateTime = c.CreateTime;
                                        fc.OverTime = c.OverTime;
                                        fc.CompanyCode = c.CompanyCode;
                                        if (c.Enable == "True")
                                        {
                                            fc.Enable = true;
                                        }
                                        else
                                        {
                                            fc.Enable = false;
                                        }
                                        fc.CarType = c.CarType;
                                        fc.IsUpload = true;
                                        fCustomerBLL.Add(fc);
                                        values = values + c.Id + ",";
                                    }
                                }
                                wclient.UploadString("http://zst.gzwulian.com/ClientService/HttpRequest/UploadCarInfo.ashx?paraStr=" + values, "");
                            }
                        }
                    }
                    Thread.Sleep(3000);
                }


            }
            catch (Exception e)
            {

            }
           
        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
          //  AutoSizeFrom.controlAutoSize(this);
        }
    }
}
