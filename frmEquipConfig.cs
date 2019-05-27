using System;
using System.Data;
using System.Windows.Forms;
using www.gzwulian.com.BLL;
using www.gzwulian.com.Common;
using www.gzwulian.com.Model;
using System.Net;
using System.Threading;
using AxVZLPRClientCtrlLib;

namespace ChargeWin
{
    public partial class frmEquipConfig : Form
    {
        public frmEquipConfig()
        {
            InitializeComponent();
        }
        www.gzwulian.com.Model.BaseSet model = new BaseSet();
        //  www.gzwulian.com.Common.LedFunc;
        private www.gzwulian.com.BLL.BaseSetManager bll = new BaseSetManager();
        private AxVZLPRClientCtrlLib.AxVZLPRClientCtrl axCtrl;



        string LedAdrr;
        string LedShowType;
        string LedControl;
        string incode;
        string stoptime;
        string outcode;
        string auto_sy = "00", auto_ey = "00";// 音量，第一音量，第二音量
        short Serial;
        string strvol; //回定音量
        string strbri;//回定亮度
        string configpath = GlobalInfo.Instance.ConfigPath;
        string WinAdrr = "-1";//窗口地扯
        string ShowLedico = "-1";//屏上是否显上位图
        System.Net.IPAddress myip = null;
        private void frmConfig_Load(object sender, EventArgs e)
        {
            Init();
            axCtrl = new AxVZLPRClientCtrl();
            axCtrl.Dock = DockStyle.Fill;
            ctrlpanel.Controls.Add(axCtrl);
            axCtrl.SetWindowStyle(1);
            ctrlpanel.Visible = false;
            showLedInfo();
        }
        //初始化默认参数
        private void Init()
        {
            txtEquipIp.Text = "192.168.1.100";
            //txtViewIP.Text = "192.168.1.108";
            txtPort.Text = "80";
            txtLoginName.Text = "admin";
            txtLoginPwd.Text = "admin";
            cbEquipType.SelectedIndex = 0;
            BindData();
        }
        /// <summary>
        /// 检测Ip是否存在
        /// </summary>
        /// <returns></returns>
        private bool IsIpExist()
        {
            string Ip = txtEquipIp.Text.Trim();
            string strWhere = "EquipIp=" + "'" + Ip + "'";
            DataSet ds = bll.GetList(strWhere);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool testResult = false;
        private int lprHandle = 0;
        private int lpropen = 0;
        //private bool dbConnectState = false;
        private void btnTestConnect_Click(object sender, EventArgs e)
        {
            string ipAdd = txtEquipIp.Text;
            short port = short.Parse(txtPort.Text);
            string uName = txtLoginName.Text;
            string uPwd = txtLoginPwd.Text;
            lprHandle = axCtrl.VzLPRClientOpen(ipAdd, port, uName, uPwd);
            if (lprHandle > 0)
            {

                string SerialNumber = axCtrl.VzLPRGetSerialNumber(lprHandle);
                txtSn.Text = SerialNumber;
                string strNumber = txtNumber.Text.Trim();
                string strSn = txtSn.Text.Trim();
                string key1 = "gzW" + strSn + "440";
                string key2 = "LIOTong5";

                if (strNumber == CEncoder.EncryptDES(key1, key2))
                {
                    lpropen = axCtrl.VzLPRClientStartPlay(lprHandle, 0);
                    testResult = true;
                    MessageHelper.ShowTips("测试成功！");

                }
                else
                {
                    lprHandle = 0;
                    testResult = false;
                    MessageHelper.ShowTips("注册码验证不正确，请咨询供应商。");


                }



            }
            else
            {
                lprHandle = 0;
                testResult = false;
                MessageHelper.ShowTips("设备不在线,请检查输入数据！");

            }
        }




        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!IsIpExist() && testResult)
            {
                if (string.IsNullOrWhiteSpace(cbEquipType.Text))
                {
                    MessageHelper.ShowTips("设备类型不能为空！");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtImagePath.Text))
                {
                    MessageHelper.ShowTips("图片存放路径不能为空！");
                    return;
                }
                model.EquipIp = txtEquipIp.Text;
                model.Port = txtPort.Text;
                model.LoginrName = txtLoginName.Text;
                model.LoginPwd = txtLoginPwd.Text;
                model.Position = txtPosition.Text;
                model.ImagePath = txtImagePath.Text;
                model.AddTime = DateTime.Now;
                model.ParkId = LoginInfo.ParkId;
                model.CompanyCode = LoginInfo.CompanyCode;
                model.EquipType = cbEquipType.Text;

                model.EquipSn = txtSn.Text;
                model.EquipCode = txtNumber.Text;
                if (bll.Add(model) > 0)
                {

                    www.gzwulian.com.Common.MessageHelper.ShowTips("添加成功！");
                    BindData();
                }


            }
            else
            {
                www.gzwulian.com.Common.MessageHelper.ShowTips("一体机配置未成功，请配置成功再添加！");
            }

        }


        /// <summary>
        /// 将配置成功的一体机设备绑定到DGV控件
        /// </summary>
        private void BindData()
        {
            DataSet ds = bll.GetAllList();
            dgvList.DataSource = ds.Tables[0];

            this.dgvList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.Columns["Id"].HeaderText = "Id号";

            this.dgvList.Columns["Id"].Width = 40;
            this.dgvList.Columns["Id"].DisplayIndex = 0;
            this.dgvList.Columns["Id"].HeaderText = "Id号";
            this.dgvList.Columns["Id"].Width = 40;
            this.dgvList.Columns["Id"].DisplayIndex = 0;
            this.dgvList.Columns["EquipIp"].HeaderText = "设备Ip";
            this.dgvList.Columns["EquipIp"].Width = 100;
            this.dgvList.Columns["EquipIp"].DisplayIndex = 1;
            this.dgvList.Columns["Port"].HeaderText = "端口";
            this.dgvList.Columns["Port"].Width = 40;
            this.dgvList.Columns["Port"].DisplayIndex = 2;
            this.dgvList.Columns["LoginrName"].HeaderText = "登陆名";
            this.dgvList.Columns["LoginrName"].DisplayIndex = 3;
            this.dgvList.Columns["Position"].HeaderText = "所在位置";
            this.dgvList.Columns["Position"].DisplayIndex = 4;
            this.dgvList.Columns["EquipType"].HeaderText = "设备类型";
            this.dgvList.Columns["EquipType"].DisplayIndex = 5;
            this.dgvList.Columns["ImagePath"].HeaderText = "图片路径";
            this.dgvList.Columns["ImagePath"].Width = 110;
            this.dgvList.Columns["ImagePath"].DisplayIndex = 6;
            this.dgvList.Columns["CompanyCode"].HeaderText = "单位编号";
            this.dgvList.Columns["CompanyCode"].Width = 80;
            this.dgvList.Columns["CompanyCode"].DisplayIndex = 7;

            this.dgvList.Columns["EquipSn"].HeaderText = "设备号";
            this.dgvList.Columns["EquipSn"].Width = 80;
            this.dgvList.Columns["EquipSn"].DisplayIndex = 8;
            this.dgvList.Columns["EquipCode"].HeaderText = "EquipCode";
            this.dgvList.Columns["EquipCode"].Width = 80;
            this.dgvList.Columns["EquipCode"].DisplayIndex = 9;

            this.dgvList.Columns["IsUpload"].HeaderText = "是否上传";
            this.dgvList.Columns["IsUpload"].DisplayIndex = 10;



            // this.dgvList.Columns["AddTime"].HeaderText = "添加日期";
            //this.dgvList.Columns["AddTime"].DisplayIndex = 8;
            this.dgvList.Columns["AddTime"].Visible = false; ;
            this.dgvList.Columns["ParkId"].Visible = false;
            this.dgvList.Columns["OperatorName"].Visible = false;
            this.dgvList.Columns["LoginPwd"].Visible = false;

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                txtImagePath.Text = folderBrowser.SelectedPath;
            }
        }
        //移除已配置的一体机
        private void btnMove_Click(object sender, EventArgs e)
        {


            if (this.dgvList.Rows.Count == 0)
            {
                return;
            }
            if (this.dgvList.SelectedRows.Count < 1)
            {
                MessageHelper.ShowTips("请先选择要操作的数据！");
                return;
            }
            int id = int.Parse(this.dgvList.SelectedRows[0].Cells["Id"].Value.ToString());
            DialogResult dr = MessageBox.Show(this, "确定删除该条数据吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                if (id != 0)
                {
                    if (bll.Delete(id))
                    {
                        MessageHelper.ShowTips("删除成功!");
                        BindData();
                        
                        //this.ucPageBar1.RefreshData(false);
                    }
                    else
                    {
                        MessageHelper.ShowTips("删除失败!");
                    }
                }

            }
        }


        //20160520简阳改，存本地摄像机数据不为In或Out为准，改为One，Two
        //目的只一台电脑可以设置成两个入口或两个出口，便于管理。

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (this.dgvList.Rows.Count == 0)
            {
                return;
            }
            if (this.dgvList.SelectedRows.Count < 1)
            {
                MessageHelper.ShowTips("请先选择要操作的数据！");
                return;
            }

            int id = int.Parse(this.dgvList.SelectedRows[0].Cells["Id"].Value.ToString());
            string LoginName = bll.GetModel(id).LoginrName;
            string Password = bll.GetModel(id).LoginPwd;
            string EquipIp = bll.GetModel(id).EquipIp;
            string Position = bll.GetModel(id).Position;
            string Port = bll.GetModel(id).Port;
            string EquipType = bll.GetModel(id).EquipType;
            string ImagePath = bll.GetModel(id).ImagePath;
            string EquipNo = cbox_no.Text;
            string EquipSerial = bll.GetModel(id).EquipCode;
            INIFile ini = new INIFile(configpath);
          


            try
            {
                if (EquipNo == "1")
                {
                   
                    ini.IniWriteValue("EquipOneSet", "EquipIp", EquipIp);
                    ini.IniWriteValue("EquipOneSet", "Port", Port);
                    ini.IniWriteValue("EquipOneSet", "Position", Position);
                    ini.IniWriteValue("EquipOneSet", "EquipType", EquipType);
                    ini.IniWriteValue("EquipOneSet", "ImagePath", ImagePath);
                    ini.IniWriteValue("EquipOneSet", "LoginName", LoginName);
                    ini.IniWriteValue("EquipOneSet", "Password", Password);
                    ini.IniWriteValue("EquipOneSet", "EquipSerial", EquipSerial);
                    
                }
                if (EquipNo == "2")
               {
                        
                        ini.IniWriteValue("EquipTwoSet", "EquipIp", EquipIp);
                        ini.IniWriteValue("EquipTwoSet", "Port", Port);
                        ini.IniWriteValue("EquipTwoSet", "Position", Position);
                        ini.IniWriteValue("EquipTwoSet", "EquipType", EquipType);
                        ini.IniWriteValue("EquipTwoSet", "ImagePath", ImagePath);
                        ini.IniWriteValue("EquipTwoSet", "LoginName", LoginName);
                        ini.IniWriteValue("EquipTwoSet", "Password", Password);
                        ini.IniWriteValue("EquipTwoSet", "EquipSerial", EquipSerial);
                   
                }
                if (EquipNo == "3")
                {

                    ini.IniWriteValue("EquipThreeSet", "EquipIp", EquipIp);
                    ini.IniWriteValue("EquipThreeSet", "Port", Port);
                    ini.IniWriteValue("EquipThreeSet", "Position", Position);
                    ini.IniWriteValue("EquipThreeSet", "EquipType", EquipType);
                    ini.IniWriteValue("EquipThreeSet", "ImagePath", ImagePath);
                    ini.IniWriteValue("EquipThreeSet", "LoginName", LoginName);
                    ini.IniWriteValue("EquipThreeSet", "Password", Password);
                    ini.IniWriteValue("EquipThreeSet", "EquipSerial", EquipSerial);
                }
                if (EquipNo == "4")
                { 
                        ini.IniWriteValue("EquipFourSet", "EquipIp", EquipIp);
                        ini.IniWriteValue("EquipFourSet", "Port", Port);
                        ini.IniWriteValue("EquipFourSet", "Position", Position);
                        ini.IniWriteValue("EquipFourSet", "EquipType", EquipType);
                        ini.IniWriteValue("EquipFourSet", "ImagePath", ImagePath);
                        ini.IniWriteValue("EquipFourSet", "LoginName", LoginName);
                        ini.IniWriteValue("EquipFourSet", "Password", Password);
                        ini.IniWriteValue("EquipFourSet", "EquipSerial", EquipSerial);


                }
                if (EquipNo == "5")
                {
                    ini.IniWriteValue("EquipFiveSet", "EquipIp", EquipIp);
                    ini.IniWriteValue("EquipFiveSet", "Port", Port);
                    ini.IniWriteValue("EquipFiveSet", "Position", Position);
                    ini.IniWriteValue("EquipFiveSet", "EquipType", EquipType);
                    ini.IniWriteValue("EquipFiveSet", "ImagePath", ImagePath);
                    ini.IniWriteValue("EquipFiveSet", "LoginName", LoginName);
                    ini.IniWriteValue("EquipFiveSet", "Password", Password);
                    ini.IniWriteValue("EquipFiveSet", "EquipSerial", EquipSerial);


                }


                MessageHelper.ShowTips("设置成功！");
            }
            catch
            {
                MessageHelper.ShowTips("设置失败！");
            }


        }

        public string getcboxstr(int index)
        {
            int i = index;
            int incode = 32;
            switch (i)
            {
                case 0:
                    incode = 32;
                    break;
                case 1:
                    incode = 33;
                    break;
                case 2:
                    incode = 34;
                    break;
                case 3:
                    incode = 35;
                    break;
                case 4:
                    incode = 36;
                    break;
                case 5:
                    incode = 37;
                    break;
                case 6:
                    incode = 38;
                    break;
                case 7:
                    incode = 39;
                    break;
                case 8:
                    incode = 40;
                    break;
                case 9:
                    incode = 41;
                    break;
                case 10:
                    incode = 54;
                    break;
                default:
                    incode = 32;
                    break;
            }


            return incode.ToString("X2");


        }

        private void dgvList_DoubleClick(object sender, EventArgs e)
        {
            if (this.dgvList.Rows.Count == 0)
            {
                return;
            }
            if (this.dgvList.SelectedRows.Count < 1)
            {
                MessageHelper.ShowTips("请先选择要操作的数据！");
                return;
            }

            int id = int.Parse(this.dgvList.SelectedRows[0].Cells["Id"].Value.ToString());
            txtLoginName.Text = bll.GetModel(id).LoginrName;
            txtLoginPwd.Text = bll.GetModel(id).LoginPwd;
            txtEquipIp.Text = bll.GetModel(id).EquipIp;
            txtPosition.Text = bll.GetModel(id).Position;
            txtPort.Text = bll.GetModel(id).Port;
            cbEquipType.Text = bll.GetModel(id).EquipType;
            txtImagePath.Text = bll.GetModel(id).ImagePath;

            txtSn.Text = bll.GetModel(id).EquipSn;
            txtNumber.Text = bll.GetModel(id).EquipCode;


        }

        private void but_saveled_Click(object sender, EventArgs e)
        {
           
            INIFile ini = new INIFile(configpath);
            //控制代码 = 进入模式+停留模式+停留时间+退出模式。
            string tabName = LedConfig.SelectedTab.Name;
            string strLedType;
            
            string locip = txtEquipIp.Text.Substring(0, 1);

            if (!IPAddress.TryParse(locip, out myip))
            {
                MessageHelper.ShowTips("请先选择摄像机！");
                return;
            }


            if (tabName == "oneLed")
            {
                //地址为-1时为默认配置
                LedAdrr = cbox_ledaddr.Text; //Led显示屏地址
               


                    incode = getcboxstr(cbox_incode.SelectedIndex);
                    stoptime = (32 + Convert.ToInt32(num_stoptime.Value)).ToString("X2");
                    outcode = getcboxstr(cbox_exitcode.SelectedIndex);
                    auto_sy = "00";
                    auto_ey = "00";// 音量，第一音量，第二音量
                    LedControl = incode + "44" + stoptime + outcode;
                    strLedType = "OneLed";




                    if (cbox_sy.Checked)
                    {
                        auto_sy = mtbox_time1.Text + "-" + cbox_yl1.Text;
                        auto_ey = mtbox_time3.Text + "-" + cbox_yl2.Text;
                    }


                    LedShowType = "1"; //1、表示显示车牌号，2、显示收费信息，3、显示剩余车位数，//未用 4、显示月租车剩余时间
                    if (rb_plate.Checked) { LedShowType = "1"; }
                    if (rb_charge.Checked) { LedShowType = "2"; }

                    if (rb_cws.Checked)
                    {
                        LedShowType = "3";
                        ini.IniWriteValue(txtEquipIp.Text, "LedType", strLedType);
                        ini.IniWriteValue(txtEquipIp.Text, "LedAddr", LedAdrr);
                        ini.IniWriteValue(txtEquipIp.Text, "LedShowType", LedShowType);
                        ini.IniWriteValue(txtEquipIp.Text, "LedControlchar", LedControl);
                        MessageHelper.ShowTips("显示屏参数保存成功，请退出重新打开软件，配置参数在重启软件后生效！");
                    }
                    else
                    {
                        ini.IniWriteValue(txtEquipIp.Text, "LedType", strLedType);
                        ini.IniWriteValue(txtEquipIp.Text, "LedAddr" + LedAdrr, LedAdrr);
                        ini.IniWriteValue(txtEquipIp.Text, "LedShowType" + LedAdrr, LedShowType);
                        ini.IniWriteValue(txtEquipIp.Text, "LedControlchar" + LedAdrr, LedControl);
                    
                        MessageHelper.ShowTips("显示屏参数保存成功，请退出重新打开软件，配置参数在重启软件后生效！");
                    }

                    ini.IniWriteValue(txtEquipIp.Text, "LedVols" + LedAdrr, auto_sy);
                    ini.IniWriteValue(txtEquipIp.Text, "LedVole" + LedAdrr, auto_ey);
            }
           
            else
            {
                //地址为-1时为默认配置
                LedAdrr = cbox_mledaddr.Text;

                WinAdrr = comb_addwin.Text;
                strLedType = "AdLed";
                if (check_mico.Checked)
                {
                    ShowLedico = "1";
                }
                else
                {
                    ShowLedico = "-1";
                }
                string textColor = "FF00000000000000";
                if (cbTextColor.Text == "黄")
                {
                    textColor = "FFFF000000000000";
                }
                if (cbTextColor.Text == "绿")
                {
                    textColor = "00FF000000000000";
                }

                if (rb_mplate.Checked) { LedShowType = "1"; }
                if (rb_mcharge.Checked) { LedShowType = "2"; }
                if (rb_mcws.Checked)
                {
                    LedShowType = "3";
                    //                    LedControl = cbox_mincode.SelectedIndex.ToString("X2") + comb_insd.SelectedIndex.ToString("X2") + "00" + Convert.ToInt16(num_mstoptime.Value).ToString("X2") + cbox_moutcode.SelectedIndex.ToString("X2") + Convert.ToInt16(num_mstoptime.Value).ToString("X2") + "03" + textColor;
                    LedControl = cbox_mincode.SelectedIndex.ToString("X2") + comb_insd.SelectedIndex.ToString("X2") + "00" + Convert.ToInt16(num_mstoptime.Value).ToString("X2") + cbox_moutcode.SelectedIndex.ToString("X2") + Convert.ToInt16(num_mstoptime.Value).ToString("X2") + "03" + Convert.ToInt16(tb_playcs.Text).ToString("X2") + textColor;
                    ini.IniWriteValue(txtEquipIp.Text, "LedType", strLedType);
                    ini.IniWriteValue(txtEquipIp.Text, "LedAddr", LedAdrr);

                    ini.IniWriteValue(txtEquipIp.Text, "LedWinNo", WinAdrr);
                    ini.IniWriteValue(txtEquipIp.Text, "LedShowType", LedShowType);
                    ini.IniWriteValue(txtEquipIp.Text, "LedControlchar", LedControl);
                    MessageHelper.ShowTips("显示屏参数保存成功，请退出重新打开软件，配置参数在重启软件后生效！");
                }
                else
                {
                    LedControl = cbox_mincode.SelectedIndex.ToString("X2") + comb_insd.SelectedIndex.ToString("X2") + "00" + Convert.ToInt16(num_mstoptime.Value).ToString("X2") + cbox_moutcode.SelectedIndex.ToString("X2") + Convert.ToInt16(num_mstoptime.Value).ToString("X2") + "03" + Convert.ToInt16(tb_playcs.Text).ToString("X2") + textColor;
                    ini.IniWriteValue(txtEquipIp.Text, "LedType", strLedType);
                    ini.IniWriteValue(txtEquipIp.Text, "LedAddr", LedAdrr);
                    ini.IniWriteValue(txtEquipIp.Text, "LedWinNo" + WinAdrr, WinAdrr);
                    ini.IniWriteValue(txtEquipIp.Text, "LedShowType" + WinAdrr, LedShowType);
                    ini.IniWriteValue(txtEquipIp.Text, "LedControlchar" + WinAdrr, LedControl);
                    MessageHelper.ShowTips("显示屏参数保存成功，请退出重新打开软件，配置参数在重启软件后生效！");
                }
                ini.IniWriteValue(txtEquipIp.Text, "ShowLedico" + LedAdrr, ShowLedico);
                ini.IniWriteValue(txtEquipIp.Text, "LedVols" + LedAdrr, auto_sy);
                ini.IniWriteValue(txtEquipIp.Text, "LedVole" + LedAdrr, auto_ey);

            }
           
        }

        private void WriteLenInfo(string Ledtype)
        {
            
            if (this.dgvList.Rows.Count == 0)
            {
                MessageHelper.ShowTips("没有摄像机信息，请先添加摄像机！");
                return;
            }
            if (this.dgvList.SelectedRows.Count < 1)
            {
                MessageHelper.ShowTips("请先选择要操作的数据！");
                return;
            }
            for (int i = 0; i < dgvList.SelectedRows.Count; i++)
            {
                int id = int.Parse(this.dgvList.SelectedRows[i].Cells["Id"].Value.ToString());
                string LoginName = bll.GetModel(id).LoginrName;
                string Password = bll.GetModel(id).LoginPwd;
                string EquipIp = bll.GetModel(id).EquipIp;
                string Position = bll.GetModel(id).Position;
                string Port = bll.GetModel(id).Port;
                string EquipType = bll.GetModel(id).EquipType;
                string ImagePath = bll.GetModel(id).ImagePath;
                string EquipNo = cbox_no.Text;
                string EquipSerial = bll.GetModel(id).EquipCode;
                INIFile ini = new INIFile(configpath);

                if (EquipType == "入口设备")
                {
                   ini.IniWriteValue("EquipOneSet", "EquipIp", EquipIp);
                   ini.IniWriteValue("EquipOneSet", "Port", Port);
                   ini.IniWriteValue("EquipOneSet", "Position", Position);
                   ini.IniWriteValue("EquipOneSet", "EquipType", EquipType);
                   ini.IniWriteValue("EquipOneSet", "ImagePath", ImagePath);
                   ini.IniWriteValue("EquipOneSet", "LoginName", LoginName);
                   ini.IniWriteValue("EquipOneSet", "Password", Password);
                   ini.IniWriteValue("EquipOneSet", "EquipSerial", EquipSerial);
                    if (Ledtype == "two")
                    {
                        //剩余车位数
                        ini.IniWriteValue(EquipIp, "LedType", "OneLed");
                        ini.IniWriteValue(EquipIp, "LedAddr1", "1");
                        ini.IniWriteValue(EquipIp, "LedShowType1", "3");
                        ini.IniWriteValue(EquipIp, "LedControlchar1", "20202220");
                        //第一块并显示车牌
                        ini.IniWriteValue(EquipIp, "LedAddr1", "1");
                        ini.IniWriteValue(EquipIp, "LedShowType1", "1");
                        ini.IniWriteValue(EquipIp, "LedControlchar1", "20202220");
                        //第二块屏显示欢迎光临
                        ini.IniWriteValue(EquipIp, "LedAddr2", "2");
                        ini.IniWriteValue(EquipIp, "LedShowType2", "2");
                        ini.IniWriteValue(EquipIp, "LedControlchar2", "20202220");

                    }
                    else
                    {
                        ini.IniWriteValue(EquipIp, "LedType", "AdLed");
                        ini.IniWriteValue(EquipIp, "LedAddr", "1");
                        //第2个窗口剩余车位数
                        ini.IniWriteValue(EquipIp, "LedWinNo", "2");
                        ini.IniWriteValue(EquipIp, "LedShowType", "3");
                        ini.IniWriteValue(EquipIp, "LedControlchar", "01000002010203FF00FF000000000000");
                        //第2个窗口显示车牌
                        ini.IniWriteValue(EquipIp, "LedWinNo2", "2");
                        ini.IniWriteValue(EquipIp, "LedShowType2", "1");
                        ini.IniWriteValue(EquipIp, "LedControlchar2", "010000050105030100FF000000000000");
                        //第3个窗口屏显示欢迎光临
                        ini.IniWriteValue(EquipIp, "LedWinNo3", "3");
                        ini.IniWriteValue(EquipIp, "LedShowType3", "2");
                        ini.IniWriteValue(EquipIp, "LedControlchar3", "010000020102030100FF000000000000");
                    }


                }
                if (EquipType == "出口设备")
                {
                    ini.IniWriteValue("EquipTwoSet", "EquipIp", EquipIp);
                    ini.IniWriteValue("EquipTwoSet", "Port", Port);
                    ini.IniWriteValue("EquipTwoSet", "Position", Position);
                    ini.IniWriteValue("EquipTwoSet", "EquipType", EquipType);
                    ini.IniWriteValue("EquipTwoSet", "ImagePath", ImagePath);
                    ini.IniWriteValue("EquipTwoSet", "LoginName", LoginName);
                    ini.IniWriteValue("EquipTwoSet", "Password", Password);
                    ini.IniWriteValue("EquipTwoSet", "EquipSerial", EquipSerial);
                    if (Ledtype == "two")
                    {
                        ini.IniWriteValue(EquipIp, "LedType", "OneLed");
                        //第一块并显示车牌
                        ini.IniWriteValue(EquipIp, "LedAddr1", "1");
                        ini.IniWriteValue(EquipIp, "LedShowType1", "1");
                        ini.IniWriteValue(EquipIp, "LedControlchar1", "20202220");
                        //第二块屏显示欢迎光临
                        ini.IniWriteValue(EquipIp, "LedAddr2", "2");
                        ini.IniWriteValue(EquipIp, "LedShowType2", "2");
                        ini.IniWriteValue(EquipIp, "LedControlchar2", "20202220");

                    }
                    else
                    {
                        ini.IniWriteValue(EquipIp, "LedType", "AdLed");
                        ini.IniWriteValue(EquipIp, "LedAddr", "1");
                        //第2个窗口显示车牌
                        ini.IniWriteValue(EquipIp, "LedWinNo2", "2");
                        ini.IniWriteValue(EquipIp, "LedShowType2", "1");
                        ini.IniWriteValue(EquipIp, "LedControlchar2", "010000050105030100FF000000000000");
                        //第3个窗口屏显示欢迎光临
                        ini.IniWriteValue(EquipIp, "LedWinNo3", "3");
                        ini.IniWriteValue(EquipIp, "LedShowType3", "2");
                        ini.IniWriteValue(EquipIp, "LedControlchar3", "010000020102030100FF000000000000");
                    }




                }
                if (EquipType == "入口辅助1")
                {
                    ini.IniWriteValue("EquipThreeSet", "EquipIp", EquipIp);
                    ini.IniWriteValue("EquipThreeSet", "Port", Port);
                    ini.IniWriteValue("EquipThreeSet", "Position", Position);
                    ini.IniWriteValue("EquipThreeSet", "EquipType", EquipType);
                    ini.IniWriteValue("EquipThreeSet", "ImagePath", ImagePath);
                    ini.IniWriteValue("EquipThreeSet", "LoginName", LoginName);
                    ini.IniWriteValue("EquipThreeSet", "Password", Password);
                    ini.IniWriteValue("EquipThreeSet", "EquipSerial", EquipSerial);
                    if (Ledtype == "two")
                    {
                        //剩余车位数
                        ini.IniWriteValue(EquipIp, "LedType", "OneLed");
                        ini.IniWriteValue(EquipIp, "LedAddr1", "1");
                        ini.IniWriteValue(EquipIp, "LedShowType1", "3");
                        ini.IniWriteValue(EquipIp, "LedControlchar1", "20202220");
                        //第一块并显示车牌
                        ini.IniWriteValue(EquipIp, "LedAddr1", "1");
                        ini.IniWriteValue(EquipIp, "LedShowType1", "1");
                        ini.IniWriteValue(EquipIp, "LedControlchar1", "20202220");
                        //第二块屏显示欢迎光临
                        ini.IniWriteValue(EquipIp, "LedAddr2", "2");
                        ini.IniWriteValue(EquipIp, "LedShowType2", "2");
                        ini.IniWriteValue(EquipIp, "LedControlchar2", "20202220");

                    }
                    else
                    {
                        ini.IniWriteValue(EquipIp, "LedType", "AdLed");
                        ini.IniWriteValue(EquipIp, "LedAddr", "1");
                        //第2个窗口剩余车位数
                        ini.IniWriteValue(EquipIp, "LedWinNo", "2");
                        ini.IniWriteValue(EquipIp, "LedShowType", "3");
                        ini.IniWriteValue(EquipIp, "LedControlchar", "01000002010203FF00FF000000000000");
                        //第2个窗口显示车牌
                        ini.IniWriteValue(EquipIp, "LedWinNo2", "2");
                        ini.IniWriteValue(EquipIp, "LedShowType2", "1");
                        ini.IniWriteValue(EquipIp, "LedControlchar2", "010000050105030100FF000000000000");
                        //第3个窗口屏显示欢迎光临
                        ini.IniWriteValue(EquipIp, "LedWinNo3", "3");
                        ini.IniWriteValue(EquipIp, "LedShowType3", "2");
                        ini.IniWriteValue(EquipIp, "LedControlchar3", "010000020102030100FF000000000000");
                    }
                }
                if (EquipType == "入口辅助2")
                {
                    ini.IniWriteValue("EquipFourSet", "EquipIp", EquipIp);
                    ini.IniWriteValue("EquipFourSet", "Port", Port);
                    ini.IniWriteValue("EquipFourSet", "Position", Position);
                    ini.IniWriteValue("EquipFourSet", "EquipType", EquipType);
                    ini.IniWriteValue("EquipFourSet", "ImagePath", ImagePath);
                    ini.IniWriteValue("EquipFourSet", "LoginName", LoginName);
                    ini.IniWriteValue("EquipFourSet", "Password", Password);
                    ini.IniWriteValue("EquipFourSet", "EquipSerial", EquipSerial);
                    if (Ledtype == "two")
                    {
                        //剩余车位数
                        ini.IniWriteValue(EquipIp, "LedType", "OneLed");
                        ini.IniWriteValue(EquipIp, "LedAddr1", "1");
                        ini.IniWriteValue(EquipIp, "LedShowType1", "3");
                        ini.IniWriteValue(EquipIp, "LedControlchar1", "20202220");
                        //第一块并显示车牌
                        ini.IniWriteValue(EquipIp, "LedAddr1", "1");
                        ini.IniWriteValue(EquipIp, "LedShowType1", "1");
                        ini.IniWriteValue(EquipIp, "LedControlchar1", "20202220");
                        //第二块屏显示欢迎光临
                        ini.IniWriteValue(EquipIp, "LedAddr2", "2");
                        ini.IniWriteValue(EquipIp, "LedShowType2", "2");
                        ini.IniWriteValue(EquipIp, "LedControlchar2", "20202220");

                    }
                    else
                    {
                        ini.IniWriteValue(EquipIp, "LedType", "AdLed");
                        ini.IniWriteValue(EquipIp, "LedAddr", "1");
                        //第2个窗口剩余车位数
                        ini.IniWriteValue(EquipIp, "LedWinNo", "2");
                        ini.IniWriteValue(EquipIp, "LedShowType", "3");
                        ini.IniWriteValue(EquipIp, "LedControlchar", "01000002010203FF00FF000000000000");
                        //第2个窗口显示车牌
                        ini.IniWriteValue(EquipIp, "LedWinNo2", "2");
                        ini.IniWriteValue(EquipIp, "LedShowType2", "1");
                        ini.IniWriteValue(EquipIp, "LedControlchar2", "010000050105030100FF000000000000");
                        //第3个窗口屏显示欢迎光临
                        ini.IniWriteValue(EquipIp, "LedWinNo3", "3");
                        ini.IniWriteValue(EquipIp, "LedShowType3", "2");
                        ini.IniWriteValue(EquipIp, "LedControlchar3", "010000020102030100FF000000000000");
                    }
                }

                if (EquipType == "出口辅助")
                {
                    ini.IniWriteValue("EquipFiveSet", "EquipIp", EquipIp);
                    ini.IniWriteValue("EquipFiveSet", "Port", Port);
                    ini.IniWriteValue("EquipFiveSet", "Position", Position);
                    ini.IniWriteValue("EquipFiveSet", "EquipType", EquipType);
                    ini.IniWriteValue("EquipFiveSet", "ImagePath", ImagePath);
                    ini.IniWriteValue("EquipFiveSet", "LoginName", LoginName);
                    ini.IniWriteValue("EquipFiveSet", "Password", Password);
                    ini.IniWriteValue("EquipFiveSet", "EquipSerial", EquipSerial);
                    if (Ledtype == "two")
                    {
                        ini.IniWriteValue(EquipIp, "LedType", "OneLed");
                        //第一块并显示车牌
                        ini.IniWriteValue(EquipIp, "LedAddr1", "1");
                        ini.IniWriteValue(EquipIp, "LedShowType1", "1");
                        ini.IniWriteValue(EquipIp, "LedControlchar1", "20202220");
                        //第二块屏显示欢迎光临
                        ini.IniWriteValue(EquipIp, "LedAddr2", "2");
                        ini.IniWriteValue(EquipIp, "LedShowType2", "2");
                        ini.IniWriteValue(EquipIp, "LedControlchar2", "20202220");

                    }
                    else
                    {
                        ini.IniWriteValue(EquipIp, "LedType", "AdLed");
                        ini.IniWriteValue(EquipIp, "LedAddr", "1");
                        //第2个窗口显示车牌
                        ini.IniWriteValue(EquipIp, "LedWinNo2", "2");
                        ini.IniWriteValue(EquipIp, "LedShowType2", "1");
                        ini.IniWriteValue(EquipIp, "LedControlchar2", "010000050105030100FF000000000000");
                        //第3个窗口屏显示欢迎光临
                        ini.IniWriteValue(EquipIp, "LedWinNo3", "3");
                        ini.IniWriteValue(EquipIp, "LedShowType3", "2");
                        ini.IniWriteValue(EquipIp, "LedControlchar3", "010000020102030100FF000000000000");
                    }

                }
               
            }

        }

  

        private void but_timeled_Click(object sender, EventArgs e)
        {
            if (lprHandle > 0)
            {

                Serial = Convert.ToInt16(cbox_ledaddr.Text);
                LedAdrr = (32 + Serial).ToString("X2");

                DateTime currentTime = System.DateTime.Now;
                string year = currentTime.Year.ToString();
                string month = currentTime.Month.ToString();
                string day = currentTime.Day.ToString();
                string hour = currentTime.Hour.ToString();
                string minu = currentTime.Minute.ToString();
                string seco = currentTime.Second.ToString();
                string week = Convert.ToInt16(currentTime.DayOfWeek).ToString();
                year = year.Substring(2, 2);
                if (month.Length < 2) { month = "0" + month; }
                if (day.Length < 2) { day = "0" + day; }
                if (hour.Length < 2) { hour = "0" + hour; }
                if (minu.Length < 2) { minu = "0" + minu; }
                if (seco.Length < 2) { seco = "0" + seco; }
                if (week.Length < 2) { week = "0" + week; }

                string tabName = LedConfig.SelectedTab.Name;
                if (tabName == "oneLed")
                {
                    string strtime = ToHex(year + month + day + week + hour + minu + seco, "gb2312", false);
                    strvol = "02" + LedAdrr + "2620" + strtime + "03";
                }
                else
                {
                    year = "20" + year;
                    string stryear = Convert.ToInt16(year).ToString("X2");
                    stryear = crcforebit(stryear);
                    stryear = stryear.Substring(2, 2) + stryear.Substring(0, 2);



                    string strtime = stryear + Convert.ToInt16(month).ToString("X2") + Convert.ToInt16(day).ToString("X2") + Convert.ToInt16(week).ToString("X2") + Convert.ToInt16(hour).ToString("X2") + Convert.ToInt16(minu).ToString("X2") + Convert.ToInt16(seco).ToString("X2");
                    strvol = Convert.ToInt16(cbox_mledaddr.Text).ToString("X2") + "64FFFF0508" + strtime;
                    string strvolcrc= crcforebit(LedFunc.CalculateCrc16(LedFunc.strToToHexByte(strvol)).ToString("X2"));
                    strvol = strvol + strvolcrc;
 
                }

                int SerialHandle = axCtrl.VzLPRSerialStartEx(lprHandle, 1);
                if (SerialHandle > 0)
                {
                    axCtrl.VzLPRSerialSendEx(lprHandle, SerialHandle, strvol, Convert.ToInt16(strvol.Length / 2));
                    axCtrl.VzLPRSerialStopEx(lprHandle, SerialHandle);
                    MessageBox.Show("设置成功。");
                }

            }
            else
            {
                MessageBox.Show("摄像机未连接或连接不正确，请先连接摄像机。");
                return;
            }
        }

        private void but_sendled_Click(object sender, EventArgs e)
        {
            string tabName = LedConfig.SelectedTab.Name;
            if (lprHandle > 0 && lpropen == 0)
            {
                if (tabName == "oneLed")
                {
                    Serial = Convert.ToInt16(cbox_ledaddr.Text);
                    LedAdrr = (32 + Serial).ToString("X2");
                    incode = getcboxstr(cbox_incode1.SelectedIndex);
                    stoptime = (32 + Convert.ToInt32(num_stoptime1.Value)).ToString("X2");
                    outcode = getcboxstr(cbox_exitcode1.SelectedIndex);
                    LedControl = incode + "44" + stoptime + outcode;



                    string Data = ToHex(tbox_showtext.Text, "gb2312", false);
                    string TimeData = ToHex("20`Y年`M月`D日 星期`V `H:`N:`S", "gb2312", false);

                    string TimeDatalen = (32 + TimeData.Length / 2).ToString("X2");
                    string Datalen = (32 + Data.Length / 2).ToString("X2");
                    string SendText = "02" + LedAdrr + "25" + "23" + "0C" + LedControl + Datalen + Data + "03";
                    string SendShow = "02" + LedAdrr + "24" + "23" + "03";

                    string SendTime = "02" + LedAdrr + "25" + "22" + "0C" + LedControl + TimeDatalen + TimeData + "03";
                    string ShowTime = "02" + LedAdrr + "24" + "22" + "03";

                    bool shanqi = chboxshanqi.Checked;
                    if (shanqi)
                    {
                        string shanqiaddr = (32 + Convert.ToInt32(cbox_sanqi.Text)).ToString("X2");
                        SendText = "02" + LedAdrr + "25" + shanqiaddr + "0C" + LedControl + Datalen + Data + "03";
                        SendShow = "02" + LedAdrr + "24" + shanqiaddr + "03";
                        SendTime = "02" + LedAdrr + "25" + shanqiaddr + "0C" + LedControl + TimeDatalen + TimeData + "03";
                        ShowTime = "02" + LedAdrr + "24" + shanqiaddr + "03";

                    }


                    int lprserial = axCtrl.VzLPRSerialStartEx(lprHandle, 1);
                    if (chbox_showtime.Checked)
                    {
                        axCtrl.VzLPRSerialSendEx(lprHandle, lprserial, SendTime, 255);
                        axCtrl.VzLPRSerialSendEx(lprHandle, lprserial, ShowTime, 255);
                        axCtrl.VzLPRSerialStopEx(lprHandle, lprserial);

                    }
                    if (!string.IsNullOrWhiteSpace(Data))
                    {
                        axCtrl.VzLPRSerialSendEx(lprHandle, lprserial, SendText, 255);
                        axCtrl.VzLPRSerialSendEx(lprHandle, lprserial, SendShow, 255);
                        axCtrl.VzLPRSerialStopEx(lprHandle, lprserial);
                    }
                    MessageBox.Show("发送成功！");

                }
                else
                {//广告屏

                    if (check_mico.Checked)//选中要发送图标
                    {
                        //delledWin("0");
                        //delledWin("1");
                        //Thread.Sleep(500);
                        //delfile("0");
                        //delfile("1");
                        Thread.Sleep(500);
                        delLedText("0");
                        delLedText("1");

                        Thread.Sleep(500);
                        //显示系统图标 参数图标号
                        //显示日期时间
                        bool showico = false, showdata = false;
                        showico=ShowSysIcon(Convert.ToInt16(tb_icono.Text));
                      //  Thread.Sleep(500);
                        showdata=ShowDataTime();
                        if (showico && showdata)
                        {
                            MessageHelper.ShowTips("设置成功！");
                            return;
                        }
                        else
                        {

                            MessageHelper.ShowError("设置失败，请稍后再试！");
                            return;

                        }
                        
                        

                    }
                    else
                    {
                        if (cbox_mledaddr.Text == "")
                        {
                            cbox_mledaddr.Text = "0";
                        }
                        if (comb_addwin.Text == "")
                        {
                            comb_addwin.Text = "0";
                        }

                        string SerialAddr = Convert.ToInt16(cbox_mledaddr.Text).ToString("X2");//串口号
                        string WinAddr = Convert.ToInt16(comb_addwin.Text).ToString("X2");//窗口地址
                        string FileId = Convert.ToInt16(tb_fileno.Text).ToString("X2");//文件号
                        string strinoutsd = Convert.ToInt16(comb_insd.SelectedIndex).ToString("X2");//进入退出速度
                        string strincode = Convert.ToInt16(cbox_mincode.SelectedIndex).ToString("X2");//进入模式
                        string stroutcode = Convert.ToInt16(cbox_moutcode.SelectedIndex).ToString("X2");//退出模式
                        string strstoptime = Convert.ToInt16(num_mstoptime.Value).ToString("X2");//停留时间
                        string strtext = ToHex(text_mshowtext.Text, "gb2312", false);
                        string textlen = (strtext.Length / 2).ToString("X2");
                        string textColor= "FF00000000000000";
                        if (cbTextColor.Text == "黄")
                        {
                            textColor = "FFFF000000000000";
                        }
                        if (cbTextColor.Text == "绿")
                        {
                            textColor = "00FF000000000000";
                        }




                            //资料上说是19，实际是有20个控件制符。
                        string strlr = SerialAddr + "64FFFF67" + (20 + strtext.Length / 2).ToString("X2")+ WinAddr + FileId + "0C" + strincode + strinoutsd + "00" + strstoptime + stroutcode + strinoutsd + "03"+textColor + textlen + "00" + strtext;
                        string strcontrol = strlr + crcforebit(LedFunc.CalculateCrc16(LedFunc.strToToHexByte(strlr)).ToString("X2"));

                        int lprserial = axCtrl.VzLPRSerialStartEx(lprHandle, 1);
                        Thread.Sleep(500);
                        int info = axCtrl.VzLPRSerialSendEx(lprHandle, lprserial, strcontrol, Convert.ToInt16(strcontrol.Length / 2));
                        axCtrl.VzLPRSerialStopEx(lprHandle, lprserial);
                        if (info == 0)
                        {
                            MessageHelper.ShowTips("设置成功！");
                            return;

                        }
                        else
                        {  
                            MessageHelper.ShowError("设置失败，请稍后再试！");
                            return;

                        }

                    }

                }
            }
            else
            {
                MessageBox.Show("发送失败，请先连接摄像机！");
                return;

            }

        }

        private bool delfile(string winno)
        {
            string strData = Convert.ToInt16(cbox_mledaddr.Text).ToString("X2") + "64FFFF6B02";
            string strTemp = strData;
            string strDatacrc = null;
            string strsendData = null;
            short strdataLen = 0;
            bool isdel = false;
            if (lprHandle > 0)
            {
                int serialHandle = axCtrl.VzLPRSerialStartEx(lprHandle, 1);
                if (winno == "-1")
                {
                    for (int j=0;j<4;j++)
                    { 
                        for (int i = 0; i < 8; i++)
                        {
                            strData = strTemp + Convert.ToInt16(j).ToString("X2") + i.ToString("X2");
                            strDatacrc = LedFunc.CalculateCrc16(LedFunc.strToToHexByte(strData)).ToString("X2");
                            strsendData = strData + crcforebit(strDatacrc);
                            strdataLen = Convert.ToInt16(strsendData.Length / 2);
                            Thread.Sleep(500);
                            axCtrl.VzLPRSerialSendEx(lprHandle, serialHandle, strsendData, strdataLen);


                        }
                    }
                }
                else
                { 
                for (int i = 0; i < 8; i++)
                {
                    strData = strTemp + Convert.ToInt16(winno).ToString("X2") + i.ToString("X2");
                    strDatacrc = LedFunc.CalculateCrc16(LedFunc.strToToHexByte(strData)).ToString("X2");
                    strsendData = strData + crcforebit(strDatacrc);
                    strdataLen = Convert.ToInt16(strsendData.Length / 2);
                    axCtrl.VzLPRSerialSendEx(lprHandle, serialHandle, strsendData, strdataLen);


                }

                }
                axCtrl.VzLPRSerialStopEx(lprHandle, serialHandle);
                isdel = true;
            }
            else
            {
                isdel = false;

            }
            return isdel;


        }

        private bool ShowSysIcon(int v)
        {
          // delledpic()//删除图图片
            bool istrue = false;
   
            string s_addr = Convert.ToInt16(cbox_mledaddr.Text).ToString("X2");

            string strdelpic = s_addr + "64FFFF810104";
            string strdepiccrc = LedFunc.CalculateCrc16(LedFunc.strToToHexByte(strdelpic)).ToString("X2");
            strdelpic = strdelpic + crcforebit(strdepiccrc);

            string strcolbgCode = s_addr+ "64FFFF410400000000"; //selbgcolor()//设置背景颜色
            string strcolbgCodecrc = LedFunc.CalculateCrc16(LedFunc.strToToHexByte(strcolbgCode)).ToString("X2");
            strcolbgCode = strcolbgCode + crcforebit(strcolbgCodecrc);

            string strcolCode  = s_addr + "64FFFF4004FF000000";//setcolor()//设置绘'颜色
            string strcolCodecrc = LedFunc.CalculateCrc16(LedFunc.strToToHexByte(strcolCode)).ToString("X2");
            strcolCode = strcolCode + crcforebit(strcolCodecrc);

            string strclear = s_addr + "64FFFF0100";
            string strclearcrc = LedFunc.CalculateCrc16(LedFunc.strToToHexByte(strclear)).ToString("X2");
            strclear = strclear + crcforebit(strclearcrc);


            string strshowiconcode = s_addr + "64FFFF430AFAFFFEFF01000300" + v.ToString("X2") + "00";
            string strshowiconcrc = LedFunc.CalculateCrc16(LedFunc.strToToHexByte(strshowiconcode)).ToString("X2");
            strshowiconcrc = crcforebit(strshowiconcrc);
           
            string strshowicon = strshowiconcode + strshowiconcrc;
            //图形箭头
            //1、建立图片控件

            string strpiccode = s_addr+"64FFFF8009041800100030001000";
            string strpiccrc = LedFunc.CalculateCrc16(LedFunc.strToToHexByte(strpiccode)).ToString("X2");
            strpiccrc = crcforebit(strpiccrc);



            string strpic = strpiccode + strpiccrc;
            //2、添加图片
            string straddpiccode = s_addr + "64FFFF8209042D00010200000606";
            string straddpiccrc = LedFunc.CalculateCrc16(LedFunc.strToToHexByte(straddpiccode)).ToString("X2");
            straddpiccrc = crcforebit(straddpiccrc);



            string straddpic = straddpiccode + straddpiccrc;


            if (lprHandle > 0)
            {
                int lprserial = axCtrl.VzLPRSerialStartEx(lprHandle, 1);

                Thread.Sleep(500);
                axCtrl.VzLPRSerialSendEx(lprHandle, lprserial, strdelpic, Convert.ToInt16(strdelpic.Length / 2));//删除图标控件
                Thread.Sleep(500);
                axCtrl.VzLPRSerialSendEx(lprHandle, lprserial, strshowicon, Convert.ToInt16(strshowicon.Length / 2));//设置显示图标
                Thread.Sleep(500);
                axCtrl.VzLPRSerialSendEx(lprHandle, lprserial, strpic, Convert.ToInt16(strpic.Length / 2));//建立图片控件
                Thread.Sleep(500);
                axCtrl.VzLPRSerialSendEx(lprHandle, lprserial, straddpic, Convert.ToInt16(straddpic.Length / 2));//显示箭头

                axCtrl.VzLPRSerialSendEx(lprHandle, lprserial, strclear, Convert.ToInt16(strclear.Length / 2));//清除LED内存               

                Thread.Sleep(500);
                axCtrl.VzLPRSerialSendEx(lprHandle, lprserial, strcolbgCode,Convert.ToInt16(strcolbgCode.Length/2));//设置背景
                Thread.Sleep(500);
                axCtrl.VzLPRSerialSendEx(lprHandle, lprserial, strcolCode, Convert.ToInt16(strcolCode.Length / 2));//设置前景
           
                axCtrl.VzLPRSerialStopEx(lprHandle, lprserial);
                istrue = true;

            }

            else
            {
              
                istrue = false;

            }
            return istrue;


           
        }

        //crc 之后不足四位补齐四位
        private string crcforebit(string str)
        {
            int istrlen = str.Length;
            for (int i = 0; i < 4 - istrlen; i++)
            {
                str = "0" + str;

            }
            return str;
           
        }

        private bool ShowDataTime()
        {
            //1、建立文本控件
            //2、显示时间
            //3、建立文本控件
            //4、显示日期
            bool istrue = false;;
            string s_addr = Convert.ToInt16(cbox_mledaddr.Text).ToString("X2");
            string straddtimecode = s_addr + "64FFFF600A00001100000030000800";
            string straddtimecrc = LedFunc.CalculateCrc16(LedFunc.strToToHexByte(straddtimecode)).ToString("X2").ToString();

            straddtimecrc = crcforebit(straddtimecrc);



            string straddtime = straddtimecode + straddtimecrc;

            string stradddatecode = s_addr + "64FFFF600A01001300080030000800";
            string stradddatecrc = LedFunc.CalculateCrc16(LedFunc.strToToHexByte(stradddatecode)).ToString("X2").ToString();

            stradddatecrc = crcforebit(stradddatecrc);

            string stradddate = stradddatecode + stradddatecrc;

            string strshowdatecode = s_addr + "64FFFF621B00000108FF00010000FF00000000000000080060592D604D2D6044";
            string strshowdatecrc = LedFunc.CalculateCrc16(LedFunc.strToToHexByte(strshowdatecode)).ToString("X2").ToString();
            strshowdatecode = strshowdatecode + crcforebit(strshowdatecrc);

            string strshowtimecode = s_addr + "64FFFF621B01000108FF00010000FF00000000000000080060483A604E3A6053";
            string strshowtimecrc = LedFunc.CalculateCrc16(LedFunc.strToToHexByte(strshowtimecode)).ToString("X2").ToString();
            strshowtimecode = strshowtimecode + crcforebit(strshowtimecrc);


            if (lprHandle > 0)
            {
                int lprserial = axCtrl.VzLPRSerialStartEx(lprHandle, 1);
                Thread.Sleep(500);
                axCtrl.VzLPRSerialSendEx(lprHandle, lprserial, stradddate, Convert.ToInt16(stradddate.Length / 2));
                Thread.Sleep(500);
                axCtrl.VzLPRSerialSendEx(lprHandle, lprserial, straddtime, Convert.ToInt16(straddtime.Length / 2));
                Thread.Sleep(500);
                axCtrl.VzLPRSerialSendEx(lprHandle, lprserial, strshowdatecode, Convert.ToInt16(strshowdatecode.Length / 2));
                Thread.Sleep(500);
                axCtrl.VzLPRSerialSendEx(lprHandle, lprserial, strshowtimecode, Convert.ToInt16(strshowtimecode.Length / 2));
                axCtrl.VzLPRSerialStopEx(lprHandle, lprserial);
                istrue = true;
            }
            else
            {

                istrue = false;
            }

            return istrue;





        }

       

        public static string ToHex(string s, string charset, bool fenge)
        {
            if ((s.Length % 2) != 0)
            {
                s += " ";//空格
                         //throw new ArgumentException("s is not valid chinese string!");
            }
            System.Text.Encoding chs = System.Text.Encoding.GetEncoding(charset);
            byte[] bytes = chs.GetBytes(s);
            string str = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                str += string.Format("{0:X}", bytes[i]);
                if (fenge && (i != bytes.Length - 1))
                {
                    str += string.Format("{0}", ",");
                }
            }
            return str;
        }

        private void butsetvol_Click(object sender, EventArgs e)
        {
            string tabName = LedConfig.SelectedTab.Name;
            string strvoltext = "", strvolcs = "", strbritext = "", strbrics = ""; //音量和亮度
            string voltext = "";
            if (tabName == "oneLed")
            {

                Serial = Convert.ToInt16(cbox_ledaddr.Text);
                LedAdrr = (32 + Serial).ToString("X2");
                strvoltext = "02" + LedAdrr + "9C" + "20" + (32 + Convert.ToInt32(comgdyl.Text)).ToString("X2");
                strbritext = "02" + LedAdrr + "9B" + "20" + (32 + Convert.ToInt32(comgdld.Text)).ToString("X2");
                strvolcs = strtocs(strvoltext);
                strvol = strvoltext + "20" + strvolcs + "03";
                strbrics = strtocs(strbritext);
                strbri = strbritext + "20" + strbrics + "03";
            }

            else
            {
                Serial = Convert.ToInt16(cbox_mledaddr.Text);
                LedAdrr = Serial.ToString("X2");
                //  winno = Convert.ToInt16(comb_addwin.Text);
                //  winaddr =  winno.ToString("X2");
                strvoltext = LedAdrr + "64FFFF0D01" + Convert.ToInt16(combmgdyl.Text).ToString("X2");
                strbritext = LedAdrr + "64FFFF0C01" + Convert.ToInt16(combmdgld.Text).ToString("X2");
                voltext = LedAdrr + "64FFFF300901BBB6D3ADB9E2C1D9" + LedFunc.CalculateCrc16(LedFunc.strToToHexByte(LedAdrr + "64FFFF300901BBB6D3ADB9E2C1D9")).ToString("X2");
                string strvolcrc = LedFunc.CalculateCrc16(LedFunc.strToToHexByte(strvoltext)).ToString("X2");
                string strbricrc = LedFunc.CalculateCrc16(LedFunc.strToToHexByte(strbritext)).ToString("X2");
                strvol = strvoltext + crcforebit(strvolcrc);
                strbri = strbritext + crcforebit(strbricrc);
            }
            if (lprHandle > 0)
            {
                int SerialHandle = axCtrl.VzLPRSerialStartEx(lprHandle, 1);
                if (SerialHandle > 0)
                {
                    //设置音量
                    axCtrl.VzLPRSerialSendEx(lprHandle, SerialHandle, strvol, Convert.ToInt16(strvol.Length / 2));
                    //测试音量
                    axCtrl.VzLPRSerialSendEx(lprHandle, SerialHandle, voltext, Convert.ToInt16(voltext.Length / 2));
                    //设置亮度
                    axCtrl.VzLPRSerialSendEx(lprHandle, SerialHandle, strbri, Convert.ToInt16(strbri.Length / 2));
                    axCtrl.VzLPRSerialStopEx(lprHandle, SerialHandle);

                    MessageBox.Show("设置成功。");
                }

            }
            else
            {
                MessageBox.Show("摄像机未连接或连接不正确，请先连接摄像机。");
                return;
            }
        }

        private string strtocs(string strvoltext)
        {
            int cs = 1;
            for (int i = 0; i < strvoltext.Length; i++)
            {
                cs = cs + Convert.ToInt32(strvoltext.Substring(i, 1), 16);
            }
            return cs.ToString("X2");

        }

        private void butleddel_Click(object sender, EventArgs e)
        {
            string tabName = LedConfig.SelectedTab.Name;
            if (tabName == "oneLed")
            {
                string ledaddr = (32 + Convert.ToInt32(cbox_ledaddr.Text)).ToString("X2");
                if (lprHandle > 0 && lpropen == 0)
                {
                    int serialHandle = axCtrl.VzLPRSerialStartEx(lprHandle, 1);
                    axCtrl.VzLPRSerialSendEx(lprHandle, serialHandle, "02" + ledaddr + "282003", 255);
                    MessageBox.Show("清除LED所有内容成功！");

                }
                else
                {
                    MessageBox.Show("清除LED内容失败，请检查设备连接！");

                }
            }
            else
            {//广告屏
             //1、删除窗体，默认0，1，2，3，4，5，6，7  delledWin()
             //2、新建窗体 ,默认0，1，2，3，4，5，6，7  addledWin()


                bool isdel =false,isadd=false,isdelText=false,isdelfile=false;
  
                isdelfile = delfile("-1");
                isdelText = delLedText("-1");
                isdel = delledWin("-1");
                isadd = addledWin("-1");

                if (isdel&&isadd&&isdelText&&isdelfile)
                {
                 
                    MessageBox.Show("初始化成功！");

                }
                else

                {
                    MessageBox.Show("初始化失败，请检查设备连接！");

                }




            }
        }

        private bool delLedText(string winno)
        {
            string strData = Convert.ToInt16(cbox_mledaddr.Text).ToString("X2") + "64FFFF6101";
            string strTemp = strData;
            string strDatacrc = null;
            string strsendData = null;
            short strdataLen = 0;
            bool isdel = false;
            if (lprHandle > 0)
            {
                int serialHandle = axCtrl.VzLPRSerialStartEx(lprHandle, 1);
                if (winno == "-1")
                {
                    for (int i = 0; i < 4; i++)
                    {

                        strData = strTemp + i.ToString("X2");
                        strDatacrc = LedFunc.CalculateCrc16(LedFunc.strToToHexByte(strData)).ToString("X2");
                        strsendData = strData + strDatacrc;
                        strdataLen = Convert.ToInt16(strsendData.Length / 2);
                        Thread.Sleep(500);
                        axCtrl.VzLPRSerialSendEx(lprHandle, serialHandle, strsendData, strdataLen);
                    }
                }
                else
                {
                    strData = strTemp + Convert.ToInt16(winno).ToString("X2") ;
                    strDatacrc = LedFunc.CalculateCrc16(LedFunc.strToToHexByte(strData)).ToString("X2");
                    strsendData = strData + strDatacrc;
                    strdataLen = Convert.ToInt16(strsendData.Length / 2);
                    Thread.Sleep(500);
                    axCtrl.VzLPRSerialSendEx(lprHandle, serialHandle, strsendData, strdataLen);

                }
                //显示同步窗口
                strData = Convert.ToInt16(cbox_mledaddr.Text).ToString("X2") + "64FFFF530101";
                strDatacrc = LedFunc.CalculateCrc16(LedFunc.strToToHexByte(strData)).ToString("X2");
                strDatacrc = crcforebit(strDatacrc);
                strsendData = strData + strDatacrc;
                strdataLen = Convert.ToInt16(strsendData.Length / 2);

                axCtrl.VzLPRSerialSendEx(lprHandle, serialHandle, strsendData, strdataLen);
                axCtrl.VzLPRSerialStopEx(lprHandle, serialHandle);
                isdel = true;
            }
            else
            {
                isdel = false;

            }
            return isdel;



        }

        private bool addledWin(string winno)
        {
            string strData = Convert.ToInt16(cbox_mledaddr.Text).ToString("X2") + "64FFFF600A";
            string strTemp = strData;
            string strDatacrc = null;
            string strsendData = null;
            short strdataLen = 0;
            bool isdel = false;
            if (lprHandle > 0)
            {
             int serialHandle = axCtrl.VzLPRSerialStartEx(lprHandle, 1);
             if (winno == "-1")
                {
                    int a = 0;
                    for (int i = 0; i < 8; i++)
                    {

                        strData = strTemp + i.ToString("X2") + "000000" + a.ToString("X2") + "0040001000";
                        strDatacrc = LedFunc.CalculateCrc16(LedFunc.strToToHexByte(strData)).ToString("X2");
                        strDatacrc = crcforebit(strDatacrc);
                        strsendData = strData + strDatacrc;
                        strdataLen = Convert.ToInt16(strsendData.Length / 2);
                        Thread.Sleep(500);
                        axCtrl.VzLPRSerialSendEx(lprHandle, serialHandle, strsendData, strdataLen);
                        a = a + 16;
                      
                    }
                }
                else
                {
                    strData = strTemp + "0" + winno + "000000" + (Convert.ToInt16(winno)*16).ToString("X2") + "0040001000";
                    strDatacrc = LedFunc.CalculateCrc16(LedFunc.strToToHexByte(strData)).ToString("X2");
                    strDatacrc = crcforebit(strDatacrc);
                    strsendData = strData + strDatacrc;
                    strdataLen = Convert.ToInt16(strsendData.Length / 2);
                    axCtrl.VzLPRSerialSendEx(lprHandle, serialHandle, strsendData, strdataLen);
 
                }
                //显示同步窗口
                strData = Convert.ToInt16(cbox_mledaddr.Text).ToString("X2") + "64FFFF530101";
                strDatacrc = LedFunc.CalculateCrc16(LedFunc.strToToHexByte(strData)).ToString("X2");
                strDatacrc = crcforebit(strDatacrc);
                strsendData = strData + strDatacrc;
                strdataLen = Convert.ToInt16(strsendData.Length / 2);
                axCtrl.VzLPRSerialSendEx(lprHandle, serialHandle, strsendData, strdataLen);
                axCtrl.VzLPRSerialStopEx(lprHandle, serialHandle);
                isdel = true;
            }
            else
            {
                isdel = false;

            }
            return isdel;
        }

        private bool delledWin(string  winno)
        {
            string strData = Convert.ToInt16(cbox_mledaddr.Text).ToString("X2") + "64FFFF5202";
            string strTemp = strData;
            string strDatacrc = null;
            string strsendData = null;
            short strdataLen = 0;
            bool isdel = false;
                if (lprHandle > 0)
                {
                int serialHandle = axCtrl.VzLPRSerialStartEx(lprHandle, 1);
                if (winno == "-1")
                {
                     for (int i = 0; i < 8; i++)
                    {
                        strData = strTemp + i.ToString("X2") + "00";
                        strDatacrc = crcforebit(LedFunc.CalculateCrc16(LedFunc.strToToHexByte(strData)).ToString("X2"));
                        strsendData = strData + strDatacrc;
                        strdataLen = Convert.ToInt16(strsendData.Length / 2);
                        Thread.Sleep(1000);
                        axCtrl.VzLPRSerialSendEx(lprHandle, serialHandle, strsendData, strdataLen);
 
                    }
                }
               else
               {

                    strData = strTemp + Convert.ToInt16(winno).ToString("X2") + "00";
                    strDatacrc = crcforebit(LedFunc.CalculateCrc16(LedFunc.strToToHexByte(strData)).ToString("X2"));
                    strsendData = strData + strDatacrc;
                    strdataLen = Convert.ToInt16(strsendData.Length / 2);
                    axCtrl.VzLPRSerialSendEx(lprHandle, serialHandle, strsendData, strdataLen);


                }
                axCtrl.VzLPRSerialStopEx(lprHandle,serialHandle);
                isdel = true;
            }
            else
            {
                isdel = false;

            }
            return isdel;
        }

        private void frmEquipConfig_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (lprHandle > 0)
            {
                axCtrl.VzLPRClientClose(lprHandle);
            }
        }

        private void cbox_ledaddr_SelectedIndexChanged(object sender, EventArgs e)
        {
            showLedInfo();
        }

        private void showLedInfo()
        {

            INIFile ini = new INIFile(configpath);
            string ipAddr = txtEquipIp.Text;
            LedAdrr = cbox_ledaddr.Text;
            string winNo= ini.IniReadValue(ipAddr, "LedWinNo" + LedAdrr);
            if (string.IsNullOrEmpty(winNo)) { winNo = "-1"; }
            string tabName = LedConfig.SelectedTab.Name;
            if (tabName == "oneLed"&& winNo=="-1")
            {


                string ledAddr = ini.IniReadValue(ipAddr, "LedAddr" + LedAdrr);
                string ledShowType = ini.IniReadValue(ipAddr, "LedShowType" + LedAdrr);
                string ledControl = ini.IniReadValue(ipAddr, "LedControlchar" + LedAdrr);
                string ledmControl = ini.IniReadValue(ipAddr, "LedMControlchar" + LedAdrr);
                string ledVoss = ini.IniReadValue(ipAddr, "LedVols" + LedAdrr);
                string ledVose = ini.IniReadValue(ipAddr, "LedVole" + LedAdrr);
                if (!string.IsNullOrEmpty(ledControl))
                {

                    LedControl = incode + "44" + stoptime + outcode;
                    cbox_incode.SelectedIndex = Convert.ToInt32(ledControl.Substring(0, 2), 16) - 32;
                    cbox_exitcode.SelectedIndex = Convert.ToInt32(ledControl.Substring(6, 2), 16) - 32;
                    num_stoptime.Value = Convert.ToInt32(ledControl.Substring(4, 2), 16) - 32;

                }

                    if (ledShowType == "1")
                {
                    rb_plate.Checked = true;
                }


                if (ledShowType == "2")
                {
                    rb_charge.Checked = true;
                }


                if (ledShowType == "3")
                {
                    rb_yzcsysj.Checked = true;
                }

                if (ledShowType == "4")
                {
                    rb_cws.Checked = true;
                }

            }
            else
            {

                LedAdrr = cbox_mledaddr.Text;
                string ledAddr = ini.IniReadValue(ipAddr, "LedAddr" + LedAdrr);
                string ledShowType = ini.IniReadValue(ipAddr, "LedShowType" + LedAdrr);
                string ledControl = ini.IniReadValue(ipAddr, "LedControlchar" + LedAdrr);
                string ledmControl = ini.IniReadValue(ipAddr, "LedMControlchar" + LedAdrr);
                string ledVoss = ini.IniReadValue(ipAddr, "LedVols" + LedAdrr);
                string ledVose = ini.IniReadValue(ipAddr, "LedVole" + LedAdrr);
                string ledShowico = ini.IniReadValue(ipAddr, "LedShowico" + LedAdrr);
                string ledWinno = ini.IniReadValue(ipAddr, "LedWinNo" + LedAdrr);

          
                comb_addwin.Text = ledWinno;
                if (!string.IsNullOrEmpty(ledmControl))
                {
                    cbox_mincode.SelectedIndex = Convert.ToInt32(ledmControl.Substring(0, 2), 16);
                    comb_insd.SelectedIndex = Convert.ToInt32(ledmControl.Substring(2, 2), 16);
                    num_mstoptime.Value = Convert.ToInt32(ledmControl.Substring(6,2), 16);
                    cbox_moutcode.SelectedIndex = Convert.ToInt32(ledmControl.Substring(8,2),16);

                }


                if (ledShowType == "1")
                {
                    rb_mplate.Checked = true;
                }


                if (ledShowType == "2")
                {
                    rb_mcharge.Checked = true;
                }


                //if (ledShowType == "3")
                //{
                //    rb_yzcsysj.Checked = true;
                //}

                if (ledShowType == "4")
                {
                    rb_mcws.Checked = true;
                }

                if (ledShowico == "1")

                {
                    check_mico.Checked = true;


                }
                else
                {
                    check_mico.Checked = false;

                }


            }




        }

        private void check_mico_CheckedChanged(object sender, EventArgs e)
        {
            if (check_showtime.Checked)
            {

                text_mshowtext.Text = "现在时间 20`Y 年`M 月`D 日 星期`V `H:`N:`S";


            }
            else
            {
                text_mshowtext.Text = "";
                lb_icono.Visible = true;
                tb_icono.Visible = true;
            }

        }

        private void check_mico_Click(object sender, EventArgs e)
        {
            if (check_showtime.Checked)
            {
                text_mshowtext.Text = "现在时间 20`Y 年`M 月`D 日 星期`V `H:`N:`S";
            }
            else
            {
                text_mshowtext.Text = "";
                lb_icono.Visible = true;
                tb_icono.Visible = true;
            }
        }

        private void btn_setting_Click(object sender, EventArgs e)
        {
            if (cbox_two.Checked)
            {
                WriteLenInfo("two");
            }
            else { WriteLenInfo("four"); };
        }

        private void cbox_sy_CheckedChanged(object sender, EventArgs e)
        {
            if (cbox_sy.Checked)
            {
                mtbox_time1.Enabled = true;
                mtbox_time2.Enabled = true;
                mtbox_time3.Enabled = true;
                mtbox_time4.Enabled = true;
                cbox_yl1.Enabled = true;
                cbox_yl2.Enabled = true;
            }
            else
            {
                mtbox_time1.Enabled = false;
                mtbox_time2.Enabled = false;
                mtbox_time3.Enabled = false;
                mtbox_time4.Enabled = false;
                cbox_yl1.Enabled = false;
                cbox_yl2.Enabled = false;

            }
        }
    }
}
