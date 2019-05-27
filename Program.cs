using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using www.gzwulian.com.Common;

namespace ChargeWin
{
    static class Program
    {

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmTest());
            string configpath = GlobalInfo.Instance.ConfigPath;
            INIFile ini = new INIFile(configpath);
            string isFirst = ini.IniReadValue("Check", "IsFirst");
            if (!isFirst.Equals("0"))
            {
                Application.Run(new frmLogin());
            }
            else
            {
                Application.Run(new frmDbSet());
            }
        }
    }
}
