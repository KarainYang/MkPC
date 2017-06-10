<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserInRole.aspx.cs" Inherits="Admin_AdminModel_User_UserInRole" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">
<%@ Import Namespace="YK.Common" %>
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
                    <th>角色列表：
                    </th>
                    <td>
                        <style>
                            #CheckBoxRolesList td{ border:0px;}
                        </style>
                        <asp:CheckBoxList ID="CheckBoxRolesList" runat="server">
                        </asp:CheckBoxList>
                     </td>
                   </tr>
            </table>    
            <div class="SubmitClass">          
                <asp:Button ID="BtnSave" runat="server" Text=" 保存 " CssClass="buttonCss"  OnClick="BtnSave_Click"/>
            </div>
            <div runat="Server" id="MessageDiv">            
            </div> 
    </form>
</body>
</html>