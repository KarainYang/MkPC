<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Assembly.aspx.cs" Inherits="AssemblyPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <asp:GridView ID="GridView2" runat="server">
        </asp:GridView>
        用户名：<asp:TextBox ID="TbUserName" runat="server"></asp:TextBox>
        密码：<asp:TextBox ID="TbPwd" runat="server"></asp:TextBox>
        <asp:Button ID="BtnSubmit" runat="server" Text="提交" onclick="BtnSubmit_Click" />
        <asp:Button ID="BtnUpdate" runat="server" Text="修改" onclick="BtnUpdate_Click" />
    </div>
    </form>
</body>
</html>
