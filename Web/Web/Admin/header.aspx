<%@ Page Language="C#" AutoEventWireup="true" CodeFile="header.aspx.cs" Inherits="Admin_header2" %>
<%@ Import Namespace="YK.Model" %>
<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="css/admin.css" type="text/css" rel="stylesheet"/>
    <script src="js/jquery.js" type="text/javascript"></script>
    <style>
        .tbCss a{ color:White;}
        .navigation a{ font-size:13px;}

        .menuDiv{ float:left; height:30px; line-height:30px; width:80px; font-weight:bold; }
        .current{ float:left;height:30px; line-height:30px;width:80px; font-weight:bold;border-bottom:2px solid red; }
    </style>
    <script language="javascript" type="text/javascript">
        function changeMenu(obj) {
            $(".navigation div").attr("class", "menuDiv");
            obj.className = "current";
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
     <table cellspacing="0" cellpadding="0" width="100%" background="images/header_bg.jpg" border="0" class="tbCss">
	  <tr height="18">
            <td rowspan="2" width="260"><img height="56" src="images/header_left.jpg" width="260" alt=""/></td>
            <td align="right">
                <a href="main.aspx" target="main">返回首页</a>&nbsp;&nbsp;
                <a href="SystemModel/Admin/UpdatePwd.aspx" target="main">修改密码</a> &nbsp;&nbsp;
                <a href="LoginOut.aspx" target="_top" >退出</a> &nbsp;&nbsp;
            </td>
      </tr>
      <tr height="38">
		<td align="center" class="navigation" valign="top">  
            <%
                    foreach (TB_Admin_Resources resource in resources)
                    {
                            %>
            <div class="menuDiv" onclick="changeMenu(this)">
                <a href="menu.aspx?rid=<%= resource.ID %>" target="menu"><%= resource.ResourceName %></a>
            </div>
                        
            <% 
                    }
            %>					 
		</td>
	  </tr>
	</table>
    </form>
</body>
</html>
