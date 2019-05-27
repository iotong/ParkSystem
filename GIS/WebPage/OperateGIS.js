/**********************定义操作GIS的相关方法**********************/
/********* Author:Zhou.huawei********/
/********* CreateDate:2013-11-2*****/
/********* ModifyDate:2013-12-17*****/

/*************************************定义相关变量**********************************/

var map;   //定义map对象
var point; //创建中心点坐标
var rightclicklng;//鼠标右键单击时候记录的经度
var rightclicklnt; //鼠标右键单击时候记录的纬度
var dynamicRadius; //选择的半径(单位：Km)

/*************************************定义图片**********************************/

//默认的在线图标(ZX)
var zxIcon = new BMap.Icon("ZX.png", new BMap.Size(27, 43), {
    offset: new BMap.Size(0, 0)
});

//在建状态图标(ZJ)
var zjIcon = new BMap.Icon("ZJ.png", new BMap.Size(27, 43), {
    offset: new BMap.Size(0, 0)
});

//验收状态图标(YS)
var ysIcon = new BMap.Icon("YS.png", new BMap.Size(62, 61), {
    offset: new BMap.Size(0, 0)
});

//维护状态图标(WH)
var whIcon = new BMap.Icon("WH.png", new BMap.Size(62, 61), {
    offset: new BMap.Size(0, 0)
});


/*************************************定义功能函数**********************************/
//初始化地图
function initialize(){
    map = new BMap.Map("container");
    point = new BMap.Point(106.67497, 26.605877); //默认为贵阳市
    map.addControl(new BMap.NavigationControl());

    //marker标点
    markAllMoniterStation();
    
    //添加右键菜单
   addContextMenuItem();

    //设置中心点
    map.centerAndZoom(point, 11);

    //启用鼠标滑轮缩放功能
    map.enableScrollWheelZoom();

    // 添加比例尺控件
    map.addControl(new BMap.ScaleControl());

    //添加缩略地图控件
    map.addControl(new BMap.OverviewMapControl());

    //添加地图类型控件，可以查看卫星地图
    map.addControl(new BMap.MapTypeControl({ anchor: BMAP_ANCHOR_TOP_RIGHT }));

    //清除logo方法
    var logoTimer = setInterval(clearLogo, 500);}

//去掉百度的logo,使用clearInterval会失效
function clearLogo() {
    var logoImg = $("a[title='到百度地图查看此区域']");
    var logoTxt = $(".BMap_cpyCtrl span");
    logoImg.hide();
    logoTxt.remove();
    }


//根据经纬度设置地图中心点
function setCenterByLongAndLat(longitude, latitude) {
    map.centerAndZoom(new BMap.Point(longitude, latitude), 11);
    rangeAddMarkerList();
}

//添加标注点文本描述信息
function addMarkLableInfo(marker, lblContent) {
    var label = new BMap.Label(lblContent, { offset: new BMap.Size(-5, 50) });
    marker.setLabel(label);
}

//绑定Marker的MouseOverOutEvent，设置Icon图标
function bingMarkerMouseOverOutEvent(mark,markIcon) {
    marker.addEventListener("mouseover", function () {
        marker.setIcon(thIcon);
    });

    marker.addEventListener("mouseout", function () {
        marker.setIcon(markIcon);
    });
}



//添加右键菜单
function addContextMenuItem() {
    var menu = new BMap.ContextMenu();
    var txtMenuItem = [
  {
      text: '放大',
      callback: function () { map.zoomIn() }
  },
  {
      text: '缩小',
      callback: function () { map.zoomOut() }
  }
 ];

    for (var i = 0; i < txtMenuItem.length; i++) {
        menu.addItem(new BMap.MenuItem(txtMenuItem[i].text, txtMenuItem[i].callback, 100));

        //添加分割线
        if (i == 1) {
            menu.addSeparator();
        }
    }
    map.addContextMenu(menu);
}



/***********************************************************************************************************/
/***********************************************************************************************************/
var currentClickPoint;   //当前单击的Marker点
var currentClickPointStr;//当前点击点的文本信息
var circle;//框选的圆
var RADIAL = 15000;//圆的半径(米)
var rPoint;//圆的中心点坐标
var circlePoint = new Array();//框选的点集合


//定义贵阳人防点坐标数组
//var cdArray = new Array(["106.719215", "26.585913", "中中商场", "贵阳市云岩区"], ["106.721673", "26.453687", "测试项目", "贵阳市云岩区1路"], ["106.601385", "26.549265", "测试项目02", "贵阳市云岩区2路"], ["106.77774", "26.57292", "测试项目03", "贵阳市云岩区3路"]);
var cdArray = new Array();

/*************************************GIS基础方法***************************************/


//标注当前建设单位所有的人防项目点
function markAllMoniterStation() {
    //贵阳
    for (var i = 0; i < cdArray.length; i++) {

        var pName = cdArray[i].split(",")[0];
        var pAddress = cdArray[i].split(",")[1];
        var jd = cdArray[i].split(",")[2];
        var wd = cdArray[i].split(",")[3];
        var point = new BMap.Point(jd, wd);
        addMarker(point, i, pName, pAddress);
    }
}

//添加标注点
function addMarker(point, index,content,address) {
    // 创建标注对象并添加到地图  
    var marker = new BMap.Marker(point, { icon: zxIcon });

    map.addOverlay(marker);

    //添加Marker描述文字
    addMarkLableInfo(marker, content);

    //添加Marker单击事件
    addMarkerClickEvent(point, marker, content,address);

    //添加Marker的MouseOver及MouseOut事件
    addMarkerMouseOverOutEvent(marker);
}

//添加图标单击事件
function addMarkerClickEvent(point,marker,content,address) {
    var opts = {
        width: 300,     // 信息窗口宽度
        height: 200,     // 信息窗口高度
        title: "------------项目基本信息-----------"  // 信息窗口标题
    }
    var strHtml = "";
    //定义信息框文本
    strHtml += "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" class=\"infoTable\">";
    strHtml += "<tr>";
    strHtml += "<td width=\"180px\"></td>";
    strHtml += "<td rowspan=\"4\" width=\"80px\"><img src='" + "ZJ.png" + "' ></td>";
    strHtml += "</tr>";
    strHtml += "<tr><td height=\"17px\">项目名称：<font color='red'>" + content + "</font></td></tr>";
    strHtml += "<tr><td height=\"17px\">项目地址：<font color='red'>" + address + "</font></td></tr>";
    strHtml += "<tr><td height=\"17px\">经度：<font color='red'>" + marker.point.lng + "</font></td></tr>";
    strHtml += "<tr><td height=\"17px\">纬度：<font color='red'>" + marker.point.lat + "</font></td></tr>";
    strHtml += "</table>";


    //创建信息窗口对象
    var infoWindow = new BMap.InfoWindow(strHtml, opts);
    marker.addEventListener("click", function () {
        this.openInfoWindow(infoWindow);

        //记录当前点击的点坐标及名称
        currentClickPoint = point;
        currentClickPointStr = content;
    });
}

//添加图标MouseOver及MouseOut事件
function addMarkerMouseOverOutEvent(marker) {
    marker.addEventListener("mouseover", function () {
        marker.setIcon(thIcon);
    });

    marker.addEventListener("mouseout", function () {
        marker.setIcon(zxIcon);
    });
}

/************************************javascript和c#的交互*****************************************/
//初始化Marker数组
function InitMarkerArray(markerString) {
    var mkStr = markerString + "";
    var mkArray = mkStr.split("|");

    //Marker标注点赋值
    for (var i = 0; i < mkArray.length; i++) {
        cdArray[i] = mkArray[i];
    }
}
