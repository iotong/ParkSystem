using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using www.gzwulian.com.BLL;
using www.gzwulian.com.Common;
using www.gzwulian.com.Model;
using System.Net;
using System.Net.Sockets;

namespace ChargeWin
{
    public partial class ZXJK : Form
    {
        public ZXJK()
        {
            InitializeComponent();
        }

        private INIMag iniinfo;
        private PlateIdentifyInfo identifyInfoModel = null;
        private PlateIdentifyInfoManager inoutBLL = new PlateIdentifyInfoManager();
        private ChargeRecord chargeRecordModel = null;
        private ChargeRecordManager chargeRecordBLL = new ChargeRecordManager();
        private FInOutInfo fInOutInfoModel = null;
        private FInOutInfoManager fInOutInfoBLL = new FInOutInfoManager();
        private FCustomerManager fCustomerBLL = new FCustomerManager();
        private FCustomer fCustomerModel = null;
        private FeeStandard feeModel = new FeeStandard();
        private FeeStandardManager feeBLL = new FeeStandardManager();
        private frmEquipConfig fequipConfig = new frmEquipConfig();
        private int OnelprHandle = 0,ThreelprHandle=0,FourlprHandle=0;
        private int TwolprHandle = 0,FivelprHandle=0;
        private bool InCarAutoOpen = false;//内部车自动开闸；
       // private string str_rkip,str_threeip,str_fourip; //入口摄像机IP地址
      //  private string str_ckip; //出口摄像机IP地址
        private string cameraOneType="1",cameraThreeType="1",cameraFourType="1",OneLedType="1",ThreeLedType="1",FourLedType="1", EquipFiveSet="1";//第一台摄像机类型（出口或入口）201605 增加 //所接显示屏类型
        private string OneAddr="1",SyOneWinNo = "1", SyOneControl = "1", SyOneShowType = "1";//余车位显示地址，窗口号，控制符20170331jian增加。
      //  private string TwoAddr, SyTwoWinNo, SyTwoControl, SyTwoShowType;//余车位显示地址，窗口号，控制符20170331jian增加。

        private string ThreeAddr = "1", SyThreeWinNo = "1", SyThreeControl = "1", SyThreeShowType = "1";//余车位显示地址，窗口号，控制符20170331jian增加。
        private string FourAddr = "1", SyFourWinNo = "1", SyFourControl = "1", SyFourShowType = "1";//余车位显示地址，窗口号，控制符20170331jian增加。

        private string OneSerial = "1", TwoSerial = "1", ThreeSerial = "1", FourSerial = "1",FiveSerial="1";//摄像机加密码，为了摄像机串货 201708 增加 。

        public static int i_winstoptime;

        private string cameraTwoType = "1",cameraFiveType="1", TwoLedType = "1",FiveLedType="1";//第二台摄像机类型（出口或入口）201605 增加 //所接显示屏类型20170331 jian增加
        private string OnePosition = "1", ThreePosition = "1", FourPosition = "1";//
        private string TwoPosition = "1",FivePosition="1";//
        private string oneIp = "1", threeIp = "1", fourIp = "1";//
        private string twoIp = "1",fiveIp="1";//
        private string OneShowLedico="0", ThreeShowLedico = "0", FourShowLedico = "0";//第一个屏是否显示图标
       // private string TwoShowLedico="0";//第二个屏是否显示图标
        private short int_rkport,int_threeport,int_fourport; //入口摄像机端口号

        private short int_ckport,int_fiveport; //出口摄像机端口号
        private string str_rkuser,str_threeuser,str_fouruser; //入口摄像机用户名
        private string str_ckuser,strfiveuser; //出口摄像机用户名
        private string str_ckpass,strfivepass; //入口摄像机密码
        private string str_rkpass,str_threepass,str_fourpass; //入口摄像机密码
        private string inimgpath,threeimagepath,fourimagepath; //入口摄像机图片保存路径
        private string outimgpath,fiveImagepath; //出口摄像机图片保存路径
        private string rkImage,threeImage,fourImage;//入口摄像机图片保存路径
        private string ckImage,fiveImage;//出口摄像机图片保存路径
        public string str_imgpath; //图片图径


        public string strReason;
        public string str_MoveCar;//一户多车结算模式
                                  // ChargeRecord chargeRecordModel = new ChargeRecord();

        private string OneLedAddr1="1", OneLedAddr2="1"; //第一台摄像机接的第一块LED屏地址，第二块LED屏地址
        private string OneLedShowType1="1", OneLedShowType2="1";//显示类型
        public  string OneLedControlchar1 = "1", OneLedControlchar2 = "1";//控制字符
       // private string OneLedMControlchar0 = "0", OneLedMControlchar1 = "0", OneLedMControlchar2 = "0", OneLedMControlchar3 = "0";//广告屏控制字符
        private string OneLedWinNo0 = "0",OneLedWinNo1="0", OneLedWinNo2="0",OneLedWinNo3="0";//广告屏窗口号

        private string OneLedVols1, OneLedVols2; //自动音量
        private string OneLedVole1, OneLedVole2;

        private string TwoAddr, TwoLedAddr1="1", TwoLedAddr2="2"; //第二台摄像机接的第一块LED屏地址，第二块LED屏地址
        private string TwoLedShowType1="1", TwoLedShowType2="2";//显示类型
        public string TwoLedControlchar1 = "1", TwoLedControlchar2 = "1";//控制字符
        
     //   private string TwoLedMControlchar0="0", TwoLedMControlchar1="0", TwoLedMControlchar2 = "0", TwoLedMControlchar3 = "0";//广告屏控制字符
        private string TwoLedWinNo0="0", TwoLedWinNo1="0",TwoLedWinNo2="0", TwoLedWinNo3 = "0";//广告屏窗口号

        private string FiveAddr, FiveLedAddr1 = "1", FiveLedAddr2 = "2"; //第二台摄像机接的第一块LED屏地址，第二块LED屏地址
        private string FiveLedShowType1 = "1", FiveLedShowType2 = "2";//显示类型
        public string FiveLedControlchar1 = "1", FiveLedControlchar2 = "1";//控制字符

        //   private string TwoLedMControlchar0="0", TwoLedMControlchar1="0", TwoLedMControlchar2 = "0", TwoLedMControlchar3 = "0";//广告屏控制字符
        private string FiveLedWinNo0 = "0", FiveLedWinNo1 = "0", FiveLedWinNo2 = "0", FiveLedWinNo3 = "0";//广告屏窗口号


        private string TwoLedVols1, TwoLedVols2; //自动音量
        private string TwoLedVole1, TwoLedVole2;

        private string ThreeLedAddr1 = "1", ThreeLedAddr2 = "1"; //第三台摄像机接的第一块LED屏地址，第二块LED屏地址
        private string ThreeLedShowType1 = "1", ThreeLedShowType2 = "1";//显示类型
        private string ThreeLedControlchar1 = "1", ThreeLedControlchar2 = "1";//控制字符
       // private string ThreeLedMControlchar0 = "0", ThreeLedMControlchar1 = "0", ThreeLedMControlchar2 = "0", ThreeLedMControlchar3 = "0";//广告屏控制字符
        private string ThreeLedWinNo0 = "0", ThreeLedWinNo1 = "0", ThreeLedWinNo2 = "0", ThreeLedWinNo3 = "0";//广告屏窗口号

        private string ThreeLedVols1, ThreeLedVols2; //自动音量
        private string ThreeLedVole1, ThreeLedVole2;

        private string FourLedAddr1 = "1", FourLedAddr2 = "2"; //第四台摄像机接的第一块LED屏地址，第二块LED屏地址
        private string FourLedShowType1 = "1", FourLedShowType2 = "2";//显示类型
        private string FourLedControlchar1 = "1", FourLedControlchar2 = "1";//控制字符
       // private string FourLedMControlchar0 = "0", FourLedMControlchar1 = "0", FourLedMControlchar2 = "0", FourLedMControlchar3 = "0";//广告屏控制字符
        private string FourLedWinNo0 = "0", FourLedWinNo1 = "0", FourLedWinNo2 = "0", FourLedWinNo3 = "0";//广告屏窗口号

        private string FourLedVols1, FourLedVols2; //自动音量
        private string FourLedVole1, FourLedVole2;


        private BaseSet inbaseSetModel = null;
        private BaseSet outbaseSetModel = null;
        private BaseSetManager baseSetBLL = new BaseSetManager();
        private Operator operatorMode = null;
        private OperatorManager operatorBll = new OperatorManager();
        private ParkInfo parkInfoModel = null;
        private ParkInfoManager parkInfoBll = new ParkInfoManager();
        private string configpath = Application.StartupPath + "\\Config\\SysCon.ini";
        private INIFile ini = null;
        private Point oriPoint1,oriPoint2,oriPoint3;//保存原有位置 
        private bool isWin1=false,isWin2=false,isWin3=false;//当前监控窗口

        //主要记录宽车道情况下，一个车道两台摄机的情况。
        private string One_OutPlate=null,One_InPlate=null;//第一次车辆出场，第一次入场车牌
        private DateTime  One_OutTime=DateTime.Now,One_InTime = DateTime.Now;//第一次车辆出场时间，第一次入场时间


        AutoSizeFormClass AutoSizeForm = new AutoSizeFormClass();

        public struct CustomerConst
        {
            public const string Customer = "临停客户";
            public const string InCustomer = "内部客户";
            public const string FCustomer = "固定客户";
            public const string OFCustomer = "过期客户";
            public const string PlusOperate = "PlusOperate";
            public const string SubOperate = "SubOperate";
        }

        private string parkInfo = string.Empty;

        /// <summary>
        /// 获取实时泊位信息
        /// </summary>
        public void GetBerthInfo()
        {
            int oldleftberth = 0;
            int leftberth = 0;
            while (true)
            {
                if (operatorMode == null)
                {
                    operatorMode = new Operator();
                }
                operatorMode = GetOperatorModel();
                if (parkInfoModel == null)
                {
                    parkInfoModel = new ParkInfo();
                }
                parkInfoModel = parkInfoBll.GetModel(operatorMode.ParkId);
                leftberth = parkInfoModel.BerthCountRest ?? 0;
                if (oldleftberth != leftberth)
                {
                    oldleftberth = leftberth;
                    parkInfo = "车位" + oldleftberth.ToString();
                    PlayBerth();
                    ShowBerth(oldleftberth.ToString() + "个");
                }
                Thread.Sleep(3000);
            }

        }

        /// <summary>
        /// 刷新车位数量
        /// </summary>
        private void RefreshCount(string customertype, string operate)
        {
            operatorMode = GetOperatorModel();
            parkInfoModel = parkInfoBll.GetModel(operatorMode.ParkId);
            if (parkInfoModel != null)
            {
                if (customertype == CustomerConst.Customer)
                {
                    if (operate == CustomerConst.PlusOperate)
                    {
                        parkInfoModel.BerthCountRest = parkInfoModel.BerthCountRest + 1;
                    }
                    else
                    {
                        parkInfoModel.BerthCountRest = parkInfoModel.BerthCountRest - 1;
                    }
                }
                else
                {
                    if (operate == CustomerConst.PlusOperate)
                    {
                        parkInfoModel.FBerthCountRest = parkInfoModel.FBerthCountRest + 1;
                    }
                    else
                    {
                        parkInfoModel.FBerthCountRest = parkInfoModel.FBerthCountRest - 1;
                    }
                }
                parkInfoBll.Update(parkInfoModel);
                parkInfoModel = parkInfoBll.GetModel(operatorMode.ParkId);
                int leftberth = parkInfoModel.BerthCountRest ?? 0;
                int leftfberth = parkInfoModel.FBerthCountRest ?? 0;
                int sumleft = leftberth;
                parkInfo = "车位" + sumleft;
                Thread th = new Thread(new ParameterizedThreadStart(this.WebParkUpdate));
                th.IsBackground = true;
                th.Start(parkInfoModel);

            }

        }

        /// <summary>
        /// 更新服务器端的停车场信息
        /// </summary>
        /// <param name="model"></param>
        private void WebParkUpdate(object parkmodel)
        {
            www.gzwulian.com.Model.ParkInfo model = (www.gzwulian.com.Model.ParkInfo)parkmodel;
            //向服务端添加结算信息
            bool isSuccess = true;
            try
            {
                string CompanyCode = model.CompanyCode;
                string Name = model.ParkName;
                string ParkId = model.ParkID;
                string ParkName = model.ParkName;
                string ParkCity = model.ParkCity;
                string ParkCounty = model.ParkCounty;
                string ParkStreet = model.ParkStreet;
                string ParkOwner = model.ParkOwner;
                string ParkType = model.ParkType;
                string Lon = model.Longtitude.ToString();
                string Lat = model.Latitude.ToString();
                string SumBerthCount = model.SumBerthCount.ToString();
                string BerthCount = model.BerthCount.ToString();
                string FBerthCount = model.FBerthCount.ToString();
                string BusinessTime = model.BusinessTime;
                string OwnerTel = model.OwnerTel;
                string Remark = model.Remark;
                string BerthCountRest = model.BerthCountRest.ToString();
                string FBerthCountRest = model.FBerthCountRest.ToString();
                string values = CompanyCode + ',' + Name + ',' + ParkId + ',' + ParkName + ',' + ParkCity + ',' +
                                ParkCounty + ',' +
                                ParkStreet + ',' + ParkOwner + ',' + ParkType + ',' + Lon + ',' + Lat + ',' +
                                SumBerthCount + ',' + BerthCount + ',' +
                                FBerthCount + ',' + BusinessTime + ',' + OwnerTel + ',' + Remark + ',' +
                                LoginInfo.LoginName + ',' + BerthCountRest + ',' + FBerthCountRest;
                System.Net.WebClient wclient = new System.Net.WebClient();
                wclient.UploadString(
                    "http://zst.gzwulian.com/ClientService/HttpRequest/VehicParkInfo.ashx?paraStr=" + values, " ");
            }
            catch (Exception)
            {
                isSuccess = false;
            }
            model.IsUpload = isSuccess;
            parkInfoBll.Update(model);
        }

        /// <summary>
        /// 获取操作员实体
        /// </summary>
        /// <returns></returns>
        private Operator GetOperatorModel()
        {
            if (operatorMode == null)
            {
                operatorMode = new Operator();
            }
            operatorMode = operatorBll.GetModel(LoginInfo.Id);
            return operatorMode;
        }

        /// <summary>
        /// 初始化停车场信息
        /// </summary>
        private void RefreshParkInfo()
        {
            operatorMode = GetOperatorModel();
            parkInfoModel = new ParkInfo();
            parkInfoModel = parkInfoBll.GetModel(operatorMode.ParkId);
            if (parkInfoModel != null)
            {
                //临停泊位总数
                lbBerthCount.Text = parkInfoModel.BerthCount.ToString() + "(个)";
                //剩余临停泊位数
                lbBerthCountRest.Text = parkInfoModel.BerthCountRest.ToString() + "(个)";
            }
        }

        /// <summary>
        /// 初始化收费记录信息
        /// </summary>
        private void RefreshChargeInfo()
        {
            DataSet ds = chargeRecordBLL.GetList(1, "OutTime!=''", "OutTime");
            if (ds.Tables[0].Rows.Count > 0)
            {
                chargeRecordModel = chargeRecordBLL.DataTableToList(ds.Tables[0]).First();
                if (string.IsNullOrWhiteSpace(chargeRecordModel.PlateId))
                {
                    lblPlateId.Text = chargeRecordModel.CardCode;
                }
                else
                {
                    lblPlateId.Text = chargeRecordModel.PlateId;
                }
                lblCarType.Text = chargeRecordModel.CarType;
                lblCType.Text = chargeRecordModel.CusType;
                lblIInTime.Text = chargeRecordModel.InTime.ToString();
                lblOOutTime.Text = chargeRecordModel.OutTime.ToString();
                lblParkTime.Text = chargeRecordModel.ParkTime;
                if (!string.IsNullOrEmpty(chargeRecordModel.FreeReason))
                {
                    lblSummoney.Text = "免 费";
                }
                else
                {
                    lblSummoney.Text = chargeRecordModel.SumMoney.ToString() + "（元）";
                }

                lblFeeStandard.Text = chargeRecordModel.FeeStandard;
                lblCarType.Text = chargeRecordModel.CarType;
            }
        }

        private IPEndPoint ipLocalPoint;
        private EndPoint RemotePoint;
        public System.Net.Sockets.Socket mySocket;
        private bool RunningFlag = false;
        private Thread pth;
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZXJK_Load(object sender, EventArgs e)
        {


            BackgroundWorker worker = GetWorker();
            worker.RunWorkerAsync();
            ini = new INIFile(configpath);
            //if (btnOffWork.Text == "开始上班")
            //{
            //开始上班



            //}
            iniinfo = new INIMag(GlobalInfo.Instance.ConfigPath);

            //窗口停车时间（需确认开闸）
            i_winstoptime = iniinfo.WinStopTime;

            if (string.IsNullOrWhiteSpace(LoginInfo.ParkId))
            {
                MessageBox.Show("没有车场的基本信息，请先对车场信息进行配置后再使用。");
                Close();
                return;

            }

            if (!SetShowmessgess())
            {
                Close();
                return;

            }

            // DeleteImg();
            //Control.CheckForIllegalCrossThreadCalls = false;
            //str_MoveCar=1是自动转固定车，=0为不自动转固定车 2016.7.20jyb
            // -1时不启动一户多车模式
            str_MoveCar = LoginInfo.getMoveCar.ToString();//一户多车计费模式 
            //判断用户有没有操作车辆档案的权限
            SetRights();
            

            pth = new Thread(GetBerthInfo);
            pth.IsBackground = true;
            pth.Start();

            //  RefreshChargeInfo();
            ReadiniFree();//取免费原因
          //  MessageHelper.ShowTips(strReason[0].ToString());

            //初始化配置
            InitSet();
            //    Thread th = new Thread(InitSet);
            //th.IsBackground = true;
            //th.Start();
            //try
            //{
            //    //定义网络类型，数据连接类型和网络协议UDP   
            //    mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //    ipLocalPoint = new IPEndPoint(IPAddress.Parse(GetIPAddress()), 39169); //getIPAddress()获得本地地址
            //    //绑定网络地址   
            //    mySocket.Bind(ipLocalPoint);
            //    IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 39169);
            //    RemotePoint = (EndPoint)(ipep);
            //    //开启线程接收
            //    RunningFlag = true;
            //    //Thread thread = new Thread(new ThreadStart(this.ReceiveHandle));
            //    //thread.Start();
            //}
            //catch (Exception ex)
            //{

            //}

            //显示车位信息
            OnWork();
            RefreshParkInfo();
            PlayBerth();//显示车位信息

            worker.CancelAsync();
            AutoSizeForm.controllInitializeSize(this);

            // titleTime.Start();



        }

        private void SetRights()
        {
            if (!frmMain.strcarData)
            {
                butCarData.Enabled = false;
            }
            else
            {
                butCarData.Enabled = true;
            }
            if (!frmMain.strchargData)
            {
                butcharge.Enabled = false;

            }
            else
            {
                butcharge.Enabled = true;

            }


            if (iniinfo.HandOff == "True")
            {
                butintg.Enabled = true;
                butouttg.Enabled = true;
            }
            else
            {

                butintg.Enabled = false;
                butouttg.Enabled = false;
            }
        }

        private BackgroundWorker GetWorker()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.WorkerSupportsCancellation = true;
            return worker;
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            frmWait waitfrm = new frmWait();
                        waitfrm.showtip = "正在加载数据，请稍后......";
            waitfrm.Show();

            BackgroundWorker worker = (BackgroundWorker)sender;
            while (true)
            {

                waitfrm.BringToFront();
                waitfrm.Refresh();
                if (worker.CancellationPending)
                {
                    waitfrm.Close();
                    e.Cancel = true;
                }
                else
                    e.Cancel = false;
                System.Threading.Thread.Sleep(10);
            }
        }
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ((BackgroundWorker)sender).Dispose();
        }

        private bool SetShowmessgess()
        {
          //  bool isEquip = false;
            INIFile ini = new INIFile(configpath);
            oneIp = ini.IniReadValue("EquipOneSet", "EquipIp");

            if (!string.IsNullOrWhiteSpace(oneIp))
            {

                cameraOneType = ini.IniReadValue("EquipOneSet", "EquipType");
                int_rkport = short.Parse(ini.IniReadValue("EquipOneSet", "Port"));
                str_rkuser = ini.IniReadValue("EquipOneSet", "LoginName");
                str_rkpass = ini.IniReadValue("EquipOneSet", "Password");
                rkImage = ini.IniReadValue("EquipOneSet", "ImagePath"); //出口图片路径
                OnePosition = ini.IniReadValue("EquipOneSet", "Position");
                OneSerial = ini.IniReadValue("EquipOneSet", "EquipSerial");
                inimgpath = rkImage;
                this.In_axVZLPRClientCtrl.SetWindowStyle(1);
                OnelprHandle = this.In_axVZLPRClientCtrl.VzLPRClientOpen(oneIp, int_rkport, str_rkuser, str_rkpass);
                if (OnelprHandle > 0)
                {
                    string key1 = "gzW" + this.In_axVZLPRClientCtrl.VzLPRGetSerialNumber(OnelprHandle) + "440";
                    string key2 = "LIOTong5";
                    if (OneSerial == CEncoder.EncryptDES(key1, key2))
                    {
                        this.In_axVZLPRClientCtrl.SetIsSaveFullImage(OnelprHandle, true, inimgpath);
                        this.In_axVZLPRClientCtrl.VzLPRClientStartPlay(OnelprHandle, 0);
                        int i = this.In_axVZLPRClientCtrl.VzLPRSetOfflineCheck(OnelprHandle);

                        OneShowLedico = ini.IniReadValue(oneIp, "ShowLedico1");
                        if (OneShowLedico == "1")
                        {
                            SetLedInitIco("one", OneLedAddr1, OnelprHandle);
                        }

                        //读取LED设备参数
                        OneLedType= ini.IniReadValue(oneIp, "LedType");

                        if (OneLedType == "OneLed")
                        {
                            OneAddr = ini.IniReadValue(oneIp, "LedAddr");
                            SyOneShowType = ini.IniReadValue(oneIp, "LedShowType");
                            SyOneControl = ini.IniReadValue(oneIp, "LedControlchar");
                            OneLedAddr1 = ini.IniReadValue(oneIp, "LedAddr1");
                            OneLedShowType1 = ini.IniReadValue(oneIp, "LedShowType1");
                            OneLedControlchar1 = ini.IniReadValue(oneIp, "LedControlchar1");
                            OneLedAddr2 = ini.IniReadValue(oneIp, "LedAddr2");
                            OneLedShowType2 = ini.IniReadValue(oneIp, "LedShowType2");
                            OneLedControlchar2 = ini.IniReadValue(oneIp, "LedControlchar2");
                        }
                        if (OneLedType == "AdLed")
                        {
                            OneAddr = ini.IniReadValue(oneIp, "LedAddr");

                            SyOneWinNo = ini.IniReadValue(oneIp, "LedWinNo");
                            SyOneShowType = ini.IniReadValue(oneIp, "LedShowType");
                            SyOneControl = ini.IniReadValue(oneIp, "LedControlchar");


                            OneLedWinNo1 = ini.IniReadValue(oneIp, "LedWinNo2");
                            OneLedShowType1 = ini.IniReadValue(oneIp, "LedShowType2");
                            OneLedControlchar1 = ini.IniReadValue(oneIp, "LedControlchar2");


                            OneLedWinNo2 = ini.IniReadValue(oneIp, "LedWinNo3");
                            OneLedShowType2 = ini.IniReadValue(oneIp, "LedShowType3");
                            OneLedControlchar2 = ini.IniReadValue(oneIp, "LedControlchar3");

                        }
                        OneLedVols1 = ini.IniReadValue(oneIp, "LedVols1");
                        OneLedVole1 = ini.IniReadValue(oneIp, "LedVole1");
                        OneLedVols2 = ini.IniReadValue(oneIp, "LedVols2");
                        OneLedVole2 = ini.IniReadValue(oneIp, "LedVole2");

                        ////显示车位信息
                        //RefreshParkInfo();
                        //PlayBerth();//显示车位信息

                    }
                    else
                    {
                        MessageHelper.ShowWarning("IP为【" + oneIp + "】为摄像机验证不正确，请联系供应商！");

                    }
                }
                else
                {
                    MessageHelper.ShowTips("IP为【" + oneIp + "】为摄像机不在线，请检查网络配置！");

                }
            } 
            twoIp = ini.IniReadValue("EquipTwoSet", "EquipIp");
            if (!string.IsNullOrWhiteSpace(twoIp))
            {

                cameraTwoType = ini.IniReadValue("EquipTwoSet", "EquipType");
                int_ckport = short.Parse(ini.IniReadValue("EquipTwoSet", "Port"));
                str_ckuser = ini.IniReadValue("EquipTwoSet", "LoginName");
                str_ckpass = ini.IniReadValue("EquipTwoSet", "Password");
                ckImage = ini.IniReadValue("EquipTwoSet", "ImagePath"); //出口图片路径
                TwoPosition = ini.IniReadValue("EquipTwoSet", "Position");
                TwoSerial = ini.IniReadValue("EquipTwoSet", "EquipSerial");
                outimgpath = ckImage;
                this.Out_axVZLPRClientCtrl.SetWindowStyle(1);
                TwolprHandle = this.Out_axVZLPRClientCtrl.VzLPRClientOpen(twoIp, int_rkport, str_rkuser, str_rkpass);
                if (TwolprHandle > 0)
                {

                    string key1 = "gzW" + this.Out_axVZLPRClientCtrl.VzLPRGetSerialNumber(TwolprHandle) + "440";
                    string key2 = "LIOTong5";
                    if (TwoSerial == CEncoder.EncryptDES(key1, key2))
                    {
                        this.Out_axVZLPRClientCtrl.SetIsSaveFullImage(TwolprHandle, true, outimgpath);
                        this.Out_axVZLPRClientCtrl.VzLPRClientStartPlay(TwolprHandle, 0);
                        int i = this.Out_axVZLPRClientCtrl.VzLPRSetOfflineCheck(TwolprHandle);


                        TwoLedType = ini.IniReadValue(twoIp, "LedType");
                        if (TwoLedType == "OneLed")
                        {
                            TwoLedAddr1 = ini.IniReadValue(twoIp, "LedAddr1");
                            TwoLedShowType1 = ini.IniReadValue(twoIp, "LedShowType1");
                            TwoLedControlchar1 = ini.IniReadValue(twoIp, "LedControlchar1");

                            TwoLedAddr2 = ini.IniReadValue(twoIp, "LedAddr2");
                            TwoLedShowType2 = ini.IniReadValue(twoIp, "LedShowType2");
                            TwoLedControlchar2 = ini.IniReadValue(twoIp, "LedControlchar2");

                        }
                        if (TwoLedType == "AdLed")
                        {
                            TwoAddr = ini.IniReadValue(twoIp, "LedAddr");

                            TwoLedWinNo1 = ini.IniReadValue(twoIp, "LedWinNo2");
                            TwoLedShowType1 = ini.IniReadValue(twoIp, "LedShowType2");
                            TwoLedControlchar1 = ini.IniReadValue(twoIp, "LedControlchar2");

                            TwoLedWinNo2 = ini.IniReadValue(twoIp, "LedWinNo3");
                            TwoLedShowType2 = ini.IniReadValue(twoIp, "LedShowType3");
                            TwoLedControlchar2 = ini.IniReadValue(twoIp, "LedControlchar3");

                        }
                        TwoLedVols1 = ini.IniReadValue(twoIp, "LedVols1");
                        TwoLedVole1 = ini.IniReadValue(twoIp, "LedVole1");
                        TwoLedVols2 = ini.IniReadValue(twoIp, "LedVols2");
                        TwoLedVole2 = ini.IniReadValue(twoIp, "LedVole2");



                    }
                    else
                    {
                        MessageHelper.ShowWarning("IP为【" + twoIp + "】为摄像机验证不正确，请联系供应商！");

                    }



                }
                else
                {
                    MessageHelper.ShowTips("IP为【" + twoIp + "】为摄像机不在线，请检查网络配置！");

                }
            }

            threeIp = ini.IniReadValue("EquipThreeSet", "EquipIp");
            if (!string.IsNullOrWhiteSpace(threeIp))
            {

                cameraThreeType = ini.IniReadValue("EquipThreeSet", "EquipType");
                int_threeport = short.Parse(ini.IniReadValue("EquipThreeSet", "Port"));
                str_threeuser = ini.IniReadValue("EquipThreeSet", "LoginName");
                str_threepass = ini.IniReadValue("EquipThreeSet", "Password");
                threeImage = ini.IniReadValue("EquipThreeSet", "ImagePath"); //出口图片路径
                ThreePosition = ini.IniReadValue("EquipThreeSet", "Position");
                ThreeSerial = ini.IniReadValue("EquipThreeSet", "EquipSerial");

                threeimagepath = threeImage;

               

                this.In_ThreeaxVZLPRClientCtrl.SetWindowStyle(1);
                ThreelprHandle = this.In_ThreeaxVZLPRClientCtrl.VzLPRClientOpen(threeIp, int_rkport, str_rkuser, str_rkpass);
                if (ThreelprHandle > 0)
                {

                    string key1 = "gzW" + this.In_ThreeaxVZLPRClientCtrl.VzLPRGetSerialNumber(ThreelprHandle) + "440";
                    string key2 = "LIOTong5";
                    if (ThreeSerial == CEncoder.EncryptDES(key1, key2))
                    {
                        this.In_ThreeaxVZLPRClientCtrl.SetIsSaveFullImage(ThreelprHandle, true, threeImage);
                        this.In_ThreeaxVZLPRClientCtrl.VzLPRClientStartPlay(ThreelprHandle, 0);
                        int i = this.In_ThreeaxVZLPRClientCtrl.VzLPRSetOfflineCheck(ThreelprHandle);
                        panel1.Visible = true;
                        lb_ThreeName.Text = ThreePosition;


                        ThreeShowLedico = ini.IniReadValue(threeIp, "ShowLedico1");
                        if (ThreeShowLedico == "1")
                        {
                            SetLedInitIco("three", ThreeLedAddr1, ThreelprHandle);
                        }
   
                        //读取LED设备参数
                        ThreeLedType = ini.IniReadValue(threeIp, "LedType");
                        if (ThreeLedType == "OneLed")
                        {
                            ThreeAddr = ini.IniReadValue(threeIp, "LedAddr");
                            SyThreeShowType = ini.IniReadValue(threeIp, "SyLedShowType");
                            SyThreeControl = ini.IniReadValue(threeIp, "SyLedControlchar");

                            ThreeLedAddr1 = ini.IniReadValue(threeIp, "LedAddr1");
                            ThreeLedShowType1 = ini.IniReadValue(threeIp, "LedShowType1");
                            ThreeLedControlchar1 = ini.IniReadValue(threeIp, "LedControlchar1");

                            ThreeLedAddr2 = ini.IniReadValue(threeIp, "LedAddr2");
                            ThreeLedShowType2 = ini.IniReadValue(threeIp, "LedShowType2");
                            ThreeLedControlchar2 = ini.IniReadValue(threeIp, "LedControlchar2");
                        }
                        if (ThreeLedType == "AdLed")
                        {
                            ThreeAddr = ini.IniReadValue(threeIp, "LedAddr");

                            SyThreeWinNo = ini.IniReadValue(threeIp, "SyLedWinNo");
                            SyThreeShowType = ini.IniReadValue(threeIp, "SyLedShowType");
                            SyThreeControl = ini.IniReadValue(threeIp, "SyLedControlchar");


                            ThreeLedWinNo1 = ini.IniReadValue(threeIp, "LedWinNo2");
                            ThreeLedShowType1 = ini.IniReadValue(threeIp, "LedShowType2");
                            ThreeLedControlchar1 = ini.IniReadValue(threeIp, "LedControlchar2");


                            ThreeLedWinNo2 = ini.IniReadValue(threeIp, "LedWinNo3");
                            ThreeLedShowType2 = ini.IniReadValue(threeIp, "LedShowType3");
                            ThreeLedControlchar2 = ini.IniReadValue(threeIp, "LedControlchar3");

                        }
                        ThreeLedVols1 = ini.IniReadValue(threeIp, "LedVols1");
                        ThreeLedVole1 = ini.IniReadValue(threeIp, "LedVole1");
                        ThreeLedVols2 = ini.IniReadValue(threeIp, "LedVols2");
                        ThreeLedVole2 = ini.IniReadValue(threeIp, "LedVole2");



                    }
                    else
                    {
                        MessageHelper.ShowWarning("IP为【" + threeIp + "】为摄像机验证不正确，请联系供应商！");

                    }


                }
                else
                {
                    MessageHelper.ShowTips("IP为【" + threeIp + "】为摄像机不在线，请检查网络配置！");

                }

            }

            fourIp = ini.IniReadValue("EquipFourSet", "EquipIp");
            if (!string.IsNullOrWhiteSpace(fourIp))
            {

                cameraFourType = ini.IniReadValue("EquipFourSet", "EquipType");
                int_fourport = short.Parse(ini.IniReadValue("EquipFourSet", "Port"));
                str_fouruser = ini.IniReadValue("EquipFourSet", "LoginName");
                str_fourpass = ini.IniReadValue("EquipFourSet", "Password");
                fourImage = ini.IniReadValue("EquipFourSet", "ImagePath"); //出口图片路径
                FourPosition = ini.IniReadValue("EquipFourSet", "Position");
                FourSerial = ini.IniReadValue("EquipFourSet", "EquipSerial");
                fourimagepath = fourImage;


                this.In_FouraxVZLPRClientCtrl.SetWindowStyle(1);
                FourlprHandle = this.In_FouraxVZLPRClientCtrl.VzLPRClientOpen(fourIp, int_rkport, str_rkuser, str_rkpass);
                if (FourlprHandle > 0)
                {

                    string key1 = "gzW" + this.In_FouraxVZLPRClientCtrl.VzLPRGetSerialNumber(FourlprHandle) + "440";
                    string key2 = "LIOTong5";
                    if (FourSerial == CEncoder.EncryptDES(key1, key2))
                    {
                        this.In_FouraxVZLPRClientCtrl.SetIsSaveFullImage(FourlprHandle, true, fourImage);
                        this.In_FouraxVZLPRClientCtrl.VzLPRClientStartPlay(FourlprHandle, 0);
                        int i = this.In_FouraxVZLPRClientCtrl.VzLPRSetOfflineCheck(FourlprHandle);
                        panel2.Visible = true;
                        lb_FourName.Text = FourPosition;

                        FourShowLedico = ini.IniReadValue(fourIp, "ShowLedico1");
                        if (ThreeShowLedico == "1")
                        {
                            SetLedInitIco("four", FourLedAddr1, FourlprHandle);
                        }

                        //读取LED设备参数
                        FourLedType = ini.IniReadValue(fourIp, "LedType");
                        if (FourLedType == "OneLed")
                        {
                            FourAddr = ini.IniReadValue(fourIp, "LedAddr");
                            SyFourShowType = ini.IniReadValue(fourIp, "SyLedShowType");
                            SyFourControl = ini.IniReadValue(fourIp, "SyLedControlchar");

                            FourLedAddr1 = ini.IniReadValue(fourIp, "LedAddr1");
                            FourLedShowType1 = ini.IniReadValue(fourIp, "LedShowType1");
                            FourLedControlchar1 = ini.IniReadValue(fourIp, "LedControlchar1");

                            FourLedAddr2 = ini.IniReadValue(fourIp, "LedAddr2");
                            FourLedShowType2 = ini.IniReadValue(fourIp, "LedShowType2");
                            FourLedControlchar2 = ini.IniReadValue(fourIp, "LedControlchar2");
                        }
                        if (FourLedType == "AdLed")
                        {
                            FourAddr = ini.IniReadValue(fourIp, "LedAddr");

                            SyFourWinNo = ini.IniReadValue(fourIp, "SyLedWinNo");
                            SyFourShowType = ini.IniReadValue(fourIp, "SyLedShowType");
                            SyFourControl = ini.IniReadValue(fourIp, "SyLedControlchar");


                            FourLedWinNo1 = ini.IniReadValue(fourIp, "LedWinNo2");
                            FourLedShowType1 = ini.IniReadValue(fourIp, "LedShowType2");
                            FourLedControlchar1 = ini.IniReadValue(fourIp, "LedControlchar2");


                            FourLedWinNo2 = ini.IniReadValue(fourIp, "LedWinNo3");
                            FourLedShowType2 = ini.IniReadValue(fourIp, "LedShowType3");
                            FourLedControlchar2 = ini.IniReadValue(fourIp, "LedControlchar3");

                        }
                        FourLedVols1 = ini.IniReadValue(fourIp, "LedVols1");
                        FourLedVole1 = ini.IniReadValue(fourIp, "LedVole1");
                        FourLedVols2 = ini.IniReadValue(fourIp, "LedVols2");
                        FourLedVole2 = ini.IniReadValue(fourIp, "LedVole2");
                    }
                    else
                    {
                        MessageHelper.ShowWarning("IP为【" + fourIp + "】为摄像机验证不正确，请联系供应商！");

                    }

                }
                else
                {
                    MessageHelper.ShowTips("IP为【" + fourIp + "】为摄像机不在线，请检查网络配置！");

                }

            }


            fiveIp = ini.IniReadValue("EquipFiveSet", "EquipIp");
            if (!string.IsNullOrWhiteSpace(fiveIp))
            {

                cameraFiveType = ini.IniReadValue("EquipFiveSet", "EquipType");
                int_fiveport = short.Parse(ini.IniReadValue("EquipFiveSet", "Port"));
                strfiveuser = ini.IniReadValue("EquipFiveSet", "LoginName");
                strfivepass = ini.IniReadValue("EquipFiveSet", "Password");
                fiveImage = ini.IniReadValue("EquipFiveSet", "ImagePath"); //出口图片路径
                FivePosition = ini.IniReadValue("EquipFiveSet", "Position");
                FiveSerial = ini.IniReadValue("EquipFiveSet", "EquipSerial");
                fiveImagepath = fiveImage;


                this.Out_FiveaxVZLPRClientCtrl.SetWindowStyle(1);
                FivelprHandle = this.Out_FiveaxVZLPRClientCtrl.VzLPRClientOpen(fiveIp, int_fiveport, strfiveuser, strfivepass);
                if (FivelprHandle > 0)
                {

                    string key1 = "gzW" + this.Out_FiveaxVZLPRClientCtrl.VzLPRGetSerialNumber(FivelprHandle) + "440";
                    string key2 = "LIOTong5";
                    if (FiveSerial == CEncoder.EncryptDES(key1, key2))
                    {
                        this.Out_FiveaxVZLPRClientCtrl.SetIsSaveFullImage(FivelprHandle, true, fiveImage);
                        this.Out_FiveaxVZLPRClientCtrl.VzLPRClientStartPlay(FivelprHandle, 0);
                        int i = this.Out_FiveaxVZLPRClientCtrl.VzLPRSetOfflineCheck(FivelprHandle);
                        panel4.Visible = true;
                        lb_FiveName.Text = FivePosition;

                        //FourShowLedico = ini.IniReadValue(fourIp, "ShowLedico1");
                        //if (ThreeShowLedico == "1")
                        //{
                        //    SetLedInitIco("four", FourLedAddr1, FourlprHandle);
                        //}

                        //读取LED设备参数
                        FiveLedType = ini.IniReadValue(fiveIp, "LedType");
                        if (FiveLedType == "OneLed")
                        {
                            FiveAddr = ini.IniReadValue(fiveIp, "LedAddr");
                            //SyfiveShowType = ini.IniReadValue(fourIp, "SyLedShowType");
                            //SyFourControl = ini.IniReadValue(fourIp, "SyLedControlchar");

                            FiveLedAddr1 = ini.IniReadValue(fiveIp, "LedAddr1");
                            FiveLedShowType1 = ini.IniReadValue(fiveIp, "LedShowType1");
                            FiveLedControlchar1 = ini.IniReadValue(fiveIp, "LedControlchar1");

                            FiveLedAddr2 = ini.IniReadValue(fourIp, "LedAddr2");
                            FiveLedShowType2 = ini.IniReadValue(fiveIp, "LedShowType2");
                            FiveLedControlchar2 = ini.IniReadValue(fiveIp, "LedControlchar2");
                        }
                        if (FiveLedType == "AdLed")
                        {
                            FiveAddr = ini.IniReadValue(fiveIp, "LedAddr");

                            //SyFourWinNo = ini.IniReadValue(fourIp, "SyLedWinNo");
                            //SyFourShowType = ini.IniReadValue(fourIp, "SyLedShowType");
                            //SyFourControl = ini.IniReadValue(fourIp, "SyLedControlchar");


                            FiveLedWinNo1 = ini.IniReadValue(fiveIp, "LedWinNo2");
                            FiveLedShowType1 = ini.IniReadValue(fiveIp, "LedShowType2");
                            FiveLedControlchar1 = ini.IniReadValue(fiveIp, "LedControlchar2");


                            FiveLedWinNo2 = ini.IniReadValue(fiveIp, "LedWinNo3");
                            FiveLedShowType2 = ini.IniReadValue(fiveIp, "LedShowType3");
                            FiveLedControlchar2 = ini.IniReadValue(fiveIp, "LedControlchar3");

                        }
                        //FourLedVols1 = ini.IniReadValue(fourIp, "LedVols1");
                        //FourLedVole1 = ini.IniReadValue(fourIp, "LedVole1");
                        //FourLedVols2 = ini.IniReadValue(fourIp, "LedVols2");
                        //FourLedVole2 = ini.IniReadValue(fourIp, "LedVole2");
                    }
                    else
                    {
                        MessageHelper.ShowWarning("IP为【" + fiveIp + "】为摄像机验证不正确，请联系供应商！");

                    }

                }
                else
                {
                    MessageHelper.ShowTips("IP为【" + fiveIp + "】为摄像机不在线，请检查网络配置！");

                }

            }

            groupPanel1.Text = "车辆图片";
            groupPanel3.Text = "车辆图片";

            groupPanel6.Text = cameraOneType + "-" + OnePosition;
            groupPanel2.Text = cameraTwoType + "-" + TwoPosition;

            if (string.IsNullOrWhiteSpace(oneIp) && string.IsNullOrWhiteSpace(twoIp))
            {
                MessageHelper.ShowTips("在线监控需要有车牌识别一体机才能正常工作，请先配置一体机！");
                // Close();
                return false;
            }
            else
            {
                return true;

            }



        }

        private void SetLedInitIco(string strIp, string strLedAddr,int lprHandle)
        {
           
            string strdelwin= LedFunc.Delledwin("0", strLedAddr);
            string strdelwin1 = LedFunc.Delledwin("1", strLedAddr);


            string strdelpic = "0064FFFF810104675F";
            string s_addr = Convert.ToInt16(strLedAddr).ToString("X2");
            string strcolbgCode = s_addr + "64FFFF410400000000541F"; //selbgcolor()//设置背景颜色
            string strcolCode = s_addr + "64FFFF4004FF00000065DA";//setcolor()//设置绘'颜色

            string strclear = s_addr + "64FFFF01007067";


            string strshowiconcode = s_addr + "64FFFF430AFAFFFEFF01000300" + Convert.ToString(43,16) + "00";
            string strshowiconcrc = LedFunc.CalculateCrc16(LedFunc.strToToHexByte(strshowiconcode)).ToString("X2");
            string strshowicon = strshowiconcode + strshowiconcrc;
            //图形箭头
            //1、建立图片控件

            string strpiccode = s_addr + "64FFFF8009041800100030001000";
            string strpiccrc = LedFunc.CalculateCrc16(LedFunc.strToToHexByte(strpiccode)).ToString("X2");
            string strpic = strpiccode + strpiccrc;
            //2、添加图片
            string straddpiccode = s_addr + "64FFFF8209042D00010200000606";
            string straddpiccrc = LedFunc.CalculateCrc16(LedFunc.strToToHexByte(straddpiccode)).ToString("X2");
            string straddpic = straddpiccode + straddpiccrc;

            //   string s_addr = Convert.ToInt16(cbox_mledaddr.Text).ToString("X2");
            string straddtimecode = s_addr + "64FFFF600A00001100000030000800";
            string straddtimecrc = LedFunc.CalculateCrc16(LedFunc.strToToHexByte(straddtimecode)).ToString("X2").ToString();
            string straddtime = straddtimecode + straddtimecrc;

            string stradddatecode = s_addr + "64FFFF600A01001300080030000800";
            string stradddatecrc = LedFunc.CalculateCrc16(LedFunc.strToToHexByte(stradddatecode)).ToString("X2").ToString();
            string stradddate = stradddatecode + stradddatecrc;

            string strshowdatecode = s_addr + "64FFFF621B00000108FF00010000FF00000000000000080060592D604D2D6044DEC9";
            string strshowtimecode = s_addr + "64FFFF621B01000108FF00010000FF00000000000000080060483A604E3A6053D223";

            if (strIp == "one")
            {

              
                    int lprserial = In_axVZLPRClientCtrl.VzLPRSerialStartEx(lprHandle, 1);


                    In_axVZLPRClientCtrl.VzLPRSerialSendEx(lprHandle, lprserial, strdelwin, Convert.ToInt16(strdelwin.Length / 2));//清除LED内存  

                    In_axVZLPRClientCtrl.VzLPRSerialSendEx(lprHandle, lprserial, strdelwin1, Convert.ToInt16(strdelwin1.Length / 2));//清除LED内存  

                    In_axVZLPRClientCtrl.VzLPRSerialSendEx(lprHandle, lprserial, strclear, Convert.ToInt16(strclear.Length / 2));//清除LED内存               

                    In_axVZLPRClientCtrl.VzLPRSerialSendEx(lprHandle, lprserial, strdelpic, Convert.ToInt16(strdelpic.Length / 2));//删除图标控件
                    Thread.Sleep(500);
                    In_axVZLPRClientCtrl.VzLPRSerialSendEx(lprHandle, lprserial, strcolbgCode, Convert.ToInt16(strcolbgCode.Length / 2));//设置背景
                    Thread.Sleep(500);
                    In_axVZLPRClientCtrl.VzLPRSerialSendEx(lprHandle, lprserial, strcolCode, Convert.ToInt16(strcolCode.Length / 2));//设置前景
                    Thread.Sleep(500);
                    In_axVZLPRClientCtrl.VzLPRSerialSendEx(lprHandle, lprserial, strshowicon, Convert.ToInt16(strshowicon.Length / 2));//设置显示图标
                    Thread.Sleep(1000);
                    In_axVZLPRClientCtrl.VzLPRSerialSendEx(lprHandle, lprserial, strpic, Convert.ToInt16(strpic.Length / 2));//建立图片控件
                    Thread.Sleep(500);
                    In_axVZLPRClientCtrl.VzLPRSerialSendEx(lprHandle, lprserial, straddpic, Convert.ToInt16(straddpic.Length / 2));//显示箭头
                    Thread.Sleep(500);
                    In_axVZLPRClientCtrl.VzLPRSerialSendEx(lprHandle, lprserial, stradddate, Convert.ToInt16(stradddate.Length));
                    Thread.Sleep(1000);
                    In_axVZLPRClientCtrl.VzLPRSerialSendEx(lprHandle, lprserial, straddtime, Convert.ToInt16(straddtime.Length));
                    Thread.Sleep(1000);
                    In_axVZLPRClientCtrl.VzLPRSerialSendEx(lprHandle, lprserial, strshowdatecode, Convert.ToInt16(strshowdatecode.Length));
                    Thread.Sleep(1000);
                    In_axVZLPRClientCtrl.VzLPRSerialSendEx(lprHandle, lprserial, strshowtimecode, Convert.ToInt16(strshowtimecode.Length));
                    In_axVZLPRClientCtrl.VzLPRSerialStopEx(lprHandle, lprserial);
               
            }
            else
            {

             
                    int lprserial = Out_axVZLPRClientCtrl.VzLPRSerialStartEx(lprHandle, 1);

                    Out_axVZLPRClientCtrl.VzLPRSerialSendEx(lprHandle, lprserial, strclear, Convert.ToInt16(strclear.Length / 2));//清除LED内存               

                    Out_axVZLPRClientCtrl.VzLPRSerialSendEx(lprHandle, lprserial, strdelpic, Convert.ToInt16(strdelpic.Length / 2));//删除图标控件
                    Thread.Sleep(500);
                    Out_axVZLPRClientCtrl.VzLPRSerialSendEx(lprHandle, lprserial, strcolbgCode, Convert.ToInt16(strcolbgCode.Length / 2));//设置背景
                    Thread.Sleep(500);
                    Out_axVZLPRClientCtrl.VzLPRSerialSendEx(lprHandle, lprserial, strcolCode, Convert.ToInt16(strcolCode.Length / 2));//设置前景
                    Thread.Sleep(500);
                    Out_axVZLPRClientCtrl.VzLPRSerialSendEx(lprHandle, lprserial, strshowicon, Convert.ToInt16(strshowicon.Length / 2));//设置显示图标
                    Thread.Sleep(1000);
                    Out_axVZLPRClientCtrl.VzLPRSerialSendEx(lprHandle, lprserial, strpic, Convert.ToInt16(strpic.Length / 2));//建立图片控件
                    Thread.Sleep(500);
                    Out_axVZLPRClientCtrl.VzLPRSerialSendEx(lprHandle, lprserial, straddpic, Convert.ToInt16(straddpic.Length / 2));//显示箭头
                    Thread.Sleep(500);
                    Out_axVZLPRClientCtrl.VzLPRSerialSendEx(lprHandle, lprserial, stradddate, Convert.ToInt16(stradddate.Length));
                    Thread.Sleep(1000);
                    Out_axVZLPRClientCtrl.VzLPRSerialSendEx(lprHandle, lprserial, straddtime, Convert.ToInt16(straddtime.Length));
                    Thread.Sleep(1000);
                    Out_axVZLPRClientCtrl.VzLPRSerialSendEx(lprHandle, lprserial, strshowdatecode, Convert.ToInt16(strshowdatecode.Length));
                    Thread.Sleep(1000);
                    Out_axVZLPRClientCtrl.VzLPRSerialSendEx(lprHandle, lprserial, strshowtimecode, Convert.ToInt16(strshowtimecode.Length));
                    Out_axVZLPRClientCtrl.VzLPRSerialStopEx(lprHandle, lprserial);
                


            }

            //
        }



        /// <summary>
        /// 初始化配置
        /// </summary>
        private void InitSet()
        {
            inbaseSetModel = new BaseSet();
            outbaseSetModel = new BaseSet();

        }


        /// <summary>
        /// 顶部显示标题和时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void titleTime_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.GetDateTimeFormats('f')[0].ToString();
            System.Drawing.Color[] colors = new Color[5];
            colors[0] = System.Drawing.Color.DarkRed;
            colors[1] = System.Drawing.Color.DarkSlateBlue;
            colors[2] = System.Drawing.Color.DarkTurquoise;
            colors[3] = System.Drawing.Color.Firebrick;
            colors[4] = System.Drawing.Color.Fuchsia;
            if (this.titleTime.Interval % 10 == 1 || this.titleTime.Interval % 10 == 6)
            {
                this.lblTitle.ForeColor = colors[0];
            }
            else if (this.titleTime.Interval % 10 == 2 || this.titleTime.Interval % 10 == 7)
            {
                this.lblTitle.ForeColor = colors[1];
            }
            else if (this.titleTime.Interval % 10 == 3 || this.titleTime.Interval % 10 == 8)
            {
                this.lblTitle.ForeColor = colors[0];
            }
            else if (this.titleTime.Interval % 10 == 4 || this.titleTime.Interval % 10 == 9)
            {
                this.lblTitle.ForeColor = colors[1];
            }
            else
            {
                this.lblTitle.ForeColor = colors[1];
            }
            titleTime.Interval++;

        }
     

        /// <summary>
        /// 向入口显示屏发送内容
        /// </summary>
        public void SendInContent(string strcontent)
        {
            if (strcontent.Contains("车位"))
            {

            }
            else
            {

            }
        }

        /// <summary>
        /// 向出口显示屏发送其它内容
        /// </summary>
        /// <param name="content"></param>
        public void SendOutContent(string strcontent)
        {
            if (!strcontent.Contains("平安"))
            {



            }
            else
            {

            }
        }

        /// <summary>
        /// 向出口显示屏发送车牌信息
        /// </summary>
        /// <param name="content"></param>
        public void SendOutPContent(string strpcontent)
        {



        }

        private string content = "欢迎光临";

        /// <summary>
        /// 入场播报
        /// </summary>
        public void ThInPlay(object content)
        {
            try
            {
                SendInContent(content.ToString());
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// 显示车位数
        /// </summary>
        public void PlayBerth()
        {
            string SendText = "", SendShow = "";
            int? icontRest = parkInfoModel.BerthCountRest;
            string Data = null;
            if (icontRest != null && icontRest > 0)
            {
                Data = ToHex("余位" + icontRest.ToString(), "gb2312", false);
              //  iniinfo.IsOpenNotConfirm = "True";
                InCarAutoOpen = false;
            }
            else
            {
                Data = ToHex("车位已满", "gb2312", false);
              //  iniinfo.IsOpenNotConfirm = "False";
                InCarAutoOpen = true;
            }
            
            string Datalen = "";
            string LedControl, ledaddr;
            int Serial = 0;
            string SerialAddr;//串口号
            //入口一
            if (OnelprHandle > 0)
            {
                if (OneLedType == "OneLed")
                {
                    Datalen = (32 + Data.Length / 2).ToString("X2");
                    Serial = Convert.ToInt32(OneAddr);
                    ledaddr = (32 + Serial).ToString("X2");
                    LedControl = SyOneControl;
                    SendText = "02" + ledaddr + "25" + "CD" + "0C" + LedControl + Datalen + Data + "03";
                    SendShow = "02" + ledaddr + "24" + "CD" + "03";
                    int lprserial = In_axVZLPRClientCtrl.VzLPRSerialStartEx(OnelprHandle, 1);
                    In_axVZLPRClientCtrl.VzLPRSerialSendEx(OnelprHandle, lprserial, SendText, 255);
                    In_axVZLPRClientCtrl.VzLPRSerialSendEx(OnelprHandle, lprserial, SendShow, 255);
                    In_axVZLPRClientCtrl.VzLPRSerialStopEx(OnelprHandle, lprserial);
                }
                if (OneLedType == "AdLed")
                {
                    SerialAddr = Convert.ToInt16(OneAddr).ToString("X2");
                    string WinAddr = Convert.ToInt16(SyOneWinNo).ToString("X2");//窗口地址
                 //   string FileId = Convert.ToInt16(0).ToString("X2");//文件号
                    string strtext = Data;
                    string textlen = (strtext.Length / 2).ToString("X2");
                    string strConrol = SyOneControl;

                    //资料上说是19，实际是有20个控件制符。
                    // string strlr = SerialAddr + "64FFFF67" + (20 + strtext.Length / 2).ToString("X2") + WinAddr + FileId + "0C" + strConrol + textlen + "00" + strtext;
                     string strlr = SerialAddr + "64FFFF62" + (19 + strtext.Length / 2).ToString("X2") + WinAddr + strConrol + textlen + "00" + strtext;

                    SendText = strlr + crcforebit(LedFunc.CalculateCrc16(LedFunc.strToToHexByte(strlr)).ToString("X2"));
                    SendShow = SerialAddr + "64FFFF01007067";
                    int lprserial = In_axVZLPRClientCtrl.VzLPRSerialStartEx(OnelprHandle, 1);
                    Thread.Sleep(500);
                    In_axVZLPRClientCtrl.VzLPRSerialSendEx(OnelprHandle, lprserial, SendText, 255);
                    In_axVZLPRClientCtrl.VzLPRSerialSendEx(OnelprHandle, lprserial, SendShow, 255);
                    In_axVZLPRClientCtrl.VzLPRSerialStopEx(OnelprHandle, lprserial);
               }
            }
            //入口二
            if (ThreelprHandle > 0)
            {
                if (ThreeLedType == "OneLed")
                {
                    Datalen = (32 + Data.Length / 2).ToString("X2");
                    Serial = Convert.ToInt32(ThreeAddr);
                    ledaddr = (32 + Serial).ToString("X2");
                    LedControl = SyThreeControl;
                    SendText = "02" + ledaddr + "25" + "CD" + "0C" + LedControl + Datalen + Data + "03";
                    SendShow = "02" + ledaddr + "24" + "CD" + "03";
                    int lprserial = In_ThreeaxVZLPRClientCtrl.VzLPRSerialStartEx(ThreelprHandle, 1);
                    Thread.Sleep(500);
                    In_ThreeaxVZLPRClientCtrl.VzLPRSerialSendEx(ThreelprHandle, lprserial, SendText, 255);
                    In_ThreeaxVZLPRClientCtrl.VzLPRSerialSendEx(ThreelprHandle, lprserial, SendShow, 255);
                    In_ThreeaxVZLPRClientCtrl.VzLPRSerialStopEx(ThreelprHandle, lprserial);
                }
                if (ThreeLedType == "AdLed")
                {
                   
                    SerialAddr = Convert.ToInt16(ThreeAddr).ToString("X2");
                    string WinAddr = Convert.ToInt16(SyThreeWinNo).ToString("X2");//窗口地址
                  //  string FileId = Convert.ToInt16(0).ToString("X2");//文件号
                    string strtext = Data;
                    string textlen = (strtext.Length / 2).ToString("X2");
                    string strConrol = SyThreeControl;

                    //资料上说是19，实际是有20个控件制符。
                    // string strlr = SerialAddr + "64FFFF67" + (20 + strtext.Length / 2).ToString("X2") + WinAddr + FileId + "0C" + strConrol + textlen + "00" + strtext;
                    string strlr = SerialAddr + "64FFFF62" + (19 + strtext.Length / 2).ToString("X2") + WinAddr + strConrol + textlen + "00" + strtext;

                    SendText = strlr + crcforebit(LedFunc.CalculateCrc16(LedFunc.strToToHexByte(strlr)).ToString("X2"));
                    SendShow = SerialAddr + "64FFFF01007067";
                    int lprserial = In_ThreeaxVZLPRClientCtrl.VzLPRSerialStartEx(OnelprHandle, 1);
                    Thread.Sleep(500);
                    In_ThreeaxVZLPRClientCtrl.VzLPRSerialSendEx(OnelprHandle, lprserial, SendText, 255);
                    In_ThreeaxVZLPRClientCtrl.VzLPRSerialSendEx(OnelprHandle, lprserial, SendShow, 255);
                    In_ThreeaxVZLPRClientCtrl.VzLPRSerialStopEx(OnelprHandle, lprserial);
                }
            }

            //入口三
            if (FourlprHandle > 0)
            {
                if (FourLedType == "OneLed")
                {
                    Datalen = (32 + Data.Length / 2).ToString("X2");
                    Serial = Convert.ToInt32(FourAddr);
                    ledaddr = (32 + Serial).ToString("X2");
                    LedControl = SyThreeControl;
                    SendText = "02" + ledaddr + "25" + "CD" + "0C" + LedControl + Datalen + Data + "03";
                    SendShow = "02" + ledaddr + "24" + "CD" + "03";
                    int lprserial = In_FouraxVZLPRClientCtrl.VzLPRSerialStartEx(FourlprHandle, 1);
                    Thread.Sleep(500);
                    In_FouraxVZLPRClientCtrl.VzLPRSerialSendEx(FourlprHandle, lprserial, SendText, 255);
                    In_FouraxVZLPRClientCtrl.VzLPRSerialSendEx(FourlprHandle, lprserial, SendShow, 255);
                    In_FouraxVZLPRClientCtrl.VzLPRSerialStopEx(FourlprHandle, lprserial);
                }
                if (FourLedType == "AdLed")
                {
                    SerialAddr = Convert.ToInt16(ThreeAddr).ToString("X2");
                    string WinAddr = Convert.ToInt16(SyFourWinNo).ToString("X2");//窗口地址
                                                                                  //  string FileId = Convert.ToInt16(0).ToString("X2");//文件号
                    string strtext = Data;
                    string textlen = (strtext.Length / 2).ToString("X2");
                    string strConrol = SyFourControl;

                    //资料上说是19，实际是有20个控件制符。
                    // string strlr = SerialAddr + "64FFFF67" + (20 + strtext.Length / 2).ToString("X2") + WinAddr + FileId + "0C" + strConrol + textlen + "00" + strtext;
                    string strlr = SerialAddr + "64FFFF62" + (20 + strtext.Length / 2).ToString("X2") + WinAddr + strConrol + textlen + "00" + strtext;

                    SendText = strlr + crcforebit(LedFunc.CalculateCrc16(LedFunc.strToToHexByte(strlr)).ToString("X2"));
                    SendShow = SerialAddr + "64FFFF01007067";
                    int lprserial = In_FouraxVZLPRClientCtrl.VzLPRSerialStartEx(FourlprHandle, 1);
                    Thread.Sleep(500);
                    In_FouraxVZLPRClientCtrl.VzLPRSerialSendEx(FourlprHandle, lprserial, SendText, 255);
                    In_FouraxVZLPRClientCtrl.VzLPRSerialSendEx(FourlprHandle, lprserial, SendShow, 255);
                    In_FouraxVZLPRClientCtrl.VzLPRSerialStopEx(FourlprHandle, lprserial);
                }
            }


        }


        /// <summary>
        /// 入场播报
        /// </summary>
        public void InPlay(string onestring, string strcontent)
        {

            string plate;
            string stop = onestring.Substring(onestring.Length - 4);

            if (stop == "stop")
            {
                plate = onestring.Substring(0, onestring.Length - 4);
                if (OneLedType == "OneLed") //显示屏类型
                {
                    string strControl = "2020FF20";
                    OneSendLed(OneLedAddr1, plate, OneLedControlchar1, "-1", OneLedShowType1);//第一块屏显示 
                    Thread.Sleep(500);
                    OneSendLed(OneLedAddr2, strcontent, strControl, "-1","3");//第二块屏显示
               }
                if (OneLedType == "AdLed")
                {
                    string strControl = "01000002FF020301FF00000000000000"; ;
                    OneSendLed(OneAddr, plate, OneLedControlchar1, OneLedWinNo1, OneLedShowType1); //第一块屏显示
                    Thread.Sleep(500);
                    OneSendLed(OneAddr, strcontent, strControl, OneLedWinNo2, "3");//第二块屏显示

                }
            }
            else
            {
                plate = onestring;
                if (OneLedType == "OneLed") //显示屏类型
                {
                    OneSendLed(OneLedAddr1, plate, OneLedControlchar1, "-1", OneLedShowType1);//第一块屏显示 
                    Thread.Sleep(500);
                    OneSendLed(OneLedAddr2, strcontent, OneLedControlchar2, "-1", OneLedShowType2);//第二块屏显示
                }
                if (OneLedType == "AdLed")
                {
                    OneSendLed(OneAddr, plate, OneLedControlchar1, OneLedWinNo1, OneLedShowType1); //第一块屏显示
                    Thread.Sleep(500);
                    OneSendLed(OneAddr, strcontent, OneLedControlchar2, OneLedWinNo2, OneLedShowType2);//第二块屏显示

                }

            }
        
    
        }
        
        /// <summary>
        /// 入场播报 三
        /// </summary>
        public void ThreePlay(string onestring, string strcontent)
        {
            string plate = onestring;
            if (ThreeLedType == "OneLed") //显示屏类型
            {
                ThreeSendLed(ThreeLedAddr1, plate, ThreeLedControlchar1, "-1", ThreeLedShowType1);//第一块屏显示 
                Thread.Sleep(500);
                ThreeSendLed(ThreeLedAddr2, strcontent, ThreeLedControlchar2, "-1", ThreeLedShowType2);//第二块屏显示
            }
            if (ThreeLedType == "AdLed")
            {
                ThreeSendLed(ThreeAddr, plate, ThreeLedControlchar1, ThreeLedWinNo1, ThreeLedShowType1); //第一块屏显示
                Thread.Sleep(500);
                ThreeSendLed(ThreeAddr, strcontent, ThreeLedControlchar2, ThreeLedWinNo2,ThreeLedShowType2);//第二块屏显示

            }
            
        }


        /// <summary>
        /// 出场播报五
        /// </summary>
        public void FivePlay(string onestring, string strcontent)
        {
            string plate = onestring;
            if (FiveLedType == "OneLed") //显示屏类型
            {
                FiveSendLed(FiveLedAddr1, plate, FiveLedControlchar1, "-1", FiveLedShowType1);//第一块屏显示 
                Thread.Sleep(500);
                FiveSendLed(FiveLedAddr2, strcontent, FiveLedControlchar2, "-1", FiveLedShowType2);//第二块屏显示
            }
            if (FiveLedType == "AdLed")
            {
                FiveSendLed(FiveAddr, plate, FiveLedControlchar1, FiveLedWinNo1, FiveLedShowType1); //第一块屏显示
                Thread.Sleep(500);
                FiveSendLed(FiveAddr, strcontent, FiveLedControlchar2, FiveLedWinNo2, FiveLedShowType2);//第二块屏显示

            }

        }

        public void FiveSendLed(string Ledaddr, string content, string ledcontrolchar, string LedWinNo, string LedShowType)
        {

            string showtext = ToHex(content, "gb2312", false); ;
            string showtextlen = (32 + showtext.Length / 2).ToString("X2"); ;
            string sendgb = "00", showgb = "00", LedSerail = "1";
            short sendgblen = 0, showgblen = 0;
            if (LedWinNo == "-1")
            {
                LedSerail = (32 + Convert.ToInt32(Ledaddr)).ToString("X2");
                sendgb = "02" + LedSerail + "25E90C" + ledcontrolchar + showtextlen + showtext + "03";
                showgb = "02" + LedSerail + "24E9" + "03";
                sendgblen = Convert.ToInt16(sendgb.Length / 2);
                showgblen = Convert.ToInt16(showgb.Length / 2);

            }
            else
            {
                LedSerail = (Convert.ToInt32(Ledaddr)).ToString("X2");
                if (content.Length < 10)
                {


                    string showlen = (showtext.Length / 2 + 19).ToString("X2");
                    sendgb = LedSerail + "64FFFF62" + showlen + Convert.ToInt16(LedWinNo).ToString("X2") + ledcontrolchar + showtextlen + "00" + showtext;
                    showgb = LedFunc.CalculateCrc16(LedFunc.strToToHexByte(sendgb)).ToString("X2");
                    showgb = crcforebit(showgb);
                    sendgb = sendgb + showgb;

                    sendgblen = Convert.ToInt16(sendgb.Length / 2);
                    showgblen = Convert.ToInt16(showgb.Length / 2);
                }
                else
                {

                    string showtemp = Convert.ToInt16(LedWinNo).ToString("X2") + ledcontrolchar + showtextlen + "00" + showtext + "0A" + showtext + "0700";
                    string showlen = (showtemp.Length / 2).ToString("X2");

                    sendgb = LedSerail + "64FFFF6D" + showlen + showtemp;
                    showgb = LedFunc.CalculateCrc16(LedFunc.strToToHexByte(sendgb)).ToString("X2");
                    showgb = crcforebit(showgb);

                    sendgb = sendgb + showgb;



                }
                showgb = LedSerail + "64FFFF01007067";

                sendgblen = Convert.ToInt16(sendgb.Length / 2);
                showgblen = Convert.ToInt16(showgb.Length / 2);
            }


            try
            {

                if (FivelprHandle > 0)
                {

                    int lprSerail = Out_FiveaxVZLPRClientCtrl.VzLPRSerialStartEx(FivelprHandle, 1);
                    Out_FiveaxVZLPRClientCtrl.VzLPRSerialSendEx(FivelprHandle, lprSerail, sendgb, sendgblen);
                    Out_FiveaxVZLPRClientCtrl.VzLPRSerialSendEx(FivelprHandle, lprSerail, showgb, showgblen);
                    Out_FiveaxVZLPRClientCtrl.VzLPRSerialStopEx(FivelprHandle, lprSerail);
                }
            }
            catch
            {

            }



        }

        public void ThreeSendLed(string Ledaddr, string content, string ledcontrolchar, string LedWinNo, string LedShowType)
        {

            string showtext = ToHex(content, "gb2312", false); ;
            string showtextlen = (32 + showtext.Length / 2).ToString("X2"); ;
            string sendgb = "00", showgb = "00", LedSerail = "1";
            short sendgblen = 0, showgblen = 0;
            if (LedWinNo == "-1")
            {
                LedSerail = (32 + Convert.ToInt32(Ledaddr)).ToString("X2");
                sendgb = "02" + LedSerail + "25E90C" + ledcontrolchar + showtextlen + showtext + "03";
                showgb = "02" + LedSerail + "24E9" + "03";
                sendgblen = Convert.ToInt16(sendgb.Length / 2);
                showgblen = Convert.ToInt16(showgb.Length / 2);

            }
            else
            {
                LedSerail = (Convert.ToInt32(Ledaddr)).ToString("X2");
                if (content.Length < 10)
                {


                    string showlen = (showtext.Length / 2 + 19).ToString("X2");
                    sendgb = LedSerail + "64FFFF62" + showlen + Convert.ToInt16(LedWinNo).ToString("X2") + ledcontrolchar + showtextlen + "00" + showtext;
                    showgb = LedFunc.CalculateCrc16(LedFunc.strToToHexByte(sendgb)).ToString("X2");
                    showgb = crcforebit(showgb);
                    sendgb = sendgb + showgb;

                    sendgblen = Convert.ToInt16(sendgb.Length / 2);
                    showgblen = Convert.ToInt16(showgb.Length / 2);
                }
                else
                {

                    string showtemp = Convert.ToInt16(LedWinNo).ToString("X2") + ledcontrolchar + showtextlen + "00" + showtext + "0A" + showtext + "0700";
                    string showlen = (showtemp.Length / 2).ToString("X2");

                    sendgb = LedSerail + "64FFFF6D" + showlen + showtemp;
                    showgb = LedFunc.CalculateCrc16(LedFunc.strToToHexByte(sendgb)).ToString("X2");
                    showgb = crcforebit(showgb);
                    
                    sendgb = sendgb + showgb;



                }
                showgb = LedSerail + "64FFFF01007067";

                sendgblen = Convert.ToInt16(sendgb.Length / 2);
                showgblen = Convert.ToInt16(showgb.Length / 2);
            }


            try
            {

                if (ThreelprHandle > 0)
                {

                    int lprSerail = In_ThreeaxVZLPRClientCtrl.VzLPRSerialStartEx(ThreelprHandle, 1);
                    In_ThreeaxVZLPRClientCtrl.VzLPRSerialSendEx(ThreelprHandle, lprSerail, sendgb, sendgblen);
                    In_ThreeaxVZLPRClientCtrl.VzLPRSerialSendEx(ThreelprHandle, lprSerail, showgb, showgblen);
                    In_ThreeaxVZLPRClientCtrl.VzLPRSerialStopEx(ThreelprHandle, lprSerail);
                }
            }
            catch
            {

            }



        }

        private string crcforebit(string str)
        {
            int istrlen = str.Length;
            for (int i = 0; i < 4 - istrlen; i++)
            {
                str = "0" + str;

            }
            return str;
        }


        /// <summary>
        /// 入场播报四
        /// </summary>
        public void FourPlay(string onestring, string strcontent)
        {
            string plate = onestring;
            if (FourLedType == "OneLed") //显示屏类型
            {
                FourSendLed(FourLedAddr1, plate, FourLedControlchar1, "-1", FourLedShowType1);//第一块屏显示 
                Thread.Sleep(500);
                FourSendLed(FourLedAddr2, strcontent, FourLedControlchar2, "-1", FourLedShowType2);//第二块屏显示
            }
            if (FourLedType == "AdLed")
            {
                FourSendLed(FourAddr, plate, FourLedControlchar1, FourLedWinNo1, FourLedShowType1); //第一块屏显示
                Thread.Sleep(500);
                FourSendLed(FourAddr, strcontent, FourLedControlchar2, FourLedWinNo2, FourLedShowType2);//第二块屏显示

            }
        }

        public void FourSendLed(string Ledaddr, string content, string ledcontrolchar, string LedWinNo, string LedShowType )
        {

            string showtext = ToHex(content, "gb2312", false); ;
            string showtextlen = (32 + showtext.Length / 2).ToString("X2"); ;
            string sendgb = "00", showgb = "00", LedSerail = "1";
            short sendgblen = 0, showgblen = 0;
            if (LedWinNo == "-1")
            {


                LedSerail = (32 + Convert.ToInt32(Ledaddr)).ToString("X2");

                sendgb = "02" + LedSerail + "25E90C" + ledcontrolchar + showtextlen + showtext + "03";
                showgb = "02" + LedSerail + "24E9" + "03";
                sendgblen = Convert.ToInt16(sendgb.Length / 2);
                showgblen = Convert.ToInt16(showgb.Length / 2);

            }
            else
            {
                LedSerail = (Convert.ToInt32(Ledaddr)).ToString("X2");
                if (content.Length < 10)
                {


                    string showlen = (showtext.Length / 2 + 19).ToString("X2");
                    sendgb = LedSerail + "64FFFF62" + showlen + Convert.ToInt16(LedWinNo).ToString("X2") + ledcontrolchar + showtextlen + "00" + showtext;
                    showgb = LedFunc.CalculateCrc16(LedFunc.strToToHexByte(sendgb)).ToString("X2");
                    sendgb = sendgb + showgb;

                    sendgblen = Convert.ToInt16(sendgb.Length / 2);
                    showgblen = Convert.ToInt16(showgb.Length / 2);
                }
                else
                {

                    string showtemp = Convert.ToInt16(LedWinNo).ToString("X2") + ledcontrolchar + showtextlen + "00" + showtext + "0A" + showtext + "0700";
                    string showlen = (showtemp.Length / 2).ToString("X2");

                    sendgb = LedSerail + "64FFFF6D" + showlen + showtemp;
                    string  sendgbcrc = LedFunc.CalculateCrc16(LedFunc.strToToHexByte(sendgb)).ToString("X2");
                    sendgb = sendgb + crcforebit(sendgbcrc);
                }
                showgb = LedSerail + "64FFFF01007067";
                sendgblen = Convert.ToInt16(sendgb.Length / 2);
                showgblen = Convert.ToInt16(showgb.Length / 2);
            }


            try
            {

                if (FourlprHandle > 0)
                {

                    int lprSerail = In_FouraxVZLPRClientCtrl.VzLPRSerialStartEx(FourlprHandle, 1);
                    Thread.Sleep(500);
                    In_FouraxVZLPRClientCtrl.VzLPRSerialSendEx(FourlprHandle, lprSerail, sendgb, sendgblen);
                    In_FouraxVZLPRClientCtrl.VzLPRSerialSendEx(FourlprHandle, lprSerail, showgb, showgblen);
                    In_FouraxVZLPRClientCtrl.VzLPRSerialStopEx(FourlprHandle, lprSerail);
                }
            }
            catch
            {

            }



        }



        public void OneSendLed(string Ledaddr, string content,string ledcontrolchar,string LedWinNo,string LedShowType)
        {

            string showtext = ToHex(content, "gb2312", false); ;
            string showtextlen = (32 + showtext.Length / 2).ToString("X2"); ;
            string sendgb ="00", showgb="00", LedSerail="1";
            short sendgblen = 0, showgblen = 0;
            if (LedWinNo == "-1")
            {
                LedSerail = (32 + Convert.ToInt32(Ledaddr)).ToString("X2");
                sendgb = "02" + LedSerail + "25E90C" + ledcontrolchar + showtextlen + showtext + "03";
                showgb = "02" + LedSerail + "24E9" + "03";
                sendgblen = Convert.ToInt16(sendgb.Length/2);
                showgblen = Convert.ToInt16(showgb.Length/2);

            }
            else
            {
                LedSerail = (Convert.ToInt32(Ledaddr)).ToString("X2");
                if (LedShowType=="1")
                {
                    string showlen = (showtext.Length / 2 + 19).ToString("X2");
                    sendgb = LedSerail + "64FFFF62" + showlen + Convert.ToInt16(LedWinNo).ToString("X2") + ledcontrolchar + showtextlen + "00" + showtext;
                    showgb = LedFunc.CalculateCrc16(LedFunc.strToToHexByte(sendgb)).ToString("X2");
                    sendgb = sendgb + showgb;
                    sendgblen = Convert.ToInt16(sendgb.Length / 2);
                    showgblen = Convert.ToInt16(showgb.Length / 2);
                }
                else
                {
                  
                    string showtemp = Convert.ToInt16(LedWinNo).ToString("X2") + ledcontrolchar + showtextlen + "00" + showtext + "0A" + showtext + "0700";
                    string showlen = (showtemp.Length / 2).ToString("X2");

                    sendgb = LedSerail + "64FFFF6D" + showlen + showtemp;
                    showgb = LedFunc.CalculateCrc16(LedFunc.strToToHexByte(sendgb)).ToString("X2");
                    showgb = crcforebit(showgb);
                    sendgb = sendgb + showgb;
                }
                showgb = LedSerail + "64FFFF01007067";
                sendgblen = Convert.ToInt16(sendgb.Length / 2);
                showgblen = Convert.ToInt16(showgb.Length / 2);
            }
            try
            {
                if (OnelprHandle > 0)
                {
                     int lprSerail = In_axVZLPRClientCtrl.VzLPRSerialStartEx(OnelprHandle, 1);
                     Thread.Sleep(500);
                     In_axVZLPRClientCtrl.VzLPRSerialSendEx(OnelprHandle, lprSerail, sendgb, sendgblen);
                     In_axVZLPRClientCtrl.VzLPRSerialSendEx(OnelprHandle, lprSerail, showgb, showgblen);
                     In_axVZLPRClientCtrl.VzLPRSerialStopEx(OnelprHandle, lprSerail);
                }
            }
            catch
            {

            }



        }

        public void OutPlay(string onestring, string strcontent)
        {

            string plate;
            string stop = onestring.Substring(onestring.Length - 4);

            if (stop == "stop")
            {
                plate = onestring.Substring(0, onestring.Length - 4);
                if (TwoLedType == "OneLed") //显示屏类型
                {
                    string strControl= "2020FF20";
                    TwoSendLed(TwoLedAddr1, plate, TwoLedControlchar1, "-1", TwoLedShowType1);//第一块屏显示 
                    Thread.Sleep(500);
                    TwoSendLed(TwoLedAddr2, strcontent, strControl, "-1", "3");//第二块屏显示
                }
                if (TwoLedType == "AdLed")
                {
                    string strControl= "01000002FF020301FF00000000000000";
                    TwoSendLed(TwoAddr, plate, TwoLedControlchar1, TwoLedWinNo1, TwoLedShowType1); //第一块屏显示
                    Thread.Sleep(500);
                    TwoSendLed(TwoAddr, strcontent, strControl,TwoLedWinNo2, "3");//第二块屏显示

                }
            }
            else
            {
                plate = onestring;
                if (TwoLedType == "OneLed") //显示屏类型
                {
                    TwoSendLed(TwoLedAddr1, plate, TwoLedControlchar1, "-1", TwoLedShowType1);//第一块屏显示 
                    Thread.Sleep(500);
                    TwoSendLed(TwoLedAddr2, strcontent, TwoLedControlchar2, "-1", TwoLedShowType2);//第二块屏显示
                }
                if (TwoLedType == "AdLed")
                {
                    TwoSendLed(TwoAddr, plate, TwoLedControlchar1, TwoLedWinNo1, TwoLedShowType1); //第一块屏显示
                    Thread.Sleep(500);
                    TwoSendLed(TwoAddr, strcontent, TwoLedControlchar2, TwoLedWinNo2, TwoLedShowType2);//第二块屏显示

                }

            }


        }
        public void TwoSendLed(string Ledaddr, string content,string ledcontrolchar,string LedWinNo, string LedShowType)
        {

         
            string showtext = ToHex(content, "gb2312", false); ;
            string showtextlen = (32 + showtext.Length / 2).ToString("X2"); ;
            string sendgb = "00", showgb = "00", LedSerail = "1";
            short sendgblen = 0, showgblen = 0;
            if (LedWinNo == "-1")
            {
                LedSerail = (32 + Convert.ToInt32(Ledaddr)).ToString("X2");
                sendgb = "02" + LedSerail + "25E90C" + ledcontrolchar + showtextlen + showtext + "03";
                showgb = "02" + LedSerail + "24E9" + "03";
                sendgblen = Convert.ToInt16(sendgb.Length / 2);
                showgblen = Convert.ToInt16(showgb.Length / 2);

            }
            else
            {
                LedSerail = (Convert.ToInt32(Ledaddr)).ToString("X2");
                if (LedShowType == "1")
                {
                    string showlen = (showtext.Length / 2 + 19).ToString("X2");
                    sendgb = LedSerail + "64FFFF62" + showlen + Convert.ToInt16(LedWinNo).ToString("X2") + ledcontrolchar + showtextlen + "00" + showtext;
                    string  sendgbcrc = LedFunc.CalculateCrc16(LedFunc.strToToHexByte(sendgb)).ToString("X2");
                    sendgb = sendgb + crcforebit(sendgbcrc);
                }
                else
                {
                    string showtemp = Convert.ToInt16(LedWinNo).ToString("X2") + ledcontrolchar + showtextlen + "00" + showtext + "0A" + showtext + "0700";
                    string showlen = (showtemp.Length / 2).ToString("X2");
                    sendgb = LedSerail + "64FFFF6D" + showlen + showtemp;
                    string sendgbcrc = LedFunc.CalculateCrc16(LedFunc.strToToHexByte(sendgb)).ToString("X2");
                    sendgb = sendgb + crcforebit(sendgbcrc);
                    sendgb = sendgb + showgb;
                }
                showgb = LedSerail + "64FFFF01007067";
                sendgblen = Convert.ToInt16(sendgb.Length / 2);
                showgblen = Convert.ToInt16(showgb.Length / 2);

            }
            try
            {
                if (TwolprHandle > 0)
                {
                    int lprSerail = Out_axVZLPRClientCtrl.VzLPRSerialStartEx(TwolprHandle, 1);
                    Thread.Sleep(500);
                    Out_axVZLPRClientCtrl.VzLPRSerialSendEx(TwolprHandle, lprSerail, sendgb, sendgblen);
                    Out_axVZLPRClientCtrl.VzLPRSerialSendEx(TwolprHandle, lprSerail, showgb, showgblen);
                    Out_axVZLPRClientCtrl.VzLPRSerialStopEx(TwolprHandle, lprSerail);
                }
            }
            catch
            {

            }



        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            oriPoint3 = e.Location;
        }

        private void panel4_DoubleClick(object sender, EventArgs e)
        {
            string strtitle;
            if (!isWin3)
            {
                groupPanel2.Controls.Clear();
                groupPanel2.Controls.Add(Out_FiveaxVZLPRClientCtrl);
                Out_FiveaxVZLPRClientCtrl.Dock = DockStyle.Fill;
                //groupPanel2.Controls.Add(panel4);
                //panel4.BringToFront();

                panel4.Controls.Clear();
                panel4.Controls.Add(Out_axVZLPRClientCtrl);
                Out_axVZLPRClientCtrl.Dock = DockStyle.Bottom;
                Out_axVZLPRClientCtrl.Size = new Size(96, 96);
                panel4.Controls.Add(lb_FiveName);
                strtitle = lb_FiveName.Text;
                lb_FiveName.Text = groupPanel2.Text;
                groupPanel2.Text = strtitle;

                panel4.BringToFront();
                lb_FiveName.BringToFront();
                Out_FiveaxVZLPRClientCtrl.BringToFront();
                isWin3 = true;

            }
            else
            {
                
                groupPanel2.Controls.Clear();
                groupPanel2.Controls.Add(Out_axVZLPRClientCtrl);
                Out_axVZLPRClientCtrl.Dock = DockStyle.Fill;
               // groupPanel2.Controls.Add(panel4);
               
                panel4.Controls.Clear();
                Out_FiveaxVZLPRClientCtrl.Dock = DockStyle.Bottom;
                Out_FiveaxVZLPRClientCtrl.Size = new Size(96, 96);
                panel4.Controls.Add(Out_FiveaxVZLPRClientCtrl);
                panel4.Controls.Add(lb_FiveName);

                strtitle = lb_FiveName.Text;
                lb_FiveName.Text = groupPanel2.Text;
                panel4.Controls.Add(lb_FiveName);
                groupPanel2.Text = strtitle;
             //   panel4.BringToFront();
                lb_FiveName.BringToFront();
                Out_axVZLPRClientCtrl.BringToFront();
                isWin3 = false;


            }
        }

        private void Out_FiveaxVZLPRClientCtrl_OnLPRPlateImgOut(object sender, AxVZLPRClientCtrlLib._DVZLPRClientCtrlEvents_OnLPRPlateImgOutEvent e)
        {
            picOutImg.Image = Image.FromFile(e.imagePath);
            outimgpath = e.imagePath;
            fiveImagepath = e.imagePath;
        }

        private void Out_FiveaxVZLPRClientCtrl_OnLPRPlateInfoOutEx(object sender, AxVZLPRClientCtrlLib._DVZLPRClientCtrlEvents_OnLPRPlateInfoOutExEvent e)
        {
            
            //  string tips; //提示信息
            DateTime outtime = DateTime.Now;
            string info = string.Empty;
            string custype = string.Empty;
            string cartype = string.Empty;
            string outcontent = "一路平安";

            int overday = iniinfo.OverDay;
            string time = string.Empty;
            DateTime intime;
            string parktime = string.Empty;
            decimal summoney = 0;
            string plateid = string.Empty;
            string chrageplaeid = string.Empty;

            //判断是否识别正确;
            if (Isplateid(e.license))
            {
                plateid = e.license;
                if (isOneOut(plateid))
                { 
                ChargeRecord chgrecord = GetRecordModel(plateid);
                //车辆类型
                if (chgrecord != null)
                {
                    if (!string.IsNullOrWhiteSpace(chgrecord.CarType))
                    {
                        cartype = chgrecord.CarType;
                    }
                    else
                    {
                        cartype = GetCarType(e.nType);
                    }

                }
                else
                {
                    cartype = GetCarType(e.nType);
                }
                //插入车辆出入记录表
                InsertIdentifyInfo(e.license, e.color, e.colorIndex, e.nType, e.confidence, e.bright, e.nDirection, e.time, e.carBright, e.carColor, e.imgPath, e.ip, e.resultType, outtime, "OutTime");
                info = "车牌" + plateid + ";车主类型:" + "{0}" + ";出场时间:" + outtime.ToString("HH:mm:ss");
                bool noInCar = !IsInnerCar(plateid);
                //固定车且不为内部车的情况
                if (GetFCustomer(plateid) != null && noInCar)
                {
                    //判断是否在有效果内，在有效期内
                    if (IsValCustomer(plateid))
                    {
                        //   如果是一户多车，则执行，否则直接出场。
                        if (str_MoveCar != "-1")
                        {

                            if (string.IsNullOrEmpty(GetInTime(plateid)))
                            {

                                if (str_MoveCar == "1")
                                {
                                    string getMovePlateId;
                                    getMovePlateId = GetMoveCarPlateId(plateid).Trim();//得到本户下未交费车辆信息
                                    chargeRecordModel = GetChargeModeByPlateId(getMovePlateId);
                                  //  #region 一户多车下，有另一辆车是临时车，所以在本车辆出库时将计算第二辆费用，并支付。
                                    if (chargeRecordModel != null)
                                    {

                                        time = chargeRecordModel.InTime.ToString();
                                        intime = Convert.ToDateTime(time);
                                        cartype = chargeRecordModel.CarType;
                                        summoney = CalulateFee(intime, cartype);
                                        //绑定数据
                                        TimeSpan span = outtime - intime;
                                        if (span.Days > 0)
                                        {
                                            parktime = span.Days + "天" + span.Hours + "小时" + span.Hours + "分钟";
                                        }
                                        else
                                        {
                                            parktime = span.Hours + "小时" + span.Minutes + "分钟";

                                        }

                                        string tips = "一户多车用户，车牌 【" + plateid + "】未记费，另一辆【" + getMovePlateId + "】已在本车场内，已达到记费条件，请交费。";
                                        MessageHelper.ShowTips(tips);

                                        frmCharge frmcharge = new frmCharge(getMovePlateId, cartype, intime, outtime, parktime, feeStandard,
                            summoney, fiveImagepath, Out_FiveaxVZLPRClientCtrl.Name);
                                        frmcharge.Owner = this;
                                        frmcharge.ShowDialog();
                                        custype = "一户多车";


                                        //更新数据库
                                        //1、更新收费记录表
                                        //2、固定车出场
                                        //3、回定车入场
                                        //4、如果设置第二次始终为临停车，则不进行结算操作

                                        if (frmcharge.DialogResult == DialogResult.OK)
                                        {
                                            OpenFiveDaozha();
                                            ShowInfo(string.Format(info, custype));
                                            //出场信息
                                            BindOutInfo(cameraTwoType, outtime.ToString("HH:mm:ss"), cartype, custype, e.license);
                                            //刷新泊位数量
                                            RefreshCount(CustomerConst.FCustomer, CustomerConst.PlusOperate);
                                            RefreshParkInfo();
                                            //刷新最新收费信息
                                            RefreshChargeInfo();
                                            //插入固定车出入记录表
                                            // InsertFCustomerInfo(e.license, e.color, intime, "", e.imgPath, "固定车辆", "in");
                                            InsertFCustomerInfo(getMovePlateId, e.color, outtime, "", e.imgPath, cartype, "out");
                                            InsertFCustomerInfo(getMovePlateId, e.color, outtime, e.imgPath, "", cartype, "in");
                                        }
                                        if (frmcharge.DialogResult == DialogResult.Cancel)
                                        {
                                            ShowInfo(string.Format(info, custype));
                                            //出场信息
                                            BindOutInfo(cameraOneType, outtime.ToString("HH:mm:ss"), cartype, custype, e.license);
                                            //刷新泊位数量
                                            RefreshCount(CustomerConst.FCustomer, CustomerConst.PlusOperate);
                                            RefreshParkInfo();
                                            //刷新最新收费信息
                                            RefreshChargeInfo();
                                            //插入固定车出入记录表
                                            // InsertFCustomerInfo(e.license, e.color, intime, "", e.imgPath, "固定车辆", "in");
                                            InsertFCustomerInfo(getMovePlateId, e.color, outtime, "", e.imgPath, cartype, "out");
                                            InsertFCustomerInfo(getMovePlateId, e.color, outtime, e.imgPath, "", cartype, "in");


                                        }

                                    }
                                    else
                                    {
                                        //自动开闸
                                        OpenFiveDaozha();
                                        custype = CustomerConst.FCustomer;
                                        ShowInfo(string.Format(info, custype));

                                        //播报

                                        string PlayText = "";
                                        if (iniinfo.FcarplayNo == "True")
                                        {
                                            PlayText = plateid + "," + outcontent;

                                        }
                                        else
                                        {
                                            PlayText = outcontent;


                                        }


                                        FivePlay(plateid, PlayText);

                                        //插入固定车出入记录表
                                        InsertFCustomerInfo(e.license, e.color, outtime, "", e.imgPath, "固定车辆", "out");
                                        //出场信息
                                        BindOutInfo(cameraTwoType, outtime.ToString("HH:mm:ss"), cartype, custype, e.license);
                                        //刷新泊位数量
                                        RefreshCount(CustomerConst.FCustomer, CustomerConst.PlusOperate);
                                        RefreshParkInfo();
                                        //刷新最新收费信息
                                        RefreshChargeInfo();
                                    }
                                  //  #endregion
                                }
                                if (str_MoveCar == "0")
                                {
                                    OpenFiveDaozha();

                                    string time1 = fCustomerModel.OverTime.ToString();
                                    TimeSpan timespan = Convert.ToDateTime(time1) - DateTime.Now;
                                    string lefttime = ((int)timespan.TotalDays).ToString();
                                    //自动开闸

                                    string PlayText = "";
                                    if (iniinfo.FcarplayNo == "True")
                                    {
                                        PlayText = plateid + "," + outcontent;

                                    }
                                    else
                                    {
                                        PlayText = outcontent;


                                    }


                                    if (Convert.ToInt32(lefttime) <= overday)
                                    {
                                        //播报
                                        FivePlay(plateid, plateid + ",剩余" + lefttime + "天,请交费，一路平安。");

                                    }
                                    else
                                    {

                                        //播报
                                        FivePlay(plateid, PlayText);

                                    }

                                    custype = CustomerConst.FCustomer;

                                    Thread thread = new Thread(new ParameterizedThreadStart(ShowInfo));
                                    string strInfo = string.Format(info, custype);
                                    thread.Start((object)strInfo);

                                    //  ShowInfo(string.Format(info, custype));

                                    //插入固定车出入记录表
                                    InsertFCustomerInfo(plateid, e.color, outtime, "", e.imgPath, "固定车辆", "out");
                                    //出场信息
                                    BindOutInfo(cameraTwoType, outtime.ToString("HH:mm:ss"), cartype, custype, plateid);
                                    //刷新泊位数量
                                    RefreshCount(CustomerConst.FCustomer, CustomerConst.PlusOperate);
                                    RefreshParkInfo();
                                    //刷新最新收费信息
                                    RefreshChargeInfo();


                                }
                            }
                            else
                            {

                                time = GetInTime(plateid);
                                intime = Convert.ToDateTime(time);
                                summoney = CalulateFee(intime, cartype);
                                TimeSpan timeSpan = outtime - intime;
                                parktime = string.Empty;
                                if (timeSpan.Days > 0)
                                {
                                    parktime = timeSpan.Days + "天" + timeSpan.Hours.ToString() + "小时" +
                                               timeSpan.Minutes.ToString() + "分钟";
                                }
                                else
                                {
                                    parktime = timeSpan.Hours.ToString() + "小时" +
                                               timeSpan.Minutes.ToString() + "分钟";
                                }
                                if (iniinfo.AutoOpen == "True" && summoney == 0)
                                {
                                    //自动开闸
                                    OpenFiveDaozha();
                                    //   custype = CustomerConst.FCustomer;
                                    custype = "一户多车";
                                    ShowInfo(string.Format(info, custype));
                                    //插入固定车出入记录表
                                    InsertFCustomerInfo(plateid, e.color, outtime, "", e.imgPath, "一户多车", "out");
                                    //出场信息
                                    BindOutInfo(cameraTwoType, outtime.ToString("HH:mm:ss"), cartype, custype, plateid);
                                    //刷新泊位数量
                                    RefreshCount(CustomerConst.FCustomer, CustomerConst.PlusOperate);
                                    RefreshParkInfo();
                                    //刷新最新收费信息
                                    RefreshChargeInfo();
                                }
                                else
                                {

                                    frmCharge frmcharge = new frmCharge(plateid, cartype, intime, outtime, parktime, feeStandard,
                     summoney, fiveImagepath, Out_FiveaxVZLPRClientCtrl.Name);
                                    frmcharge.Owner = this;
                                    frmcharge.ShowDialog();
                                    custype = "一户多车";

                                    if (frmcharge.DialogResult == DialogResult.OK)
                                    {
                                        OpenFiveDaozha();
                                        ShowInfo(string.Format(info, custype));
                                        //出场信息
                                        BindOutInfo(cameraTwoType, outtime.ToString("HH:mm:ss"), cartype, custype, plateid);
                                        //刷新泊位数量
                                        RefreshCount(CustomerConst.FCustomer, CustomerConst.PlusOperate);
                                        RefreshParkInfo();
                                        //刷新最新收费信息
                                        RefreshChargeInfo();
                                        //插入固定车出入记录表
                                        // InsertFCustomerInfo(e.license, e.color, intime, "", e.imgPath, "固定车辆", "in");
                                        InsertFCustomerInfo(plateid, e.color, outtime, e.imgPath, "", cartype, "out");
                                        InsertFCustomerInfo(plateid, e.color, outtime, "", e.imgPath, cartype, "in");
                                    }
                                    if (frmcharge.DialogResult == DialogResult.Cancel)
                                    {
                                        ShowInfo(string.Format(info, custype));
                                        //出场信息
                                        BindOutInfo(cameraOneType, outtime.ToString("HH:mm:ss"), cartype, custype, e.license);
                                        //刷新泊位数量
                                        RefreshCount(CustomerConst.FCustomer, CustomerConst.PlusOperate);
                                        RefreshParkInfo();
                                        //刷新最新收费信息
                                        RefreshChargeInfo();
                                        //插入固定车出入记录表
                                        // InsertFCustomerInfo(e.license, e.color, intime, "", e.imgPath, "固定车辆", "in");
                                        InsertFCustomerInfo(plateid, e.color, outtime, "", e.imgPath, cartype, "out");
                                        InsertFCustomerInfo(plateid, e.color, outtime, e.imgPath, "", cartype, "in");


                                    }

                                }




                            }


                        }
                        else
                        {
                            //自动开闸
                            OpenFiveDaozha();

                            string time1 = fCustomerModel.OverTime.ToString();
                            TimeSpan timespan = Convert.ToDateTime(time1) - DateTime.Now;
                            string lefttime = ((int)timespan.TotalDays).ToString();
                            //自动开闸


                            string PlayText = "";
                            if (iniinfo.FcarplayNo == "True")
                            {
                                PlayText = plateid + "," + outcontent;

                            }
                            else
                            {
                                PlayText = outcontent;


                            }

                            if (Convert.ToInt32(lefttime) <= overday)
                            {
                                //播报
                                FivePlay(plateid, plateid + ",剩余" + lefttime + "天,请交费，一路平安。");

                            }
                            else
                            {

                                //播报
                                FivePlay(plateid, PlayText);

                            }

                           custype = CustomerConst.FCustomer;
                            ShowInfo(string.Format(info, custype));
                            //插入固定车出入记录表
                            //  OutPlay(plateid, plateid + "," + outcontent);

                            InsertFCustomerInfo(e.license, e.color, outtime, "", e.imgPath, "固定车辆", "out");
                            //出场信息
                            BindOutInfo(cameraTwoType, outtime.ToString("HH:mm:ss"), cartype, custype, e.license);
                            //刷新泊位数量
                            RefreshCount(CustomerConst.FCustomer, CustomerConst.PlusOperate);
                            RefreshParkInfo();
                            //刷新最新收费信息
                            RefreshChargeInfo();


                        }


                    }

                    else
                    {
                        custype = CustomerConst.OFCustomer;

                        //   #region 过期客户收费

                        //过期固定客户收费
                        if (iniinfo.IsFCustomerFee == "True")
                        {
                            if (string.IsNullOrEmpty(GetInTime(plateid)))
                            {
                                MessageHelper.ShowTips("车辆【" + plateid + "】没有进场信息！");
                                return;
                            }
                            string outimgpath = e.imgPath;
                            intime = Convert.ToDateTime(GetInTime(plateid));
                            summoney = CalulateFee(intime, cartype);
                            TimeSpan timeSpan = outtime - intime;
                            parktime = string.Empty;
                            if (timeSpan.Days > 0)
                            {
                                parktime = timeSpan.Days + "天" + timeSpan.Hours.ToString() + "小时" +
                                           timeSpan.Minutes.ToString() + "分钟";
                            }
                            else
                            {
                                parktime = timeSpan.Hours.ToString() + "小时" +
                                           timeSpan.Minutes.ToString() + "分钟";
                            }
                            frmCharge frmcharge = new frmCharge(plateid, cartype, intime, outtime, parktime,
                                                                feeStandard,
                                                                summoney, outimgpath, Out_axVZLPRClientCtrl.Name);
                            frmcharge.Owner = this;
                            frmcharge.ShowDialog();
                            custype = frmcharge.CusType;
                            if (frmcharge.DialogResult == DialogResult.OK)
                            {
                                OpenFiveDaozha();
                                ShowInfo(string.Format(info, custype));
                                //出场信息
                                BindOutInfo(cameraTwoType, outtime.ToString("HH:mm:ss"), cartype, custype, plateid);
                                //刷新泊位数量
                                RefreshCount(CustomerConst.FCustomer, CustomerConst.PlusOperate);
                                RefreshParkInfo();
                                //刷新最新收费信息
                                RefreshChargeInfo();
                                //插入固定车出入记录表
                                InsertFCustomerInfo(plateid, e.color, intime, "", e.imgPath, "固定车辆", "in");
                            }
                            if (frmcharge.DialogResult == DialogResult.Cancel)
                            {
                                ShowInfo(string.Format(info, custype));
                                //出场信息
                                BindOutInfo(cameraOneType, outtime.ToString("HH:mm:ss"), cartype, custype, e.license);
                                //刷新泊位数量
                                RefreshCount(CustomerConst.FCustomer, CustomerConst.PlusOperate);
                                RefreshParkInfo();
                                //刷新最新收费信息
                                RefreshChargeInfo();
                                //插入固定车出入记录表
                                // InsertFCustomerInfo(e.license, e.color, intime, "", e.imgPath, "固定车辆", "in");
                                InsertFCustomerInfo(plateid, e.color, outtime, "", e.imgPath, cartype, "out");
                                //  InsertFCustomerInfo(plateid, e.color, outtime, e.imgPath, "", cartype, "in");


                            }

                        }


                        else
                        {

                            //播报
                            if (!string.IsNullOrEmpty(TwoLedAddr1))
                            {
                                FivePlay(plateid, plateid + "," + outcontent);
                            }
                            //开闸
                            OpenFiveDaozha();
                            ShowInfo(string.Format(info, custype));
                            //出场信息
                            BindOutInfo(cameraTwoType, outtime.ToString("HH:mm:ss"), cartype, custype, plateid);
                            //刷新泊位数量
                            RefreshCount(CustomerConst.FCustomer, CustomerConst.PlusOperate);
                            RefreshParkInfo();
                            //刷新最新收费信息
                            RefreshChargeInfo();
                            //插入固定车出入记录表
                            InsertFCustomerInfo(plateid, e.color, outtime, "", e.imgPath, "固定车辆", "out");
                            //showcontext = "车牌为:" + e.license + "的车主,您的月卡已到期，请及时续费";
                        }
                    }
                }
                else
                {
                   // #region 临停客户
                    //if (iniinfo.IsOpenNotConfirm != "True")
                    //{
                    //    //临停车确认是否开闸
                    //    if (GetFCustomer(e.license) == null)
                    //    {
                    //        frmCheck outfrmcheck = new frmCheck(e.license, cartype, "out");
                    //        DialogResult dr = outfrmcheck.ShowDialog();
                    //        if (dr == DialogResult.OK)
                    //        {
                    //            e.license = outfrmcheck.PlateId;
                    //            cartype = outfrmcheck.CarType;
                    //        }
                    //        else
                    //        {
                    //            return;
                    //        }
                    //    }

                    //}
                    //不存在进场记录
                    if (string.IsNullOrEmpty(GetInTime(plateid)))
                    {
                      //  #region 没有检测到入场信息，手动收费

                        if (MessageHelper.ConfirmYesNo("没有检测到车辆【" + plateid + "】的入场信息，请点击【是】手动收费！"))
                        {
                            frmManualFee frmmanualfee = new frmManualFee(Out_axVZLPRClientCtrl.Name);
                            frmmanualfee.Owner = this;
                            frmmanualfee.ShowDialog();
                            if (frmmanualfee.DialogResult == DialogResult.OK)
                            {
                                if (frmmanualfee.CType == CustomerConst.FCustomer)
                                {
                                    if (MessageHelper.ConfirmYesNo("固定车辆，请点击【是】放行！"))
                                    {
                                        OpenFiveDaozha();
                                    }
                                }
                                else
                                {
                                    OpenFiveDaozha();
                                    string meg = string.Empty;
                                    if (frmmanualfee.Tag == "1")
                                    {
                                        meg = "车牌" + frmmanualfee.PlateId;
                                        lblOutPlateId.Text = frmmanualfee.PlateId;
                                    }
                                    else
                                    {
                                        meg = "卡号" + frmmanualfee.CardCode;
                                        lblOutPlateId.Text = frmmanualfee.CardCode;
                                        lbId.Text = "刷卡卡号";
                                    }
                                    //显示记录
                                    ShowInfo(meg + ";车主类型:" + frmmanualfee.CType + ";出场时间:" +
                                             frmmanualfee.OutTime.ToString("HH:mm:ss"));
                                    //出场信息
                                    BindOutInfo(cameraTwoType, frmmanualfee.OutTime.ToString("HH:mm:ss"), frmmanualfee.CarType,
                                             frmmanualfee.CType, plateid);

                                    //刷新泊位数量
                                    RefreshCount(CustomerConst.Customer, CustomerConst.PlusOperate);
                                    //RefreshParkInfo();
                                    //播报车位数
                                    PlayBerth();
                                    //刷新最新收费信息
                                    RefreshChargeInfo();
                                    if (frmmanualfee.CType == CustomerConst.InCustomer)
                                    {
                                        //插入临停车出入记录表
                                        InsertFCustomerInfo(plateid, e.color, frmmanualfee.OutTime, "", e.imgPath,
                                                            "内部车辆",
                                                            "out");
                                    }
                                    else
                                    {
                                        //插入临停车出入记录表
                                        InsertFCustomerInfo(plateid, e.color, frmmanualfee.OutTime, "", e.imgPath,
                                                            "临停车辆",
                                                            "out");
                                    }
                                }


                            }
                        }
                    }


                    //进场记录存在，临停车收费
                    else
                    {
                     //   #region 临停车收费

                        string outimgpath = e.imgPath;
                        intime = Convert.ToDateTime(GetInTime(plateid));
                        if (!noInCar)
                        {
                            cartype = "内部车辆";
                        }
                        summoney = CalulateFee(intime, cartype);
                        TimeSpan timeSpan = outtime - intime;
                        parktime = string.Empty;
                        if (timeSpan.Days > 0)
                        {
                            parktime = timeSpan.Days + "天" + timeSpan.Hours.ToString() + "小时" +
                                       timeSpan.Minutes.ToString() + "分钟";
                        }
                        else
                        {
                            parktime = timeSpan.Hours.ToString() + "小时" +
                                       timeSpan.Minutes.ToString() + "分钟";
                        }
                        //收费车辆在免费时间内自动开闸
                        if (iniinfo.AutoOpen == "True" && summoney == 0)
                        {
                            OpenFiveDaozha();
                            //刷新最新收费信息
                            //RefreshChargeInfo();
                            if (noInCar)
                            {
                                custype = "临停客户";
                                //插入临停车出入记录表
                                InsertFCustomerInfo(plateid, e.color, outtime, "", e.imgPath, "临停车辆", "out");
                                //RefreshParkInfo();
                                //刷新泊位数量
                                RefreshCount(CustomerConst.Customer, CustomerConst.PlusOperate);
                            }
                            else
                            {
                                custype = "内部客户";
                                //插入临停车出入记录表
                                InsertFCustomerInfo(plateid, e.color, outtime, "", e.imgPath, "内部车辆", "out");
                                //刷新泊位数量
                                RefreshCount(CustomerConst.Customer, CustomerConst.PlusOperate);
                            }
                            ShowInfo(string.Format(info, custype));
                            //出场信息
                            BindOutInfo(cameraTwoType, outtime.ToString("HH:mm:ss"), cartype, custype, e.license);

                            string PlayText = "";
                            if (iniinfo.LcarplayNo == "True")
                            {
                                PlayText = plateid + "," + outcontent;
                            }
                            else
                            {
                                PlayText = outcontent;
                            }


                            FivePlay(plateid, PlayText);
                            //播报车位数
                            PlayBerth();
                        }
                        else
                        {

                            frmCharge frmcharge = new frmCharge(plateid, cartype, intime, outtime, parktime, feeStandard,
                                                                summoney, fiveImagepath, Out_FiveaxVZLPRClientCtrl.Name);
                            frmcharge.Owner = this;
                            frmcharge.ShowDialog();
                            custype = frmcharge.CusType;
                            if (frmcharge.DialogResult == DialogResult.OK)
                            {
                                OpenFiveDaozha();
                                ShowInfo(string.Format(info, custype));
                                //出场信息
                                BindOutInfo(cameraTwoType, outtime.ToString("HH:mm:ss"), cartype, custype, plateid);
                                //刷新泊位数量
                                RefreshCount(CustomerConst.Customer, CustomerConst.PlusOperate);
                                //RefreshParkInfo();
                                //刷新最新收费信息
                                RefreshChargeInfo();
                                if (noInCar)
                                {
                                    //插入临停车出入记录表
                                    InsertFCustomerInfo(plateid, e.color, outtime, "", e.imgPath, "临停车辆", "out");
                                }
                                else
                                {
                                    //插入临停车出入记录表
                                    InsertFCustomerInfo(plateid, e.color, outtime, "", e.imgPath, "内部车辆", "out");
                                }
                                //播报车位数
                                PlayBerth();

                            }
                            if (frmcharge.DialogResult == DialogResult.Cancel)
                            {
                                ShowInfo(string.Format(info, custype));
                                //出场信息
                                BindOutInfo(cameraFiveType, outtime.ToString("HH:mm:ss"), cartype, custype, e.license);
                                //刷新泊位数量
                                RefreshCount(CustomerConst.FCustomer, CustomerConst.PlusOperate);
                                RefreshParkInfo();
                                //刷新最新收费信息
                                RefreshChargeInfo();
                                //插入固定车出入记录表
                                // InsertFCustomerInfo(e.license, e.color, intime, "", e.imgPath, "固定车辆", "in");
                                InsertFCustomerInfo(plateid, e.color, outtime, "", e.imgPath, cartype, "out");
                                //  InsertFCustomerInfo(plateid, e.color, outtime, e.imgPath, "", cartype, "in");


                            }
                        }
                    }
                }
            }
            }
            else
            {
                //打开收费窗口，刷卡收费后放行
                InputPalteCharge(e.imgPath, e.color);

            }
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //这个地方记录的是button1对于窗口的位置  
                Point newPos = panel4.Location;
                //适当调整button1的位置  
                newPos.Offset(e.Location.X - oriPoint1.X, e.Location.Y - oriPoint1.Y);
                //保证拖动后控件还在当前窗体的可见范围内  
                if (new Rectangle(0, 0, this.Width, this.Height).Contains(newPos))
                {
                    panel4.Location = newPos;
                }
                else
                {
                    panel4.Location = oriPoint3;
                }
            }
        }

        //传入车牌，判判断车牌是此车是否也作出场处理
        //也入场true 
        //未入场false
        public bool isOneOut(string Plate)
        {
            DateTime nowDateTime = DateTime.Now;
            bool isout = false;
            int stopTime = Convert.ToInt32((nowDateTime - One_OutTime).TotalSeconds);
            
            if (One_OutPlate == Plate && stopTime < 90){
                isout = false;}
            else{          
                isout = true;}
            One_OutTime = nowDateTime;
            One_OutPlate = Plate;
            return isout;

        }

        public bool isOneIn(string Plate)
        {
            DateTime nowDateTime = DateTime.Now;
            bool isin = false;
            int stopTime = (nowDateTime - One_InTime).Seconds;
            if (cameraThreeType == "入口辅助")
            {
                if (One_InPlate == Plate && stopTime < 90)
                {
                    isin = true;
                }
                else
                {
                    isin = false;
                }
                One_InTime = nowDateTime;
                One_InPlate = Plate;
            }
            else { isin = false;}
        return isin;
        }




        /// <summary>
        /// 出口播报
        /// </summary>
        /// <param name="playcontent"></param>
        public void ThOutPlay(object playcontent)
        {


        }


        public static string ToHex(string s, string charset, bool fenge)
        {
            if ((s.Length % 2) != 0)
            {
                s += " ";//空格
                         //throw new ArgumentException("s is not valid chinese string!");
            }
            System.Text.Encoding chs = System.Text.Encoding.GetEncoding(charset);
            byte[] bytes = chs.GetBytes(s);
            string str = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                str += string.Format("{0:X}", bytes[i]);
                if (fenge && (i != bytes.Length - 1))
                {
                    str += string.Format("{0}", ",");
                }
            }
            return str;
        }

        private void butouttg_Click(object sender, EventArgs e)
        {
            //拍照
            string ckName = DateTime.Now.ToString("yyyyMMddhhmmssfff")+".jpg";
            string savePath = ckImage + "\\手机抬杆"+ ckName;
            //   MessageHelper.ShowTips(ckImage);
            if (!isWin3)
            {
                if (TwolprHandle > 0)
                {
                    Out_axVZLPRClientCtrl.VzLPRClientCaptureImg(0, savePath);
                    picOutImg.Image = Image.FromFile(savePath);
                    InsertFCustomerInfo("手动抬杆", "无", DateTime.Now, "", savePath, "无", "out");
                    OpenOutDaozha();

                }
            }
            else
            {
                if (FivelprHandle > 0)
                {
                    Out_FiveaxVZLPRClientCtrl.VzLPRClientCaptureImg(0, savePath);
                    picOutImg.Image = Image.FromFile(savePath);
                    InsertFCustomerInfo("手动抬杆", "无", DateTime.Now, "", savePath, "无", "out");
                    OpenFiveDaozha();

                }
            }
            //保存信息
            //开闸



        }

        private void butintg_Click(object sender, EventArgs e)
        {
            //拍照
            string rkName = DateTime.Now.ToString("yyyyMMddhhmmssfff") + ".jpg";
            string savePath = rkImage + "\\手机抬杆" + rkName;
            if (!isWin1 && !isWin2)
            {
                if (OnelprHandle > 0)
                {
                    In_axVZLPRClientCtrl.VzLPRClientCaptureImg(0, savePath);
                    picInImg.Image = Image.FromFile(savePath);
                    InsertFCustomerInfo("手动抬杆", "无", DateTime.Now, "", savePath, "无", "in");
                    OpenInDaozha();
                }
            }
            if (isWin1)
            {
                if (ThreelprHandle > 0)
                {
                    In_ThreeaxVZLPRClientCtrl.VzLPRClientCaptureImg(0, savePath);
                    picInImg.Image = Image.FromFile(savePath);
                    InsertFCustomerInfo("手动抬杆", "无", DateTime.Now, "", savePath, "无", "in");
                    OpenThreeDaozha();
                }

            }
            if (isWin2)
            {
                if (FourlprHandle > 0)
                {
                    In_FouraxVZLPRClientCtrl.VzLPRClientCaptureImg(0, savePath);
                    picInImg.Image = Image.FromFile(savePath);
                    InsertFCustomerInfo("手动抬杆", "无", DateTime.Now, "", savePath, "无", "in");
                    OpenFourDaozha();
                }

            }

        }

        /// <summary>
        /// 出场播报
        /// </summary>
        /// <param name="playcontent"></param>


        private void In_axVZLPRClientCtrl_OnLPRPlateInfoOutEx(object sender,
                                                              AxVZLPRClientCtrlLib.
                                                                  _DVZLPRClientCtrlEvents_OnLPRPlateInfoOutExEvent e)
        {
            fCustomerModel = null;
            int overday = iniinfo.OverDay;
            if (cameraOneType == "入口设备")
            {
                //   string tips; //提示信息
                DateTime intime = DateTime.Now;
                string custype = string.Empty;
                string cartype = string.Empty;
                string info = string.Empty;


              //  #region 完成识别

                //判断是否识别正确
                if (Isplateid(e.license))
                {
                    if (!isOneIn(e.license))
                    {
                    //    #region 确认确认是否开闸
                        cartype = GetCarType(e.nType);
                        FCustomer fmodel = GetFCustomer(e.license);
                        custype = CustomerConst.FCustomer;
                        string ctype = string.Empty;
                        bool noInCar = true;
                        if (fmodel != null)
                        {
                            ctype = GetFCustomer(e.license).CarType;
                        }
                        if (!string.IsNullOrEmpty(ctype))
                        {
                            noInCar = !ctype.Equals("内部车辆");
                        }

                        if (iniinfo.IsOpenNotConfirm != "True"|| InCarAutoOpen)
                        {
                            //临停车确认是否开闸
                            if (GetFCustomer(e.license) == null)
                            {
                                frmCheck frmcheck = new frmCheck(e.license, cartype, "in");
                                DialogResult dr = frmcheck.ShowDialog();
                                if (dr == DialogResult.OK)
                                {
                                    e.license = frmcheck.PlateId;
                                    cartype = frmcheck.CarType;
                                }
                                else
                                {
                                    return;
                                }
                            }
                        }

                        //内部车确认是否开闸
                        if (!noInCar && InCarAutoOpen)
                        {
                            frmCheck frmcheck = new frmCheck(e.license, cartype, "in");
                            DialogResult dr = frmcheck.ShowDialog();
                            if (dr == DialogResult.OK)
                            {
                                e.license = frmcheck.PlateId;
                                cartype = frmcheck.CarType;
                            }
                            else
                            {
                                return;
                            }
                        }

                     //   #endregion


                        //插入车辆出入记录表
                        InsertIdentifyInfo(e.license, e.color, e.colorIndex, e.nType, e.confidence, e.bright, e.nDirection, e.time, e.carBright, e.carColor, e.imgPath, e.ip, e.resultType, intime, "InTime");
                        info = "车牌" + e.license + ";车主类型:" + "{0}" + ";入场时间:" + intime.ToString("HH:mm:ss");

                        //判断是否是月租车

                     //   #region 月租车

                        if (GetFCustomer(e.license) != null && noInCar)
                        {

                            //是月租车，判断是否在有效期内，在有效期内
                            if (IsValCustomer(e.license))
                            {
                                //月租车在有效期内，再判断车位是否被占 2016.7.20jyb
                                //如果不被占用当固定车辆，如被点用，当临时车车辆
                                //  IsMoveCar(e.license);
                                //如果是一户多车，已有车辆入场，另一个需同时插入收费信息表
                                if (str_MoveCar != "-1")
                                {
                                    if (IsMoveCar(e.license))
                                    {
                                        custype = "一户多车";
                                        InsertChargeRecord(e.license, cartype, intime, e.imgPath, custype, "");
                                    }
                                }
                                //
                                string time = fCustomerModel.OverTime.ToString();
                                TimeSpan timespan = Convert.ToDateTime(time) - DateTime.Now;
                                string lefttime = ((int)timespan.TotalDays).ToString();


                                string PlayText = "";
                                if (iniinfo.FcarplayNo == "True")
                                {
                                    PlayText = e.license + "," + content;
                                }
                                else
                                {
                                    PlayText = content;
                                }



                                if (Convert.ToInt32(lefttime) <= overday)
                                {
                                    //播报

                                    InPlay(e.license, "欢迎光临," + e.license + ",剩余" + lefttime + "天,请交费");

                                }
                                else
                                {
                                    //播报
                                    InPlay(e.license, PlayText);

                                }
                                OpenInDaozha();
                                // custype = CustomerConst.FCustomer;

                                Thread thread = new Thread(new ParameterizedThreadStart(ShowInfo));
                                string strInfo = string.Format(info, custype);
                                thread.Start((object)strInfo);


                                // ShowInfo(string.Format(info, custype));
                                //进场场信息
                                BindInInfo(cameraOneType, intime.ToString("HH:mm:ss"), cartype, custype, e.license);
                                //插入固定车出入记录表
                                InsertFCustomerInfo(e.license, e.color, intime, e.imgPath, "", "固定车辆", "in");
                                //刷新泊位数量
                                RefreshCount(CustomerConst.FCustomer, CustomerConst.SubOperate);
                                //RefreshParkInfo();
                                //显示车位
                                PlayBerth();
                            }
                            else
                            {
                                string time = string.Empty;

                            //    #region 过期固定客户收费

                                if (iniinfo.IsFCustomerFee == "True")
                                {
                                    fCustomerModel = GetFCustomer(e.license);
                                    if (fCustomerModel != null)
                                    {
                                        //if (!string.IsNullOrEmpty(GetInTime(e.license)))
                                        //{
                                        //    MessageHelper.ShowTips("车辆【" + e.license + "】已有进场信息！");
                                        //    return;
                                        //}
                                        time = fCustomerModel.OverTime.ToString();
                                        if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(time)) > 0)
                                        {
                                            TimeSpan timespan = DateTime.Now - Convert.ToDateTime(time);
                                            string overtime = ((int)timespan.TotalDays).ToString();
                                            //播报
                                            InPlay(e.license, "欢迎光临," + e.license + ",已过期,请交费");

                                        }
                                        OpenInDaozha();
                                        custype = CustomerConst.OFCustomer;
                                        ShowInfo(string.Format(info, custype));
                                        //插入固定车出入记录表
                                        InsertFCustomerInfo(e.license, e.color, intime, e.imgPath, "", "固定车辆", "in");
                                        //插入临时车辆收费记录表
                                        InsertChargeRecord(e.license, cartype, intime, e.imgPath, custype, "");
                                        //进场场信息
                                        BindInInfo(cameraOneType, intime.ToString("HH:mm:ss"), cartype, custype, e.license);
                                        //刷新泊位数量
                                        RefreshCount(CustomerConst.FCustomer, CustomerConst.SubOperate);
                                        //RefreshParkInfo();
                                        //显示车位
                                        PlayBerth();
                                    }

                                }
                             //   #endregion
                                #region 过期固定客户提示过期，不收费

                                else
                                {
                                    time = fCustomerModel.OverTime.ToString();
                                    if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(time)) > 0)
                                    {
                                        TimeSpan timespan = DateTime.Now - Convert.ToDateTime(time);
                                        string overtime = ((int)timespan.TotalDays).ToString();
                                        InPlay(e.license, "欢迎光临," + e.license + ",已过期,请交费");
                                    }
                                    else
                                    {
                                        //播报
                                        InPlay(e.license, e.license + "," + content);
                                    }
                                    OpenInDaozha();
                                    custype = CustomerConst.OFCustomer;
                                    ShowInfo(string.Format(info, custype));
                                    //插入固定车出入记录表
                                    InsertFCustomerInfo(e.license, e.color, intime, e.imgPath, "", "固定车辆", "in");
                                    //进场场信息
                                    BindInInfo(cameraOneType, intime.ToString("HH:mm:ss"), cartype, custype, e.license);
                                    //刷新泊位数量
                                    RefreshCount(CustomerConst.FCustomer, CustomerConst.SubOperate);
                                    //RefreshParkInfo();
                                    //显示车位
                                    PlayBerth();

                                }

                                #endregion

                            }
                        }
                      //  #endregion
                      //  #region 临停车,内部车辆

                        else //临时停车记录
                        {
                            #region 临停车辆不能重复入场（屏蔽）

                            //      if (!string.IsNullOrEmpty(GetInTime(e.license)))
                            //{
                            //    MessageHelper.ShowTips("车辆【" + e.license + "】已有进场信息！");
                            //    return;
                            //} 

                         //   #endregion




                            string PlayText = "";
                            if (iniinfo.LcarplayNo == "True")
                            {
                                PlayText = e.license + "," + content;
                            }
                            else
                            {
                                PlayText = content;
                            }

                            //播报
                            InPlay(e.license, PlayText);
                            //开闸
                            OpenInDaozha();
                            //插入临时车辆出入记录表
                            if (!noInCar)
                            {
                                cartype = "内部车辆";
                                custype = CustomerConst.InCustomer;
                                //插入临停车出入记录表
                                InsertFCustomerInfo(e.license, e.color, intime, e.imgPath, "", cartype, "in");
                            }
                            else
                            {
                                custype = CustomerConst.Customer;
                                //插入临停车出入记录表
                                InsertFCustomerInfo(e.license, e.color, intime, e.imgPath, "", "临停车辆", "in");
                            }
                            Thread thread = new Thread(new ParameterizedThreadStart(ShowInfo));
                            string strInfo = string.Format(info, custype);
                            thread.Start((object)strInfo);
                            //  ShowInfo(string.Format(info, custype));
                            InsertChargeRecord(e.license, cartype, intime, e.imgPath, custype, "");
                            //进场场信息
                            BindInInfo(cameraOneType, intime.ToString("HH:mm:ss"), cartype, custype, e.license);
                            //刷新泊位数量
                            RefreshCount(CustomerConst.Customer, CustomerConst.SubOperate);
                            //RefreshParkInfo();
                            //显示车位
                            PlayBerth();
                        }

                     //   #endregion
                    }
                }
              //  #endregion
                #region 识别未完成，手动识别

                else
                {
                    InInputPalte(e.imgPath, e.color, "One");

                }

            }
            if (cameraOneType == "出口设备")
            {

                //  string tips; //提示信息
                DateTime outtime = DateTime.Now;
                string info = string.Empty;
                string custype = string.Empty;
                string cartype = string.Empty;
                string outcontent = "一路平安";


                string time = string.Empty;
                DateTime intime;
                string parktime = string.Empty;
                decimal summoney = 0;
                string plateid = string.Empty;
                string chrageplaeid = string.Empty;

                //判断是否识别正确;
                if (Isplateid(e.license))
                {
                    plateid = e.license;
                    ChargeRecord chgrecord = GetRecordModel(plateid);
                    //车辆类型
                    if (chgrecord != null)
                    {
                        if (!string.IsNullOrWhiteSpace(chgrecord.CarType))
                        {
                            cartype = chgrecord.CarType;
                        }
                        else
                        {
                            cartype = GetCarType(e.nType);
                        }

                    }
                    else
                    {
                        cartype = GetCarType(e.nType);
                    }
                    //插入车辆出入记录表
                    InsertIdentifyInfo(e.license, e.color, e.colorIndex, e.nType, e.confidence, e.bright, e.nDirection,e.time, e.carBright, e.carColor, e.imgPath, e.ip, e.resultType, outtime, "OutTime");
                    info = "车牌" + plateid + ";车主类型:" + "{0}" + ";出场时间:" + outtime.ToString("HH:mm:ss");
                    bool noInCar = !IsInnerCar(plateid);
                    //固定车且不为内部车的情况
                    if (GetFCustomer(plateid) != null && noInCar)
                    {
                        //判断是否在有效果内，在有效期内
                        if (IsValCustomer(plateid))
                        {
                            //   如果是一户多车，则执行，否则直接出场。
                            if (str_MoveCar != "-1")
                            {

                                if (string.IsNullOrEmpty(GetInTime(plateid)))
                                {

                                    if (str_MoveCar == "1")
                                    {
                                        string getMovePlateId;
                                        getMovePlateId = GetMoveCarPlateId(plateid).Trim();//得到本户下未交费车辆信息
                                        chargeRecordModel = GetChargeModeByPlateId(getMovePlateId);
                                    //    #region 一户多车下，有另一辆车是临时车，所以在本车辆出库时将计算第二辆费用，并支付。
                                        if (chargeRecordModel != null)
                                        {

                                            time = chargeRecordModel.InTime.ToString();
                                            intime = Convert.ToDateTime(time);
                                            cartype = chargeRecordModel.CarType;
                                            summoney = CalulateFee(intime, cartype);
                                            //绑定数据
                                            TimeSpan span = outtime - intime;
                                            if (span.Days > 0)
                                            {
                                                parktime = span.Days + "天" + span.Hours + "小时" + span.Hours + "分钟";
                                            }
                                            else
                                            {
                                                parktime = span.Hours + "小时" + span.Minutes + "分钟";

                                            }

                                            string tips = "一户多车用户，车牌 【" + plateid + "】未记费，另一辆【" + getMovePlateId + "】已在本车场内，已达到记费条件，请交费。";
                                            MessageHelper.ShowTips(tips);

                                            frmCharge frmcharge = new frmCharge(getMovePlateId, cartype, intime, outtime, parktime, feeStandard,
                                summoney, outimgpath, In_axVZLPRClientCtrl.Name);
                                            frmcharge.Owner = this;
                                            frmcharge.ShowDialog();
                                            custype = "一户多车";


                                            //更新数据库
                                            //1、更新收费记录表
                                            //2、固定车出场
                                            //3、回定车入场
                                            //4、如果设置第二次始终为临停车，则不进行结算操作

                                            if (frmcharge.DialogResult == DialogResult.OK)
                                            {
                                                OpenInDaozha();
                                                Thread thread = new Thread(new ParameterizedThreadStart(ShowInfo));
                                                string strInfo = string.Format(info, custype);
                                                thread.Start((object)strInfo);
                                                // ShowInfo(string.Format(info, custype));
                                                //出场信息
                                                BindOutInfo(cameraOneType, outtime.ToString("HH:mm:ss"), cartype, custype, e.license);
                                                //刷新泊位数量
                                                RefreshCount(CustomerConst.FCustomer, CustomerConst.PlusOperate);
                                                RefreshParkInfo();
                                                //刷新最新收费信息
                                                RefreshChargeInfo();
                                                //插入固定车出入记录表
                                                // InsertFCustomerInfo(e.license, e.color, intime, "", e.imgPath, "固定车辆", "in");
                                                InsertFCustomerInfo(getMovePlateId, e.color, outtime, "", e.imgPath, cartype, "out");
                                                InsertFCustomerInfo(getMovePlateId, e.color, outtime, e.imgPath, "", cartype, "in");
                                            }
                                            if (frmcharge.DialogResult == DialogResult.Cancel)
                                            {
                                                Thread thread = new Thread(new ParameterizedThreadStart(ShowInfo));
                                                string strInfo = string.Format(info, custype);
                                                thread.Start((object)strInfo);
                                                //ShowInfo(string.Format(info, custype));
                                                //出场信息
                                                BindOutInfo(cameraOneType, outtime.ToString("HH:mm:ss"), cartype, custype, e.license);
                                                //刷新泊位数量
                                                RefreshCount(CustomerConst.FCustomer, CustomerConst.PlusOperate);
                                                RefreshParkInfo();
                                                //刷新最新收费信息
                                                RefreshChargeInfo();
                                                //插入固定车出入记录表
                                                // InsertFCustomerInfo(e.license, e.color, intime, "", e.imgPath, "固定车辆", "in");
                                                InsertFCustomerInfo(getMovePlateId, e.color, outtime, "", e.imgPath, cartype, "out");
                                                InsertFCustomerInfo(getMovePlateId, e.color, outtime, e.imgPath, "", cartype, "in");


                                            }
                                           
                                        }
                                        else
                                        {
                                            //自动开闸
                                            OpenInDaozha();
                                            custype = CustomerConst.FCustomer;
                                            Thread thread = new Thread(new ParameterizedThreadStart(ShowInfo));
                                            string strInfo = string.Format(info, custype);
                                            thread.Start((object)strInfo);
                                          //  ShowInfo(string.Format(info, custype));


                                            string PlayText = "";
                                            if (iniinfo.FcarplayNo == "True")
                                            {
                                                PlayText = plateid + "," + outcontent;
                                            }
                                            else
                                            {
                                                PlayText = outcontent;
                                            }


                                            //播报
                                            InPlay(plateid, PlayText);

                                            //插入固定车出入记录表
                                            InsertFCustomerInfo(e.license, e.color, outtime, "", e.imgPath, "固定车辆", "out");
                                            //出场信息
                                            BindOutInfo(cameraOneType, outtime.ToString("HH:mm:ss"), cartype, custype, e.license);
                                            //刷新泊位数量
                                            RefreshCount(CustomerConst.FCustomer, CustomerConst.PlusOperate);
                                            RefreshParkInfo();
                                            //刷新最新收费信息
                                            RefreshChargeInfo();
                                        }
                                      //  #endregion
                                    }
                                    else
                                    {
                                        //自动开闸
                                        OpenInDaozha();
                                        custype = CustomerConst.FCustomer;
                                        Thread thread = new Thread(new ParameterizedThreadStart(ShowInfo));
                                        string strInfo = string.Format(info, custype);
                                        thread.Start((object)strInfo);
                                        // ShowInfo(string.Format(info, custype));
                                        //播报


                                        string PlayText = "";
                                        if (iniinfo.FcarplayNo == "True")
                                        {
                                            PlayText = plateid + "," + outcontent;
                                        }
                                        else
                                        {
                                            PlayText = outcontent;
                                        }


                                        InPlay(plateid, PlayText);

                                        //插入固定车出入记录表
                                        InsertFCustomerInfo(plateid, e.color, outtime, "", e.imgPath, "固定车辆", "out");
                                        //出场信息
                                        BindOutInfo(cameraOneType, outtime.ToString("HH:mm:ss"), cartype, custype, plateid);
                                        //刷新泊位数量
                                        RefreshCount(CustomerConst.FCustomer, CustomerConst.PlusOperate);
                                        RefreshParkInfo();
                                        //刷新最新收费信息
                                        RefreshChargeInfo();


                                    }
                                }
                                else
                                {

                                    time = GetInTime(plateid);
                                    intime = Convert.ToDateTime(time);
                                    summoney = CalulateFee(intime, cartype);
                                    TimeSpan timeSpan = outtime - intime;
                                    parktime = string.Empty;
                                    if (timeSpan.Days > 0)
                                    {
                                        parktime = timeSpan.Days + "天" + timeSpan.Hours.ToString() + "小时" +
                                                   timeSpan.Minutes.ToString() + "分钟";
                                    }
                                    else
                                    {
                                        parktime = timeSpan.Hours.ToString() + "小时" +
                                                   timeSpan.Minutes.ToString() + "分钟";
                                    }
                                    if (iniinfo.AutoOpen == "True" && summoney == 0)
                                    {
                                        //自动开闸
                                        OpenInDaozha();
                                        //   custype = CustomerConst.FCustomer;

                                        OutPlay(plateid, plateid + "," + outcontent); OutPlay(plateid, plateid + "," + outcontent);
                                        custype = "一户多车";
                                        Thread thread = new Thread(new ParameterizedThreadStart(ShowInfo));
                                        string strInfo = string.Format(info, custype);
                                        thread.Start((object)strInfo);
                                        // ShowInfo(string.Format(info, custype));
                                        //插入固定车出入记录表
                                        InsertFCustomerInfo(plateid, e.color, outtime, "", e.imgPath, "一户多车", "out");
                                        //出场信息
                                        BindOutInfo(cameraOneType, outtime.ToString("HH:mm:ss"), cartype, custype, plateid);
                                        //刷新泊位数量
                                        RefreshCount(CustomerConst.FCustomer, CustomerConst.PlusOperate);
                                        RefreshParkInfo();
                                        //刷新最新收费信息
                                        RefreshChargeInfo();
                                    }
                                    else
                                    {

                                        frmCharge frmcharge = new frmCharge(plateid, cartype, intime, outtime, parktime, feeStandard,
                         summoney, outimgpath, In_axVZLPRClientCtrl.Name);
                                        frmcharge.Owner = this;
                                        frmcharge.ShowDialog();
                                        custype = "一户多车";

                                        if (frmcharge.DialogResult == DialogResult.OK)
                                        {
                                            OpenInDaozha();
                                            Thread thread = new Thread(new ParameterizedThreadStart(ShowInfo));
                                            string strInfo = string.Format(info, custype);
                                            thread.Start((object)strInfo);
                                            // ShowInfo(string.Format(info, custype));
                                            //出场信息
                                            BindOutInfo(cameraOneType, outtime.ToString("HH:mm:ss"), cartype, custype, plateid);
                                            //刷新泊位数量
                                            RefreshCount(CustomerConst.FCustomer, CustomerConst.PlusOperate);
                                            RefreshParkInfo();
                                            //刷新最新收费信息
                                            RefreshChargeInfo();
                                            //插入固定车出入记录表
                                            // InsertFCustomerInfo(e.license, e.color, intime, "", e.imgPath, "固定车辆", "in");
                                            InsertFCustomerInfo(plateid, e.color, outtime, e.imgPath, "", cartype, "out");
                                            InsertFCustomerInfo(plateid, e.color, outtime, "", e.imgPath, cartype, "in");
                                        }
                                        if (frmcharge.DialogResult == DialogResult.Cancel)
                                        {
                                            Thread thread = new Thread(new ParameterizedThreadStart(ShowInfo));
                                            string strInfo = string.Format(info, custype);
                                            thread.Start((object)strInfo);
                                            // ShowInfo(string.Format(info, custype));
                                            //出场信息
                                            BindOutInfo(cameraOneType, outtime.ToString("HH:mm:ss"), cartype, custype, e.license);
                                            //刷新泊位数量
                                            RefreshCount(CustomerConst.FCustomer, CustomerConst.PlusOperate);
                                            RefreshParkInfo();
                                            //刷新最新收费信息
                                            RefreshChargeInfo();
                                            //插入固定车出入记录表
                                            // InsertFCustomerInfo(e.license, e.color, intime, "", e.imgPath, "固定车辆", "in");
                                            InsertFCustomerInfo(plateid, e.color, outtime, "", e.imgPath, cartype, "out");
                                            InsertFCustomerInfo(plateid, e.color, outtime, e.imgPath, "", cartype, "in");


                                        }
                                      

                                    }




                                }


                            }
                            else
                            {
                                //自动开闸
                                OpenInDaozha();


                                string time1 = fCustomerModel.OverTime.ToString();
                                TimeSpan timespan = Convert.ToDateTime(time1) - DateTime.Now;
                                string lefttime = ((int)timespan.TotalDays).ToString();
                                //自动开闸

                              

                                if (Convert.ToInt32(lefttime) <= overday)
                                {
                                    //播报
                                    InPlay(e.license, e.license + ",剩余" + lefttime + "天,请交费，一路平安。");

                                }
                                else
                                {

                                    //播报
                                    InPlay(plateid, plateid + "," + outcontent);

                                }



                                custype = CustomerConst.FCustomer;
                                Thread thread = new Thread(new ParameterizedThreadStart(ShowInfo));
                                string strInfo = string.Format(info, custype);
                                thread.Start((object)strInfo);

                              //  ShowInfo(string.Format(info, custype));
                                //插入固定车出入记录表


                                string PlayText = "";
                                if (iniinfo.FcarplayNo == "True")
                                {
                                    PlayText = plateid + "," + outcontent;
                                }
                                else
                                {
                                    PlayText = outcontent;
                                }

                                InPlay(plateid, PlayText);

                                InsertFCustomerInfo(e.license, e.color, outtime, "", e.imgPath, "固定车辆", "out");
                                //出场信息
                                BindOutInfo(cameraOneType, outtime.ToString("HH:mm:ss"), cartype, custype, e.license);
                                //刷新泊位数量
                                RefreshCount(CustomerConst.FCustomer, CustomerConst.PlusOperate);
                                RefreshParkInfo();
                                //刷新最新收费信息
                                RefreshChargeInfo();


                            }


                        }

                        else
                        {
                            custype = CustomerConst.OFCustomer;

                            //   #region 过期客户收费

                            //过期固定客户收费
                            if (iniinfo.IsFCustomerFee == "True")
                            {
                                if (string.IsNullOrEmpty(GetInTime(plateid)))
                                {
                                    MessageHelper.ShowTips("车辆【" + plateid + "】没有进场信息！");
                                    return;
                                }
                                string outimgpath = e.imgPath;
                                intime = Convert.ToDateTime(GetInTime(plateid));
                                summoney = CalulateFee(intime, cartype);
                                TimeSpan timeSpan = outtime - intime;
                                parktime = string.Empty;
                                if (timeSpan.Days > 0)
                                {
                                    parktime = timeSpan.Days + "天" + timeSpan.Hours.ToString() + "小时" +
                                               timeSpan.Minutes.ToString() + "分钟";
                                }
                                else
                                {
                                    parktime = timeSpan.Hours.ToString() + "小时" +
                                               timeSpan.Minutes.ToString() + "分钟";
                                }
                                frmCharge frmcharge = new frmCharge(plateid, cartype, intime, outtime, parktime,
                                                                    feeStandard,
                                                                    summoney, outimgpath, Out_axVZLPRClientCtrl.Name);
                                frmcharge.Owner = this;
                                frmcharge.ShowDialog();
                                custype = frmcharge.CusType;
                                if (frmcharge.DialogResult == DialogResult.OK)
                                {
                                    OpenOutDaozha();
                                    Thread thread = new Thread(new ParameterizedThreadStart(ShowInfo));
                                    string strInfo = string.Format(info, custype);
                                    thread.Start((object)strInfo);
                                    //   ShowInfo(string.Format(info, custype));
                                    //出场信息
                                    BindOutInfo(cameraOneType, outtime.ToString("HH:mm:ss"), cartype, custype, plateid);
                                    //刷新泊位数量
                                    RefreshCount(CustomerConst.FCustomer, CustomerConst.PlusOperate);
                                    RefreshParkInfo();
                                    //刷新最新收费信息
                                    RefreshChargeInfo();
                                    //插入固定车出入记录表
                                    InsertFCustomerInfo(plateid, e.color, intime, "", e.imgPath, "固定车辆", "in");
                                }

                                if (frmcharge.DialogResult == DialogResult.Cancel)
                                {
                                    Thread thread = new Thread(new ParameterizedThreadStart(ShowInfo));
                                    string strInfo = string.Format(info, custype);
                                    thread.Start((object)strInfo);
                                  //  ShowInfo(string.Format(info, custype));
                                    //出场信息
                                    BindOutInfo(cameraOneType, outtime.ToString("HH:mm:ss"), cartype, custype, e.license);
                                    //刷新泊位数量
                                    RefreshCount(CustomerConst.FCustomer, CustomerConst.PlusOperate);
                                    RefreshParkInfo();
                                    //刷新最新收费信息
                                    RefreshChargeInfo();
                                    //插入固定车出入记录表
                                    // InsertFCustomerInfo(e.license, e.color, intime, "", e.imgPath, "固定车辆", "in");
                                    InsertFCustomerInfo(plateid, e.color, outtime, "", e.imgPath, cartype, "out");
                                   // InsertFCustomerInfo(plateid, e.color, outtime, e.imgPath, "", cartype, "in");


                                }
                               


                            }


                            else
                            {

                                //播报
                                if (!string.IsNullOrEmpty(OneLedAddr1))
                                {
                                    InPlay(plateid, plateid+","+ outcontent);
                                }
                                //开闸
                                OpenInDaozha();
                                Thread thread = new Thread(new ParameterizedThreadStart(ShowInfo));
                                string strInfo = string.Format(info, custype);
                                thread.Start((object)strInfo);
                               // ShowInfo(string.Format(info, custype));
                                //出场信息
                                BindOutInfo(cameraOneType, outtime.ToString("HH:mm:ss"), cartype, custype, plateid);
                                //刷新泊位数量
                                RefreshCount(CustomerConst.FCustomer, CustomerConst.PlusOperate);
                                RefreshParkInfo();
                                //刷新最新收费信息
                                RefreshChargeInfo();
                                //插入固定车出入记录表
                                InsertFCustomerInfo(plateid, e.color, outtime, "", e.imgPath, "固定车辆", "out");
                                //showcontext = "车牌为:" + e.license + "的车主,您的月卡已到期，请及时续费";
                            }
                        }
                    }
                    else
                    {
                      //  #region 临停客户
                        //if (iniinfo.IsOpenNotConfirm != "True")
                        //{
                        //    //临停车确认是否开闸
                        //    if (GetFCustomer(e.license) == null)
                        //    {
                        //        frmCheck outfrmcheck = new frmCheck(e.license, cartype, "out");
                        //        DialogResult dr = outfrmcheck.ShowDialog();
                        //        if (dr == DialogResult.OK)
                        //        {
                        //            e.license = outfrmcheck.PlateId;
                        //            cartype = outfrmcheck.CarType;
                        //        }
                        //        else
                        //        {
                        //            return;
                        //        }
                        //    }

                        //}
                        //不存在进场记录
                        if (string.IsNullOrEmpty(GetInTime(plateid)))
                        {
                            #region 没有检测到入场信息，手动收费

                            if (MessageHelper.ConfirmYesNo("没有检测到车辆【" + plateid + "】的入场信息，请点击【是】手动收费！"))
                            {
                                frmManualFee frmmanualfee = new frmManualFee(In_axVZLPRClientCtrl.Name);
                                frmmanualfee.Owner = this;
                                frmmanualfee.ShowDialog();
                                if (frmmanualfee.DialogResult == DialogResult.OK)
                                {
                                    if (frmmanualfee.CType == CustomerConst.FCustomer)
                                    {
                                        if (MessageHelper.ConfirmYesNo("固定车辆，请点击【是】放行！"))
                                        {
                                            OpenInDaozha();
                                        }
                                    }
                                    else
                                    {
                                        OpenInDaozha();
                                        string meg = string.Empty;
                                        if (frmmanualfee.Tag == "1")
                                        {
                                            meg = "车牌" + frmmanualfee.PlateId;
                                            lblOutPlateId.Text = frmmanualfee.PlateId;
                                        }
                                        else
                                        {
                                            meg = "卡号" + frmmanualfee.CardCode;
                                            lblOutPlateId.Text = frmmanualfee.CardCode;
                                            lbId.Text = "刷卡卡号";
                                        }
                                        //显示记录
                                        Thread thread = new Thread(new ParameterizedThreadStart(ShowInfo));
                                        string strInfo = meg + ";车主类型:" + frmmanualfee.CType + ";出场时间:" +
                                                 frmmanualfee.OutTime.ToString("HH:mm:ss");
                                        thread.Start((object)strInfo);


                                       // ShowInfo(meg + ";车主类型:" + frmmanualfee.CType + ";出场时间:" +
                                        //         frmmanualfee.OutTime.ToString("HH:mm:ss"));
                                        //出场信息
                                        BindOutInfo(cameraOneType, frmmanualfee.OutTime.ToString("HH:mm:ss"), frmmanualfee.CarType,
                                                 frmmanualfee.CType, plateid);

                                        //刷新泊位数量
                                        RefreshCount(CustomerConst.Customer, CustomerConst.PlusOperate);
                                        //RefreshParkInfo();
                                        //播报车位数
                                        PlayBerth();
                                        //刷新最新收费信息
                                        RefreshChargeInfo();
                                        if (frmmanualfee.CType == CustomerConst.InCustomer)
                                        {
                                            //插入临停车出入记录表
                                            InsertFCustomerInfo(plateid, e.color, frmmanualfee.OutTime, "", e.imgPath,
                                                                "内部车辆",
                                                                "out");
                                        }
                                        else
                                        {
                                            //插入临停车出入记录表
                                            InsertFCustomerInfo(plateid, e.color, frmmanualfee.OutTime, "", e.imgPath,
                                                                "临停车辆",
                                                                "out");
                                        }
                                    }


                                }
                            }
                        }


                        //进场记录存在，临停车收费
                        else
                        {
                        //    #region 临停车收费

                            string outimgpath = e.imgPath;
                            intime = Convert.ToDateTime(GetInTime(plateid));
                            if (!noInCar)
                            {
                                cartype = "内部车辆";
                            }
                            summoney = CalulateFee(intime, cartype);
                            TimeSpan timeSpan = outtime - intime;
                            parktime = string.Empty;
                            if (timeSpan.Days > 0)
                            {
                                parktime = timeSpan.Days + "天" + timeSpan.Hours.ToString() + "小时" +
                                           timeSpan.Minutes.ToString() + "分钟";
                            }
                            else
                            {
                                parktime = timeSpan.Hours.ToString() + "小时" +
                                           timeSpan.Minutes.ToString() + "分钟";
                            }
                            //收费车辆在免费时间内自动开闸
                            if (iniinfo.AutoOpen == "True" && summoney == 0)
                            {
                                OpenInDaozha();
                                //刷新最新收费信息
                                //RefreshChargeInfo();
                                if (noInCar)
                                {
                                    custype = "临停客户";
                                    //插入临停车出入记录表
                                    InsertFCustomerInfo(plateid, e.color, outtime, "", e.imgPath, "临停车辆", "out");
                                    //RefreshParkInfo();
                                    //刷新泊位数量
                                    RefreshCount(CustomerConst.Customer, CustomerConst.PlusOperate);
                                }
                                else
                                {
                                    custype = "内部客户";
                                    //插入临停车出入记录表
                                    InsertFCustomerInfo(plateid, e.color, outtime, "", e.imgPath, "内部车辆", "out");
                                    //刷新泊位数量
                                    RefreshCount(CustomerConst.Customer, CustomerConst.PlusOperate);
                                }
                                Thread thread = new Thread(new ParameterizedThreadStart(ShowInfo));
                                string strInfo = string.Format(info, custype);
                                thread.Start((object)strInfo);



                                // ShowInfo(string.Format(info, custype));
                                //出场信息
                                BindOutInfo(cameraOneType, outtime.ToString("HH:mm:ss"), cartype, custype, e.license);

                                string PlayText = "";
                                if (iniinfo.LcarplayNo == "True")
                                {
                                    PlayText = plateid + "," + outcontent;
                                }
                                else
                                {
                                    PlayText = outcontent;
                                }



                                InPlay(plateid , PlayText);
                                //播报车位数
                                PlayBerth();
                            }
                            else
                            {

                                frmCharge frmcharge = new frmCharge(plateid, cartype, intime, outtime, parktime, feeStandard,
                                                                    summoney, outimgpath, In_axVZLPRClientCtrl.Name);
                                frmcharge.Owner = this;
                                frmcharge.ShowDialog();
                                custype = frmcharge.CusType;
                                if (frmcharge.DialogResult == DialogResult.OK)
                                {
                                    OpenInDaozha();

                                    Thread thread = new Thread(new ParameterizedThreadStart(ShowInfo));
                                    string strInfo = string.Format(info, custype);
                                    thread.Start((object)strInfo);


                                    //  ShowInfo(string.Format(info, custype));
                                    //出场信息
                                    BindOutInfo(cameraOneType, outtime.ToString("HH:mm:ss"), cartype, custype, plateid);
                                    //刷新泊位数量
                                    RefreshCount(CustomerConst.Customer, CustomerConst.PlusOperate);
                                    //RefreshParkInfo();
                                    //刷新最新收费信息
                                    RefreshChargeInfo();
                                    if (noInCar)
                                    {
                                        //插入临停车出入记录表
                                        InsertFCustomerInfo(plateid, e.color, outtime, "", e.imgPath, "临停车辆", "out");
                                    }
                                    else
                                    {
                                        //插入临停车出入记录表
                                        InsertFCustomerInfo(plateid, e.color, outtime, "", e.imgPath, "内部车辆", "out");
                                    }
                                    //播报车位数
                                    PlayBerth();

                                }
                                if (frmcharge.DialogResult == DialogResult.Cancel)
                                {
                                    Thread thread = new Thread(new ParameterizedThreadStart(ShowInfo));
                                    string strInfo = string.Format(info, custype);
                                    thread.Start((object)strInfo);

                                    //ShowInfo(string.Format(info, custype));
                                    //出场信息
                                    BindOutInfo(cameraOneType, outtime.ToString("HH:mm:ss"), cartype, custype, e.license);
                                    //刷新泊位数量
                                    RefreshCount(CustomerConst.FCustomer, CustomerConst.PlusOperate);
                                    RefreshParkInfo();
                                    //刷新最新收费信息
                                    RefreshChargeInfo();
                                    //插入固定车出入记录表
                                    // InsertFCustomerInfo(e.license, e.color, intime, "", e.imgPath, "固定车辆", "in");
                                    InsertFCustomerInfo(plateid, e.color, outtime, "", e.imgPath, cartype, "out");
                                   // InsertFCustomerInfo(plateid, e.color, outtime, e.imgPath, "", cartype, "in");


                                }
                            }
                        }
                    }
                }

                else
                {
                    //打开收费窗口，刷卡收费后放行
                    InputPalteCharge(e.imgPath, e.color);

                }
             //   #endregion
            }
          //  #endregion
        }
     //   #endregion
        private bool IsMoveCarUser(string plateid)
        {
            FCustomerManager fcu = new FCustomerManager();
            return fcu.GetMoveCarUser(plateid);
        }

        //根据车牌判断是否是一户多车，并检查是有有车辆入场
        private bool IsMoveCar(string plateid)
        {

            FCustomerManager fcu = new FCustomerManager();
            return fcu.GetMoveCar(plateid);

        }


        //根据车牌判断是否是一户多车，得到在未收费中的车牌号
        public string GetMoveCarPlateId(string plateid)
        {

            FCustomerManager fcu = new FCustomerManager();
            return fcu.GetMoveCarPlateId(plateid);

        }




        //根据车牌判断是否是一户多车，未交费记录
        public ChargeRecord GetUnCharge(string plateid)
        {
            DataSet ds = chargeRecordBLL.GetList(1, "plateid=" + "'" + plateid + "' and CardCode = '0'", "Id");
            if (ds.Tables[0].Rows.Count > 0)
            {
                return chargeRecordBLL.DataTableToList(ds.Tables[0]).First();
            }
            else
            {
                return null;
            }

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            oriPoint2 = e.Location;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //这个地方记录的是button1对于窗口的位置  
                Point newPos = panel2.Location;
                //适当调整button1的位置  
                newPos.Offset(e.Location.X - oriPoint2.X, e.Location.Y - oriPoint2.Y);
                //保证拖动后控件还在当前窗体的可见范围内  
                if (new Rectangle(0, 0, this.Width, this.Height).Contains(newPos))
                {
                    panel2.Location = newPos;
                }
                else
                {
                    panel2.Location = oriPoint2;
                }
            }
        }

        private void panel2_DoubleClick(object sender, EventArgs e)
        {
            string strtitle;
            if (!isWin1)
            {
                if (isWin2)
                {
                    groupPanel6.Controls.Clear();
                    groupPanel6.Controls.Add(In_axVZLPRClientCtrl);
                    In_axVZLPRClientCtrl.Dock = DockStyle.Fill;
                    groupPanel6.Controls.Add(panel2);
                    panel2.BringToFront();

                    panel2.Controls.Clear();
                    In_FouraxVZLPRClientCtrl.Dock = DockStyle.Bottom;
                    In_FouraxVZLPRClientCtrl.Size = new Size(96, 96);
                    panel2.Controls.Add(In_FouraxVZLPRClientCtrl);


                    strtitle = lb_FourName.Text;
                    lb_FourName.Text = groupPanel6.Text;
                    panel2.Controls.Add(lb_FourName);
                    groupPanel6.Text = strtitle;
                    lb_FourName.BringToFront();


                    In_FouraxVZLPRClientCtrl.BringToFront();


                    isWin2 = false;


                }
                else
                {

                    groupPanel6.Controls.Clear();
                    groupPanel6.Controls.Add(In_FouraxVZLPRClientCtrl);
                    In_FouraxVZLPRClientCtrl.Dock = DockStyle.Fill;
                    groupPanel6.Controls.Add(panel2);
                    panel2.BringToFront();

                    panel2.Controls.Clear();
                    In_axVZLPRClientCtrl.Dock = DockStyle.Bottom;
                    In_axVZLPRClientCtrl.Size = new Size(96, 96);
                    panel2.Controls.Add(In_axVZLPRClientCtrl);

                    strtitle = lb_FourName.Text;
                    lb_FourName.Text = groupPanel6.Text;
                    panel2.Controls.Add(lb_FourName);
                    groupPanel6.Text = strtitle;
                    lb_FourName.BringToFront();


                    In_axVZLPRClientCtrl.BringToFront();

                    isWin2 = true;
                }
                panel1.Controls.Add(In_ThreeaxVZLPRClientCtrl);
                groupPanel6.Controls.Add(panel1);
                panel1.BringToFront();
                In_ThreeaxVZLPRClientCtrl.BringToFront();

            }
        }

        private void In_ThreeaxVZLPRClientCtrl_OnLPRPlateImgOut(object sender, AxVZLPRClientCtrlLib._DVZLPRClientCtrlEvents_OnLPRPlateImgOutEvent e)
        {
            picInImg.Image = Image.FromFile(e.imagePath);
            inimgpath = e.imagePath;
            threeimagepath = e.imagePath;
        }

        private void In_ThreeaxVZLPRClientCtrl_OnLPRPlateInfoOutEx(object sender, AxVZLPRClientCtrlLib._DVZLPRClientCtrlEvents_OnLPRPlateInfoOutExEvent e)
        {
            fCustomerModel = null;
            int overday = iniinfo.OverDay;
          
                //   string tips; //提示信息
                DateTime intime = DateTime.Now;
                string custype = string.Empty;
                string cartype = string.Empty;
                string info = string.Empty;


            //  #region 完成识别

            //判断是否识别正确
            if (Isplateid(e.license))
            {

                // 确认确认是否开闸
                if (!isOneIn(e.license))
                {
                    cartype = GetCarType(e.nType);
                    FCustomer fmodel = GetFCustomer(e.license);
                    custype = CustomerConst.FCustomer;
                    string ctype = string.Empty;
                    bool noInCar = true;
                    if (fmodel != null)
                    {
                        ctype = GetFCustomer(e.license).CarType;
                    }
                    if (!string.IsNullOrEmpty(ctype))
                    {
                        noInCar = !ctype.Equals("内部车辆");
                    }

                    if (iniinfo.IsOpenNotConfirm != "True"|| InCarAutoOpen)
                    {
                        //临停车确认是否开闸
                        if (GetFCustomer(e.license) == null)
                        {
                            frmCheck frmcheck = new frmCheck(e.license, cartype, "in");
                            DialogResult dr = frmcheck.ShowDialog();
                            if (dr == DialogResult.OK)
                            {
                                e.license = frmcheck.PlateId;
                                cartype = frmcheck.CarType;
                            }
                            else
                            {
                                return;
                            }
                        }
                    }

                    //内部车确认是否开闸
                    if (!noInCar && InCarAutoOpen)
                    {
                        frmCheck frmcheck = new frmCheck(e.license, cartype, "in");
                        DialogResult dr = frmcheck.ShowDialog();
                        if (dr == DialogResult.OK)
                        {
                            e.license = frmcheck.PlateId;
                            cartype = frmcheck.CarType;
                        }
                        else
                        {
                            return;
                        }
                    }



                    //插入车辆出入记录表
                    InsertIdentifyInfo(e.license, e.color, e.colorIndex, e.nType, e.confidence, e.bright, e.nDirection, e.time, e.carBright, e.carColor, e.imgPath, e.ip, e.resultType, intime, "InTime");
                    info = "车牌" + e.license + ";车主类型:" + "{0}" + ";入场时间:" + intime.ToString("HH:mm:ss");

                    //判断是否是月租车

                    //   #region 月租车

                    if (GetFCustomer(e.license) != null && noInCar)
                    {

                        //是月租车，判断是否在有效期内，在有效期内
                        if (IsValCustomer(e.license))
                        {
                            //月租车在有效期内，再判断车位是否被占 2016.7.20jyb
                            //如果不被占用当固定车辆，如被点用，当临时车车辆
                            //  IsMoveCar(e.license);
                            //如果是一户多车，已有车辆入场，另一个需同时插入收费信息表
                            if (str_MoveCar != "-1")
                            {
                                if (IsMoveCar(e.license))
                                {
                                    custype = "一户多车";
                                    InsertChargeRecord(e.license, cartype, intime, e.imgPath, custype, "");
                                }
                            }
                            //
                            string time = fCustomerModel.OverTime.ToString();
                            TimeSpan timespan = Convert.ToDateTime(time) - DateTime.Now;
                            string lefttime = ((int)timespan.TotalDays).ToString();




                            if (Convert.ToInt32(lefttime) <= overday)
                            {
                                //播报

                                ThreePlay(e.license, "欢迎光临," + e.license + ",剩余" + lefttime + "天,请交费");


                            }
                            else
                            {
                                //播报
                                ThreePlay(e.license, e.license + "," + content);

                            }


                            OpenThreeDaozha();

                            // custype = CustomerConst.FCustomer;
                            Thread thread = new Thread(new ParameterizedThreadStart(ShowInfo));
                            string strInfo = string.Format(info, custype);
                            thread.Start((object)strInfo);
                            //  ShowInfo(string.Format(info, custype));
                            //进场场信息
                            BindInInfo(cameraOneType, intime.ToString("HH:mm:ss"), cartype, custype, e.license);
                            //插入固定车出入记录表
                            InsertFCustomerInfo(e.license, e.color, intime, e.imgPath, "", "固定车辆", "in");
                            //刷新泊位数量
                            RefreshCount(CustomerConst.FCustomer, CustomerConst.SubOperate);
                            //RefreshParkInfo();
                            //显示车位
                            //PlayBerth();
                        }
                        else
                        {
                            string time = string.Empty;

                            //    #region 过期固定客户收费

                            if (iniinfo.IsFCustomerFee == "True")
                            {
                                fCustomerModel = GetFCustomer(e.license);
                                if (fCustomerModel != null)
                                {
                                    //if (!string.IsNullOrEmpty(GetInTime(e.license)))
                                    //{
                                    //    MessageHelper.ShowTips("车辆【" + e.license + "】已有进场信息！");
                                    //    return;
                                    //}
                                    time = fCustomerModel.OverTime.ToString();
                                    if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(time)) > 0)
                                    {
                                        TimeSpan timespan = DateTime.Now - Convert.ToDateTime(time);
                                        string overtime = ((int)timespan.TotalDays).ToString();
                                        //播报

                                        ThreePlay(e.license, "欢迎光临," + e.license + ",已过期,请交费");

                                    }
                                    OpenThreeDaozha();
                                    custype = CustomerConst.OFCustomer;
                                    ShowInfo(string.Format(info, custype));
                                    //插入固定车出入记录表
                                    InsertFCustomerInfo(e.license, e.color, intime, e.imgPath, "", "固定车辆", "in");
                                    //插入临时车辆收费记录表
                                    InsertChargeRecord(e.license, cartype, intime, e.imgPath, custype, "");
                                    //进场场信息
                                    BindInInfo(cameraOneType, intime.ToString("HH:mm:ss"), cartype, custype, e.license);
                                    //刷新泊位数量
                                    RefreshCount(CustomerConst.FCustomer, CustomerConst.SubOperate);
                                    //RefreshParkInfo();
                                    //显示车位
                                    PlayBerth();
                                }

                            }
                            //    #endregion
                            #region 过期固定客户提示过期，不收费

                            else
                            {
                                time = fCustomerModel.OverTime.ToString();
                                if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(time)) > 0)
                                {
                                    TimeSpan timespan = DateTime.Now - Convert.ToDateTime(time);
                                    string overtime = ((int)timespan.TotalDays).ToString();
                                    ThreePlay(e.license, "欢迎光临," + e.license + ",已过期,请交费");
                                }
                                else
                                {
                                    //播报
                                    ThreePlay(e.license, e.license + "," + content);
                                }
                                OpenThreeDaozha();
                                custype = CustomerConst.OFCustomer;
                                ShowInfo(string.Format(info, custype));
                                //插入固定车出入记录表
                                InsertFCustomerInfo(e.license, e.color, intime, e.imgPath, "", "固定车辆", "in");
                                //进场场信息
                                BindInInfo(cameraOneType, intime.ToString("HH:mm:ss"), cartype, custype, e.license);
                                //刷新泊位数量
                                RefreshCount(CustomerConst.FCustomer, CustomerConst.SubOperate);
                                //RefreshParkInfo();
                                //显示车位
                                PlayBerth();

                            }

                            #endregion

                        }
                    }
                    //    #endregion
                    #region 临停车,内部车辆

                    else //临时停车记录
                    {
                        #region 临停车辆不能重复入场（屏蔽）

                        //      if (!string.IsNullOrEmpty(GetInTime(e.license)))
                        //{
                        //    MessageHelper.ShowTips("车辆【" + e.license + "】已有进场信息！");
                        //    return;
                        //} 

                        #endregion


                        //播报
                        ThreePlay(e.license, e.license + "," + content);
                        //开闸
                        OpenThreeDaozha();
                        //插入临时车辆出入记录表
                        if (!noInCar)
                        {
                            cartype = "内部车辆";
                            custype = CustomerConst.InCustomer;
                            //插入临停车出入记录表
                            InsertFCustomerInfo(e.license, e.color, intime, e.imgPath, "", cartype, "in");
                        }
                        else
                        {
                            custype = CustomerConst.Customer;
                            //插入临停车出入记录表
                            InsertFCustomerInfo(e.license, e.color, intime, e.imgPath, "", "临停车辆", "in");
                        }

                        ShowInfo(string.Format(info, custype));
                        InsertChargeRecord(e.license, cartype, intime, e.imgPath, custype, "");
                        //进场场信息
                        BindInInfo(cameraOneType, intime.ToString("HH:mm:ss"), cartype, custype, e.license);
                        //刷新泊位数量
                        RefreshCount(CustomerConst.Customer, CustomerConst.SubOperate);
                        //RefreshParkInfo();
                        //显示车位
                        PlayBerth();
                    }

                    #endregion
                }
            }

            //    #endregion
            //   #region 识别未完成，手动识别

            else
            {
                InInputPalte(e.imgPath, e.color, "Three");

            }

            

        }
        private void In_axVZLPRClientCtrl_OnLPRPlateImgOut(object sender,
                                                           AxVZLPRClientCtrlLib.
                                                               _DVZLPRClientCtrlEvents_OnLPRPlateImgOutEvent e)
        {
            picInImg.Image = Image.FromFile(e.imagePath);
            inimgpath = e.imagePath;
        }

        private void button3_Click(object sender, EventArgs e)
        {
          MessageBox.Show(CalulateFee(dateTimePicker1.Value, "小型车").ToString());
        }

        private void butcharge_Click(object sender, EventArgs e)
        {
            frmChargeInfo frmcharge = new frmChargeInfo();
            frmcharge.TopMost = true;
            frmcharge.ShowDialog();
        }

        private void ZXJK_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Out_axVZLPRClientCtrl_OnLPRPlateInfoOutEx(object sender,
                                                               AxVZLPRClientCtrlLib.
                                                                   _DVZLPRClientCtrlEvents_OnLPRPlateInfoOutExEvent e)
        {
            fCustomerModel = null;
            int overday = iniinfo.OverDay;
            if (cameraTwoType == "入口设备")
            {

                //   string tips; //提示信息
                DateTime intime = DateTime.Now;
                string custype = string.Empty;
                string cartype = string.Empty;
                string info = string.Empty;


                #region 完成识别

                //判断是否识别正确
                if (Isplateid(e.license))
                {
                    #region 确认确认是否开闸
                   // cartype = GetCarType(e.nType);
                    //if (iniinfo.IsOpenNotConfirm != "True"|| InCarAutoOpen)
                    //{
                    //    //临停车确认是否开闸
                    //    if (GetFCustomer(e.license) == null)
                    //    {
                    //        frmCheck frmcheck = new frmCheck(e.license, cartype, "in");
                    //        DialogResult dr = frmcheck.ShowDialog();
                    //        if (dr == DialogResult.OK)
                    //        {
                    //            e.license = frmcheck.PlateId;
                    //            cartype = frmcheck.CarType;
                    //        }
                    //        else
                    //        {
                    //            return;
                    //        }
                    //    }

                    //}

                    #endregion
                    cartype = GetCarType(e.nType);
                    FCustomer fmodel = GetFCustomer(e.license);
                    custype = CustomerConst.FCustomer;
                    string ctype = string.Empty;
                    bool noInCar = true;
                    if (fmodel != null)
                    {
                        ctype = GetFCustomer(e.license).CarType;
                    }
                    if (!string.IsNullOrEmpty(ctype))
                    {
                        noInCar = !ctype.Equals("内部车辆");
                    }

                    if (iniinfo.IsOpenNotConfirm != "True" || InCarAutoOpen)
                    {
                        //临停车确认是否开闸
                        if (GetFCustomer(e.license) == null)
                        {
                            frmCheck frmcheck = new frmCheck(e.license, cartype, "in");
                            DialogResult dr = frmcheck.ShowDialog();
                            if (dr == DialogResult.OK)
                            {
                                e.license = frmcheck.PlateId;
                                cartype = frmcheck.CarType;
                            }
                            else
                            {
                                return;
                            }
                        }
                    }

                    //内部车确认是否开闸
                    if (!noInCar && InCarAutoOpen)
                    {
                        frmCheck frmcheck = new frmCheck(e.license, cartype, "in");
                        DialogResult dr = frmcheck.ShowDialog();
                        if (dr == DialogResult.OK)
                        {
                            e.license = frmcheck.PlateId;
                            cartype = frmcheck.CarType;
                        }
                        else
                        {
                            return;
                        }
                    }

                    //插入车辆出入记录表
                    InsertIdentifyInfo(e.license, e.color, e.colorIndex, e.nType, e.confidence, e.bright, e.nDirection,e.time, e.carBright, e.carColor, e.imgPath, e.ip, e.resultType, intime, "InTime");
                    info = "车牌" + e.license + ";车主类型:" + "{0}" + ";入场时间:" + intime.ToString("HH:mm:ss");

                    //判断是否是月租车

                    #region 月租车

                    if (GetFCustomer(e.license) != null && noInCar)
                    {

                        //是月租车，判断是否在有效期内，在有效期内
                        if (IsValCustomer(e.license))
                        {
                            //月租车在有效期内，再判断车位是否被占 2016.7.20jyb
                            //如果不被占用当固定车辆，如被点用，当临时车车辆
                            //  IsMoveCar(e.license);
                            //如果是一户多车，已有车辆入场，另一个需同时插入收费信息表
                            if (str_MoveCar != "-1")
                            {
                                if (IsMoveCar(e.license))
                                {
                                    custype = "一户多车";
                                    InsertChargeRecord(e.license, cartype, intime, e.imgPath, custype, "");
                                }
                            }
                            //
                            string time = fCustomerModel.OverTime.ToString();
                            TimeSpan timespan = Convert.ToDateTime(time) - DateTime.Now;
                            string lefttime = ((int)timespan.TotalDays).ToString();
                            if (Convert.ToInt32(lefttime) <= overday)
                            {
                                //播报
                                OutPlay(e.license, "欢迎光临," + e.license + ",剩余" + lefttime + "天,请交费。");

                            }
                            else
                            {
                                //播报
                                OutPlay(e.license, e.license + "," + content);

                            }
                            OpenOutDaozha();
                            // custype = CustomerConst.FCustomer;
                            ShowInfo(string.Format(info, custype));
                            //进场场信息
                            BindInInfo(cameraTwoType, intime.ToString("HH:mm:ss"), cartype, custype, e.license);
                            //插入固定车出入记录表
                            InsertFCustomerInfo(e.license, e.color, intime, e.imgPath, "", "固定车辆", "in");
                            //刷新泊位数量
                            RefreshCount(CustomerConst.FCustomer, CustomerConst.SubOperate);
                            //RefreshParkInfo();
                            //显示车位
                            PlayBerth();
                        }
                        else
                        {
                            string time = string.Empty;

                            #region 过期固定客户收费

                            if (iniinfo.IsFCustomerFee == "True")
                            {
                                fCustomerModel = GetFCustomer(e.license);
                                if (fCustomerModel != null)
                                {
                                    //if (!string.IsNullOrEmpty(GetInTime(e.license)))
                                    //{
                                    //    MessageHelper.ShowTips("车辆【" + e.license + "】已有进场信息！");
                                    //    return;
                                    //}
                                    time = fCustomerModel.OverTime.ToString();
                                    if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(time)) > 0)
                                    {
                                        TimeSpan timespan = DateTime.Now - Convert.ToDateTime(time);
                                        string overtime = ((int)timespan.TotalDays).ToString();
                                        //播报
                                        OutPlay(e.license, "欢迎光临," + e.license + ",已过期,请交费");

                                    }
                                    OpenOutDaozha();
                                    custype = CustomerConst.OFCustomer;
                                    ShowInfo(string.Format(info, custype));
                                    //插入固定车出入记录表
                                    InsertFCustomerInfo(e.license, e.color, intime, e.imgPath, "", "固定车辆", "in");
                                    //插入临时车辆收费记录表
                                    InsertChargeRecord(e.license, cartype, intime, e.imgPath, custype, "");
                                    //进场场信息
                                    BindInInfo(cameraTwoType, intime.ToString("HH:mm:ss"), cartype, custype, e.license);
                                    //刷新泊位数量
                                    RefreshCount(CustomerConst.FCustomer, CustomerConst.SubOperate);
                                    //RefreshParkInfo();
                                    //显示车位
                                    PlayBerth();
                                }

                            }
                            #endregion
                            #region 过期固定客户提示过期，不收费

                            else
                            {
                                time = fCustomerModel.OverTime.ToString();


                                string PlayText="";
                                if (iniinfo.FcarplayNo=="True")
                                {
                                    PlayText = e.license + "," + content;

                                }
                                else
                                {
                                    PlayText =  content;


                                }


                                if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(time)) > 0)
                                {
                                    TimeSpan timespan = DateTime.Now - Convert.ToDateTime(time);
                                    string overtime = ((int)timespan.TotalDays).ToString();
                                    OutPlay(e.license, "欢迎光临," + e.license + ",已过期,请交费");
                                }
                                else
                                {
                                    //播报
                                    OutPlay(e.license, PlayText);
                                }
                                OpenOutDaozha();
                                custype = CustomerConst.OFCustomer;
                                ShowInfo(string.Format(info, custype));
                                //插入固定车出入记录表
                                InsertFCustomerInfo(e.license, e.color, intime, e.imgPath, "", "固定车辆", "in");
                                //进场场信息
                                BindInInfo(cameraTwoType, intime.ToString("HH:mm:ss"), cartype, custype, e.license);
                                //刷新泊位数量
                                RefreshCount(CustomerConst.FCustomer, CustomerConst.SubOperate);
                                //RefreshParkInfo();
                                //显示车位
                                PlayBerth();

                            }

                            #endregion

                        }
                    }
                    #endregion
                    #region 临停车,内部车辆

                    else //临时停车记录
                    {
                        #region 临停车辆不能重复入场（屏蔽）

                        //      if (!string.IsNullOrEmpty(GetInTime(e.license)))
                        //{
                        //    MessageHelper.ShowTips("车辆【" + e.license + "】已有进场信息！");
                        //    return;
                        //} 

                        #endregion


                        //播报
                        OutPlay(e.license, e.license + "," + content);
                        //开闸
                        OpenOutDaozha();
                        //插入临时车辆出入记录表
                        if (!noInCar)
                        {
                            cartype = "内部车辆";
                            custype = CustomerConst.InCustomer;
                            //插入临停车出入记录表
                            InsertFCustomerInfo(e.license, e.color, intime, e.imgPath, "", cartype, "in");
                        }
                        else
                        {
                            custype = CustomerConst.Customer;
                            //插入临停车出入记录表
                            InsertFCustomerInfo(e.license, e.color, intime, e.imgPath, "", "临停车辆", "in");
                        }

                        ShowInfo(string.Format(info, custype));
                        InsertChargeRecord(e.license, cartype, intime, e.imgPath, custype, "");
                        //进场场信息
                        BindInInfo(cameraTwoType, intime.ToString("HH:mm:ss"), cartype, custype, e.license);
                        //刷新泊位数量
                        RefreshCount(CustomerConst.Customer, CustomerConst.SubOperate);
                        //RefreshParkInfo();
                        //显示车位
                        PlayBerth();
                    }

                    #endregion
                }
                #endregion
                #region 识别未完成，手动识别

                else
                {

                    InInputPalte(e.imgPath, e.color,"Two");

                }

            }


            if (cameraTwoType == "出口设备")
            {


                //  string tips; //提示信息
                DateTime outtime = DateTime.Now;
                string info = string.Empty;
                string custype = string.Empty;
                string cartype = string.Empty;
                string outcontent = "一路平安";


                string time = string.Empty;
                DateTime intime;
                string parktime = string.Empty;
                decimal summoney = 0;
                string plateid = string.Empty;
                string chrageplaeid = string.Empty;

                //判断是否识别正确;
                if (Isplateid(e.license))
                {
                    plateid = e.license;
                    if(isOneOut(plateid))
                    { 
                    ChargeRecord chgrecord = GetRecordModel(plateid);
                    //车辆类型
                    if (chgrecord != null)
                    {
                        if (!string.IsNullOrWhiteSpace(chgrecord.CarType))
                        {
                            cartype = chgrecord.CarType;
                        }
                        else
                        {
                            cartype = GetCarType(e.nType);
                        }

                    }
                    else
                    {
                        cartype = GetCarType(e.nType);
                    }
                    //插入车辆出入记录表
                    InsertIdentifyInfo(e.license, e.color, e.colorIndex, e.nType, e.confidence, e.bright, e.nDirection,e.time, e.carBright, e.carColor, e.imgPath, e.ip, e.resultType, outtime, "OutTime");
                    info = "车牌" + plateid + ";车主类型:" + "{0}" + ";出场时间:" + outtime.ToString("HH:mm:ss");
                    bool noInCar = !IsInnerCar(plateid);
                    //固定车且不为内部车的情况
                    if (GetFCustomer(plateid) != null && noInCar)
                    {
                        //判断是否在有效果内，在有效期内
                        if (IsValCustomer(plateid))
                        {
                            //   如果是一户多车，则执行，否则直接出场。
                            if (str_MoveCar != "-1")
                            {

                                if (string.IsNullOrEmpty(GetInTime(plateid)))
                                {

                                    if (str_MoveCar == "1")
                                    {
                                        string getMovePlateId;
                                        getMovePlateId = GetMoveCarPlateId(plateid).Trim();//得到本户下未交费车辆信息
                                        chargeRecordModel = GetChargeModeByPlateId(getMovePlateId);
                                    //    #region 一户多车下，有另一辆车是临时车，所以在本车辆出库时将计算第二辆费用，并支付。
                                        if (chargeRecordModel != null)
                                        {

                                            time = chargeRecordModel.InTime.ToString();
                                            intime = Convert.ToDateTime(time);
                                            cartype = chargeRecordModel.CarType;
                                            summoney = CalulateFee(intime, cartype);
                                            //绑定数据
                                            TimeSpan span = outtime - intime;
                                            if (span.Days > 0)
                                            {
                                                parktime = span.Days + "天" + span.Hours + "小时" + span.Hours + "分钟";
                                            }
                                            else
                                            {
                                                parktime = span.Hours + "小时" + span.Minutes + "分钟";

                                            }

                                            string tips = "一户多车用户，车牌 【" + plateid + "】未记费，另一辆【" + getMovePlateId + "】已在本车场内，已达到记费条件，请交费。";
                                            MessageHelper.ShowTips(tips);

                                            frmCharge frmcharge = new frmCharge(getMovePlateId, cartype, intime, outtime, parktime, feeStandard,
                                summoney, outimgpath, Out_axVZLPRClientCtrl.Name);
                                            frmcharge.Owner = this;
                                            frmcharge.ShowDialog();
                                            custype = "一户多车";


                                            //更新数据库
                                            //1、更新收费记录表
                                            //2、固定车出场
                                            //3、回定车入场
                                            //4、如果设置第二次始终为临停车，则不进行结算操作

                                            if (frmcharge.DialogResult == DialogResult.OK)
                                            {
                                                OpenOutDaozha();
                                                ShowInfo(string.Format(info, custype));
                                                //出场信息
                                                BindOutInfo(cameraTwoType, outtime.ToString("HH:mm:ss"), cartype, custype, e.license);
                                                //刷新泊位数量
                                                RefreshCount(CustomerConst.FCustomer, CustomerConst.PlusOperate);
                                                RefreshParkInfo();
                                                //刷新最新收费信息
                                                RefreshChargeInfo();
                                                //插入固定车出入记录表
                                                // InsertFCustomerInfo(e.license, e.color, intime, "", e.imgPath, "固定车辆", "in");
                                                InsertFCustomerInfo(getMovePlateId, e.color, outtime, "", e.imgPath, cartype, "out");
                                                InsertFCustomerInfo(getMovePlateId, e.color, outtime, e.imgPath, "", cartype, "in");
                                            }
                                            if (frmcharge.DialogResult == DialogResult.Cancel)
                                            {
                                                ShowInfo(string.Format(info, custype));
                                                //出场信息
                                                BindOutInfo(cameraOneType, outtime.ToString("HH:mm:ss"), cartype, custype, e.license);
                                                //刷新泊位数量
                                                RefreshCount(CustomerConst.FCustomer, CustomerConst.PlusOperate);
                                                RefreshParkInfo();
                                                //刷新最新收费信息
                                                RefreshChargeInfo();
                                                //插入固定车出入记录表
                                                // InsertFCustomerInfo(e.license, e.color, intime, "", e.imgPath, "固定车辆", "in");
                                                InsertFCustomerInfo(getMovePlateId, e.color, outtime, "", e.imgPath, cartype, "out");
                                                InsertFCustomerInfo(getMovePlateId, e.color, outtime, e.imgPath, "", cartype, "in");


                                            }

                                        }
                                        else
                                        {
                                            //自动开闸
                                            OpenOutDaozha();
                                            custype = CustomerConst.FCustomer;
                                            ShowInfo(string.Format(info, custype));

                                            //播报

                                            string PlayText = "";
                                            if (iniinfo.FcarplayNo == "True")
                                            {
                                                PlayText = plateid + "," + outcontent;

                                            }
                                            else
                                            {
                                                PlayText = outcontent;


                                            }


                                            OutPlay(plateid, PlayText);

                                            //插入固定车出入记录表
                                            InsertFCustomerInfo(e.license, e.color, outtime, "", e.imgPath, "固定车辆", "out");
                                            //出场信息
                                            BindOutInfo(cameraTwoType, outtime.ToString("HH:mm:ss"), cartype, custype, e.license);
                                            //刷新泊位数量
                                            RefreshCount(CustomerConst.FCustomer, CustomerConst.PlusOperate);
                                            RefreshParkInfo();
                                            //刷新最新收费信息
                                            RefreshChargeInfo();
                                        }
                                        #endregion
                                    }
                                    if (str_MoveCar == "0")
                                    {
                                        OpenOutDaozha();

                                        string time1 = fCustomerModel.OverTime.ToString();
                                        TimeSpan timespan = Convert.ToDateTime(time1) - DateTime.Now;
                                        string lefttime = ((int)timespan.TotalDays).ToString();
                                        //自动开闸

                                        string PlayText = "";
                                        if (iniinfo.FcarplayNo == "True")
                                        {
                                            PlayText = plateid + "," + outcontent;

                                        }
                                        else
                                        {
                                            PlayText = outcontent;


                                        }


                                        if (Convert.ToInt32(lefttime) <= overday)
                                        {
                                            //播报
                                            OutPlay(plateid, plateid + ",剩余" + lefttime + "天,请交费，一路平安。");

                                        }
                                        else
                                        {

                                            //播报
                                            OutPlay(plateid, PlayText);

                                        }

                                        custype = CustomerConst.FCustomer;

                                        Thread thread = new Thread(new ParameterizedThreadStart(ShowInfo));
                                        string strInfo = string.Format(info, custype);
                                        thread.Start((object)strInfo);

                                        //  ShowInfo(string.Format(info, custype));

                                        //插入固定车出入记录表
                                        InsertFCustomerInfo(plateid, e.color, outtime, "", e.imgPath, "固定车辆", "out");
                                        //出场信息
                                        BindOutInfo(cameraTwoType, outtime.ToString("HH:mm:ss"), cartype, custype, plateid);
                                        //刷新泊位数量
                                        RefreshCount(CustomerConst.FCustomer, CustomerConst.PlusOperate);
                                        RefreshParkInfo();
                                        //刷新最新收费信息
                                        RefreshChargeInfo();


                                    }
                                }
                                else
                                {

                                    time = GetInTime(plateid);
                                    intime = Convert.ToDateTime(time);
                                    summoney = CalulateFee(intime, cartype);
                                    TimeSpan timeSpan = outtime - intime;
                                    parktime = string.Empty;
                                    if (timeSpan.Days > 0)
                                    {
                                        parktime = timeSpan.Days + "天" + timeSpan.Hours.ToString() + "小时" +
                                                   timeSpan.Minutes.ToString() + "分钟";
                                    }
                                    else
                                    {
                                        parktime = timeSpan.Hours.ToString() + "小时" +
                                                   timeSpan.Minutes.ToString() + "分钟";
                                    }
                                    if (iniinfo.AutoOpen == "True" && summoney == 0)
                                    {
                                        //自动开闸
                                        OpenOutDaozha();
                                        //   custype = CustomerConst.FCustomer;
                                        custype = "一户多车";
                                        ShowInfo(string.Format(info, custype));
                                        //插入固定车出入记录表
                                        InsertFCustomerInfo(plateid, e.color, outtime, "", e.imgPath, "一户多车", "out");
                                        //出场信息
                                        BindOutInfo(cameraTwoType, outtime.ToString("HH:mm:ss"), cartype, custype, plateid);
                                        //刷新泊位数量
                                        RefreshCount(CustomerConst.FCustomer, CustomerConst.PlusOperate);
                                        RefreshParkInfo();
                                        //刷新最新收费信息
                                        RefreshChargeInfo();
                                    }
                                    else
                                    {

                                        frmCharge frmcharge = new frmCharge(plateid, cartype, intime, outtime,parktime, feeStandard,
                         summoney, outimgpath, Out_axVZLPRClientCtrl.Name);
                                        frmcharge.Owner = this;
                                        frmcharge.ShowDialog();
                                        custype = "一户多车";

                                        if (frmcharge.DialogResult == DialogResult.OK)
                                        {
                                            OpenOutDaozha();
                                            ShowInfo(string.Format(info, custype));
                                            //出场信息
                                            BindOutInfo(cameraTwoType, outtime.ToString("HH:mm:ss"), cartype, custype, plateid);
                                            //刷新泊位数量
                                            RefreshCount(CustomerConst.FCustomer, CustomerConst.PlusOperate);
                                            RefreshParkInfo();
                                            //刷新最新收费信息
                                            RefreshChargeInfo();
                                            //插入固定车出入记录表
                                            // InsertFCustomerInfo(e.license, e.color, intime, "", e.imgPath, "固定车辆", "in");
                                            InsertFCustomerInfo(plateid, e.color, outtime, e.imgPath, "", cartype, "out");
                                            InsertFCustomerInfo(plateid, e.color, outtime, "", e.imgPath, cartype, "in");
                                        }
                                        if (frmcharge.DialogResult == DialogResult.Cancel)
                                        {
                                            ShowInfo(string.Format(info, custype));
                                            //出场信息
                                            BindOutInfo(cameraOneType, outtime.ToString("HH:mm:ss"), cartype, custype, e.license);
                                            //刷新泊位数量
                                            RefreshCount(CustomerConst.FCustomer, CustomerConst.PlusOperate);
                                            RefreshParkInfo();
                                            //刷新最新收费信息
                                            RefreshChargeInfo();
                                            //插入固定车出入记录表
                                            // InsertFCustomerInfo(e.license, e.color, intime, "", e.imgPath, "固定车辆", "in");
                                            InsertFCustomerInfo(plateid, e.color, outtime, "", e.imgPath, cartype, "out");
                                            InsertFCustomerInfo(plateid, e.color, outtime, e.imgPath, "", cartype, "in");


                                        }

                                    }




                                }

                                
                            }
                            else
                            {
                                //自动开闸
                                OpenOutDaozha();

                                string time1 = fCustomerModel.OverTime.ToString();
                                TimeSpan timespan = Convert.ToDateTime(time1) - DateTime.Now;
                                string lefttime = ((int)timespan.TotalDays).ToString();
                                //自动开闸


                                string PlayText = "";
                                if (iniinfo.FcarplayNo == "True")
                                {
                                    PlayText = plateid + "," + outcontent;

                                }
                                else
                                {
                                    PlayText = outcontent;


                                }

                                if (Convert.ToInt32(lefttime) <= overday)
                                {
                                    //播报
                                    OutPlay(plateid, plateid + ",剩余" + lefttime + "天,请交费，一路平安。");

                                }
                                else
                                {

                                    //播报
                                    OutPlay(plateid, PlayText);

                                }





                                custype = CustomerConst.FCustomer;
                                ShowInfo(string.Format(info, custype));
                                //插入固定车出入记录表
                              //  OutPlay(plateid, plateid + "," + outcontent);

                                InsertFCustomerInfo(e.license, e.color, outtime, "", e.imgPath, "固定车辆", "out");
                                //出场信息
                                BindOutInfo(cameraTwoType, outtime.ToString("HH:mm:ss"), cartype, custype, e.license);
                                //刷新泊位数量
                                RefreshCount(CustomerConst.FCustomer, CustomerConst.PlusOperate);
                                RefreshParkInfo();
                                //刷新最新收费信息
                                RefreshChargeInfo();


                            }


                        }

                        else
                        {
                            custype = CustomerConst.OFCustomer;

                            //   #region 过期客户收费

                            //过期固定客户收费
                            if (iniinfo.IsFCustomerFee == "True")
                            {
                                if (string.IsNullOrEmpty(GetInTime(plateid)))
                                {
                                    MessageHelper.ShowTips("车辆【" + plateid + "】没有进场信息！");
                                    return;
                                }
                                string outimgpath = e.imgPath;
                                intime = Convert.ToDateTime(GetInTime(plateid));
                                summoney = CalulateFee(intime, cartype);
                                TimeSpan timeSpan = outtime - intime;
                                parktime = string.Empty;
                                if (timeSpan.Days > 0)
                                {
                                    parktime = timeSpan.Days + "天" + timeSpan.Hours.ToString() + "小时" +
                                               timeSpan.Minutes.ToString() + "分钟";
                                }
                                else
                                {
                                    parktime = timeSpan.Hours.ToString() + "小时" +
                                               timeSpan.Minutes.ToString() + "分钟";
                                }
                                frmCharge frmcharge = new frmCharge(plateid, cartype, intime, outtime, parktime,
                                                                    feeStandard,
                                                                    summoney, outimgpath, Out_axVZLPRClientCtrl.Name);
                                frmcharge.Owner = this;
                                frmcharge.ShowDialog();
                                custype = frmcharge.CusType;
                                if (frmcharge.DialogResult == DialogResult.OK)
                                {
                                    OpenOutDaozha();
                                    ShowInfo(string.Format(info, custype));
                                    //出场信息
                                    BindOutInfo(cameraTwoType, outtime.ToString("HH:mm:ss"), cartype, custype, plateid);
                                    //刷新泊位数量
                                    RefreshCount(CustomerConst.FCustomer, CustomerConst.PlusOperate);
                                    RefreshParkInfo();
                                    //刷新最新收费信息
                                    RefreshChargeInfo();
                                    //插入固定车出入记录表
                                    InsertFCustomerInfo(plateid, e.color, intime, "", e.imgPath, "固定车辆", "in");
                                }
                                if (frmcharge.DialogResult == DialogResult.Cancel)
                                {
                                    ShowInfo(string.Format(info, custype));
                                    //出场信息
                                    BindOutInfo(cameraTwoType, outtime.ToString("HH:mm:ss"), cartype, custype, e.license);
                                    //刷新泊位数量
                                    RefreshCount(CustomerConst.FCustomer, CustomerConst.PlusOperate);
                                    RefreshParkInfo();
                                    //刷新最新收费信息
                                    RefreshChargeInfo();
                                    //插入固定车出入记录表
                                    // InsertFCustomerInfo(e.license, e.color, intime, "", e.imgPath, "固定车辆", "in");
                                    InsertFCustomerInfo(plateid, e.color, outtime, "", e.imgPath, cartype, "out");
                                  //  InsertFCustomerInfo(plateid, e.color, outtime, e.imgPath, "", cartype, "in");


                                }

                            }


                            else
                            {

                                //播报
                                if (!string.IsNullOrEmpty(TwoLedAddr1))
                                {
                                    OutPlay(plateid, plateid+","+ outcontent);
                                }
                                //开闸
                                OpenOutDaozha();
                                ShowInfo(string.Format(info, custype));
                                //出场信息
                                BindOutInfo(cameraTwoType, outtime.ToString("HH:mm:ss"), cartype, custype, plateid);
                                //刷新泊位数量
                                RefreshCount(CustomerConst.FCustomer, CustomerConst.PlusOperate);
                                RefreshParkInfo();
                                //刷新最新收费信息
                                RefreshChargeInfo();
                                //插入固定车出入记录表
                                InsertFCustomerInfo(plateid, e.color, outtime, "", e.imgPath, "固定车辆", "out");
                                //showcontext = "车牌为:" + e.license + "的车主,您的月卡已到期，请及时续费";
                            }
                        }
                    }
                    else
                    {
                     //   #region 临停客户
                        //if (iniinfo.IsOpenNotConfirm != "True")
                        //{
                        //    //临停车确认是否开闸
                        //    if (GetFCustomer(e.license) == null)
                        //    {
                        //        frmCheck outfrmcheck = new frmCheck(e.license, cartype, "out");
                        //        DialogResult dr = outfrmcheck.ShowDialog();
                        //        if (dr == DialogResult.OK)
                        //        {
                        //            e.license = outfrmcheck.PlateId;
                        //            cartype = outfrmcheck.CarType;
                        //        }
                        //        else
                        //        {
                        //            return;
                        //        }
                        //    }

                        //}
                        //不存在进场记录
                        if (string.IsNullOrEmpty(GetInTime(plateid)))
                        {
                            #region 没有检测到入场信息，手动收费

                            if (MessageHelper.ConfirmYesNo("没有检测到车辆【" + plateid + "】的入场信息，请点击【是】手动收费！"))
                            {
                                frmManualFee frmmanualfee = new frmManualFee(Out_axVZLPRClientCtrl.Name);
                                frmmanualfee.Owner = this;
                                frmmanualfee.ShowDialog();
                                if (frmmanualfee.DialogResult == DialogResult.OK)
                                {
                                    if (frmmanualfee.CType == CustomerConst.FCustomer)
                                    {
                                        if (MessageHelper.ConfirmYesNo("固定车辆，请点击【是】放行！"))
                                        {
                                            OpenOutDaozha();
                                        }
                                    }
                                    else
                                    {
                                        OpenOutDaozha();
                                        string meg = string.Empty;
                                        if (frmmanualfee.Tag == "1")
                                        {
                                            meg = "车牌" + frmmanualfee.PlateId;
                                            lblOutPlateId.Text = frmmanualfee.PlateId;
                                        }
                                        else
                                        {
                                            meg = "卡号" + frmmanualfee.CardCode;
                                            lblOutPlateId.Text = frmmanualfee.CardCode;
                                            lbId.Text = "刷卡卡号";
                                        }
                                        //显示记录
                                        ShowInfo(meg + ";车主类型:" + frmmanualfee.CType + ";出场时间:" +
                                                 frmmanualfee.OutTime.ToString("HH:mm:ss"));
                                        //出场信息
                                        BindOutInfo(cameraTwoType, frmmanualfee.OutTime.ToString("HH:mm:ss"), frmmanualfee.CarType,
                                                 frmmanualfee.CType, plateid);

                                        //刷新泊位数量
                                        RefreshCount(CustomerConst.Customer, CustomerConst.PlusOperate);
                                        //RefreshParkInfo();
                                        //播报车位数
                                        PlayBerth();
                                        //刷新最新收费信息
                                        RefreshChargeInfo();
                                        if (frmmanualfee.CType == CustomerConst.InCustomer)
                                        {
                                            //插入临停车出入记录表
                                            InsertFCustomerInfo(plateid, e.color, frmmanualfee.OutTime, "", e.imgPath,
                                                                "内部车辆",
                                                                "out");
                                        }
                                        else
                                        {
                                            //插入临停车出入记录表
                                            InsertFCustomerInfo(plateid, e.color, frmmanualfee.OutTime, "", e.imgPath,
                                                                "临停车辆",
                                                                "out");
                                        }
                                    }


                                }
                            }
                        }


                        //进场记录存在，临停车收费
                        else
                        {
                        //    #region 临停车收费

                            string outimgpath = e.imgPath;
                            intime = Convert.ToDateTime(GetInTime(plateid));
                            if (!noInCar)
                            {
                                cartype = "内部车辆";
                            }
                            summoney = CalulateFee(intime, cartype);
                            TimeSpan timeSpan = outtime - intime;
                            parktime = string.Empty;
                            if (timeSpan.Days > 0)
                            {
                                parktime = timeSpan.Days + "天" + timeSpan.Hours.ToString() + "小时" +
                                           timeSpan.Minutes.ToString() + "分钟";
                            }
                            else
                            {
                                parktime = timeSpan.Hours.ToString() + "小时" +
                                           timeSpan.Minutes.ToString() + "分钟";
                            }
                            //收费车辆在免费时间内自动开闸
                            if (iniinfo.AutoOpen == "True" && summoney == 0)
                            {
                                OpenOutDaozha();
                                //刷新最新收费信息
                                //RefreshChargeInfo();
                                if (noInCar)
                                {
                                    custype = "临停客户";
                                    //插入临停车出入记录表
                                    InsertFCustomerInfo(plateid, e.color, outtime, "", e.imgPath, "临停车辆", "out");
                                    //RefreshParkInfo();
                                    //刷新泊位数量
                                    RefreshCount(CustomerConst.Customer, CustomerConst.PlusOperate);
                                }
                                else
                                {
                                    custype = "内部客户";
                                    //插入临停车出入记录表
                                    InsertFCustomerInfo(plateid, e.color, outtime, "", e.imgPath, "内部车辆", "out");
                                    //刷新泊位数量
                                    RefreshCount(CustomerConst.Customer, CustomerConst.PlusOperate);
                                }
                                ShowInfo(string.Format(info, custype));
                                //出场信息
                                BindOutInfo(cameraTwoType, outtime.ToString("HH:mm:ss"), cartype, custype, e.license);

                                string PlayText = "";
                                if (iniinfo.LcarplayNo == "True")
                                {
                                    PlayText = plateid + "," + outcontent;
                                }
                                else
                                {
                                    PlayText = outcontent;
                                }


                                OutPlay(plateid, PlayText);
                                //播报车位数
                                PlayBerth();
                            }
                            else
                            {

                                frmCharge frmcharge = new frmCharge(plateid, cartype, intime, outtime, parktime, feeStandard,
                                                                    summoney, outimgpath, Out_axVZLPRClientCtrl.Name);
                                frmcharge.Owner = this;
                                frmcharge.ShowDialog();
                                custype = frmcharge.CusType;
                                if (frmcharge.DialogResult == DialogResult.OK)
                                {
                                    OpenOutDaozha();
                                    ShowInfo(string.Format(info, custype));
                                    //出场信息
                                    BindOutInfo(cameraTwoType, outtime.ToString("HH:mm:ss"), cartype, custype, plateid);
                                    //刷新泊位数量
                                    RefreshCount(CustomerConst.Customer, CustomerConst.PlusOperate);
                                    //RefreshParkInfo();
                                    //刷新最新收费信息
                                    RefreshChargeInfo();
                                    if (noInCar)
                                    {
                                        //插入临停车出入记录表
                                        InsertFCustomerInfo(plateid, e.color, outtime, "", e.imgPath, "临停车辆", "out");
                                    }
                                    else
                                    {
                                        //插入临停车出入记录表
                                        InsertFCustomerInfo(plateid, e.color, outtime, "", e.imgPath, "内部车辆", "out");
                                    }
                                    //播报车位数
                                    PlayBerth();

                                }
                                if (frmcharge.DialogResult == DialogResult.Cancel)
                                {
                                    ShowInfo(string.Format(info, custype));
                                    //出场信息
                                    BindOutInfo(cameraOneType, outtime.ToString("HH:mm:ss"), cartype, custype, e.license);
                                    //刷新泊位数量
                                    RefreshCount(CustomerConst.FCustomer, CustomerConst.PlusOperate);
                                    RefreshParkInfo();
                                    //刷新最新收费信息
                                    RefreshChargeInfo();
                                    //插入固定车出入记录表
                                    // InsertFCustomerInfo(e.license, e.color, intime, "", e.imgPath, "固定车辆", "in");
                                    InsertFCustomerInfo(plateid, e.color, outtime, "", e.imgPath, cartype, "out");
                                  //  InsertFCustomerInfo(plateid, e.color, outtime, e.imgPath, "", cartype, "in");


                                }
                            }
                        }
                    }
                }
            }    
                else
                {
                    //打开收费窗口，刷卡收费后放行
                    InputPalteCharge(e.imgPath, e.color);

                }
             
            }
        }

        private void In_FouraxVZLPRClientCtrl_OnLPRPlateImgOut(object sender, AxVZLPRClientCtrlLib._DVZLPRClientCtrlEvents_OnLPRPlateImgOutEvent e)
        {
            picInImg.Image = Image.FromFile(e.imagePath);
            inimgpath = e.imagePath;
            fourimagepath = e.imagePath;
        }

        private void In_FouraxVZLPRClientCtrl_OnLPRPlateInfoOutEx(object sender, AxVZLPRClientCtrlLib._DVZLPRClientCtrlEvents_OnLPRPlateInfoOutExEvent e)
        {
            fCustomerModel = null;
            int overday = iniinfo.OverDay;

            //   string tips; //提示信息
            DateTime intime = DateTime.Now;
            string custype = string.Empty;
            string cartype = string.Empty;
            string info = string.Empty;


           // #region 完成识别

            //判断是否识别正确
            if (Isplateid(e.license))
            {
               //确认确认是否开闸
                cartype = GetCarType(e.nType);
                FCustomer fmodel = GetFCustomer(e.license);
                custype = CustomerConst.FCustomer;
                string ctype = string.Empty;
                bool noInCar = true;
                if (fmodel != null)
                {
                    ctype = GetFCustomer(e.license).CarType;
                }
                if (!string.IsNullOrEmpty(ctype))
                {
                    noInCar = !ctype.Equals("内部车辆");
                }

                if (iniinfo.IsOpenNotConfirm != "True"|| InCarAutoOpen)

                {
                    //临停车确认是否开闸
                    if (GetFCustomer(e.license) == null)
                    {
                        frmCheck frmcheck = new frmCheck(e.license, cartype, "in");
                        DialogResult dr = frmcheck.ShowDialog();
                        if (dr == DialogResult.OK)
                        {
                            e.license = frmcheck.PlateId;
                            cartype = frmcheck.CarType;
                        }
                        else
                        {
                            return;
                        }
                    }
                }

                //内部车确认是否开闸
                if (!noInCar && InCarAutoOpen)
                {
                    frmCheck frmcheck = new frmCheck(e.license, cartype, "in");
                    DialogResult dr = frmcheck.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        e.license = frmcheck.PlateId;
                        cartype = frmcheck.CarType;
                    }
                    else
                    {
                        return;
                    }
                }

                //插入车辆出入记录表
                InsertIdentifyInfo(e.license, e.color, e.colorIndex, e.nType, e.confidence, e.bright, e.nDirection,e.time, e.carBright, e.carColor, e.imgPath, e.ip, e.resultType, intime, "InTime");
                info = "车牌" + e.license + ";车主类型:" + "{0}" + ";入场时间:" + intime.ToString("HH:mm:ss");
               
                //判断是否是月租车

                #region 月租车

                if (GetFCustomer(e.license) != null && noInCar)
                {

                    //是月租车，判断是否在有效期内，在有效期内
                    if (IsValCustomer(e.license))
                    {
                        //月租车在有效期内，再判断车位是否被占 2016.7.20jyb
                        //如果不被占用当固定车辆，如被点用，当临时车车辆
                        //  IsMoveCar(e.license);
                        //如果是一户多车，已有车辆入场，另一个需同时插入收费信息表
                        if (str_MoveCar != "-1")
                        {
                            if (IsMoveCar(e.license))
                            {
                                custype = "一户多车";
                                InsertChargeRecord(e.license, cartype, intime, e.imgPath, custype, "");
                            }
                        }
                        //
                        string time = fCustomerModel.OverTime.ToString();
                        TimeSpan timespan = Convert.ToDateTime(time) - DateTime.Now;
                        string lefttime = ((int)timespan.TotalDays).ToString();
                        if (Convert.ToInt32(lefttime) <= overday)
                        {
                            //播报
                            FourPlay(e.license, "欢迎光临," + e.license + ",剩余" + lefttime + "天,请交费");

                        }
                        else
                        {
                            //播报
                            FourPlay(e.license, e.license + "," + content);

                        }
                        OpenFourDaozha();
                        // custype = CustomerConst.FCustomer;
                        Thread thread = new Thread(new ParameterizedThreadStart(ShowInfo));
                        string strInfo = string.Format(info, custype);
                        thread.Start((object)strInfo);
                        // ShowInfo(string.Format(info, custype));
                        //进场场信息
                        BindInInfo(cameraOneType, intime.ToString("HH:mm:ss"), cartype, custype, e.license);
                        //插入固定车出入记录表
                        InsertFCustomerInfo(e.license, e.color, intime, e.imgPath, "", "固定车辆", "in");
                        //刷新泊位数量
                        RefreshCount(CustomerConst.FCustomer, CustomerConst.SubOperate);
                        //RefreshParkInfo();
                        //显示车位
                        PlayBerth();
                    }
                    else
                    {
                        string time = string.Empty;

                        #region 过期固定客户收费

                        if (iniinfo.IsFCustomerFee == "True")
                        {
                            fCustomerModel = GetFCustomer(e.license);
                            if (fCustomerModel != null)
                            {
                                //if (!string.IsNullOrEmpty(GetInTime(e.license)))
                                //{
                                //    MessageHelper.ShowTips("车辆【" + e.license + "】已有进场信息！");
                                //    return;
                                //}
                                time = fCustomerModel.OverTime.ToString();
                                if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(time)) > 0)
                                {
                                    TimeSpan timespan = DateTime.Now - Convert.ToDateTime(time);
                                    string overtime = ((int)timespan.TotalDays).ToString();
                                    //播报
                                    FourPlay(e.license, "欢迎光临," + e.license + ",已过期,请交费");

                                }
                                OpenFourDaozha();
                                custype = CustomerConst.OFCustomer;
                                ShowInfo(string.Format(info, custype));
                                //插入固定车出入记录表
                                InsertFCustomerInfo(e.license, e.color, intime, e.imgPath, "", "固定车辆", "in");
                                //插入临时车辆收费记录表
                                InsertChargeRecord(e.license, cartype, intime, e.imgPath, custype, "");
                                //进场场信息
                                BindInInfo(cameraOneType, intime.ToString("HH:mm:ss"), cartype, custype, e.license);
                                //刷新泊位数量
                                RefreshCount(CustomerConst.FCustomer, CustomerConst.SubOperate);
                              //  RefreshParkInfo();
                                //显示车位
                                PlayBerth();
                            }

                        }
                        #endregion
                        #region 过期固定客户提示过期，不收费

                        else
                        {
                            time = fCustomerModel.OverTime.ToString();
                            if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(time)) > 0)
                            {
                                TimeSpan timespan = DateTime.Now - Convert.ToDateTime(time);
                                string overtime = ((int)timespan.TotalDays).ToString();
                                FourPlay(e.license, "欢迎光临," + e.license + ",已过期,请交费");
                            }
                            else
                            {
                                //播报
                                FourPlay(e.license, e.license + "," + content);
                            }
                            OpenFourDaozha();
                            custype = CustomerConst.OFCustomer;
                            ShowInfo(string.Format(info, custype));
                            //插入固定车出入记录表
                            InsertFCustomerInfo(e.license, e.color, intime, e.imgPath, "", "固定车辆", "in");
                            //进场场信息
                            BindInInfo(cameraOneType, intime.ToString("HH:mm:ss"), cartype, custype, e.license);
                            //刷新泊位数量
                            RefreshCount(CustomerConst.FCustomer, CustomerConst.SubOperate);
                            //RefreshParkInfo();
                            //显示车位
                            PlayBerth();

                        }

                        #endregion

                    }
                }
                #endregion
                #region 临停车,内部车辆

                else //临时停车记录
                {
                    #region 临停车辆不能重复入场（屏蔽）

                    //      if (!string.IsNullOrEmpty(GetInTime(e.license)))
                    //{
                    //    MessageHelper.ShowTips("车辆【" + e.license + "】已有进场信息！");
                    //    return;
                    //} 

                    #endregion


                    //播报
                    FourPlay(e.license, e.license + "," + content);
                    //开闸
                    OpenFourDaozha();
                    //插入临时车辆出入记录表
                    if (!noInCar)
                    {
                        cartype = "内部车辆";
                        custype = CustomerConst.InCustomer;
                        //插入临停车出入记录表
                        InsertFCustomerInfo(e.license, e.color, intime, e.imgPath, "", cartype, "in");
                    }
                    else
                    {
                        custype = CustomerConst.Customer;
                        //插入临停车出入记录表
                        InsertFCustomerInfo(e.license, e.color, intime, e.imgPath, "", "临停车辆", "in");
                    }

                    ShowInfo(string.Format(info, custype));
                    InsertChargeRecord(e.license, cartype, intime, e.imgPath, custype, "");
                    //进场场信息
                    BindInInfo(cameraOneType, intime.ToString("HH:mm:ss"), cartype, custype, e.license);
                    //刷新泊位数量
                    RefreshCount(CustomerConst.Customer, CustomerConst.SubOperate);
                    //RefreshParkInfo();
                    //显示车位
                    PlayBerth();
                }

                #endregion
            }
            #endregion
            #region 识别未完成，手动识别

            else
            {
                InInputPalte(e.imgPath, e.color, "Four");

            }
        }

        FCustomer fmodel;

        /// <summary>
        /// 判断是否为内部车
        /// </summary>
        /// <param name="plateid"></param>
        /// <returns></returns>
        public bool IsInnerCar(string plateid)
        {
            if (fmodel == null)
            {
                fmodel = new FCustomer();
            }
            fmodel = GetFCustomer(plateid);
            string ctype = string.Empty;
            if (fmodel != null)
            {
                ctype = fmodel.CarType;
            }
            return ctype.Equals("内部车辆");
        }

        private void Out_axVZLPRClientCtrl_OnLPRPlateImgOut(object sender, AxVZLPRClientCtrlLib._DVZLPRClientCtrlEvents_OnLPRPlateImgOutEvent e)
        {
            picOutImg.Image = Image.FromFile(e.imagePath);
            outimgpath = e.imagePath;
        }

        private void picInImg_DoubleClick(object sender, EventArgs e)
        {
            //弹出窗口最大化显示本图片
            if (inimgpath.Contains("."))
            {
                Frmimgshow imgshow = new Frmimgshow();
                imgshow.Tag = inimgpath;
                imgshow.ShowDialog();
            }
            else
            {
                MessageHelper.ShowTips("暂无图片！");
            }
        }

        private void picOutImg_DoubleClick(object sender, EventArgs e)
        {
            //弹出窗口最大化显示本图片
            if (outimgpath.Contains("."))
            {
                Frmimgshow imgshow = new Frmimgshow();
                imgshow.Tag = outimgpath;
                imgshow.ShowDialog();
            }
            else
            {
                MessageHelper.ShowTips("暂无图片！");
            }

        }

        /// <summary>
        /// 打开入口道闸
        /// </summary>
        public void OpenInDaozha()
        {
            if (In_axVZLPRClientCtrl.VzLPRClientGetIOOutput(0, 0) == 0)
            {
                In_axVZLPRClientCtrl.VzLPRClientSetIOOutput(0, 1, 1);

            }
            Thread.Sleep(1000);
            In_axVZLPRClientCtrl.VzLPRClientSetIOOutput(0, 1, 0);
        }

        public void OpenThreeDaozha()
        {

            if (In_ThreeaxVZLPRClientCtrl.VzLPRClientGetIOOutput(0, 0) == 0)
            {
                In_ThreeaxVZLPRClientCtrl.VzLPRClientSetIOOutput(0, 1, 1);

            }
            Thread.Sleep(1000);
            In_ThreeaxVZLPRClientCtrl.VzLPRClientSetIOOutput(0, 1, 0);
            
        }

        public void OpenFourDaozha()
        {
            if (In_FouraxVZLPRClientCtrl.VzLPRClientGetIOOutput(0, 0) == 0)
            {
                In_FouraxVZLPRClientCtrl.VzLPRClientSetIOOutput(0, 1, 1);

            }
            Thread.Sleep(1000);
            In_FouraxVZLPRClientCtrl.VzLPRClientSetIOOutput(0, 1, 0);
        }


        public void OpenFiveDaozha()
        {
            if (Out_FiveaxVZLPRClientCtrl.VzLPRClientGetIOOutput(0, 0) == 0)
            {
                Out_FiveaxVZLPRClientCtrl.VzLPRClientSetIOOutput(0, 1, 1);

            }
            Thread.Sleep(1000);
            Out_FiveaxVZLPRClientCtrl.VzLPRClientSetIOOutput(0, 1, 0);
        }
        /// <summary>
        /// 打开出口道闸
        /// </summary>
        public void OpenOutDaozha()
        {
            if (Out_axVZLPRClientCtrl.VzLPRClientGetIOOutput(0, 0) == 0)
            {
                Out_axVZLPRClientCtrl.VzLPRClientSetIOOutput(0, 1, 1);

            }
            Thread.Sleep(1000);
            Out_axVZLPRClientCtrl.VzLPRClientSetIOOutput(0, 1, 0);
        }

        public class ServerData
        {

            public PlateIdentifyInfo model;
            public string timetype;
            public DateTime? time;
            public void AddWebInOutInfo()
            {
                System.Net.WebClient wclient = new System.Net.WebClient();
                wclient.Encoding = System.Text.Encoding.UTF8;
                bool isSuccess = true;
                string values = model.PlateId + ',' + model.PlateCorlor + ',' + model.ColorIndex + ',' + model.Type + ',' + model.Confidence + ',' +
                                model.Bright + ',' + model.Direction
                   + ',' + model.UserTime + ',' + model.CarBright + ',' + model.CarColor
                    + ',' + model.Ip + ',' + model.ResultType + ',' + timetype + ',' + time + ',' + LoginInfo.ParkId + ',' + LoginInfo.CompanyCode + ',' + LoginInfo.LoginName;
                //string filepath = string.Empty;
                //if (model.PlateImgPath != null)
                //{
                //    filepath = model.PlateImgPath;
                //}
                try
                {
                    wclient.UploadString("http://zst.gzwulian.com/ClientService/HttpRequest/UploadIdentifyInfo.ashx?paraStr=" + values," ");
                    //UploadFile.UploadClientFile("http://localhost:12485/ClientService/HttpRequest/UploadIdentifyInfo.ashx?paraStr=" + values, filepath);
                    //  UploadFile.UploadClientFile("http://zst.gzwulian.com/ClientService/HttpRequest/UploadIdentifyInfo.ashx?paraStr=" + values, filepath);
                }
                catch
                {
                    isSuccess = false;
                }
                model.IsUpload = isSuccess;
                PlateIdentifyInfoManager BLL = new PlateIdentifyInfoManager();
                BLL.Update(model);
            }

        }

        /// <summary>
        /// 绑定进出场信息
        /// </summary>
        /// <param name="inttime">进场时间</param>
        /// <param name="outtime">出场时间</param>
        /// <param name="cartype">车辆类型</param>
        /// <param name="ctype">客户类型</param>
        /// <param name="plateid">车牌号码</param>
        //public void BindInOuInfo(string intime, string outtime, string cartype, string ctype, string plateid)
        //{
        //    if (intime != "")
        //    {
        //        lblInCarType.Text = cartype;
        //        lblInTime.Text = intime;
        //        lblInCType.Text = ctype;
        //        lblInPlateId.Text = plateid;
        //    }
        //    else
        //    {
        //        lblOutCarType.Text = cartype;
        //        lblOutTime.Text = outtime;
        //        lblOutCType.Text = ctype;
        //        lblOutPlateId.Text = plateid;
        //    }

        //}
        //jian2016.6.15修改，主要解决两个同时是出口或同时是出的显示问题
        public void BindInInfo(string strOneType, string inouttime, string cartype, string ctype, string plateid)
        {
            if (strOneType == "入口设备")
            {
                groupPanel1.Text = "进场信息";
                labelX5.Text = "进场时间";
                lblInCarType.Text = cartype;
                lblInTime.Text = inouttime;
                lblInCType.Text = ctype;
                lblInPlateId.Text = plateid;
            }
            else
            {

                groupPanel1.Text = "出场信息";
                labelX5.Text = "出场时间";
                lblInCarType.Text = cartype;
                lblInTime.Text = inouttime;
                lblInCType.Text = ctype;
                lblInPlateId.Text = plateid;
            }



        }


        public void BindOutInfo(string strOneType, string inouttime, string cartype, string ctype, string plateid)
        {

            if (strOneType == "入口设备")
            {
                groupPanel3.Text = "进场信息";
                labelX11.Text = "进场时间";
                lblOutCarType.Text = cartype;
                lblOutTime.Text = inouttime;
                lblOutCType.Text = ctype;
                lblOutPlateId.Text = plateid;

            }
            else
            {
                groupPanel3.Text = "出场信息";
                labelX11.Text = "出场时间";
                lblOutCarType.Text = cartype;
                lblOutTime.Text = inouttime;
                lblOutCType.Text = ctype;
                lblOutPlateId.Text = plateid;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outtime"></param>
        /// <param name="summoney"></param>
        /// <param name="givemoney"></param>
        /// <param name="outimgpath"></param>
        /// <param name="feestandard"></param>
        /// <param name="parktime"></param>
        /// <param name="freereason"></param>
        public void UpdateChargeRecord(DateTime outtime, decimal summoney, decimal givemoney, string outimgpath, string feestandard, string parktime, string freereason)
        {
            DataSet ds = chargeRecordBLL.GetList(1, "PlateId=" + "'" + lblPlateId.Text + "'", "InTime");
            if (ds.Tables[0].Rows.Count > 0)
            {
                chargeRecordModel = chargeRecordBLL.DataTableToList(ds.Tables[0]).First();
            }
            if (chargeRecordModel != null)
            {
                chargeRecordModel.OutTime = outtime;
                chargeRecordModel.SumMoney = summoney;
                chargeRecordModel.GiveCharge = givemoney;
                chargeRecordModel.OutImgPath = outimgpath;
                chargeRecordModel.FeeStandard = feestandard;
                chargeRecordModel.ParkTime = parktime;
                chargeRecordModel.FreeReason = freereason;
                chargeRecordModel.OperatorName = LoginInfo.LoginName;
                chargeRecordBLL.Update(chargeRecordModel);
            }


        }

        /// <summary>
        /// 插入收费记录表
        /// </summary>
        /// <param name="plateid">车牌号码</param>
        /// <param name="cartype">车辆类型</param>
        /// <param name="intime">进场时间</param>
        /// <param name="inimgpath">进场时图片路径</param>
        public void InsertChargeRecord(string plateid, string cartype, DateTime intime, string inimgpath, string custype, string cardcode)
        {
            chargeRecordModel = new ChargeRecord();
            chargeRecordModel.FeeStandard = GetChargeStandardByCarType(cartype).FeeType;
            chargeRecordModel.PlateId = plateid;
            chargeRecordModel.CarType = cartype;
            chargeRecordModel.InImgPath = inimgpath;
            chargeRecordModel.InTime = intime;
            chargeRecordModel.CusType = custype;
            chargeRecordModel.CardCode = cardcode;
            chargeRecordModel.OperatorName = LoginInfo.LoginName;
            chargeRecordModel.CompanyCode = LoginInfo.CompanyCode;
            chargeRecordModel.ParkId = LoginInfo.ParkId;
            chargeRecordBLL.Add(chargeRecordModel);
        }

        /// <summary>
        /// 插入车牌识别信息
        /// </summary>
        /// <param name="plateid">车牌号</param>
        /// <param name="platecorlor">车牌颜色</param>
        /// <param name="corlorindex">颜色索引</param>
        /// <param name="type">车牌类型</param>
        /// <param name="confidence">可信度</param>
        /// <param name="bright">亮度</param>
        /// <param name="direction">方向</param>
        /// <param name="usetime">识别所用时间</param>
        /// <param name="carbright">车亮度</param>
        /// <param name="carcolor">车辆颜色</param>
        /// <param name="imgpath">图片</param>
        /// <param name="ip">ip地址</param>
        /// <param name="resulttype">结果类型</param>
        /// <param name="intime">进场时间</param>
        /// /// <param name="intime">出场时间</param>
        public void InsertIdentifyInfo(string plateid, string platecorlor, int corlorindex, int type, int confidence, int bright, int direction, decimal usetime, int carbright, int carcolor, string imgpath, string ip, int resulttype, DateTime time, string timetype)
        {
            //插入车辆出入记录表
            identifyInfoModel = new PlateIdentifyInfo();
            identifyInfoModel.PlateId = plateid;
            identifyInfoModel.PlateCorlor = platecorlor;
            identifyInfoModel.ColorIndex = corlorindex;
            identifyInfoModel.Type = type;
            identifyInfoModel.Confidence = confidence;
            identifyInfoModel.Bright = bright;
            identifyInfoModel.Direction = direction;
            identifyInfoModel.UserTime = usetime;
            identifyInfoModel.CarBright = carbright;
            identifyInfoModel.CarColor = carcolor;
            identifyInfoModel.PlateImgPath = imgpath;
            identifyInfoModel.Ip = ip;
            identifyInfoModel.ResultType = resulttype;
            if (timetype == "InTime")
            {
                identifyInfoModel.InTime = time;
            }
            else
            {
                identifyInfoModel.OutTime = time;
            }
            identifyInfoModel.AddTime = DateTime.Now;
            identifyInfoModel.ParkId = LoginInfo.ParkId;
            identifyInfoModel.CompanyCode = LoginInfo.CompanyCode;
            identifyInfoModel.OperatorName = LoginInfo.LoginName;
            inoutBLL.Add(identifyInfoModel);
            //上传到服务端
            if(iniinfo.CarinfoUpload=="True")
            {
                ServerData serverData = new ServerData();
                serverData.model = identifyInfoModel;
                serverData.timetype = timetype;
                serverData.time = time;
                Thread th = new Thread(new ThreadStart(serverData.AddWebInOutInfo));
                th.IsBackground = true;
                th.Start();
                //    AddWebIdentifyInfo(identifyInfoModel, timetype, time);  
            }

        }

        /// <summary>
        /// 插入车牌识别信息
        /// </summary>
        /// <param name="plateid">车牌号</param>
        /// <param name="platecorlor">车牌颜色</param>
        /// <param name="corlorindex">颜色索引</param>
        /// <param name="type">车牌类型</param>
        /// <param name="confidence">可信度</param>
        /// <param name="bright">亮度</param>
        /// <param name="direction">方向</param>
        /// <param name="usetime">识别所用时间</param>
        /// <param name="carbright">车亮度</param>
        /// <param name="carcolor">车辆颜色</param>
        /// <param name="imgpath">图片</param>
        /// <param name="ip">ip地址</param>
        /// <param name="resulttype">结果类型</param>
        /// <param name="intime">进场时间</param>
        /// /// <param name="intime">出场时间</param>
        public void InsertIdentifyInfo11(string plateid, string platecorlor, int corlorindex, int type, int confidence, int bright, int direction, decimal usetime, int carbright, int carcolor, string imgpath, string ip, int resulttype, DateTime time, string timetype)
        {
            ////插入车辆出入记录表
            //identifyInfoModel = new PlateIdentifyInfo();
            //identifyInfoModel.PlateId = plateid;
            //identifyInfoModel.PlateCorlor = platecorlor;
            //identifyInfoModel.ColorIndex = corlorindex;
            //identifyInfoModel.Type = type;
            //identifyInfoModel.Confidence = confidence;
            //identifyInfoModel.Bright = bright;
            //identifyInfoModel.Direction = direction;
            //identifyInfoModel.UserTime = usetime;
            //identifyInfoModel.CarBright = carbright;
            //identifyInfoModel.CarColor = carcolor;
            //identifyInfoModel.PlateImgPath = imgpath;
            //identifyInfoModel.Ip = ip;
            //identifyInfoModel.ResultType = resulttype;
            //if (timetype == "InTime")
            //{
            //    identifyInfoModel.InTime = time;
            //}
            //else
            //{
            //    identifyInfoModel.OutTime = time;
            //}
            //identifyInfoModel.AddTime = DateTime.Now;
            //identifyInfoModel.ParkId = LoginInfo.ParkId;
            //identifyInfoModel.CompanyCode = LoginInfo.CompanyCode;
            //identifyInfoModel.OperatorName = LoginInfo.LoginName;
            //inoutBLL.Add(identifyInfoModel);
            ////上传到服务端
            //AddWebIdentifyInfo(identifyInfoModel, timetype, time);
            //List<PlateIdentifyInfo> identifyModelList = inoutBLL.GetModelList("IsUpload!='True'");
            //if (identifyModelList.Count > 0)
            //{
            //    foreach (PlateIdentifyInfo model in identifyModelList)
            //    {
            //        string ttype = string.Empty;
            //        DateTime? ttime;
            //        if (model.InTime == null)
            //        {
            //            ttype = "OutTime";
            //            ttime = model.OutTime;
            //        }
            //        else
            //        {
            //            ttype = "InTime";
            //            ttime = model.InTime;
            //        }
            //        AddWebIdentifyInfo(model, ttype, ttime);
            //    }
            //}

        }

        /// <summary>
        /// 添加进出入信息到服务端
        /// </summary>
        /// <param name="model"></param>
        /// <param name="timetype"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        private bool AddWebIdentifyInfo(PlateIdentifyInfo model, string timetype, DateTime? time)
        {
            bool isSuccess = true;
            System.Net.WebClient wclient = new System.Net.WebClient();
            wclient.Encoding = System.Text.Encoding.UTF8;
            string values = model.PlateId + ',' + model.PlateCorlor + ',' + model.ColorIndex + ',' + model.Type + ',' + model.Confidence + ',' +
                            model.Bright + ',' + model.Direction
               + ',' + model.UserTime + ',' + model.CarBright + ',' + model.CarColor
                + ',' + model.Ip + ',' + model.ResultType + ',' + timetype + ',' + time + ',' + LoginInfo.ParkId + ',' + LoginInfo.CompanyCode + ',' + LoginInfo.LoginName;
            try
            {
                wclient.UploadString("http://zst.gzwulian.com/ClientService/HttpRequest/UploadIdentifyInfo.ashx?paraStr=" + values, " ");
                // wclient.UploadString("http://zst.gzwulian.com/ClientService/HttpRequest/UploadIdentifyInfo.ashx?paraStr=" + values, "");
               // UploadFile.UploadClientFile("http://zst.gzwulian.com/ClientService/HttpRequest/UploadIdentifyInfo.ashx?paraStr=" + values, model.PlateImgPath);
            }
            catch
            {
                isSuccess = false;
            }
            model.IsUpload = isSuccess;
            return inoutBLL.Update(model);
        }

        /// <summary>
        /// 通过实体对象得到服务端实体对象
        /// </summary>
        /// <param name="mode">实体对象</param>
        /// <returns></returns>
        private WebFInOutInfo.FInOutInfo GetFInOutModel(www.gzwulian.com.Model.FInOutInfo model)
        {
            WebFInOutInfo.FInOutInfo webFInoutmodel = new WebFInOutInfo.FInOutInfo();
            webFInoutmodel.AddTime = model.AddTime;
            webFInoutmodel.CompanyCode = model.CompanyCode;
            webFInoutmodel.FCustomerId = model.FCustomerId;
            webFInoutmodel.Id = model.Id;
            webFInoutmodel.InImgPath = model.InImgPath;
            webFInoutmodel.InTime = model.InTime;
            webFInoutmodel.IsUpload = model.IsUpload;
            webFInoutmodel.OperatorName = model.OperatorName;
            webFInoutmodel.OutImgPath = model.OutImgPath;
            webFInoutmodel.OutTime = model.OutTime;
            webFInoutmodel.ParkId = model.ParkId;
            webFInoutmodel.PlateColor = model.PlateColor;
            webFInoutmodel.PlateId = model.PlateId;
            return webFInoutmodel;

        }

        WebFInOutInfo.FInOut webFInOutInfo = new WebFInOutInfo.FInOut();
        WebFInOutInfo.FInOutInfo webFInOutModel = null;

        /// <summary>
        /// 插入车辆进出信息
        /// </summary>
        /// <param name="plateid">车牌号</param>
        /// <param name="platecolor">车牌颜色</param>
        /// <param name="inouttime">进场时间</param>
        /// <param name="inimgpath">进场图片路径</param>
        /// <param name="outimgpath">出场图片路径</param>
        public void InsertFCustomerInfo(string plateid, string platecolor, DateTime inouttime, string inimgpath, string outimgpath, string vehictype, string inouttype)
        {
            fInOutInfoModel = new FInOutInfo();
            fInOutInfoModel.PlateId = plateid;
            fInOutInfoModel.PlateColor = platecolor;
            if (inouttype == "in")
            {
                fInOutInfoModel.InTime = inouttime;
            }
            else
            {
                fInOutInfoModel.OutTime = inouttime;
            }
            fInOutInfoModel.OperatorName = LoginInfo.LoginName;
            fInOutInfoModel.CompanyCode = LoginInfo.CompanyCode;
            fInOutInfoModel.InImgPath = inimgpath;
            fInOutInfoModel.OutImgPath = outimgpath;
            fInOutInfoModel.VehicType = vehictype;
            fInOutInfoModel.AddTime = DateTime.Now;
            fInOutInfoModel.OperatorName = LoginInfo.LoginName;
            fInOutInfoModel.ParkId = LoginInfo.ParkId;
            fInOutInfoModel.CompanyCode = LoginInfo.CompanyCode;
            fInOutInfoBLL.Add(fInOutInfoModel);
            //上传到服务端
            if(iniinfo.CarinfoUpload=="True")
            {
                Thread th = new Thread(new ParameterizedThreadStart(this.AddWebFInOutInfo));
                th.IsBackground = true;
                th.Start(fInOutInfoModel);
                //  AddWebFInOutInfo(fInOutInfoModel);
            }

        }

        private delegate void ShowBerthCrossThread();
        /// <summary>
        /// 显示临停泊位数
        /// </summary>
        /// <param name="berthcount"></param>
        private void ShowBerth(string berthcount)
        {
            ShowBerthCrossThread showDlgBerth = delegate ()
                {
                    lbBerthCountRest.Text = berthcount;
                };
            this.Invoke(showDlgBerth);
        }

        private delegate void ShowInfoCrossThread();
        /// <summary>
        /// 显示车辆进出信息
        /// </summary>
        /// <param name="info"></param>
        public void ShowInfo(object info)
        {
            ShowInfoCrossThread showInfo = delegate ()
            {
                lbRecord.Items.Add(info);
            };
            lbRecord.Invoke(showInfo);
        }

        private string feeStandard = "";
        /// <summary>
        /// 计算停车费额
        /// </summary>
        /// <param name="intime">进场时间</param>
        /// <param name="carType">车辆类型</param>
        /// <returns></returns>
        public decimal CalulateFee(DateTime intime, string carType)
        {
            int parkTime;
            decimal sumMoney = 0;
            int setminute = iniinfo.OverTime;
         //   DateTime carouttime = new DateTime(dateTimePicker2.Value.Year, dateTimePicker2.Value.Month, dateTimePicker2.Value.Day, dateTimePicker2.Value.Hour, dateTimePicker2.Value.Minute,0);

            //2017.3.12 jian 因为计算有秒在里，在播报时只到分，所以计费到秒和显示播报可能有误差。
            //时场时间，去掉秒。
            DateTime carintime = new DateTime(intime.Year, intime.Month, intime.Day, intime.Hour, intime.Minute, 0);


            DateTime nowTime = DateTime.Now;
            //出场时间，去掉秒
            DateTime carouttime = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, nowTime.Hour, nowTime.Minute, 0);
            //计算车辆停留时间(分钟)
            TimeSpan timeSpan = carouttime - carintime;
            parkTime = int.Parse(Math.Ceiling(timeSpan.TotalMinutes).ToString());
            FeeStandard feeStandardModel = this.GetChargeStandardByCarType(carType);
            feeStandard = feeStandardModel.FeeType;
            //每天最高收费
            decimal feetop = feeStandardModel.Feetop ?? 0;

           //车辆进场日期的月份
            int inmonth = intime.Month;
            //车辆出场日期的月份
            int outmonth = carouttime.Month;

            //2017.2.15jian增加月年比较
            int inday = intime.Day+inmonth+intime.Year;
            //车辆出场日期的号数
            int outday = carouttime.Day+outmonth+intime.Year;
            //用于判定停车是否为同一天

            //车辆进场日期的号数
            //int inday = intime.Day;
            ////车辆出场日期的号数
            //int outday = carouttime.Day;
            ////用于判定停车是否为同一天
            int day = outday - inday;
            if (inmonth != outmonth)
            {
                TimeSpan mspan = carouttime - intime;
                day = (int)mspan.TotalDays;
            }
            #region 进场时间inhourminute
            //进场时间小时
            string inhour = intime.Hour.ToString();
            //进场时间分钟
            string inminute = intime.Minute.ToString();
            //进场小时分钟数（时间点）
            DateTime inhourminute = Convert.ToDateTime(inhour + ":" + inminute);
            #endregion
            #region 出场时间outhourminute
            //出场时间小时
            string outhour = carouttime.Hour.ToString();
            //出场时间分钟
            string outminute = carouttime.Minute.ToString();
            //出场小时分钟数 （时间点）
            DateTime outhourminute = Convert.ToDateTime(outhour + ":" + outminute);
            #endregion
            //如果停车时间大于免费时间就进行计费
            if (parkTime > feeStandardModel.FreeMinutes)
            {
                #region 按收费标准计算费用
                if (feeStandard == "按次收费")
                {
                    if (carType == "内部车辆")
                    {
                        parkTime = parkTime - feeStandardModel.FreeMinutes ?? 0;
                        sumMoney = int.Parse(Math.Ceiling(parkTime / 1440.0).ToString()) * feeStandardModel.FeePerView ?? 0;
                        return sumMoney;
                    }
                    else
                    {
                        sumMoney = feeStandardModel.FeePerView ?? 0;
                        return sumMoney * (day + 1);
                    }
                }
                else if (feeStandard == "标准收费")
                {
                    string standardFee = feeStandardModel.StandardFee;
                    //每天最高收费
                    decimal feeTop = feeStandardModel.Feetop ?? 0;
                    string[] fee = standardFee.Split(',');
                    int parkHour = 0;
                    if ((parkTime % 60) > setminute)
                    {
                        parkHour = int.Parse(Math.Ceiling(parkTime / 60.0).ToString());
                    }
                    else
                    {
                        parkHour = int.Parse(Math.Floor(parkTime / 60.0).ToString());
                    }

                    //判断停车时间是否超过一天（包括一天）
                    if (parkHour >= 24)
                    {
                        decimal dayfee = decimal.Parse(fee[23]);
                        int n = parkHour % 24;
                        if (n == 0)
                        {
                            sumMoney = (parkHour / 24) * decimal.Parse(fee[23]);
                        }
                        else
                        {
                            sumMoney = (parkHour / 24) * decimal.Parse(fee[23]) + decimal.Parse(fee[n - 1]);
                        }

                    }
                    else
                    {
                        sumMoney = decimal.Parse(fee[parkHour % 24 - 1]);
                    }
                    return sumMoney;
                }
                else if (feeStandard == "按设定时间收费")
                {
                    //计时单位
                    int timeunit = feeStandardModel.STTimeUnie ?? 0;
                    //每计时单位费额
                    decimal unitfee = feeStandardModel.STUnieFee ?? 0;
                    //过零点收取的过夜费
                    decimal overfee = feeStandardModel.STOverNightFee ?? 0;
                    //进场到当天零点的停车时间
                    int inparktime = CaculateMunites(Convert.ToDateTime(inhourminute), Convert.ToDateTime("23:59:59"));
                    //进场到当天零点的停车时间停车费额
                    decimal infee = 0;
                    //出场当天的停车时间停车费额
                    decimal outfee = 0;
                    //停车一整天所需费
                    decimal dayfee = 0;
                    //出场当天的停车时间
                    int outparktime = CaculateMunites(Convert.ToDateTime("00:00"), Convert.ToDateTime(outhourminute));
                    //判断是否过零点，收取过夜费
                    if (day > 0)
                    {
                        if (parkTime < 1440)
                        {
                            if ((inparktime % timeunit) > setminute)
                            {
                                infee = Decimal.Parse(Math.Ceiling(inparktime / 1.00 / timeunit).ToString()) * unitfee;
                            }
                            else
                            {
                                infee = Decimal.Parse(Math.Floor(inparktime / 1.00 / timeunit).ToString()) * unitfee;
                            }
                            if ((outparktime % timeunit) > setminute)
                            {
                                outfee = Decimal.Parse(Math.Ceiling(outparktime / 1.00 / timeunit).ToString()) * unitfee;
                            }
                            else
                            {
                                outfee = Decimal.Parse(Math.Floor(outparktime / 1.00 / timeunit).ToString()) * unitfee;
                            }
                            if (infee > feetop)
                            {
                                infee = feetop;
                            }
                            if (outfee > feetop)
                            {
                                outfee = feetop;
                            }
                            sumMoney = infee + outfee + overfee;
                        }
                        else
                        {
                            if ((inparktime % timeunit) > setminute)
                            {
                                infee = Decimal.Parse(Math.Ceiling(inparktime / 1.00 / timeunit).ToString()) * unitfee;
                            }
                            else
                            {
                                infee = Decimal.Parse(Math.Floor(inparktime / 1.00 / timeunit).ToString()) * unitfee;
                            }
                            if ((outparktime % timeunit) > setminute)
                            {
                                outfee = Decimal.Parse(Math.Ceiling(outparktime / 1.00 / timeunit).ToString()) * unitfee;
                            }
                            else
                            {
                                outfee = Decimal.Parse(Math.Floor(outparktime / 1.00 / timeunit).ToString()) * unitfee;
                            }
                            dayfee = int.Parse(Math.Ceiling(1440.00 / timeunit).ToString()) * unitfee;
                            if (infee > feetop)
                            {
                                infee = feetop;
                            }
                            if (outfee > feetop)
                            {
                                outfee = feetop;
                            }
                            if (dayfee > feetop)
                            {
                                dayfee = feetop;
                            }
                            int n = (parkTime - inparktime - outparktime) / 1440;
                            sumMoney = infee + outfee + dayfee * n + overfee * day;
                        }

                    }
                    else
                    {
                        if ((parkTime % timeunit) > setminute)
                        {
                            sumMoney = Decimal.Parse(Math.Ceiling(parkTime / 1.00 / timeunit).ToString()) * unitfee;
                        }
                        else
                        {
                            sumMoney = Decimal.Parse(Math.Floor(parkTime / 1.00 / timeunit).ToString()) * unitfee;
                        }

                        if (sumMoney > feetop)
                        {
                            sumMoney = feetop;
                        }
                    }
                    return sumMoney;
                }
                else if (feeStandard == "按设定时间段收费")
                {

                    #region 白天段
                    //白天段开始小时数
                    int daystarthour = feeStandardModel.DayStartHour ?? 0;
                    //白天段开始分钟数
                    int daystartminute = feeStandardModel.DayStartMinute ?? 0;
                    //白天段计时单位
                    int daytimeunit = feeStandardModel.DayTimeUnit ?? 0;
                    //白天段每计时单位费额（元）
                    decimal dayunitfee = feeStandardModel.DayUnitFee ?? 0;
                    //白天段最高收费
                    decimal daytopfee = feeStandardModel.DayTopFee ?? 0;
                    //白天段最低收费
                    decimal daylowestfee = feeStandardModel.DayLowestFee ?? 0;
                    //白天段收费
                    decimal dayparkfee = 0;
                    //剩余时间收费
                    decimal leftdayfee = 0;
                    #endregion

                    #region 夜间段
                    //白天段开始小时数
                    int nightstarthour = feeStandardModel.NightStartHour ?? 0;
                    //白天段开始分钟数
                    int nightstartminute = feeStandardModel.NightStartMinute ?? 0;
                    //白天段计时单位
                    int nighttimeunit = feeStandardModel.NightTimeUnit ?? 0;
                    //夜间段每计时单位费额（元）
                    decimal nightunitfee = feeStandardModel.NightUnitFee ?? 0;
                    //夜间段最高收费
                    decimal nighttopfee = feeStandardModel.NightTopFee ?? 0;
                    //夜间段最低收费
                    decimal nightlowestfee = feeStandardModel.NightLowestFee ?? 0;
                    //夜间段收费
                    decimal nightparkfee = 0;
                    //剩余时间收费
                    decimal leftnightfee = 0;
                    #endregion

                    //设置的白天段开始时间
                    DateTime daystarttime = Convert.ToDateTime(daystarthour.ToString() + ":" + daystartminute.ToString());
                    //设置的夜间段开始时间
                    DateTime nightstarttime = Convert.ToDateTime(nightstarthour.ToString() + ":" + nightstartminute.ToString());
                    //判断是进场场是否在同一天
                    if (outday == inday)
                    {
                        //进场时间在白天段内
                        if ((inhourminute >= daystarttime) && (inhourminute <= nightstarttime))
                        {
                            //进出场时间在白天内
                            if ((outhourminute >= daystarttime) && (outhourminute < nightstarttime))
                            {
                                if ((parkTime % daytimeunit) > setminute)
                                {
                                    sumMoney = Decimal.Parse(Math.Ceiling(parkTime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                }
                                else
                                {
                                    sumMoney = Decimal.Parse(Math.Floor(parkTime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                }

                                if (sumMoney > daytopfee)
                                {
                                    sumMoney = daytopfee;
                                }
                                if (sumMoney < daylowestfee)
                                {
                                    sumMoney = daylowestfee;
                                }

                                //每天收费同不能高于设定的值,2017-2-15日jian增加
                                if (sumMoney > feetop)
                                {
                                    sumMoney = feetop;
                                }


                            }

                            else//进场时间在白天段内，出场时间在夜间段内
                            {
                                TimeSpan dayparkspan = nightstarttime - inhourminute;
                                int dayparktime = int.Parse(dayparkspan.TotalMinutes.ToString());
                                int nightparktime = parkTime - dayparktime;
                                if ((dayparktime % daytimeunit) > setminute)
                                {
                                    dayparkfee = Decimal.Parse(Math.Ceiling(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                }
                                else
                                {
                                    dayparkfee = Decimal.Parse(Math.Floor(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                }
                                if ((nightparktime % nighttimeunit) > setminute)
                                {
                                    nightparkfee = Decimal.Parse(Math.Ceiling(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                }
                                else
                                {
                                    nightparkfee = Decimal.Parse(Math.Floor(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                }

                                if (dayparkfee > daytopfee)
                                {
                                    dayparkfee = daytopfee;
                                }
                                if (dayparkfee < daylowestfee)
                                {
                                    dayparkfee = daylowestfee;
                                }
                                if (nightparkfee > nighttopfee)
                                {
                                    nightparkfee = nighttopfee;
                                }
                                if (nightparkfee < nightlowestfee)
                                {
                                    nightparkfee = nightlowestfee;
                                }
                                sumMoney = dayparkfee + nightparkfee;
                            }
                            //每天收费同不能高于设定的值,2017-2-15日jian增加
                            if (sumMoney > feetop)
                            {
                                sumMoney = feetop;
                            }

                        }
                        else //进场时间在夜间段((inhourminute<daystarttime)&&(inhourminute>=nightstarttime))
                        {
                            //进出场时间在夜间段
                            if ((outhourminute < daystarttime) || (outhourminute >= nightstarttime))
                            {
                                if ((parkTime % nighttimeunit) > setminute)
                                {
                                    nightparkfee = Decimal.Parse(Math.Ceiling(parkTime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                }
                                else
                                {
                                    nightparkfee = Decimal.Parse(Math.Floor(parkTime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                }

                                if (nightparkfee > nighttopfee)
                                {
                                    nightparkfee = nighttopfee;
                                }
                                if (nightparkfee < nightlowestfee)
                                {
                                    nightparkfee = nightlowestfee;
                                }
                                sumMoney = nightparkfee;
                                //每天收费同不能高于设定的值,2017-2-15日jian增加
                                if (sumMoney > feetop)
                                {
                                    sumMoney = feetop;
                                }


                            }
                            else//进场时间在夜间段，出场时间在白天段（进场场为同一天，这种情况下，进场时间必定小于白天段开始的时间）
                            {

                                TimeSpan dayparkspan = outhourminute - daystarttime;
                                //白天段停车时间
                                int dayparktime = int.Parse(dayparkspan.TotalMinutes.ToString());
                                int nightparktime = parkTime - dayparktime;
                                if ((dayparktime % daytimeunit) > setminute)
                                {
                                    dayparkfee = Decimal.Parse(Math.Ceiling(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                }
                                else
                                {
                                    dayparkfee = Decimal.Parse(Math.Floor(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                }
                                if ((nightparktime % nighttimeunit) > setminute)
                                {
                                    nightparkfee = Decimal.Parse(Math.Ceiling(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                }
                                else
                                {
                                    nightparkfee = Decimal.Parse(Math.Floor(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                }
                                if (dayparkfee > daytopfee)
                                {
                                    dayparkfee = daytopfee;
                                }
                                if (dayparkfee < daylowestfee)
                                {
                                    dayparkfee = daylowestfee;
                                }
                                if (nightparkfee > nighttopfee)
                                {
                                    nightparkfee = nighttopfee;
                                }
                                if (nightparkfee < nightlowestfee)
                                {
                                    nightparkfee = nightlowestfee;
                                }
                                sumMoney = dayparkfee + nightparkfee;
                                //每天收费同不能高于设定的值,2017-2-15日jian增加
                                if (sumMoney > feetop)
                                {
                                    sumMoney = feetop;
                                }
                            }
                        }
                        //每天收费同不能高于设定的值,2017-2-15日jian增加
                        if (sumMoney > feetop)
                        {
                            sumMoney = feetop;
                        }
                        return sumMoney;
                    }
                    else//进出场时间不是同一天
                    {
                        //进场时间在白天段内
                        if ((inhourminute >= daystarttime) && (inhourminute < nightstarttime))
                        {
                            //进出场时间在白天内
                            if ((outhourminute >= daystarttime) && (outhourminute < nightstarttime))
                            {
                                //停车时间小于24小时
                                if (parkTime < 1440)
                                {
                                    TimeSpan dayspan = nightstarttime - daystarttime;
                                    int daytime = int.Parse(dayspan.TotalMinutes.ToString());
                                    //夜间段停车时间
                                    int nightparktime = 1440 - daytime;
                                    //白天段停车时间
                                    int dayparktime = parkTime - nightparktime;
                                    if ((dayparktime % daytimeunit) > setminute)
                                    {
                                        dayparkfee = Decimal.Parse(Math.Ceiling(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                    }
                                    else
                                    {
                                        dayparkfee = Decimal.Parse(Math.Floor(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                    }
                                    if ((nightparktime % nighttimeunit) > setminute)
                                    {
                                        nightparkfee = Decimal.Parse(Math.Ceiling(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                    }
                                    else
                                    {
                                        nightparkfee = Decimal.Parse(Math.Floor(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                    }


                                    if (dayparkfee > daytopfee)
                                    {
                                        dayparkfee = daytopfee;
                                    }
                                    if (dayparkfee < daylowestfee)
                                    {
                                        dayparkfee = daylowestfee;
                                    }
                                    if (nightparkfee > nighttopfee)
                                    {
                                        nightparkfee = nighttopfee;
                                    }
                                    if (nightparkfee < nightlowestfee)
                                    {
                                        nightparkfee = nightlowestfee;
                                    }
                                    sumMoney = dayparkfee + nightparkfee;
                                    //每天收费同不能高于设定的值,2017-2-15日jian增加
                                    if (sumMoney > feetop)
                                    {
                                        sumMoney = feetop;
                                    }

                                }
                                else
                                {
                                    #region 停车整天数收费额金
                                    //停车整天数
                                    int parkdays = parkTime / 1440;
                                    //剩余停车分钟数
                                    int leftparkminutes = parkTime - 1440 * parkdays;
                                    TimeSpan dayspan = nightstarttime - daystarttime;
                                    //整天白天段停车分钟数
                                    int daytime = int.Parse(dayspan.TotalMinutes.ToString());
                                    //整天夜间段停车分钟数
                                    int nighttime = 1440 - daytime;
                                    //整天白天段停车费用
                                    if ((daytime % daytimeunit) > setminute)
                                    {
                                        dayparkfee = Decimal.Parse(Math.Ceiling(daytime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                    }
                                    else
                                    {
                                        dayparkfee = Decimal.Parse(Math.Floor(daytime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                    }

                                    //整天夜间段停车费用
                                    if ((nighttime % nighttimeunit) > setminute)
                                    {
                                        nightparkfee = Decimal.Parse(Math.Ceiling(nighttime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                    }
                                    else
                                    {
                                        nightparkfee = Decimal.Parse(Math.Floor(nighttime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                    }

                                    if (dayparkfee > daytopfee)
                                    {
                                        dayparkfee = daytopfee;
                                    }
                                    if (dayparkfee < daylowestfee)
                                    {
                                        dayparkfee = daylowestfee;
                                    }
                                    if (nightparkfee > nighttopfee)
                                    {
                                        nightparkfee = nighttopfee;
                                    }
                                    if (nightparkfee < nightlowestfee)
                                    {
                                        nightparkfee = nightlowestfee;
                                    }
                                    //停车整天数停车总费用

                                    //daytopsum 每天最大收费不能大于设定的高费用,jian 2017-2-15改
                                    decimal daytopsum = dayparkfee + nightparkfee;
                                    if (daytopsum > feetop)
                                    {
                                        daytopsum = feetop;
                                    }
                                    decimal sumdaymoney = daytopsum * parkdays;



                                    //decimal sumdaymoney = (dayparkfee + nightparkfee) * parkdays;
                                    #endregion
                                    #region 剩余分钟数收费金额

                                    decimal leftmoney = 0;
                                    #region 进场小时分钟数小于出场小时分钟数
                                    if (inhourminute <= outhourminute)
                                    {
                                        if ((leftparkminutes % daytimeunit) > setminute)
                                        {
                                            leftdayfee = decimal.Parse(Math.Ceiling(leftparkminutes / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                        }
                                        else
                                        {
                                            leftdayfee = decimal.Parse(Math.Floor(leftparkminutes / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                        }

                                        leftmoney = leftdayfee;
                                    }
                                    #endregion
                                    #region 进场小时分钟数大于出场小时分钟数，这种情况下，剩余时间的白天段停车时间等于剩余时间减去夜间段时间
                                    else
                                    {

                                        //剩余停车分钟数,白天段停车时间
                                        int dayparktime = leftparkminutes - nighttime;
                                        //剩余停车分钟数,夜间段停车时间
                                        int nightparktime = leftparkminutes - dayparktime;
                                        if ((dayparktime % daytimeunit) > setminute)
                                        {
                                            leftdayfee = decimal.Parse(Math.Ceiling(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                        }
                                        else
                                        {
                                            leftdayfee = decimal.Parse(Math.Floor(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                        }
                                        if ((nightparktime % nighttimeunit) > setminute)
                                        {
                                            leftnightfee = Decimal.Parse(Math.Ceiling(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                        }
                                        else
                                        {
                                            leftnightfee = Decimal.Parse(Math.Floor(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                        }
                                        if (leftdayfee > daytopfee)
                                        {
                                            leftdayfee = daytopfee;
                                        }
                                        if (leftdayfee < daylowestfee)
                                        {
                                            leftdayfee = daylowestfee;
                                        }
                                        if (leftnightfee > nighttopfee)
                                        {
                                            leftnightfee = nighttopfee;
                                        }
                                        if (leftnightfee < nightlowestfee)
                                        {
                                            leftnightfee = nightlowestfee;
                                        }
                                        leftmoney = leftdayfee + leftnightfee;
                                        //2017.2.15 jian改
                                        if (leftmoney > feetop)
                                        {
                                            leftmoney = feetop;
                                        }

                                    }
                                    #endregion

                                    #endregion

                                    //每天收费同不能高于设定的值,2017-2-15日jian增加
                                    if (leftmoney > feetop)
                                    {
                                        leftmoney = feetop;
                                    }
                                    sumMoney = sumdaymoney + leftmoney;


                                }

                            }

                            else//进场时间在白天段内，出场时间在夜间段内
                            {
                                //停车时间小于24小时
                                if (parkTime < 1440)
                                {
                                    TimeSpan dayparkspan = nightstarttime - inhourminute;
                                    //白天段停车时间
                                    int dayparktime = int.Parse(dayparkspan.TotalMinutes.ToString());
                                    //夜间段停车段
                                    int nightparktime = parkTime - dayparktime;
                                    if ((dayparktime % daytimeunit) > setminute)
                                    {
                                        dayparkfee = Decimal.Parse(Math.Ceiling(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                    }
                                    else
                                    {
                                        dayparkfee = Decimal.Parse(Math.Floor(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                    }
                                    if ((nightparktime % nighttimeunit) > setminute)
                                    {
                                        nightparkfee = Decimal.Parse(Math.Ceiling(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                    }
                                    else
                                    {
                                        nightparkfee = Decimal.Parse(Math.Floor(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                    }


                                    if (dayparkfee > daytopfee)
                                    {
                                        dayparkfee = daytopfee;
                                    }
                                    if (dayparkfee < daylowestfee)
                                    {
                                        dayparkfee = daylowestfee;
                                    }
                                    if (nightparkfee > nighttopfee)
                                    {
                                        nightparkfee = nighttopfee;
                                    }
                                    if (nightparkfee < nightlowestfee)
                                    {
                                        nightparkfee = nightlowestfee;
                                    }
                                    sumMoney = dayparkfee + nightparkfee;
                                    //每天收费同不能高于设定的值,2017-2-15日jian增加
                                    if (sumMoney > feetop)
                                    {
                                        sumMoney = feetop;
                                    }
                                }
                                else//停车时间大于24小时，则分为两种情况
                                {
                                    //进场时间大于小于或等于出场时间
                                    #region 停车整天数收费额金
                                    //停车整天数
                                    int parkdays = parkTime / 1440;
                                    //剩余停车分钟数
                                    int parkminutes = parkTime - 1440 * parkdays;
                                    TimeSpan dayspan = nightstarttime - daystarttime;
                                    //整天白天段停车分钟数
                                    int daytime = int.Parse(dayspan.TotalMinutes.ToString());
                                    //整天夜间段停车分钟数
                                    int nighttime = 1440 - daytime;
                                    //整天白天段停车费用
                                    dayparkfee = Decimal.Parse(Math.Ceiling(daytime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                    //整天夜间段停车费用
                                    nightparkfee = Decimal.Parse(Math.Ceiling(nighttime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                    if (dayparkfee > daytopfee)
                                    {
                                        dayparkfee = daytopfee;
                                    }
                                    if (dayparkfee < daylowestfee)
                                    {
                                        dayparkfee = daylowestfee;
                                    }
                                    if (nightparkfee > nighttopfee)
                                    {
                                        nightparkfee = nighttopfee;
                                    }
                                    if (nightparkfee < nightlowestfee)
                                    {
                                        nightparkfee = nightlowestfee;
                                    }
                                    //停车整天数停车总费用

                                    decimal sumdays = dayparkfee + nightparkfee;
                                    //2017.2.15 jian改。
                                    if (sumdays > feetop)
                                    {
                                        sumdays = feetop;

                                    }
                                    decimal sumdaymoney = sumdays * parkdays;

                                    //decimal sumdaymoney = (dayparkfee + nightparkfee) * parkdays;
                                    #endregion
                                    #region 剩余分钟数收费金额

                                    TimeSpan span = nightstarttime - inhourminute;
                                    //剩余停车分钟数,白天段停车时间
                                    int dayparktime = int.Parse(span.TotalMinutes.ToString());
                                    //剩余停车分钟数,夜间段停车时间
                                    int nightparktime = parkminutes - dayparktime;
                                    if ((dayparktime % daytimeunit) > setminute)
                                    {
                                        leftdayfee = Decimal.Parse(Math.Ceiling(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                    }
                                    else
                                    {
                                        leftdayfee = Decimal.Parse(Math.Floor(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                    }
                                    if ((nightparktime % nighttimeunit) > setminute)
                                    {
                                        leftnightfee = Decimal.Parse(Math.Ceiling(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                    }
                                    else
                                    {
                                        leftnightfee = Decimal.Parse(Math.Floor(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                    }


                                    if (leftdayfee > daytopfee)
                                    {
                                        leftdayfee = daytopfee;
                                    }
                                    if (leftdayfee < daylowestfee)
                                    {
                                        leftdayfee = daylowestfee;
                                    }
                                    if (leftnightfee > nighttopfee)
                                    {
                                        leftnightfee = nighttopfee;
                                    }
                                    if (leftnightfee < nightlowestfee)
                                    {
                                        leftnightfee = nightlowestfee;
                                    }
                                    decimal leftmoney = leftdayfee + leftnightfee;

                                    if (leftmoney>feetop)
                                    {
                                        leftmoney = feetop;

                                    }

                                    #endregion
                                    sumMoney = sumdaymoney + leftmoney;

                                }
                            }

                        }
                        else //进场时间在夜间段((inhourminute<daystarttime)&&(inhourminute>=nightstarttime))
                        {
                            //进出场时间在夜间段
                            if ((outhourminute < daystarttime) || (outhourminute >= nightstarttime))
                            {
                                //停车时间小于24小时
                                if (parkTime < 1440)
                                {
                                    //进场时间在第一夜间段（凌晨）
                                    if (inhourminute <= daystarttime)
                                    {
                                        TimeSpan dayspan = nightstarttime - daystarttime;
                                        int daytime = int.Parse(dayspan.TotalMinutes.ToString());
                                        //夜间段停车时间
                                        int nightparktime = parkTime - daytime;
                                        //白天段停车时间
                                        int dayparktime = daytime;
                                        if ((dayparktime % daytimeunit) > setminute)
                                        {
                                            dayparkfee = Decimal.Parse(Math.Ceiling(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                        }
                                        else
                                        {
                                            dayparkfee = Decimal.Parse(Math.Floor(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                        }
                                        if ((nightparktime % nighttimeunit) > setminute)
                                        {
                                            nightparkfee = Decimal.Parse(Math.Ceiling(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                        }
                                        else
                                        {
                                            nightparkfee = Decimal.Parse(Math.Floor(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                        }


                                        if (dayparkfee > daytopfee)
                                        {
                                            dayparkfee = daytopfee;
                                        }
                                        if (dayparkfee < daylowestfee)
                                        {
                                            dayparkfee = daylowestfee;
                                        }
                                        if (nightparkfee > nighttopfee)
                                        {
                                            nightparkfee = nighttopfee;
                                        }
                                        if (nightparkfee < nightlowestfee)
                                        {
                                            nightparkfee = nightlowestfee;
                                        }


                                        sumMoney = dayparkfee + nightparkfee;
                                        //2017.2.15 jian改。
                                        if (sumMoney > feetop)
                                        {
                                            sumMoney = feetop;

                                        }




                                    }
                                    else//进场时间在第二夜间段（夜间段开始时间到0点）
                                    {
                                        //出场时间为第二天的凌晨夜间段
                                        if (outhourminute < inhourminute)
                                        {
                                            if ((parkTime % nighttimeunit) > setminute)
                                            {
                                                nightparkfee = Decimal.Parse(Math.Ceiling(parkTime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                            }
                                            else
                                            {
                                                nightparkfee = Decimal.Parse(Math.Floor(parkTime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                            }

                                            if (nightparkfee > nighttopfee)
                                            {
                                                nightparkfee = nighttopfee;
                                            }
                                            if (nightparkfee < nightlowestfee)
                                            {
                                                nightparkfee = nightlowestfee;
                                            }
                                            sumMoney = nightparkfee;
                                            //2017.2.15 jian改。
                                            if (sumMoney > feetop)
                                            {
                                                sumMoney = feetop;

                                            }

                                        }
                                        else//出场时间为第二天的接近零点的夜间段
                                        {
                                            TimeSpan dayspan = nightstarttime - daystarttime;
                                            int daytime = int.Parse(dayspan.TotalMinutes.ToString());
                                            //夜间段停车时间
                                            int nightparktime = parkTime - daytime;
                                            //白天段停车时间
                                            int dayparktime = daytime;
                                            if ((dayparktime % daytimeunit) > setminute)
                                            {
                                                dayparkfee = Decimal.Parse(Math.Ceiling(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                            }
                                            else
                                            {
                                                dayparkfee = Decimal.Parse(Math.Floor(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                            }
                                            if ((nightparktime % nighttimeunit) > setminute)
                                            {
                                                nightparkfee = Decimal.Parse(Math.Ceiling(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                            }
                                            else
                                            {
                                                nightparkfee = Decimal.Parse(Math.Floor(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                            }


                                            if (dayparkfee > daytopfee)
                                            {
                                                dayparkfee = daytopfee;
                                            }
                                            if (dayparkfee < daylowestfee)
                                            {
                                                dayparkfee = daylowestfee;
                                            }
                                            if (nightparkfee > nighttopfee)
                                            {
                                                nightparkfee = nighttopfee;
                                            }
                                            if (nightparkfee < nightlowestfee)
                                            {
                                                nightparkfee = nightlowestfee;
                                            }
                                            sumMoney = dayparkfee + nightparkfee;
                                            //2017.2.15 jian改。
                                            if (sumMoney > feetop)
                                            {
                                                sumMoney = feetop;

                                            }
                                        }

                                    }

                                }
                                else//停车时间大于等于24小时
                                {
                                    if (inhourminute <= daystarttime)
                                    {
                                        #region 停车整天数收费额金
                                        //停车整天数
                                        int parkdays = parkTime / 1440;
                                        //剩余停车分钟数
                                        int parkminutes = parkTime - 1440 * parkdays;
                                        TimeSpan dayspan = nightstarttime - daystarttime;
                                        //整天白天段停车分钟数
                                        int daytime = int.Parse(dayspan.TotalMinutes.ToString());
                                        //整天夜间段停车分钟数
                                        int nighttime = 1440 - daytime;
                                        //整天白天段停车费用
                                        dayparkfee = Decimal.Parse(Math.Ceiling(daytime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                        //整天夜间段停车费用
                                        nightparkfee = Decimal.Parse(Math.Ceiling(nighttime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                        if (dayparkfee > daytopfee)
                                        {
                                            dayparkfee = daytopfee;
                                        }
                                        if (dayparkfee < daylowestfee)
                                        {
                                            dayparkfee = daylowestfee;
                                        }
                                        if (nightparkfee > nighttopfee)
                                        {
                                            nightparkfee = nighttopfee;
                                        }
                                        if (nightparkfee < nightlowestfee)
                                        {
                                            nightparkfee = nightlowestfee;
                                        }
                                        //停车整天数停车总费用
                                        //2017.2.15 jian改
                                        decimal sumdays = dayparkfee + nightparkfee;
                                        if(sumdays>feetop)
                                        {
                                            sumdays = feetop;


                                        }
                                        decimal sumdaymoney = sumdays * parkdays;
                                        //  decimal sumdaymoney = (dayparkfee + nightparkfee) * parkdays;
                                        #endregion
                                        #region 剩余分钟数收费金额
                                        TimeSpan span = nightstarttime - daystarttime;
                                        //剩余停车分钟数,白天段停车时间
                                        int dayparktime = int.Parse(span.TotalMinutes.ToString());
                                        //剩余停车分钟数,夜间段停车时间
                                        int nightparktime = parkminutes - dayparktime;
                                        if ((nightparktime % nighttimeunit) > setminute)
                                        {
                                            leftnightfee = Decimal.Parse(Math.Ceiling(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                        }
                                        else
                                        {
                                            leftnightfee = Decimal.Parse(Math.Floor(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                        }
                                        if ((dayparktime % daytimeunit) > setminute)
                                        {
                                            leftdayfee = Decimal.Parse(Math.Ceiling(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                        }
                                        else
                                        {
                                            leftdayfee = Decimal.Parse(Math.Floor(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                        }

                                        if (leftdayfee > daytopfee)
                                        {
                                            leftdayfee = daytopfee;
                                        }
                                        if (leftdayfee < daylowestfee)
                                        {
                                            leftdayfee = daylowestfee;
                                        }
                                        if (leftnightfee > nighttopfee)
                                        {
                                            leftnightfee = nighttopfee;
                                        }
                                        if (leftnightfee < nightlowestfee)
                                        {
                                            leftnightfee = nightlowestfee;
                                        }
                                        decimal leftmoney = leftnightfee + leftdayfee;
                                        //2017.2.15 jian
                                        if (leftmoney > feetop)
                                        {
                                            leftmoney = feetop;
                                        }
                                        #endregion
                                        sumMoney = sumdaymoney + leftmoney;


                                    }
                                    else
                                    {
                                        #region 停车整天数收费额金
                                        //停车整天数
                                        int parkdays = parkTime / 1440;
                                        //剩余停车分钟数
                                        int parkminutes = parkTime - 1440 * parkdays;
                                        TimeSpan dayspan = nightstarttime - daystarttime;
                                        //整天白天段停车分钟数
                                        int daytime = int.Parse(dayspan.TotalMinutes.ToString());
                                        //整天夜间段停车分钟数
                                        int nighttime = 1440 - daytime;
                                        //整天白天段停车费用
                                        dayparkfee = Decimal.Parse(Math.Ceiling(daytime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                        //整天夜间段停车费用
                                        nightparkfee = Decimal.Parse(Math.Ceiling(nighttime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                        if (dayparkfee > daytopfee)
                                        {
                                            dayparkfee = daytopfee;
                                        }
                                        if (dayparkfee < daylowestfee)
                                        {
                                            dayparkfee = daylowestfee;
                                        }
                                        if (nightparkfee > nighttopfee)
                                        {
                                            nightparkfee = nighttopfee;
                                        }
                                        if (nightparkfee < nightlowestfee)
                                        {
                                            nightparkfee = nightlowestfee;
                                        }
                                        //停车整天数停车总费用
                                        decimal sumdaymoney = (dayparkfee + nightparkfee) * parkdays;
                                        #endregion
                                        if (outhourminute <= inhourminute)
                                        {
                                            if ((parkminutes % nighttimeunit) > setminute)
                                            {
                                                nightparkfee = Decimal.Parse(Math.Ceiling(parkminutes / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                            }
                                            else
                                            {
                                                nightparkfee = Decimal.Parse(Math.Floor(parkminutes / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                            }

                                            if (nightparkfee > nighttopfee)
                                            {
                                                nightparkfee = nighttopfee;
                                            }
                                            if (nightparkfee < nightlowestfee)
                                            {
                                                nightparkfee = nightlowestfee;
                                            }

                                            //2017.2.15 jian改
                                            if (nightparkfee > feetop)
                                            {
                                                nightparkfee = feetop;

                                            }

                                            sumMoney = sumdaymoney + nightparkfee;



                                        }
                                        else
                                        {
                                            //白天段停车时间
                                            int dayparktime = daytime;
                                            //夜间段停车时间
                                            int nightparktime = parkTime - daytime;
                                            if ((nightparktime % nighttimeunit) > setminute)
                                            {
                                                nightparkfee = Decimal.Parse(Math.Ceiling(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                            }
                                            else
                                            {
                                                nightparkfee = Decimal.Parse(Math.Floor(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                            }
                                            if ((dayparktime % daytimeunit) > setminute)
                                            {
                                                dayparkfee = Decimal.Parse(Math.Ceiling(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                            }
                                            else
                                            {
                                                dayparkfee = Decimal.Parse(Math.Floor(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                            }


                                            if (dayparkfee > daytopfee)
                                            {
                                                dayparkfee = daytopfee;
                                            }
                                            if (dayparkfee < daylowestfee)
                                            {
                                                dayparkfee = daylowestfee;
                                            }
                                            if (nightparkfee > nighttopfee)
                                            {
                                                nightparkfee = nighttopfee;
                                            }
                                            if (nightparkfee < nightlowestfee)
                                            {
                                                nightparkfee = nightlowestfee;
                                            }
                                            //2017.2.15 jian改
                                            decimal sumdays = dayparkfee + nightparkfee;
                                            if (sumdays > feetop)
                                            {
                                                sumdays = feetop;
                                            }

                                            sumMoney = sumdaymoney + sumdays;
                                            //  sumMoney = sumdaymoney + dayparkfee + nightparkfee;
                                        }
                                    }
                                }

                            }
                            else//进场时间在夜间段，出场时间在白天段（进场场不在同一天，这种情况下，进场时间必定小于白天段开始的时间）
                            {
                                if (parkTime < 1440)
                                {
                                    TimeSpan dayparkspan = outhourminute - daystarttime;
                                    //白天段停车时间
                                    int dayparktime = int.Parse(dayparkspan.TotalMinutes.ToString());
                                    int nightparktime = parkTime - dayparktime;
                                    if ((dayparktime % daytimeunit) > setminute)
                                    {
                                        dayparkfee = Decimal.Parse(Math.Ceiling(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                    }
                                    else
                                    {
                                        dayparkfee = Decimal.Parse(Math.Floor(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                    }
                                    if ((nightparktime % nighttimeunit) > setminute)
                                    {
                                        nightparkfee = Decimal.Parse(Math.Ceiling(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                    }
                                    else
                                    {
                                        nightparkfee = Decimal.Parse(Math.Floor(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                    }

                                    if (dayparkfee > daytopfee)
                                    {
                                        dayparkfee = daytopfee;
                                    }
                                    if (dayparkfee < daylowestfee)
                                    {
                                        dayparkfee = daylowestfee;
                                    }
                                    if (nightparkfee > nighttopfee)
                                    {
                                        nightparkfee = nighttopfee;
                                    }
                                    if (nightparkfee < nightlowestfee)
                                    {
                                        nightparkfee = nightlowestfee;
                                    }
                                    sumMoney = dayparkfee + nightparkfee;
                                    //2017.2.15 jian 改
                                    if (sumMoney > feetop)
                                    {
                                        sumMoney = feetop;

                                    }


                                }
                                else
                                {
                                    #region 停车整天数收费额金
                                    //停车整天数
                                    int parkdays = parkTime / 1440;
                                    //剩余停车分钟数
                                    int parkminutes = parkTime - 1440 * parkdays;
                                    TimeSpan dayspan = nightstarttime - daystarttime;
                                    //整天白天段停车分钟数
                                    int daytime = int.Parse(dayspan.TotalMinutes.ToString());
                                    //整天夜间段停车分钟数
                                    int nighttime = 1440 - daytime;
                                    //整天白天段停车费用
                                    dayparkfee = Decimal.Parse(Math.Ceiling(daytime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                    //整天夜间段停车费用
                                    nightparkfee = Decimal.Parse(Math.Ceiling(nighttime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                    if (dayparkfee > daytopfee)
                                    {
                                        dayparkfee = daytopfee;
                                    }
                                    if (dayparkfee < daylowestfee)
                                    {
                                        dayparkfee = daylowestfee;
                                    }
                                    if (nightparkfee > nighttopfee)
                                    {
                                        nightparkfee = nighttopfee;
                                    }
                                    if (nightparkfee < nightlowestfee)
                                    {
                                        nightparkfee = nightlowestfee;
                                    }
                                    //停车整天数停车总费用



                                    decimal sumdaymoney = feetop * parkdays;

                                    //decimal sumdaymoney = (dayparkfee + nightparkfee) * parkdays;
                                    #endregion

                                    TimeSpan dayparkspan = outhourminute - daystarttime;
                                    //白天段停车时间
                                    int dayparktime = int.Parse(dayparkspan.TotalMinutes.ToString());
                                    int nightparktime = parkminutes - dayparktime;
                                    if ((dayparktime % daytimeunit) > setminute)
                                    {
                                        leftdayfee = Decimal.Parse(Math.Ceiling(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                    }
                                    else
                                    {
                                        leftdayfee = Decimal.Parse(Math.Floor(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                    }
                                    if ((nightparktime % nighttimeunit) > setminute)
                                    {
                                        leftnightfee = Decimal.Parse(Math.Ceiling(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                    }
                                    else
                                    {
                                        leftnightfee = Decimal.Parse(Math.Floor(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                    }
                                    if (leftdayfee > daytopfee)
                                    {
                                        leftdayfee = daytopfee;
                                    }
                                    if (leftdayfee < daylowestfee)
                                    {
                                        leftdayfee = daylowestfee;
                                    }
                                    if (leftnightfee > nighttopfee)
                                    {
                                        leftnightfee = nighttopfee;
                                    }
                                    if (leftnightfee < nightlowestfee)
                                    {
                                        leftnightfee = nightlowestfee;
                                    }

                                    decimal sumdays = leftdayfee + leftnightfee;
                                    if (sumdays > feetop)
                                    {
                                        sumdays = feetop;
                                    }
                                    sumMoney = sumdaymoney + sumdays;
                                   // sumMoney = sumdaymoney + leftdayfee + leftnightfee;
                                }


                            }
                        }

                        return sumMoney;

                    }

                }
                else
                {
                    return sumMoney;
                }
                #endregion

            }
            else
            {
                return sumMoney;
            }

        }

        /// <summary>
        /// 计算停车费额
        /// </summary>
        /// <param name="intime">进场时间</param>
        /// <param name="carType">车辆类型</param>
        /// <returns></returns>
        public decimal CalulateFee(DateTime intime, DateTime carouttime, string carType)
        {
            int parkTime;
            int setminute = iniinfo.OverTime;
            decimal sumMoney = 0;
            //计算车辆停留时间(分钟)
            TimeSpan timeSpan = carouttime - intime;
            parkTime = int.Parse(Math.Ceiling(timeSpan.TotalMinutes).ToString());
            FeeStandard feeStandardModel = this.GetChargeStandardByCarType(carType);
            feeStandard = feeStandardModel.FeeType;
            //每天最高收费
            decimal feetop = feeStandardModel.Feetop ?? 0;
            //车辆进场日期的月份
            int inmonth = intime.Month;
            //车辆出场日期的月份
            int outmonth = carouttime.Month;
            //车辆进场日期的号数
            int inday = intime.Day;
            //车辆出场日期的号数
            int outday = carouttime.Day;
            //用于判定停车是否为同一天
            int day = outday - inday;
            if (inmonth != outmonth)
            {
                TimeSpan mspan = carouttime - intime;
                day = (int)mspan.TotalDays;
            }
            #region 进场时间inhourminute
            //进场时间小时
            string inhour = intime.Hour.ToString();
            //进场时间分钟
            string inminute = intime.Minute.ToString();
            //进场小时分钟数（时间点）
            DateTime inhourminute = Convert.ToDateTime(inhour + ":" + inminute);
            #endregion
            #region 出场时间outhourminute
            //出场时间小时
            string outhour = carouttime.Hour.ToString();
            //出场时间分钟
            string outminute = carouttime.Minute.ToString();
            //出场小时分钟数 （时间点）
            DateTime outhourminute = Convert.ToDateTime(outhour + ":" + outminute);
            #endregion
            //如果停车时间大于免费时间就进行计费
            if (parkTime > feeStandardModel.FreeMinutes)
            {

                #region 按收费标准计算费用
                if (feeStandard == "按次收费")
                {
                    if (carType == "内部车辆")
                    {
                        parkTime = parkTime - feeStandardModel.FreeMinutes ?? 0;
                        sumMoney = int.Parse(Math.Ceiling(parkTime / 1440.0).ToString()) * feeStandardModel.FeePerView ?? 0;
                        return sumMoney;
                    }
                    else
                    {
                        sumMoney = feeStandardModel.FeePerView ?? 0;
                        return sumMoney * (day + 1);
                    }

                }
                else if (feeStandard == "标准收费")
                {
                    string standardFee = feeStandardModel.StandardFee;
                    //每天最高收费
                    decimal feeTop = feeStandardModel.Feetop ?? 0;
                    string[] fee = standardFee.Split(',');
                    int parkHour = 0;
                    if ((parkTime % 60) > setminute)
                    {
                        parkHour = int.Parse(Math.Ceiling(parkTime / 60.0).ToString());
                    }
                    else
                    {
                        parkHour = int.Parse(Math.Floor(parkTime / 60.0).ToString());
                    }

                    //判断停车时间是否超过一天（包括一天）
                    if (parkHour >= 24)
                    {
                        decimal dayfee = decimal.Parse(fee[23]);
                        int n = parkHour % 24;
                        if (n == 0)
                        {
                            sumMoney = (parkHour / 24) * decimal.Parse(fee[23]);
                        }
                        else
                        {
                            sumMoney = (parkHour / 24) * decimal.Parse(fee[23]) + decimal.Parse(fee[n - 1]);
                        }

                    }
                    else
                    {
                        sumMoney = decimal.Parse(fee[parkHour % 24 - 1]);
                    }
                    return sumMoney;
                }
                else if (feeStandard == "按设定时间收费")
                {
                    //计时单位
                    int timeunit = feeStandardModel.STTimeUnie ?? 0;
                    //每计时单位费额
                    decimal unitfee = feeStandardModel.STUnieFee ?? 0;
                    //过零点收取的过夜费
                    decimal overfee = feeStandardModel.STOverNightFee ?? 0;
                    //进场到当天零点的停车时间
                    int inparktime = CaculateMunites(Convert.ToDateTime(inhourminute), Convert.ToDateTime("23:59:59"));
                    //进场到当天零点的停车时间停车费额
                    decimal infee = 0;
                    //出场当天的停车时间停车费额
                    decimal outfee = 0;
                    //停车一整天所需费
                    decimal dayfee = 0;
                    //出场当天的停车时间
                    int outparktime = CaculateMunites(Convert.ToDateTime("00:00"), Convert.ToDateTime(outhourminute));
                    //判断是否过零点，收取过夜费
                    if (day > 0)
                    {
                        if (parkTime < 1440)
                        {
                            if ((inparktime % timeunit) > setminute)
                            {
                                infee = Decimal.Parse(Math.Ceiling(inparktime / 1.00 / timeunit).ToString()) * unitfee;
                            }
                            else
                            {
                                infee = Decimal.Parse(Math.Floor(inparktime / 1.00 / timeunit).ToString()) * unitfee;
                            }
                            if ((outparktime % timeunit) > setminute)
                            {
                                outfee = Decimal.Parse(Math.Ceiling(outparktime / 1.00 / timeunit).ToString()) * unitfee;
                            }
                            else
                            {
                                outfee = Decimal.Parse(Math.Floor(outparktime / 1.00 / timeunit).ToString()) * unitfee;
                            }
                            if (infee > feetop)
                            {
                                infee = feetop;
                            }
                            if (outfee > feetop)
                            {
                                outfee = feetop;
                            }
                            sumMoney = infee + outfee + overfee;
                        }
                        else
                        {
                            if ((inparktime % timeunit) > setminute)
                            {
                                infee = Decimal.Parse(Math.Ceiling(inparktime / 1.00 / timeunit).ToString()) * unitfee;
                            }
                            else
                            {
                                infee = Decimal.Parse(Math.Floor(inparktime / 1.00 / timeunit).ToString()) * unitfee;
                            }
                            if ((outparktime % timeunit) > setminute)
                            {
                                outfee = Decimal.Parse(Math.Ceiling(outparktime / 1.00 / timeunit).ToString()) * unitfee;
                            }
                            else
                            {
                                outfee = Decimal.Parse(Math.Floor(outparktime / 1.00 / timeunit).ToString()) * unitfee;
                            }
                            dayfee = int.Parse(Math.Ceiling(1440.00 / timeunit).ToString()) * unitfee;
                            if (infee > feetop)
                            {
                                infee = feetop;
                            }
                            if (outfee > feetop)
                            {
                                outfee = feetop;
                            }
                            if (dayfee > feetop)
                            {
                                dayfee = feetop;
                            }
                            int n = (parkTime - inparktime - outparktime) / 1440;
                            sumMoney = infee + outfee + dayfee * n + overfee * day;
                        }

                    }
                    else
                    {
                        if ((parkTime % timeunit) > setminute)
                        {
                            sumMoney = Decimal.Parse(Math.Ceiling(parkTime / 1.00 / timeunit).ToString()) * unitfee;
                        }
                        else
                        {
                            sumMoney = Decimal.Parse(Math.Floor(parkTime / 1.00 / timeunit).ToString()) * unitfee;
                        }

                        if (sumMoney > feetop)
                        {
                            sumMoney = feetop;
                        }
                    }
                    return sumMoney;
                }
                else if (feeStandard == "按白天夜间段收费")
                {

                    #region 白天段
                    //白天段开始小时数
                    int daystarthour = feeStandardModel.DayStartHour ?? 0;
                    //白天段开始分钟数
                    int daystartminute = feeStandardModel.DayStartMinute ?? 0;
                    //白天段计时单位
                    int daytimeunit = feeStandardModel.DayTimeUnit ?? 0;
                    //白天段每计时单位费额（元）
                    decimal dayunitfee = feeStandardModel.DayUnitFee ?? 0;
                    //白天段最高收费
                    decimal daytopfee = feeStandardModel.DayTopFee ?? 0;
                    //白天段最低收费
                    decimal daylowestfee = feeStandardModel.DayLowestFee ?? 0;
                    //白天段收费
                    decimal dayparkfee = 0;
                    //剩余时间收费
                    decimal leftdayfee = 0;
                    #endregion

                    #region 夜间段
                    //白天段开始小时数
                    int nightstarthour = feeStandardModel.NightStartHour ?? 0;
                    //白天段开始分钟数
                    int nightstartminute = feeStandardModel.NightStartMinute ?? 0;
                    //白天段计时单位
                    int nighttimeunit = feeStandardModel.NightTimeUnit ?? 0;
                    //夜间段每计时单位费额（元）
                    decimal nightunitfee = feeStandardModel.NightUnitFee ?? 0;
                    //夜间段最高收费
                    decimal nighttopfee = feeStandardModel.NightTopFee ?? 0;
                    //夜间段最低收费
                    decimal nightlowestfee = feeStandardModel.NightLowestFee ?? 0;
                    //夜间段收费
                    decimal nightparkfee = 0;
                    //剩余时间收费
                    decimal leftnightfee = 0;
                    #endregion

                    //设置的白天段开始时间
                    DateTime daystarttime = Convert.ToDateTime(daystarthour.ToString() + ":" + daystartminute.ToString());
                    //设置的夜间段开始时间
                    DateTime nightstarttime = Convert.ToDateTime(nightstarthour.ToString() + ":" + nightstartminute.ToString());
                    //判断是进场场是否在同一天
                    if (outday == inday)
                    {
                        //进场时间在白天段内
                        if ((inhourminute >= daystarttime) && (inhourminute <= nightstarttime))
                        {
                            //进出场时间在白天内
                            if ((outhourminute >= daystarttime) && (outhourminute < nightstarttime))
                            {
                                if ((parkTime % daytimeunit) > setminute)
                                {
                                    sumMoney = Decimal.Parse(Math.Ceiling(parkTime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                }
                                else
                                {
                                    sumMoney = Decimal.Parse(Math.Floor(parkTime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                }

                                if (sumMoney > daytopfee)
                                {
                                    sumMoney = daytopfee;
                                }
                                if (sumMoney < daylowestfee)
                                {
                                    sumMoney = daylowestfee;
                                }
                            }

                            else//进场时间在白天段内，出场时间在夜间段内
                            {
                                TimeSpan dayparkspan = nightstarttime - inhourminute;
                                int dayparktime = int.Parse(dayparkspan.TotalMinutes.ToString());
                                int nightparktime = parkTime - dayparktime;
                                if ((dayparktime % daytimeunit) > setminute)
                                {
                                    dayparkfee = Decimal.Parse(Math.Ceiling(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                }
                                else
                                {
                                    dayparkfee = Decimal.Parse(Math.Floor(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                }
                                if ((nightparktime % nighttimeunit) > setminute)
                                {
                                    nightparkfee = Decimal.Parse(Math.Ceiling(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                }
                                else
                                {
                                    nightparkfee = Decimal.Parse(Math.Floor(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                }

                                if (dayparkfee > daytopfee)
                                {
                                    dayparkfee = daytopfee;
                                }
                                if (dayparkfee < daylowestfee)
                                {
                                    dayparkfee = daylowestfee;
                                }
                                if (nightparkfee > nighttopfee)
                                {
                                    nightparkfee = nighttopfee;
                                }
                                if (nightparkfee < nightlowestfee)
                                {
                                    nightparkfee = nightlowestfee;
                                }
                                sumMoney = dayparkfee + nightparkfee;
                            }

                        }
                        else //进场时间在夜间段((inhourminute<daystarttime)&&(inhourminute>=nightstarttime))
                        {
                            //进出场时间在夜间段
                            if ((outhourminute < daystarttime) || (outhourminute >= nightstarttime))
                            {
                                if ((parkTime % nighttimeunit) > setminute)
                                {
                                    nightparkfee = Decimal.Parse(Math.Ceiling(parkTime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                }
                                else
                                {
                                    nightparkfee = Decimal.Parse(Math.Floor(parkTime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                }

                                if (nightparkfee > nighttopfee)
                                {
                                    nightparkfee = nighttopfee;
                                }
                                if (nightparkfee < nightlowestfee)
                                {
                                    nightparkfee = nightlowestfee;
                                }
                                sumMoney = nightparkfee;
                            }
                            else//进场时间在夜间段，出场时间在白天段（进场场为同一天，这种情况下，进场时间必定小于白天段开始的时间）
                            {

                                TimeSpan dayparkspan = outhourminute - daystarttime;
                                //白天段停车时间
                                int dayparktime = int.Parse(dayparkspan.TotalMinutes.ToString());
                                int nightparktime = parkTime - dayparktime;
                                if ((dayparktime % daytimeunit) > setminute)
                                {
                                    dayparkfee = Decimal.Parse(Math.Ceiling(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                }
                                else
                                {
                                    dayparkfee = Decimal.Parse(Math.Floor(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                }
                                if ((nightparktime % nighttimeunit) > setminute)
                                {
                                    nightparkfee = Decimal.Parse(Math.Ceiling(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                }
                                else
                                {
                                    nightparkfee = Decimal.Parse(Math.Floor(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                }
                                if (dayparkfee > daytopfee)
                                {
                                    dayparkfee = daytopfee;
                                }
                                if (dayparkfee < daylowestfee)
                                {
                                    dayparkfee = daylowestfee;
                                }
                                if (nightparkfee > nighttopfee)
                                {
                                    nightparkfee = nighttopfee;
                                }
                                if (nightparkfee < nightlowestfee)
                                {
                                    nightparkfee = nightlowestfee;
                                }
                                sumMoney = dayparkfee + nightparkfee;
                            }
                        }

                        return sumMoney;
                    }
                    else//进出场时间不是同一天
                    {
                        //进场时间在白天段内
                        if ((inhourminute >= daystarttime) && (inhourminute < nightstarttime))
                        {
                            //进出场时间在白天内
                            if ((outhourminute >= daystarttime) && (outhourminute < nightstarttime))
                            {
                                //停车时间小于24小时
                                if (parkTime < 1440)
                                {
                                    TimeSpan dayspan = nightstarttime - daystarttime;
                                    int daytime = int.Parse(dayspan.TotalMinutes.ToString());
                                    //夜间段停车时间
                                    int nightparktime = 1440 - daytime;
                                    //白天段停车时间
                                    int dayparktime = parkTime - nightparktime;
                                    if ((dayparktime % daytimeunit) > setminute)
                                    {
                                        dayparkfee = Decimal.Parse(Math.Ceiling(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                    }
                                    else
                                    {
                                        dayparkfee = Decimal.Parse(Math.Floor(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                    }
                                    if ((nightparktime % nighttimeunit) > setminute)
                                    {
                                        nightparkfee = Decimal.Parse(Math.Ceiling(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                    }
                                    else
                                    {
                                        nightparkfee = Decimal.Parse(Math.Floor(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                    }


                                    if (dayparkfee > daytopfee)
                                    {
                                        dayparkfee = daytopfee;
                                    }
                                    if (dayparkfee < daylowestfee)
                                    {
                                        dayparkfee = daylowestfee;
                                    }
                                    if (nightparkfee > nighttopfee)
                                    {
                                        nightparkfee = nighttopfee;
                                    }
                                    if (nightparkfee < nightlowestfee)
                                    {
                                        nightparkfee = nightlowestfee;
                                    }
                                    sumMoney = dayparkfee + nightparkfee;

                                }
                                else
                                {
                                    #region 停车整天数收费额金
                                    //停车整天数
                                    int parkdays = parkTime / 1440;
                                    //剩余停车分钟数
                                    int leftparkminutes = parkTime - 1440 * parkdays;
                                    TimeSpan dayspan = nightstarttime - daystarttime;
                                    //整天白天段停车分钟数
                                    int daytime = int.Parse(dayspan.TotalMinutes.ToString());
                                    //整天夜间段停车分钟数
                                    int nighttime = 1440 - daytime;
                                    //整天白天段停车费用
                                    if ((daytime % daytimeunit) > setminute)
                                    {
                                        dayparkfee = Decimal.Parse(Math.Ceiling(daytime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                    }
                                    else
                                    {
                                        dayparkfee = Decimal.Parse(Math.Floor(daytime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                    }

                                    //整天夜间段停车费用
                                    if ((nighttime % nighttimeunit) > setminute)
                                    {
                                        nightparkfee = Decimal.Parse(Math.Ceiling(nighttime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                    }
                                    else
                                    {
                                        nightparkfee = Decimal.Parse(Math.Floor(nighttime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                    }

                                    if (dayparkfee > daytopfee)
                                    {
                                        dayparkfee = daytopfee;
                                    }
                                    if (dayparkfee < daylowestfee)
                                    {
                                        dayparkfee = daylowestfee;
                                    }
                                    if (nightparkfee > nighttopfee)
                                    {
                                        nightparkfee = nighttopfee;
                                    }
                                    if (nightparkfee < nightlowestfee)
                                    {
                                        nightparkfee = nightlowestfee;
                                    }
                                    //停车整天数停车总费用
                                    decimal sumdaymoney = (dayparkfee + nightparkfee) * parkdays;
                                    #endregion
                                    #region 剩余分钟数收费金额

                                    decimal leftmoney = 0;

                                    if (inhourminute <= outhourminute)
                                    {
                                        if ((leftparkminutes % daytimeunit) > setminute)
                                        {
                                            leftdayfee = decimal.Parse(Math.Ceiling(leftparkminutes / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                        }
                                        else
                                        {
                                            leftdayfee = decimal.Parse(Math.Floor(leftparkminutes / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                        }

                                        leftmoney = leftdayfee;
                                    }
                                    //夜间段都停车
                                    else
                                    {

                                        //剩余停车分钟数,白天段停车时间
                                        int dayparktime = leftparkminutes - nighttime;
                                        //剩余停车分钟数,夜间段停车时间
                                        int nightparktime = leftparkminutes - dayparktime;
                                        if ((dayparktime % daytimeunit) > setminute)
                                        {
                                            leftdayfee = decimal.Parse(Math.Ceiling(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                        }
                                        else
                                        {
                                            leftdayfee = decimal.Parse(Math.Floor(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                        }
                                        if ((nightparktime % nighttimeunit) > setminute)
                                        {
                                            leftnightfee = Decimal.Parse(Math.Ceiling(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                        }
                                        else
                                        {
                                            leftnightfee = Decimal.Parse(Math.Floor(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                        }
                                        if (leftdayfee > daytopfee)
                                        {
                                            leftdayfee = daytopfee;
                                        }
                                        if (leftdayfee < daylowestfee)
                                        {
                                            leftdayfee = daylowestfee;
                                        }
                                        if (leftnightfee > nighttopfee)
                                        {
                                            leftnightfee = nighttopfee;
                                        }
                                        if (leftnightfee < nightlowestfee)
                                        {
                                            leftnightfee = nightlowestfee;
                                        }
                                        leftmoney = leftdayfee + leftnightfee;
                                    }

                                    #endregion
                                    sumMoney = sumdaymoney + leftmoney;
                                }

                            }

                            else//进场时间在白天段内，出场时间在夜间段内
                            {
                                //停车时间小于24小时
                                if (parkTime < 1440)
                                {
                                    TimeSpan dayparkspan = nightstarttime - inhourminute;
                                    //白天段停车时间
                                    int dayparktime = int.Parse(dayparkspan.TotalMinutes.ToString());
                                    //夜间段停车段
                                    int nightparktime = parkTime - dayparktime;
                                    if ((dayparktime % daytimeunit) > setminute)
                                    {
                                        dayparkfee = Decimal.Parse(Math.Ceiling(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                    }
                                    else
                                    {
                                        dayparkfee = Decimal.Parse(Math.Floor(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                    }
                                    if ((nightparktime % nighttimeunit) > setminute)
                                    {
                                        nightparkfee = Decimal.Parse(Math.Ceiling(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                    }
                                    else
                                    {
                                        nightparkfee = Decimal.Parse(Math.Floor(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                    }


                                    if (dayparkfee > daytopfee)
                                    {
                                        dayparkfee = daytopfee;
                                    }
                                    if (dayparkfee < daylowestfee)
                                    {
                                        dayparkfee = daylowestfee;
                                    }
                                    if (nightparkfee > nighttopfee)
                                    {
                                        nightparkfee = nighttopfee;
                                    }
                                    if (nightparkfee < nightlowestfee)
                                    {
                                        nightparkfee = nightlowestfee;
                                    }
                                    sumMoney = dayparkfee + nightparkfee;
                                }
                                else//停车时间大于24小时，则分为两种情况
                                {
                                    //进场时间大于小于或等于出场时间
                                    #region 停车整天数收费额金
                                    //停车整天数
                                    int parkdays = parkTime / 1440;
                                    //剩余停车分钟数
                                    int parkminutes = parkTime - 1440 * parkdays;
                                    TimeSpan dayspan = nightstarttime - daystarttime;
                                    //整天白天段停车分钟数
                                    int daytime = int.Parse(dayspan.TotalMinutes.ToString());
                                    //整天夜间段停车分钟数
                                    int nighttime = 1440 - daytime;
                                    //整天白天段停车费用
                                    dayparkfee = Decimal.Parse(Math.Ceiling(daytime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                    //整天夜间段停车费用
                                    nightparkfee = Decimal.Parse(Math.Ceiling(nighttime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                    if (dayparkfee > daytopfee)
                                    {
                                        dayparkfee = daytopfee;
                                    }
                                    if (dayparkfee < daylowestfee)
                                    {
                                        dayparkfee = daylowestfee;
                                    }
                                    if (nightparkfee > nighttopfee)
                                    {
                                        nightparkfee = nighttopfee;
                                    }
                                    if (nightparkfee < nightlowestfee)
                                    {
                                        nightparkfee = nightlowestfee;
                                    }
                                    //停车整天数停车总费用
                                    decimal sumdaymoney = (dayparkfee + nightparkfee) * parkdays;
                                    #endregion
                                    #region 剩余分钟数收费金额

                                    TimeSpan span = nightstarttime - inhourminute;
                                    //剩余停车分钟数,白天段停车时间
                                    int dayparktime = int.Parse(span.TotalMinutes.ToString());
                                    //剩余停车分钟数,夜间段停车时间
                                    int nightparktime = parkminutes - dayparktime;
                                    if ((dayparktime % daytimeunit) > setminute)
                                    {
                                        leftdayfee = Decimal.Parse(Math.Ceiling(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                    }
                                    else
                                    {
                                        leftdayfee = Decimal.Parse(Math.Floor(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                    }
                                    if ((nightparktime % nighttimeunit) > setminute)
                                    {
                                        leftnightfee = Decimal.Parse(Math.Ceiling(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                    }
                                    else
                                    {
                                        leftnightfee = Decimal.Parse(Math.Floor(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                    }


                                    if (leftdayfee > daytopfee)
                                    {
                                        leftdayfee = daytopfee;
                                    }
                                    if (leftdayfee < daylowestfee)
                                    {
                                        leftdayfee = daylowestfee;
                                    }
                                    if (leftnightfee > nighttopfee)
                                    {
                                        leftnightfee = nighttopfee;
                                    }
                                    if (leftnightfee < nightlowestfee)
                                    {
                                        leftnightfee = nightlowestfee;
                                    }
                                    decimal leftmoney = leftdayfee + leftnightfee;
                                    #endregion
                                    sumMoney = sumdaymoney + leftmoney;
                                }
                            }

                        }
                        else //进场时间在夜间段((inhourminute<daystarttime)&&(inhourminute>=nightstarttime))
                        {
                            //进出场时间在夜间段
                            if ((outhourminute < daystarttime) || (outhourminute >= nightstarttime))
                            {
                                //停车时间小于24小时
                                if (parkTime < 1440)
                                {
                                    //进场时间在第一夜间段（凌晨）
                                    if (inhourminute <= daystarttime)
                                    {
                                        TimeSpan dayspan = nightstarttime - daystarttime;
                                        int daytime = int.Parse(dayspan.TotalMinutes.ToString());
                                        //夜间段停车时间
                                        int nightparktime = parkTime - daytime;
                                        //白天段停车时间
                                        int dayparktime = daytime;
                                        if ((dayparktime % daytimeunit) > setminute)
                                        {
                                            dayparkfee = Decimal.Parse(Math.Ceiling(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                        }
                                        else
                                        {
                                            dayparkfee = Decimal.Parse(Math.Floor(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                        }
                                        if ((nightparktime % nighttimeunit) > setminute)
                                        {
                                            nightparkfee = Decimal.Parse(Math.Ceiling(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                        }
                                        else
                                        {
                                            nightparkfee = Decimal.Parse(Math.Floor(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                        }


                                        if (dayparkfee > daytopfee)
                                        {
                                            dayparkfee = daytopfee;
                                        }
                                        if (dayparkfee < daylowestfee)
                                        {
                                            dayparkfee = daylowestfee;
                                        }
                                        if (nightparkfee > nighttopfee)
                                        {
                                            nightparkfee = nighttopfee;
                                        }
                                        if (nightparkfee < nightlowestfee)
                                        {
                                            nightparkfee = nightlowestfee;
                                        }
                                        sumMoney = dayparkfee + nightparkfee;
                                    }
                                    else//进场时间在第二夜间段（夜间段开始时间到0点）
                                    {
                                        //出场时间为第二天的凌晨夜间段
                                        if (outhourminute < inhourminute)
                                        {
                                            if ((parkTime % nighttimeunit) > setminute)
                                            {
                                                nightparkfee = Decimal.Parse(Math.Ceiling(parkTime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                            }
                                            else
                                            {
                                                nightparkfee = Decimal.Parse(Math.Floor(parkTime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                            }

                                            if (nightparkfee > nighttopfee)
                                            {
                                                nightparkfee = nighttopfee;
                                            }
                                            if (nightparkfee < nightlowestfee)
                                            {
                                                nightparkfee = nightlowestfee;
                                            }
                                            sumMoney = nightparkfee;
                                        }
                                        else//出场时间为第二天的接近零点的夜间段
                                        {
                                            TimeSpan dayspan = nightstarttime - daystarttime;
                                            int daytime = int.Parse(dayspan.TotalMinutes.ToString());
                                            //夜间段停车时间
                                            int nightparktime = parkTime - daytime;
                                            //白天段停车时间
                                            int dayparktime = daytime;
                                            if ((dayparktime % daytimeunit) > setminute)
                                            {
                                                dayparkfee = Decimal.Parse(Math.Ceiling(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                            }
                                            else
                                            {
                                                dayparkfee = Decimal.Parse(Math.Floor(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                            }
                                            if ((nightparktime % nighttimeunit) > setminute)
                                            {
                                                nightparkfee = Decimal.Parse(Math.Ceiling(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                            }
                                            else
                                            {
                                                nightparkfee = Decimal.Parse(Math.Floor(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                            }


                                            if (dayparkfee > daytopfee)
                                            {
                                                dayparkfee = daytopfee;
                                            }
                                            if (dayparkfee < daylowestfee)
                                            {
                                                dayparkfee = daylowestfee;
                                            }
                                            if (nightparkfee > nighttopfee)
                                            {
                                                nightparkfee = nighttopfee;
                                            }
                                            if (nightparkfee < nightlowestfee)
                                            {
                                                nightparkfee = nightlowestfee;
                                            }
                                            sumMoney = dayparkfee + nightparkfee;
                                        }

                                    }

                                }
                                else//停车时间大于等于24小时
                                {
                                    if (inhourminute <= daystarttime)
                                    {
                                        #region 停车整天数收费额金
                                        //停车整天数
                                        int parkdays = parkTime / 1440;
                                        //剩余停车分钟数
                                        int parkminutes = parkTime - 1440 * parkdays;
                                        TimeSpan dayspan = nightstarttime - daystarttime;
                                        //整天白天段停车分钟数
                                        int daytime = int.Parse(dayspan.TotalMinutes.ToString());
                                        //整天夜间段停车分钟数
                                        int nighttime = 1440 - daytime;
                                        //整天白天段停车费用
                                        dayparkfee = Decimal.Parse(Math.Ceiling(daytime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                        //整天夜间段停车费用
                                        nightparkfee = Decimal.Parse(Math.Ceiling(nighttime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                        if (dayparkfee > daytopfee)
                                        {
                                            dayparkfee = daytopfee;
                                        }
                                        if (dayparkfee < daylowestfee)
                                        {
                                            dayparkfee = daylowestfee;
                                        }
                                        if (nightparkfee > nighttopfee)
                                        {
                                            nightparkfee = nighttopfee;
                                        }
                                        if (nightparkfee < nightlowestfee)
                                        {
                                            nightparkfee = nightlowestfee;
                                        }
                                        //停车整天数停车总费用
                                        decimal sumdaymoney = (dayparkfee + nightparkfee) * parkdays;
                                        #endregion
                                        #region 剩余分钟数收费金额
                                        TimeSpan span = nightstarttime - daystarttime;
                                        //剩余停车分钟数,白天段停车时间
                                        int dayparktime = int.Parse(span.TotalMinutes.ToString());
                                        //剩余停车分钟数,夜间段停车时间
                                        int nightparktime = parkminutes - dayparktime;
                                        if ((nightparktime % nighttimeunit) > setminute)
                                        {
                                            leftnightfee = Decimal.Parse(Math.Ceiling(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                        }
                                        else
                                        {
                                            leftnightfee = Decimal.Parse(Math.Floor(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                        }
                                        if ((dayparktime % daytimeunit) > setminute)
                                        {
                                            leftdayfee = Decimal.Parse(Math.Ceiling(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                        }
                                        else
                                        {
                                            leftdayfee = Decimal.Parse(Math.Floor(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                        }

                                        if (leftdayfee > daytopfee)
                                        {
                                            leftdayfee = daytopfee;
                                        }
                                        if (leftdayfee < daylowestfee)
                                        {
                                            leftdayfee = daylowestfee;
                                        }
                                        if (leftnightfee > nighttopfee)
                                        {
                                            leftnightfee = nighttopfee;
                                        }
                                        if (leftnightfee < nightlowestfee)
                                        {
                                            leftnightfee = nightlowestfee;
                                        }
                                        decimal leftmoney = leftnightfee + leftdayfee;
                                        #endregion
                                        sumMoney = sumdaymoney + leftmoney;


                                    }
                                    else
                                    {
                                        #region 停车整天数收费额金
                                        //停车整天数
                                        int parkdays = parkTime / 1440;
                                        //剩余停车分钟数
                                        int parkminutes = parkTime - 1440 * parkdays;
                                        TimeSpan dayspan = nightstarttime - daystarttime;
                                        //整天白天段停车分钟数
                                        int daytime = int.Parse(dayspan.TotalMinutes.ToString());
                                        //整天夜间段停车分钟数
                                        int nighttime = 1440 - daytime;
                                        //整天白天段停车费用
                                        dayparkfee = Decimal.Parse(Math.Ceiling(daytime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                        //整天夜间段停车费用
                                        nightparkfee = Decimal.Parse(Math.Ceiling(nighttime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                        if (dayparkfee > daytopfee)
                                        {
                                            dayparkfee = daytopfee;
                                        }
                                        if (dayparkfee < daylowestfee)
                                        {
                                            dayparkfee = daylowestfee;
                                        }
                                        if (nightparkfee > nighttopfee)
                                        {
                                            nightparkfee = nighttopfee;
                                        }
                                        if (nightparkfee < nightlowestfee)
                                        {
                                            nightparkfee = nightlowestfee;
                                        }
                                        //停车整天数停车总费用
                                        decimal sumdaymoney = (dayparkfee + nightparkfee) * parkdays;
                                        #endregion
                                        if (outhourminute <= inhourminute)
                                        {
                                            if ((parkminutes % nighttimeunit) > setminute)
                                            {
                                                nightparkfee = Decimal.Parse(Math.Ceiling(parkminutes / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                            }
                                            else
                                            {
                                                nightparkfee = Decimal.Parse(Math.Floor(parkminutes / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                            }

                                            if (nightparkfee > nighttopfee)
                                            {
                                                nightparkfee = nighttopfee;
                                            }
                                            if (nightparkfee < nightlowestfee)
                                            {
                                                nightparkfee = nightlowestfee;
                                            }
                                            sumMoney = sumdaymoney + nightparkfee;
                                        }
                                        else
                                        {
                                            //白天段停车时间
                                            int dayparktime = daytime;
                                            //夜间段停车时间
                                            int nightparktime = parkTime - daytime;
                                            if ((nightparktime % nighttimeunit) > setminute)
                                            {
                                                nightparkfee = Decimal.Parse(Math.Ceiling(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                            }
                                            else
                                            {
                                                nightparkfee = Decimal.Parse(Math.Floor(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                            }
                                            if ((dayparktime % daytimeunit) > setminute)
                                            {
                                                dayparkfee = Decimal.Parse(Math.Ceiling(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                            }
                                            else
                                            {
                                                dayparkfee = Decimal.Parse(Math.Floor(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                            }


                                            if (dayparkfee > daytopfee)
                                            {
                                                dayparkfee = daytopfee;
                                            }
                                            if (dayparkfee < daylowestfee)
                                            {
                                                dayparkfee = daylowestfee;
                                            }
                                            if (nightparkfee > nighttopfee)
                                            {
                                                nightparkfee = nighttopfee;
                                            }
                                            if (nightparkfee < nightlowestfee)
                                            {
                                                nightparkfee = nightlowestfee;
                                            }
                                            sumMoney = sumdaymoney + dayparkfee + nightparkfee;
                                        }
                                    }
                                }

                            }
                            else//进场时间在夜间段，出场时间在白天段（进场场不在同一天，这种情况下，进场时间必定小于白天段开始的时间）
                            {
                                if (parkTime < 1440)
                                {
                                    TimeSpan dayparkspan = outhourminute - daystarttime;
                                    //白天段停车时间
                                    int dayparktime = int.Parse(dayparkspan.TotalMinutes.ToString());
                                    int nightparktime = parkTime - dayparktime;
                                    if ((dayparktime % daytimeunit) > setminute)
                                    {
                                        dayparkfee = Decimal.Parse(Math.Ceiling(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;

                                    }
                                    else
                                    {
                                        dayparkfee = Decimal.Parse(Math.Floor(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                    }
                                    if ((nightparktime % nighttimeunit) > setminute)
                                    {
                                        nightparkfee = Decimal.Parse(Math.Ceiling(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                    }
                                    else
                                    {
                                        nightparkfee = Decimal.Parse(Math.Floor(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                    }

                                    if (dayparkfee > daytopfee)
                                    {
                                        dayparkfee = daytopfee;
                                    }
                                    if (dayparkfee < daylowestfee)
                                    {
                                        dayparkfee = daylowestfee;
                                    }
                                    if (nightparkfee > nighttopfee)
                                    {
                                        nightparkfee = nighttopfee;
                                    }
                                    if (nightparkfee < nightlowestfee)
                                    {
                                        nightparkfee = nightlowestfee;
                                    }
                                    sumMoney = dayparkfee + nightparkfee;
                                }
                                else
                                {
                                    #region 停车整天数收费额金
                                    //停车整天数
                                    int parkdays = parkTime / 1440;
                                    //剩余停车分钟数
                                    int parkminutes = parkTime - 1440 * parkdays;
                                    TimeSpan dayspan = nightstarttime - daystarttime;
                                    //整天白天段停车分钟数
                                    int daytime = int.Parse(dayspan.TotalMinutes.ToString());
                                    //整天夜间段停车分钟数
                                    int nighttime = 1440 - daytime;
                                    //整天白天段停车费用
                                    dayparkfee = Decimal.Parse(Math.Ceiling(daytime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                    //整天夜间段停车费用
                                    nightparkfee = Decimal.Parse(Math.Ceiling(nighttime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                    if (dayparkfee > daytopfee)
                                    {
                                        dayparkfee = daytopfee;
                                    }
                                    if (dayparkfee < daylowestfee)
                                    {
                                        dayparkfee = daylowestfee;
                                    }
                                    if (nightparkfee > nighttopfee)
                                    {
                                        nightparkfee = nighttopfee;
                                    }
                                    if (nightparkfee < nightlowestfee)
                                    {
                                        nightparkfee = nightlowestfee;
                                    }
                                    //停车整天数停车总费用
                                    decimal sumdaymoney = (dayparkfee + nightparkfee) * parkdays;
                                    #endregion

                                    TimeSpan dayparkspan = outhourminute - daystarttime;
                                    //白天段停车时间
                                    int dayparktime = int.Parse(dayparkspan.TotalMinutes.ToString());
                                    int nightparktime = parkminutes - dayparktime;
                                    if ((dayparktime % daytimeunit) > setminute)
                                    {
                                        leftdayfee = Decimal.Parse(Math.Ceiling(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                    }
                                    else
                                    {
                                        leftdayfee = Decimal.Parse(Math.Floor(dayparktime / 1.00 / daytimeunit).ToString()) * dayunitfee;
                                    }
                                    if ((nightparktime % nighttimeunit) > setminute)
                                    {
                                        leftnightfee = Decimal.Parse(Math.Ceiling(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                    }
                                    else
                                    {
                                        leftnightfee = Decimal.Parse(Math.Floor(nightparktime / 1.00 / nighttimeunit).ToString()) * nightunitfee;
                                    }
                                    if (leftdayfee > daytopfee)
                                    {
                                        leftdayfee = daytopfee;
                                    }
                                    if (leftdayfee < daylowestfee)
                                    {
                                        leftdayfee = daylowestfee;
                                    }
                                    if (leftnightfee > nighttopfee)
                                    {
                                        leftnightfee = nighttopfee;
                                    }
                                    if (leftnightfee < nightlowestfee)
                                    {
                                        leftnightfee = nightlowestfee;
                                    }
                                    sumMoney = sumdaymoney + leftdayfee + leftnightfee;
                                }


                            }
                        }

                        return sumMoney;

                    }

                }
                else
                {
                    return sumMoney;
                }
                #endregion

            }
            else
            {
                return sumMoney;
            }

        }

        /// <summary>
        /// 计算时间段的分钟数
        /// </summary>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        private int CaculateMunites(DateTime starttime, DateTime endtime)
        {
            TimeSpan timespan = endtime - starttime;
            int m = int.Parse(timespan.TotalMinutes.ToString("f0"));
            return m;
        }

        /// <summary>
        /// 通过车牌类型获得车辆类型
        /// </summary>
        /// <param name="plateid"></param>
        /// <returns></returns>
        private string GetCarType(int type)
        {
            switch (type)
            {
                case 1:
                    {
                        return "小型车";
                    }
                case 2:
                    {
                        return "小型车";
                    }
                case 3:
                    {
                        return "小型车";
                    }
                case 4:
                    {
                        return "中大型车";
                    }
                case 5:
                    {
                        return "公务车";
                    }
                case 6:
                    {
                        return "公务车";
                    }
                case 7:
                    {
                        return "小型车";
                    }
                case 8:
                    {
                        return "公务车";
                    }
                case 9:
                    {
                        return "公务车";
                    }
                case 10:
                    {
                        return "公务车";
                    }
                case 11:
                    {
                        return "公务车";
                    }
                case 12:
                    {
                        return "中大型车";
                    }
                case 13:
                    {
                        return "小型车";
                    }
                case 14:
                    {
                        return "公务车";
                    }
                case 15:
                    {
                        return "公务车";
                    }
                default:
                    {
                        return "小型车";
                    }
            }
        }

        private CarTypeManager carTypeBLL = new CarTypeManager();
        private CarType carTypeModel = new CarType();
        /// <summary>
        /// 通过车类型得到收费标准实体
        /// </summary>
        /// <param name="carType"></param>
        /// <returns></returns>
        public FeeStandard GetChargeStandardByCarType(string carType)
        {
            DataSet ds = carTypeBLL.GetList("CarTypeName=" + "'" + carType + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                carTypeModel = carTypeBLL.DataTableToList(ds.Tables[0]).First();
            }
            if (carTypeModel != null)
            {
                int id = carTypeModel.ChargeId ?? 0;
                if (id != 0)
                {
                    feeModel = feeBLL.GetModel(id);
                }

            }

            return feeModel;
        }

        /// <summary>
        /// 通过车牌号码获取进场时间
        /// </summary>
        /// <param name="plateid"></param>
        /// <returns></returns>
        public string GetInTime(string plateid)
        {
            DataSet ds = chargeRecordBLL.GetList(1, "plateid=" + "'" + plateid + "'", "InTime");
            if (ds.Tables[0].Rows.Count > 0)
            {
                chargeRecordModel = chargeRecordBLL.DataTableToList(ds.Tables[0]).First();
                if (string.IsNullOrEmpty(chargeRecordModel.OutTime.ToString()))
                {
                    string intime = chargeRecordModel.InTime.ToString() ?? "";
                    return intime;
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }



        }

        /// <summary>
        /// 获取收费记录
        /// </summary>
        /// <param name="plateid"></param>
        /// <returns></returns>
        public ChargeRecord GetRecordModel(string plateid)
        {
            DataSet ds = chargeRecordBLL.GetList(1, "plateid=" + "'" + plateid + "'", "InTime");
            if (ds.Tables[0].Rows.Count > 0)
            {
                chargeRecordModel = chargeRecordBLL.DataTableToList(ds.Tables[0]).First();
                if (string.IsNullOrEmpty(chargeRecordModel.OutTime.ToString()))
                {
                    return chargeRecordModel;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// 判断进入车辆是否是固定客户车辆
        /// </summary>
        /// <returns></returns>
        public FCustomer GetFCustomer(string plateid)
        {
            string strWhere = "PlateId=" + "'" + plateid + "'";
            DataSet ds = fCustomerBLL.GetList(strWhere);
            if (ds.Tables[0].Rows.Count > 0)
            {
                fCustomerModel = fCustomerBLL.DataTableToList(ds.Tables[0]).First();
            }
            else
            {
                fCustomerModel = null;
            }
            return fCustomerModel;
        }

        /// <summary>
        /// 判断识后的车牌是否规范
        /// </summary>
        /// <param name="plateid"></param>
        /// <returns></returns>
        private bool Isplateid(string plateid)
        {
            if ((plateid == "_无_") || (plateid.Length != 7))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 判断固定车是否在有效期内
        /// </summary>
        /// <param name="plateid"></param>
        /// <returns></returns>
        public bool IsValCustomer(string plateid)
        {
            return fCustomerBLL.IsValCustomer(plateid);
        }

        private void bt_jlmx_Click(object sender, EventArgs e)
        {
            //frmMain frmmain ;
            //frmmain = (frmMain)this.Owner;
            //this.WindowState = FormWindowState.Minimized;
            frmInOutInfo frminoutinfo = new frmInOutInfo();
            frminoutinfo.ShowDialog();
            //frmmain.CreateTab(frminoutinfo,"出入记录");
        }
        Settlement settlementModel = new Settlement();
        private SettlementManager settlementBLL = new SettlementManager();
        WebWorkInfo.WorkInfo workInfo = new WebWorkInfo.WorkInfo();

        private void In_axVZLPRClientCtrl_OnLPRSerialRecvData(object sender, AxVZLPRClientCtrlLib._DVZLPRClientCtrlEvents_OnLPRSerialRecvDataEvent e)
        {
           // MessageBox.Show(e.recvData);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            //记住原来的位置，这里是鼠标相对于button1的位置  
            oriPoint1 = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //这个地方记录的是button1对于窗口的位置  
                Point newPos = panel1.Location;
                //适当调整button1的位置  
                newPos.Offset(e.Location.X - oriPoint1.X, e.Location.Y - oriPoint1.Y);
                //保证拖动后控件还在当前窗体的可见范围内  
                if (new Rectangle(0, 0, this.Width, this.Height).Contains(newPos))
                {
                    panel1.Location = newPos;
                }
                else
                {
                    panel1.Location = oriPoint1;
                }
            }
        }



       

        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            string strtitle;
            if (!isWin2)
            {
                if (isWin1)
                {
                
                    groupPanel6.Controls.Clear();
                    groupPanel6.Controls.Add(In_axVZLPRClientCtrl);
                    In_axVZLPRClientCtrl.Dock = DockStyle.Fill;
                    groupPanel6.Controls.Add(panel1);
                    panel1.BringToFront();

                    panel1.Controls.Clear();
                    In_ThreeaxVZLPRClientCtrl.Dock = DockStyle.Bottom;
                    In_ThreeaxVZLPRClientCtrl.Size = new Size(96, 96);
                    panel1.Controls.Add(In_ThreeaxVZLPRClientCtrl);

                    strtitle=lb_ThreeName.Text;
                    lb_ThreeName.Text = groupPanel6.Text;
                    panel1.Controls.Add(lb_ThreeName);
                    groupPanel6.Text = strtitle;
                    lb_ThreeName.BringToFront();

                    In_ThreeaxVZLPRClientCtrl.BringToFront();

                 
                    isWin1 = false;


                }
                else
                {
               
                    groupPanel6.Controls.Clear();
                    groupPanel6.Controls.Add(In_ThreeaxVZLPRClientCtrl);
                    In_ThreeaxVZLPRClientCtrl.Dock = DockStyle.Fill;
                    groupPanel6.Controls.Add(panel1);
                    panel1.BringToFront();

                    panel1.Controls.Clear();
                    In_axVZLPRClientCtrl.Dock = DockStyle.Bottom;
                    In_axVZLPRClientCtrl.Size = new Size(96, 96);
                    panel1.Controls.Add(In_axVZLPRClientCtrl);
                    panel1.Controls.Add(lb_ThreeName);

                    strtitle = lb_ThreeName.Text;
                    lb_ThreeName.Text = groupPanel6.Text;
                    panel1.Controls.Add(lb_ThreeName);
                    groupPanel6.Text = strtitle;
                    lb_ThreeName.BringToFront();


                    In_axVZLPRClientCtrl.BringToFront();
                    
                    isWin1 = true;
                }
                panel2.Controls.Add(In_FouraxVZLPRClientCtrl);
                groupPanel6.Controls.Add(panel2);
                panel2.BringToFront();
                In_FouraxVZLPRClientCtrl.BringToFront();

            } 
         
        }

        WebWorkInfo.Settlement websettlModel = null;
        private void btnOffWork_Click(object sender, EventArgs e)
        {
            OnOffWork();
        }

        /// <summary>
        /// 添加结算信息到服务端
        /// </summary>
        /// <param name="model"></param>
        public void AddWebSettlement(object model)
        {
            Settlement settModel = (Settlement)model;
            //向服务端添加结算信息
            bool isSuccess = true;
            try
            {
                websettlModel = ModelTrans.GetWebSettlModel(settModel);
                isSuccess = workInfo.Add(websettlModel);
            }
            catch (Exception)
            {
                isSuccess = false;
            }
            settModel.IsUpload = isSuccess;
            settlementBLL.Update(settModel);
        }

        /// <summary>
        /// 添加固定客户进出入信息到服务器端
        /// </summary>
        /// <param name="model"></param>
        public void AddWebFInOutInfo(object model)
        {
            www.gzwulian.com.Model.FInOutInfo fInOutModel = (www.gzwulian.com.Model.FInOutInfo)model;
            bool isSuccess = true;
            try
            {
                webFInOutModel = ModelTrans.GetWebFInOutModel(fInOutModel);
                webFInOutInfo.Add(webFInOutModel);
            }
            catch (Exception)
            {
                isSuccess = false;
            }
            fInOutModel.IsUpload = isSuccess;
            fInOutInfoBLL.Update(fInOutModel);
        }

        WebChargeInfo.ChargeRecord webchargeModel = null;
        private WebChargeInfo.ChargeInfo chargeInfo = new WebChargeInfo.ChargeInfo();

        /// <summary>
        /// 添加收费信息到服务器
        /// </summary>
        public void AddWebCharge(object model)
        {
            www.gzwulian.com.Model.ChargeRecord chageModel = (www.gzwulian.com.Model.ChargeRecord)model;
            bool isSuccess = true;
            try
            {
                webchargeModel = ModelTrans.GetWebChargeModel(chageModel);
                chargeInfo.Add(webchargeModel);
            }
                       
            

            catch (Exception)
            {
              //  MessageBox.Show(E.Message);
                isSuccess = false;
            }
            chageModel.IsUpload = isSuccess;
            chargeRecordBLL.Update(chageModel);
        }

        private void IsertInOutInfo(string inouttype, string plateid, DateTime time)
        {
            identifyInfoModel = new PlateIdentifyInfo();
            identifyInfoModel.PlateId = plateid;
            string timetype = string.Empty;
            if (inouttype == "in")
            {
                identifyInfoModel.InTime = time;
                timetype = "InTime";
            }

            else
            {
                identifyInfoModel.OutTime = time;
                timetype = "OutTime";
            }
            identifyInfoModel.OperatorName = LoginInfo.LoginName;
            identifyInfoModel.AddTime = DateTime.Now;
            identifyInfoModel.ParkId = LoginInfo.ParkId;
            identifyInfoModel.CompanyCode = LoginInfo.CompanyCode;
            inoutBLL.Add(identifyInfoModel);
            //上传到服务端
            if(iniinfo.CarinfoUpload=="True")
            {
                ServerData serverData = new ServerData();
                serverData.model = identifyInfoModel;
                serverData.timetype = timetype;
                serverData.time = time;
                Thread th = new Thread(new ThreadStart(serverData.AddWebInOutInfo));
                th.IsBackground = true;
                th.Start();
                //  serverData.AddWebInOutInfo(identifyInfoModel);

            }
        }
        /// <summary>
        /// 上下班
        /// </summary>
        /// 

        private void OnWork()
        {
            LoginInfo.isSettle = true;
            txtOperatorName.Text = LoginInfo.LoginName;
            txtWorkTime.Text = DateTime.Now.ToString("HH:mm:ss");
            operatorMode = operatorBll.GetModel(LoginInfo.Id);
            settlementModel.WorkTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            settlementModel.OperatorName = operatorMode.OperatorName;
            settlementModel.StaffName = operatorMode.RealName;
            settlementModel.AddTime = DateTime.Now;
            settlementModel.ParkId = LoginInfo.ParkId;
            settlementModel.CompanyCode = LoginInfo.CompanyCode;
            settlementBLL.Add(settlementModel);

        }


        private void OnOffWork()
        {

            //下班结算
          
                if (MessageHelper.ConfirmYesNo("您确定要下班结算？"))
                {
                  //  #region 结算
                    DataTable dt = settlementBLL.GetList(1, "OffWorkTime is null", "WorkTime").Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        settlementModel = settlementBLL.DataTableToList(dt).First();
                    }
                    string time = settlementModel.WorkTime.ToString() ?? "";
                    DateTime starttime = Convert.ToDateTime(time);
                    DateTime endtime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    settlementModel.OffWorkTime = endtime;
                    settlementModel.FInCount = fInOutInfoBLL.GetInOrOutCount(starttime, endtime, "InTime");
                    settlementModel.FOutCount = fInOutInfoBLL.GetInOrOutCount(starttime, endtime, "OutTime");
                    settlementModel.InCount = chargeRecordBLL.GetInOrOutCount(starttime, endtime, "InTime");
                    settlementModel.OutCount = chargeRecordBLL.GetInOrOutCount(starttime, endtime, "OutTime");
                    settlementModel.ChargeAmount = chargeRecordBLL.GetCharge(starttime, endtime);
                    bool flag = settlementBLL.Update(settlementModel);
                    bool isSuccess = true;

                if (iniinfo.CarinfoUpload == "True")
                {
                    Thread td = new Thread(new ParameterizedThreadStart(this.AddWebSettlement));
                    td.IsBackground = true;
                    td.Start(settlementModel);
                }

                //向服务端添加结算信息

                //Thread td = new Thread(new ParameterizedThreadStart(this.AddWebSettlement));
                //td.IsBackground = true;
                //td.Start(settlementModel);
                //if (iniinfo.CarinfoUpload == "True")
                //    {
                //        AddWebSettlement(settlementModel);
                //    }
                if (flag)
                    {
                        //   btnOffWork.Text = "结算成功";
                     //   btnOffWork.Text = "下班结算";
                        MessageHelper.ShowTips("下班结算成功！");
                        this.TopMost = false;
                        LoginInfo.isSettle = false;
                    
                        frmLogin frmlogin = new frmLogin();
                        frmlogin.ShowDialog();
                    if (frmlogin.DialogResult == DialogResult.OK)
                    {
                        txtOperatorName.Text = LoginInfo.LoginName;
                        txtWorkTime.Text = DateTime.Now.ToString("HH:mm:ss");
                        operatorMode = operatorBll.GetModel(LoginInfo.Id);
                        settlementModel.WorkTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        settlementModel.OperatorName = operatorMode.OperatorName;
                        settlementModel.StaffName = operatorMode.RealName;
                        settlementModel.AddTime = DateTime.Now;
                        settlementModel.ParkId = LoginInfo.ParkId;
                        settlementModel.CompanyCode = LoginInfo.CompanyCode;
                        settlementBLL.Add(settlementModel);
                        LoginInfo.isSettle = true;
                        SetRights();
                        

                    }
                    else
                    {
                        if (OnelprHandle > 0)
                        {
                            In_axVZLPRClientCtrl.VzLPRClientClose(OnelprHandle);
                        }
                        if (TwolprHandle > 0)
                        {
                            Out_axVZLPRClientCtrl.VzLPRClientClose(TwolprHandle);
                        }
                        if (ThreelprHandle > 0)
                        {
                            In_ThreeaxVZLPRClientCtrl.VzLPRClientClose(ThreelprHandle);
                        }
                        if (FourlprHandle > 0)
                        {
                            In_FouraxVZLPRClientCtrl.VzLPRClientClose(FourlprHandle);
                        }

                    }

                }
                    else
                    {
                        MessageHelper.ShowTips("下班结算失败！");
                        Application.Exit();

                    }
                    #endregion
                }

            




            //if (btnOffWork.Text == "开始上班")
            //{
            //    btnOffWork.Text = "下班结算";
            //    txtOperatorName.Text = LoginInfo.LoginName;
            //    txtWorkTime.Text = DateTime.Now.ToString("HH:mm:ss");
            //    operatorMode = operatorBll.GetModel(LoginInfo.Id);
            //    settlementModel.WorkTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            //    settlementModel.OperatorName = operatorMode.OperatorName;
            //    settlementModel.StaffName = operatorMode.RealName;
            //    settlementModel.AddTime = DateTime.Now;
            //    settlementModel.ParkId = LoginInfo.ParkId;
            //    settlementModel.CompanyCode = LoginInfo.CompanyCode;
            //    settlementBLL.Add(settlementModel);
            //}
            ////下班结算
            //else if (btnOffWork.Text == "下班结算")
            //{
            //    if (MessageHelper.ConfirmYesNo("您确定要下班结算？"))
            //    {
            //        #region 结算
            //        DataTable dt = settlementBLL.GetList(1, "OffWorkTime is null", "WorkTime").Tables[0];
            //        if (dt.Rows.Count > 0)
            //        {
            //            settlementModel = settlementBLL.DataTableToList(dt).First();
            //        }
            //        string time = settlementModel.WorkTime.ToString() ?? "";
            //        DateTime starttime = Convert.ToDateTime(time);
            //        DateTime endtime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            //        settlementModel.OffWorkTime = endtime;
            //        settlementModel.FInCount = fInOutInfoBLL.GetInOrOutCount(starttime, endtime, "InTime");
            //        settlementModel.FOutCount = fInOutInfoBLL.GetInOrOutCount(starttime, endtime, "OutTime");
            //        settlementModel.InCount = chargeRecordBLL.GetInOrOutCount(starttime, endtime, "InTime");
            //        settlementModel.OutCount = chargeRecordBLL.GetInOrOutCount(starttime, endtime, "OutTime");
            //        settlementModel.ChargeAmount = chargeRecordBLL.GetCharge(starttime, endtime);
            //        bool flag = settlementBLL.Update(settlementModel);
            //        bool isSuccess = true;
            //        //向服务端添加结算信息

            //        //Thread td = new Thread(new ParameterizedThreadStart(this.AddWebSettlement));
            //        //td.IsBackground = true;
            //        //td.Start(settlementModel);
            //        if(iniinfo.CarinfoUpload == "True")
            //        { 
            //            AddWebSettlement(settlementModel);
            //        }
            //        if (flag)
            //        {
            //            //   btnOffWork.Text = "结算成功";
            //            btnOffWork.Text = "下班结算";
            //            MessageHelper.ShowTips("下班结算成功！");
            //            LoginInfo.isoneLogin = false;
            //            frmLogin frmlogin = new frmLogin();
            //            frmlogin.ShowDialog();

            //            // this.Close();
            //            // Environment.Exit(0);
            //          //  Application.Exit();
            //          //  Application.Restart();
            //        }
            //        else
            //        {
            //            MessageHelper.ShowTips("下班结算失败！");
            //            Application.Exit();

            //        }
            //        #endregion
            //    }

            //}
            //else
            //{
            //    MessageHelper.ShowTips("请重新登录！");
            //}
        }
        /// <summary>
        /// 显示进出记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInOutInfo_Click(object sender, EventArgs e)
        {
            frmFInOutInfo frminoutinfo = new frmFInOutInfo();
            frminoutinfo.TopMost = true;
            frminoutinfo.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (iniinfo.IsExistByPwd == "True")
            {
                frmConfirm frmconfirm = new frmConfirm();
                DialogResult dr = frmconfirm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    In_axVZLPRClientCtrl.VzLPRClientStopPlay(0);
                    //  In_axVZLPRClientCtrl.VzLPRClientClose(OnelprHandle);
                    Out_axVZLPRClientCtrl.VzLPRClientStopPlay(0);
                    //    Out_axVZLPRClientCtrl.VzLPRClientClose(TwolprHandle);
                    //终止显示线程
                    this.DialogResult = DialogResult.OK;
                  
                    pth.Abort();
                    Hide();
                   // Close();
                }

            }
            else
            {
 //               In_axVZLPRClientCtrl.VzLPRClientStopPlay(0);
                //   In_axVZLPRClientCtrl.VzLPRClientClose(OnelprHandle);
 //               Out_axVZLPRClientCtrl.VzLPRClientStopPlay(0);
                //   Out_axVZLPRClientCtrl.VzLPRClientClose(TwolprHandle);
                //终止显示线程
                pth.Abort();
                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
        }

        private void ZXJK_SizeChanged(object sender, EventArgs e)
        {
            AutoSizeForm.controlAutoSize(this);
        }

        private void btnInTrigger_Click(object sender, EventArgs e)
        {
            if (!isWin1 && !isWin2)
            {
                In_axVZLPRClientCtrl.VzLPRClientForceTrigger(0);
            }
            if (isWin1) {
                In_ThreeaxVZLPRClientCtrl.VzLPRClientForceTrigger(0);
            }
            if(isWin2)
            {
                In_FouraxVZLPRClientCtrl.VzLPRClientForceTrigger(0);

            }


        }

        private void btnOutTrigger_Click(object sender, EventArgs e)
        {
            if (isWin3)
            {
                Out_FiveaxVZLPRClientCtrl.VzLPRClientForceTrigger(0);
            }
            else
            { 
               Out_axVZLPRClientCtrl.VzLPRClientForceTrigger(0);
            }
        }

        private void btnOutCard_Click(object sender, EventArgs e)
        {
            frmManualFee frmmanualfee = new frmManualFee(Out_axVZLPRClientCtrl.Name);
            frmmanualfee.Owner = this;
            frmmanualfee.ShowDialog();
            if (frmmanualfee.DialogResult == DialogResult.OK)
            {
                string meg = string.Empty;
                if (frmmanualfee.Tag == "1")
                {
                    meg = "车牌" + frmmanualfee.PlateId;
                    lblOutPlateId.Text = frmmanualfee.PlateId;
                }
                else
                {
                    meg = "卡号" + frmmanualfee.CardCode;
                    lblOutPlateId.Text = frmmanualfee.CardCode;
                    lbId.Text = "刷卡卡号";
                }
                OpenOutDaozha();
                ShowInfo(meg + ";车主类型:" + frmmanualfee.CType + ";出场时间:" + frmmanualfee.OutTime.ToString("HH:mm:ss"));
                //出场信息
                BindOutInfo(cameraTwoType, frmmanualfee.OutTime.ToString("HH:mm:ss"), frmmanualfee.CarType, frmmanualfee.CType, lblOutPlateId.Text);
                //刷新泊位数量
                if (frmmanualfee.CType == CustomerConst.Customer)
                {
                    RefreshCount(CustomerConst.Customer, CustomerConst.PlusOperate);
                }
                //RefreshParkInfo();
                //刷新最新收费信息
                if (frmmanualfee.CType == CustomerConst.Customer)
                {
                    //播报车位数
                    PlayBerth();
                }
                RefreshChargeInfo();
                IsertInOutInfo("out", lblOutPlateId.Text, frmmanualfee.OutTime);
            }
        }

        private void btnInCard_Click(object sender, EventArgs e)
        {

            frmTest frmtest = new frmTest();
            frmtest.Owner = this;
            frmtest.ShowDialog();
        }


        public void InInputPalte(string ImgPath, string Color,string inName)
        {

            string tips; //提示信息
            DateTime intime = DateTime.Now;
            string custype = string.Empty;
            string cartype = string.Empty;
            string info = string.Empty;
            int overday = iniinfo.OverDay;

            MessageHelper.ShowTips("识别未完成，请手动输入车牌号或刷卡进场！");
            frmCard frmcard = new frmCard(inimgpath);
            frmcard.Owner = this;
            DialogResult dr = frmcard.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string meg = "";
                string plateid = string.Empty;
                if (frmcard.Tag == "1")
                {
                    meg = "车牌" + frmcard.PalteId;
                    plateid = frmcard.PalteId;
                }
                //else
                //{
                //    meg = "卡号" + frmcard.CardCode;
                //    lb_hm.Text = "刷卡卡号";
                //    plateid = frmcard.CardCode;
                //}
                custype = CustomerConst.FCustomer;
                cartype = frmcard.CarType;
                info = "车牌" + plateid + ";车主类型:" + "{0}" + ";入场时间:" + frmcard.InTime.ToString("HH:mm:ss");


                //刷新泊位数量
                if (frmcard.CType == CustomerConst.Customer || frmcard.CType == CustomerConst.InCustomer)
                {
                    switch(inName)
                    {
                        case "One":
                            OpenInDaozha();
                            InPlay(plateid, plateid + "," + content);
                            break;
                        case "Two":
                            OpenOutDaozha();
                            OutPlay(plateid, plateid + "," + content);
                            break;
                        case "Three":
                            OpenThreeDaozha();
                            ThreePlay(plateid, plateid + "," + content);
                            break;
                        case "Four":
                            OpenFourDaozha();
                            FourPlay(plateid, plateid + "," + content);
                            break;
                    }
                   
                    ShowInfo(meg + ";车主类型:" + frmcard.CType + ";入场时间:" + frmcard.InTime.ToString("HH:mm:ss"));
                    //进场场信息
                    BindInInfo(cameraOneType, intime.ToString("HH:mm:ss"), frmcard.CarType, frmcard.CType, plateid);
                    InsertChargeRecord(plateid, cartype, intime, ImgPath, frmcard.CType, "");
                    if (frmcard.CType == CustomerConst.InCustomer)
                    {
                        //插入临停车出入记录表
                        InsertFCustomerInfo(plateid, Color, intime, ImgPath, "", "内部车辆", "in");
                    }
                    else
                    {
                        RefreshCount(CustomerConst.Customer, CustomerConst.SubOperate);
                        //插入临停车出入记录表
                        InsertFCustomerInfo(plateid, Color, intime, ImgPath, "", "临停车辆", "in");
                    }
                    //显示车位
                    PlayBerth();

                }
                else
                {
                    if (frmcard.CType == CustomerConst.OFCustomer)
                    {
                        string time = string.Empty;
                       // #region 过期固定客户收费

                        if (iniinfo.IsFCustomerFee == "True")
                        {
                            fCustomerModel = GetFCustomer(plateid);
                            if (fCustomerModel != null)
                            {
                                time = fCustomerModel.OverTime.ToString();
                                if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(time)) > 0)
                                {
                                    TimeSpan timespan = DateTime.Now - Convert.ToDateTime(time);
                                    string overtime = ((int)timespan.TotalDays).ToString();
                                    //播报
                                    switch (inName)
                                    {
                                        case "One":
                                            OpenInDaozha();
                                            InPlay(plateid, plateid + "," + "欢迎光临,已过期,请交费!");
                                            break;
                                        case "Two":
                                            OpenOutDaozha();
                                            OutPlay(plateid, plateid + "," + "欢迎光临,已过期,请交费!");
                                            break;
                                        case "Three":
                                            OpenThreeDaozha();
                                            ThreePlay(plateid, plateid + "," + "欢迎光临,已过期,请交费!");
                                            break;
                                        case "Four":
                                            OpenFourDaozha();
                                            FourPlay(plateid, plateid + "," + "欢迎光临,已过期,请交费!");
                                            break;
                                    }



                                   // InPlay(plateid, plateid + "," + "欢迎光临,已过期,请交费!");
                                }
                                else
                                {
                                    //播报
                                    switch (inName)
                                    {
                                        case "One":
                                            OpenInDaozha();
                                            InPlay(plateid, plateid + "," + content);
                                            break;
                                        case "Two":
                                            OpenOutDaozha();
                                            OutPlay(plateid, plateid + "," + content);
                                            break;
                                        case "Three":
                                            OpenThreeDaozha();
                                            ThreePlay(plateid, plateid + "," + content);
                                            break;
                                        case "Four":
                                            OpenFourDaozha();
                                            FourPlay(plateid, plateid + "," + content);
                                            break;
                                    }


                                }
                                custype = CustomerConst.OFCustomer;
                                ShowInfo(string.Format(info, custype));
                                //插入固定车出入记录表
                                InsertFCustomerInfo(plateid, Color, intime, ImgPath, "", "固定车辆", "in");
                                //插入临时车辆收费记录表
                                InsertChargeRecord(plateid, cartype, intime, ImgPath, custype, "");
                                //进场场信息
                                BindInInfo(cameraOneType, intime.ToString("HH:mm:ss"), cartype, custype, plateid);
                                //刷新泊位数量
                                RefreshCount(CustomerConst.FCustomer, CustomerConst.SubOperate);
                                //RefreshParkInfo();
                                //显示车位
                                PlayBerth();

                            }

                        }
                        #endregion
                      //  #region 过期固定客户提示过期，不收费

                        else
                        {
                            time = fCustomerModel.OverTime.ToString();
                            if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(time)) > 0)
                            {
                                TimeSpan timespan = DateTime.Now - Convert.ToDateTime(time);
                                string overtime = ((int)timespan.TotalDays).ToString();
                                tips = "欢迎光临，已过期,请交费!";
                                //播报
                                switch (inName)
                                {
                                    case "One":
                                        OpenInDaozha();
                                        InPlay(plateid, plateid + "," + content);
                                        break;
                                    case "Two":
                                        OpenOutDaozha();
                                        OutPlay(plateid, plateid + "," + content);
                                        break;
                                    case "Three":
                                        OpenThreeDaozha();
                                        ThreePlay(plateid, plateid + "," + content);
                                        break;
                                    case "Four":
                                        OpenFourDaozha();
                                        FourPlay(plateid, plateid + "," + content);
                                        break;
                                }





                               // InPlay(plateid, plateid + "," + tips);
                            }
                          //  OpenInDaozha();
                            custype = CustomerConst.OFCustomer;

                            //如果是一户多车，已有车辆入场，另一个需同时插入收费信息表
                            if (str_MoveCar != "-1")
                            {

                                if (IsMoveCar(plateid))
                                {
                                    custype = "一户多车";
                                    InsertChargeRecord(plateid, cartype, intime, ImgPath, custype, "");
                                }
                            }

                            ShowInfo(string.Format(info, custype));
                            //插入固定车出入记录表
                            InsertFCustomerInfo(plateid, Color, intime, ImgPath, "", "固定车辆", "in");
                            //进场场信息

                            BindInInfo(cameraOneType, intime.ToString("HH:mm:ss"), cartype, custype, plateid);
                            //刷新泊位数量
                            RefreshCount(CustomerConst.FCustomer, CustomerConst.SubOperate);
                            //RefreshParkInfo();
                            //显示车位
                           PlayBerth();
                        }

                        #endregion
                    }
                    else
                    {
                        //如果是一户多车，已有车辆入场，另一个需同时插入收费信息表
                        if (str_MoveCar != "-1")
                        {

                            if (IsMoveCar(plateid))
                            {
                                custype = "一户多车";
                                InsertChargeRecord(plateid, cartype, intime, ImgPath, custype, "");
                            }
                        }

                        string time = fCustomerModel.OverTime.ToString();
                        TimeSpan timespan = Convert.ToDateTime(time) - DateTime.Now;
                        string lefttime = ((int)timespan.TotalDays).ToString();
                        if (Convert.ToInt32(lefttime) <= overday)
                        {
                            //播报
                            switch (inName)
                            {
                                case "One":
                                    OpenInDaozha();
                                    InPlay(plateid, "欢迎光临," + plateid + ",剩余" + lefttime + "天。");
                                    break;
                                case "Two":
                                    OpenOutDaozha();
                                    OutPlay(plateid, "欢迎光临," + plateid + ",剩余" + lefttime + "天。");
                                    break;
                                case "Three":
                                    OpenThreeDaozha();
                                    ThreePlay(plateid, "欢迎光临," + plateid + ",剩余" + lefttime + "天。");
                                    break;
                                case "Four":
                                    OpenFourDaozha();
                                    FourPlay(plateid, "欢迎光临," + plateid + ",剩余" + lefttime + "天。");
                                    break;
                            }




                          
                        }
                        else
                        {
                            //播报
                            switch (inName)
                            {
                                case "One":
                                    OpenInDaozha();
                                    InPlay(plateid, plateid + "," + content);
                                    break;
                                case "Two":
                                    OpenOutDaozha();
                                    OutPlay(plateid, plateid + "," + content);
                                    break;
                                case "Three":
                                    OpenThreeDaozha();
                                    ThreePlay(plateid, plateid + "," + content);
                                    break;
                                case "Four":
                                    OpenFourDaozha();
                                    FourPlay(plateid, plateid + "," + content);
                                    break;
                            }
                           
                        }
                     //   OpenInDaozha();

                        ShowInfo(string.Format(info, custype));
                        //进场场信息
                        BindInInfo(cameraOneType, intime.ToString("HH:mm:ss"), cartype, custype, plateid);
                        //插入固定车出入记录表
                        InsertFCustomerInfo(plateid, Color, intime, ImgPath, "", "固定车辆", "in");

                        //刷新泊位数量
                        RefreshCount(CustomerConst.FCustomer, CustomerConst.SubOperate);
                        //RefreshParkInfo();
                        //显示车位
                         PlayBerth();
                    }

                }
            }


        }

        public void InputPalteCharge(string imgPath, string Color)
        {

            DateTime outtime = DateTime.Now;
            string info = string.Empty;
            string custype = string.Empty;
            string cartype = string.Empty;
            string outcontent = "一路平安";

            frmManualFee frmmanualfee = new frmManualFee(Out_axVZLPRClientCtrl.Name);
            frmmanualfee.Owner = this;
            if (MessageHelper.ConfirmYesNo("未能识别，请点击【是】手动收费？"))
            {
                frmmanualfee.ShowDialog();
            }
            else
            {
                return;
            }
            if (frmmanualfee.DialogResult == DialogResult.OK)
            {
                OpenOutDaozha();
             //   OutPlay(frmmanualfee.PlateId, frmmanualfee.PlateId+","+ outcontent.ToString());
                string meg = string.Empty;

                if (frmmanualfee.Tag == "1")
                {
                    meg = "车牌" + frmmanualfee.PlateId;
                    lblOutPlateId.Text = frmmanualfee.PlateId;
                }
                //else
                //{
                //    meg = "卡号" + frmmanualfee.CardCode;
                //    lblOutPlateId.Text = frmmanualfee.CardCode;
                //    lbId.Text = "刷卡卡号:";
                //}
                ShowInfo(meg + ";车主类型:" + frmmanualfee.CType + ";出场时间:" + frmmanualfee.OutTime.ToString("HH:mm:ss"));
                //出场信息
                BindOutInfo(cameraTwoType, frmmanualfee.OutTime.ToString("HH:mm:ss"), frmmanualfee.CarType, frmmanualfee.CType,
                             lblOutPlateId.Text);

                //刷新最新收费信息
                RefreshChargeInfo();
                if (frmmanualfee.CType == CustomerConst.Customer)
                {
                    //刷新泊位数量
                    RefreshCount(CustomerConst.Customer, CustomerConst.PlusOperate);
                    //插入车辆出入记录表
                    InsertFCustomerInfo(lblOutPlateId.Text, Color, frmmanualfee.OutTime, "", imgPath, "临停车辆",
                                        "out");
                }
                else
                {

                    InsertFCustomerInfo(lblOutPlateId.Text, Color, frmmanualfee.OutTime, "", imgPath, frmmanualfee.CType,
                                      "out");

                }

                //播报车位数
                PlayBerth();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            InInputPalte("", "","");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InputPalteCharge("", "");
        }


        public ChargeRecord GetChargeModeByPlateId(string plateid)
        {
            DataSet ds = chargeRecordBLL.GetList(1, "PlateId=" + "'" + plateid + "'", "InTime");
            if (ds.Tables[0].Rows.Count > 0)
            {
                chargeRecordModel = chargeRecordBLL.DataTableToList(ds.Tables[0]).First();
                if (!string.IsNullOrEmpty(chargeRecordModel.OutTime.ToString()))
                {
                    chargeRecordModel = null;
                }
            }
            else
            {
                chargeRecordModel = null;
            }
            return chargeRecordModel;

        }


        public bool ReadiniFree()
        {
            
            try
            {
                INIFile ini = new INIFile(Application.StartupPath + "\\Config\\SysFree.ini");
                if (ini != null)
                {
                    for (int i = 0; i < 20; i++)
                    { 
                        if (ini.IniReadValue("SysFree", "Text" + i.ToString()) != "")
                        {
                            strReason= strReason + ini.IniReadValue("SysFree", "Text" + i.ToString()) + ",";
                        }
                  }
                    
                }
                return true;
            }
            catch
            {
                return false;

            }

        }

        private void butCarData_Click(object sender, EventArgs e)
        {
            frmFCustomer frmfcustomer = new frmFCustomer();
            frmfcustomer.TopMost = true;
            frmfcustomer.ShowDialog();
        }
     
    }

}
#endregion