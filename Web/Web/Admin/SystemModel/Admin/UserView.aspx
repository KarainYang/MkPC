<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserView.aspx.cs" Inherits="Admin_AdminModel_User_UserView" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
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
         <table class="fromTable" width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>          
                    <th>用户名：</th>
                    <td>
                        <asp:TextBox ID="TbUserName" runat="server" CssClass="inputCss"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFV1" runat="server" ErrorMessage="请输入用户名！" ControlToValidate="TbUserName"></asp:RequiredFieldValidator>
                    </td>
               </tr>
               <tr>          
                    <th>密码：</th>
                    <td>
                        <asp:TextBox ID="TbUserPwd" runat="server" TextMode="Password" CssClass="inputCss"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFV2" runat="server" ErrorMessage="请输入密码！" ControlToValidate="TbUserPwd"></asp:RequiredFieldValidator>
                    </td>
               </tr>
               <tr>
                     <th>确认密码：</th>
                    <td>
                        <asp:TextBox ID="TbConfirmPwd" runat="server" MaxLength="60" CssClass="inputCss" TextMode="Password"></asp:TextBox>                        
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="两次密码不一致" ControlToValidate="TbUserPwd" ControlToCompare="TbConfirmPwd"></asp:CompareValidator>
                    </td>
               </tr>               
                <tr>   
                     <th>状态：</th>
                     <td>
                         <asp:CheckBox ID="CheckBoxState" runat="server" Text="冻结" />                                     
                    </td>
                 </tr>  
            </table>    
            <div class="SubmitClass">           
                <asp:Button ID="BtnSave" runat="server" Text=" 保存 " CssClass="buttonCss"  OnClick="BtnSave_Click"/>
                         <input type="button" value=" 取消 " class="buttonCss" onclick="closeLayer()"  />
            </div>
            <div runat="Server" id="MessageDiv">            
            </div> 
    </form>
</body>
</html>