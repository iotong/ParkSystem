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
    public partial class frmAddRole : Form
    {
        public frmAddRole()
        {
            InitializeComponent();
        }
        www.gzwulian.com.Model.RightsGroup rightsGroupModel=new RightsGroup();
        private www.gzwulian.com.BLL.RightsGroupManager rightsGroupBLL = new RightsGroupManager();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRole.Text))
            {
                MessageHelper.ShowTips("角色名称不能为空！");
                return;
            }
            rightsGroupModel.GroupName = txtRole.Text;
            DataSet ds = rightsGroupBLL.GetList("GroupName=" + "'" + txtRole.Text + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                MessageHelper.ShowWarning("已存在该角色！");
            }
            else
            {
                int flag = rightsGroupBLL.Add(rightsGroupModel);
                if (flag > 0)
                {
                    MessageHelper.ShowTips("添加成功！");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageHelper.ShowTips("添加失败！");
                    this.Close();
                }
                
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
