using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using www.gzwulian.com.Common;

namespace ChargeWin
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {

            LoadCurrentConfiguration();
            ReadFree();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            INIMag _writer = new INIMag(Application.StartupPath + "\\Config\\SysCon.ini");
            _writer.IsFCustomerFee = cbIsFCustomerFee.Checked.ToString();
            _writer.IsExistByPwd = cbIsExistByPwd.Checked.ToString();
            _writer.IsOpenNotConfirm = cbIsOpenNotConfirm.Checked.ToString();
            _writer.IsOutSelectFreeFee = cbIsOutSelectFreeFee.Checked.ToString();
            _writer.AutoOpen = cbAutoOpen.Checked.ToString();
            _writer.FcarplayNo = cbFplay.Checked.ToString();
            _writer.LcarplayNo = cbLplay.Checked.ToString();
            _writer.CarinfoUpload = cbcarUpload.Checked.ToString();
            _writer.HandOff = cbHandOff.Checked.ToString();
            

            if (!IsIntNum(tbox_winstoptime.Text))
            {
                tbox_winstoptime.Focus();
            }
            else
            {
                _writer.WinStopTime = Convert.ToInt16(tbox_winstoptime.Text);

            }



            if (!IsIntNum(txtDeleteDay.Text))
            {
                txtDeleteDay.Focus();
            }
            else {
                _writer.DeleteDay = Convert.ToInt16(txtDeleteDay.Text);

            }

            if (chbox_movecar.Checked)
            {
                if (rb1.Checked)
                {
                    _writer.MoveCar = "0";//先进场为固定车，后进场为临时车
                }
                else
                {

                    _writer.MoveCar = "1";//自动转化，固定车驶后，第二辆自动转为固定车

                }
            }
            else
            {
                _writer.MoveCar = "-1";

            }
            if (!string.IsNullOrWhiteSpace(txtOverDay.Text))
            {
                _writer.OverDay = Convert.ToInt32(txtOverDay.Text);
            }
            if (!string.IsNullOrWhiteSpace(txtOverTime.Text))
            {
                _writer.OverTime = int.Parse(txtOverTime.Text);
            }
            if (!string.IsNullOrWhiteSpace(txtDeleteDay.Text))
            {
                _writer.DeleteDay = int.Parse(txtDeleteDay.Text);
            }
            try
            {
                _writer.Write();
                MessageHelper.ShowTips("保存成功！");

            }
            catch (Exception)
            {

                MessageHelper.ShowWarning("数据写入失败！");
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 显示上次配置的数据
        /// </summary>
        private void LoadCurrentConfiguration()
        {
            INIMag writer = new INIMag(Application.StartupPath + "\\Config\\SysCon.ini");

            if (writer.FcarplayNo == "True")
            {
                cbFplay.Checked = true;
            }
            else
            {
                cbFplay.Checked = false;
            }

            if (writer.LcarplayNo == "True")
            {
                cbLplay.Checked = true;
            }
            else
            {
                cbLplay.Checked = false;
            }

            if (writer.CarinfoUpload == "True")
            {
                cbcarUpload .Checked = true;
            }
            else
            {
                cbcarUpload.Checked = false;
            }

            if (writer.HandOff == "True")
            {
                cbHandOff.Checked = true;
            }
            else
            {
                cbHandOff.Checked = false;
            }

            if (writer.IsFCustomerFee == "True")
            {
                cbIsFCustomerFee.Checked = true;
            }
            else
            {
                cbIsFCustomerFee.Checked = false;
            }
            if (writer.IsOpenNotConfirm == "True")
            {
                cbIsOpenNotConfirm.Checked = true;
            }
            else
            {
                cbIsOpenNotConfirm.Checked = false;
            }
            if (writer.IsExistByPwd == "True")
            {
                cbIsExistByPwd.Checked = true;
            }
            else
            {
                cbIsExistByPwd.Checked = false;
            }
            if (writer.IsOutSelectFreeFee == "True")
            {
                cbIsOutSelectFreeFee.Checked = true;
            }
            else
            {
                cbIsOutSelectFreeFee.Checked = false;
            }
            txtOverTime.Text = writer.OverTime.ToString();
            txtOverDay.Text = writer.OverDay.ToString();
            txtDeleteDay.Text = writer.DeleteDay.ToString();
            if (writer.AutoOpen == "True")
            {
                cbAutoOpen.Checked = true;
            }
            else
            {
                cbAutoOpen.Checked = false;
            }


            if (writer.MoveCar == "-1")
            {
                chbox_movecar.Checked = false;
                rb1.Checked = false;
                rb2.Checked = false;
                rb1.Enabled = true;
                rb2.Enabled = true;

            }
            else
            {
                chbox_movecar.Checked = true;
                if (writer.MoveCar == "0")
                {
                    rb1.Checked = true;
                    rb2.Checked = false;
                }
                else
                {

                    rb2.Checked = true;
                    rb1.Checked = false;

                }
            }
        }

        public static bool IsIntNum(string str)
        {
            System.Text.RegularExpressions.Regex reg1
            = new System.Text.RegularExpressions.
                Regex(@"^[-]?[1-9]{1}\d*$|^[0]{1}$");
            bool ismatch = reg1.IsMatch(str);
            if (!ismatch)
                MessageBox.Show("您输入的天数不是整数,请重新输入！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return ismatch;

        }

        private void delData_Click(object sender, EventArgs e)
        {
            if (!IsIntNum(txtDeleteDay.Text))
            {
                txtDeleteDay.Focus();

            }
            else
            {
                frmMain frm = new frmMain();
              
                if (frm.ClearSqlData(txtDeleteDay.Text))
                {
                    frm.DeleteImg(Convert.ToInt16(txtDeleteDay.Text));
                    MessageBox.Show("清除成功！","提示！");
                    return;
                }
                else
                {
                    MessageBox.Show("清除失败！", "提示！");
                    return; 

                }
             }
        }

        private void chbox_movecar_CheckedChanged(object sender, EventArgs e)
        {
            if (chbox_movecar.Checked)
            {
                rb1.Enabled = true;
                rb2.Enabled = true;
                rb1.Checked = true;
            }
            else
            {
                rb1.Enabled = false;
                rb2.Enabled = false;
                rb1.Checked = false;
                rb2.Checked = false;
            }
        }

        private void buttools_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath+"\\tools\\LPRConfigTool.exe");
        }

        private void butInit_Click(object sender, EventArgs e)
        {
            string sourceFile= Application.StartupPath + "\\Config\\init.ini";
            string targetFile= Application.StartupPath + "\\Config\\SysCon.ini";
            System.IO.File.Copy(sourceFile, targetFile, true);
            LoadCurrentConfiguration();
            MessageHelper.ShowTips("初始化配置文件成功！");
        }

        private void butSaveFree_Click(object sender, EventArgs e)
        {
            string sourceFile = Application.StartupPath + "\\Config\\initFree.ini";
            string targetFile = Application.StartupPath + "\\Config\\SysFree.ini";
            System.IO.File.Copy(sourceFile, targetFile, true);

            if(WriteFree())
            {
                  MessageHelper.ShowTips("免费原因保存成功！");
            }
        }



        public bool WriteFree()
        {
            try
            {
                INIFile ini = new INIFile(Application.StartupPath + "\\Config\\SysFree.ini");
                int rows = lboxfree.Items.Count;
                if (ini != null && rows > 0)
                {
                    for (int i = 0; i < rows; i++)
                        ini.IniWriteValue("SysFree", "Text" + i.ToString(), lboxfree.Items[i].ToString());

                }
                return true;
            }
            catch
            {
                return false;

            }
            
        }

        public bool ReadFree()
        {
            try
            {
                INIFile ini = new INIFile(Application.StartupPath + "\\Config\\SysFree.ini");
               if (ini != null)
                {
                    for (int i = 0; i < 20; i++)
                        if (ini.IniReadValue("SysFree", "Text" + i.ToString())!="")
                        { 
                           lboxfree.Items.Add(ini.IniReadValue("SysFree", "Text" + i.ToString()));
                        }

                }
                return true;
            }
            catch
            {
                return false;

            }

        }

        private void lboxfree_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int i = lboxfree.SelectedIndex;
            if (i >= 0)
            { 
                lboxfree.Items.RemoveAt(i);
            }
        }

        private void butAddFree_Click(object sender, EventArgs e)
        {
            lboxfree.Items.Add(txtFree.Text);
        }

        private void txtFree_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                lboxfree.Items.Add(txtFree.Text);

            }
           
        }

       
    }
}
