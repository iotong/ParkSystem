using ChargeWin;
using ChargeWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using www.gzwulian.com.BLL;
using www.gzwulian.com.Common;
using www.gzwulian.com.Model;
using ParkInfo = www.gzwulian.com.Model.ParkInfo;

namespace ChargeWin
{
    public partial class frmParking : Form
    {
        public frmParking()
        {
            InitializeComponent();
        }
        www.gzwulian.com.Model.Company companyModel=new Company();
        www.gzwulian.com.BLL.CompanyManager companyBLL=new CompanyManager();
        www.gzwulian.com.Model.ParkInfo parkinfoModel=new ParkInfo();
        www.gzwulian.com.BLL.ParkInfoManager parkinfoBLL=new ParkInfoManager();
        Operator operatorModel = new Operator();
        private OperatorManager operatorBLL = new OperatorManager();
        private string parkId;
        private string CompanyCode;
        string flag = string.Empty;
        private void frmParking_Load(object sender, EventArgs e)
        {
            InitComInfo();
            BindParkInfo();
            //DataBind();
            txtLat.Enabled = false;
            txtLon.Enabled = false;
            if (!string.IsNullOrWhiteSpace(txtParkId.Text))
            {
                lbLeftBerth.Visible = true;
                txtLeftBerth.Visible = true;
            }
        }
     
        /// <summary>
        /// 检查车场编号是否存在
        /// </summary>
        /// <returns></returns>
        private bool CheckParkId()
       {
           www.gzwulian.com.Model.ParkInfo parkInfomodel = new ParkInfo();
           parkInfomodel = parkinfoBLL.GetModel(txtParkId.Text.Trim());
           if (parkInfomodel != null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        /// <summary>
        /// 绑定停车场信息
        /// </summary>
        private void BindParkInfo()
        {
            operatorModel = operatorBLL.GetModel(LoginInfo.Id);
            parkId = operatorModel.ParkId;
            
            if (!string.IsNullOrWhiteSpace(parkId))
            {
                parkinfoModel = parkinfoBLL.GetModel(parkId);
                if (parkinfoModel!=null)
                {
                    txtParkId.Text = parkinfoModel.ParkID;
                    txtParkId.Enabled = false;
                    txtParkName.Text = parkinfoModel.ParkName;
                    txtParkCity.Text = parkinfoModel.ParkCity;
                    txtParkCounty.Text = parkinfoModel.ParkCounty;
                    txtParkStreet.Text = parkinfoModel.ParkStreet;
                    txtParkOwner.Text = parkinfoModel.ParkOwner;
                    txtOwnerTel.Text = parkinfoModel.OwnerTel;
                    txtBusinessTime.Text = parkinfoModel.BusinessTime.ToString();
                    txtParkType.Text = parkinfoModel.ParkType;
                    txtSumBerthCount.Text = parkinfoModel.SumBerthCount.ToString();
                    txtFBerthCount.Text = parkinfoModel.FBerthCount.ToString();
                    txtBerthCount.Text = parkinfoModel.BerthCount.ToString();
                    txtLeftBerth.Text = parkinfoModel.BerthCountRest.ToString();
                    txtLat.Text = parkinfoModel.Latitude.ToString();
                    txtLon.Text = parkinfoModel.Longtitude.ToString();
                    txtRemark.Text = parkinfoModel.Remark;

                }
               
            }
        }

        /// <summary>
        /// 初始化经营单位信息
        /// </summary>
        private void InitComInfo()
        {
            operatorModel = operatorBLL.GetModel(LoginInfo.Id);
            CompanyCode = operatorModel.CompanyCode;
            if (!string.IsNullOrWhiteSpace(CompanyCode))
            {
                companyModel = companyBLL.GetModel(CompanyCode);
                if (companyModel!=null)
                {
                    txtCompanyCode.Text = companyModel.CompanyCode;
                    txtName.Text = companyModel.Name;
                    txtCompanyCode.Enabled = false;
                    txtName.Enabled = false;
                }
             
            }
        }
        /// <summary>
        /// 检查输入
        /// </summary>
        /// <returns></returns>
        private void CheckInput()
        {
            flag = string.Empty;
            if (string.IsNullOrWhiteSpace(txtParkId.Text))
            {
                flag = "停车场编号不能为空！";
                www.gzwulian.com.Common.MessageHelper.ShowWarning(flag);
                return;

            }
            if (string.IsNullOrWhiteSpace(txtParkName.Text))
            {
                flag = "停车场名称不能为空！";
                www.gzwulian.com.Common.MessageHelper.ShowWarning(flag);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtParkCity.Text))
            {
                flag = "停车场所在城市不能为空！";
                www.gzwulian.com.Common.MessageHelper.ShowWarning(flag);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtParkCounty.Text))
            {
                flag = "停车场所在区（区县）不能为空！";
                www.gzwulian.com.Common.MessageHelper.ShowWarning(flag);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtParkStreet.Text))
            {
                flag = "停车场所在街道不能为空！";
                www.gzwulian.com.Common.MessageHelper.ShowWarning(flag);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtParkOwner.Text))
            {
                flag = "停车场所在经营者不能为空！";
                www.gzwulian.com.Common.MessageHelper.ShowWarning(flag);
                return;
            }
            //if (string.IsNullOrWhiteSpace(txtLon.Text) && !string.IsNullOrWhiteSpace(txtLat.Text))
            //{
            //    flag = "经纬度不能为空！";
            //    www.gzwulian.com.Common.MessageHelper.ShowWarning(flag);
            //    return;
            //}
            if (string.IsNullOrWhiteSpace(txtSumBerthCount.Text))
            {
                flag = "停车场总泊位数不能为空！";
                www.gzwulian.com.Common.MessageHelper.ShowWarning(flag);
                return;
            }
            if (!string.IsNullOrWhiteSpace(txtOwnerTel.Text))
            {
                Regex regMobileRegex = new Regex("^[1][3-8]\\d{9}$");     //电话
                if (!regMobileRegex.IsMatch(this.txtOwnerTel.Text))
                {
                    flag = "请正确输入11位手机号！";
                    MessageHelper.ShowWarning(flag);
                    return;
                }
            }


        }

        /// <summary>
        ///更新停车场信息
        /// </summary>
        private void EditeParkInfo()
        {
            //检查输入
            CheckInput();
            if (!string.IsNullOrEmpty(flag))
            {
                return;
            }
            operatorModel = operatorBLL.GetModel(LoginInfo.Id);
            parkId = operatorModel.ParkId;
            parkinfoModel = parkinfoBLL.GetModel(parkId);
            if (parkinfoModel!=null)
            {
               
                parkinfoModel.ParkID = txtParkId.Text.Trim();
                parkinfoModel.ParkName = txtParkName.Text.Trim();
                parkinfoModel.ParkCity = txtParkCity.Text.Trim();
                parkinfoModel.ParkCounty = txtParkCounty.Text.Trim();
                parkinfoModel.ParkStreet = txtParkStreet.Text.Trim();
                parkinfoModel.ParkOwner = txtParkOwner.Text.Trim();
                if (!string.IsNullOrWhiteSpace(txtParkType.Text))
                {
                    parkinfoModel.ParkType = txtParkType.Text.Trim();
                }
                if (!string.IsNullOrWhiteSpace(txtLat.Text) || !string.IsNullOrWhiteSpace(txtLon.Text))
                {
                    parkinfoModel.Longtitude = Decimal.Parse(txtLon.Text);
                    parkinfoModel.Latitude = Decimal.Parse(txtLat.Text);
                }
                parkinfoModel.SumBerthCount = Int32.Parse(txtSumBerthCount.Text.Trim());
                if (!string.IsNullOrWhiteSpace(txtBerthCount.Text))
                {
                    parkinfoModel.BerthCount = Int32.Parse(txtBerthCount.Text.Trim());
                    parkinfoModel.BerthCountRest = Int32.Parse(txtBerthCount.Text.Trim());
                }
                if (!string.IsNullOrWhiteSpace(txtLeftBerth.Text))
                {
                    parkinfoModel.BerthCountRest = Int32.Parse(txtLeftBerth.Text.Trim());
                }
                if (!string.IsNullOrWhiteSpace(txtFBerthCount.Text))
                {
                    parkinfoModel.FBerthCount = Int32.Parse(txtFBerthCount.Text.Trim());
                    parkinfoModel.FBerthCountRest = Int32.Parse(txtFBerthCount.Text.Trim());
                }
                parkinfoModel.BusinessTime = txtBusinessTime.Text.Trim();
                parkinfoModel.OwnerTel = txtOwnerTel.Text.Trim();
                parkinfoModel.Remark = txtRemark.Text.Trim();
                parkinfoModel.CompanyCode = txtCompanyCode.Text;
                parkinfoModel.OperatorName = LoginInfo.LoginName;
                if (string.IsNullOrEmpty(flag))
                {
                    if (parkinfoBLL.Update(parkinfoModel))
                    {
                        LoginInfo.ParkId = parkinfoModel.ParkID;
                        try
                        {
                            //将停车场信息上传到服务器端
                            Thread th = new Thread(UploadParkInfo);
                            th.IsBackground = true;
                            th.Start();
                        }
                        catch (Exception)
                        {
                        }
                        www.gzwulian.com.Common.MessageHelper.ShowTips("修改成功！");
                    }
                    else
                    {
                        www.gzwulian.com.Common.MessageHelper.ShowTips("修改失败！");
                    }

                }
            }

        }

      
        /// <summary>
        /// 添加停车场信息
        /// </summary>
        private void AddParkInfo()
        {
            //检查输入
            CheckInput();
            if (!string.IsNullOrEmpty(flag))
            {
                return;
            }
            parkinfoModel = new ParkInfo();
            parkinfoModel.ParkID = txtParkId.Text.Trim();
            parkinfoModel.ParkName = txtParkName.Text.Trim();
            parkinfoModel.ParkCity = txtParkCity.Text.Trim();
            parkinfoModel.ParkCounty = txtParkCounty.Text.Trim();
            parkinfoModel.ParkStreet = txtParkStreet.Text.Trim();
            parkinfoModel.ParkOwner = txtParkOwner.Text.Trim();
            if (!string.IsNullOrWhiteSpace(txtParkType.Text))
            {
                parkinfoModel.ParkType = txtParkType.Text.Trim();
            }
            if (!string.IsNullOrWhiteSpace(txtLat.Text) || !string.IsNullOrWhiteSpace(txtLon.Text))
            {
                parkinfoModel.Longtitude = Decimal.Parse(txtLon.Text);
                parkinfoModel.Latitude = Decimal.Parse(txtLat.Text);
            }
            parkinfoModel.SumBerthCount = Int32.Parse(txtSumBerthCount.Text.Trim());
            if (!string.IsNullOrWhiteSpace(txtBerthCount.Text))
            {
                parkinfoModel.BerthCount = Int32.Parse(txtBerthCount.Text.Trim());
                parkinfoModel.BerthCountRest = Int32.Parse(txtBerthCount.Text.Trim());
            }
            if (!string.IsNullOrWhiteSpace(txtFBerthCount.Text))
            {
                parkinfoModel.FBerthCount = Int32.Parse(txtFBerthCount.Text.Trim());
                parkinfoModel.FBerthCountRest = Int32.Parse(txtFBerthCount.Text.Trim());
            }
            parkinfoModel.BusinessTime = txtBusinessTime.Text.Trim();
            parkinfoModel.OwnerTel = txtOwnerTel.Text.Trim();
            parkinfoModel.Remark = txtRemark.Text.Trim();
            parkinfoModel.CompanyCode = txtCompanyCode.Text;
            parkinfoModel.OperatorName = LoginInfo.LoginName;
            parkinfoModel.AddTime = DateTime.Now;
            if (string.IsNullOrEmpty(flag))
            {
                if (CheckParkId())
                {
                    if (parkinfoBLL.Add(parkinfoModel))
                    {
                        //更新车辆类型
                        UpdateCarType(parkinfoModel.ParkID);
                        operatorModel = operatorBLL.GetModel(LoginInfo.Id);
                        operatorModel.ParkId = txtParkId.Text.Trim();
                        operatorBLL.Update(operatorModel);
                        LoginInfo.ParkId = txtParkId.Text.Trim();
                        bool isSuccess=true;
                        try
                        {
                            //将停车场信息上传到服务器端
                            Thread th = new Thread(UploadParkInfo);
                            th.IsBackground = true;
                            th.Start();
                        }
                        catch (Exception)
                        {
                            isSuccess=false;
                        }
                        parkinfoModel.IsUpload = isSuccess;
                        parkinfoBLL.Update(parkinfoModel);
                        www.gzwulian.com.Common.MessageHelper.ShowTips("车场信息添加成功！");
                        //DataBind();

                    }
                    else
                    {
                        www.gzwulian.com.Common.MessageHelper.ShowTips("添加失败");
                    }
                }
                else
                {
                    www.gzwulian.com.Common.MessageHelper.ShowTips("停车场编号已经存在!");
                }
            }

        }

        private void btnSelectPoint_Click(object sender, EventArgs e)
        {
            frmPointSelect frmselect = new frmPointSelect();
            DialogResult dr = frmselect.ShowDialog();
             if (dr == DialogResult.OK)
            {
                this.txtLon.Text = frmselect.Longitude;
                this.txtLat.Text = frmselect.Latitude;
            }
           
        }
        /// <summary>
        /// 更新车辆类型
        /// </summary>
        /// <param name="companycode"></param>
        private void UpdateCarType(string parkid)
        {
            www.gzwulian.com.BLL.CarTypeManager carTypeBLL = new CarTypeManager();
            List<CarType> carTypeList = carTypeBLL.GetModelList("");
            foreach (CarType carType in carTypeList)
            {
                carType.ParkId = parkid;
                carTypeBLL.Update(carType);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            operatorModel = operatorBLL.GetModel(LoginInfo.Id);
            parkId = operatorModel.ParkId;
            parkinfoModel = parkinfoBLL.GetModel(parkId);
            if (parkinfoModel!=null)
            {
                EditeParkInfo();
                AddWebOperator();
                AddWebCarType();
            }
            else
            {
                AddParkInfo();
                AddWebOperator();
                AddWebCarType();
            }
        }
        /// <summary>
        /// 向服务器传送停车场信息
        /// </summary>
        public void UploadParkInfo()
        {
            try
            {
                string values = txtCompanyCode.Text.Trim() + ',' + txtName.Text.Trim() + ',' + txtParkId.Text.Trim() + ',' +
               txtParkName.Text.Trim() + ',' + txtParkCity.Text.Trim() + ',' + txtParkCounty.Text.Trim() + ',' + txtParkStreet.Text.Trim() + ',' +
               txtParkOwner.Text.Trim() + ',' + txtParkType.Text.Trim() + ',' + txtLon.Text.Trim() + ',' + txtLat.Text.Trim() + ',' + txtSumBerthCount.Text.Trim() + ',' +
               txtBerthCount.Text.Trim() + ',' + txtFBerthCount.Text.Trim() + ',' + txtBusinessTime.Text.Trim() + ',' + txtOwnerTel.Text.Trim() + ',' + txtRemark.Text.Trim() + ',' + LoginInfo.LoginName + ',' + txtBerthCount.Text.Trim() + ',' + txtFBerthCount.Text.Trim();
                System.Net.WebClient wclient = new System.Net.WebClient();
                wclient.UploadString("http://zst.gzwulian.com/ClientService/HttpRequest/VehicParkInfo.ashx?paraStr=" + values, " ");
            }
            catch (Exception ex)
            {
                
            }
           
        }
        private WebCarTypeInfo.CarTypeInfo WebTypeBLL = new WebCarTypeInfo.CarTypeInfo();
        private CarTypeManager carTypeBLL = new CarTypeManager();
        private WebCarTypeInfo.CarType webCarTypeModel = null;
        /// <summary>
        /// 添加车辆类型到服务端
        /// </summary>
        /// <param name="model"></param>
        private void AddWebCarType()
        {
            List<www.gzwulian.com.Model.CarType> modelList = carTypeBLL.GetModelList("");
            if (modelList.Count > 0)
            {
                foreach (www.gzwulian.com.Model.CarType model in modelList)
                {
                    //向服务端添加结算信息
                    bool isSuccess = true;
                    try
                    {
                        webCarTypeModel = new WebCarTypeInfo.CarType();
                        webCarTypeModel = ModelTrans.GetWebCarTypeModel(model);
                        WebTypeBLL.Add(webCarTypeModel);
                    }
                    catch (Exception)
                    {
                        isSuccess = false;
                    }
                    model.IsUpload = isSuccess;
                    carTypeBLL.Update(model);
                }

            }

        }
        private WebOperatorInfo.OperatorInfo webOprBLL = new WebOperatorInfo.OperatorInfo();
        private WebOperatorInfo.Operator webOprModel = null;
        /// <summary>
        /// 添加操作员信息到服务端
        /// </summary>
        public void AddWebOperator()
        {
            List<www.gzwulian.com.Model.Operator> operatorModelList = operatorBLL.GetModelList("");
            if (operatorModelList.Count > 0)
            {
                foreach (www.gzwulian.com.Model.Operator model in operatorModelList)
                {
                    if ((!string.IsNullOrEmpty(model.CompanyCode) && (!string.IsNullOrEmpty(model.ParkId))))
                    {
                        bool isSuccess = true;
                        try
                        {
                            WebOperatorInfo.OperatorInfo opeBLL = new WebOperatorInfo.OperatorInfo();
                            webOprModel = ModelTrans.GetWebOpeModel(model);
                            webOprBLL.Add(webOprModel);
                        }
                        catch (Exception er)
                        {
                            isSuccess = false;
                            er.Message.ToString();
                        }

                        model.IsUpload = isSuccess;
                        operatorBLL.Update(model);
                    }

                }

            }
        }

        private void txtDigit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

       
    }
}
