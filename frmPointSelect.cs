using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ChargeWin.GIS.WebPage;

namespace ChargeWin
{
    /// <summary>
    /// GIS坐标选取窗体类
    /// </summary>
    public partial class frmPointSelect : Form
    {
        public frmPointSelect()
        {
            InitializeComponent();
        }

        //GIS数据操作对象
        GISSelectData objGISData = null; 

        //回调委托对象
        public ChargeWin.GIS.WebPage.GISSelectData.callBackMethod objcallMethod = null;

        /// <summary>
        /// 获取或设置经度
        /// </summary>
        public string Longitude { set; get; }

        /// <summary>
        /// 获取或设置纬度
        /// </summary>
        public string Latitude { set; get; }

        /// <summary>
        /// 窗体加载，显示GIS界面
        /// </summary>
        private void frmPointSelect_Load(object sender, EventArgs e)
        {
            //绑定委托方法
            objcallMethod = new GISSelectData.callBackMethod(ShowLongLatPoint);
            //加载GIS页面
            LoadGISHtml();
        }


        /// <summary>
        /// 显示经纬度
        /// </summary>
        /// <param name="longitude">经度</param>
        /// <param name="latitude">纬度</param>
        private void ShowLongLatPoint(string longitude,string latitude)
        {
            this.txtLongitude.Text = longitude;
            this.txtLatitude.Text = latitude;

            //属性赋值
            this.Longitude = longitude;
            this.Latitude = latitude;
        }

        /// <summary>
        /// 加载GIS页面
        /// </summary>
        private void LoadGISHtml()
        {
            //设置webBrowser   
            this.wbrowserGIS.ScriptErrorsSuppressed = true; //禁用错误脚本提示
            //this.wbrowserGIS.Navigate(new Uri(System.Environment.CurrentDirectory + @"/GIS/WebPage/SelectGISPoint.htm", UriKind.RelativeOrAbsolute));
            this.wbrowserGIS.Navigate(new Uri(Application.StartupPath+ @"/GIS/WebPage/SelectGISPoint.htm", UriKind.RelativeOrAbsolute));
            objGISData = new GISSelectData();
            objGISData.ObjCallBackMethod = objcallMethod;
            wbrowserGIS.ObjectForScripting = objGISData;
        }

        /// <summary>
        /// 刷新页面
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadGISHtml();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.Longitude) || string.IsNullOrEmpty(this.Latitude))
            {
                MessageBox.Show("请在地图上拖动图标获取坐标点位！");
                this.DialogResult = DialogResult.None;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
