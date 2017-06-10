<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VisionSubjectView.aspx.cs" Inherits="Admin_SystemModel_Exam_VisionSubjectView" %>

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
                类型：
            </th>
            <td>
                <yk:DropDownList runat="server" ID="DDLModule"></yk:DropDownList>
            </td>
        </tr>
        <tr>          
            <th>名称：</th>
            <td>
                <asp:TextBox ID="TbName" runat="server" Width="300px" GroupName="Validator"   CssClass="inputCss"
                            title="结果" LabelID="LbName"></asp:TextBox>
                <span id="LbName">*</span>    
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
            <th>结果：</th>
            <td>
                <yk:TextBox ID="TbResult" runat="server" Width="300px" MaxLength="60" GroupName="Validator"   CssClass="inputCss"
                            title="结果" LabelID="LbResult"></yk:TextBox>   
                            <span id="LbResult">*</span>    
            </td>
        </tr>
        <tr>
            <th>排序：</th>
            <td>
                <asp:TextBox ID="TbOrderBy" runat="server" MaxLength="60" CssClass="inputCss"></asp:TextBox>                        
            </td>
        </tr>
        <tr>
            <th>描述：</th>
            <td>
                <yk:FCKeditor ID="FckDesc" runat="server" Height="300px" ToolbarSet="Basic" >
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
