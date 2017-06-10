<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OpenWinMain.aspx.cs" Inherits="OpenWinMain" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="YK.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <yk:AdminHeader ID="AdminHeader1" runat="server"></yk:AdminHeader>
	<script language="javascript" type="text/javascript">
        //添加
        function openWindows() {
            yk.win.openWin({
                title: "标题",
                url: "OpenWin.aspx",
                width: 600,
                height: 500,
                onClose: function () {
                    alert('关闭窗口');
                }
            });
        }
	</script>
</head>
<body>
    <input type="button" value="打开窗口" onclick="openWindows()" />
</body>
</html>
