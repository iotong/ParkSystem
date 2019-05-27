using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bll = www.gzwulian.com.BLL;
using Model = www.gzwulian.com.Model;
using System.Text.RegularExpressions;
using System.Threading;
using www.gzwulian.com.Common;
using ChargeWin;

namespace ChargeWin
{
    public partial class frmFCustomerAdd : Form
    {
        public frmFCustomerAdd()
        {
            InitializeComponent();
        }
        private void frmFCustomerAdd_Load(object sender, EventArgs e)
        {
            cbbSex.DropDownStyle=ComboBoxStyle.DropDownList;
           
        }
        public frmFCustomerAdd(string State,int FcId)
        {
            InitializeComponent();
            if (State == "添加")
            {
                this.Text = "增加车主信息";
                this.btnUpdate.Visible = false;
                cbbSex.SelectedIndex = 0;
            }
            else if (State == "修改")
            {
                this.Text = "修改车主信息";
                this.btnAdd.Visible = false;
                btnUpdate.Location = new Point(78,320);
                UpdateId = FcId;
                FcustomerUpdateLoad(bllFcMag.GetModel(FcId));
            }

        }

        void FcustomerUpdateLoad(Model.FCustomer FcUpdate)
        {
            this.tbxFcName.Text = FcUpdate.Name;
            this.tbxCode.Text = FcUpdate.Code;
            this.cbbSex.Text = FcUpdate.Gender;
            tbxIdCard.Text = FcUpdate.IdCard;
            tbxTelphone.Text = FcUpdate.Telphone;
            this.tbxPlateId.Text = FcUpdate.PlateId;
            this.cbCarType.Text = FcUpdate.CarType;
            this.tbxPlateColor.Text = FcUpdate.PlateColor;
            this.dtpCreateTime.Text = FcUpdate.CreateTime.ToString() ?? "";
            this.dtpOverTime.Text = FcUpdate.OverTime.ToString() ?? "";
            this.cbxEnable.Checked = FcUpdate.Enable;
            this.cbbSex.Text = FcUpdate.Gender;
        }
        WebFCustomerInfo.FCustomer  FCustomerModel = null;//服务端实体
        /// <summary>
        /// 将添加或修改的固定客户上传到服务器端
        /// </summary>
        /// <param name="model"></param>
        private void UploadFCustomer(object model)
        { 
          #region 将固定客户上传到服务器端
            www.gzwulian.com.Model.FCustomer fmodel = (www.gzwulian.com.Model.FCustomer)model;
		          bool isSuccess = true;
                    try
                    {
                        WebFCustomerInfo.FCustomerInfo FCustomerBLL = new WebFCustomerInfo.FCustomerInfo();
                        FCustomerModel =ModelTrans.GetWebFCustomerModel(fmodel);
                        FCustomerBLL.Add(FCustomerModel);
                    }
                    catch(Exception er)
                    {
                       
                       isSuccess=false;
                       er.Message.ToString();
                    }

                    fmodel.IsUpload=isSuccess;
                    bllFcMag.Update(fmodel); 
	                #endregion
        }
        /// <summary>
        /// 获得服务端实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private WebFCustomerInfo.FCustomer GetWebFCustomerModel(www.gzwulian.com.Model.FCustomer model)
        {
            FCustomerModel = new WebFCustomerInfo.FCustomer();
            FCustomerModel.Address = model.Address;
            if(model.AddTime!=null)
            { 
               FCustomerModel.AddTime =DateTime.Parse(model.AddTime.ToString());
            }
            FCustomerModel.Affiliation = model.Affiliation;
            FCustomerModel.BirthDate = model.BirthDate;
            FCustomerModel.CarType = model.CarType;
            FCustomerModel.Code = model.Code;
            FCustomerModel.CompanyCode = model.CompanyCode;
            if(model.CreateTime!=null)
            {
               FCustomerModel.CreateTime =DateTime.Parse(model.CreateTime.ToString());
            }
            FCustomerModel.Department = model.Department;
            FCustomerModel.Enable = model.Enable;
            FCustomerModel.Gender = model.Gender;
            FCustomerModel.Id = model.Id;
            FCustomerModel.IdCard = model.IdCard;
            FCustomerModel.ImgPath = model.ImgPath;
            FCustomerModel.IsMarried = model.IsMarried;
            FCustomerModel.IsUpload = model.IsUpload;
            FCustomerModel.JoinDate = model.JoinDate;
            FCustomerModel.Majou = model.Majou;
            FCustomerModel.Name = model.Name;
            FCustomerModel.NativePlace = model.NativePlace;
            FCustomerModel.NeedAlarm = model.NeedAlarm;
            FCustomerModel.OperatorName = model.OperatorName;
            if(model.OverTime!=null)
            {
               FCustomerModel.OverTime =DateTime.Parse(model.OverTime.ToString());
            }
          
            FCustomerModel.ParkId = model.ParkId;
            FCustomerModel.Path = model.Path;
            FCustomerModel.PlateColor = model.PlateColor;
            FCustomerModel.PlateId = model.PlateId;
            FCustomerModel.Position = model.Position;
            FCustomerModel.PostalCode = model.PostalCode;
            FCustomerModel.School = model.School;
            FCustomerModel.StartTimeSeg = model.StartTimeSeg;
            FCustomerModel.Telphone = model.Telphone;
            FCustomerModel.TimeSeg = model.TimeSeg;
            FCustomerModel.TopDegree = model.TopDegree;
            return FCustomerModel;
        }
        Bll.FCustomerManager bllFcMag = new Bll.FCustomerManager();

        Model.FCustomer modelFc = new Model.FCustomer();

        int UpdateId;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (bllFcMag.GetModelList("PlateId='" + tbxPlateId.Text + "'").Count > 0)
            {
                MessageHelper.ShowTips("已存在【" + tbxPlateId.Text + "】的信息！");
                return;
            }
            else
            {
                Add();
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        private void Add()
        {
            if (string.IsNullOrWhiteSpace(this.tbxFcName.Text))
            {
                MessageBox.Show("请输入车主姓名！", "提示");
                return;
            }
            if (!string.IsNullOrWhiteSpace(this.tbxIdCard.Text))
            {
                Regex regCardRegex = new Regex(@"^[1-9][0-7]\d{4}((19\d{2}(0[13-9]|1[012])(0[1-9]|[12]\d|30))|(19\d{2}(0[13578]|1[02])31)|(19\d{2}02(0[1-9]|1\d|2[0-8]))|(19([13579][26]|[2468][048]|0[48])0229))\d{4}(\d|X|x)?$");     //身份证
                if (!regCardRegex.IsMatch(this.tbxIdCard.Text))
                {
                    MessageBox.Show(this, "错误，请输入正确身份证号.", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (!string.IsNullOrWhiteSpace(this.tbxTelphone.Text))
            {
                Regex regMobileRegex = new Regex("^[1][3-8]\\d{9}$");     //电话
                if (!regMobileRegex.IsMatch(this.tbxTelphone.Text))
                {
                    MessageBox.Show(this, "错误，请输入正确的11位手机号.", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (string.IsNullOrWhiteSpace(this.tbxPlateId.Text))
            {
                MessageBox.Show("请输入车牌号码！", "提示");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.cbCarType.Text))
            {
                MessageBox.Show("请选择车辆类型！", "提示");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.tbxCode.Text))
            {
                MessageBox.Show("请输入车主编号！", "提示");
                return;
            }
            modelFc.Name = this.tbxFcName.Text;
            modelFc.Code = this.tbxCode.Text;
            modelFc.Gender = this.cbbSex.Text;
            modelFc.IdCard = tbxIdCard.Text;
            modelFc.CarType=  cbCarType.Text;
            modelFc.Telphone = tbxTelphone.Text;
            modelFc.PlateId = this.tbxPlateId.Text;
            modelFc.PlateColor = this.tbxPlateColor.Text;
            //modelFc.TimeSeg = this.tbxTimeSeg.Text;
            //modelFc.StartTimeSeg = this.cbxStartTimeSeg.Checked;
            //modelFc.NeedAlarm = this.cbxNeedAlarm.Checked;
            modelFc.CreateTime = this.dtpCreateTime.Value;
            modelFc.OverTime = this.dtpOverTime.Value;
            modelFc.Enable = this.cbxEnable.Checked;
            modelFc.CompanyCode = LoginInfo.CompanyCode;
            modelFc.ParkId = LoginInfo.ParkId;
            try
            {
                int rows = bllFcMag.Add(modelFc);
                if (rows > 0)
                {
                    MessageBox.Show("数据添加成功。", "提示");

                    frmFCustomer.strnewplate = tbxPlateId.Text; 
                    this.DialogResult = DialogResult.OK;
                    //UploadFCustomer(modelFc);
                    //将固定客户上传到服务器端
                    Thread th = new Thread(new ParameterizedThreadStart(UploadFCustomer));
                    th.IsBackground = true;
                    th.Start(modelFc);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("数据添加失败,请检查后重试!");
                }


            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 更新
        /// </summary>
        private void Update()
        {
            if (string.IsNullOrWhiteSpace(this.tbxFcName.Text))
            {
                MessageBox.Show("请输入车主姓名！", "提示");
                return;
            }
            if (!string.IsNullOrWhiteSpace(this.tbxIdCard.Text))
            {
                Regex regCardRegex = new Regex(@"^[1-9][0-7]\d{4}((19\d{2}(0[13-9]|1[012])(0[1-9]|[12]\d|30))|(19\d{2}(0[13578]|1[02])31)|(19\d{2}02(0[1-9]|1\d|2[0-8]))|(19([13579][26]|[2468][048]|0[48])0229))\d{4}(\d|X|x)?$");     //身份证
                if (!regCardRegex.IsMatch(this.tbxIdCard.Text))
                {
                    MessageBox.Show(this, "错误，请输入正确身份证号.", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (!string.IsNullOrWhiteSpace(this.tbxTelphone.Text))
            {
                Regex regMobileRegex = new Regex("^[1][3-8]\\d{9}$");     //电话
                if (!regMobileRegex.IsMatch(this.tbxTelphone.Text))
                {
                    MessageBox.Show(this, "错误，请输入正确的11位手机号.", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (string.IsNullOrWhiteSpace(this.tbxPlateId.Text))
            {
                MessageBox.Show("请输入车牌号码！", "提示");
                return;
            }

            modelFc.Id = this.UpdateId;
            modelFc.Name = this.tbxFcName.Text;
            modelFc.Code = this.tbxCode.Text;
            modelFc.Gender = this.cbbSex.Text;
            modelFc.IdCard = tbxIdCard.Text;
            modelFc.Telphone = tbxTelphone.Text;
            modelFc.PlateId = this.tbxPlateId.Text;
            modelFc.PlateColor = this.tbxPlateColor.Text;
            //modelFc.TimeSeg = this.tbxTimeSeg.Text;
            //modelFc.StartTimeSeg = this.cbxStartTimeSeg.Checked;
            //modelFc.NeedAlarm = this.cbxNeedAlarm.Checked;
            modelFc.CreateTime = this.dtpCreateTime.Value;
            modelFc.OverTime = this.dtpOverTime.Value;
            modelFc.Enable = this.cbxEnable.Checked;
            modelFc.AddTime = DateTime.Now;
            try
            {
                bool rows = bllFcMag.Update(modelFc);
                if (rows)
                {
                    MessageBox.Show("数据修改成功。", "提示");
                    //UploadFCustomer(modelFc);
                    Thread th = new Thread(new ParameterizedThreadStart(UploadFCustomer));
                    th.IsBackground = true;
                    th.Start(modelFc);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("数据修改失败,请检查后重试。", "提示");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.tbxFcName.Text))
            {
                MessageBox.Show("请输入车主姓名！","提示");
                return;
            }
            if (!string.IsNullOrWhiteSpace(this.tbxIdCard.Text))
            {
                Regex regCardRegex = new Regex(@"^[1-9][0-7]\d{4}((19\d{2}(0[13-9]|1[012])(0[1-9]|[12]\d|30))|(19\d{2}(0[13578]|1[02])31)|(19\d{2}02(0[1-9]|1\d|2[0-8]))|(19([13579][26]|[2468][048]|0[48])0229))\d{4}(\d|X|x)?$");     //身份证
                if (!regCardRegex.IsMatch(this.tbxIdCard.Text))
                {
                    MessageBox.Show(this, "错误，请输入正确身份证号.", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (!string.IsNullOrWhiteSpace(this.tbxTelphone.Text))
            {
                Regex regMobileRegex = new Regex("^[1][3-8]\\d{9}$");     //电话
                if (!regMobileRegex.IsMatch(this.tbxTelphone.Text))
                {
                    MessageBox.Show(this, "错误，请输入正确的11位手机号.", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (string.IsNullOrWhiteSpace(this.tbxPlateId.Text))
            {
                MessageBox.Show( "请输入车牌号码！","提示");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.cbCarType.Text))
            {
                MessageBox.Show("请选择车辆类型！", "提示");
                return;
            }
            modelFc.Id = this.UpdateId;
            modelFc.Name = this.tbxFcName.Text;
            modelFc.Code = this.tbxCode.Text;
            modelFc.Gender = this.cbbSex.Text;
            modelFc.IdCard = tbxIdCard.Text;
            modelFc.Telphone = tbxTelphone.Text;
            modelFc.PlateId = this.tbxPlateId.Text;
            modelFc.CarType = this.cbCarType.Text;
            modelFc.PlateColor = this.tbxPlateColor.Text;
            //modelFc.TimeSeg = this.tbxTimeSeg.Text;
            //modelFc.StartTimeSeg = this.cbxStartTimeSeg.Checked;
            //modelFc.NeedAlarm = this.cbxNeedAlarm.Checked;
            modelFc.CreateTime = this.dtpCreateTime.Value;
            modelFc.OverTime = this.dtpOverTime.Value;
            modelFc.AddTime = DateTime.Now;
            modelFc.CompanyCode = LoginInfo.CompanyCode;
            modelFc.Enable = this.cbxEnable.Checked;
            try
            {
               bool rows = bllFcMag.Update(modelFc);
                if (rows)
                {

                    MessageBox.Show( "数据修改成功。","提示");


                    frmFCustomer.strnewplate = tbxPlateId.Text;
                    this.DialogResult = DialogResult.OK;
                    UploadFCustomer(modelFc);
                    this.Close();
                }
                else
                    MessageBox.Show( "数据修改失败,请检查后重试。","错误");

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void tbxTelphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' || (e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == 8 || e.KeyChar == 46 || e.KeyChar == 0x08)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                return;
            }
        }







      


    }
}
