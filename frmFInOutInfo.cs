using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bll= www.gzwulian.com.BLL;
using Model = www.gzwulian.com.Model;
using Common = www.gzwulian.com.Common;

namespace ChargeWin
{
    public partial class frmFInOutInfo : Form
    {
        public frmFInOutInfo()
        {
            InitializeComponent();
        }

        DataSet ds;
        /// <summary>
        /// 数据集合
        /// </summary>
        public DataSet Ds
        {
            get { return ds; }
            set { ds = value; }
        }

        StringBuilder strWhere = new StringBuilder();

        Bll.FInOutInfoManager bllFCmanager = new Bll.FInOutInfoManager();

        private void btnProQuery_Click(object sender, EventArgs e)
        {
            SelectDataBind(this.ucPageBar1.PageSize, this.ucPageBar1.CurrentPage);
            this.ucPageBar1.RefreshData(true);
        }

        private void frmFInOutInfo_Load(object sender, EventArgs e)
        {
           DataSet ds= bllFCmanager.GetAllList();
           dtpOutTime.CustomFormat = "yyyy-MM-dd";
           dtpInTime.CustomFormat = "yyyy-MM-dd";
            dtpOutTime.Checked = dtpInTime.Checked = false;
            this.ucPageBar1.OnDataBind += new Common.ucPageBar.DataBind(SelectDataBind);
            this.ucPageBar1.RefreshData(true);
        }


        /// <summary>
        /// 数据绑定到dataGridView1
        /// </summary>
        /// <param name="pageSize">每页对少条数据</param>
        /// <param name="currentPage">当前页码</param>
        public void SelectDataBind(uint pageSize, uint currentPage)
        {
            string sqlWhere = "";

            strWhere.Remove(0, strWhere.ToString().Length);
          
         
            if (!string.IsNullOrWhiteSpace(tbxPlateId.Text))
            {
                if (strWhere.ToString().Contains("like"))
                {
                    strWhere.Append(" and PlateId like " + "'%" + tbxPlateId.Text.Trim() + "%'");
                }
                else
                {
                    strWhere.Append(" PlateId like " + "'%" + tbxPlateId.Text.Trim() + "%'");
                }
            }

            if (dtpInTime.Checked == true && dtpOutTime.Checked == true)
            {
                if (strWhere.ToString().Contains("CONVERT") || strWhere.ToString().Contains("and") ||
             strWhere.ToString().Contains("like"))
                {
                    strWhere.Append("and AddTime between " + "'" + dtpInTime.Value.Date.ToString() + "' and " + "'" + dtpOutTime.Value.Date.AddDays(1).AddSeconds(-1).ToString() + "'");
                }
                else
                {
                    strWhere.Append(" AddTime between " + "'" + dtpInTime.Value.Date.ToString() + "' and " + "'" + dtpOutTime.Value.Date.AddDays(1).AddSeconds(-1).ToString() + "'");
                }
            }

            if (!string.IsNullOrWhiteSpace(strWhere.ToString()))
            {
                sqlWhere = strWhere.ToString();
            }
            int count = bllFCmanager.GetRecordCount(sqlWhere);
            this.ucPageBar1.RecordCount = (uint)count;
            int pagesize = (int)pageSize;
            int sumpages = (int)Math.Ceiling(count / (decimal)pageSize);
            int currentpage = (int)currentPage;
            int startindex = (currentpage - 1) * pagesize + 1;
            int endindex = currentpage * pagesize;
            if (currentpage == sumpages)
            {
                if (count%pagesize == 0)
                {
                    endindex = sumpages*pagesize;
                }
                else
                {
                    endindex = (sumpages - 1) * pagesize + count % pagesize;  
                }
            }
            DataSet ds = bllFCmanager.GetListByPage(sqlWhere, "", startindex, endindex);
            DataTable dt = ds.Tables[0];
            this.dgvFCustomerInfo.Columns.Clear();
            BindDataGridView(ds);
            ds.Dispose();
            dt.Dispose();

        }
        /// <summary>
        /// DGV绑定
        /// </summary>
        /// <param name="ds"></param>
        private void BindDataGridView(DataSet ds)
        {
            this.dgvFCustomerInfo.DataSource = ds.Tables[0];
            // 设置中文列名及可写状态
            this.dgvFCustomerInfo.Columns["Id"].HeaderText = "编号";
            this.dgvFCustomerInfo.Columns["Id"].Width = 40;
            this.dgvFCustomerInfo.Columns["Id"].ToolTipText = "[只读列]";
            this.dgvFCustomerInfo.Columns["Id"].DisplayIndex = 2;
            this.dgvFCustomerInfo.Columns["PlateId"].HeaderText = "车牌号码";
            this.dgvFCustomerInfo.Columns["PlateId"].ToolTipText = "[只读列]";
            this.dgvFCustomerInfo.Columns["PlateId"].DisplayIndex = 3;
            this.dgvFCustomerInfo.Columns["PlateId"].ReadOnly = true;
            this.dgvFCustomerInfo.Columns["PlateColor"].HeaderText = "车牌颜色";
            this.dgvFCustomerInfo.Columns["PlateColor"].DisplayIndex = 4;
            this.dgvFCustomerInfo.Columns["InTime"].HeaderText = "进场时间";
            this.dgvFCustomerInfo.Columns["InTime"].Width = 120;
            this.dgvFCustomerInfo.Columns["InTime"].DisplayIndex = 6;
            this.dgvFCustomerInfo.Columns["OutTime"].HeaderText = "出场时间";
            this.dgvFCustomerInfo.Columns["OutTime"].Width = 120;
            this.dgvFCustomerInfo.Columns["OutTime"].DisplayIndex = 7;
            this.dgvFCustomerInfo.Columns["VehicType"].HeaderText = "车辆类型";
            this.dgvFCustomerInfo.Columns["VehicType"].DisplayIndex = 8;
            this.dgvFCustomerInfo.Columns["OperatorName"].HeaderText = "操作员";
            this.dgvFCustomerInfo.Columns["AddTime"].HeaderText = "新增时间";
            this.dgvFCustomerInfo.Columns["AddTime"].Width = 120;
            //this.dgvFCustomerInfo.Columns["Id"].Visible = false;
            this.dgvFCustomerInfo.Columns["row"].Visible = false;
            this.dgvFCustomerInfo.Columns["FCustomerId"].Visible = false;
            this.dgvFCustomerInfo.Columns["ParkId"].Visible = false;
            this.dgvFCustomerInfo.Columns["CompanyCode"].Visible = false;
            this.dgvFCustomerInfo.Columns["OutImgPath"].Visible = false;
            this.dgvFCustomerInfo.Columns["InImgPath"].Visible = false;
            this.dgvFCustomerInfo.Columns["IsUpload"].Visible = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.tbxPlateId.Text = "";
            this.dtpInTime.Checked = this.dtpOutTime.Checked = false;
            this.ucPageBar1.OnDataBind += new Common.ucPageBar.DataBind(SelectDataBind);
            this.ucPageBar1.RefreshData(true);
        }

        private void btnToExcel_Click(object sender, EventArgs e)
        {
            sfdDataToExcel.Filter = "Excel工作簿|*.xls";
            DialogResult dlt = sfdDataToExcel.ShowDialog();
            // DT= dataGridView1.DataSource;
            if (dlt == DialogResult.OK)
            {
                WriteToExcel(dgvFCustomerInfo);
            }
        }



        /// <summary>
        /// 导出DataGridView数据至Excel表
        /// </summary>
        /// <param name="grid">数据源DatagridView</param>
        public void WriteToExcel(DataGridView grid)
        {
            try
            {

                string strFilePath = sfdDataToExcel.FileName; //赋给文件的名字
                System.IO.StreamWriter sw = new System.IO.StreamWriter(strFilePath, true, System.Text.Encoding.Default); //写入流
                object[] values = new object[grid.Columns.Count];
                for (int i = 0; i < grid.Columns.Count; ++i)
                {
                    if (grid.Columns[i].HeaderText.ToString() == "项目代码")
                    {
                        grid.Columns[i].HeaderText = "项目代码";
                    }
                    if (grid.Columns[i].Visible)
                    {
                        sw.Write(grid.Columns[i].HeaderText.ToString());
                        sw.Write('\t');
                    }
                }
                sw.Write("\r\n");
                for (int i = 0; i < grid.Rows.Count; i++)
                {
                    for (int j = 0; j < values.Length; ++j)
                    {
                        if (grid.Columns[j].Visible)
                        {  
                                sw.Write(grid.Rows[i].Cells[j].Value);
                                sw.Write('\t');
                        }
                    }
                    sw.Write("\r\n");
                }

                sw.Flush();
                sw.Close();
                MessageBox.Show("成功导出[" + grid.Rows.Count.ToString() + "]行到Execl！");
            }
            catch
            {
                MessageBox.Show("导出Execl失败！");
            }
        }

        private void dgvFCustomerInfo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            else
            {
                string Id = this.dgvFCustomerInfo.Rows[e.RowIndex].Cells[1].Value.ToString();//获得本行第一个单元格的数据，以此类推
                frmShowInfo frmshowinfo = new frmShowInfo(Convert.ToInt32(Id));
                frmshowinfo.ShowDialog();
            }
        }

        private void btnChargeToExcel_Click(object sender, EventArgs e)
        {
            sfdDataToExcel.Filter = "Excel工作簿|*.xls";
            DialogResult dlt = sfdDataToExcel.ShowDialog();
            if (dlt == DialogResult.OK)
            {
                WriteToExcel(dgvFCustomerInfo);
            }
        }
    }
}
