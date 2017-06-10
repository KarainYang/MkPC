<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GenerateHtml.aspx.cs" Inherits="GenerateHtml" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             源路径：<asp:TextBox ID="TbSourcePath" runat="server"></asp:TextBox>
             生成文件路径：<asp:TextBox ID="TbGeneratePath" runat="server"></asp:TextBox>
            <asp:Button ID="BtnGenerate" runat="server" Text="生成html文件" 
                 onclick="BtnGenerate_Click" />
            <br />
            <asp:Button ID="BtnConfigGenerate" runat="server" Text="按配置文件生成html文件" 
                 onclick="BtnConfigGenerate_Click" />
            <asp:Button ID="BtnProDetailsGenerate" runat="server" Text="生成产品详细html文件" 
                 onclick="BtnProDetailsGenerate_Click" />
        </div>
    </form>
</body>
</html>
