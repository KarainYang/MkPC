<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditFile.aspx.cs" Inherits="EditFile" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        地址：<asp:TextBox ID="TbAddress" runat="server" Width="60%"></asp:TextBox>
        <asp:Button ID="BtnGet" runat="server" Text="获取文本" onclick="BtnGet_Click" />
        <asp:TextBox ID="TbTxt" runat="server" TextMode="MultiLine" Width="100%" Height="500px"></asp:TextBox>
        <asp:Button ID="BtnSave" runat="server" Text="保存" onclick="BtnSave_Click" />
    </div>
    </form>
</body>
</html>
