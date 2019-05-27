using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using www.gzwulian.com.Common;
using Bll = www.gzwulian.com.BLL;
using Model = www.gzwulian.com.Model;
using System.Text.RegularExpressions;
using ChargeWin;
using ChargeWin;

namespace ChargeWin
{
    public partial class frmOperatorMagAdd : Form
    {
        public frmOperatorMagAdd()
        {
            InitializeComponent();
        }

        Bll.OperatorManager bllOpMag = new Bll.OperatorManager();

        Model.Operator modelOpMag = new Model.Operator();
        private Bll.RightsGroupManager rightsGroupBLL = new Bll.RightsGroupManager();
        private Model.RightsGroup rightsGroupModel = new Model.RightsGroup();
        int UpdateId;
        public bool Istrue;
        private Dictionary<string, int> roleDic = new Dictionary<string, int>();
        WebOperatorInfo.Operator opModel = null;//服务端实体
        public frmOperatorMagAdd(string State, int ID)
        {
            InitializeComponent();
            if (State == "添加")
            {
                this.Text = "添加操作员";
                this.tbxParkId.Text =LoginInfo.ParkId;
                this.tbxCompanyCode.Text = LoginInfo.CompanyCode;
                this.btnUpdate.Visible = false;
                this.lblParkId.Enabled = false;
                this.tbxParkId.Enabled = false;
                this.lblCompanyCode.Enabled = false;
                this.tbxCompanyCode.Enabled = false;
                lblAddTime.Visible = false;
                dtpAddTime.Visible = false;
                BindRoles();
            }
            else if (State == "修改")
            {
                this.Text = "修改操作员信息";
                this.btnAdd.Visible = false;
                btnUpdate.Location = new Point(112,272);
                this.tbxPassword.Enabled = false;
                this.tbxOperatorName.Enabled = false;
                this.tbxParkId.Enabled = false;
                this.tbxCompanyCode.Enabled = false;
                UpdateId = ID;
                modelOpMag = bllOpMag.GetModel(this.UpdateId);
                BindRoles();
                UpdateLoad();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private www.gzwulian.com.Model.RightsGroup GetModelByRoleName()
        {
            rightsGroupModel = rightsGroupBLL.GetModelList("GroupName=" + "'" + cbRoleList.Text + "'").First();
            return rightsGroupModel;
        }

        //添加操作员
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.cbRoleList.Text == "超级管理员")
            {
                MessageHelper.ShowTips("角色不能设置为超级管理员！");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.tbxOperatorName.Text))
            {
                MessageHelper.ShowTips("请输入操作员登录名称！");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.tbxPassword.Text))
            {
                MessageHelper.ShowTips("请输入登录密码！");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.tbxRealName.Text))
            {
                MessageHelper.ShowTips("请输入真实姓名！");
                return;
            }
            //if (string.IsNullOrWhiteSpace(this.tbxParkId.Text))
            //{
            //    MessageHelper.ShowTips("请输入车场编号！");
            //    return;
            //}

            modelOpMag.OperatorName = this.tbxOperatorName.Text;
            modelOpMag.Password = CEncoder.Encode(this.tbxPassword.Text);
            modelOpMag.RealName = this.tbxRealName.Text;
            if (rdbtnN.Checked)
            {
                modelOpMag.Gender = this.rdbtnN.Text;
            }
            else if (rdbtnV.Checked)
            {
                modelOpMag.Gender = this.rdbtnV.Text;
            }
            else
            {
                MessageHelper.ShowTips("请选择性别!");
                return;
            }
            rightsGroupModel = GetModelByRoleName();
            if (rightsGroupModel!=null)
            {
                modelOpMag.GroupId = rightsGroupModel.Id;
            }
            modelOpMag.ParkId =LoginInfo.ParkId;
            modelOpMag.CompanyCode = LoginInfo.CompanyCode;
            modelOpMag.TelPhone = this.tbxTelphone.Text;
            modelOpMag.AddTime = this.dtpAddTime.Value;
            modelOpMag.State = this.cbkState.Checked;

            try
            {
                int rows = bllOpMag.Add(modelOpMag);
                if (rows > 0)
                {
                    MessageBox.Show("数据添加成功。", "提示");
                    Istrue = true;
                    //将操作员上传到服务器端
                    UploadOperator(modelOpMag);
  
                    this.Close();
                }
                else
                    MessageBox.Show("数据添加失败,请检查后重试。", "错误");

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 将添加或修改的操作员上传到服务器端
        /// </summary>
        /// <param name="model"></param>
        private void UploadOperator(www.gzwulian.com.Model.Operator model)
        { 
          #region 将操作员上传到服务器端
		          bool isSuccess = true;
                    try
                    {
                        WebOperatorInfo.OperatorInfo opeBLL = new WebOperatorInfo.OperatorInfo();
                        opModel = ModelTrans.GetWebOpeModel(model);
                        opeBLL.Add(opModel);
                    }
                    catch(Exception er)
                    {
                       isSuccess=false;
                       er.Message.ToString();
                    }

                    model.IsUpload=isSuccess;
                    bllOpMag.Update(model); 
	                #endregion
        }
        /// <summary>
        /// 获得服务端实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private WebOperatorInfo.Operator GetWebOpeModel(www.gzwulian.com.Model.Operator model)
        {
            opModel = new WebOperatorInfo.Operator();
            opModel.AddTime = model.AddTime;
            opModel.CompanyCode = model.CompanyCode;
            opModel.GroupId = model.GroupId;
            opModel.Id = model.Id;
            opModel.IsUpload = model.IsUpload;
            opModel.OperatorName = model.OperatorName;
            opModel.ParkId = model.ParkId;
            opModel.Password = model.Password;
            opModel.RealName = model.RealName;
            opModel.RightsList = model.RightsList;
            opModel.State = model.State;
            opModel.TelPhone = model.TelPhone;
            return opModel;
        }
       /// <summary>
        /// 绑定角色
       /// </summary>
        private void BindRoles()
        {
            DataSet ds = rightsGroupBLL.GetAllList();
            cbRoleList.DisplayMember = "GroupName";
            cbRoleList.ValueMember = "GroupName";
            cbRoleList.DataSource = ds.Tables[0].DefaultView;
            //初始化字典
            List<Model.RightsGroup> list=rightsGroupBLL.DataTableToList(ds.Tables[0]);
           foreach (Model.RightsGroup rightsGroup in list)
           {
               roleDic.Add(rightsGroup.GroupName,rightsGroup.Id);
           }

        }
        private void frmOperatorMagAdd_Load(object sender, EventArgs e)
        {
           
        }

        void UpdateLoad()
        {
            this.tbxOperatorName.Text = modelOpMag.OperatorName;
            this.tbxPassword.Text = modelOpMag.Password;
            this.tbxRealName.Text = modelOpMag.RealName;
            if (modelOpMag.Gender == "男")
                this.rdbtnN.Checked = true;
            else if (modelOpMag.Gender == "女")
                this.rdbtnV.Checked = true;

            this.tbxParkId.Text = modelOpMag.ParkId;
            this.tbxCompanyCode.Text = modelOpMag.CompanyCode;
            this.tbxTelphone.Text = modelOpMag.TelPhone;
            this.dtpAddTime.Text = modelOpMag.AddTime.ToString() ?? "";
            this.cbkState.Checked = modelOpMag.State;
            int groupId = modelOpMag.GroupId ?? 0;
            rightsGroupModel = rightsGroupBLL.GetModel(groupId);
            if (rightsGroupModel != null)
            {
                this.cbRoleList.Text = rightsGroupModel.GroupName;
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (tbxOperatorName.Text.Trim()=="admin")
            {
                if (this.cbRoleList.Text != "管理员")
                {
                    MessageHelper.ShowTips("不能修改管理员【admin】的角色");
                    return;
                }
                
            }
            if (this.cbRoleList.Text=="超级管理员")
            {
                MessageHelper.ShowTips("角色不能设置为超级管理员！");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.tbxOperatorName.Text))
            {

                MessageBox.Show(this, "请输入操作员登录名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            if (string.IsNullOrWhiteSpace(this.cbRoleList.Text))
            {

                MessageBox.Show(this, "请输选择角色！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            if (string.IsNullOrWhiteSpace(this.tbxPassword.Text))
            {
                MessageBox.Show(this, "请输入登录密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(this.tbxRealName.Text))
            {
                MessageBox.Show(this, "请输入真实姓名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(this.tbxParkId.Text))
            {
                MessageBox.Show(this, "请输入车场编号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            modelOpMag.RealName = this.tbxRealName.Text;
            if (rdbtnN.Checked)
                modelOpMag.Gender = this.rdbtnN.Text;
            else if (rdbtnV.Checked)
                modelOpMag.Gender = this.rdbtnV.Text;
            modelOpMag.ParkId = this.tbxParkId.Text;
            modelOpMag.CompanyCode = this.tbxCompanyCode.Text;
            modelOpMag.TelPhone = this.tbxTelphone.Text;
            modelOpMag.AddTime = this.dtpAddTime.Value;
            modelOpMag.State = this.cbkState.Checked;
            modelOpMag.GroupId = roleDic[cbRoleList.Text];

            try
            {
                bool rows = bllOpMag.Update(modelOpMag);
                if (rows)
                {
                    MessageBox.Show("数据修改成功。", "提示");
                    this.Istrue = rows;
                    //将操作员上传到服务器端
                    UploadOperator(modelOpMag);
                    this.Close();
                }
                else
                    MessageBox.Show("数据修改失败,请检查后重试。", "错误");

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

        private void tbxTelphone_Leave(object sender, EventArgs e)
        {
               
                Regex regMobileRegex = new Regex("^[1][3-8]\\d{9}$");     //电话
                if (!regMobileRegex.IsMatch(this.tbxTelphone.Text))
                {
                    MessageBox.Show(this, "错误，请输入正确的11位手机号.", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
        }

    }
}


