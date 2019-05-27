using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using www.gzwulian.com.BLL;
using www.gzwulian.com.Model;
using www.gzwulian.com.Common;

namespace ChargeWin
{
    public partial class frmChargeInfo : Form
    {
        public frmChargeInfo()
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
        private ChargeRecord chargeRecordModel;
        www.gzwulian.com.BLL.ChargeRecordManager chargeRecordBLL = new ChargeRecordManager();

        private void btnProQuery_Click(object sender, EventArgs e)
        {
            DataBind(this.ucPageBar1.PageSize, this.ucPageBar1.CurrentPage);
            this.ucPageBar1.RefreshData(true);
        }

        private void frmWorkRecord_Load(object sender, EventArgs e)
        {
            this.dtpInTime.Checked = false;
            this.dtpOutTime.Checked = false;
            this.dtpInTime.CustomFormat = "yyyy-MM-dd";
            this.dtpOutTime.CustomFormat = "yyyy-MM-dd";
            DataSet ds = chargeRecordBLL.GetAllList();
            this.ucPageBar1.OnDataBind += new ucPageBar.DataBind(DataBind);
            this.ucPageBar1.RefreshData(true);
        }

        /// <summary>
        /// 数据绑定到DGV
        /// </summary>
        /// <param name="pageSize">每页对少条数据</param>
        /// <param name="currentPage">当前页码</param>
        public void DataBind(uint pageSize, uint currentPage)
        {
            string sqlWhere = "OutTime is not null";

            strWhere.Remove(0, strWhere.ToString().Length);
            if (!string.IsNullOrEmpty(txtPlateId.Text.Trim()))
            {
                if (strWhere.ToString().Contains("CONVERT") || strWhere.ToString().Contains("and") || strWhere.ToString().Contains("like"))
                {
                    strWhere.Append(" and PlateId like " + "'%" + txtPlateId.Text.Trim() + "%'");
                }
                else
                {
                    strWhere.Append(" PlateId like " + "'%" + txtPlateId.Text.Trim() + "%'");
                }
            }
            if (dtpInTime.Checked == true && dtpOutTime.Checked == true)
            {
                if (strWhere.ToString().Contains("CONVERT") || strWhere.ToString().Contains("and") ||
             strWhere.ToString().Contains("like"))
                {
                    strWhere.Append("and OperatorTime between " + "'" + dtpInTime.Value.Date.ToString() + "' and " + "'" + dtpOutTime.Value.Date.AddDays(1).AddSeconds(-1).ToString() + "'");
                }
                else
                {
                    strWhere.Append(" OperatorTime between " + "'" + dtpInTime.Value.Date.ToString() + "' and " + "'" + dtpOutTime.Value.Date.AddDays(1).AddSeconds(-1).ToString() + "'");
                }

            }
            if (!string.IsNullOrWhiteSpace(strWhere.ToString()))
            {
                sqlWhere = strWhere.ToString();
               
            }
            int count = chargeRecordBLL.GetRecordCount(sqlWhere);
            this.ucPageBar1.RecordCount = (uint)count;
            int pagesize = (int) pageSize;
            int sumpages = (int)Math.Ceiling(count / (decimal)pageSize);
            int currentpage = (int) currentPage;
            int startindex = (currentpage-1)*pagesize+1;
            int endindex = currentpage * pagesize;
            if (currentpage == sumpages)
            {
               endindex = (currentpage - 1) * pagesize + count % pagesize;
            }
           // sqlWhere = sqlWhere + " ORDER BY OperatorTime ";
            DataSet ds = chargeRecordBLL.GetListByPage(sqlWhere, "OperatorTime", startindex, endindex);
            DataTable dt = ds.Tables[0];
            this.dgvFCustomerInfo.Columns.Clear();
            BindDataGridView(ds);
        
            ds.Dispose();
            dt.Dispose();

        }

        void BindDataGridView(DataSet ds)
        {
            List<www.gzwulian.com.Model.ChargeRecord> infoModelList = chargeRecordBLL.DataTableToList(ds.Tables[0]);
            this.dgvFCustomerInfo.DataSource = infoModelList;
            this.dgvFCustomerInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvFCustomerInfo.ColumnHeadersHeight =400;
            this.dgvFCustomerInfo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // 设置中文列名及可写状态
            //this.dgvFCustomerInfo.Columns["Id"].HeaderText = "编号";
            //this.dgvFCustomerInfo.Columns["Id"].Width = 60;
            //this.dgvFCustomerInfo.Columns["Id"].ToolTipText = "[只读列]";
            //this.dgvFCustomerInfo.Columns["Id"].DisplayIndex = 2;
            this.dgvFCustomerInfo.Columns["PlateId"].HeaderText = "车牌号";
            this.dgvFCustomerInfo.Columns["PlateId"].ToolTipText = "[只读列]";
            this.dgvFCustomerInfo.Columns["PlateId"].Width = 76;
            this.dgvFCustomerInfo.Columns["PlateId"].DisplayIndex = 3;
            this.dgvFCustomerInfo.Columns["PlateId"].ReadOnly = true;

            this.dgvFCustomerInfo.Columns["InTime"].HeaderText = "进场时间";
            this.dgvFCustomerInfo.Columns["InTime"].DisplayIndex = 4;
            this.dgvFCustomerInfo.Columns["InTime"].Width = 110;
            this.dgvFCustomerInfo.Columns["OutTime"].HeaderText = "出场时间";
            this.dgvFCustomerInfo.Columns["OutTime"].DisplayIndex = 5;
            this.dgvFCustomerInfo.Columns["OutTime"].Width = 110;

            this.dgvFCustomerInfo.Columns["FeeStandard"].HeaderText = "收费标准";
            this.dgvFCustomerInfo.Columns["FeeStandard"].DisplayIndex = 6;
            this.dgvFCustomerInfo.Columns["FeeStandard"].Width = 80;

            this.dgvFCustomerInfo.Columns["ParkTime"].HeaderText = "停车时间";
            this.dgvFCustomerInfo.Columns["ParkTime"].DisplayIndex = 8;
            this.dgvFCustomerInfo.Columns["ParkTime"].Width = 80;

            this.dgvFCustomerInfo.Columns["CusType"].HeaderText = "客户类型";
            this.dgvFCustomerInfo.Columns["CusType"].DisplayIndex = 9;
            this.dgvFCustomerInfo.Columns["CusType"].Width = 80;
            this.dgvFCustomerInfo.Columns["SumMoney"].HeaderText = "应收金额";
            this.dgvFCustomerInfo.Columns["SumMoney"].DisplayIndex = 10;
            this.dgvFCustomerInfo.Columns["SumMoney"].Width = 80;

            this.dgvFCustomerInfo.Columns["GiveCharge"].HeaderText = "实收金额";
            this.dgvFCustomerInfo.Columns["GiveCharge"].DisplayIndex = 11;
            this.dgvFCustomerInfo.Columns["GiveCharge"].Width = 80;

            this.dgvFCustomerInfo.Columns["FreeReason"].HeaderText = "免费原因";
            this.dgvFCustomerInfo.Columns["FreeReason"].DisplayIndex = 12;
            this.dgvFCustomerInfo.Columns["FreeReason"].Width = 80;
            this.dgvFCustomerInfo.Columns["OperatorName"].HeaderText = "操作员";
            this.dgvFCustomerInfo.Columns["OperatorName"].DisplayIndex = 13;
            this.dgvFCustomerInfo.Columns["OperatorName"].Width = 110;
            this.dgvFCustomerInfo.Columns["Id"].Visible = false;

            this.dgvFCustomerInfo.Columns["ParkId"].Visible = false;
            this.dgvFCustomerInfo.Columns["CompanyCode"].Visible = false;
            this.dgvFCustomerInfo.Columns["IsUpload"].Visible=false;
            this.dgvFCustomerInfo.Columns["Name"].Visible = false;
            this.dgvFCustomerInfo.Columns["InImgPath"].Visible = false;
            this.dgvFCustomerInfo.Columns["OutImgPath"].Visible = false;
            this.dgvFCustomerInfo.Columns["ReMoney"].Visible = false;
           // this.dgvFCustomerInfo.Columns["GiveCharge"].Visible = false;
            this.dgvFCustomerInfo.Columns["OperatorTime"].Visible = false;
            this.dgvFCustomerInfo.Columns["Memo"].Visible = false;
            this.dgvFCustomerInfo.Columns["CardCode"].Visible = false;
            this.dgvFCustomerInfo.Columns["CarType"].Visible = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.dtpInTime.Checked = false;
            this.dtpOutTime.Checked = false;
            this.txtPlateId.Text = string.Empty;
            this.ucPageBar1.OnDataBind += new ucPageBar.DataBind(DataBind);
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
                //string tempImagePath = @"D:\EXCEL";//软件安装目录
                // string temp = Common.RegistTableUtility.Instance.GetPath() + @"Excel";//目录下的Execl文件夹
                //Directory.CreateDirectory(@temp);
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
