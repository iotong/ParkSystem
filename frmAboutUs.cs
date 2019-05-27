using ChargeWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ChargeWin
{
    partial class frmAboutUs : Form
    {
        public frmAboutUs()
        {
            InitializeComponent();
            this.Text = String.Format("关于 {0}", "智能停车场管理系统");
            this.labelProductName.Text = "智能停车场管理系统";
            this.labelVersion.Text = String.Format("版本 {0}", "3.1.0");
            this.labelCopyright.Text = " © 2015 www.gzwulian.com";
            this.labelCompanyName.Text = "www.gzwulian.com";
            this.textBoxDescription.Text = "欢迎使用智能停车场管理系统！";
            //this.Text = String.Format("关于 {0}", AssemblyTitle);
            //this.labelProductName.Text = AssemblyProduct;
            //this.labelVersion.Text = String.Format("版本 {0}", AssemblyVersion);
            //this.labelCopyright.Text = AssemblyCopyright;
            //this.labelCompanyName.Text = AssemblyCompany;
            //this.textBoxDescription.Text = AssemblyDescription;
        }

        #region 程序集特性访问器

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion





        private void linkLabel1_Click(object sender, EventArgs e)
        {
            frmRegstr frmregstr = new frmRegstr();
            frmregstr.ShowDialog();
        }

        private void frmAboutUs_Load(object sender, EventArgs e)
        {
            if (LoginInfo.isDays == 99)
            {

                linkLabel1.Visible = false;


            }
            else
            {
                linkLabel1.Visible = true;
                linkLabel1.Text = "欢迎试用，还有【" + (15 - LoginInfo.isDays).ToString() + "】天可以使用，点击立即注册！";




            }

        }
    }
}
