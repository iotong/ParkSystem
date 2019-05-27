var map;   //定义map对象
var point; //创建中心点坐标

/*************************************定义功能函数**********************************/
//初始化地图
function initialize() {
    map = new BMap.Map("container");
    point = new BMap.Point(106.67497, 26.605877); //默认为贵阳市
    map.addControl(new BMap.NavigationControl());

    
    //设置中心点
    map.centerAndZoom(point, 11);

    addMarker();

    //添加地图的右键单击事件
    map.addEventListener("rightclick", function (e) {
        rightclicklng = e.point.lng;
        rightclicklnt = e.point.lat;
    });

    //启用鼠标滑轮缩放功能
    map.enableScrollWheelZoom();

    // 添加比例尺控件
    map.addControl(new BMap.ScaleControl());

    //添加缩略地图控件
    map.addControl(new BMap.OverviewMapControl());

    //添加地图类型控件，可以查看卫星地图
    map.addControl(new BMap.MapTypeControl({ anchor: BMAP_ANCHOR_TOP_RIGHT }));

    //清除logo方法
    var logoTimer = setInterval(clearLogo, 500);
}

//去掉百度的logo,使用clearInterval会失效
function clearLogo() {
    var logoImg = $("a[title='到百度地图查看此区域']");
    var logoTxt = $(".BMap_cpyCtrl span");
    logoImg.hide();
    logoTxt.remove();
}

//添加一个标注点
function addMarker() {
    var markerPoint = new BMap.Point(106.67497, 26.605877);//Marker点的坐标
    var marker = new BMap.Marker(markerPoint);  // 创建标注
    map.addOverlay(marker);              // 将标注添加到地图中
    marker.enableDragging();             //启用拖拽事件
    marker.addEventListener("dragend", function (e) {
        //alert("当前位置：" + e.point.lng + ", " + e.point.lat);

        invokeCSharpMethod(e.point.lng, e.point.lat);
    })
}

//调用Winform中.CS类中的方法，实现交互
function invokeCSharpMethod(longValue, latValue) {
    window.external.JSClickEvent(longValue + "|" + latValue);
}