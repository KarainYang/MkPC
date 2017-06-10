<%@ Page Language="C#" AutoEventWireup="true" CodeFile="header2.aspx.cs" Inherits="Admin_header" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="css/admin.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table cellspacing="0" cellpadding="0" width="100%" background="images/header_bg.jpg" border="0">
	  <tr height="56">
		<td width="260"><img height="56" src="images/header_left.jpg" width="260" alt=""/></td>
		<td style="FONT-WEIGHT: bold; COLOR: #fff; PADDING-TOP:10px" align="center">      
			<a style="COLOR: #f00" href="main.aspx" target="main">返回首页</a>
			&nbsp;&nbsp;
            <asp:DropDownList ID="DDLLangs" runat="server" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="DDLLangs_SelectedIndexChanged">
            </asp:DropDownList>  
			&nbsp;&nbsp; 
			 当前用户：<asp:Label ID="LblName" runat="server" Text=""></asp:Label>
			&nbsp;&nbsp; 
			<a style="COLOR: #fff" href="SystemModel/Admin/UpdatePwd.aspx" target="main">修改密码</a> &nbsp;&nbsp;
			<a href="LoginOut.aspx" target="_top" style="COLOR: #fff" >注销当前用户</a> &nbsp;&nbsp;
			<a href="../index.html" style="color:White;" target="_blank">浏览前台</a>
			当前时间：<span id="time"></span>
			<script language="javascript" type="text/javascript">
			    function getTime()
			    {
			         var gettime=new Date();
			        document.getElementById("time").innerText=gettime.getFullYear()+"年"+(gettime.getMonth()+1)+"月"+gettime.getDate()+"日 "+gettime.getHours()+":"+gettime.getMinutes()+":"+gettime.getSeconds();
                    setTimeout("getTime()",1000);
			    }
			    getTime();
			 </script>			 
		</td>
		<td align="right" width="268">&nbsp;</td>
	  </tr>
	</table>
	<table cellspacing="0" cellpadding="0" width="100%" border="0">
	  <tr bgColor="#1c5db6" height="4">
		<td></td>
	  </tr>
    </table>
    </div>
    </form>
</body>
</html>
