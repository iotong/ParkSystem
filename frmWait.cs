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
    public partial class frmWait : Form
    {
        public frmWait()
        {
            InitializeComponent();
        }
        public string showtip;
        private void MessageForm_Load(object sender, EventArgs e)
        {
            label1.Text = showtip;
            
        }
    }
}
