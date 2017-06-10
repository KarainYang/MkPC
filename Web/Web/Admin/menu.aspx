<%@ Page Language="C#" AutoEventWireup="true" CodeFile="menu.aspx.cs" Inherits="Admin_menu2" %>

<%@ Import Namespace="YK.Model" %>
<%@ Import Namespace="YK.Common" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="css/admin.css" type="text/css" rel="stylesheet" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <style>
        .menuDiv{ font-weight:bold; text-align:left; height:40px; line-height:40px; padding-left:8px; font-size:13px; }
        .current{ font-weight:bold; text-align:left; height:40px; line-height:40px; padding-left:8px; font-size:13px;  background-color:#D1E6F7; }
        img{ margin-top:16px;}
    </style>
    <script language="javascript" type="text/javascript">
        function changeMenu(obj) {
            $("div").attr("class", "menuDiv");
            obj.className = "current";
        }
    </script>
</head>
<body>
        <table height="100%" cellspacing="0" cellpadding="0" width="170" background="images/menu_bg.jpg"
            border="0">
            <tr>
                <td valign="top" align="center">	
                    <br />	                  
                    <%
                        int rid = Request.QueryString["rid"].ToInt();
                        if (rid > 0)
                        {


                            foreach (TB_Admin_Resources resource in resources)
                            {
                                if (rid == resource.ID)
                                {
                                    foreach (TB_Admin_Resources child in resource.ChildTree)
                                    {
                    %>
                        <div class="menuDiv" onclick="changeMenu(this)">
                            <img src="images/menu_icon.gif" />
                            <a class="menuChild" href="<%=child.Url %>" target="main"><%=child.ResourceName%></a>
                        </div>
                    <%
                                    }
                                }
                            }
                        }
                        else
                        {
                         %>
                            <div class="menuDiv" onclick="changeMenu(this)">
                                <img src="images/menu_icon.gif" />
                                <a href="main.aspx" target="main">首页</a> &nbsp;&nbsp;
                            </div>
                            <div class="menuDiv" onclick="changeMenu(this)">
                                <img src="images/menu_icon.gif" />
                                <a href="SystemModel/Admin/UpdatePwd.aspx" target="main">修改密码</a> &nbsp;&nbsp;
                            </div>
                            <div class="menuDiv" onclick="changeMenu(this)">
                                <img src="images/menu_icon.gif" />
                                <a href="LoginOut.aspx" target="_top" >退出</a> &nbsp;&nbsp;
                            </div>
                         <%
                        }
                              %>
                </td>
                <td width="1" bgcolor="#d1e6f7">
                </td>
            </tr>
        </table>
        <script language="javascript" type="text/javascript">
            $(".menuDiv a").each(function (index) {
                if (index == 0) {
                    this.click();
                }
            });
        </script>
</body>
</html>
