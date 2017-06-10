<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewsView.aspx.cs" Inherits="Admin_SystemModel_Info_NewsView" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">
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
                    类别：
                </th>
                <td>
                    <yk:DropDownList runat="server" ID="DDLCategory">
                    </yk:DropDownList>
                    <asp:RequiredFieldValidator ID="RFVCategory" runat="server" ErrorMessage="请输入选择类别！" ControlToValidate="DDLCategory"></asp:RequiredFieldValidator>
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
            <tr style=" display:none;">
                <th>
                    描述：
                </th>
                <td>
                    <asp:TextBox ID="TbDescription" runat="server" TextMode="MultiLine" Rows="3" Width="100%" CssClass="inputCss"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    备注：
                </th>
                <td>
                    <yk:FCKeditor runat="server" ID="FckRemark" Height="300px" Width="100%">
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
            <tr>
                <th>
                    是否推荐：
                </th>
                <td>
                    <asp:CheckBox ID="CheckBoxIsVouch" runat="server" Text="推荐" />
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
