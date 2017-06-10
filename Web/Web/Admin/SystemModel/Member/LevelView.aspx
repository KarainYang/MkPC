<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LevelView.aspx.cs" Inherits="Admin_AdminModel_Member_LevelView" %>

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
         <table class="fromTable">
                <tr>          
                    <th>级别名称：</th>
                    <td>
                        <asp:TextBox ID="TbTitle" runat="server"  CssClass="inputCss" Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFV1" runat="server" ErrorMessage="请输入优惠券名称！" ControlToValidate="TbTitle"></asp:RequiredFieldValidator>
                    </td>
               </tr> 
               <tr>
                     <th>折扣：</th>
                    <td>
                        <asp:TextBox ID="TbDiscount" runat="server" CssClass="inputCss"></asp:TextBox>                        
                    </td>
               </tr> 
               <tr>
                     <th>是否为默认级别：</th>
                    <td>
                        <yk:CheckBox runat="server" ID="CheckIsDefault" />
                    </td>
               </tr> 
               <tr>
                     <th>是否启用折扣：</th>
                    <td>
                        <yk:CheckBox runat="server" ID="CheckIsEnableDis" />
                    </td>
               </tr> 
               <tr>
                     <th>最低积分：</th>
                    <td>
                        <asp:TextBox ID="TbMinIntegral" runat="server" CssClass="inputCss"></asp:TextBox>                        
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