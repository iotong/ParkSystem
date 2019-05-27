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
using www.gzwulian.com.Common;
using www.gzwulian.com.Model;

namespace ChargeWin
{
    public partial class frmShowInfo : Form
    {
        private FInOutInfo inoutModel;
        private FInOutInfoManager inoutBLL = new FInOutInfoManager();
        private string rkImage = string.Empty;
        private string ckImage = string.Empty;
        private string configpath = Application.StartupPath + "\\Config\\SysCon.ini";
       
        
        public frmShowInfo(int id)
        {
            INIFile ini = new INIFile(configpath);
            string inIp = ini.IniReadValue("EquipInSet", "EquipIp");
            rkImage = ini.IniReadValue("EquipInSet", "ImagePath"); //出口图片路径
            ckImage = ini.IniReadValue("EquipOutSet", "ImagePath"); //出口图片路径
            InitializeComponent();
            inoutModel = new FInOutInfo();
            inoutModel = inoutBLL.GetModel(id);
            if (inoutModel != null)
            {
                txtPlateId.Text = inoutModel.PlateId;
                txtColor.Text = inoutModel.PlateColor;
                txtType.Text = inoutModel.VehicType;
                txtInTime.Text = inoutModel.InTime.ToString();
                txtOutTime.Text = inoutModel.OutTime.ToString();
                if (!string.IsNullOrWhiteSpace(inoutModel.InImgPath))
                {
                    if (inoutModel.InImgPath.Substring(0, 1).ToLower() == "e" || inoutModel.InImgPath.Substring(0, 1).ToLower() == "d" || inoutModel.InImgPath.Substring(0, 1).ToLower() == "c")
                    {
                        if (File.Exists(inoutModel.InImgPath))
                        {
                            picPlate.Image = Image.FromFile(inoutModel.InImgPath);
                        }
                        else
                        {
                            picPlate.Image = Image.FromFile(Application.StartupPath + "//wu.png");
                        }

                    }
                    else
                    {
                        string inimg = rkImage + "\\" + inoutModel.InImgPath.Substring(inoutModel.InImgPath.LastIndexOf('\\') + 1);
                        if (File.Exists(inimg))
                        {
                            picPlate.Image = Image.FromFile(inimg);
                        }
                        else
                        {
                            picPlate.Image = Image.FromFile(Application.StartupPath + "//wu.png");

                        }
                        
                    }
     
                    
                }
                else if (!string.IsNullOrWhiteSpace(inoutModel.OutImgPath))
                {
                    if (inoutModel.OutImgPath.Substring(0, 1).ToLower() == "e" || inoutModel.OutImgPath.Substring(0, 1).ToLower() == "d" || inoutModel.OutImgPath.Substring(0, 1).ToLower() == "c")
                    {
                        if (File.Exists(inoutModel.OutImgPath))
                        {
                            picPlate.Image = Image.FromFile(inoutModel.OutImgPath);
                        }
                        else
                        {
                            picPlate.Image = Image.FromFile(Application.StartupPath + "//wu.png");
                        }
                    }
                    else
                    {
                        string outimg = rkImage + "\\" +
                                        inoutModel.OutImgPath.Substring(inoutModel.OutImgPath.LastIndexOf('\\') + 1);
                        if (File.Exists(outimg))
                        {
                            picPlate.Image = Image.FromFile(outimg);
                        }
                        else
                        {
                            picPlate.Image = Image.FromFile(Application.StartupPath + "//wu.png");

                        }
                    }

                }
                else
                {
                    picPlate.Image = Image.FromFile(Application.StartupPath + "//wu.png");
                }
              
               
            }
        }
    }
}
