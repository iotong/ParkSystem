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

namespace ChargeWin
{
    public partial class frmCard : Form
    {
        PlateIdentifyInfo identifyInfoModel = new PlateIdentifyInfo();
        FeeStandard feeStandardModel = new FeeStandard();
        private ChargeRecord chargeRecordModel = null;
        ChargeRecordManager chargeRecordBLL = new ChargeRecordManager();
        private CarTypeManager carTypeBLL = new CarTypeManager();
        public string PalteId { get; set; }
        public string CardCode { get; set; }
        public string CType { get; set; }
        public string Tag { get; set; }
        public DateTime InTime { get; set; }
        public string CarType { get; set; }
        public string InImgPath { get; set; }
        private INIMag iniinfo = null;
        public frmCard(string inpath)
        {
            InitializeComponent();
            this.InImgPath = inpath;
           
        }

     
        private void frmCard_Load(object sender, EventArgs e)
        {
            iniinfo = new INIMag(GlobalInfo.Instance.ConfigPath);
            txtPlateId.TabIndex = 0;
            txtPlateId.Focus();
            rbPlateId.Checked= true;
            cbCarType.SelectedIndex = 0;
            //cbCustomerType.SelectedIndex = 0;
            CarTypeBind();
            
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
        private void CarTypeBind()
        {
            DataSet ds = carTypeBLL.GetAllList();
            cbCarType.DataSource = ds.Tables[0].DefaultView;
            cbCarType.DisplayMember = "CarTypeName";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ZXJK frmzxjk = null;
            frmzxjk = (ZXJK)this.Owner;
            chargeRecordModel = new ChargeRecord();
            this.Tag = "1";
            if (rbPlateId.Checked == true)
            {
                txtPlateId.Focus();
                if (string.IsNullOrWhiteSpace(txtPlateId.Text))
                {
                    MessageHelper.ShowTips("请输入车牌号！");
                   // this.DialogResult = DialogResult.None;
                    return;
                }
                else
                {
                    txtPlateId.Focus();
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
            string custype = string.Empty;
            if (!string.IsNullOrWhiteSpace(txtPlateId.Text))
            {
                this.PalteId = txtPlateId.Text.Trim();
                if (frmzxjk.GetFCustomer(this.PalteId)!=null)
                {
                    if (frmzxjk.IsInnerCar(this.PalteId))
                    {
                        custype = CustomerConst.InCustomer;
                    }
                    else
                    {
                        if (frmzxjk.IsValCustomer(this.PalteId))
                        {
                            custype = CustomerConst.FCustomer;
                        }
                        else
                        {
                            custype = CustomerConst.OFCustomer;
                        }
                        
                    }
                }
                else
                {
                    custype = CustomerConst.Customer;
                }
                //if (!string.IsNullOrEmpty(frmzxjk.GetInTime(this.PalteId)))
                //{
                //    MessageHelper.ShowTips("车辆【" + this.PalteId + "】已进场！");
                //    this.DialogResult = DialogResult.None;
                //    return;
                //}
            }
            if (!string.IsNullOrWhiteSpace(txtCardCode.Text))
            {
                custype = CustomerConst.Customer;
            }
            DateTime carintime = DateTime.Now;
           // int flag = 0;
            //if ((iniinfo.IsFCustomerFee == "True" && custype == CustomerConst.OFCustomer) || custype==CustomerConst.Customer)
            //{
            //    chargeRecordModel.CusType = custype;
            //    chargeRecordModel.PlateId = txtPlateId.Text;
            //    chargeRecordModel.CardCode = txtCardCode.Text;
            //    chargeRecordModel.InTime = carintime;
            //    chargeRecordModel.CarType = cbCarType.Text;
            //    chargeRecordModel.FeeStandard = GetFeeStandard(cbCarType.Text);
            //    chargeRecordModel.InImgPath = this.InImgPath;
            //    chargeRecordModel.OperatorName = LoginInfo.LoginName;
            //    chargeRecordModel.ParkId = LoginInfo.ParkId;
            //    chargeRecordModel.CompanyCode = LoginInfo.CompanyCode;
            //    flag = chargeRecordBLL.Add(chargeRecordModel);
            //} 
            this.CType = custype;
            this.PalteId = txtPlateId.Text;
            this.CardCode = txtCardCode.Text;
            this.InTime = carintime;
            this.CarType = cbCarType.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            this.Close();
            
        }
        /// <summary>
        /// 获得收费标准
        /// </summary>
        /// <returns></returns>
        private string GetFeeStandard(string cartype)
        {
            ZXJK frmzxjk;
            frmzxjk = (ZXJK)this.Owner;
            feeStandardModel = frmzxjk.GetChargeStandardByCarType(cartype);
            return feeStandardModel.FeeType;
        }

        private void txtCardCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if(e.KeyChar==(Char)Keys.Enter)
            {
            btnOK_Click(null, null);
            }
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rd = (RadioButton)sender;
            if (rd.Text == "输入车牌号")
            {
                txtCardCode.Text = "";
                txtPlateId.Visible = true;
                lbPlateId.Visible = true;
                txtPlateId.Focus();
                txtCardCode.Visible = false;
                lbCardCode.Visible = false;
            }
            else
            {
                txtPlateId.Text = "";
                txtPlateId.Visible = false;
                lbPlateId.Visible = false;
                txtCardCode.Visible = true;
                lbCardCode.Visible = true;
                lbCardCode.Location = new Point(6, 50);
                txtCardCode.Location = new Point(75, 47);
                txtCardCode.Focus();
            }
        }

        private void txtCardCode_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCardCode.Text))
            {
                //MessageHelper.ShowTips("请刷卡！");
                //txtCardCode.Focus();
            }
        }

        private void txtPlateId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {  
                btnOK_Click(null,null); 
            }
        }

        }
    }

