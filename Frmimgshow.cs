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
    public partial class Frmimgshow : Form
    {
        public Frmimgshow()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frmimgshow_Load(object sender, EventArgs e)
        {
            ZXJK sfgl = new ZXJK();
            pbox.Image = Image.FromFile(Tag.ToString());
        }


    }
}
