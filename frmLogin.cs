using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using ChargeWin;
using www.gzwulian.com.BLL;
using www.gzwulian.com.Common;
using www.gzwulian.com.Model;
using System.Management;
using System.Security.Cryptography;
using System.IO;
using ChargeWin;

namespace ChargeWin
{
    public partial class frmLogin : Form
    {
        private  string configpath;
        private  string FLOGTime;
        private  string REGCode;
        private int ISDays = 0;
        //    private bool boolReg = false;
      //  frmMain frmmain = null;
        private string moveCar;
        www.gzwulian.com.Model.Operator operatormodel = null;
        private static byte[] Keys = { 0x02, 0x20, 0x25, 0x20, 0x21, 0xAD, 0xBE, 0xCF };
        public frmLogin()
        {
          
            InitializeComponent();
            this.txtusername.Focus();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            configpath = GlobalInfo.Instance.ConfigPath;
            INIFile ini = new INIFile(configpath);
            string getRegCode = string.Empty;
           // int isDays = 0;
            string loginname = ini.IniReadValue("LoginInfo", "LoginName");
            string loginpwd = CEncoder.Decode(ini.IniReadValue("LoginInfo", "LoginPwd"));
            bool isremember = ini.IniReadValue("LoginInfo", "IsRemember") == "True";
            FLOGTime = ini.IniReadValue("SysConfig", "FLTime");//第一次应用时间
            REGCode = ini.IniReadValue("SysConfig", "RegCode");//注册码
            moveCar = ini.IniReadValue("SysConfig", "MoveCar");//一户多车参数
            if (isremember)
             {
               txtusername.Text = loginname;
               txtuserpwd.Text = loginpwd;
               cbSave.Checked = isremember;
              }
 
             this.FormBorderStyle = FormBorderStyle.None;

           // //判断注册码是否正常，不正确看再还有多少天，正确则不作操作。
            getRegCode = GetregCode();
            ISDays = getDay(FLOGTime);
            if (getRegCode != REGCode)
            {
                //如果没有时间，第一次运行，则写入。否则计算。
                if (string.IsNullOrWhiteSpace(FLOGTime) || FLOGTime.Length < 10)
                {
                    ISDays = 0;
                    ini.IniWriteValue("SysConfig", "FLTime", GetCreatetime().ToString());
                    linkLabel1.Visible = true;
                    linkLabel1.Text = "欢迎试用，该试用期为【" + (15 - ISDays).ToString() + "】天，点击立即注册！";


                }
                else //计算天数
                {
                    if (ISDays > 15)
                    {
                        if (MessageHelper.ConfirmYesNo("试用期结束，谢谢使用，如需继续使用请注册或致电：4000851048【贵州物联传感科技】"))
                        {
                            frmRegstr frmregstr = new frmRegstr();
                            frmregstr.ShowDialog();
                            if (frmregstr.DialogResult == DialogResult.No)
                            {
                               Application.Exit();
                            }


                        }
                        else
                        {
                            Application.Exit();
                        }
                      

                      

                    }
                    else
                    {
                        linkLabel1.Visible = true;
                        linkLabel1.Text = "欢迎试用，还有【" + (15 - ISDays).ToString() + "】天可以使用，点击立即注册！";

                    }




                }

            }
            else
            {
                ISDays = 99;

            }

        }

        private int getDay(string fLOGTime)
        {
            long firstTime=0;
            if (!string.IsNullOrWhiteSpace(fLOGTime)){
                firstTime = Convert.ToInt32(fLOGTime);

            }
           // long firstTime = Convert.ToInt32(fLOGTime);
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1,8,0,0,0));
            long lTime = long.Parse(firstTime + "0000000") - 4405;
            TimeSpan toNow = new TimeSpan(lTime);
            DateTime dtFirst = dtStart.Add(toNow);
            return  (DateTime.Now - dtFirst).Days;

   
           
        }


        /// <summary>  
        /// 时间戳Timestamp  
        /// </summary>  
        /// <returns></returns> 
        private int GetCreatetime()
        {
            DateTime DateStart = new DateTime(1970, 1, 1,8, 0, 0,0);
            DateTime firstDate = DateTime.Now;
            return Convert.ToInt32((firstDate - DateStart).TotalSeconds)+4405;
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
        private string GetregCode()
        {
            //获取CPU和主板信息

            string cpuInfo ="gzW" + GetCPUSerialNumber()+"440";
            string boisInfo = "L" + GetIDESerialNumber() + "5";
            //  string boisInfo= "L"+GetBaseBoardSerialNumber()+"5";
            //计算
            return  EncryptDES(cpuInfo,boisInfo);
          

        }

        public static string EncryptDES(string encryptString, string encryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return encryptString;
            }
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

        private void SaveLoginInfo(string loginname,string loginpwd)
        {
            //存在用户配置文件，自动加载登录信息
            INIFile ini = new INIFile(configpath);
            ini.IniWriteValue("LoginInfo", "LoginName", loginname);
            ini.IniWriteValue("LoginInfo", "LoginPwd", loginpwd);
            ini.IniWriteValue("LoginInfo", "IsRemember", cbSave.Checked.ToString());
            ini.IniWriteValue("LoginInfo", "CompanyCode", operatormodel.CompanyCode);
            ini.IniWriteValue("LoginInfo", "ParkId", operatormodel.ParkId);

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string username =txtusername.Text.Trim() ;
            string userpass = CEncoder.Encode(this.txtuserpwd.Text.Trim());
            
            if (this.Check(username, userpass) == true)
            {
                try
                {
                    www.gzwulian.com.BLL.OperatorManager bllOperator = new OperatorManager();
                    if (bllOperator.IsExistLoginName(username) == true)
                    {
                        if (!bllOperator.GetStateByName(username))
                        { MessageHelper.ShowTips("此用户未启用！"); }
                        else
                        {
                            if (bllOperator.ValidateUser(username, userpass, out operatormodel) == true)
                            {

                                //if(frmmain==null)
                                //{ 
                                //   frmMain frmmain = new frmMain();
                                //}
                                frmMain frmmain = new frmMain();
                                frmmain.LoginName = username;
                                LoginInfo.Id = operatormodel.Id;
                                LoginInfo.LoginName = username;
                                LoginInfo.RealName = operatormodel.RealName;
                                LoginInfo.CompanyCode = operatormodel.CompanyCode;
                                LoginInfo.ParkId = operatormodel.ParkId;
                                LoginInfo.flTime = FLOGTime;
                                LoginInfo.regCode = REGCode;
                                LoginInfo.isDays = ISDays;
                                LoginInfo.getMoveCar = moveCar;
                                LoginInfo.GroupId = operatormodel.GroupId ?? 1;
                               // LoginInfo.isoneLogin = true;
                                SaveLoginInfo(username, userpass);


                                frmmain.SetEnable();
                                frmmain.InitBar();


                                if (ISDays!=99)
                                {
                                    frmmain.Text = frmmain.Text + "--试用版";
                                }
                                //  frmmain.Show();
                                if (LoginInfo.isoneLogin)
                                {
                                    frmmain.Show();
                                    LoginInfo.isoneLogin = false;
                                    //Log_BLL.Add(DateTime.Now, "登录系统", username, "登录成功", Dns.GetHostName().ToUpperInvariant(), Systems.GetOSNameByUserAgent(Environment.OSVersion.ToString()), 1);
                                }
                                this.Hide();
                                this.DialogResult= DialogResult.OK;
                               

                            }
                            else
                            {
                                MessageHelper.ShowTips("用户名或密码错误!");
                                this.txtuserpwd.Focus();
                            }
                        }
                    }
                    else
                    {
                        MessageHelper.ShowTips("用户名或密码错误");
                        this.txtusername.Clear();
                        this.txtusername.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageHelper.ShowTips("登陆失败,请重新配置数据库信息！" + ex.Message);
                    this.Hide();
                    frmDbSet frmdbset = new frmDbSet();
                    frmdbset.ShowDialog();
                  
                }
                
        
            }
        }

        private bool Check(string username, string userpass)
        {
            bool result = false;
            if (string.IsNullOrEmpty(username))
            {
                MessageHelper.ShowTips("输入账号!");
                this.txtusername.Focus();
                
                return result;
            }
            else if (string.IsNullOrEmpty(userpass))
            {
                MessageHelper.ShowTips("输入密码!");
                this.txtuserpwd.Focus();
                return result;
            }
            else
            {
                return result = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
          
            Application.Exit();

        }



        private void linkLabel1_Click(object sender, EventArgs e)
        {
            frmRegstr frmregstr = new frmRegstr();
            frmregstr.ShowDialog();
        }

      
    }
}
