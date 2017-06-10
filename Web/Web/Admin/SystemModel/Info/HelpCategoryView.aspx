﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HelpCategoryView.aspx.cs"
    Inherits="Admin_SystemModel_Info_HelpCategoryView" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <yk:AdminHeader ID="AdminHeader1" runat="server"></yk:AdminHeader>

    <script language="javascript" type="text/javascript">
        var DG = frameElement.lhgDG;
        DG.addBtn('ok', '确定', ok);
        function ok() {
            $("#<%= BtnSave.ClientID %>").click();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <table class="fromTable">
        <tr>
            <th>
                名称：
            </th>
            <td>
                <asp:TextBox ID="TbName" runat="server" CssClass="inputCss"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFV1" runat="server" ErrorMessage="请输入名称！" ControlToValidate="TbName"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th>
                排序：
            </th>
            <td>
                <asp:TextBox ID="TbOrderBy" runat="server" CssClass="inputCss"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div class="SubmitClass">
        <asp:Button ID="BtnSave" runat="server" Text=" 保存 " CssClass="buttonCss" OnClick="BtnSave_Click" />
    </div>
    <div runat="Server" id="MessageDiv">
    </div>
    </form>
</body>
</html>