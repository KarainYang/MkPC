<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberView.aspx.cs" Inherits="Admin_AdminModel_Member_MemberView" %>

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
                        <asp:TextBox ID="TbUserName" runat="server"  CssClass="inputCss"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFV1" runat="server" ErrorMessage="请输入用户名！" ControlToValidate="TbUserName"></asp:RequiredFieldValidator>
                    </td>
               </tr>
               <tr>          
                    <th>密码：</th>
                    <td>
                        <asp:TextBox ID="TbUserPwd" runat="server"  CssClass="inputCss"  TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFV2" runat="server" ErrorMessage="请输入密码！" ControlToValidate="TbUserPwd"></asp:RequiredFieldValidator>
                    </td>
               </tr>
               <tr>
                     <th>确认密码：</th>
                    <td>
                        <asp:TextBox ID="TbConfirmPwd" runat="server"  MaxLength="60" CssClass="inputCss"  TextMode="Password"></asp:TextBox>                        
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="两次密码不一致" ControlToValidate="TbUserPwd" ControlToCompare="TbConfirmPwd"></asp:CompareValidator>
                    </td>
               </tr>   
               <tr>
                     <th>真实姓名：</th>
                    <td>
                        <asp:TextBox ID="TbRealName" runat="server"  MaxLength="60" CssClass="inputCss"></asp:TextBox>                        
                    </td>
               </tr>    
               <tr>
                     <th>性别：</th>
                    <td>
                        <yk:DropDownList runat="server" ID="DDLSex">
                            <asp:ListItem Text="男" Value="0"></asp:ListItem>
                            <asp:ListItem Text="女" Value="1"></asp:ListItem>
                        </yk:DropDownList>
                    </td>
               </tr>
               <tr>
                     <th>年龄：</th>
                    <td>
                        <asp:TextBox ID="TbAge" runat="server"  MaxLength="60" CssClass="inputCss"></asp:TextBox>                        
                    </td>
               </tr>     
               <tr>
                     <th>生日：</th>
                    <td>
                        <asp:TextBox ID="TbBirthday" runat="server"  MaxLength="60" CssClass="inputCss" onclick="WdatePicker()"></asp:TextBox>                        
                    </td>
               </tr> 
               <tr>
                     <th>照片：</th>
                    <td>
                        <yk:FileUpload runat="server" ID="PhotoUrl" />                       
                    </td>
               </tr>  
               <tr>
                     <th>手机：</th>
                    <td>
                        <asp:TextBox ID="TbMobile" runat="server"  MaxLength="60" CssClass="inputCss"></asp:TextBox>                        
                    </td>
               </tr>   
               <tr>
                     <th>邮箱：</th>
                    <td>
                        <asp:TextBox ID="TbEmail" runat="server"  MaxLength="60" CssClass="inputCss"></asp:TextBox>                        
                    </td>
               </tr>
               <tr>
                     <th>所在城市：</th>
                    <td>
                        <asp:TextBox ID="TbCity" runat="server"  MaxLength="60" CssClass="inputCss"></asp:TextBox>                        
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