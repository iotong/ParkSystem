using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using www.gzwulian.com.BLL;
using www.gzwulian.com.Common;
using www.gzwulian.com.Model;
using AxVZLPRClientCtrlLib;
using ChargeWin;

namespace ChargeWin
{
    public partial class frmFCustomer : Form
    {
        public frmFCustomer()
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
        private www.gzwulian.com.Model.FCustomer fCustomerModel = new FCustomer();
        public static string stroldplate = string.Empty, strnewplate=string.Empty;
        private BaseSet inbaseSetModel = null;
        private BaseSet outbaseSetModel = null;
        private List<BaseSet> allList = null;
        private List<BaseSet> seleList = null;
        private string plateId ;
        private string strName;
        private int customerCode ;
        private bool enable ;
        private string overTime ;
        private string createTime;
        private bool startTimeSeg ;
        private bool needAlarm ;


        private BaseSetManager baseSetBLL = new BaseSetManager();
        FCustomerManager bllFCmanager = new FCustomerManager();
        private void frmFCustomer_Load(object sender, EventArgs e)
        {
            //this.dgvFCustomerInfo.AutoGenerateColumns = false;时出问题，DGV列绑定时未将对象引用到实例
            //ds = bllFCmanager.GetAllList();
            getdevice();
            this.ucPageBar1.OnDataBind += new www.gzwulian.com.Common.ucPageBar.DataBind(SelectDataBind);
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
            if (currentpage == sumpages)
            {
                endindex = (currentpage - 1) * pagesize + count % pagesize;
            }
            DataSet ds = bllFCmanager.GetListByPage(sqlWhere, "", startindex,endindex);
            DataTable dt = ds.Tables[0];
            this.dgvFCustomerInfo.Columns.Clear();
            BindDataGridView(ds);
            ds.Dispose();
            dt.Dispose();

        }

        void BindDataGridView(DataSet ds)
        {
            //this.dgvFCustomerInfo.DataSource = ds.Tables[0].DefaultView;

            List<www.gzwulian.com.Model.FCustomer> fCustomersList = bllFCmanager.DataTableToList(ds.Tables[0]);
            this.dgvFCustomerInfo.DataSource = fCustomersList;
            this.dgvFCustomerInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvFCustomerInfo.ColumnHeadersHeight = 400;
            this.dgvFCustomerInfo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            

            // 设置中文列名及可写状态
            // 设置中文列名及可写状态
            //this.dgvFCustomerInfo.Columns["Id"].HeaderText = "编号";
            //this.dgvFCustomerInfo.Columns["Id"].ToolTipText = "[只读列]";
            //this.dgvFCustomerInfo.Columns["Id"].DisplayIndex = 0;
            //this.dgvFCustomerInfo.Columns["Id"].ReadOnly = true;
            //this.dgvFCustomerInfo.Columns["Id"].Width = 40;


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
            this.dgvFCustomerInfo.Columns["IdCard"].Width = 120;

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
            this.dgvFCustomerInfo.Columns["Id"].Visible = false;

            //this.dgvFCustomerInfo.Columns["CreateTime"].Visible = false;
            this.dgvFCustomerInfo.Columns["StartTimeSeg"].Visible = false;
            this.dgvFCustomerInfo.Columns["NeedAlarm"].Visible = false;
            this.dgvFCustomerInfo.Columns["ImgPath"].Visible = false;
            this.dgvFCustomerInfo.Columns["Code"].Visible = false;
            this.dgvFCustomerInfo.Columns["TimeSeg"].Visible = false;  
            this.dgvFCustomerInfo.Columns["IsUpload"].Visible=false;
        }

        private void tspbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();

           

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

        private void tspbtnRefresh_Click(object sender, EventArgs e)
        {

            tbxFcName.Text = "";
            cbbSex.Text = tbxCode.Text = "";
            tbxIdCard.Text = tbxPlateId.Text = tbxTelphone.Text = "";

            this.ucPageBar1.OnDataBind += new www.gzwulian.com.Common.ucPageBar.DataBind(SelectDataBind);
            this.ucPageBar1.RefreshData(true);
        }
        AxVZLPRClientCtrl axCtrl = new AxVZLPRClientCtrl();
        private int lprHandle = 0;
        /// <summary>
        /// 删除白名单
        /// </summary>
        /// <returns></returns>
        private void Delete(object plateid)
        {
            try
            {
                inbaseSetModel = new BaseSet();
                outbaseSetModel = new BaseSet();
                inbaseSetModel = baseSetBLL.GetModelList("EquipType='入口设备'").First();
                outbaseSetModel = baseSetBLL.GetModelList("EquipType='出口设备'").First();
                List<BaseSet> list = new List<BaseSet>();
                if (inbaseSetModel != null && outbaseSetModel != null)
                {
                    list.Add(inbaseSetModel);
                    list.Add(outbaseSetModel);
                }
                int flag = -1;
                axCtrl.Dock = DockStyle.Fill;
                ctrlpanel.Controls.Add(axCtrl);
                //axCtrl.SetWindowStyle(1);
                ctrlpanel.Visible = false;
                foreach (BaseSet baseSet in list)
                {
                    lprHandle = axCtrl.VzLPRClientOpen(baseSet.EquipIp, Convert.ToInt16(baseSet.Port), baseSet.LoginrName, baseSet.LoginPwd);
                    int rows = this.dgvFCustomerInfo.SelectedRows.Count;
                    if (lprHandle != 0)
                    {
                        for (int i = 0; i < rows; i++)
                        {
                            //int id = int.Parse(this.dgvFCustomerInfo.SelectedRows[i].Cells["Id"].Value.ToString());
                            //fCustomerModel = bllFCmanager.GetModel(id);
                            //string plateId = fCustomerModel.PlateId;
                            if (lprHandle > 0)
                            {
                                flag = axCtrl.VzLPRClientDeleteWlist(plateid.ToString(), lprHandle);
                            }
                        }
                    }
                 
                }

            }
            catch (Exception)
            {

            }
           
        }

        private void tspbtnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvFCustomerInfo.Rows.Count == 0)
            {
                return;
            }
            if (this.dgvFCustomerInfo.SelectedRows.Count<1)
            {
               MessageHelper.ShowTips("请先选择要操作的数据！");
                return;
            }
            bool flag = false;
            DialogResult dr = MessageBox.Show(this, "确定删除该用户？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                    for (int i = 0; i < this.dgvFCustomerInfo.SelectedRows.Count; i++)
                    {
                      int id = int.Parse(this.dgvFCustomerInfo.SelectedRows[i].Cells["Id"].Value.ToString());
                        if (id != 0)
                        {
                            www.gzwulian.com.Model.FCustomer fmodel = bllFCmanager.GetModel(id);
                            stroldplate = fmodel.PlateId;
                            flag = bllFCmanager.Delete(id);
                            if (flag)
                            {
                                try
                                {
                                    DelPlatetoDevice(stroldplate);
                                    //删除白名单
                                    //Thread th = new Thread(new ParameterizedThreadStart(Delete));
                                    //th.IsBackground = true;
                                    //th.Start();
                                    //Delete(fmodel.PlateId);
                                }
                                catch (Exception)
                                {

                                }
                            }
                          
                        }
                    }
            }
            if (flag)
            {
                MessageHelper.ShowTips("删除成功！");
                this.ucPageBar1.RefreshData(false);
            }
            else
            {
                MessageHelper.ShowTips("删除失败！");
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmFCustomerAdd frmFcAdd = new frmFCustomerAdd("添加",0);
            frmFcAdd.TopMost = true;
            frmFcAdd.ShowDialog();

            if (frmFcAdd.DialogResult == DialogResult.OK)
            {

                AddPlatetoDevice(strnewplate,true);
                this.ucPageBar1.OnDataBind += new www.gzwulian.com.Common.ucPageBar.DataBind(SelectDataBind);
                this.ucPageBar1.RefreshData(true);


            }


        }

        private void AddPlatetoDevice(string strnewplate,bool add)
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
                            strsql = strsql + " or id =" + str[0];
                        }
                        else
                        {
                            strsql = " id =" + str[0];
                        }
                        issele = true;
                    }

                }
            }
            if (!issele)
            {
                MessageBox.Show("没有选择的设备，请先获取并选择设备后再试", "提示！");
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
                    ctrlpanel.Controls.Add(axCtrl);
                    ctrlpanel.Visible = false;
                }
                {
                    foreach (BaseSet baseSet in seleList)
                    {
                        lprHandle = axCtrl.VzLPRClientOpen(baseSet.EquipIp, Convert.ToInt16(baseSet.Port), baseSet.LoginrName, baseSet.LoginPwd);
                        if (lprHandle > 0)
                        {
                           // if (!add)
                           // {
                                int id = int.Parse(this.dgvFCustomerInfo.SelectedRows[0].Cells["Id"].Value.ToString());
                                fCustomerModel = bllFCmanager.GetModel(id);
                                int customerCode = fCustomerModel.Id;
                                bool enable = fCustomerModel.Enable;
                                string overTime = fCustomerModel.OverTime.ToString();
                                string createTime = fCustomerModel.CreateTime.ToString();
                                bool startTimeSeg = fCustomerModel.StartTimeSeg;
                                bool needAlarm = fCustomerModel.NeedAlarm;
                                string strName = fCustomerModel.Name.ToString();//用户名称
                          //  }

                             flag = axCtrl.VzLPRClientAddWlistEx(strnewplate, customerCode, enable, enable, enable, createTime, overTime, false, false, strName, plateId, lprHandle);
                        }
                        else
                        {

                            if (!MessageHelper.ConfirmYesNo("设备:【" + baseSet.EquipIp + "】不在线，同步失败,是否同步下一台试备？"))
                            {

                                return;
                            }
                        }


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

            //  MessageBox.Show(strnewplate);
        }

        private void tspbtnUpdate_Click(object sender, EventArgs e)
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
            stroldplate = dgvFCustomerInfo.SelectedRows[0].Cells["PlateId"].Value.ToString();
           // int id = int.Parse(this.dgvFCustomerInfo.SelectedRows[0].Cells["Id"].Value.ToString());
            fCustomerModel = bllFCmanager.GetModel(id);
            plateId = strnewplate;
            customerCode = fCustomerModel.Id;
            strName = fCustomerModel.Name;
            enable = fCustomerModel.Enable;
            overTime = fCustomerModel.OverTime.ToString();
            createTime = fCustomerModel.CreateTime.ToString();
            startTimeSeg = fCustomerModel.StartTimeSeg;
            needAlarm = fCustomerModel.NeedAlarm;



            frmFCustomerAdd frmFcUpdate = new frmFCustomerAdd("修改", id);
            frmFcUpdate.TopMost = true;
            frmFcUpdate.ShowDialog();

            if (frmFcUpdate.DialogResult == DialogResult.OK)
            {
                if (stroldplate!=strnewplate)
                {
                    DelPlatetoDevice(stroldplate);
                    AddPlatetoDevice(strnewplate,false);

                }
                this.ucPageBar1.OnDataBind += new www.gzwulian.com.Common.ucPageBar.DataBind(SelectDataBind);
                this.ucPageBar1.RefreshData(true);

            }


        }

        private void DelPlatetoDevice(string stroldplate)
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
                            strsql = strsql + " or id =" + str[0];
                        }
                        else
                        {
                            strsql = " id =" + str[0];
                        }
                        issele = true;
                    }

                }
            }
            if (!issele)
            {
                MessageBox.Show("没有选择的设备，请先获取并选择设备后再试", "提示！");
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
                    ctrlpanel.Controls.Add(axCtrl);
                     ctrlpanel.Visible = false;
                }
                {
                    foreach (BaseSet baseSet in seleList)
                    {
                        lprHandle = axCtrl.VzLPRClientOpen(baseSet.EquipIp, Convert.ToInt16(baseSet.Port), baseSet.LoginrName, baseSet.LoginPwd);
                        if (lprHandle > 0)
                        {
                          
                                flag = axCtrl.VzLPRClientDeleteWlist(stroldplate,lprHandle);
              
                       }
                        else
                        {

                            if (!MessageHelper.ConfirmYesNo("设备:【" + baseSet.EquipIp + "】不在线，同步失败,是否同步下一台试备？"))
                            {

                                return;
                            }
                        }


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



        //    MessageBox.Show(stroldplate);
           // throw new NotImplementedException();
        }

        private void btnToExcel_Click(object sender, EventArgs e)
        {
            sfdDataToExcel.Filter = "Excel工作簿|*.xls";
            DialogResult dlt = sfdDataToExcel.ShowDialog();
            if (dlt == DialogResult.OK)
            {
                WriteToExcel();
            }
        }

        /// <summary>
        /// 导出数据至Excel表
        /// </summary>
        /// <param name="grid">数据源DatagridView</param>
        public void WriteToExcel()
        {
            try
            {
                //创建Excel文件的对象
                NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
                //添加一个sheet
                NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");
                //获取list数据
                List<FCustomer> listInfo = bllFCmanager.GetModelList("");
                //var pName = listInfo[0].ParkInfo.ParkName;
                //给sheet1添加第一行的头部标题
                NPOI.SS.UserModel.IRow headrow = sheet1.CreateRow(0);
                headrow.CreateCell(0).SetCellValue("客户编码");
                headrow.CreateCell(1).SetCellValue("客户姓名");
                headrow.CreateCell(2).SetCellValue("性别");
                headrow.CreateCell(3).SetCellValue("身份证号");
                headrow.CreateCell(4).SetCellValue("联系电话");
                headrow.CreateCell(5).SetCellValue("车牌号码");
                headrow.CreateCell(6).SetCellValue("车牌颜色");
                headrow.CreateCell(7).SetCellValue("是否启用");
                headrow.CreateCell(8).SetCellValue("建档时间");
                headrow.CreateCell(9).SetCellValue("过期时间");
                headrow.CreateCell(10).SetCellValue("车辆类型");
                headrow.CreateCell(11).SetCellValue("停车场编号");
                headrow.CreateCell(12).SetCellValue("备注");

                //将数据逐步写入sheet1各个行
                for (int i = 0; i < listInfo.Count; i++)
                {
                    NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);
                    rowtemp.CreateCell(0).SetCellValue(listInfo[i].Code.ToString());
                    rowtemp.CreateCell(1).SetCellValue(listInfo[i].Name.ToString());
                    rowtemp.CreateCell(2).SetCellValue(listInfo[i].Gender);
                    rowtemp.CreateCell(3).SetCellValue("");
                    rowtemp.CreateCell(4).SetCellValue(listInfo[i].Telphone);
                    rowtemp.CreateCell(5).SetCellValue(listInfo[i].PlateId);
                    rowtemp.CreateCell(6).SetCellValue(listInfo[i].PlateColor);
                    rowtemp.CreateCell(7).SetCellValue(listInfo[i].Enable == true ? "是" : "否");
                    rowtemp.CreateCell(8).SetCellValue(listInfo[i].CreateTime.ToString());
                    rowtemp.CreateCell(9).SetCellValue(listInfo[i].OverTime.ToString());
                    rowtemp.CreateCell(10).SetCellValue(listInfo[i].CarType);
                    rowtemp.CreateCell(11).SetCellValue(listInfo[i].ParkId);
                    rowtemp.CreateCell(12).SetCellValue("");
                }
                //自适应宽度
                for (int i = 0; i <= 12; i++)
                {
                    sheet1.AutoSizeColumn(i);
                }
                for (int columnNum = 0; columnNum <= 10; columnNum++)
                {
                    int columnWidth = sheet1.GetColumnWidth(columnNum) / 256;
                    for (int rowNum = 1; rowNum <= sheet1.LastRowNum; rowNum++)
                    {
                        IRow currentRow;

                        if (sheet1.GetRow(rowNum) == null)
                        {
                            currentRow = sheet1.CreateRow(rowNum);
                        }
                        else
                        {
                            currentRow = sheet1.GetRow(rowNum);
                        }

                        if (currentRow.GetCell(columnNum) != null)
                        {
                            ICell currentCell = currentRow.GetCell(columnNum);
                            int length = Encoding.Default.GetBytes(currentCell.ToString()).Length;
                            if (columnWidth < length)
                            {
                                columnWidth = length;
                            }
                        }
                    }
                    sheet1.SetColumnWidth(columnNum, columnWidth * 256);
                }
                // 写入到客户端 

                string strFilePath = sfdDataToExcel.FileName; //赋给文件的名字
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    book.Write(ms);
                    ms.Flush();
                    ms.Position = 0;
                    using (FileStream fs = new FileStream(strFilePath, FileMode.Create, FileAccess.Write))
                    {
                        byte[] data = ms.ToArray();
                        fs.Write(data, 0, data.Length);
                        fs.Flush();
                    }
                }
                MessageHelper.ShowTips("导出数据成功！");
            }
            catch (Exception)
            {

                MessageHelper.ShowTips("导出数据失败！");
            }
          




            //string filename ="车辆信息" + dateTime + ".xls";
            //try
            //{
            //    //string tempImagePath = @"D:\EXCEL";//软件安装目录
            //    // string temp = Common.RegistTableUtility.Instance.GetPath() + @"Excel";//目录下的Execl文件夹
            //    //Directory.CreateDirectory(@temp);
            //    string strFilePath = sfdDataToExcel.FileName; //赋给文件的名字
            //    System.IO.StreamWriter sw = new System.IO.StreamWriter(strFilePath, true, System.Text.Encoding.Default); //写入流
            //    object[] values = new object[grid.Columns.Count];
            //    for (int i = 0; i < grid.Columns.Count; ++i)
            //    {
                  
            //        if (grid.Columns[i].HeaderText.ToString() == "项目代码")
            //        {
            //            grid.Columns[i].HeaderText = "项目代码";
            //        }
            //        if (grid.Columns[i].Visible)
            //        {
            //            sw.Write(grid.Columns[i].HeaderText.ToString());
            //            sw.Write('\t');
            //        }
            //    }
            //        sw.Write("\r\n");
            //            for (int i = 0; i < grid.Rows.Count; i++)
            //            {
            //                for (int j = 0; j < values.Length; ++j)
            //                {
            //                    if (grid.Columns[j].Visible)
            //                    {
            //                        if (grid.Rows[i].Cells[j].Value.ToString() == "TRUE")
            //                        {
            //                            sw.Write("是");
            //                            sw.Write('\t');
            //                        }
            //                        else if (grid.Rows[i].Cells[j].Value.ToString() == "FALSE")
            //                        {
            //                            sw.Write("否");
            //                            sw.Write('\t');
            //                        }
            //                        else
            //                        {
            //                            sw.Write(grid.Rows[i].Cells[j].Value);
            //                            sw.Write('\t');
            //                        }
            //                    }
            //                }
            //                sw.Write("\r\n");
            //            }
              
            //    sw.Flush();
            //    sw.Close();
            //    MessageBox.Show("成功导出[" + grid.Rows.Count.ToString() + "]行到Execl！");
            //}
            //catch
            //{
            //    MessageBox.Show("导出Execl失败！");
            //}
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
        /// 数据绑定到DGV
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
            //if (currentpage == sumpages)
            //{
            //    endindex = (currentpage - 1) * pagesize + count % pagesize;
            //}
            DataSet ds = bllFCmanager.GetListByPage(sqlWhere, "",startindex,endindex);
            DataTable dt = ds.Tables[0];
            this.dgvFCustomerInfo.Columns.Clear();
            BindDataGridView(ds);
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

        private IWorkbook workbook = null;
        private void toolBtn_Click(object sender, EventArgs e)
        {
            string path = "";
            System.Windows.Forms.OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "选择文件"; //选择框名称        
            fd.Filter = "xls files (*.xls)|*.xls"; //选择文件的类型为Xls表格          
            if (fd.ShowDialog() == DialogResult.OK) //当点击确定               
            {
                if (!string.IsNullOrWhiteSpace(fd.FileName))
                {
                    path = fd.FileName.Trim(); //文件路径
                    path = path.Replace("\\", "/");
                }
                else
                {
                    MessageHelper.ShowTips("请选择文件！");
                    return;
                }
             
            }
            else
            {
                return;
            }
            int index = 0;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            #region 表头 
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                #region 获取表头
                workbook = new HSSFWorkbook(fs);
                ISheet sheet = workbook.GetSheetAt(index);
                //获取表头   
                IRow header = sheet.GetRow(sheet.FirstRowNum);
                List<int> columns = new List<int>();
                for (int i = 0; i < header.LastCellNum; i++)
                {
                    object obj = GetValueTypeForXls(header.GetCell(i) as HSSFCell);
                    if (obj == null || obj.ToString() == string.Empty)
                    {
                        dt.Columns.Add(new DataColumn("Columns" + i.ToString()));
                    }
                    else
                    {
                        dt.Columns.Add(new DataColumn(obj.ToString()));
                    }
                    columns.Add(i);
                }
                #endregion

                #region 获取数据
                //获取数据   
                for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
                {
                    DataRow dr = dt.NewRow();
                    bool hasValue = false;
                    foreach (int j in columns)
                    {
                        dr[j] = GetValueTypeForXls(sheet.GetRow(i).GetCell(j) as HSSFCell);
                        if (dr[j] != null && dr[j].ToString() != string.Empty)
                        {
                            hasValue = true;
                        }
                    }
                    if (hasValue)
                    {
                        dt.Rows.Add(dr);
                    }
                }
                #endregion
                ds.Tables.Add(dt);
            }
            #endregion
           #region 添加或跟新数据到数据库
            try
            {
                www.gzwulian.com.Model.FCustomer modelFc = new FCustomer();
                int addflag = 0;
                bool updateflag = false;
                for (int i = 0; i < dt.Rows.Count ; i++)
                {
                    modelFc.Name = dt.Rows[i]["客户姓名"].ToString();
                    modelFc.Code = dt.Rows[i]["客户编码"].ToString();
                    modelFc.Gender = dt.Rows[i]["性别"].ToString();
                    modelFc.IdCard = dt.Rows[i]["身份证号"].ToString();
                    modelFc.Telphone = dt.Rows[i]["联系电话"].ToString();
                    modelFc.PlateId = dt.Rows[i]["车牌号码"].ToString();
                    modelFc.PlateColor = dt.Rows[i]["车牌颜色"].ToString();
                    modelFc.CarType = dt.Rows[i]["车辆类型"].ToString();
                    modelFc.CreateTime = Convert.ToDateTime(dt.Rows[i]["建档时间"].ToString());
                    modelFc.OverTime = Convert.ToDateTime(dt.Rows[i]["过期时间"].ToString());
                    modelFc.AddTime =  DateTime.Now;
                    if (dt.Rows[i]["是否启用"].ToString() == "是")
                    {
                        modelFc.Enable = true;
                    }
                    else
                    {
                        modelFc.Enable = false;
                    }
                    modelFc.CompanyCode = LoginInfo.CompanyCode;
                    modelFc.ParkId = LoginInfo.ParkId;
                    www.gzwulian.com.Model.FCustomer model = null;
                    if (bllFCmanager.GetModelList("PlateId='" + modelFc.PlateId + "'").Count > 0)
                    {
                        model = bllFCmanager.GetModelList("PlateId='" + modelFc.PlateId + "'").First();
                    }

                    if (model == null)
                    {
                        addflag = bllFCmanager.Add(modelFc);
                    }
                    else
                    {
                        modelFc.Id = model.Id;
                        updateflag = bllFCmanager.Update(modelFc);
                    }
                }
                if (addflag > 0 || updateflag == true)
                {
                    MessageHelper.ShowTips("数据导入成功!");
                    this.ucPageBar1.RefreshData(false);
                }
                else
                {
                    MessageHelper.ShowTips("数据导入失败!");
                }
            }
            catch (Exception)
            {
                MessageHelper.ShowTips("请检查数据后导入");
                this.ucPageBar1.RefreshData(false);
            }
	     #endregion
    
        }
        /// <summary>   
        /// 获取单元格类型(xls)   
        /// </summary>   
        /// <param name="cell"></param>   
        /// <returns></returns>   
        private static object GetValueTypeForXls(HSSFCell cell)
        {
            if (cell == null)
                return null;
            switch (cell.CellType)
            {
                case CellType.Blank: //BLANK:   
                    return null;
                case CellType.Boolean: //BOOLEAN:   
                    return cell.BooleanCellValue;
                case CellType.Numeric: //NUMERIC:   
                    return cell.NumericCellValue;
                case CellType.String: //STRING:             
                    return cell.StringCellValue;
                case CellType.Error: //ERROR:   
                    return cell.ErrorCellValue;
                case CellType.Formula: //FORMULA:   
                default:
                    return "=" + cell.CellFormula;
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

        private void btseleall_Click(object sender, EventArgs e)
        {
            if (btseleall.Tag.ToString() == "0")
            {
                for (int i = 0; i < cListEquip.Items.Count; i++)
                {
                    cListEquip.SetItemChecked(i, true);

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
    }
}
