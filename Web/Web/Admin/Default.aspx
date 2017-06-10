<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>管理中心 </title>
   <%-- <script language="javascript" type="Text/javascript">
        window.open("Welcome.aspx","","width=800,height=300,menu=0");
    </script>--%>
</head>
<FRAMESET border=0 frameSpacing=0 rows="56, *" frameBorder=0>
	<FRAME name=header src="header.aspx" frameBorder=0 noResize scrolling=no>
	<FRAMESET cols="170, *">
		<FRAME name=menu src="menu.aspx" frameBorder=0 noResize>
		<FRAME name=main src="main.aspx" frameBorder=0 noResize scrolling=yes>
	</FRAMESET>
</FRAMESET>
<noframes>
</noframes>
</html>