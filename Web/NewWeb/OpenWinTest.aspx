<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OpenWinTest.aspx.cs" Inherits="OpenWinTest" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="YK.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <yk:AdminHeader ID="AdminHeader1" runat="server"></yk:AdminHeader>
    <link href="Admin/css/Yk.Core.css" rel="stylesheet" />
    <script src="Admin/js/yk.core.layer.js"></script>
</head>
<body>
    <iframe src="OpenWinMain.aspx" name="frame_tab0" frameborder="0" width="100%" height="600px"></iframe>
</body>
</html>
