<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReplyView.aspx.cs" Inherits="Admin_SystemModel_Product_ReplyView" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Import Namespace="YK.Common" %>
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
                回复内容：
            </th>
            <td>
                <yk:TextBox ID="TbContent" runat="server" GroupName="Validator" TextMode="MultiLine" Rows="6" Width="260px"
                    CssClass="inputCss" title="回复内容" LabelID="LbName"></yk:TextBox>
                <span id="LbName">*</span>
            </td>
        </tr>        
    </table>
    </div>
    <div class="SubmitClass">
        <asp:Button ID="BtnSave" runat="server" Text=" 保存 " CssClass="buttonCss" OnClick="BtnSave_Click"
            OnClientClick="return yk.core.validator.VerificationForm('Validator')" />
        <input type="button" value=" 取消 " class="buttonCss" id="cancleCss" onclick="closeLayer()"  />
    </div>
    <div runat="Server" id="MessageDiv">
    </div>
    </form>
</body>
</html>
