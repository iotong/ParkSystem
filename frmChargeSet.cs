using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ChargeWin.WebStandardInfo;
using www.gzwulian.com.BLL;
using www.gzwulian.com.Common;
using www.gzwulian.com.Model;
using FeeStandard = www.gzwulian.com.Model.FeeStandard;
using ChargeWin;
using ChargeWin;

namespace ChargeWin
{
    public partial class frmChargeSet : Form
    {
        public frmChargeSet()
        {
            InitializeComponent();

        }

        private www.gzwulian.com.Model.FeeStandard feeModel = new FeeStandard();
        private www.gzwulian.com.BLL.FeeStandardManager feeBLL = new FeeStandardManager();
        private  www.gzwulian.com.BLL.CarTypeManager  carBLL=new CarTypeManager();
        Dictionary<string,string> dic=new Dictionary<string,string>();
        private WebStandardInfo.StandardInfo standardInfo = new StandardInfo();
        private CarTypeManager carTypeBLL = new CarTypeManager();

        private void frmChargeSet_Load(object sender, EventArgs e)
        {
            DataSet ds = carBLL.GetAllList();
            BindDic();
            cbCarType.DisplayMember = "CarTypeName";
            cbCarType.DataSource = ds.Tables[0].DefaultView;
            rdSetTime.Checked = true;
            gbStandard.Visible = false;

            //2017.2.15  jian 打开时调入默认设置 
            FeeStandard feeStandardModel = GetChargeStandardByCarType("小型车");
            string  feeStandard = feeStandardModel.FeeType;
           // MessageBox.Show(feeStandard);

            selefeeStandard(feeStandard);
        }

        public void selefeeStandard(string feeType)
        {

            if (feeType == "按设定时间收费")
            {
                //if (IsExistFeeType(rd.Text, cbCarType.Text))
                //{
                //    InitInfo(rd.Text, cbCarType.Text);
                //    txtFeetop.Text = feeModel.Feetop.ToString();
                //    txtFreeMinutes.Text = feeModel.FreeMinutes.ToString();
                //    txtSTTimeUnie.Text = feeModel.STTimeUnie.ToString();
                //    txtSTUnieFee.Text = feeModel.STUnieFee.ToString();
                //    txtSTOverNightFee.Text = feeModel.STOverNightFee.ToString();
                //}
                InitInfo(feeType, cbCarType.Text);
                txtFeetop.Text = feeModel.Feetop.ToString();
                txtFreeMinutes.Text = feeModel.FreeMinutes.ToString();
                txtSTTimeUnie.Text = feeModel.STTimeUnie.ToString();
                txtSTUnieFee.Text = feeModel.STUnieFee.ToString();
                txtSTOverNightFee.Text = feeModel.STOverNightFee.ToString();
                txtFeetop.Enabled = true;
                panel1.Controls.Clear();
                panel1.Controls.Add(gbFeeSet);
                gbFeeSet.Visible = true;
                gbFeeSet.Location = new Point(3, 5);
                gbStandard.Visible = false;
                gbDayNight.Visible = false;
                gbPerView.Visible = false;
                rdSetTime.Checked = true;

            }
            else if (feeType == "标准收费")
            {
                txtFeetop.Text = "";
                txtFeetop.Enabled = false;
                panel1.Controls.Clear();
                panel1.Controls.Add(gbStandard);
                gbDayNight.Visible = false;
                gbFeeSet.Visible = false;
                gbPerView.Visible = false;
                gbStandard.Visible = true;
                gbStandard.Location = new Point(3, 5);
                //if (IsExistFeeType(rd.Text, cbCarType.Text))
                //{
                //    InitInfo(rd.Text, cbCarType.Text);
                //    txtFreeMinutes.Text = feeModel.FreeMinutes.ToString();
                //    string standardfee = feeModel.StandardFee;
                //    string[] fee = standardfee.Split(',');
                //    DataTable dt = new DataTable();
                //    dt.Columns.Add("ParkTime");
                //    dt.Columns.Add("ParkFee");

                //    for (int i = 0; i < fee.Length; i++)
                //    {
                //        DataRow ndr = dt.NewRow();
                //        ndr["ParkTime"] = i + 1;
                //        ndr["ParkFee"] = fee[i];
                //        dt.Rows.Add(ndr);
                //    }
                //    dgvFee.Rows.Clear();
                //    //dgvFee.AutoGenerateColumns = false;
                //    foreach (DataRow dr in dt.Rows)
                //    {
                //        dgvFee.Rows.Add(dr["ParkTime"], dr["ParkFee"]);
                //    }

                //}
                InitInfo(feeType, cbCarType.Text);
                txtFreeMinutes.Text = feeModel.FreeMinutes.ToString();
                string standardfee = feeModel.StandardFee;
                if (string.IsNullOrEmpty(standardfee))
                {
                    standardfee = "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24";
                }
                string[] fee = standardfee.Split(',');
                DataTable dt = new DataTable();
                dt.Columns.Add("ParkTime");
                dt.Columns.Add("ParkFee");

                for (int i = 0; i < fee.Length; i++)
                {
                    DataRow ndr = dt.NewRow();
                    ndr["ParkTime"] = i + 1;
                    ndr["ParkFee"] = fee[i];
                    dt.Rows.Add(ndr);
                }
                dgvFee.Rows.Clear();
                //dgvFee.AutoGenerateColumns = false;
                foreach (DataRow dr in dt.Rows)
                {
                    dgvFee.Rows.Add(dr["ParkTime"], dr["ParkFee"]);
                }
                rdStandard.Checked = true;
            }
            else if (feeType == "按设定时间段收费")
            {
                panel1.Controls.Clear();
                panel1.Controls.Add(gbDayNight);
                txtFeetop.Enabled = true;
                gbDayNight.Visible = true;
                gbDayNight.Location = new Point(3, 5);
                gbFeeSet.Visible = false;
                gbStandard.Visible = false;
                gbPerView.Visible = false;
                DataTable dt = new DataTable();
                List<string> itermList = new List<string>();
                itermList.Add("开始小时");
                itermList.Add("开始分钟");
                itermList.Add("计时单位(分钟)");
                itermList.Add("单位收费额(元)");
                itermList.Add("最高收费(元)");
                itermList.Add("最低收费(元)");
                dt.Columns.Add("Iterm");
                dt.Columns.Add("Day");
                dt.Columns.Add("Night");
                foreach (string value in itermList)
                {
                    DataRow ndr = dt.NewRow();
                    ndr["Iterm"] = value;
                    ndr["Day"] = null;
                    ndr["Night"] = null;
                    dt.Rows.Add(ndr);
                }
                dgvDayNight.Rows.Clear();
                txtFeetop.Text = feeModel.Feetop.ToString();
                //dgvFee.AutoGenerateColumns = false;
                foreach (DataRow dr in dt.Rows)
                {
                    dgvDayNight.Rows.Add(dr["Iterm"], dr["Day"], dr["Night"]);
                }
                if (IsExistFeeType(feeType, cbCarType.Text))
                {
                    InitInfo(feeType, cbCarType.Text);
                    txtFreeMinutes.Text = feeModel.FreeMinutes.ToString();
                    //初始化已添加的数据
                    dgvDayNight.Rows[0].Cells["Day"].Value = feeModel.DayStartHour;
                    dgvDayNight.Rows[1].Cells["Day"].Value = feeModel.DayStartMinute;
                    dgvDayNight.Rows[2].Cells["Day"].Value = feeModel.DayTimeUnit;
                    dgvDayNight.Rows[3].Cells["Day"].Value = feeModel.DayUnitFee;
                    dgvDayNight.Rows[4].Cells["Day"].Value = feeModel.DayTopFee;
                    dgvDayNight.Rows[5].Cells["Day"].Value = feeModel.DayLowestFee;
                    dgvDayNight.Rows[0].Cells["Night"].Value = feeModel.NightStartHour;
                    dgvDayNight.Rows[1].Cells["Night"].Value = feeModel.NightStartMinute;
                    dgvDayNight.Rows[2].Cells["Night"].Value = feeModel.NightTimeUnit;
                    dgvDayNight.Rows[3].Cells["Night"].Value = feeModel.NightUnitFee;
                    dgvDayNight.Rows[4].Cells["Night"].Value = feeModel.NightTopFee;
                    dgvDayNight.Rows[5].Cells["Night"].Value = feeModel.NightLowestFee;
                }
                rdDayNight.Checked = true;

            }
            else if (feeType == "按次收费")
            {
                txtFeetop.Text = "";
                txtFeetop.Enabled = false;
                gbDayNight.Visible = false;
                gbFeeSet.Visible = false;
                gbStandard.Visible = false;
                gbPerView.Visible = true;
                gbPerView.Location = new Point(3, 5);
                panel1.Controls.Add(gbPerView);
                if (IsExistFeeType(feeType, cbCarType.Text))
                {
                    InitInfo(feeType, cbCarType.Text);
                    txtFreeMinutes.Text = feeModel.FreeMinutes.ToString();
                    txtPerViewFee.Text = feeModel.FeePerView.ToString();
                }
                rdPerView.Checked = true;
            }



    }

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

        private void BindDic()
        {
            if (dic!=null)
            {
                dic.Clear();
            }
            DataSet ds = carBLL.GetAllList();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string CarTypeName = ds.Tables[0].Rows[i]["CarTypeName"].ToString();
                    int chargeId = (int)ds.Tables[0].Rows[i]["ChargeId"];
                    feeModel = feeBLL.GetModel(chargeId);
                    if (feeModel != null)
                    {
                        dic.Add(CarTypeName, feeModel.FeeType);
                    }
                    else
                    {
                        dic.Add(CarTypeName, "");
                    }

                }

            }
        }

        private void InitInfo(string feetype,string cartype)
        {
            string strWhere = "FeeType=" + "'" + feetype + "'" + "and CarType=" + "'" + cartype + "'";
            DataSet ds = feeBLL.GetList(strWhere);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                int Id = (int) dt.Rows[0]["Id"];
                feeModel = feeBLL.GetModel(Id);
            }
            else
            {
                feeModel=new FeeStandard();
            }

        }

        private void rdSetTime_CheckedChanged(object sender, EventArgs e)
        {
            if (feeModel != null)
            {
                txtFreeMinutes.Text = feeModel.FreeMinutes.ToString();
            }
            foreach (RadioButton rd in gbType.Controls)
            {
                InitInfo(rd.Text, cbCarType.Text);
                if (rd.Checked == true)
                {
                    if (rd.Text == "按设定时间收费")
                    {
                        //if (IsExistFeeType(rd.Text, cbCarType.Text))
                        //{
                        //    InitInfo(rd.Text, cbCarType.Text);
                        //    txtFeetop.Text = feeModel.Feetop.ToString();
                        //    txtFreeMinutes.Text = feeModel.FreeMinutes.ToString();
                        //    txtSTTimeUnie.Text = feeModel.STTimeUnie.ToString();
                        //    txtSTUnieFee.Text = feeModel.STUnieFee.ToString();
                        //    txtSTOverNightFee.Text = feeModel.STOverNightFee.ToString();
                        //}
                        InitInfo(rd.Text, cbCarType.Text);
                        txtFeetop.Text = feeModel.Feetop.ToString();
                        txtFreeMinutes.Text = feeModel.FreeMinutes.ToString();
                        txtSTTimeUnie.Text = feeModel.STTimeUnie.ToString();
                        txtSTUnieFee.Text = feeModel.STUnieFee.ToString();
                        txtSTOverNightFee.Text = feeModel.STOverNightFee.ToString();
                        txtFeetop.Enabled = true;
                        panel1.Controls.Clear();
                        panel1.Controls.Add(gbFeeSet);
                        gbFeeSet.Visible = true;
                        gbFeeSet.Location = new Point(3, 5);
                        gbStandard.Visible = false;
                        gbDayNight.Visible = false;
                        gbPerView.Visible = false;

                    }
                    else if (rd.Text == "标准收费")
                    {
                        txtFeetop.Text ="";
                        txtFeetop.Enabled = false;
                        panel1.Controls.Clear();
                        panel1.Controls.Add(gbStandard);
                        gbDayNight.Visible = false;
                        gbFeeSet.Visible = false;
                        gbPerView.Visible = false;
                        gbStandard.Visible = true;
                        gbStandard.Location=new Point(3,5);
                        //if (IsExistFeeType(rd.Text, cbCarType.Text))
                        //{
                        //    InitInfo(rd.Text, cbCarType.Text);
                        //    txtFreeMinutes.Text = feeModel.FreeMinutes.ToString();
                        //    string standardfee = feeModel.StandardFee;
                        //    string[] fee = standardfee.Split(',');
                        //    DataTable dt = new DataTable();
                        //    dt.Columns.Add("ParkTime");
                        //    dt.Columns.Add("ParkFee");

                        //    for (int i = 0; i < fee.Length; i++)
                        //    {
                        //        DataRow ndr = dt.NewRow();
                        //        ndr["ParkTime"] = i + 1;
                        //        ndr["ParkFee"] = fee[i];
                        //        dt.Rows.Add(ndr);
                        //    }
                        //    dgvFee.Rows.Clear();
                        //    //dgvFee.AutoGenerateColumns = false;
                        //    foreach (DataRow dr in dt.Rows)
                        //    {
                        //        dgvFee.Rows.Add(dr["ParkTime"], dr["ParkFee"]);
                        //    }

                        //}
                        InitInfo(rd.Text, cbCarType.Text);
                        txtFreeMinutes.Text = feeModel.FreeMinutes.ToString();
                        string standardfee = feeModel.StandardFee;
                        if (string.IsNullOrEmpty(standardfee))
                        {
                            standardfee = "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24";
                        }
                        string[] fee = standardfee.Split(',');
                        DataTable dt = new DataTable();
                        dt.Columns.Add("ParkTime");
                        dt.Columns.Add("ParkFee");

                        for (int i = 0; i < fee.Length; i++)
                        {
                            DataRow ndr = dt.NewRow();
                            ndr["ParkTime"] = i + 1;
                            ndr["ParkFee"] = fee[i];
                            dt.Rows.Add(ndr);
                        }
                        dgvFee.Rows.Clear();
                        //dgvFee.AutoGenerateColumns = false;
                        foreach (DataRow dr in dt.Rows)
                        {
                            dgvFee.Rows.Add(dr["ParkTime"], dr["ParkFee"]);
                        }
                    }
                    else if (rd.Text == "按设定时间段收费")
                    {
                        panel1.Controls.Clear();
                        panel1.Controls.Add(gbDayNight);
                        txtFeetop.Enabled = true;
                        gbDayNight.Visible = true;
                        gbDayNight.Location = new Point(3, 5);
                        gbFeeSet.Visible = false;
                        gbStandard.Visible = false;
                        gbPerView.Visible = false;
                        DataTable dt = new DataTable();
                        List<string> itermList = new List<string>();
                        itermList.Add("开始小时");
                        itermList.Add("开始分钟");
                        itermList.Add("计时单位(分钟)");
                        itermList.Add("单位收费额(元)");
                        itermList.Add("最高收费(元)");
                        itermList.Add("最低收费(元)");
                        dt.Columns.Add("Iterm");
                        dt.Columns.Add("Day");
                        dt.Columns.Add("Night");
                        foreach (string value in itermList)
                        {
                            DataRow ndr = dt.NewRow();
                            ndr["Iterm"] = value;
                            ndr["Day"] = null;
                            ndr["Night"] = null;
                            dt.Rows.Add(ndr);
                        }
                        dgvDayNight.Rows.Clear();
                        txtFeetop.Text = feeModel.Feetop.ToString();
                        //dgvFee.AutoGenerateColumns = false;
                        foreach (DataRow dr in dt.Rows)
                        {
                            dgvDayNight.Rows.Add(dr["Iterm"], dr["Day"], dr["Night"]);
                        }
                        if (IsExistFeeType(rd.Text, cbCarType.Text))
                        {
                            InitInfo(rd.Text, cbCarType.Text);
                            txtFreeMinutes.Text = feeModel.FreeMinutes.ToString();
                            //初始化已添加的数据
                            dgvDayNight.Rows[0].Cells["Day"].Value = feeModel.DayStartHour;
                            dgvDayNight.Rows[1].Cells["Day"].Value = feeModel.DayStartMinute;
                            dgvDayNight.Rows[2].Cells["Day"].Value = feeModel.DayTimeUnit;
                            dgvDayNight.Rows[3].Cells["Day"].Value = feeModel.DayUnitFee;
                            dgvDayNight.Rows[4].Cells["Day"].Value = feeModel.DayTopFee;
                            dgvDayNight.Rows[5].Cells["Day"].Value = feeModel.DayLowestFee;
                            dgvDayNight.Rows[0].Cells["Night"].Value = feeModel.NightStartHour;
                            dgvDayNight.Rows[1].Cells["Night"].Value = feeModel.NightStartMinute;
                            dgvDayNight.Rows[2].Cells["Night"].Value = feeModel.NightTimeUnit;
                            dgvDayNight.Rows[3].Cells["Night"].Value = feeModel.NightUnitFee;
                            dgvDayNight.Rows[4].Cells["Night"].Value = feeModel.NightTopFee;
                            dgvDayNight.Rows[5].Cells["Night"].Value = feeModel.NightLowestFee;
                        }
                      
                    }
                    else if(rd.Text == "按次收费")
                    {
                        txtFeetop.Text = "";
                        txtFeetop.Enabled = false;
                        gbDayNight.Visible = false;
                        gbFeeSet.Visible = false;
                        gbStandard.Visible = false;
                        gbPerView.Visible = true;
                        gbPerView.Location=new Point(3,5);
                        panel1.Controls.Add(gbPerView);
                        if (IsExistFeeType(rd.Text, cbCarType.Text))
                        {
                            InitInfo(rd.Text,cbCarType.Text);
                            txtFreeMinutes.Text = feeModel.FreeMinutes.ToString();
                            txtPerViewFee.Text = feeModel.FeePerView.ToString();
                        }
                    }


                }

            }
        }



        private void btnApp_Click(object sender, EventArgs e)
        {
            foreach (RadioButton rd in gbType.Controls)
            {
                if (rd.Checked == true)
                {
                    if (!IsExistFeeType(rd.Text,cbCarType.Text))
                    {
                        Add(rd.Text);
                    }
                    else
                    {
                        Update(rd.Text,cbCarType.Text);
                    }
                }
            }
        }

        /// <summary>
        /// 添加收费标准
        /// </summary>
        private void Add(string feetype)
        {
            if (string.IsNullOrEmpty(txtFreeMinutes.Text.Trim()))
            {
                MessageHelper.ShowTips("免费分钟数不能为空！");
                return;
            }
            feeModel.FreeMinutes = int.Parse(txtFreeMinutes.Text.Trim());
            if (feetype == "按设定时间收费")
            {

                if (string.IsNullOrEmpty(txtFeetop.Text.Trim()))
                {
                    MessageHelper.ShowTips("每天最高收费不能为空！");
                    return;
                }
                if (string.IsNullOrEmpty(txtSTTimeUnie.Text.Trim()))
                {
                    MessageHelper.ShowTips("计时单位不能为空！");
                    return;
                }
                if (string.IsNullOrEmpty(txtSTUnieFee.Text.Trim()))
                {
                    MessageHelper.ShowTips("每计时单位收费不能为空！");
                    return;
                }
                if (string.IsNullOrEmpty(txtSTOverNightFee.Text.Trim()))
                {
                    MessageHelper.ShowTips("0点后加收过夜费不能为空！");
                    return;
                }
                feeModel.Feetop = Decimal.Parse(txtFeetop.Text.Trim());
                feeModel.STTimeUnie = int.Parse(txtSTTimeUnie.Text.Trim());
                feeModel.STUnieFee = decimal.Parse(txtSTUnieFee.Text.Trim());
                feeModel.STOverNightFee = decimal.Parse(txtSTOverNightFee.Text.Trim());
                feeModel.FeeType = "按设定时间收费";
                feeModel.CarType = cbCarType.Text;
                feeModel.OperatorName = LoginInfo.LoginName;
                feeModel.CompanyCode = LoginInfo.CompanyCode;
                feeModel.ParkId = LoginInfo.ParkId;
                feeModel.OperateTime = DateTime.Now;
                if (feeBLL.Add(feeModel))
                {
                    //将收费标准添加到服务端
                    AddWebSandard(feeModel);
                    MessageHelper.ShowTips("按设定时间收费添加成功！");
                }
                else
                {
                    MessageHelper.ShowTips("按设定时间收费添加失败！");
                }


            }
            else if (feetype == "标准收费")
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < dgvFee.Rows.Count; i++)
                {
                    sb.Append(dgvFee.Rows[i].Cells[1].Value);
                    sb.Append(",");
                }
                www.gzwulian.com.Model.FeeStandard Model = new FeeStandard();
                Model.StandardFee = sb.ToString().Trim(',');
                Model.CarType = cbCarType.Text;
                Model.CompanyCode = LoginInfo.CompanyCode;
                Model.ParkId = LoginInfo.ParkId;
                Model.OperatorName = LoginInfo.LoginName;
                Model.OperateTime = DateTime.Now;
                Model.FeeType = "标准收费";
                Model.CompanyCode = LoginInfo.CompanyCode;
                Model.ParkId = LoginInfo.ParkId;
                Model.OperatorName = LoginInfo.LoginName;
                if (feeBLL.Add(Model))
                {
                    //将收费标准添加到服务端
                    AddWebSandard(feeModel);
                    MessageHelper.ShowTips("标准收费添加成功！");
                }
                else
                {
                    MessageHelper.ShowTips("标准收费添加失败！");
                }
            }
            else if (feetype=="按次收费")
            {
                if (string.IsNullOrWhiteSpace(txtPerViewFee.Text))
                {
                    MessageHelper.ShowTips("按次收费额不能为空！");
                    return;
                }
                feeModel.FeePerView =decimal.Parse(txtPerViewFee.Text);
                feeModel.FeeType = feetype;
                feeModel.CarType = cbCarType.Text;
                feeModel.OperatorName = LoginInfo.LoginName;
                feeModel.OperateTime = DateTime.Now;
                feeModel.CompanyCode = LoginInfo.CompanyCode;
                feeModel.ParkId = LoginInfo.ParkId;
                feeModel.OperatorName = LoginInfo.LoginName;
                if (feeBLL.Add(feeModel))
                {
                    //将收费标准添加到服务端
                    AddWebSandard(feeModel);
                    MessageHelper.ShowTips("按次收费添加成功！");
                }
                else
                {
                    MessageHelper.ShowTips("按次收费添加失败！");
                }
            }
            else 
            {
                //白天段
                if (dgvDayNight.Rows[0].Cells["Day"].Value.ToString() != "")
                {
                    feeModel.DayStartHour = int.Parse(dgvDayNight.Rows[0].Cells["Day"].Value.ToString());
                }
                else
                {
                    feeModel.DayStartHour = 8;
                }
                if (dgvDayNight.Rows[1].Cells["Day"].Value.ToString().Trim() != "")
                {
                    feeModel.DayStartMinute = int.Parse(dgvDayNight.Rows[1].Cells["Day"].Value.ToString());
                }
                else
                {
                    feeModel.DayStartMinute = 0;
                }
                if (dgvDayNight.Rows[2].Cells["Day"].Value.ToString() != "")
                {
                    feeModel.DayTimeUnit = int.Parse(dgvDayNight.Rows[2].Cells["Day"].Value.ToString());
                }
                else
                {
                    MessageHelper.ShowTips("时间段一计时单位不能为空！");
                    return;
                }
                if (dgvDayNight.Rows[3].Cells["Day"].Value.ToString() != "")
                {
                    feeModel.DayUnitFee = int.Parse(dgvDayNight.Rows[3].Cells["Day"].Value.ToString());
                }
                else
                {
                    MessageHelper.ShowTips("时间段一单位收费额不能为空!");
                    return;
                }
                if (dgvDayNight.Rows[4].Cells["Day"].Value .ToString()!= "")
                {
                    feeModel.DayTopFee = int.Parse(dgvDayNight.Rows[4].Cells["Day"].Value.ToString());
                }
                else
                {
                    MessageHelper.ShowTips("时间段一最高收费不能为空!");
                    return;
                }
                if (dgvDayNight.Rows[5].Cells["Day"].Value.ToString()!= "")
                {
                    feeModel.DayLowestFee = int.Parse(dgvDayNight.Rows[5].Cells["Day"].Value.ToString());
                }
                else
                {
                    MessageHelper.ShowTips("时间段一最低收费不能为空!");
                    return;
                }
                //夜间段
                if (dgvDayNight.Rows[0].Cells["Night"].Value.ToString() != "")
                {
                    feeModel.NightStartHour = int.Parse(dgvDayNight.Rows[0].Cells["Night"].Value.ToString());
                }
                else
                {

                    feeModel.NightStartHour = 8;
                }
                if (dgvDayNight.Rows[1].Cells["Night"].Value.ToString()  != "")
                {
                    feeModel.NightStartMinute = int.Parse(dgvDayNight.Rows[1].Cells["Night"].Value.ToString());
                }
                else
                {
                    feeModel.NightStartMinute = 0;
                }
                if (dgvDayNight.Rows[2].Cells["Night"].Value.ToString() != "")
                {
                    feeModel.NightTimeUnit = int.Parse(dgvDayNight.Rows[2].Cells["Night"].Value.ToString());
                }
                else
                {
                    MessageHelper.ShowTips("时间段二计时单位不能为空！");
                    return;
                }
                if (dgvDayNight.Rows[3].Cells["Night"].Value.ToString() != "")
                {
                    feeModel.NightUnitFee = Decimal.Parse(dgvDayNight.Rows[3].Cells["Night"].Value.ToString());
                }
                else
                {
                    MessageHelper.ShowTips("时间段二单位收费额不能为空!");
                    return;
                }
                if (dgvDayNight.Rows[4].Cells["Night"].Value.ToString()!= "")
                {
                    feeModel.NightTopFee = Decimal.Parse(dgvDayNight.Rows[4].Cells["Night"].Value.ToString());
                }
                else
                {
                    MessageHelper.ShowTips("时间段二最高收费不能为空!");
                    return;
                }
                if (dgvDayNight.Rows[5].Cells["Night"].Value.ToString() != "")
                {
                    feeModel.NightLowestFee = Decimal.Parse(dgvDayNight.Rows[5].Cells["Night"].Value.ToString());
                }
                else
                {
                    MessageHelper.ShowTips("时间段二最高收费不能为空!");
                    return;
                }
                feeModel.FeeType = "按设定时间段收费";
                feeModel.Feetop = Decimal.Parse(txtFeetop.Text.Trim());
                feeModel.CompanyCode = LoginInfo.CompanyCode;
                feeModel.ParkId = LoginInfo.ParkId;
                feeModel.OperatorName = LoginInfo.LoginName;
                if (feeBLL.Add(feeModel))
                {
                    //将收费标准添加到服务端
                    AddWebSandard(feeModel);
                    MessageHelper.ShowTips("按设定时间段收费添加成功！");
                }
            }
        }

        /// <summary>
        /// 通过收费类型更新收费标准
        /// </summary>
        /// <param name="feetype"></param>
        private void Update(string feetype,string cartype)
        {
            string strWhere = "FeeType=" + "'" + feetype + "'" + "and  CarType=" + "'" + cartype + "'";
            DataSet ds = feeBLL.GetList(strWhere);
            DataTable dt = ds.Tables[0];
            int Id = (int) dt.Rows[0]["Id"];
            feeModel = feeBLL.GetModel(Id); 
            if (string.IsNullOrEmpty(txtFreeMinutes.Text.Trim()))
            {
                MessageHelper.ShowTips("免费分钟数不能为空！");
                return;
            }
            feeModel.FreeMinutes = int.Parse(txtFreeMinutes.Text.Trim());
            if (feetype == "按设定时间收费")
            {
                if (string.IsNullOrEmpty(txtFeetop.Text.Trim()))
                {
                    MessageHelper.ShowTips("每天最高收费不能为空！");
                    return;
                }
                if (string.IsNullOrEmpty(txtSTTimeUnie.Text.Trim()))
                {
                    MessageHelper.ShowTips("计时单位不能为空！");
                    return;
                }
                if (string.IsNullOrEmpty(txtSTUnieFee.Text.Trim()))
                {
                    MessageHelper.ShowTips("每计时单位收费不能为空！");
                    return;
                }
                if (string.IsNullOrEmpty(txtSTOverNightFee.Text.Trim()))
                {
                    MessageHelper.ShowTips("0点后加收过夜费不能为空！！");
                    return;
                }
                feeModel.Feetop = Decimal.Parse(txtFeetop.Text.Trim());
                feeModel.STTimeUnie = int.Parse(txtSTTimeUnie.Text.Trim());
                feeModel.STUnieFee = Decimal.Parse(txtSTUnieFee.Text.Trim());
                feeModel.CarType = cbCarType.Text;
                feeModel.STOverNightFee = decimal.Parse(txtSTOverNightFee.Text.Trim());
                feeModel.OperateTime = DateTime.Now;
                feeModel.CompanyCode = LoginInfo.CompanyCode;
                feeModel.ParkId = LoginInfo.ParkId;
                feeModel.OperatorName = LoginInfo.LoginName;
                if (feeBLL.Update(feeModel))
                {
                    //将收费标准添加服务端
                    AddWebSandard(feeModel);
                    MessageHelper.ShowTips("按设定时间收费更新成功！");
                }
                else
                {
                    MessageHelper.ShowTips("按设定时间收费更新失败！");
                }
            }
            else if (feetype == "标准收费")
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < dgvFee.Rows.Count; i++)
                {
                    if (dgvFee.Rows[i].Cells[1].Value != null)
                    {
                        sb.Append(dgvFee.Rows[i].Cells[1].Value);
                    }
                    else
                    {
                        sb.Append("0");
                    }
                    sb.Append(",");
                }
                feeModel.StandardFee = sb.ToString().Trim(',');
                feeModel.CompanyCode = LoginInfo.CompanyCode;
                feeModel.ParkId = LoginInfo.ParkId;
                feeModel.OperatorName = LoginInfo.LoginName;
                feeModel.OperateTime = DateTime.Now;
                if (feeBLL.Update(feeModel))
                {
                    //将收费标准添加服务端
                    AddWebSandard(feeModel);
                    MessageHelper.ShowTips("标准收费更新成功！");
                }
                else
                {
                    MessageHelper.ShowTips("标准收费更新失败！");
                }
            }
            else if (feetype=="按次收费")
            {
                if (string.IsNullOrWhiteSpace(txtPerViewFee.Text))
                {
                    MessageHelper.ShowTips("按次收费额不能为空！");
                    return;
                }
                feeModel.CompanyCode = LoginInfo.CompanyCode;
                feeModel.ParkId = LoginInfo.ParkId;
                feeModel.OperatorName = LoginInfo.LoginName;
                feeModel.FeePerView = Decimal.Parse(txtPerViewFee.Text);
                if (feeBLL.Update(feeModel))
                {
                    //将收费标准添加服务端
                    AddWebSandard(feeModel);
                    MessageHelper.ShowTips("按次收费更新成功！");
                }
                else
                {
                    MessageHelper.ShowTips("按次收费更新失败！");
                }
            }
            else
            {
                //白天段
                if (dgvDayNight.Rows[0].Cells["Day"].Value==null )
                {
                    MessageHelper.ShowTips("时间段一开始小时不能为空");
                    return;
                }
                if (dgvDayNight.Rows[1].Cells["Day"].Value == null)
                {
                    MessageHelper.ShowTips("时间段一开始分钟不能为空");
                    return;
                }
                else
                {
                    if (dgvDayNight.Rows[1].Cells["Day"].Value.ToString().Contains('.'))
                    {
                        MessageHelper.ShowTips("时间段一开始分钟不能为特殊字符");
                        return;
                    }
                }
                if (dgvDayNight.Rows[2].Cells["Day"].Value==null )
                {
                    MessageHelper.ShowTips("时间段一计时单位不能为空");
                    return;
                }
                else
                {
                    if (dgvDayNight.Rows[2].Cells["Day"].Value.ToString().Contains('.'))
                    {
                        MessageHelper.ShowTips("时间段一计时单位不能为特殊字符");
                        return;
                    }
                
                }
                if (dgvDayNight.Rows[3].Cells["Day"].Value==null)
                {
                    MessageHelper.ShowTips("时间段一单位收费额不能为空");
                    return;
                }
                if (dgvDayNight.Rows[4].Cells["Day"].Value==null)
                {
                    MessageHelper.ShowTips("时间段一最高收费不能为空");
                    return;
                }
                if (dgvDayNight.Rows[5].Cells["Day"].Value==null)
                {
                    MessageHelper.ShowTips("时间段一最低收费不能为空");
                    return;
                }
                feeModel.DayStartHour = int.Parse(dgvDayNight.Rows[0].Cells["Day"].Value.ToString());
                feeModel.DayStartMinute = int.Parse(dgvDayNight.Rows[1].Cells["Day"].Value.ToString());
                feeModel.DayTimeUnit = int.Parse(dgvDayNight.Rows[2].Cells["Day"].Value.ToString());
                feeModel.DayUnitFee = Decimal.Parse(dgvDayNight.Rows[3].Cells["Day"].Value.ToString());
                feeModel.DayTopFee = Decimal.Parse(dgvDayNight.Rows[4].Cells["Day"].Value.ToString());
                feeModel.DayLowestFee = Decimal.Parse(dgvDayNight.Rows[5].Cells["Day"].Value.ToString());

                //夜间段
                if (dgvDayNight.Rows[0].Cells["Night"].Value == null )
                {
                    MessageHelper.ShowTips("时间段二开始小时不能为空");
                    return;
                }
                else
                {
                    if (dgvDayNight.Rows[0].Cells["Night"].Value.ToString().Contains('.'))
                    {
                        MessageHelper.ShowTips("时间段二开始小时不能为特殊字符");
                        return;
                    }
                
                }
                if (dgvDayNight.Rows[1].Cells["Night"].Value == null )
                {
                    MessageHelper.ShowTips("时间段二开始分钟不能为空");
                    return;
                }
                else 
                {
                    if (dgvDayNight.Rows[1].Cells["Night"].Value.ToString().Contains('.'))
                    {
                        MessageHelper.ShowTips("时间段二开始分钟不能为特殊字符");
                        return;
                    }
                }
                if (dgvDayNight.Rows[2].Cells["Night"].Value == null )
                {
                    MessageHelper.ShowTips("时间段二计时单位不能为空或特殊字符");
                    return;
                }
                else
                {
                    if (dgvDayNight.Rows[2].Cells["Night"].Value.ToString().Contains('.'))
                    {
                        MessageHelper.ShowTips("时间段二计时单位不能为特殊字符");
                        return;
                    }
                }
                if (dgvDayNight.Rows[3].Cells["Night"].Value==null)
                {
                    MessageHelper.ShowTips("时间段二单位收费额不能为空");
                    return;
                }
                if (dgvDayNight.Rows[4].Cells["Night"].Value==null)
                {
                    MessageHelper.ShowTips("时间段二最高收费不能为空");
                    return;
                }
                if (dgvDayNight.Rows[5].Cells["Night"].Value==null)
                {
                    MessageHelper.ShowTips("时间段二最低收费不能为空");
                    return;
                }
                feeModel.NightStartHour = int.Parse(dgvDayNight.Rows[0].Cells["Night"].Value.ToString());
                feeModel.NightStartMinute = int.Parse(dgvDayNight.Rows[1].Cells["Night"].Value.ToString());
                feeModel.NightTimeUnit = int.Parse(dgvDayNight.Rows[2].Cells["Night"].Value.ToString());
                feeModel.NightUnitFee = Decimal.Parse(dgvDayNight.Rows[3].Cells["Night"].Value.ToString());
                feeModel.NightTopFee = Decimal.Parse(dgvDayNight.Rows[4].Cells["Night"].Value.ToString());
                feeModel.NightLowestFee = Decimal.Parse(dgvDayNight.Rows[5].Cells["Night"].Value.ToString());
                feeModel.FeeType = "按设定时间段收费";
                feeModel.CompanyCode = LoginInfo.CompanyCode;
                feeModel.ParkId = LoginInfo.ParkId;
                feeModel.OperatorName = LoginInfo.LoginName;
                feeModel.OperateTime = DateTime.Now;
                feeModel.Feetop = Decimal.Parse(txtFeetop.Text.Trim());
                if (feeBLL.Update(feeModel))
                {
                    //将收费标准添加服务端
                    AddWebSandard(feeModel);
                    MessageHelper.ShowTips("按设定时间段收费更新成功！");
                }
            }

        }

        /// <summary>
        /// 收费类型是否存在
        /// </summary>
        private bool IsExistFeeType(string feetype,string cartype)
        {
            bool flag = false;
            string strWhere = "FeeType=" + "'" + feetype + "'" + "and CarType=" + "'" + cartype + "'";
            DataSet ds = feeBLL.GetList(strWhere);
            if (ds.Tables[0].Rows.Count > 0)
            {
                flag = true;
            }
            return flag;
        }

        private ParkInfo parkModel = new ParkInfo();
        private ParkInfoManager parkBLL = new ParkInfoManager();
        private CarType carTypeModel = new CarType();
        private WebCarTypeInfo.CarTypeInfo webTypeBLL = new WebCarTypeInfo.CarTypeInfo();
        private void btnSetCharge_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            DataSet typeds = carBLL.GetList("CarTypeName="+"'"+cbCarType.Text+"'");
            carTypeModel = carBLL.DataTableToList(typeds.Tables[0]).First();
            if (typeds.Tables[0].Rows.Count ==1)
            {
                foreach (RadioButton rd in gbType.Controls)
                {
                    if (rd.Checked == true)
                    {
                        string strWhere = "FeeType=" + "'" + rd.Text + "'" + " and CarType=" + "'" + cbCarType.Text + "'";
                        DataSet ds = feeBLL.GetList(strWhere);
                        DataTable dt = ds.Tables[0];
                        msg = rd.Text;
                        if (dt.Rows.Count > 0)
                        {
                          
                            feeModel = feeBLL.DataTableToList(dt).First();
                            //向服务端添加收费标准
                            AddWebSandard(feeModel);
                            int Id = (int)dt.Rows[0]["Id"];
                            carTypeModel.ChargeId = Id;
                        }
                        if (carBLL.Update(carTypeModel))
                        {
                            //向服务端添加车辆类型
                            AddWebCarType(carTypeModel);
                            MessageHelper.ShowTips("设置成功,"+cbCarType.Text+"收费标准为：" + msg);
                        }
                        else
                        {
                            MessageHelper.ShowTips("收费标准设置失败！");
                        }

                    }

                }
            }
            else
            {
                MessageHelper.ShowTips("收费标准为空！");
            }
          
        }
        /// <summary>
        /// 添加收费标准到服务端
        /// </summary>
        /// <param name="model"></param>
        private void AddWebSandard(www.gzwulian.com.Model.FeeStandard model)
        {
            bool isSuccess = true;
            WebStandardInfo.FeeStandard webstandardModel = ModelTrans.GetWebStandardModel(model);
            try
            {
              isSuccess= standardInfo.Add(webstandardModel);
            }
            catch (Exception ex)
            {
                isSuccess = false;
            }
            model.IsUpload = isSuccess;
            feeBLL.Update(model);
        }
        /// <summary>
        /// 添加收费类型到服务端
        /// </summary>
        private void AddWebCarType(www.gzwulian.com.Model.CarType model)
        {
            //向服务端添加车辆类型
            bool isSuccess = true;
            WebCarTypeInfo.CarType webCarTypeModel = new WebCarTypeInfo.CarType();
            try
            {
                webCarTypeModel = ModelTrans.GetWebCarTypeModel(model);
                isSuccess=webTypeBLL.Add(webCarTypeModel);
            }
            catch (Exception)
            {
                isSuccess = false;
            }
            model.IsUpload = isSuccess;
            carBLL.Update(model);
        }

        private void txtPerViewFee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
            else
            {
                TextBox tb = (TextBox) sender;
                if (e.KeyChar == 46 && tb.Text.IndexOf('.') > -1)
                {
                    e.Handled = true;
                }
            }
        }
        private void txtIntInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 )
            {
                e.Handled = true;
            }
        }
        public DataGridViewTextBoxEditingControl dgvTxt = null; // 声明 一个 CellEdit     
        private void dgvFee_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
           dgvTxt = (DataGridViewTextBoxEditingControl)e.Control; // 赋值     
           dgvTxt.SelectAll();
           dgvTxt.KeyPress += Cells_KeyPress; // 绑定到事件    

        }
        // 自定义事件KeyPress事件
        private void Cells_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.keyPressXS(e, dgvTxt);
        }

        public void keyPressXS(KeyPressEventArgs e, DataGridViewTextBoxEditingControl dgvTxt)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;       //让操作生效
                int j = 0;
                int k = 0;
                bool flag = false;
                if (dgvTxt.Text.Length == 0)
                {
                    if (e.KeyChar == '.')
                    {
                        e.Handled = true;             //让操作失效
                    }
                }
                for (int i = 0; i < dgvTxt.Text.Length; i++)
                {
                    if (dgvTxt.Text[i] == '.')
                    {
                        j++;
                        flag = true;
                    }
                    if (flag)
                    {
                        if (char.IsNumber(dgvTxt.Text[i]) && e.KeyChar != (char)Keys.Back)
                        {
                            k++;
                        }
                    }
                    if (j >= 1)
                    {
                        if (e.KeyChar == '.')
                        {
                            e.Handled = true;             //让操作失效
                        }
                    }
                    if (k == 2)
                    {
                        if (char.IsNumber(dgvTxt.Text[i]) && e.KeyChar != (char)Keys.Back)
                        {
                            if (dgvTxt.Text.Length - dgvTxt.SelectionStart < 3)
                            {
                                if (dgvTxt.SelectedText != dgvTxt.Text)
                                {
                                    e.Handled = true;             ////让操作失效
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void cbCarType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCarType.SelectedIndex > -1)
            {
                BindDic();
                string feetype = dic[cbCarType.Text];
                if (string.IsNullOrEmpty(feetype))
                {
                    foreach (RadioButton rd in gbType.Controls)
                    {
                        rd.Checked = false;
                    }
                }
                else
                {
                    foreach (RadioButton rd in gbType.Controls)
                    {
                        rd.Checked = false;
                    }
                    foreach (RadioButton rd in gbType.Controls)
                    {
                        if (rd.Text == feetype)
                        {
                            rd.Checked = true;
                        }
                    }
                }

                InitInfo(feetype, cbCarType.Text);
             
            }
        }
        /// <summary>
        /// 通过实体对象得到服务端实体对象
        /// </summary>
        /// <param name="mode">实体对象</param>
        /// <returns></returns>
        private WebStandardInfo.FeeStandard GetWebStandardModel(www.gzwulian.com.Model.FeeStandard mode)
        {
            WebStandardInfo.FeeStandard webmodel = new WebStandardInfo.FeeStandard();
            if (mode != null)
            {
                webmodel.Id = mode.Id;
                webmodel.CarType = mode.CarType;
                webmodel.CompanyCode = mode.CompanyCode;
                webmodel.DayFirstTimeHour = mode.DayFirstTimeHour;
                webmodel.DayFirstTimeMinute = mode.DayFirstTimeMinute;
                webmodel.DayLowestFee = mode.DayLowestFee;
                webmodel.DayStartHour = mode.DayStartHour;
                webmodel.OperatorName = mode.OperatorName;
                webmodel.DayStartMinute = mode.DayStartMinute;
                webmodel.ParkId = mode.ParkId;
                webmodel.DayTimeUnit = mode.DayTimeUnit;
                webmodel.DayTopFee = mode.DayTopFee;
                webmodel.OperatorName = mode.OperatorName;
                webmodel.DayUnitFee = mode.DayUnitFee;
                webmodel.FeePerView = mode.FeePerView;
                webmodel.FeeType = mode.FeeType;
                webmodel.Feetop = mode.Feetop;
                webmodel.FreeMinutes = mode.FreeMinutes;
                webmodel.NightFirstTimeHour = mode.NightFirstTimeHour;
                webmodel.NightFirstTimeMinute = mode.NightFirstTimeMinute;
                webmodel.NightLowestFee = mode.NightLowestFee;
                webmodel.NightStartHour = mode.NightStartHour;
                webmodel.NightStartMinute = mode.NightStartMinute;
                webmodel.NightTimeUnit = mode.NightTimeUnit;
                webmodel.NightTopFee = mode.NightTopFee;
                webmodel.NightUnitFee = mode.NightUnitFee;
                webmodel.OperateTime = mode.OperateTime;
                webmodel.STFirstTimeFee = mode.STFirstTimeFee;
                webmodel.STFirstTimeUnitHour = mode.STFirstTimeUnitHour;
                webmodel.STFirstTimeUnitMinute = mode.STFirstTimeUnitMinute;
                webmodel.STOverNightFee = mode.STOverNightFee;
                webmodel.STTimeUnie = mode.STTimeUnie;
                webmodel.STUnieFee = mode.STUnieFee;
                webmodel.StandardFee = mode.StandardFee;
            }
            return webmodel;
        }
    }
}