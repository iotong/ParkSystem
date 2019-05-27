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
using Company = www.gzwulian.com.Model.Company;

namespace ChargeWin
{
    public partial class frmCompany : Form
    {
        www.gzwulian.com.BLL.CompanyManager companyBll = new CompanyManager();
        www.gzwulian.com.Model.Company companyModel = new Company();
        string companyCode ;
        Operator operatorModel = new Operator();
        private OperatorManager operatorBLL = new OperatorManager(); 
        public frmCompany()
        {
            InitializeComponent();
            operatorModel = operatorBLL.GetModel(LoginInfo.Id);
            companyCode = operatorModel.CompanyCode;
        }
        /// <summary>
        /// 更新车辆类型
        /// </summary>
        /// <param name="companycode"></param>
        private void UpdateCarType(string companycode)
        {
            www.gzwulian.com.BLL.CarTypeManager carTypeBLL=new CarTypeManager();
            List<CarType> carTypeList = carTypeBLL.GetModelList("");
            foreach (CarType carType in carTypeList)
            {
                carType.CompanyCode = companycode;
                carTypeBLL.Update(carType);
            }
        }

        #region 把公司信息传回服务器端
        /// <summary>
        /// 将公司信息上传到服务器端
        /// </summary>
        public void UploadComInfo()
        {
            
            string values = txtCompanyCode.Text.Trim()+ ',' +txtShortName.Text.Trim()+ ',' + txtName.Text.Trim() + ',' + txtAddress.Text.Trim() + ',' + txtServiceTel.Text.Trim() + ',' +
                           txtContact.Text.Trim()  + ',' + txtContactTel.Text.Trim() 
               + ',' + txtProvince.Text.Trim()  + ',' + txtCity.Text.Trim() + ',' + txtArea.Text.Trim()
               + ',' + LoginInfo.LoginName + ',' + DateTime.Now;
            System.Net.WebClient wclient = new System.Net.WebClient();
            try
            {
                wclient.UploadString("http://zst.gzwulian.com/ClientService/HttpRequest/UploadComInfo.ashx?paraStr=" + values, " ");
            }
            catch (Exception)
            {

            }
           
        }
        #endregion
        private void btnSave_Click(object sender, EventArgs e)
        {
            

            operatorModel = operatorBLL.GetModel(LoginInfo.Id);
            companyCode = operatorModel.CompanyCode;
            companyModel = companyBll.GetModel(companyCode);
            
            if (companyModel==null)
            {

                AddComInfo();
            }
            else
            {
               
                EditComInfo();
            }
           
        }
        private void frmCompany_Load(object sender, EventArgs e)
        {
            
            InitComInfo();

        }
        /// <summary>
        /// 初始化经营单位信息
        /// </summary>
        private void InitComInfo()
        {

            if (!string.IsNullOrWhiteSpace(companyCode))
            {
                companyModel = companyBll.GetModel(companyCode);
                if (companyModel!=null)
                {
                    txtCompanyCode.Text = companyModel.CompanyCode;
                    txtCompanyCode.Enabled = false;
                    txtName.Text = companyModel.Name;
                    txtShortName.Text = companyModel.ShortName;
                    txtAddress.Text = companyModel.Address;
                    txtServiceTel.Text = companyModel.ServiceTel;
                    txtContact.Text = companyModel.Contact;
                    txtContactTel.Text = companyModel.ContactTel;
                    txtProvince.Text = companyModel.Province;
                    txtCity.Text = companyModel.City;
                    txtArea.Text = companyModel.Area;
                }
    
            }
          
        }
        /// <summary>
        /// 编辑经营单位信息
        /// </summary>
        private void EditComInfo()
        {
            companyModel = companyBll.GetModel(companyCode);
            if (companyModel!=null)
            {

                CheckInput();
                if (!string.IsNullOrEmpty(flag))
                {
                    return;
                }
                companyModel.Name = txtName.Text.Trim();
                if (!string.IsNullOrEmpty(txtShortName.Text.Trim()))
                {
                    companyModel.ShortName = txtShortName.Text.Trim();
                }
                if (!string.IsNullOrEmpty(txtAddress.Text.Trim()))
                {
                    companyModel.Address = txtAddress.Text.Trim();
                }
                if (!string.IsNullOrEmpty(txtServiceTel.Text.Trim()))
                {
                    companyModel.ServiceTel = txtServiceTel.Text.Trim();
                }
                if (!string.IsNullOrEmpty(txtContact.Text.Trim()))
                {
                    companyModel.Contact = txtContact.Text.Trim();
                }
                if (!string.IsNullOrEmpty(txtContactTel.Text.Trim()))
                {
                    companyModel.ContactTel = txtContactTel.Text.Trim();
                }
                if (!string.IsNullOrEmpty(txtProvince.Text.Trim()))
                {
                    companyModel.Province = txtProvince.Text.Trim();
                }
                if (!string.IsNullOrEmpty(txtCity.Text.Trim()))
                {
                    companyModel.City = txtCity.Text.Trim();
                }
                if (!string.IsNullOrEmpty(txtArea.Text.Trim()))
                {
                    companyModel.Area = txtArea.Text.Trim();
                }
                companyModel.UpdateTime = DateTime.Now;
                if (string.IsNullOrEmpty(flag))
                {
                    if (companyBll.Update(companyModel))
                    {
                        LoginInfo.CompanyCode = companyModel.CompanyCode;
                        bool isSuccess = true;
                        try
                        {
                            //将公司信息上传到服务器
                            Thread th = new Thread(UploadComInfo);
                            th.IsBackground = true;
                            th.Start(); 
                        }
                        catch (Exception)
                        {
                            isSuccess = false;
                        }
                        companyModel.IsUpload = isSuccess;
                        companyBll.Update(companyModel);
                       MessageHelper.ShowTips("信息修改成功！");
                    }
                    else
                    {
                        MessageHelper.ShowTips("信息修改失败！");
                    }

                }
               
            }
        }

        private string flag = string.Empty;
        /// <summary>
        /// 检查输入
        /// </summary>
        private void CheckInput()
        {
            flag = string.Empty;
            if (string.IsNullOrWhiteSpace(txtCompanyCode.Text))
            {
                flag = "请输入经营单位编码！";
                MessageHelper.ShowWarning(flag);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                flag = "请输入经营单位名称";
                MessageHelper.ShowWarning(flag);
                return;
            }
            if (!string.IsNullOrWhiteSpace(txtContactTel.Text))
            {
                Regex regMobileRegex = new Regex("^[1][3-8]\\d{9}$");     //电话
                if (!regMobileRegex.IsMatch(this.txtContactTel.Text))
                {
                    flag = "请正确输入11位手机号！";
                    MessageHelper.ShowWarning(flag);
                    return;
                }
            }
          
        }

        /// <summary>
        /// 添加经营单位信息
        /// </summary>
        private void AddComInfo()
        {
            CheckInput();
            if (!string.IsNullOrEmpty(flag))
            {
                return;
            }
            companyModel = new Company();
            companyModel.CompanyCode = txtCompanyCode.Text;
            companyModel.Name = txtName.Text.Trim();
            if (!string.IsNullOrEmpty(txtShortName.Text.Trim()))
            {
                companyModel.ShortName = txtShortName.Text.Trim();
            }
            if (!string.IsNullOrEmpty(txtAddress.Text.Trim()))
            {
                companyModel.Address = txtAddress.Text.Trim();
            }
            if (!string.IsNullOrEmpty(txtServiceTel.Text.Trim()))
            {
                companyModel.ServiceTel = txtServiceTel.Text.Trim();
            }
            if (!string.IsNullOrEmpty(txtContact.Text.Trim()))
            {
                companyModel.Contact = txtContact.Text.Trim();
            }
            if (!string.IsNullOrEmpty(txtContactTel.Text.Trim()))
            {
                companyModel.ContactTel = txtContactTel.Text.Trim();
            }
            if (!string.IsNullOrEmpty(txtProvince.Text.Trim()))
            {
                companyModel.Province = txtProvince.Text.Trim();
            }
            if (!string.IsNullOrEmpty(txtCity.Text.Trim()))
            {
                companyModel.City = txtCity.Text.Trim();
            }
            if (!string.IsNullOrEmpty(txtArea.Text.Trim()))
            {
                companyModel.Area = txtArea.Text.Trim();
            }
            companyModel.UpdateTime = DateTime.Now;

           


             if (string.IsNullOrEmpty(flag))
            {
              
                if (companyBll.Add(companyModel))
                {
                    operatorModel = operatorBLL.GetModel(LoginInfo.Id);
                    operatorModel.CompanyCode = txtCompanyCode.Text.Trim();
                    operatorBLL.Update(operatorModel);
                    LoginInfo.CompanyCode = txtCompanyCode.Text.Trim();
                    bool isSuccess = true;
                    try
                    {
                        //将公司信息上传到服务器
                        Thread th = new Thread(UploadComInfo);
                        th.IsBackground = true;
                        th.Start(); 
                    }
                    catch (Exception )
                    {
                        isSuccess = false;
                    }
                    companyModel.IsUpload = isSuccess;
                    bool f=  companyBll.Update(companyModel);
                    if (f)
                    {
                        UpdateCarType(txtCompanyCode.Text); 
                    }
                    www.gzwulian.com.Common.MessageHelper.ShowTips("信息添加成功！");

                }
                else
                {
                    MessageHelper.ShowTips("信息添加失败！");
                }  
            }
          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmMain frmmain;
            frmmain = (frmMain)this.Owner;
            frmmain.CloseWin();
        }

    }
}
