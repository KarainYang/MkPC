<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PictureView.aspx.cs" Inherits="Admin_SystemModel_Product_PictureView" %>

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
    <table class="fromTable">
        <tr>
            <th>
                名称：
            </th>
            <td>
                <yk:TextBox ID="TbName" runat="server" GroupName="Validator"
                    CssClass="inputCss" title="名称" LabelID="LbName"></yk:TextBox>
                <span id="LbName">*</span>
            </td>
        </tr>
        <tr>
            <th>
                图片：
            </th>
            <td>
                <yk:FileUpload runat="server" ID="Picture"  DirectoryUrl="Userfiles/Products/ProPicture/"  IsWaterMark="true"/>
            </td>
        </tr>
        <tr>
            <th>
                排序：
            </th>
            <td>
                <yk:TextBox ID="TbOrderBy" runat="server" MaxLength="60" GroupName="Validator"
                    CssClass="inputCss" title="排序" Validator="整数" LabelID="LbOrderBy"></yk:TextBox>
                <span id="LbOrderBy">*</span>
            </td>
        </tr>        
        <tr>
            <th>
                日期：
            </th>
            <td>
                <yk:TextBox ID="TbDate" runat="server" Width="150" MaxLength="60" CssClass="inputCss"
                    onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" GroupName="Validator"
                    title="日期" LabelID="LbDate"></yk:TextBox>
                <span id="LbDate">*</span>
            </td>
        </tr>
    </table>
    <div class="SubmitClass">
        <asp:Button ID="BtnSave" runat="server" Text=" 保存 " CssClass="buttonCss" OnClick="BtnSave_Click"
            OnClientClick="return VerificationForm('Validator')" />
        <input type="button" value=" 取消 " class="buttonCss" onclick="closeLayer()" />
    </div>
    <div runat="Server" id="MessageDiv">
    </div>
    </form>
</body>
</html>
