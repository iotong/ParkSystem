using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using www.gzwulian.com.BLL;
using www.gzwulian.com.Model;

namespace ChargeWin
{
    public partial class frmTest : Form
    {
        
        public frmTest()
        {
            InitializeComponent();

        }
     
        private void btnProQuery_Click(object sender, EventArgs e)
        {
            //DirectoryInfo di=new DirectoryInfo("E:\\img");
            //FileInfo[] files = di.GetFiles();
            //foreach (FileInfo fi in files)
            //{
            //    DateTime creattime = fi.CreationTime;
            //    DateTime deletetime = DateTime.Now.AddDays(-5);
            //    if (creattime<deletetime)
            //    {
            //        fi.Delete();
            //    }
            //}

            ZXJK frmmonitor;
            frmmonitor = (ZXJK)this.Owner;
            DateTime intime = dtpInTime.Value;
            DateTime outtime = dtpOutTime.Value;
            if (outtime < intime)
            {
                MessageBox.Show("出场时间必须大于入场时间！");
                return;
            }
            string cartype = cbCarType.Text;
            decimal summonye = frmmonitor.CalulateFee(intime, outtime, cbCarType.Text);
            txtSumMoney.Text = summonye.ToString("f2");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ZXJK zsjktext = new ZXJK();
            zsjktext.InInputPalte("","","");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ZXJK zsjktext = new ZXJK();
            zsjktext.InputPalteCharge("", "");
        }
    }

}
