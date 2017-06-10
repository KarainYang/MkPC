<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HelpView.aspx.cs" Inherits="Admin_SystemModel_Info_HelpView" %>

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
                类别：
            </th>
            <td>
                <yk:DropDownList runat="server" ID="DDLCategory">
                </yk:DropDownList>
                <asp:RequiredFieldValidator ID="RFVCategory" runat="server" ErrorMessage="请输入选择类别！"
                    ControlToValidate="DDLCategory"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th>
                标题：
            </th>
            <td>
                <asp:TextBox ID="TbName" runat="server" Width="300px" CssClass="inputCss"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFV1" runat="server" ErrorMessage="请输入标题！" ControlToValidate="TbName"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th>
                备注：
            </th>
            <td>
                <yk:FCKeditor runat="server" ID="FckRemark" Height="360px" Width="100%">
                </yk:FCKeditor>
            </td>
        </tr>
        <tr>
            <th>
                是否隐藏：
            </th>
            <td>
                <asp:CheckBox ID="CheckBoxIsHidden" runat="server" Text="隐藏" />
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
