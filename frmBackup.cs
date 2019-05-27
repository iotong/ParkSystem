using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using www.gzwulian.com.Common;
using www.gzwulian.com.DBUtility;

namespace ChargeWin
{
    public partial class frmBackup : Form
    {
        public frmBackup()
        {
            InitializeComponent();
        }
        //数据库路径
        private string dPath = string.Empty;
        //数据库备份文件路径
        private string dBackPath = string.Empty;
        private SaveFileDialog sfd = new SaveFileDialog();
        private void btnBrower2_Click(object sender, EventArgs e)
        {
            sfd.Title = "请选择备份位置";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;
            sfd.Filter = "备份文件 (*.bak)|*.bak|所有文件 (*.*)|*.*";
            sfd.FileName ="ParkFeeMag";
            string dir = Application.StartupPath + "\\Data\\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            //sfd.InitialDirectory = Application.StartupPath + "\\Data\\";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                dPath = sfd.FileName;
                txtBackPath.Text = sfd.FileName;
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
 
            if (string.IsNullOrEmpty(txtBackPath.Text))
            {
                MessageHelper.ShowTips("请选择备份位置！");
                txtBackPath.Focus();
                return;
            }
            string dir = Application.StartupPath + "\\Data\\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            dPath = dir + "ParkFeeMag.mdf";
            //待备份的数据库名(带扩展名)
            string temp = dPath.Substring(dPath.LastIndexOf("\\") + 1);
             //待备份的数据库名(不带扩展名)
            string backName= temp.Substring(0, temp.LastIndexOf("."));
            //获取数据库备份文件名（不带路径）
            string backPathName = txtBackPath.Text.ToString().Substring(txtBackPath.Text.ToString().LastIndexOf("\\") + 1);
            //获取数据库备份文件路径（不带文件名）
            string backPath  = txtBackPath.Text.ToString().Substring(0, txtBackPath.Text.ToString().LastIndexOf("\\") + 1);
            string strSql = string.Format("use master;backup database {0} to disk = '{1}'", backName, backPath + backPathName);
            try
            {
                DbHelperSQL.ExecuteSql(strSql.ToString());
                MessageHelper.ShowTips("备份成功！");
            }
            catch (Exception)
            {
                MessageHelper.ShowTips("备份失败！");
            }
        }

      

 
    }
}
