<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrincipleView.aspx.cs" Inherits="Admin_SystemModel_Exam_PrincipleView" %>

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
                模块：
            </th>
            <td>
                <yk:DropDownList runat="server" ID="DDLModule"></yk:DropDownList>
            </td>
        </tr>
        <tr>
            <th>
                图片：
            </th>
            <td>
                <yk:FileUpload runat="server" ID="Picture"  DirectoryUrl="Userfiles/Examination/Principle/"  IsWaterMark="true"/>
            </td>
        </tr>
        <tr>
            <th>描述：</th>
            <td>
                <yk:FCKeditor ID="FckDesc" runat="server" Height="300px" ToolbarSet="Basic">
                </yk:FCKeditor>    
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
