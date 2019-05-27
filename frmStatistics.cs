using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using www.gzwulian.com.BLL;
using www.gzwulian.com.DBUtility;

namespace ChargeWin
{
    public partial class frmStatistics : Form
    {
        public frmStatistics()
        {
            InitializeComponent();
        }

        ChargeRecordManager chargeRecordBLL=new ChargeRecordManager();
        private DataSet ds = null;
        private void frmStatistics_Load(object sender, EventArgs e)
        {
            BindYears();
            BindData(DateTime.Now.Year);
        }

        private void feeChart_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePoint = new Point(e.X, e.Y);
            feeChart.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);
        }
        List<string> listx = new List<string>();
        List<decimal> listy = new List<decimal>();
        /// <summary>
        /// 绑定数据到chart
        /// </summary>
        private void BindData(int year)
        {
            ds = chargeRecordBLL.FeeStatistics(year);
            listx.Clear();
            listy.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listx.Add(ds.Tables[0].Rows[i]["MM"].ToString());
                listy.Add((decimal)ds.Tables[0].Rows[i]["Money"]);
            }
            feeChart.ChartAreas[0].AxisX.Title = "月份";
            feeChart.ChartAreas[0].AxisY.Title = "停车费额（元）";
            feeChart.ChartAreas[0].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.None;
            feeChart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            feeChart.ChartAreas[0].CursorX.IsUserEnabled = true;
            this.feeChart.Series[0].ToolTip = "#VALX,#VAL";
            feeChart.Series[0].Points.DataBindXY(listx, listy);
            feeChart.Series[0].IsValueShownAsLabel = true;
            feeChart.Series[0].SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.Yes;
            //feeChart.DataBindTable(ds.Tables[0].DefaultView);
        }

        /// <summary>
        /// 绑定年份
        /// </summary>
        private void BindYears()
        {
            cbYear.Items.Clear();
            List<int> listyear=new List<int>();
            int year = DateTime.Now.Year;
            for (int i = 0; i < 4;i++ )
            {
                listyear.Add(year);
                year--;
            }
            cbYear.DataSource = listyear;
            
        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbYear.SelectedItem!="")
            {
                BindData(Convert.ToInt32(cbYear.SelectedItem));
            }
         
        }
    }
}
