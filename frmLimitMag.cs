using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AxVZLPRClientCtrlLib;
using www.gzwulian.com.BLL;
using www.gzwulian.com.Common;
using www.gzwulian.com.Model;

namespace ChargeWin
{
    public partial class frmLimitMag : Form
    {
        public frmLimitMag()
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
        FCustomerManager bllFCmanager = new FCustomerManager();
        private www.gzwulian.com.Model.FCustomer fCustomerModel = new FCustomer();
        private List<BaseSet>  allList = null;
        private List<BaseSet> seleList = null;
        List<BaseSet> list = new List<BaseSet>();
        private BaseSetManager baseSetBLL = new BaseSetManager();
        private void frmFCustomer_Load(object sender, EventArgs e)
        {
            getdevice();//填充设备列表
            this.ucPageBar1.OnDataBind += new www.gzwulian.com.Common.ucPageBar.DataBind(SelectDataBind);
            this.ucPageBar1.RefreshData(true);
        }

        /// <summary>
        /// 数据绑定到dataGridView1
        /// </summary>
        /// <param name="pageSize">每页对少条数据</param>
        /// <param name="currentPage">当前页码</param>
        public void DataBind(uint pageSize, uint currentPage)
        {
            string sqlWhere = "";

            strWhere.Remove(0, strWhere.ToString().Length);
            if (!string.IsNullOrEmpty(tbxFcName.Text.Trim()))
            {
                strWhere.Append(" Name like '%" + tbxFcName.Text.Trim() + "%' ");

            }
            if (!string.IsNullOrEmpty(cbbSex.Text.Trim()))
            {
                if (strWhere.ToString().Contains("like"))
                {
                    strWhere.Append(" and Gender like " + "'%" + cbbSex.Text.Trim() + "%'");
                }
                else
                {
                    strWhere.Append(" Gender like " + "'%" + cbbSex.Text.Trim() + "%'");
                }
            }
            if (!string.IsNullOrEmpty(tbxIdCard.Text.Trim()))
            {
                if (strWhere.ToString().Contains("like"))
                {
                    strWhere.Append(" and IdCard like " + "'" + tbxIdCard.Text.Trim() + "%'");
                }
                else
                {
                    strWhere.Append(" IdCard like " + "'" + tbxIdCard.Text.Trim() + "%'");
                }
            }
            if (!string.IsNullOrEmpty(tbxTelphone.Text.Trim()))
            {
                if (strWhere.ToString().Contains("like"))
                {
                    strWhere.Append(" and Telphone like " + "'%" + tbxTelphone.Text.Trim() + "%'");
                }
                else
                {
                    strWhere.Append(" Telphone like " + "'%" + tbxTelphone.Text.Trim() + "%'");
                }
            }
            if (!string.IsNullOrEmpty(tbxPlateId.Text.Trim()))
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
            if (!string.IsNullOrEmpty(tbxCode.Text.Trim()))
            {
                if (strWhere.ToString().Contains("like"))
                {
                    strWhere.Append(" and Code like " + "'%" + tbxCode.Text.Trim() + "%'");
                }
                else
                {
                    strWhere.Append(" Code like " + "'%" + tbxCode.Text.Trim() + "%'");
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
            //if (currentpage == sumpages)
            //{
            //    endindex = (currentpage - 1) * pagesize + count % pagesize;
            //}
            DataSet ds = bllFCmanager.GetListByPage(sqlWhere, "", startindex,endindex);
            DataTable dt = ds.Tables[0];
            this.dgvFCustomerInfo.Columns.Clear();
            BindDataGridView(ds);
            ds.Dispose();
            dt.Dispose();

        }

        void BindDataGridView(DataSet ds)
        {

            this.dgvFCustomerInfo.DataSource = ds.Tables[0];
            this.dgvFCustomerInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//标题居中
            this.dgvFCustomerInfo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//内容居中

            // 设置中文列名及可写状态
            this.dgvFCustomerInfo.Columns["Id"].HeaderText = "编号";
            this.dgvFCustomerInfo.Columns["Id"].ToolTipText = "[只读列]";
            this.dgvFCustomerInfo.Columns["Id"].DisplayIndex = 0;
            this.dgvFCustomerInfo.Columns["Id"].ReadOnly = true;
            this.dgvFCustomerInfo.Columns["Id"].Width = 40;
            this.dgvFCustomerInfo.Columns["Name"].HeaderText = "客户名称";
            this.dgvFCustomerInfo.Columns["Name"].ToolTipText = "[只读列]";
            this.dgvFCustomerInfo.Columns["Name"].DisplayIndex = 1;
            this.dgvFCustomerInfo.Columns["Name"].ReadOnly = true;
            this.dgvFCustomerInfo.Columns["Name"].Width = 80;
            this.dgvFCustomerInfo.Columns["Gender"].HeaderText = "性别";
            this.dgvFCustomerInfo.Columns["Gender"].DisplayIndex = 2;
            this.dgvFCustomerInfo.Columns["Gender"].Width = 40;
            this.dgvFCustomerInfo.Columns["IdCard"].HeaderText = "身份证号";
            this.dgvFCustomerInfo.Columns["IdCard"].DisplayIndex = 3;
            this.dgvFCustomerInfo.Columns["IdCard"].Width = 85;
            this.dgvFCustomerInfo.Columns["Telphone"].HeaderText = "联系电话";
            this.dgvFCustomerInfo.Columns["Telphone"].DisplayIndex = 4;
            this.dgvFCustomerInfo.Columns["Telphone"].Width = 80;
            this.dgvFCustomerInfo.Columns["PlateId"].HeaderText = "车牌号码";
            this.dgvFCustomerInfo.Columns["PlateId"].DataPropertyName = "PlateId";
            this.dgvFCustomerInfo.Columns["PlateId"].Width = 80;
            this.dgvFCustomerInfo.Columns["Enable"].HeaderText = "是否启用";
            this.dgvFCustomerInfo.Columns["Enable"].Width = 80;
            this.dgvFCustomerInfo.Columns["CreateTime"].HeaderText = "建档时间";
            this.dgvFCustomerInfo.Columns["CreateTime"].Width = 80;
            this.dgvFCustomerInfo.Columns["OverTime"].HeaderText = "过期时间";
            this.dgvFCustomerInfo.Columns["OverTime"].Width = 80;
            this.dgvFCustomerInfo.Columns["PlateColor"].HeaderText = "车牌颜色";
            this.dgvFCustomerInfo.Columns["PlateColor"].Width = 80;
            this.dgvFCustomerInfo.Columns["CarType"].HeaderText = "车辆类型";
            this.dgvFCustomerInfo.Columns["CarType"].Width = 80;

            this.dgvFCustomerInfo.Columns["Address"].Visible = false;
            this.dgvFCustomerInfo.Columns["Department"].Visible = false;
            this.dgvFCustomerInfo.Columns["Position"].Visible = false;
            this.dgvFCustomerInfo.Columns["JoinDate"].Visible = false;
            this.dgvFCustomerInfo.Columns["BirthDate"].Visible = false;
            this.dgvFCustomerInfo.Columns["IsMarried"].Visible = false;
            this.dgvFCustomerInfo.Columns["TopDegree"].Visible = false;
            this.dgvFCustomerInfo.Columns["Affiliation"].Visible = false;
            this.dgvFCustomerInfo.Columns["Path"].Visible = false;
            this.dgvFCustomerInfo.Columns["School"].Visible = false;
            this.dgvFCustomerInfo.Columns["Majou"].Visible = false;
            this.dgvFCustomerInfo.Columns["PostalCode"].Visible = false;
            this.dgvFCustomerInfo.Columns["NativePlace"].Visible = false;
            this.dgvFCustomerInfo.Columns["ParkId"].Visible = false;
            this.dgvFCustomerInfo.Columns["OperatorName"].Visible = false;
            this.dgvFCustomerInfo.Columns["AddTime"].Visible = false;
            this.dgvFCustomerInfo.Columns["CompanyCode"].Visible = false;
            this.dgvFCustomerInfo.Columns["Row"].Visible = false;
            this.dgvFCustomerInfo.Columns["TimeSeg"].Visible = false;
            
            //this.dgvFCustomerInfo.Columns["CreateTime"].Visible = false;
            this.dgvFCustomerInfo.Columns["StartTimeSeg"].Visible = false;
            this.dgvFCustomerInfo.Columns["NeedAlarm"].Visible = false;
            this.dgvFCustomerInfo.Columns["ImgPath"].Visible = false;
            this.dgvFCustomerInfo.Columns["Code"].Visible = false;
            this.dgvFCustomerInfo.Columns["IsUpload"].Visible = false;   
           
        }
        AxVZLPRClientCtrl axCtrl = new AxVZLPRClientCtrl();
        private int lprHandle=0;
        private void tspbtnSyn_Click(object sender, EventArgs e)
        {
            bool issele = false;
            string strsql = String.Empty;
            if (cListEquip.Items.Count > 0)
            {
                for (int i = 0; i < cListEquip.Items.Count; i++)
                {
                    if (cListEquip.GetItemChecked(i))
                    {
                        string strtemp;
                        string[] str;
                        strtemp = cListEquip.GetItemText(cListEquip.Items[i]);
                        str = strtemp.Split('/');
                        if (!string.IsNullOrEmpty(strsql))
                        {
                            strsql =strsql +  " or id =" + str[0];
                        }
                        else
                        {
                            strsql = " id =" + str[0];
                        }
                        issele = true;
                    }

                }
            }
           if(!issele)
            {
                MessageBox.Show("没有选择的设备，请先获取并选择设备后再试","提示！");
                return;

            }

            if (seleList == null)
            {
                seleList = new List<BaseSet>();
            }


           seleList = baseSetBLL.GetModelList(strsql);



            try
            {
              
                int flag = -1;
                if (ctrlpanel.Controls.Count == 0)
                {
                    axCtrl.Dock = DockStyle.Fill;
                    //((System.ComponentModel.ISupportInitialize)(this.axCtrl)).BeginInit();
                    ctrlpanel.Controls.Add(axCtrl);
                    //((System.ComponentModel.ISupportInitialize)(this.axCtrl)).EndInit();
                    //axCtrl.SetWindowStyle(1);
                    ctrlpanel.Visible = false;
                }



              
                {

                    foreach (BaseSet baseSet in seleList)
                    {
                        BackgroundWorker worker = GetWorker();
                        worker.RunWorkerAsync();

                        lprHandle = axCtrl.VzLPRClientOpen(baseSet.EquipIp, Convert.ToInt16(baseSet.Port), baseSet.LoginrName, baseSet.LoginPwd);


                        
                       
                        if (lprHandle > 0)
                        {
                            int rows = this.dgvFCustomerInfo.SelectedRows.Count;
                            for (int i = 0; i < rows; i++)
                            {
                                int id = int.Parse(this.dgvFCustomerInfo.SelectedRows[i].Cells["Id"].Value.ToString());
                                fCustomerModel = bllFCmanager.GetModel(id);
                                string plateId = fCustomerModel.PlateId;
                                int customerCode = fCustomerModel.Id;
                                bool enable = fCustomerModel.Enable;
                                string overTime = fCustomerModel.OverTime.ToString();
                                string createTime = fCustomerModel.CreateTime.ToString();
                                bool startTimeSeg = fCustomerModel.StartTimeSeg;
                              //  bool needAlarm = false;
                                bool needAlarm = fCustomerModel.NeedAlarm;
                                string strName = fCustomerModel.Name.ToString();

                                //flag = axCtrl.VzLPRClientAddWlistToArray(plateId, customerCode, enable,false,false, overTime,overTime, enable, startTimeSeg, plateId,plateId, lprHandle);
                               // flag = axCtrl.VzLPRClientBatchImportWlistFromArray(lprHandle);
                                //  flag = axCtrl.VzLPRClientAddWlist(plateId, customerCode, enable, overTime, enable, false, plateId, lprHandle);
                                //flag = axCtrl.VzLPRClientAddWlist(plateId, customerCode, enable, overTime, startTimeSeg, false, plateId, lprHandle);

                                  flag = axCtrl.VzLPRClientAddWlistEx(plateId, customerCode, enable,enable,enable, createTime, overTime,false,false,strName,plateId, lprHandle);
                            }
                           
                        }
                        else
                        {
                            worker.CancelAsync();
                            if (!MessageHelper.ConfirmYesNo("设备:【" + baseSet.EquipIp + "】不在线，同步失败,是否同步下一台试备？"))
                            {
                              
                                return;
                            }
                        }
                        worker.CancelAsync();

                    }

                 //   worker.CancelAsync();
                    if (flag == 0)
                    {
                        MessageHelper.ShowTips("数据同步成功！");
                    }
                    else
                    {
                        MessageHelper.ShowTips("数据同步失败！");
                        return;
                    }
                   
                }
              
            }
            catch (Exception)
            {
                //worker.CancelAsync();
                MessageHelper.ShowTips("系统异常,同步失败，请稍后再试！");
            }
 
        }
        private BackgroundWorker GetWorker()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.WorkerSupportsCancellation = true;
            return worker;
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            frmWait waitfrm = new frmWait();
            waitfrm.showtip = "正在同步，请稍后......";
            waitfrm.Show();
            BackgroundWorker worker = (BackgroundWorker)sender;
            while (true)
            {

                waitfrm.BringToFront();
                waitfrm.Refresh();
                if (worker.CancellationPending)
                {
                    waitfrm.Close();
                    e.Cancel = true;
                }
                else
                    e.Cancel = false;
                System.Threading.Thread.Sleep(10);
            }
        }
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ((BackgroundWorker)sender).Dispose();
        }
        private void dgvFCustomerInfo_DataSourceChanged(object sender, EventArgs e)
        {
            this.dgvFCustomerInfo.AutoGenerateColumns = false;
        }

        private void btnProQuery_Click(object sender, EventArgs e)
        {
            SelectDataBind(this.ucPageBar1.PageSize, this.ucPageBar1.CurrentPage);
           this.ucPageBar1.RefreshData(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tbxFcName.Text = "";
            cbbSex.Text = tbxCode.Text="";
            tbxIdCard.Text = tbxPlateId.Text = tbxTelphone.Text = "";
            cbxFalseFC.Checked = cbxTrueFc.Checked = false;
            cbxFalseTime.Visible = cbxTrueTime.Visible = false;

            this.ucPageBar1.OnDataBind += new www.gzwulian.com.Common.ucPageBar.DataBind(SelectDataBind);
            this.ucPageBar1.RefreshData(true);
        }



    



        private void btnToExcel_Click(object sender, EventArgs e)
        {
          
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
                                    if (grid.Rows[i].Cells[j].Value.ToString() == "TRUE")
                                    {
                                        sw.Write("是");
                                        sw.Write('\t');
                                    }
                                    else if (grid.Rows[i].Cells[j].Value.ToString() == "FALSE")
                                    {
                                        sw.Write("否");
                                        sw.Write('\t');
                                    }
                                    else
                                    {
                                        sw.Write(grid.Rows[i].Cells[j].Value);
                                        sw.Write('\t');
                                    }
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

        private void cbxFalseFC_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbxFalseFC.Checked)
            {
                this.cbxTrueFc.Checked = false;
                this.cbxFalseTime.Visible =cbxFalseTime.Checked= false;
                this.cbxTrueTime.Visible = cbxTrueTime.Checked = false;
            }
        }

        private void cbxTrueFc_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbxTrueFc.Checked)
            {
                this.cbxFalseFC.Checked = cbxTrueTime.Checked =cbxFalseTime.Checked= false;
                this.cbxFalseTime.Visible = true;
                this.cbxTrueTime.Visible  = true;
            }
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
            if (!string.IsNullOrEmpty(tbxFcName.Text.Trim()))
            {
                strWhere.Append(" Name like '%" + tbxFcName.Text.Trim() + "%' ");

            }
            if (!string.IsNullOrEmpty(cbbSex.Text.Trim()))
            {
                if (strWhere.ToString().Contains("like"))
                {
                    strWhere.Append(" and Gender like " + "'%" + cbbSex.Text.Trim() + "%'");
                }
                else
                {
                    strWhere.Append(" Gender like " + "'%" + cbbSex.Text.Trim() + "%'");
                }
            }
            if (!string.IsNullOrEmpty(tbxIdCard.Text.Trim()))
            {
                if (strWhere.ToString().Contains("like"))
                {
                    strWhere.Append(" and IdCard like " + "'" + tbxIdCard.Text.Trim() + "%'");
                }
                else
                {
                    strWhere.Append(" IdCard like " + "'" + tbxIdCard.Text.Trim() + "%'");
                }
            }
            if (!string.IsNullOrEmpty(tbxTelphone.Text.Trim()))
            {
                if (strWhere.ToString().Contains("like"))
                {
                    strWhere.Append(" and Telphone like " + "'%" + tbxTelphone.Text.Trim() + "%'");
                }
                else
                {
                    strWhere.Append(" Telphone like " + "'%" + tbxTelphone.Text.Trim() + "%'");
                }
            }
            if (!string.IsNullOrEmpty(tbxPlateId.Text.Trim()))
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
            if (!string.IsNullOrEmpty(tbxCode.Text.Trim()))
            {
                if (strWhere.ToString().Contains("like"))
                {
                    strWhere.Append(" and Code like " + "'%" + tbxCode.Text.Trim() + "%'");
                }
                else
                {
                    strWhere.Append(" Code like " + "'%" + tbxCode.Text.Trim() + "%'");
                }
            }

            string Time = DateTime.Now.ToShortDateString();
            if (cbxTrueFc.Checked)
            {
                if (cbxTrueTime.Checked)
                {
                    if (strWhere.ToString().Contains("like"))
                        strWhere.Append(" and Enable = '" + cbxTrueFc.Checked + "' and  OverTime > '" + Time + "'");
                    else
                        strWhere.Append(" Enable = '" + cbxTrueFc.Checked + "' and  OverTime > '" + Time + "'");
                }
                else if (cbxFalseTime.Checked)
                {
                    if (strWhere.ToString().Contains("like"))
                        strWhere.Append(" and Enable = '" + cbxTrueFc.Checked + "' and  OverTime < '" + Time + "'");
                    else
                        strWhere.Append(" Enable = '" + cbxTrueFc.Checked + "' and  OverTime < '" + Time + "'");
                }
                else
                {
                    if (strWhere.ToString().Contains("like"))
                        strWhere.Append(" and Enable = '" + cbxTrueFc.Checked + "'");
                    else
                        strWhere.Append(" Enable = '" + cbxTrueFc.Checked + "'");
                }
          
            }
            else if (cbxFalseFC.Checked)
            {
                if (strWhere.ToString().Contains("like"))
                    strWhere.Append(" and Enable = 'False'");
                else
                    strWhere.Append(" Enable = 'False'");
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
                endindex = (currentpage - 1) * pagesize + count % pagesize;
            }
            DataSet ds = bllFCmanager.GetListByPage(sqlWhere, "",startindex,endindex);
            DataTable dt = ds.Tables[0];
            this.dgvFCustomerInfo.Columns.Clear();
            BindDataGridView(ds);
            //foreach (DataRow row in dt.Rows)
            //{
            //    this.dgvFCustomerInfo.Rows.Add(row["Id"], row["Name"], row["Gender"], row["IdCard"],
            //        row["Telphone"], row["PlateId"], row["Enable"]   );

            //}
            ds.Dispose();
            dt.Dispose();

        }

        private void cbxTrueTime_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxTrueTime.Checked)
                this.cbxFalseTime.Checked = false;
        }

        private void cbxFalseTime_CheckedChanged(object sender, EventArgs e)
        {
            if(cbxFalseTime.Checked)
                this.cbxTrueTime.Checked = false;
        }

        private void tspbtnUpdateTime_Click(object sender, EventArgs e)
        {
            if (this.dgvFCustomerInfo.Rows.Count == 0)
            {
                return;
            }
            if (this.dgvFCustomerInfo.SelectedRows.Count < 1)
            {
                MessageHelper.ShowTips("请先选择要操作的数据!");
                return;
            }
            int id = int.Parse(this.dgvFCustomerInfo.SelectedRows[0].Cells["Id"].Value.ToString());
            frmLimitUpdateT frmFcUpdate = new frmLimitUpdateT(id);
            frmFcUpdate.ShowDialog();

            this.ucPageBar1.OnDataBind += new www.gzwulian.com.Common.ucPageBar.DataBind(SelectDataBind);
            this.ucPageBar1.RefreshData(true);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            sfdDataToExcel.Filter = "Excel工作簿|*.xls";
            DialogResult dlt = sfdDataToExcel.ShowDialog();
            // DT= dataGridView1.DataSource;
            if (dlt == DialogResult.OK)
            {
                WriteToExcel(dgvFCustomerInfo);
            }
        }

        private void btseleall_Click(object sender, EventArgs e)
        {
            if (btseleall.Tag.ToString() == "0")
            {
                for (int i = 0; i < cListEquip.Items.Count;i++)
                {
                    cListEquip.SetItemChecked(i,true);

                }
                btseleall.Text = "全不选";
                btseleall.Tag = 1;
            }
            else
            {
                for (int i = 0; i < cListEquip.Items.Count; i++)
                {
                    cListEquip.SetItemChecked(i, false);

                }
                btseleall.Text = "全  选";
                btseleall.Tag = 0;



            }

        }

        private void btgetall_Click(object sender, EventArgs e)
        {
            getdevice();

        }

        private void getdevice()
        {
            if (allList == null)
            {
                allList = new List<BaseSet>();
            }

            allList = baseSetBLL.GetModelList("");
            cListEquip.Items.Clear();
            foreach (BaseSet baseSet in allList)
            {
                string stritem = String.Empty;
                stritem = baseSet.Id.ToString() + "/IP:{" + baseSet.EquipIp + "},位置:{" + baseSet.Position + "}";
                cListEquip.Items.Add(stritem);

            }
            for (int i = 0; i < cListEquip.Items.Count; i++)
            {
                cListEquip.SetItemChecked(i, true);

            }
            btseleall.Text = "全不选";

        }
    }
}
