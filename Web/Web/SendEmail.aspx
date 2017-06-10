<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SendEmail.aspx.cs" Inherits="SendEmail" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>邮件类型：</td>
                    <td>
                        <asp:DropDownList ID="DDLType" runat="server">
                            <asp:ListItem Text="126邮箱" Value="smtp.126.com"></asp:ListItem>
                            <asp:ListItem Text="163邮箱" Value="smtp.163.com"></asp:ListItem>
                            <asp:ListItem Text="qq邮箱" Value="smtp.qq.com"></asp:ListItem>
                            <asp:ListItem Text="新浪邮箱" Value="smtp.sina.com"></asp:ListItem>
                            <asp:ListItem Text="188邮箱" Value="smtp.188.com"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>账号：</td>
                    <td>
                        <asp:TextBox ID="TbUserName" runat="server"></asp:TextBox>
                    </td>
                </tr>  
                <tr>
                    <td>密码：</td>
                    <td>
                        <asp:TextBox ID="TbPwd" runat="server"></asp:TextBox>
                    </td>
                </tr> 
                <tr>
                    <td>主题：</td>
                    <td>
                        <asp:TextBox ID="TbTitle" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>   
                <tr>
                    <td>邮件地址：</td>
                    <td>
                        <asp:TextBox ID="TbAddress" runat="server" Width="500px"></asp:TextBox>
                    </td>
                </tr>                
                <tr>
                    <td>邮件内容：</td>
                    <td>
                       <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" ToolbarSet="Basic" Width="500px">
                        </FCKeditorV2:FCKeditor>
                    </td>
                </tr>
                <tr>
                    <td><asp:Button ID="BtnSend" runat="server" Text="发送" onclick="BtnSend_Click" /></td>
                </tr>
            </table>
            
        </div>
    </form>
</body>
</html>
