<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GroupView.aspx.cs" Inherits="Admin_SystemModel_Product_GroupView" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Import Namespace="YK.Common" %>
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
    <%--基本设置--%>
    <table class="fromTable">
        <tr>
            <th>
                团购名称：
            </th>
            <td>
                <yk:TextBox ID="TbName" runat="server"  Width="300px" GroupName="Validator" CssClass="inputCss"
                    title="商品名称" LabelID="LbName"></yk:TextBox>
                <span id="LbName">*</span>
            </td>
        </tr>
        <tr>
            <th>
                售价：
            </th>
            <td>
                <yk:TextBox ID="TbPrice" runat="server" GroupName="Validator" CssClass="inputCss"
                    title="售价" LabelID="LbPrice" Validator="小数"></yk:TextBox>
                <span id="LbPrice">*</span>
            </td>
        </tr>
        <tr>
            <th>
                团购价：
            </th>
            <td>
                <yk:TextBox ID="TbGroupPrice" runat="server" GroupName="Validator"
                    CssClass="inputCss" title="团购价" LabelID="LbGroupPrice" Validator="小数"></yk:TextBox>
                <span id="LbGroupPrice">*</span>
            </td>
        </tr>
        <tr>
            <th>
                小图片：
            </th>
            <td>
                <yk:FileUpload runat="server" ID="ProImg" DirectoryUrl="Userfiles/Products/" />
            </td>
        </tr>
        <tr>
            <th>
                开始时间：
            </th>
            <td>
                <yk:TextBox ID="TbStartDate" runat="server" CssClass="inputCss" onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                    GroupName="Validator" title="开始时间" LabelID="LbStartDate"></yk:TextBox>
                <span id="LbStartDate">*</span>
            </td>
        </tr>
        <tr>
            <th>
                结束时间：
            </th>
            <td>
                <yk:TextBox ID="TbStopDate" runat="server" CssClass="inputCss" onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                    GroupName="Validator" title="结束时间" LabelID="LbStopDate"></yk:TextBox>
                <span id="LbStopDate">*</span>
            </td>
        </tr>
        <tr>
            <th>
                团购描述：
            </th>
            <td>
                <yk:FCKeditor ID="FckDes" runat="server" Height="300px">
                </yk:FCKeditor>
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
        <tr>
            <th>
                是否推荐：
            </th>
            <td>
                <asp:DropDownList ID="DDLVouchType" runat="server">
                    <asp:ListItem Text="不推荐" Value="0"></asp:ListItem>
                    <asp:ListItem Text="推荐" Value="1"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <th>
                是否隐藏：
            </th>
            <td>
                <asp:CheckBox ID="CheckBoxIsHidden" runat="server" />
            </td>
        </tr>
        <tr>
            <th>
                日期：
            </th>
            <td>
                <yk:TextBox ID="TbDate" runat="server" CssClass="inputCss" onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                    GroupName="Validator" title="日期" LabelID="LbDate"></yk:TextBox>
                <span id="LbDate">*</span>
            </td>
        </tr>
    </table>
    <div class="SubmitClass">
        <asp:Button ID="BtnSave" runat="server" Text=" 保存 " CssClass="buttonCss" OnClick="BtnSave_Click"
            OnClientClick="return VerificationForm('Validator')" />
        <input type="button" value=" 清空 " class="buttonCss" onclick="window.location='?';" />
    </div>
    <div runat="Server" id="MessageDiv">
    </div>
    </form>
</body>
</html>
