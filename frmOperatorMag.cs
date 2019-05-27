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
    public partial class frmOperatorMag : Form
    {
        public frmOperatorMag()
        {
            InitializeComponent();
        }
        www.gzwulian.com.BLL.OperatorManager operatorBLL=new OperatorManager();
        private void FrmOperatorMag_Load(object sender, EventArgs e)
        {
            DataBind();
        }

        StringBuilder strWhere = new StringBuilder();
        private void DataBind()
        {

            string sqlWhere = "";

            strWhere.Remove(0, strWhere.ToString().Length);
            if (!string.IsNullOrEmpty(tbxOperatorName.Text.Trim()))
            {
                strWhere.Append(" OperatorName like '%" + tbxOperatorName.Text.Trim() + "%' ");

            }
            if (!string.IsNullOrEmpty(tbxRealName.Text.Trim()))
            {
                if (strWhere.ToString().Contains("like"))
                {
                    strWhere.Append(" and RealName like " + "'%" + tbxRealName.Text.Trim() + "%'");
                }
                else
                {
                    strWhere.Append(" RealName like " + "'%" + tbxRealName.Text.Trim() + "%'");
                }
            }
         
            if (!string.IsNullOrWhiteSpace(strWhere.ToString()))
            {
                sqlWhere = strWhere.ToString();
            }


            DataSet ds = operatorBLL.GetList(sqlWhere);

            dgvOperatorList.DataSource = ds.Tables[0].DefaultView;

            dgvOperatorList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOperatorList.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvOperatorList.Columns["Id"].HeaderText = "Id号";
            dgvOperatorList.Columns["Id"].DisplayIndex = 0;
            dgvOperatorList.Columns["Id"].Width = 40;
            dgvOperatorList.Columns["OperatorName"].HeaderText = "操作员";
            dgvOperatorList.Columns["OperatorName"].Width = 90;
            dgvOperatorList.Columns["OperatorName"].DisplayIndex = 1;
            dgvOperatorList.Columns["State"].HeaderText = "启用";
            dgvOperatorList.Columns["State"].Width = 40;
            dgvOperatorList.Columns["State"].DisplayIndex = 2;
            dgvOperatorList.Columns["RealName"].HeaderText = "真实姓名";
            dgvOperatorList.Columns["RealName"].DisplayIndex = 3;
            dgvOperatorList.Columns["Gender"].HeaderText = "性别";
            dgvOperatorList.Columns["Gender"].DisplayIndex = 4;
            dgvOperatorList.Columns["Gender"].Width = 40;
            dgvOperatorList.Columns["Telphone"].HeaderText = "联系电话";
            dgvOperatorList.Columns["Telphone"].DisplayIndex = 5;
            dgvOperatorList.Columns["AddTime"].HeaderText = "新增时间";
            dgvOperatorList.Columns["AddTime"].DisplayIndex = 6;
            dgvOperatorList.Columns["AddTime"].Width =200;
            dgvOperatorList.Columns["CompanyCode"].HeaderText = "单位编码";
            dgvOperatorList.Columns["CompanyCode"].DisplayIndex = 7;
            dgvOperatorList.Columns["ParkId"].HeaderText = "车场编码";
            dgvOperatorList.Columns["ParkId"].DisplayIndex = 8;
            dgvOperatorList.Columns["RightsList"].Visible = false;
            dgvOperatorList.Columns["Password"].Visible = false;
            dgvOperatorList.Columns["GroupId"].Visible = false;
            this.dgvOperatorList.Columns["IsUpload"].Visible = false;   
        }

        private void tsbtnCloseWindow_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbtnDeleteOperator_Click(object sender, EventArgs e)
        {
            

            if (this.dgvOperatorList.Rows.Count == 0)
            {
                return;
            }
            if (this.dgvOperatorList.SelectedRows.Count < 1)
            {
                MessageBox.Show("请先选择要操作的数据！");
                return;
            }
            int id = int.Parse(this.dgvOperatorList.SelectedRows[0].Cells["Id"].Value.ToString());
            DialogResult dr = MessageBox.Show(this, "确定删除该用户？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
               
                if (id != 0)
                {
                  

                www.gzwulian.com.Model.Operator opMoell = new Operator();
                opMoell = operatorBLL.GetModel(id);
                    if (opMoell != null)
                    {
                        if (opMoell.OperatorName =="admin")
                        {
                            MessageHelper.ShowTips("不能删除管理员【admin】");
                            return;
                        }
                        if (opMoell.OperatorName == "sadmin")
                        {
                            MessageHelper.ShowTips("不能删除超级管理员【sadmin】");
                            return;
                        }

                    }

                    if (operatorBLL.Delete(id))
                    {
                        MessageBox.Show("删除成功");
                        DataBind();
                        //this.ucPageBar1.RefreshData(false);
                    }
                    else
                    {
                        MessageBox.Show("删除失败");
                    }
                }

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.dgvOperatorList.SelectedRows[0].Cells["Id"].Value.ToString());

            if (this.dgvOperatorList.Rows.Count == 0)
            {
                return;
            }
            if (this.dgvOperatorList.SelectedRows.Count < 1)
            {
                MessageBox.Show("请先选择要操作的数据！");
                return;
            }

            frmOperatorMagAdd frmOpUp = new frmOperatorMagAdd("修改", id);
            frmOpUp.ShowDialog();
            if (frmOpUp.Istrue)
                DataBind();
        }

        private void tsbtnAddOperator_Click(object sender, EventArgs e)
        {
            frmOperatorMagAdd frmOpAdd = new frmOperatorMagAdd("添加",0);
            frmOpAdd.ShowDialog();
            if (frmOpAdd.Istrue)
            {
                DataBind();
            }
        }

        private void tsbtnRefreshOperator_Click(object sender, EventArgs e)
        {
            DataBind();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tbxOperatorName.Text = "";
            tbxRealName.Text = "";

            DataBind();
        }

        private void btnProQuery_Click(object sender, EventArgs e)
        {
            DataBind();
        }

    }
}
