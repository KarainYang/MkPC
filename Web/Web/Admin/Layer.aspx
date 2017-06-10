<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Layer.aspx.cs" Inherits="Admin_Layer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body,div,a,ul,li,p{ margin:0px; padding:0px; font-size:12px;}
        .layer,.locklayer
        {
            position:absolute;
            top:0;
            margin:0 auto;    
            background-color:white;     
            }
        .layer{ border:1px solid gray;}
        .locklayer
        {
            filter:alpha(opacity=80);
            -moz-opacity:0.8;
            -khtml-opacity:0.8;
            opacity=80;
            }
        .layerTopBar
        {
            width:100%;
            background-color:#e6e4e4;
            height:30px;
            }
        .layerTopBar a
        {
            height:26px;
            line-height:26px;          
            display:block; 
            text-decoration:none;
            text-align:center;
            float:right;
            margin:2px;
            font-size:20px;
            }
       .layerTopBar a:hover
        {
            color:Red;
        }
    </style>
    <script type="text/javascript">
        var i = 0, layerWidths = [], layerHeights = [];//弹出层宽、高数组
        var mouseStartLeft = 0.0, mouseStartTop = 0.0;//鼠标开始坐标
        var divStartLeft = 0.0, divStartTop = 0.0;//div开始坐标
        var isMouseDown = false;//是否鼠标按下
        var isDefaultButtonClick = false;//是否默认按钮点击
        //展示
        function showLayer(url, width, height) {
            layerWidths[i] = width;
            layerHeights[i] = height;

            var divLock = document.createElement("Div");
            divLock.id = "layer_" + i;
            divLock.className = "locklayer";
            divLock.style.cssText = "z-index:" + i + ";width:" + window.innerWidth + "px;height:" + window.innerHeight + "px;";
            document.body.appendChild(divLock);

            var div = document.createElement("Div");
            div.id = "layer" + i;
            div.className = "layer";
            div.title = "双击最大/最小化";
            div.style.cssText = "z-index:" + i + ";width:" + width + "px;height:" + height + "px;"
                + "margin-left:" + (window.innerWidth - width) / 2 + "px;margin-top:" + (window.innerHeight - height) / 2 + "px;";
            div.innerHTML = "<div class='layerTopBar' ondblclick='maxLayer(" + i + ")'>"
                + "<a href='javascript:void(0)' onclick='closeLayer()'>×</a>"
                + "<a href='javascript:void(0)' onclick='maxLayer(" + i + ")'>□</a></div>"
                + "<iframe style='width:100%;height:" + height + "px' id='frame_" + i + "' src='" + url + "' frameborder='0' />";

            div.onmousemove = function () {
                if (isMouseDown == true) {
                    this.style.marginLeft = (divStartLeft + (window.event.clientX - mouseStartLeft)) + "px";
                    this.style.marginTop = (divStartTop + (window.event.clientY - mouseStartTop)) + "px";
                }
            }
            div.onmouseup = function () {
                isMouseDown = false;                
            }
            div.onmousedown = function () {
                isMouseDown = true;
                mouseStartLeft = window.event.clientX;
                mouseStartTop = window.event.clientY;
                divStartLeft = this.getBoundingClientRect().left;
                divStartTop = this.getBoundingClientRect().top;
            }
            window.top.document.body.appendChild(div);

            document.body.appendChild(div);
            i++;
        }
        //关闭
        function closeLayer() {
            i--;
            window.top.document.body.removeChild(document.getElementById("layer_" + i));
            window.top.document.body.removeChild(document.getElementById("layer" + i));
            isDefaultButtonClick = false;
        }
        //最大化或最小化
        function maxLayer(num) {
            if (document.getElementById("layer" + num).style.width == layerWidths[num]+"px") {
                document.getElementById("layer" + num).style.width = window.innerWidth + "px";
                document.getElementById("layer" + num).style.height = window.innerHeight + "px";
                document.getElementById("layer" + num).style.marginLeft = "0px";
                document.getElementById("layer" + num).style.marginTop = "0px";
            }
            else {
                document.getElementById("layer" + num).style.width = layerWidths[num] + "px";
                document.getElementById("layer" + num).style.height = layerHeights[num] + "px";
                document.getElementById("layer" + num).style.marginLeft = (window.innerWidth - layerWidths[num]) / 2 + "px";
                document.getElementById("layer" + num).style.marginTop = (window.innerHeight - layerHeights[num]) / 2 + "px";
            }
        }
        //关闭并刷新父窗体
        function closeReloadParentLayer() {
            closeLayer();
            if (i > 0) {
                window.top.frames["frame_" + (i - 1)].window.location = window.top.frames["frame_" + (i - 1)].window.location.href;
            }
            else {
                window.top.window.location = window.top.window.location.href;
            }
        }
        //获取父级窗体
        function getParentFrame() {
            if (i > 0) {
                window.top.frames["frame_" + (i - 1)].window;
            }
            else {
                window.top.window;
            }
        }
        //快捷键
        window.onkeyup = function () {
            if (event.keyCode == 27 && i > 0) {
                closeLayer();
            }
            if (event.keyCode == 116 || event.keyCode == 13) {
                if (isDefaultButtonClick == false) {
                    var inputs = document.getElementsByTagName("input");
                    for (var j = 0; j < inputs.length; j++) {
                        if (inputs[j].attributes["IsEnter"] != null) {
                            if (inputs[j].attributes["IsEnter"].value.toLocaleLowerCase() == "true") {
                                inputs[j].click();
                                break;
                            }
                        }
                    }
                }
            }
            switch (event.keyCode) {
                case 37:
                    divMove(-10, 0);
                    break;
                case 38:
                    divMove(0, -10);
                    break;
                case 39:
                    divMove(10, 0);
                    break;
                case 40:
                    divMove(0, 10);
                    break;
            }
        }
        function divMove(left, top) {
            var obj = document.getElementById("layer" + (i - 1));
            obj.style.marginLeft = obj.getBoundingClientRect().left + left + "px";
            obj.style.marginTop = obj.getBoundingClientRect().top + top + "px";
        }
    </script>
</head>
<body>
    <input type="button" value="添加层" IsEnter="true" onclick="window.top.showLayer('Tab.aspx',600,500)" />
</body>
</html>
