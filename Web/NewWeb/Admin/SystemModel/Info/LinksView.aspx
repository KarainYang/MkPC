<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LinksView.aspx.cs" Inherits="Admin_SystemModel_Info_LinksView" %>

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
                    标题：
                </th>
                <td>
                    <asp:TextBox ID="TbTitle" runat="server" Width="300px" CssClass="inputCss"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFV1" runat="server" ErrorMessage="请输入标题！" ControlToValidate="TbTitle"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th>
                    图片：
                </th>
                <td>
                    <yk:FileUpload runat="server" ID="ImgUrl" DirectoryUrl="Userfiles/Links/" />
                </td>
            </tr>
            <tr>
                <th>
                    连接地址：
                </th>
                <td>
                    <asp:TextBox ID="TbLinkUrl" runat="server" Width="300px" CssClass="inputCss"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入连接地址！"
                        ControlToValidate="TbLinkUrl"></asp:RequiredFieldValidator>
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
    </div>
    <div class="SubmitClass">
        <asp:Button ID="BtnSave" runat="server" Text=" 保存 " CssClass="buttonCss" OnClick="BtnSave_Click" />
    </div>
    <div runat="Server" id="MessageDiv">
    </div>
    </form>
</body>
</html>
