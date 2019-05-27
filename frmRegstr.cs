using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Management;
using System.Security.Cryptography;
using www.gzwulian.com.Common;
using ChargeWin;

namespace ChargeWin
{
    public partial class frmRegstr : Form
    {
        private string configpath;
        public frmRegstr()
        {
            InitializeComponent();
        }




        /// <summary>
        /// 过去CPU序列号
        /// </summary>
        /// <returns>反回序列号字符串</returns>

        public static string GetCPUSerialNumber()
        {
            string cpuSerialNumber = string.Empty;
            ManagementClass mc = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                cpuSerialNumber = mo["ProcessorId"].ToString();
                break;
            }
            mc.Dispose();
            moc.Dispose();
            return cpuSerialNumber;
        }

        /// <summary>
        /// 获取硬盘ID
        /// </summary>
        /// <returns>反回ID号字符串</returns>
        public static string GetIDESerialNumber()
        {
            string ideSerialNumber = string.Empty;
            ManagementClass mc = new ManagementClass("Win32_DiskDrive");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                ideSerialNumber = (string)mo.Properties["Model"].Value;
                break;
            }
            mc.Dispose();
            moc.Dispose();
            return ideSerialNumber;
        }

        /// <summary>
        /// 获取主板编号
        /// </summary>
        /// <returns>反回主板编号字符串</returns>
        public static string GetBaseBoardSerialNumber()
        {
            string basebrardSerialNumber = string.Empty;
            ManagementClass mc = new ManagementClass("WIN32_BaseBoard");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                basebrardSerialNumber = mo["SerialNumber"].ToString();
                break;
            }
            mc.Dispose();
            moc.Dispose();
            return basebrardSerialNumber;
        }



      
        private void but_close_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            tbox_key2.Text = GetIDESerialNumber();
          //  tbox_key2.Text = GetBaseBoardSerialNumber();
            tbox_key1.Text = GetCPUSerialNumber();
           if (LoginInfo.isDays == 99)
            {
                tbox_res.Enabled = false;
                but_ok.Enabled = false;


            }
            else
            {
                tbox_res.Enabled = true;
                tbox_res.Focus();
                but_ok.Enabled = true;

            }
        }

        private void but_ok_Click(object sender, EventArgs e)
        {
            configpath = GlobalInfo.Instance.ConfigPath;
            INIFile ini = new INIFile(configpath);
            string key1 = "gzW"+tbox_key1.Text.Trim()+"440";
            string key2 = "L"+ tbox_key2.Text.Trim()+"5";
            string regcode = tbox_res.Text.Trim();

            if (CEncoder.EncryptDES(key1, key2) != regcode)
            {
                if (MessageHelper.ConfirmYesNo("你输入的注册码不对,要重新输入吗？"))
                {
                    tbox_res.Text = "";
                    tbox_res.Focus();

                }
            }
            else
            {
                //保存注册码到config.ini中
                ini.IniWriteValue("SysConfig", "RegCode",regcode);
                MessageHelper.ShowTips("注册成功，谢谢使用！");
                Application.Exit();
                Application.Restart();


            }
        }
    }
}
