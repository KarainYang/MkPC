<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdatePwd.aspx.cs" Inherits="Admin_AdminModel_User_UpdatePwd" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <yk:AdminHeader ID="AdminHeader1" runat="server"></yk:AdminHeader> 
</head>
<body>
    <form id="form1" runat="server">
        <div  class="navigation">               
               <a href="UserList.aspx">管理员</a> > 修改密码
            </div>
         <table class="fromTable" width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>          
                    <td>当前密码：</td>
                    <td>
                        <asp:TextBox ID="TbOldPwd" runat="server" TextMode="Password" Width="300px" CssClass="inputCss"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入当前密码！" ControlToValidate="TbOldPwd"></asp:RequiredFieldValidator>
                    </td>
               </tr>
               <tr>          
                    <td>新密码：</td>
                    <td>
                        <asp:TextBox ID="TbUserPwd" runat="server" TextMode="Password" Width="300px" CssClass="inputCss"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFV2" runat="server" ErrorMessage="请输入新密码！" ControlToValidate="TbUserPwd"></asp:RequiredFieldValidator>
                    </td>
               </tr>
               <tr>
                     <td>确认密码：</td>
                    <td>
                        <asp:TextBox ID="TbConfirmPwd" runat="server" Width="300px" MaxLength="60" CssClass="inputCss" TextMode="Password"></asp:TextBox>                        
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="两次密码不一致" ControlToValidate="TbUserPwd" ControlToCompare="TbConfirmPwd"></asp:CompareValidator>
                    </td>
               </tr>               
                <tr>
                    <td></td>
                    <td align="left">
                         <asp:Button ID="BtnSave" runat="server" Text=" 保存 " CssClass="buttonCss"  OnClick="BtnSave_Click"/>
                    </td>
                </tr>
            </table>    
            <div runat="Server" id="MessageDiv">            
            </div> 
    </form>
</body>
</html>