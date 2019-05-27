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

namespace ChargeWin
{
    public partial class frmConfirm : Form
    {
        public frmConfirm()
        {
            InitializeComponent();
        }

        private www.gzwulian.com.BLL.OperatorManager operatorBll = new OperatorManager();
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtPwd.Text))
            {
                MessageHelper.ShowTips("请输入密码！");
                this.DialogResult=DialogResult.None;
            }
            Operator operatorMode = new Operator();
            operatorMode = operatorBll.GetModel(LoginInfo.Id);
            string loginpwd = operatorMode.Password;
            string pwd = CEncoder.Encode(this.txtPwd.Text.Trim());
            if (loginpwd.Equals(pwd))
            {
                this.DialogResult=DialogResult.OK;
            }
            else
            {
                MessageHelper.ShowTips("密码错误！");

            }



        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
