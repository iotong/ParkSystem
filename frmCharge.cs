using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using www.gzwulian.com.BLL;
using www.gzwulian.com.Model;
using www.gzwulian.com.Common;
using System.Threading;
using ChargeWin;

namespace ChargeWin
{
    public partial class frmCharge : Form
    {
        public string PlateId { get; set; }
        public string CarType { get; set; }
        public string InTime { get; set; }
        public string ParkTime { get; set; }
        public string OutTime { get; set; }
        public string SumMoney { get; set; }

        public string GiveMoney { get; set; }
        public string FeeType { get; set; }
        public string FreeReason { get; set;}
        public string OutImgPath { get; set;}
        public string CusType { get; set; }
        private ChargeRecord chargeRecordModel = null;
        private ChargeRecordManager chargeRecordBLL = new ChargeRecordManager();
        INIMag iniinfo = new INIMag(GlobalInfo.Instance.ConfigPath);

        public const string Endtext = "一路平安";
        public string InOutName { get; set; }
        private ZXJK frmzxjk = null;
        private Thread th;
        public frmCharge(string plateid, string cartype, DateTime intime, DateTime outtime, string parktime, string feetype, decimal summoney, string outimgpath,string inoutname)
        {
            InitializeComponent();
            chargeRecordModel = new ChargeRecord();
            //  DataSet ds = chargeRecordBLL.GetList(1, "PlateId=" + "'" + lbPlateId.Text + "'", "InTime");
            DataSet ds = chargeRecordBLL.GetList(1, "PlateId=" + "'" + plateid + "'", "InTime");
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


            this.PlateId = plateid;
            this.CarType = cartype;
            this.InTime = intime.ToString();
            this.OutTime = outtime.ToString();
            this.ParkTime = parktime;
            this.FeeType = feetype;
            this.SumMoney = summoney.ToString("f0");
            this.InOutName = inoutname;
            this.OutImgPath = outimgpath;
            lbPlateId.Text = plateid;
            lbCarType.Text = cartype;
            lbInTime.Text = intime.ToString();
            lbOutTime.Text = outtime.ToString();
            lbSumMoney.Text = summoney.ToString("f2") + "(元)";
            lbFeeStandard.Text = feetype;
            lbParkTime.Text = parktime;
            label1.Text = CusType;
           // OutImgPath = outimgpath;
           // inpath = outimgpath;



        }
        public struct CustomerConst
        {
            public const string Customer = "临停客户";
            public const string FCustomer = "固定客户";
            public const string OFCustomer = "过期客户";
            public const string PlusOperate = "PlusOperate";
            public const string SubOperate = "SubOperate";
         
        }
        private string inpath = string.Empty;
        private void frmCharge_Load(object sender, EventArgs e)
        {
            frmzxjk = (ZXJK)this.Owner;
            if(cbReason.Items.Count<1)
            {
                cbReason.Items.Clear();
               ReadFree();
            }
            ChargeRecord chargeRecord = frmzxjk.GetRecordModel(this.PlateId);
            inpath = chargeRecord.InImgPath;

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


            Thread th = new Thread(PlayChangeInfo);
            th.IsBackground = true;
            th.Start();


        }

        private void ReadFree()
        {
            string[] str = frmzxjk.strReason.ToString().Split(',');

            for (int i = 0; i < str.Length; i++)
            {
                cbReason.Items.Add(str[i]);
            }


        }

        /// <summary>
        /// 更新收费记录
        /// </summary>
        private void UpdateCharge()
        {
            chargeRecordModel=new ChargeRecord();
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
            chargeRecordModel.GiveCharge = Decimal.Parse(this.GiveMoney);
            this.FreeReason = cbReason.Text;
            bool flag = chargeRecordBLL.Update(chargeRecordModel);
            if (flag)
            {

                if (iniinfo.CarinfoUpload == "True")
                {
                    Thread th = new Thread(new ParameterizedThreadStart(frmzxjk.AddWebCharge));
                    th.IsBackground = true;
                    th.Start(chargeRecordModel);
                }

                //Thread th = new Thread(new ParameterizedThreadStart(frmzxjk.AddWebCharge));
                //th.IsBackground = true;
                //th.Start(chargeRecordModel);
               // PlayChangeInfo();
                //if (iniinfo.CarinfoUpload == "True")
                //{ 
                //    frmzxjk.AddWebCharge(chargeRecordModel);
                //}
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
        }


        private void btnPass_Click(object sender, EventArgs e)
        {
          
            if (string.IsNullOrWhiteSpace(cbReason.Text))
            {
                this.GiveMoney = this.SumMoney;
                UpdateCharge();
                if (InOutName == "In_axVZLPRClientCtrl")
                {
                    frmzxjk.InPlay(this.PlateId, Endtext);
                   
                }
                if (InOutName == "Out_axVZLPRClientCtrl")
                {
                    frmzxjk.OutPlay(this.PlateId, Endtext);
                  
                }
                if (InOutName == "Out_FiveaxVZLPRClientCtrl")
                {
                    frmzxjk.FivePlay(this.PlateId, Endtext);

                }
            }
            else
            {
                MessageHelper.ShowTips("不能选择免费原因！");
                return;
            }
           

        }


        private void btnFreePass_Click(object sender, EventArgs e)
        {
           

            if (iniinfo.IsOutSelectFreeFee=="True")
            {
                if (!string.IsNullOrWhiteSpace(cbReason.Text))
                {
                  
                    this.GiveMoney = "0";
                    UpdateCharge();

                    DialogResult i = MessageBox.Show("是否开闸？", "提示！", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                 if((int)i==6)
                    {

                        this.DialogResult = DialogResult.OK;

                    }
                    else
                    {

                        this.DialogResult = DialogResult.Cancel;

                    }

                    if (InOutName == "In_axVZLPRClientCtrl")
                    {
                        frmzxjk.InPlay(this.PlateId, Endtext);

                    }
                    if (InOutName == "Out_axVZLPRClientCtrl")
                    {
                        frmzxjk.OutPlay(this.PlateId, Endtext);

                    }

                    if (InOutName == "Out_FiveaxVZLPRClientCtrl")
                    {
                        frmzxjk.FivePlay(this.PlateId, Endtext);

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

        private void frmCharge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.btnPass.Focus();
                btnPass_Click(sender,e);

            }
        }

        private void frmCharge_Shown(object sender, EventArgs e)
        {

            
        }

        private void PlayChangeInfo()
        {

            string Speechtxt = "";
            string Stoptext = "收费" + this.SumMoney + "元";
            if (iniinfo.LcarplayNo == "True")
            {
                Speechtxt = this.PlateId + ",停车" + this.ParkTime + ",收费" + this.SumMoney + "元";
            }
            else
            {
                Speechtxt = "停车" + this.ParkTime + ",收费" + this.SumMoney + "元";

            }
            if (InOutName == "In_axVZLPRClientCtrl")
            {

                frmzxjk.InPlay(this.PlateId, Speechtxt);
                Thread.Sleep(4000);
                frmzxjk.InPlay(this.PlateId + "stop", Stoptext);


            }
            if (InOutName == "Out_axVZLPRClientCtrl")
            {
                frmzxjk.OutPlay(this.PlateId, Speechtxt);
                Thread.Sleep(4000);
                frmzxjk.OutPlay(this.PlateId + "stop", Stoptext);

            }
            if (InOutName == "Out_FiveaxVZLPRClientCtrl")
            {
                frmzxjk.FivePlay(this.PlateId, Speechtxt);
                Thread.Sleep(4000);
                frmzxjk.FivePlay(this.PlateId + "stop", Stoptext);

            }
        }
    }
}
