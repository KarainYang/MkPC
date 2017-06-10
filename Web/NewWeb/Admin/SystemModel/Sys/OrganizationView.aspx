<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrganizationView.aspx.cs" Inherits="Admin_AdminModel_Organization_OrganizationView" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <yk:AdminHeader ID="AdminHeader1" runat="server"></yk:AdminHeader>
</head>
<body>
    <form id="form1" runat="server">
        <div class="BodyDiv"> 
         <table class="fromTable" width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>          
                        <th>租户名称：</th>
                        <td>
                            <yk:TextBox ID="TbName" runat="server"  Width="200px" GroupName="Validator" CssClass="inputCss"
                            title="租户名称" LabelID="LbName"></yk:TextBox>
                            <span id="LbName">*</span> 
                        </td>
                   </tr> 
                <tr>          
                        <th>租户编码：</th>
                        <td>
                            <yk:TextBox ID="TbCode" runat="server"  Width="200px" GroupName="Validator" CssClass="inputCss"
                            title="租户编码" LabelID="LbCode"></yk:TextBox>
                            <span id="LbCode">*</span> 
                        </td>
                   </tr> 
                <tr>          
                        <th>链接字符串：</th>
                        <td>
                            <yk:TextBox ID="TbConnStr" runat="server"  Width="300px" GroupName="Validator" CssClass="inputCss"
                            title="链接字符串" LabelID="LbConnStr"></yk:TextBox>
                            <span id="LbConnStr">*</span> 
                        </td>
                   </tr>    
                <tr>   
                     <th>状态：</th>
                     <td>
                         <asp:CheckBox ID="CheckBoxState" runat="server" Text="冻结" />                                     
                    </td>
                 </tr>  
            </table>   
            </div> 
            <div class="SubmitClass">           
                <asp:Button ID="BtnSave" runat="server" Text=" 保存 " CssClass="buttonCss"  OnClick="BtnSave_Click"  OnClientClick="return yk.core.validator.VerificationForm('Validator')"/>
                <input type="button" value=" 取消 " class="buttonCss" id="cancleCss" onclick="closeLayer()"  />
            </div>
            <div runat="Server" id="MessageDiv">            
            </div> 
    </form>
</body>
</html>