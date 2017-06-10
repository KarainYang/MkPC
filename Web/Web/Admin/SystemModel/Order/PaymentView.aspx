<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentView.aspx.cs" Inherits="Admin_SystemModel_Order_PaymentView" %>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <yk:AdminHeader ID="AdminHeader1" runat="server"></yk:AdminHeader> 
</head>
<body>
    <form id="form1" runat="server">
         <table class="fromTable" > 
                <tr>          
                    <th>名称：</th>
                    <td>
                        <yk:TextBox ID="TbName" runat="server" Width="300px" ToolTip="名称" CssClass="inputCss" LabelID="spName" GroupName="Validator"></yk:TextBox>
                        <span id="spName"></span>
                    </td>
               </tr>             
               <tr>          
                    <th>排序：</th>
                    <td>
                        <yk:TextBox ID="TbOrderBy" runat="server" Width="100px" ToolTip="排序" CssClass="inputCss" LabelID="spName" GroupName="Validator" Validator="整数"></yk:TextBox>
                        <span id="spOrderBy"></span>
                    </td>
               </tr>             
                 <tr>
                        <th>描述</th>                     
                        <td>
                             <yk:TextBox ID="TbDesc" runat="server" Width="90%" TextMode="MultiLine" Rows="6" MaxLength="100" CssClass="inputCss"></yk:TextBox>                         
                        </td>
                 </tr>
            </table>   
            <div class="SubmitClass">
                <asp:Button ID="BtnSave" runat="server" Text=" 保存 " CssClass="buttonCss"  OnClick="BtnSave_Click" OnClientClick="return VerificationForm('Validator')"/>
                         <input type="button" value=" 取消 " class="buttonCss" onclick="closeLayer()"  />
            </div> 
            <div runat="Server" id="MessageDiv">            
            </div> 
    </form>
</body>
</html>
