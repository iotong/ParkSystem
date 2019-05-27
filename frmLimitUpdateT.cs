using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model = www.gzwulian.com.Model;
using Bll = www.gzwulian.com.BLL;

namespace ChargeWin
{
    public partial class frmLimitUpdateT : Form
    {
        public frmLimitUpdateT()
        {
            InitializeComponent();
        }

        public frmLimitUpdateT(int ID)
        {
            InitializeComponent();
            Id = ID;
        }

        int id;
        /// <summary>
        /// 车辆固定编号
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        //字段封闭类
        Model.FCustomer ModelFcmer = new Model.FCustomer();
        //业务逻辑处理类
        Bll.FCustomerManager bllFcmer = new Bll.FCustomerManager();

        private void frmLimitUpdateT_Load(object sender, EventArgs e)
        {
            BandContrsText(bllFcmer.GetModel(this.Id));
        }

        void BandContrsText(Model.FCustomer M_Fcmer)
        {
            ModelFcmer = M_Fcmer;
            this.tbxCode.Text = M_Fcmer.Code;
            this.tbxFcName.Text = M_Fcmer.Name;
            this.tbxPlateId.Text = M_Fcmer.PlateId;
            this.tbxTelphone.Text = M_Fcmer.Telphone;
            this.tbxGender.Text = M_Fcmer.Gender;
            this.dtpCreateTime.Text = M_Fcmer.CreateTime.ToString() ?? "";
            this.dtpOverTime.Text = M_Fcmer.OverTime.ToString() ?? "";

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
            ModelFcmer.Id = this.Id;
            ModelFcmer.CreateTime = this.dtpCreateTime.Value;
            ModelFcmer.OverTime = this.dtpOverTime.Value;

           bool  through = bllFcmer.Update(ModelFcmer);
           if (through)
           {
               MessageBox.Show("数据修改成功。", "提示");
               this.Close();
           }
           else
           {
               MessageBox.Show("数据修改失败,请检查后重试。", "错误");
           }
        }
    }
}
