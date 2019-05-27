using ChargeWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using www.gzwulian.com;
using www.gzwulian.com.BLL;
using www.gzwulian.com.Common;


namespace ChargeWin
{
    public partial class frmUpdatePwd : Form
    {
        public frmUpdatePwd()
        {
            InitializeComponent();
        }
        private void frmUpdatePwd_Load(object sender, EventArgs e)
        {
            this.txtLoginname.Text = LoginInfo.LoginName;
            this.txtName.Text = LoginInfo.RealName;
        }
        private OperatorManager operatorbll=new OperatorManager();
        //private FinanceSys.PersonnelSys.BLL.Users_BLL userbll = new Users_BLL();
        private void chkPass_CheckedChanged(object sender, EventArgs e)
        {
            Eneble();
            Cleartxt();
        }
        /// <summary>
        /// 设置修改密码相关控件的启用状态
        /// </summary>
        private void Eneble()
        {
            this.lblOldPass.Enabled = !this.lblOldPass.Enabled;
            this.lblNewPass.Enabled = !this.lblNewPass.Enabled;
            this.lblNewPassAgain.Enabled = !this.lblNewPassAgain.Enabled;
            this.txtOldPass.Enabled = !this.txtOldPass.Enabled;
            this.txtNewPass.Enabled = !this.txtNewPass.Enabled;
            this.txtPassAgain.Enabled = !this.txtPassAgain.Enabled;

        }
        /// <summary>
        /// 清理个密码框内的字符
        /// </summary>
        private void Cleartxt()
        {
            this.txtOldPass.Clear();
            this.txtNewPass.Clear();
            this.txtPassAgain.Clear();
        }

   
        /// <summary>
        /// 检查输入是否合法
        /// </summary>
        /// <returns></returns>
        private bool checkInput()
        {
            if (this.txtName.Text.Trim() == "")
            {
                MessageHelper.ShowTips("请输入真实姓名。");
                return false;
            }
            if (this.txtOldPass.Text.Trim() == "")
            {
                MessageHelper.ShowTips("请输入原密码。");
                return false;
            }
            if (this.txtNewPass.Text.Trim() == "")
            {
                MessageHelper.ShowTips("请输入新密码。");
                return false;
            }
            if (this.txtPassAgain.Text.Trim() == "")
            {
                MessageHelper.ShowTips("请输入确认密码。");
                return false;
            }
            if (this.txtNewPass.Text != this.txtPassAgain.Text)
            {
                MessageHelper.ShowTips("两次输入的密码不一致");
                this.txtNewPass.Text = "";
                this.txtPassAgain.Text = "";//5|1|a|s|p|x
                return false;
            }
            return true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //修改资料（不修改密码）
            if (this.chkPass.Checked == false)
            {
                if (this.txtName.Text.Trim() == "")
                {
                    MessageHelper.ShowTips("请输入真实姓名!");
                    return;
                }
                if (operatorbll.UpdateRealName(this.txtName.Text, LoginInfo.Id))
                {
                    LoginInfo.RealName = this.txtName.Text.Trim();
                    MessageHelper.ShowTips("修改成功。");
                    this.Close();
                }
                else
                {
                    MessageHelper.ShowTips("修改失败");
                }

            }
            else
            {
                if (this.checkInput())//修改密码
                {
                    if (operatorbll.CheckPwd(CEncoder.Encode(this.txtOldPass.Text.Trim()), LoginInfo.Id))
                    {
                        bool result = operatorbll.UpdatePwd(CEncoder.Encode(this.txtNewPass.Text.Trim()), LoginInfo.Id);
                        if (result)
                        {
                            MessageHelper.ShowTips("修改成功。");
                            this.Cleartxt(); this.Close();
                            this.chkPass.Checked = false;
                        }
                    }
                    else
                    {
                        MessageHelper.ShowTips("原密码错误，请确认后在输入。修改失败。");
                        this.Cleartxt();
                        return;
                    }
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
