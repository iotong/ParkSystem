using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChargeWin.WebCarTypeInfo;
using ChargeWin.WebOperatorInfo;

namespace ChargeWin
{
    public   class ModelTrans
    {
        /// <summary>
        /// 获取服务端固定客户进出记录实体
        /// </summary>
        /// <param name="mode">实体对象</param>
        /// <returns></returns>
        public static WebFInOutInfo.FInOutInfo GetWebFInOutModel(www.gzwulian.com.Model.FInOutInfo model)
        {
            WebFInOutInfo.FInOutInfo webFInoutmodel = new WebFInOutInfo.FInOutInfo();
            if(model.AddTime!=null)
            { 
            webFInoutmodel.AddTime = model.AddTime;
            }
            webFInoutmodel.CompanyCode = model.CompanyCode;
            webFInoutmodel.FCustomerId = model.FCustomerId;
            webFInoutmodel.Id = model.Id;
            webFInoutmodel.InImgPath = model.InImgPath;
            if(model.InTime!=null)
            {
                webFInoutmodel.InTime = DateTime.Parse(model.InTime.ToString());
            }
            webFInoutmodel.VehicType = model.VehicType;
            webFInoutmodel.IsUpload = model.IsUpload;
            webFInoutmodel.OperatorName = model.OperatorName;
            webFInoutmodel.OutImgPath = model.OutImgPath;
            if(model.OutTime!=null)
            {
                webFInoutmodel.OutTime = DateTime.Parse(model.OutTime.ToString());
            }
            webFInoutmodel.ParkId = model.ParkId;
            webFInoutmodel.PlateColor = model.PlateColor;
            webFInoutmodel.PlateId = model.PlateId;
            return webFInoutmodel;

        }
        /// <summary>
        /// 通过实体对象得到服务端实体对象
        /// </summary>
        /// <param name="mode">实体对象</param>
        /// <returns></returns>
        public static WebWorkInfo.Settlement GetWebSettlModel(www.gzwulian.com.Model.Settlement mode)
        {
            WebWorkInfo.Settlement webmodel = new WebWorkInfo.Settlement();
            if (mode != null)
            {
                webmodel.Id = mode.Id;
                webmodel.AddTime = mode.AddTime;
                webmodel.ChargeAmount = mode.ChargeAmount;
                webmodel.CompanyCode = mode.CompanyCode;
                webmodel.FInCount = mode.FInCount;
                webmodel.FOutCount = mode.FOutCount;
                webmodel.InCount = mode.InCount;
                webmodel.OffWorkTime = mode.OffWorkTime;
                webmodel.OperatorName = mode.OperatorName;
                webmodel.OutCount = mode.OutCount;
                webmodel.ParkId = mode.ParkId;
                webmodel.StaffName = mode.StaffName;
                webmodel.WorkTime = mode.WorkTime;
            }
            return webmodel;
        }
        /// <summary>
        /// 获得到服务端收费记录实体
        /// </summary>
        /// <param name="mode">实体对象</param>
        /// <returns></returns>
        public static WebChargeInfo.ChargeRecord GetWebChargeModel(www.gzwulian.com.Model.ChargeRecord mode)
        {
            WebChargeInfo.ChargeRecord webmodel = new WebChargeInfo.ChargeRecord();
            if (mode != null)
            {
                webmodel.Id = mode.Id;
                webmodel.CarType = mode.CarType;
                webmodel.CardCode = mode.CardCode;
                webmodel.CompanyCode = mode.CompanyCode;
                webmodel.FeeStandard = mode.FeeStandard;
                webmodel.FreeReason = mode.FreeReason;
                webmodel.FeeStandard = mode.FeeStandard;
                webmodel.GiveCharge = mode.GiveCharge;
                webmodel.OperatorName = mode.OperatorName;
                webmodel.InTime = mode.InTime;
                webmodel.ParkId = mode.ParkId;
                webmodel.Memo = mode.Memo;
                webmodel.Name = mode.Name;
                webmodel.OperatorName = mode.OperatorName;
                webmodel.OperatorTime = mode.OperatorTime;
                webmodel.OutTime = mode.OutTime;
                webmodel.ParkTime = mode.ParkTime;
                webmodel.PlateId = mode.PlateId;
                webmodel.ReMoney = mode.ReMoney;
                webmodel.SumMoney = mode.SumMoney;
            }
            return webmodel;
        }
       


        /// <summary>
        /// 获得服务端操作员实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static WebOperatorInfo.Operator GetWebOpeModel(www.gzwulian.com.Model.Operator model)
        {
            WebOperatorInfo.Operator opModel = new WebOperatorInfo.Operator();
            opModel = new WebOperatorInfo.Operator();
            opModel.AddTime = model.AddTime;
            opModel.CompanyCode = model.CompanyCode;
            opModel.GroupId = model.GroupId;
            opModel.Id = model.Id;
            opModel.IsUpload = model.IsUpload;
            opModel.OperatorName = model.OperatorName;
            opModel.ParkId = model.ParkId;
            opModel.Password = model.Password;
            opModel.RealName = model.RealName;
            opModel.RightsList = model.RightsList;
            opModel.State = model.State;
            opModel.TelPhone = model.TelPhone;
            return opModel;
        }
        /// <summary>
        /// 获得服务端固定客户实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static WebFCustomerInfo.FCustomer GetWebFCustomerModel(www.gzwulian.com.Model.FCustomer model)
        {
            WebFCustomerInfo.FCustomer FCustomerModel = new WebFCustomerInfo.FCustomer();
            FCustomerModel.Address = model.Address;
            if(model.AddTime!=null)
            { 
            FCustomerModel.AddTime =DateTime.Parse(model.AddTime.ToString());
            }
            FCustomerModel.Affiliation = model.Affiliation;
            FCustomerModel.BirthDate = model.BirthDate;
            FCustomerModel.CarType = model.CarType;
            FCustomerModel.Code = model.Code;
            FCustomerModel.CompanyCode = model.CompanyCode;
            if (model.CreateTime!=null)
            {
                FCustomerModel.CreateTime =DateTime.Parse(model.CreateTime.ToString());
            }
            FCustomerModel.Department = model.Department;
            FCustomerModel.Enable = model.Enable;
            FCustomerModel.Gender = model.Gender;
            FCustomerModel.Id = model.Id;
            FCustomerModel.IdCard = model.IdCard;
            FCustomerModel.ImgPath = model.ImgPath;
            FCustomerModel.IsMarried = model.IsMarried;
            FCustomerModel.IsUpload = model.IsUpload;
            FCustomerModel.JoinDate = model.JoinDate;
            FCustomerModel.Majou = model.Majou;
            FCustomerModel.Name = model.Name;
            FCustomerModel.NativePlace = model.NativePlace;
            FCustomerModel.NeedAlarm = model.NeedAlarm;
            FCustomerModel.OperatorName = model.OperatorName;
            if (model.OverTime != null)
            {
                FCustomerModel.OverTime = DateTime.Parse(model.OverTime.ToString());
            }
            FCustomerModel.ParkId = model.ParkId;
            FCustomerModel.Path = model.Path;
            FCustomerModel.PlateColor = model.PlateColor;
            FCustomerModel.PlateId = model.PlateId;
            FCustomerModel.Position = model.Position;
            FCustomerModel.PostalCode = model.PostalCode;
            FCustomerModel.School = model.School;
            FCustomerModel.StartTimeSeg = model.StartTimeSeg;
            FCustomerModel.Telphone = model.Telphone;
            FCustomerModel.TimeSeg = model.TimeSeg;
            FCustomerModel.TopDegree = model.TopDegree;
            return FCustomerModel;
        }
        /// <summary>
        /// 获得服务端收费标准实体
        /// </summary>
        /// <param name="mode">实体对象</param>
        /// <returns></returns>
        public static WebStandardInfo.FeeStandard GetWebStandardModel(www.gzwulian.com.Model.FeeStandard mode)
        {
            WebStandardInfo.FeeStandard webmodel = new WebStandardInfo.FeeStandard();
            if (mode != null)
            {
                webmodel.Id = mode.Id;
                webmodel.CarType = mode.CarType;
                webmodel.CompanyCode = mode.CompanyCode;
                webmodel.DayFirstTimeHour = mode.DayFirstTimeHour;
                webmodel.DayFirstTimeMinute = mode.DayFirstTimeMinute;
                webmodel.DayLowestFee = mode.DayLowestFee;
                webmodel.DayStartHour = mode.DayStartHour;
                webmodel.OperatorName = mode.OperatorName;
                webmodel.DayStartMinute = mode.DayStartMinute;
                webmodel.ParkId = mode.ParkId;
                webmodel.DayTimeUnit = mode.DayTimeUnit;
                webmodel.DayTopFee = mode.DayTopFee;
                webmodel.OperatorName = mode.OperatorName;
                webmodel.DayUnitFee = mode.DayUnitFee;
                webmodel.FeePerView = mode.FeePerView;
                webmodel.FeeType = mode.FeeType;
                webmodel.Feetop = mode.Feetop;
                webmodel.FreeMinutes = mode.FreeMinutes;
                webmodel.NightFirstTimeHour = mode.NightFirstTimeHour;
                webmodel.NightFirstTimeMinute = mode.NightFirstTimeMinute;
                webmodel.NightLowestFee = mode.NightLowestFee;
                webmodel.NightStartHour = mode.NightStartHour;
                webmodel.NightStartMinute = mode.NightStartMinute;
                webmodel.NightTimeUnit = mode.NightTimeUnit;
                webmodel.NightTopFee = mode.NightTopFee;
                webmodel.NightUnitFee = mode.NightUnitFee;
                webmodel.OperateTime = mode.OperateTime;
                webmodel.STFirstTimeFee = mode.STFirstTimeFee;
                webmodel.STFirstTimeUnitHour = mode.STFirstTimeUnitHour;
                webmodel.STFirstTimeUnitMinute = mode.STFirstTimeUnitMinute;
                webmodel.STOverNightFee = mode.STOverNightFee;
                webmodel.STTimeUnie = mode.STTimeUnie;
                webmodel.STUnieFee = mode.STUnieFee;
                webmodel.StandardFee = mode.StandardFee;
            }
            return webmodel;
        }
        /// <summary>
        /// 获得服务端车类型实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static WebCarTypeInfo.CarType GetWebCarTypeModel(www.gzwulian.com.Model.CarType model)
        {
            WebCarTypeInfo.CarType webModel = new WebCarTypeInfo.CarType();
            if (model!=null)
            {
                webModel.AddTime = model.AddTime;
                webModel.CarTypeName = model.CarTypeName;
                webModel.ChargeId = model.ChargeId;
                webModel.CompanyCode = model.CompanyCode;
                webModel.Id = model.Id;
                webModel.OperatorName = model.OperatorName;
                webModel.ParkId = model.ParkId;
            }
            return webModel;
        }
    }

}
