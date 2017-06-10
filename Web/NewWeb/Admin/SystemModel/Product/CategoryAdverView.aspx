<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CategoryAdverView.aspx.cs" Inherits="Admin_AdminModel_Product_CategoryAdverView" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <yk:AdminHeader ID="AdminHeader1" runat="server"></yk:AdminHeader>
</head>
<body>
    <form id="form1" runat="server">
         <table class="fromTable" >
               <tr>          
                    <th>广告类型：</th>
                    <td>
                        <asp:DropDownList ID="DDLAdverType" runat="server">
                            <asp:ListItem Text="单图片" Value="0"></asp:ListItem>
                            <asp:ListItem Text="图片切换【图片点击】" Value="1"></asp:ListItem>
                            <asp:ListItem Text="图片切换【数字点击】" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
               </tr>
               <tr>          
                    <th>宽度：</th>
                    <td>
                        <asp:TextBox ID="TbWidth" runat="server" Width="300px" CssClass="inputCss"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="请输入宽度！" ControlToValidate="TbWidth"></asp:RequiredFieldValidator>
                    </td>
               </tr>
               <tr>          
                    <th>高度：</th>
                    <td>
                        <asp:TextBox ID="TbHeight" runat="server" Width="300px" CssClass="inputCss"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="请输入高度！" ControlToValidate="TbHeight"></asp:RequiredFieldValidator>
                    </td>
               </tr>              
            </table>    
            <div class="SubmitClass">
           
                <asp:Button ID="BtnSave" runat="server" Text=" 保存 " CssClass="buttonCss"  OnClick="BtnSave_Click"/>
                         <input type="button" value=" 取消 " class="buttonCss" id="cancleCss" onclick="closeLayer()"  />
            </div>
            <div runat="Server" id="MessageDiv">            
            </div> 
    </form>
</body>
</html>