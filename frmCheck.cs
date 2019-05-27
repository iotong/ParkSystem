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


namespace ChargeWin
{
    public partial class frmCheck : Form
    {
        public string PlateId
        {
            get; set;
        }
        //2017年9月8日加
        private int countTime = ZXJK.i_winstoptime*10; //自动关闭窗口时间，无操作默认30秒
        private int tempTime=0;


        public string CarType
        {
            get; set;
        }
        private CarTypeManager carBLL = new CarTypeManager();
        public frmCheck(string plateid,string cartype,string inouttype)
        {
            InitializeComponent();
            if (inouttype=="out")
            {
                btnOK.Text = "确定";
            }
            this.PlateId = plateid;
            txtPlateId.Text = plateid;
            DataSet ds = carBLL.GetAllList();
            //BindDic();
            cbCarType.DisplayMember = "CarTypeName";
            cbCarType.DataSource = ds.Tables[0].DefaultView;
            cbCarType.Text = cartype;
            if (countTime > 0)
            {
                winclose.Visible = true;
                timer1.Enabled = true;
                timer1.Start();
            }
            else
            {
                winclose.Visible = false; ;
                timer1.Enabled = false;
                timer1.Stop();

            }


        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPlateId.Text))
            {
                MessageHelper.ShowTips("车牌号码不能为空！");
                return;
            }
            this.PlateId = txtPlateId.Text;
            this.CarType = cbCarType.Text;
            this.DialogResult=DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult=DialogResult.None;
            this.Close();
        }

        private void frmCheck_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13||e.KeyValue==96)
            {
                this.btnOK.Focus();
                btnOK_Click(sender, e);

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tempTime++;
            winclose.Text = "本窗口将在【" + ((countTime - tempTime) / 10).ToString() + "秒后自动关闭。";
            if (tempTime == countTime)
            {
                timer1.Enabled = false;
                timer1.Stop();
                this.DialogResult = DialogResult.None;
                this.Close();

            }
        }
    }
}
