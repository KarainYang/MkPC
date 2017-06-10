<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmailSet.aspx.cs" Inherits="Admin_WebSet_EmailSet" %>
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
                    <th>开关：</th>
                    <td>
                        <asp:RadioButtonList ID="RadioBtnOpenOrClose" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="开启" Value="0"></asp:ListItem>
                            <asp:ListItem Text="关闭" Value="1"></asp:ListItem>
                        </asp:RadioButtonList>                      
                    </td>
               </tr>
                <tr>
                   <th>邮箱账号：</th>
                   <td><asp:TextBox ID="TbEmialName" runat="server" Width="300px"></asp:TextBox></td>
               </tr>
               <tr>
                   <th>邮箱密码：</th>
                   <td>
                        <asp:TextBox ID="TbEmailPwd" runat="server"></asp:TextBox>
                   </td>
               </tr>              
               <tr>
                    <th>SMTP地址：</th>
                    <td><asp:TextBox ID="TbSMTPAddress" runat="server" Width="300px"></asp:TextBox></td>
               </tr>
               <tr>
                     <th>端口号：</th>
                    <td><asp:TextBox ID="TbPort" runat="server"></asp:TextBox></td>                     
               </tr>              
                <tr>
                     <td></td>
                    <td align="left">
                         <asp:Button ID="BtnSave" runat="server"  CssClass="buttonCss" Text="  保 存  " OnClick="BtnSave_Click"/>                    
                    </td>
                </tr>
            </table>    
            <div runat="Server" id="MessageDiv"></div> 
    </form>
</body>
</html>