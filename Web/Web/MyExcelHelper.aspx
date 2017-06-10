<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyExcelHelper.aspx.cs" Inherits="MyExcelHelper" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="Button1" runat="server" Text=" 上传 " onclick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="导出日志" onclick="Button2_Click" />
    </div>
    </form>
</body>
</html>
