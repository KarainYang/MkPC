<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Tab.aspx.cs" Inherits="Admin_Tab" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        //展示内容选项卡
        function showContentDiv(i) {
            $(".contentDiv").css("display", "none");
            $(".contentDiv").eq(i).css("display", "block");
        }
        //加载选项
        function loadTab(i) {
            showContentDiv(i);
            $(".title").css("background-color", "white");
            $(".title").eq(i).css("background-color", "yellow");
            $(".title").each(function (index) {
                this.onclick = function () { loadTab(index); }
                this.ondblclick = function () { remove(index); }
            });
        }
        //添加某一项
        function add(title, url, id) {
            //如果已经存在，则显示该选项
            if ($("a[id='a" + id + "']").length > 0) {
                $("a[id='a" + id + "']").click();
                return;
            }

            var title = "<a class='title' id='a" + id + "'>" + title + "</a>";
            document.getElementById("titles").innerHTML += title;
            
            var height = window.screen.availHeight - 130;
            var div = document.createElement("div");
            div.id = "div" + id;
            div.className = "contentDiv";
            div.innerHTML = "<iframe src='" + url + "' width='100%' frameBorder=0 noResize scrolling=no height='" + height + "' />";
            document.getElementById("contentDivs").appendChild(div);

            loadTab($(".title").length - 1);
        }
        //移除某一项
        function remove(i) {
            $(".title").eq(i).remove();
            $(".contentDiv").eq(i).remove();
            loadTab($(".title").length - 1);
        }

        var entityList = eval('<%=resourcesJson%>');
        //选择菜单
        function changeMenu(index) {
            var html = "";
            var entity = entityList[index];
            for (var i = 0; i < entity.ChildTree.length; i++) {
                var item = entity.ChildTree[i];
                html += "<a href=\"javascript:add('" + item.ResourceName + "','" + item.Url + "','" + item.ID + "')\" >" + item.ResourceName + "</a>";
                document.getElementById("childMenu").innerHTML = html;
            }
        }
        window.onload = function () {
            //加载菜单	
            for (var i = 0; i < entityList.length; i++) {
                var entity = entityList[i];
                var html = "<a class=\"menuCss\" href=\"javascript:changeMenu(" + i + ")\">" + entity.ResourceName + "</a>";
                document.getElementById("parentMenu").innerHTML += html;
            }
            changeMenu(0);
        }
</script>
</head>
<body>
    <style>
        body,div,table,a,p,span{ margin:0px;padding:0px; text-decoration:none; font-size:12px;}
        .parentMenu{line-height:50px;background-color:rgb(39,145,222)}
        .parentMenu a{color:white;margin-left:10px;}
        .childMenu{background-color:rgb(154,218,246);height:38px;line-height:38px;}
        .childMenu a{display:block;float:left;margin-left:10px;}
        .childMenu a:hover{color:red;font-weight:bold;}
        .titlesDiv{background-color:rgb(211,238,250);}
        .title{height:31px;line-height:31px;margin-top:2px;margin-bottom:2px; display:block; margin-left:10px; float:left; background-color:white; padding-left:5px; padding-right:5px; cursor:pointer;}
    </style>
    <div id="parentMenu" class="parentMenu"></div>
    <div id="childMenu" class="childMenu"></div>
    <div class="titlesDiv">
	    <div id="titles" class="titles"></div>
        <div style="clear:both;"></div>
    </div>
    <div id="contentDivs"></div>
</body>
</html>
