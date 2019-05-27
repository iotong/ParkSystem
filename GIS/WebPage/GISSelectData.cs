using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargeWin.GIS.WebPage
{
    /// <summary>
    /// 定义GIS数据，提供给js可以和Winform进行互操作
    /// </summary>
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]//将该类设置为com可访问
    public class GISSelectData
    {
        /// <summary>
        /// 定义回调方法
        /// </summary>
        /// <param name="longValue">经度值</param>
        /// <param name="latValue">纬度值</param>
        public delegate void callBackMethod(string longValue, string latValue);
        callBackMethod objCallBackMethod = null;

        /// <summary>
        /// 获取或设置委托对象
        /// </summary>
        public callBackMethod ObjCallBackMethod
        {
            get { return objCallBackMethod; }
            set { objCallBackMethod = value; }
        }

        private double longitudeValue = 0;
        /// <summary>
        /// 获取或设置经度值
        /// </summary>
        public double LongitudeValue
        {
            get { return longitudeValue; }
            set { longitudeValue = value; }
        }
        private double latitudeValue = 0;
        /// <summary>
        /// 获取或设置纬度值
        /// </summary>
        public double LatitudeValue
        {
            get { return latitudeValue; }
            set { latitudeValue = value; }
        }

        /// <summary>
        /// js触发的方法,显示单击的经纬度
        /// </summary>
        /// <param name="jsParameter">js传递过来的参数值</param>
        public void JSClickEvent(string jsParameter)
        {
            double longValue = double.Parse(jsParameter.Split('|')[0]);
            double latValue = double.Parse(jsParameter.Split('|')[1]);
            this.LongitudeValue = longValue;
            this.LatitudeValue = latValue;
            objCallBackMethod(longValue.ToString(), latValue.ToString());
        }
    }
}
