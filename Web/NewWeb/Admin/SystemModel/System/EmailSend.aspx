<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmailSend.aspx.cs" Inherits="Admin_WebSet_EmailSend" %>
<%@ Import Namespace="YK.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <yk:AdminHeader runat="server" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="navigation">
           网站信息设置
        </div>
         <table class="fromTable" width="100%" border="0" cellpadding="0" cellspacing="0" style="line-height:30px;">
               <tr>
                    <th>
                        邮件主题：
                    </th>
                    <td>
                        <asp:TextBox ID="TbTitle" runat="server" Width="300px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入邮件主题" ControlToValidate="TbTitle"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <th>
                        邮件接收者Email：
                    </th>
                    <td>
                        <asp:TextBox ID="TbEmailAddress" runat="server" Width="600px" TextMode="MultiLine" Rows="3"></asp:TextBox> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="请输入邮件接收者Email" ControlToValidate="TbEmailAddress"></asp:RequiredFieldValidator>
                        <span style="color:Red;">一次填写多个Email地址请用分号（;）分隔</span>
                    </td>
                </tr>                
                <tr>
                    <th>
                        邮件内容：
                    </th>
                    <td>
                        <yk:FCKeditor ID="FckContent" runat="server" Width="100%" Height="400px"></yk:FCKeditor>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="请输入邮件内容" ControlToValidate="FckContent"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="Button1" runat="server"  CssClass="buttonCss" Text="  发送  " OnClick="BtnSave_Click"/>       
                    </td>
                </tr>
            </table> 
            <div runat="Server" id="MessageDiv"></div> 
    </form>
</body>
</html>