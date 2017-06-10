<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Tab2.aspx.cs" Inherits="Admin_Tab" %>

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
</script>
<link rel="stylesheet" type="text/css" href="css/reset.css" />
</head>
<body>
    <style>
        body,div,table,a,p,span{ margin:0px;padding:0px; text-decoration:none; font-size:12px;}
        .titlesDiv{background-color:rgb(211,238,250);}
        .title{height:31px;line-height:31px;margin-top:2px;margin-bottom:2px; display:block; margin-left:10px; float:left; background-color:white; padding-left:5px; padding-right:5px; cursor:pointer;}
    </style>

    <div id="smoothmenu1" class="ddsmoothmenu">
    <ul>
        <li>
            <img src="images/logo.jpg" style=" height:50px;" />
        </li>
        <%
            foreach (var model in resources)
            {
             %>
             <li>
                <a href="javascript:void(0)">
                    <%= model.ResourceName %>
                </a>
                <%
                if (model.ChildTree!=null)
                { 
                    %>
                    <ul>
                        <% foreach (var child in model.ChildTree)
                           { %>
                                <li>                                
                                        <%
                                           if (child.ChildTree == null)
                                           { 
                                            %>
                                            <a href="javascript:add('<%=child.ResourceName %>','<%=child.Url %>','<%=child.ID %>')"><%= child.ResourceName%></a>
                                        <%
                                           }
                                           else
                                           {                                        
                                             %>
                                             <a href="javascript:void(0)"><%= child.ResourceName%><img class="rightarrowclass" src="images/nav_arrow.png" /></a>

                                        <%
                                            }
                                             %>


                                        <%
                                           if (child.ChildTree!=null)
                                           { 
                                            %>
                                            <ul>
                                                <% 
                                                    foreach (var child2 in child.ChildTree)
                                                    { 
                                                        %>
                                                        <li>
                                                            <a><%= child2.ResourceName%></a>
                                                        </li>
                                                <%
                                                    }
                                                     %>
                                            </ul>
                                        <%
                                            }
                                           %>
                                </li>
                        <%
                           }
                             %>
                    </ul>
                <%
                }
                     %>
             </li>
        <%
            }
             %>   
      </ul>
	<br style="clear: left" />
</div>
    <!-- 橙线 -->
    <div id="hr"></div>
    <!--nav结束-->
 

<script type="text/javascript" src="js/jquery.min.js"></script>
<script type="text/javascript" src="js/ddsmoothmenu.js"></script>

<script type="text/javascript">
    ddsmoothmenu.init({
        mainmenuid: "smoothmenu1", //menu DIV id
        orientation: 'h', //Horizontal or vertical menu: Set to "h" or "v"
        classname: 'ddsmoothmenu', //class added to menu's outer DIV
        //customtheme: ["#1c5a80", "#18374a"],
        contentsource: "markup" //"markup" or ["container_id", "path_to_menu_file"]
    })
</script>

    <div class="titlesDiv">
	    <div id="titles" class="titles"></div>
        <div style="clear:both;"></div>
    </div>
    <div id="contentDivs"></div>
</body>
</html>
