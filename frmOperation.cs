using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChargeWin
{
    public partial class frmOperation : Form
    {
        public frmOperation()
        {
            InitializeComponent();
        }

        private void frmOperation_Load(object sender, EventArgs e)
        {
            //string path = Application.StartupPath + "\\使用手册.pdf";
            //AxAcroPDFLib.AxAcroPDF acroPDF = new AxAcroPDFLib.AxAcroPDF();
            //((System.ComponentModel.ISupportInitialize)(acroPDF)).BeginInit();
            //acroPDF.Location = new Point(0, 10);
            //acroPDF.Size = new Size(100, 100);
            //acroPDF.Dock = DockStyle.Fill;
            //panel1.Controls.Clear();
            //panel1.Controls.Add(acroPDF);
            //((System.ComponentModel.ISupportInitialize)(acroPDF)).EndInit();
            //acroPDF.LoadFile(path);
        }
    }
}
