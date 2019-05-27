using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using www.gzwulian.com.BLL;
using www.gzwulian.com.Common;

namespace ChargeWin
{
    public partial class frmDataClear : Form
    {
        public frmDataClear()
        {
            InitializeComponent();
        }

        private www.gzwulian.com.BLL.SettlementManager settlementBLL = new SettlementManager();
        private www.gzwulian.com.BLL.PlateIdentifyInfoManager identifyInfoBLL = new PlateIdentifyInfoManager();
        private www.gzwulian.com.BLL.FInOutInfoManager fInOutBLL = new FInOutInfoManager();
        private www.gzwulian.com.BLL.ChargeRecordManager chargeBLL = new ChargeRecordManager();
        private www.gzwulian.com.BLL.FCustomerManager fCustomerBll = new FCustomerManager();
        private www.gzwulian.com.BLL.FeeStandardManager feeStandBll = new FeeStandardManager();


        private void butSele_Click(object sender, EventArgs e)
        {
            if (butSele.Text == "全  选")
            {
                chblcarinout.Checked = true;
                chbfcarinout.Checked = true;
                chbcarcharge.Checked = true;
                chbjob.Checked = true;
                chbchargstand.Checked = true;
                chbrecord.Checked = true;
                chbsystem.Checked = true;


                butSele.Text = "全不选";
            }
            else
            {
                chblcarinout.Checked = false;
                chbfcarinout.Checked = false;
                chbcarcharge.Checked = false;
                chbjob.Checked = false;
                chbchargstand.Checked = false;
                chbrecord.Checked = false;
                chbsystem.Checked = false;

                butSele.Text = "全  选";
            }
           
           



        }

        private void butclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            string tips="";
            string strDay = txtDay.Text;
            if (!IsIntNum(strDay))
            {
                txtDay.Focus();
            }
            else
            {
                if (chblcarinout.Checked)
                {
                    tips = tips + "【临时车进出记录】";

                }
                if (chbfcarinout.Checked)
                {
                    tips = tips + "【月租车进出记录】";
                }

                if (chbcarcharge.Checked)
                {
                    tips = tips + "【临时车收费记录】";
                }
                if (chbjob.Checked)
                {
                    tips = tips + "【上下班记录】";
                }
                if (chbchargstand.Checked)
                {
                    tips = tips + "【收费标准记录】";
                }
                if (chbrecord.Checked)
                {
                    tips = tips + "【月租车档案】";
                }

                if (chbsystem.Checked)
                {
                    tips = tips + "【系统设置参数】";

                }

                try
                {
                    if (MessageHelper.ShowYesNoAndWarning("确定要清除" + tips + "数据吗？清除之后数据不可恢复，确定清除请选【是】。") == DialogResult.Yes)
                    {
                        ClearAllInfo(strDay);
                        // MessageHelper.ShowTips("数据清除成功！");

                    }
                }
                catch (Exception)
                {
                    MessageHelper.ShowTips("数据清除失败！");
                }
            }
        }

        public void ClearAllInfo(string strDay)
        {
            string tips = "删除";
           
            int i = 0;
           
            if (chblcarinout.Checked)
            {
                //清除临时时进出记录
                identifyInfoBLL.DelWhere(strDay);
                tips = tips + "【临时车进出记录】(" + i.ToString() + ") 条";
 
            }
            if (chbfcarinout.Checked)
            {
                //清除固定车辆进出入记录
                i=fInOutBLL.DelWhere(strDay);
                tips = tips + "【月租车进出记录】(" + i.ToString() + ") 条";

            }

            if (chbcarcharge.Checked)
            {
                //清除收费记录
                chargeBLL.DelWhere(strDay);
                tips = tips + "【临时车收费记录】(" + i.ToString() + ") 条";
            }
            if (chbjob.Checked)
            {
                i = settlementBLL.DelWhere(strDay);
                tips = tips + "【上下班记录】(" + i.ToString() + ") 条";
            }
            if (chbchargstand.Checked)
            {
                //清除收费标准信息
                feeStandBll.DelWhere(strDay);
                tips = tips + "【收费标准记录】(" + i.ToString() + ") 条";
            }
            if (chbrecord.Checked)
            {  //清除固定车案信息
                fCustomerBll.DelWhere(strDay);
                tips = tips + "【月租车档案】(" + i.ToString() + ") 条";
            }

            if (chbsystem.Checked)
            {
                //系统参数
                i = 0;
                tips = tips + "【系统设置参数】(" + i.ToString() + ") 条";
                chargeBLL.DelLog();
            }
            MessageHelper.ShowTips(tips);
           //清除日志
           

        }


        public static bool IsIntNum(string str)
        {
            System.Text.RegularExpressions.Regex reg1
            = new System.Text.RegularExpressions.
                Regex(@"^[-]?[1-9]{1}\d*$|^[0]{1}$");
            bool ismatch = reg1.IsMatch(str);
            if (!ismatch)
                MessageBox.Show("您输入的天数不是整数,请重新输入！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return ismatch;

        }
    }
}
