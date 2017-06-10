<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RelaceMark.aspx.cs" Inherits="RelaceMark" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      网址：<asp:TextBox ID="txtUrl" runat="server"></asp:TextBox>
        <asp:Button ID="btnGet" runat="server" Text="获取数据" OnClick="btnGet_Click" />
    </div>
    <div id="ShowInfo" runat="server"></div>
    </form>
</body>
</html>
