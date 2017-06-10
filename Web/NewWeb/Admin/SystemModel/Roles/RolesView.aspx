<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RolesView.aspx.cs" Inherits="Admin_AdminModel_Roles_RolesView" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">
<%@ Import Namespace="YK.Common" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <yk:AdminHeader ID="AdminHeader1" runat="server"></yk:AdminHeader>
</head>
<body>
    <form id="form1" runat="server">
    <div class="BodyDiv"> 
    <table class="fromTable">
        <tr>
            <th>
                角色名称：
            </th>
            <td>
                <asp:TextBox ID="TbRoleName" runat="server" Width="180px" CssClass="inputCss"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFV1" runat="server" ErrorMessage="请输入角色名称！" ControlToValidate="TbRoleName"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    </div>
    <div class="SubmitClass">
        <asp:Button ID="BtnSave" runat="server" Text=" 保存 " CssClass="buttonCss" OnClick="BtnSave_Click" />
        <input type="button" value=" 取消 " class="buttonCss" id="cancleCss" onclick="closeLayer()"  />
    </div>
    <div runat="Server" id="MessageDiv">
    </div>
    </form>
</body>
</html>
