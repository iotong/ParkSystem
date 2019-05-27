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
    public partial class frmInOutInfo : Form
    {
        public frmInOutInfo()
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
        private PlateIdentifyInfo plateIdentifyModel;
        PlateIdentifyInfoManager bllInOutInfo = new PlateIdentifyInfoManager();

        private void btnProQuery_Click(object sender, EventArgs e)
        {
            DataBind(this.ucPageBar1.PageSize, this.ucPageBar1.CurrentPage);
            this.ucPageBar1.RefreshData(true);
        }

        private void frmFInOutInfo_Load(object sender, EventArgs e)
        {
            dtpOutTime.CustomFormat = "yyyy-MM-dd";
            dtpInTime.CustomFormat = "yyyy-MM-dd";
            this.dtpInTime.Text = this.dtpOutTime.Text = "";
            DataSet ds= bllInOutInfo.GetAllList();
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
            string sqlWhere = "";

            strWhere.Remove(0, strWhere.ToString().Length);
            if (!string.IsNullOrEmpty(tbxPlateId.Text.Trim()))
            {
                if (strWhere.ToString().Contains("CONVERT") || strWhere.ToString().Contains("and") || strWhere.ToString().Contains("like"))
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
         
         
            //if (dtpInTime.Checked == true)
            //{
            //    if (strWhere.ToString().Contains("CONVERT") || strWhere.ToString().Contains("and") ||
            //        strWhere.ToString().Contains("like"))
            //    {
            //        strWhere.Append("and CONVERT(varchar(64), InTime, 23)= " + "'" +
            //                        dtpInTime.Value.ToString("yyyy-MM-dd") + "'");
            //    }
            //    else
            //    {
            //        strWhere.Append("CONVERT(varchar(64), InTime, 23)= " + "'" + dtpInTime.Value.ToString("yyyy-MM-dd") +
            //                        "'");
            //    }
            //}

            //if (dtpOutTime.Checked == true)
            //{
            //    if (strWhere.ToString().Contains("CONVERT") || strWhere.ToString().Contains("and") ||
            //        strWhere.ToString().Contains("like"))
            //    {
            //        strWhere.Append("and CONVERT(varchar(64), OutTime, 23)= " + "'" +
            //                        dtpOutTime.Value.ToString("yyyy-MM-dd") + "'");
            //    }
            //    else
            //    {
            //        strWhere.Append("CONVERT(varchar(64), OutTime, 23)= " + "'" +
            //                        dtpOutTime.Value.ToString("yyyy-MM-dd") + "'");
            //    }
            //}

            if (!string.IsNullOrWhiteSpace(strWhere.ToString()))
            {
                sqlWhere = strWhere.ToString();
            }



            int count = bllInOutInfo.GetRecordCount(sqlWhere);
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
            DataSet ds = bllInOutInfo.GetListByPage(sqlWhere, "", startindex, endindex);
            DataTable dt = ds.Tables[0];
            this.dgvFCustomerInfo.Columns.Clear();
            BindDataGridView(ds);
        
            ds.Dispose();
            dt.Dispose();

        }

        void BindDataGridView(DataSet ds)
        {
            List<www.gzwulian.com.Model.PlateIdentifyInfo> infoModelList = bllInOutInfo.DataTableToList(ds.Tables[0]);
            this.dgvFCustomerInfo.DataSource = infoModelList;
            this.dgvFCustomerInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvFCustomerInfo.ColumnHeadersHeight =400;
            this.dgvFCustomerInfo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                // 设置中文列名及可写状态
            //this.dgvFCustomerInfo.Columns["Id"].HeaderText = "编号";
            //this.dgvFCustomerInfo.Columns["Id"].Width = 60;
            //this.dgvFCustomerInfo.Columns["Id"].ToolTipText = "[只读列]";
            //this.dgvFCustomerInfo.Columns["Id"].DisplayIndex = 2;
            this.dgvFCustomerInfo.Columns["PlateId"].HeaderText = "车牌号码";
            this.dgvFCustomerInfo.Columns["PlateId"].ToolTipText = "[只读列]";
            this.dgvFCustomerInfo.Columns["PlateId"].Width = 100;
            this.dgvFCustomerInfo.Columns["PlateId"].DisplayIndex = 3;
            this.dgvFCustomerInfo.Columns["PlateId"].ReadOnly = true;

            this.dgvFCustomerInfo.Columns["PlateCorlor"].HeaderText = "车牌颜色";
            this.dgvFCustomerInfo.Columns["PlateCorlor"].DisplayIndex = 4;
            this.dgvFCustomerInfo.Columns["TypeStr"].HeaderText = "车牌类型";
            this.dgvFCustomerInfo.Columns["TypeStr"].DisplayIndex = 5;

            this.dgvFCustomerInfo.Columns["InTime"].HeaderText = "进场时间";
            this.dgvFCustomerInfo.Columns["InTime"].DisplayIndex = 6;
            this.dgvFCustomerInfo.Columns["InTime"].Width = 140;

            this.dgvFCustomerInfo.Columns["OutTime"].HeaderText = "出场时间";
            this.dgvFCustomerInfo.Columns["OutTime"].DisplayIndex = 7;
            this.dgvFCustomerInfo.Columns["OutTime"].Width = 140;

            //this.dgvFCustomerInfo.Columns["ParkId"].HeaderText = "停车场编码";
            //this.dgvFCustomerInfo.Columns["ParkId"].DisplayIndex = 8;

            //this.dgvFCustomerInfo.Columns["CompanyCode"].HeaderText = "单位编码";
            //this.dgvFCustomerInfo.Columns["CompanyCode"].DisplayIndex = 9;

            this.dgvFCustomerInfo.Columns["AddTime"].HeaderText = "新增时间";
            this.dgvFCustomerInfo.Columns["AddTime"].DisplayIndex = 8;
            this.dgvFCustomerInfo.Columns["AddTime"].Width = 120;
            this.dgvFCustomerInfo.Columns["OperatorName"].HeaderText = "操作员";
            this.dgvFCustomerInfo.Columns["Id"].Visible = false;
            this.dgvFCustomerInfo.Columns["ColorIndex"].Visible = false;
            this.dgvFCustomerInfo.Columns["Confidence"].Visible = false;
            this.dgvFCustomerInfo.Columns["Bright"].Visible = false;
            this.dgvFCustomerInfo.Columns["Direction"].Visible = false;
            this.dgvFCustomerInfo.Columns["CarBright"].Visible = false;
            this.dgvFCustomerInfo.Columns["PlateImgPath"].Visible = false;
            this.dgvFCustomerInfo.Columns["Ip"].Visible = false;
            this.dgvFCustomerInfo.Columns["ResultType"].Visible = false;
            this.dgvFCustomerInfo.Columns["Place"].Visible = false;
            this.dgvFCustomerInfo.Columns["Remark"].Visible = false;
            this.dgvFCustomerInfo.Columns["CardCode"].Visible = false;
            this.dgvFCustomerInfo.Columns["CarColor"].Visible = false;
            this.dgvFCustomerInfo.Columns["UserTime"].Visible = false;
            this.dgvFCustomerInfo.Columns["Type"].Visible = false;
            this.dgvFCustomerInfo.Columns["CarColorStr"].Visible = false;
            this.dgvFCustomerInfo.Columns["DirectionStr"].Visible = false;
            this.dgvFCustomerInfo.Columns["ParkId"].Visible = false;
            this.dgvFCustomerInfo.Columns["CompanyCode"].Visible = false;
            this.dgvFCustomerInfo.Columns["IsUpload"].Visible = false;   
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tbxPlateId.Text = "";
            this.dtpInTime.Checked = this.dtpOutTime.Checked =false;
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
        
        private void dgvFCustomerInfo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            else
            {
                string  Id = this.dgvFCustomerInfo.Rows[e.RowIndex].Cells[0].Value.ToString();//获得本行第一个单元格的数据，以此类推
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
