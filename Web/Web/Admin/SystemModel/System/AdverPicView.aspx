<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdverPicView.aspx.cs" Inherits="Admin_AdminModel_System_AdverPicView" %>

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
                    <th>名称：</th>
                    <td>
                        <asp:TextBox ID="TbName" runat="server" Width="300px" CssClass="inputCss"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入名称！" ControlToValidate="TbName"></asp:RequiredFieldValidator>
                    </td>
               </tr>
               <tr>          
                    <th>图片：</th>
                    <td>
                        <yk:FileUpload runat="server" ID="PicUrl" DirectoryUrl="Userfiles/Adver/" />
                    </td>
               </tr>
               <tr>          
                    <th>连接地址：</th>
                    <td>
                        <asp:TextBox ID="TbLinkUrl" runat="server" Width="300px" CssClass="inputCss" Text="http://"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="请输入连接地址！" ControlToValidate="TbLinkUrl"></asp:RequiredFieldValidator>
                    </td>
               </tr>
               <tr>          
                    <th>是否隐藏：</th>
                    <td>
                        <yk:CheckBox runat="server" ID="CheckIsHidden" /> 隐藏
                    </td>
               </tr>
               <tr>
                     <th>排序：</th>
                    <td>
                        <asp:TextBox ID="TbOrderBy" runat="server" Width="300px" MaxLength="60" CssClass="inputCss"></asp:TextBox>                        
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