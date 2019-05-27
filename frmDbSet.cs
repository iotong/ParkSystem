using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using www.gzwulian.com.Common;
using Microsoft.SqlServer;

namespace ChargeWin
{
    public partial class frmDbSet : Form
    {
        private int ok;
        public frmDbSet()
        {
            InitializeComponent();
        }
       
        private void buttonX1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBoxX4.Text))
            {
                MessageHelper.ShowTips("请输入密码！");
            }
            else
            {
                string connStr = " Data Source=" + cboserver.Text + ";User ID=" + textBoxX3.Text + ";Password=" + textBoxX4.Text + ";persist security info=false;packet size=4096";
                SqlConnection cnn = new SqlConnection(connStr);
                try
                {
                    cnn.Open();
                    if (cnn.State == ConnectionState.Open)
                    {

                        ok = 1;
                        MessageHelper.ShowTips("连接成功！");

                    }
                    else
                    {
                        ok = 0;
                        MessageHelper.ShowTips("连接失败！");
                    }
                }
                catch(Exception ex)
                {
                   MessageHelper.ShowTips("登录失败！");
                }
               
            }
        }

      
        private bool Execfile()
        {
            try
            {
                
                string path = txtSql.Text.Trim();
                string connStr = " Data Source=" + cboserver.Text + ";User ID=" + textBoxX3.Text + ";Password=" + textBoxX4.Text + ";persist security info=false;packet size=4096";
                ExecuteSql(connStr, "master", "CREATE DATABASE " + "ParkFeeMag"); //这个数据库名是指你要新建的数据库名称
                System.Diagnostics.Process sqlProcess = new System.Diagnostics.Process();
                sqlProcess.StartInfo.FileName = "osql.exe ";
                sqlProcess.StartInfo.Arguments = " -U sa -P zj -d ParkFeeMag -i " + path;
                sqlProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                sqlProcess.Start();
                sqlProcess.WaitForExit();
                sqlProcess.Close();
                return true;
            }
            catch (Exception ex)
            {
                string result = "数据库 'ParkFeeMag' 已存在。请选择其他数据库名称。";
                if (ex.ToString().Contains(result))
                {
                    MessageHelper.ShowTips("数据库 'ParkFeeMag' 已存在。");
                    return false;
                }
                else
                {
                    MessageHelper.ShowTips("连接失败");
                    return false;
                }
            }
        }

        private void ExecuteSql(string conn, string DatabaseName, string Sql)
        {
            System.Data.SqlClient.SqlConnection mySqlConnection = new System.Data.SqlClient.SqlConnection(conn);
            System.Data.SqlClient.SqlCommand Command = new System.Data.SqlClient.SqlCommand(Sql, mySqlConnection);
            Command.Connection.Open();
            Command.Connection.ChangeDatabase(DatabaseName);
            try
            {
                Command.ExecuteNonQuery();
            }
            finally
            {
                Command.Connection.Close();
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (ok == 1 && txtDbName.Text == "ParkFeeMag")
            {
                try
                {
                    string connstr = " Data Source=" + cboserver.Text.Trim() + ";Initial Catalog=" +
                                               txtDbName.Text.Trim() + ";User ID=" + textBoxX3.Text.Trim() + ";Password=" +
                                               textBoxX4.Text.Trim() + ";persist security info=false;packet size=4096";
                    System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();
                    xDoc.Load(System.Windows.Forms.Application.ExecutablePath + ".config");
                    string key = "ConnectionString";
                    System.Xml.XmlNode xNode;
                    System.Xml.XmlElement xElem1;
                    System.Xml.XmlElement xElem2;
                    xNode = xDoc.SelectSingleNode("//appSettings");

                    xElem1 = (System.Xml.XmlElement)xNode.SelectSingleNode("//add[@key='" + key + "']");
                    if (xElem1 != null) xElem1.SetAttribute("value", connstr);
                    else
                    {
                        xElem2 = xDoc.CreateElement("add");
                        xElem2.SetAttribute("key", key);
                        xElem2.SetAttribute("value", connstr);
                        xNode.AppendChild(xElem2);
                    }

                    xDoc.Save(System.Windows.Forms.Application.ExecutablePath + ".config");
                    string configpath = GlobalInfo.Instance.ConfigPath;
                    INIFile ini = new INIFile(configpath);
                    ini.IniWriteValue("Check", "IsFirst", "1");
                    MessageHelper.ShowTips("保存成功，请重新打开软件！");
                    Application.Exit();
                    //frmLogin fdb = new frmLogin();
                    //fdb.Show();
                    //this.Hide();
                }
                catch (Exception ex)
                {
                    MessageHelper.ShowTips("保存失败！");
                }

            }
            else
            {

                MessageHelper.ShowTips("请先测试并输入正确的数据库名称！");
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Files|*.sql";
            if (of.ShowDialog() == DialogResult.OK)
            {
                string path = of.FileName;
                txtSql.Text = path;
            }
        }

        private void frmDbSet_Load(object sender, EventArgs e)
        {
                cboserver.Items.Clear();
                cboserver.Items.Add(".\\SQLEXPRESS");
                cboserver.Items.Add(".");
                cboserver.Items.Add("localhost");
                cboserver.Items.Add("(local)");
                txtSql.Text = Application.StartupPath+"\\Data\\createDb.sql";
                txtSql.ReadOnly = true;
                cboserver.SelectedIndex = 0;
            
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists("D:\\DATA"))
            {
                Directory.CreateDirectory("D:\\DATA");
            }
            if (string.IsNullOrWhiteSpace(textBoxX4.Text))
            {
                MessageHelper.ShowTips("请填写密码！");

            }
            else if (string.IsNullOrWhiteSpace(txtSql.Text))
            {
                MessageHelper.ShowTips("请选择SQL脚本文件！");
            }
            else { 
              try { 
                string constr = "data source="+cboserver.Text.Trim()+";uid="+textBoxX3.Text.Trim()+";pwd="+textBoxX4.Text.Trim()+";"; // 定义链接字符窜
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                ArrayList Lists = ExecSqlFile(); //调用ExecuteSqlFile()方法，反回 ArrayList对象;
                string teststr; //定义遍历ArrayList 的变量;
                foreach (string varcommandText in Lists)
                {
                    teststr = varcommandText; //遍历并符值;
                    cmd.CommandText = teststr; //为SqlCommand赋Sql语句;
                    cmd.ExecuteNonQuery(); //执行
                }
                conn.Close();
                //以下修改配置文件
                string connstr = " Data Source=" + cboserver.Text.Trim() + ";Initial Catalog=" +
                                                txtDbName.Text.Trim() + ";User ID=" + textBoxX3.Text.Trim() + ";Password=" +
                                                textBoxX4.Text.Trim() + ";persist security info=false;packet size=4096";
                System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();
                xDoc.Load(System.Windows.Forms.Application.ExecutablePath + ".config");
                string key = "ConnectionString";
                System.Xml.XmlNode xNode;
                System.Xml.XmlElement xElem1;
                System.Xml.XmlElement xElem2;
                xNode = xDoc.SelectSingleNode("//appSettings");     
                xElem1 = (System.Xml.XmlElement)xNode.SelectSingleNode("//add[@key='" + key + "']");
                if (xElem1 != null) xElem1.SetAttribute("value", connstr);
                else
                {
                    xElem2 = xDoc.CreateElement("add");
                    xElem2.SetAttribute("key", key);
                    xElem2.SetAttribute("value", connstr);
                    xNode.AppendChild(xElem2);
                }

                xDoc.Save(System.Windows.Forms.Application.ExecutablePath + ".config");
                string configpath = GlobalInfo.Instance.ConfigPath;
                INIFile ini = new INIFile(configpath);
                ini.IniWriteValue("Check", "IsFirst", "1");
                MessageHelper.ShowTips("保存成功！");
                frmLogin fdb = new frmLogin();
                fdb.Show();
                this.Hide();
                    }
                catch(Exception ex)
                {
                    MessageHelper.ShowTips("保存失败！"+ex.Message);
                }
            }
        }

        public ArrayList ExecSqlFile()
        {
            //StreamReader sr = File.OpenText(txtSql.Text);//传入的是文件路径及完整的文件名
            StreamReader sr = new StreamReader(txtSql.Text, System.Text.Encoding.Default);
            ArrayList alSql = new ArrayList(); //每读取一条语名存入ArrayList
            string commandText = "";
            string varLine = "";
            while (sr.Peek() > -1)
            {
                varLine = sr.ReadLine();
                if (varLine == "")
                {
                    continue;
                }
                if (varLine != "GO")
                {
                    commandText += varLine;
                    commandText += " ";
                }
                else
                {
                    alSql.Add(commandText);
                    commandText = "";
                }
            }

            sr.Close();
            return alSql;

        }
    }
}
