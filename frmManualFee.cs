using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using www.gzwulian.com.BLL;
using www.gzwulian.com.Common;
using www.gzwulian.com.Model;
using System.Threading;
namespace ChargeWin
{
    public partial class frmManualFee : Form
    {
        public frmManualFee(string inoutname)
        {
            this.InOutName = inoutname;
            InitializeComponent();
        }
        ZXJK frmzxjk;
        private ChargeRecord chargeRecordModel = null;
        private ChargeRecordManager chargeRecordBLL = new ChargeRecordManager();
        INIMag iniinfo = new INIMag(GlobalInfo.Instance.ConfigPath);
        public string SumMoney { get; set; }
        public string FeeType { get; set; }
        public string FreeReason { get; set; }
        public string OutImgPath { get; set; }
        public string CusType { get; set; }

        /// <summary>
        /// 标识
        /// </summary>
        public string Tag { get; set; }
        /// <summary>
        /// 出场时间
        /// </summary>
        public DateTime OutTime { get; set; }
        /// <summary>
        /// 车主类型
        /// </summary>
        public string CType { get; set; }
        /// <summary>
        /// 车辆类型
        /// </summary>
        public string CarType { get; set; }
        /// <summary>
        /// 车牌号码
        /// </summary>
        public string PlateId { get; set; }
        /// <summary>
        /// 卡号码
        /// </summary>
        public string CardCode { get; set; }
        public string InOutName { get; set; }
        string configpath = Application.StartupPath + "\\Config\\SysCon.ini";
        INIFile ini = null;
        private string outCOMPort = string.Empty;
        private void frmManualFee_Load(object sender, EventArgs e)
        {
            frmzxjk = (ZXJK)this.Owner;
            txtPlateId.TabIndex = 0;
            //调整输入车牌优先2016.7.20jyb 
            txtPlateId.Focus();
            rdPlateId.Checked = true;
            //txtCardCode.Focus();
            //rdCardCode.Checked = true;
            //rdPlateId.Checked = true;
            //txtPlateId.Focus();
            ini = new INIFile(configpath);

        }
        public struct CustomerConst
        {
            public const string Customer = "临停客户";
            public const string FCustomer = "固定客户";
            public const string OFCustomer = "过期客户";
            public const string InCustomer = "内部客户";
            public const string PlusOperate = "PlusOperate";
            public const string SubOperate = "SubOperate";
        }
        private void bt_cksb_Click(object sender, EventArgs e)
        {
            if (chargeRecordModel != null)
            {
                if (string.IsNullOrWhiteSpace(lbFeeStandard.Text) || string.IsNullOrWhiteSpace(lbInTime.Text) || string.IsNullOrWhiteSpace(lbSumMoney.Text))
                {
                    MessageHelper.ShowWarning("请读取收费信息");
                    return;
                }
                if (rdPlateId.Checked == true)
                {
                    if (string.IsNullOrWhiteSpace(txtPlateId.Text))
                    {
                        MessageHelper.ShowTips("请输入车牌号！");
                        this.DialogResult = DialogResult.None;
                        return;
                    }
                    else
                    {
                        this.Tag = "1";
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(txtCardCode.Text))
                    {
                        MessageHelper.ShowTips("请刷卡进场！");
                        this.DialogResult = DialogResult.None;
                        return;
                    }
                    else
                    {
                        this.Tag = "0";
                    }
                }
                chargeRecordModel.OutTime = Convert.ToDateTime(lbOutTime.Text);
                this.OutTime = Convert.ToDateTime(lbOutTime.Text);
                this.CarType = lbCarType.Text;
                this.CType = txtCType.Text;
                this.CardCode = txtCardCode.Text;
                this.PlateId = txtPlateId.Text;

                chargeRecordModel.ParkTime = lbParkTime.Text;

                if (string.IsNullOrWhiteSpace(cbReason.Text))
                {
                    MessageHelper.ShowTips("免费原因不能为空！");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                chargeRecordModel.FreeReason = cbReason.Text;
                if (!string.IsNullOrWhiteSpace(lbSumMoney.Text))
                {
                    chargeRecordModel.SumMoney = 0;
                }


                if (iniinfo.IsOutSelectFreeFee == "True")
                {
                    if (!string.IsNullOrWhiteSpace(cbReason.Text))
                    {
                        if (chargeRecordBLL.Update(chargeRecordModel))
                        {

                            frmzxjk.AddWebCharge(chargeRecordModel);
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageHelper.ShowTips("操作失败！");
                            this.DialogResult = DialogResult.None;
                        }
                    }
                    else
                    {
                        MessageHelper.ShowTips("免费原因不能为空！");
                        this.DialogResult = DialogResult.None;
                    }

                }
                else
                {
                    MessageHelper.ShowTips("临时车出场不能免费！");
                    this.DialogResult = DialogResult.None;
                }


            }
        }

        private string inpath = string.Empty;
        private void btnFeeInfo_Click(object sender, EventArgs e)
        {

            string tip = string.Empty;
            string cartype = string.Empty;
            string time = string.Empty;
            DateTime intime;
            DateTime outtime = DateTime.Now;
            string parktime = string.Empty;
            decimal summoney = 0;
            string plateid = string.Empty;
            bool isincar = frmzxjk.IsInnerCar(txtPlateId.Text);
            frmzxjk = (ZXJK)this.Owner;

            if (string.IsNullOrWhiteSpace(txtPlateId.Text))
            {
                MessageHelper.ShowTips("请输入车牌号！");
                return;
            }
            else
            {
                plateid = txtPlateId.Text.Trim();

            }

            if (frmzxjk.GetFCustomer(plateid) != null && !isincar)
            {
                if (frmzxjk.IsValCustomer(plateid))
                {
                    this.CType = CustomerConst.FCustomer;
                    //1、先要判断是否未交缴信息，需交缴，没有，正常出场。
                    //2、需判断是否为多车车主，如是并有第二车辆车进入，即把第二辆去结算，并再次与固定车名义进入。
                    //
                    if (frmzxjk.str_MoveCar != "-1")//如果没有启用一户多车模式，则不执行。
                    {

                        //在启用一户多车时，如果是没有收费信息，自动视为车租车。
                        //否则，找查找收费信息，并计算费用。

                        if (string.IsNullOrEmpty(frmzxjk.GetInTime(plateid)))
                        {
                            this.CarType = "小型车";
                            this.Tag = "1";
                            this.PlateId = txtPlateId.Text;
                            this.OutTime = DateTime.Now;
                            //得到一户多车中有一辆进入，另一辆进入之后在待收费记录中的车牌号；
                            //第一辆车驶出，第二辆自动变为业主车 str_MoveCar == "1" 
                            if (frmzxjk.str_MoveCar == "1")
                            {

                                string getMovePlateId;
                                getMovePlateId = frmzxjk.GetMoveCarPlateId(plateid).Trim();//得到本户下未交费车辆信息

                                chargeRecordModel = frmzxjk.GetChargeModeByPlateId(getMovePlateId);
                                if (chargeRecordModel != null)
                                {

                                    time = chargeRecordModel.InTime.ToString();
                                    intime = Convert.ToDateTime(time);
                                    cartype = chargeRecordModel.CarType;
                                    summoney = frmzxjk.CalulateFee(intime, cartype);
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
                                    // this.CType = chargeRecordModel.CusType;
                                    this.PlateId = getMovePlateId.Trim();
                                    this.CType = "一户多车";
                                    txtCType.Text = chargeRecordModel.CusType;
                                    lbFeeStandard.Text = chargeRecordModel.FeeStandard;
                                    txtPlateId.Text = getMovePlateId;
                                    lbInTime.Text = time;
                                    lbOutTime.Text = outtime.ToString();
                                    lbCarType.Text = cartype;
                                    lbParkTime.Text = parktime;
                                    lbSumMoney.Text = summoney.ToString("f0");
                                    inpath = chargeRecordModel.InImgPath;

                                    //chargeRecordModel.SumMoney = summoney;
                                    //chargeRecordModel.OutTime = outtime;
                                    //chargeRecordModel.CarType = cartype;
                                    //chargeRecordModel.CardCode = "0";
                                    //chargeRecordModel.ParkTime = parktime;

                                    //更新数据库
                                    //1、更新收费记录表
                                    //2、固定车出场
                                    //3、回定车入场
                                    //4、如果设置第二次始终为临停车，则不进行结算操作

                                    frmzxjk.InsertFCustomerInfo(getMovePlateId, "", outtime, inpath, "", cartype, "out");
                                    frmzxjk.InsertFCustomerInfo(getMovePlateId, "", outtime, "", inpath, cartype, "in");


                                    //if (chargeRecordBLL.Update(chargeRecordModel))
                                    //{
                                    //    Thread th = new Thread(new ParameterizedThreadStart(frmzxjk.AddWebCharge));
                                    //    th.IsBackground = true;
                                    //    th.Start(chargeRecordModel);

                                    //    //   chargeRecordBLL.Update(chargeRecordModel);

                                    //}
                                    if (!string.IsNullOrEmpty(inpath))
                                    {
                                        try
                                        {
                                            picIn.Image = Image.FromFile(inpath);
                                        }
                                        catch (Exception ex)
                                        {


                                        }


                                    }


                                    this.CarType = "小型车";
                                    this.Tag = "1";
                                    this.PlateId = txtPlateId.Text;
                                    this.OutTime = DateTime.Now;
                                    this.CType = txtCType.Text;


                                    //string speechtxt = plateid + "|" + plateid + ",停车" + parktime + ",收费" + lbSumMoney.Text + "元";
                                    string speechtxt = plateid.Trim() + ",停车" + parktime + ",收费" + lbSumMoney.Text + "元";
                                    if (InOutName == "In_axVZLPRClientCtrl")
                                    {
                                        frmzxjk.InPlay(plateid, speechtxt);
                                    }
                                    else
                                    {
                                        frmzxjk.OutPlay(plateid, speechtxt);

                                    }

                                }
                                else
                                {
                                    if (InOutName == "In_axVZLPRClientCtrl")
                                    {
                                        frmzxjk.InPlay(plateid, plateid + ",一路平安。");
                                    }
                                    else
                                    {
                                        frmzxjk.OutPlay(plateid, plateid + ",一路平安。");

                                    }
                                    if (MessageHelper.ConfirmYesNo("该车辆为固定车辆，点击确定放行"))
                                    {
                                        this.DialogResult = DialogResult.OK;
                                    }

                                }
                            }
                            else
                            {
                                if (InOutName == "In_axVZLPRClientCtrl")
                                {
                                    frmzxjk.InPlay(plateid, plateid + ",一路平安。");
                                }
                                else
                                {
                                    frmzxjk.OutPlay(plateid, plateid + ",一路平安。");

                                }
                                if (MessageHelper.ConfirmYesNo("该车辆为固定车辆，点击确定放行"))
                                {
                                    this.DialogResult = DialogResult.OK;
                                }
                            }
                           
                        }

                        //先进为业主车，后进为临停车  str_MoveCar == "0" 
                       if(frmzxjk.str_MoveCar=="0")
                        {
                            time = frmzxjk.GetInTime(plateid);
                            if (string.IsNullOrEmpty(time))
                            {
                                intime = Convert.ToDateTime(time);
                                summoney = frmzxjk.CalulateFee(intime, cartype);
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

                            }
                           
                            if (iniinfo.AutoOpen == "True" && summoney == 0)
                            {
                                if (InOutName == "In_axVZLPRClientCtrl")
                                {
                                    frmzxjk.InPlay(plateid, plateid + ",一路平安。");
                                }
                                else
                                {
                                    frmzxjk.OutPlay(plateid, plateid + ",一路平安。");

                                }
                                this.DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                    chargeRecordModel = frmzxjk.GetRecordModel(plateid);
                                    if (chargeRecordModel != null)
                                    {
                                        this.CType = chargeRecordModel.CusType;

                                        //   txtCType.Text = chargeRecordModel.CusType;
                                        txtCType.Text = "一户多车";
                                        lbFeeStandard.Text = chargeRecordModel.FeeStandard;
                                        lbInTime.Text = time;
                                        lbOutTime.Text = outtime.ToString();
                                        lbCarType.Text = chargeRecordModel.CarType;
                                        lbParkTime.Text = parktime;
                                        lbSumMoney.Text = summoney.ToString("f0");
                                        inpath = chargeRecordModel.InImgPath;
                                        this.Tag = "1";
                                        if (!string.IsNullOrEmpty(inpath))
                                        {
                                            try
                                            {
                                                picIn.Image = Image.FromFile(inpath);
                                            }
                                            catch (Exception ex)
                                            {
                                            }

                                        }
                                    }
                                    ////    string speechtxt = plateid + "|" + plateid + ",停车" + parktime + ",收费" + lbSumMoney.Text + "元";
                                    //string speechtxt = plateid.Trim() + ",停车" + parktime + ",收费" + lbSumMoney.Text + "元";
                                    //if (InOutName == "In_axVZLPRClientCtrl")
                                    //{
                                    //    frmzxjk.InPlay(plateid, speechtxt);
                                    //}
                                    //else
                                    //{
                                    //    frmzxjk.OutPlay(plateid, speechtxt);

                                    //}

                            }


                        }
                    }
                    //没有启有一户多车的情况
                    else
                    {
                        this.CarType = "小型车";
                        this.Tag = "1";
                        this.PlateId = txtPlateId.Text;
                        this.OutTime = DateTime.Now;

                        if (InOutName == "In_axVZLPRClientCtrl")
                        {
                            frmzxjk.InPlay(plateid, plateid+ ",一路平安。");
                        }
                        else
                        {
                            frmzxjk.OutPlay(plateid, plateid + ",一路平安。");

                        }
                        if (MessageHelper.ConfirmYesNo("该车辆为固定车辆，点击确定放行"))
                        {


                            this.DialogResult = DialogResult.OK;
                        }

                        ////  过期固定客户收费
                        //if (iniinfo.IsFCustomerFee == "True")
                        //{

                        //    chargeRecordModel = frmzxjk.GetChargeModeByPlateId(txtPlateId.Text.Trim());
                        //    if (chargeRecordModel != null)
                        //    {
                        //        plateid = chargeRecordModel.PlateId;
                        //        time = chargeRecordModel.InTime.ToString();
                        //        intime = Convert.ToDateTime(time);
                        //        cartype = chargeRecordModel.CarType;
                        //        summoney = frmzxjk.CalulateFee(intime, cartype);
                        //        TimeSpan span = outtime - intime;
                        //        if (span.Days > 0)
                        //        {
                        //            parktime = span.Days + "天" + span.Hours + "小时" + span.Hours + "分钟";
                        //        }
                        //        else
                        //        {
                        //            parktime = span.Hours + "小时" + span.Minutes + "分钟";

                        //        }
                            

                        //    txtCType.Text = chargeRecordModel.CusType;
                        ////    this.CType = chargeRecordModel.CusType;
                        //    this.CType = "过期客户";
                        //    lbFeeStandard.Text = chargeRecordModel.FeeStandard;
                        //    lbInTime.Text = time;
                        //    lbOutTime.Text = outtime.ToString();
                        //    lbCarType.Text = cartype;
                        //    lbParkTime.Text = parktime;
                        //    lbSumMoney.Text = summoney.ToString("f0");
                        //    inpath = chargeRecordModel.InImgPath;

                        //}

               //     }


                  }
                }
                #region 过期客户

                //else
                //{
                // custype = CustomerConst.OFCustomer;

                #region 过期客户收费

                //过期固定客户收费
                if (iniinfo.IsFCustomerFee == "True")
                {
                    chargeRecordModel = frmzxjk.GetChargeModeByPlateId(txtPlateId.Text.Trim());
                    if (chargeRecordModel != null)
                    {
                        plateid = chargeRecordModel.PlateId;
                        time = chargeRecordModel.InTime.ToString();
                        intime = Convert.ToDateTime(time);
                        cartype = chargeRecordModel.CarType;
                        summoney = frmzxjk.CalulateFee(intime, cartype);
                        TimeSpan span = outtime - intime;
                        if (span.Days > 0)
                        {
                            parktime = span.Days + "天" + span.Hours + "小时" + span.Hours + "分钟";
                        }
                        else
                        {
                            parktime = span.Hours + "小时" + span.Minutes + "分钟";

                        }


                        txtCType.Text = chargeRecordModel.CusType;
                        //    this.CType = chargeRecordModel.CusType;
                        this.CType = "过期客户";
                        lbFeeStandard.Text = chargeRecordModel.FeeStandard;
                        lbInTime.Text = time;
                        lbOutTime.Text = outtime.ToString();
                        lbCarType.Text = cartype;
                        lbParkTime.Text = parktime;
                        lbSumMoney.Text = summoney.ToString("f0");
                        inpath = chargeRecordModel.InImgPath;

                        this.Tag = "1";
                        //   string speechtxt = plateid + "|" + plateid + ",停车" + parktime + ",收费" + lbSumMoney.Text + "元";
                        string speechtxt = plateid.Trim() + ",停车" + parktime + ",收费" + lbSumMoney.Text + "元";
                        if (InOutName == "In_axVZLPRClientCtrl")
                        {
                            frmzxjk.InPlay(plateid, speechtxt);
                        }
                        else
                        {

                            frmzxjk.OutPlay(plateid, speechtxt);

                        }
                    }
                }
                else
                {
                    this.CType = "过期客户";
                    this.CarType = "小型车";
                    this.Tag = "1";
                    this.PlateId = txtPlateId.Text;
                    this.OutTime = DateTime.Now;

                    if (MessageHelper.ConfirmYesNo("该车辆为过期客户，点击确定放行"))
                    {
                        this.DialogResult = DialogResult.OK;
                    }

                }
                #endregion
                #region 过期客户不收费
            }
            else //临停车的处理方法
            {

                chargeRecordModel = frmzxjk.GetChargeModeByPlateId(txtPlateId.Text.Trim());
                if (chargeRecordModel != null)
                {
                    plateid = chargeRecordModel.PlateId;
                }
                else
                {
                    tip = "车辆【" + txtPlateId.Text + "】没有进场信息！";
                    return;
                }

                if (chargeRecordModel != null)
                {
                    time = chargeRecordModel.InTime.ToString();
                    intime = Convert.ToDateTime(time);
                    cartype = chargeRecordModel.CarType;
                    summoney = frmzxjk.CalulateFee(intime, cartype);
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
                    txtCType.Text = chargeRecordModel.CusType;
                    this.CType = chargeRecordModel.CusType;
                    lbFeeStandard.Text = chargeRecordModel.FeeStandard;
                    lbInTime.Text = time;
                    lbOutTime.Text = outtime.ToString();
                    lbCarType.Text = cartype;
                    lbParkTime.Text = parktime;
                    lbSumMoney.Text = summoney.ToString("f0");
                    inpath = chargeRecordModel.InImgPath;



                    if (!string.IsNullOrEmpty(inpath))
                    {
                        try
                        {
                            picIn.Image = Image.FromFile(inpath);
                        }
                        catch (Exception ex)
                        {
                        }

                    }
                    this.Tag = "1";
                    //   string speechtxt = plateid + "|" + plateid + ",停车" + parktime + ",收费" + lbSumMoney.Text + "元";
                    string speechtxt = plateid.Trim() + ",停车" + parktime + ",收费" + lbSumMoney.Text + "元";
                    if (InOutName == "In_axVZLPRClientCtrl")
                    {
                        frmzxjk.InPlay(plateid, speechtxt);
                    }
                    else
                    {

                        frmzxjk.OutPlay(plateid, speechtxt);

                    }
                    //显示车位
                    frmzxjk.PlayBerth();
                }
                //else
                //{
                //    MessageHelper.ShowWarning(tip);
                //}

            }
           
        }


        /// <summary>
        ///  计费并显示
        /// </summary>
        /// <param name="plateid"></param>
        /// <returns></returns>
        public void calushow(string Number)
        {
        }



        /// <summary>
        ///  通过车牌号获取收费记录实体
        /// </summary>
        /// <param name="plateid"></param>
        /// <returns></returns>
        /// 

        //public ChargeRecord GetChargeModeByPlateId(string plateid)
        //{
        //    DataSet ds = chargeRecordBLL.GetList(1, "PlateId=" + "'" + plateid + "'", "InTime");
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        chargeRecordModel = chargeRecordBLL.DataTableToList(ds.Tables[0]).First();
        //        if (!string.IsNullOrEmpty(chargeRecordModel.OutTime.ToString()))
        //        {
        //            chargeRecordModel = null;
        //        }
        //    }
        //    else
        //    {
        //        chargeRecordModel = null;
        //    }
        //    return chargeRecordModel;

        //}
        /// <summary>
        /// 通过卡号获取收费记录实体
        /// </summary>
        /// <param name="cardcode"></param>
        /// <returns></returns>
        private ChargeRecord GetChargeModeByCardCode(string cardcode)
        {
            DataSet ds = chargeRecordBLL.GetList(1, "CardCode=" + "'" + cardcode + "'", "InTime");
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
        private void btnOpen_Click(object sender, EventArgs e)
        {

            if (chargeRecordModel != null)
            {
                if (string.IsNullOrWhiteSpace(lbFeeStandard.Text) || string.IsNullOrWhiteSpace(lbInTime.Text) || string.IsNullOrWhiteSpace(lbSumMoney.Text))
                {
                    MessageHelper.ShowWarning("请读取收费信息");
                    return;
                }
                else
                {


                    chargeRecordModel.OutTime = Convert.ToDateTime(lbOutTime.Text);
                    this.OutTime = Convert.ToDateTime(lbOutTime.Text);
                    this.CarType = lbCarType.Text;
                    this.CType = txtCType.Text;
                    this.CardCode = txtCardCode.Text;
                    this.PlateId = txtPlateId.Text;

                    chargeRecordModel.ParkTime = lbParkTime.Text;
                    if (!string.IsNullOrWhiteSpace(lbSumMoney.Text))
                    {
                        chargeRecordModel.SumMoney = Convert.ToDecimal(lbSumMoney.Text);
                    }

                    if (!string.IsNullOrWhiteSpace(cbReason.Text))
                    {
                        MessageHelper.ShowTips("不能选择免费原因！");
                        return;
                    }

                    chargeRecordModel.FreeReason = cbReason.Text;
                    chargeRecordModel.OperatorTime = DateTime.Now;
                    if (chargeRecordBLL.Update(chargeRecordModel))
                    {
                        Thread th = new Thread(new ParameterizedThreadStart(frmzxjk.AddWebCharge));
                        th.IsBackground = true;
                        th.Start(chargeRecordModel);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageHelper.ShowTips("操作失败！");
                        this.DialogResult = DialogResult.None;
                    }

                }

                this.DialogResult = DialogResult.OK;

            }
        }


        private void rd_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rd = (RadioButton)sender;
            if (rd.Text == "输入车牌号")
            {
                txtPlateId.Visible = true;
                txtPlateId.Focus();
                lbPlateId.Visible = true;
                lbCardCode.Visible = false;
                txtCardCode.Visible = false;
            }
            else
            {
                txtPlateId.Visible = false;
                lbPlateId.Visible = false;
                txtCardCode.Visible = true;
                txtCardCode.Focus();
                lbCardCode.Visible = true;
                lbCardCode.Location = new Point(20, 50);
                txtCardCode.Location = new Point(104, 50);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picIn_DoubleClick(object sender, EventArgs e)
        {
            //弹出窗口最大化显示本图片
            if (inpath.Contains("."))
            {
                Frmimgshow imgshow = new Frmimgshow();
                imgshow.Tag = inpath;
                imgshow.ShowDialog();
            }
            else
            {
                MessageHelper.ShowTips("暂无图片！");
            }
        }

        private void frmManualFee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)

            {
                this.btnOpen.Focus();
                btnOpen_Click(sender, e);


            }
        
    }
    private void UpdateCharge()
    {
        chargeRecordModel = new ChargeRecord();
        DataSet ds = chargeRecordBLL.GetList(1, "PlateId=" + "'" + lbPlateId.Text + "'", "InTime");
        if (ds.Tables[0].Rows.Count > 0)
        {
            chargeRecordModel = chargeRecordBLL.DataTableToList(ds.Tables[0]).First();
        }
        else
        {
            MessageHelper.ShowTips("请核对车牌是否正确！");
            return;
        }
        this.CusType = chargeRecordModel.CusType;
        chargeRecordModel.OutTime = Convert.ToDateTime(lbOutTime.Text);
        chargeRecordModel.SumMoney = Decimal.Parse(this.SumMoney);

        chargeRecordModel.OperatorTime = DateTime.Now;
        chargeRecordModel.OutImgPath = this.OutImgPath;
        chargeRecordModel.FeeStandard = lbFeeStandard.Text;
        chargeRecordModel.ParkTime = lbParkTime.Text;
        chargeRecordModel.FreeReason = cbReason.Text;
        chargeRecordModel.CarType = lbCarType.Text;
        chargeRecordModel.OperatorName = LoginInfo.LoginName;
        this.FreeReason = cbReason.Text;
        bool flag = chargeRecordBLL.Update(chargeRecordModel);
        if (flag)
        {
            Thread th = new Thread(new ParameterizedThreadStart(frmzxjk.AddWebCharge));
            th.IsBackground = true;
            th.Start(chargeRecordModel);
            //frmzxjk.AddWebCharge(chargeRecordModel);
            this.DialogResult = DialogResult.OK;
        }
        else
        {
            this.DialogResult = DialogResult.None;
        }
    }
}

}
    #endregion

#endregion