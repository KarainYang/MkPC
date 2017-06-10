<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BrandView.aspx.cs" Inherits="Admin_SystemModel_Product_BrandView" %>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <yk:AdminHeader ID="AdminHeader1" runat="server"></yk:AdminHeader>
</head>
<body>
    <form id="form1" runat="server">
        <div class="BodyDiv"> 
         <table class="fromTable">
                <tr>          
                    <th>类型：</th>
                    <td>
                        <asp:DropDownList ID="DDLType" runat="server">
                            <asp:ListItem Text="普通" Value="1"></asp:ListItem>
                            <asp:ListItem Text="团购" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
               </tr>  
                <tr>          
                    <th>品牌名称：</th>
                    <td>
                        <asp:TextBox ID="TbName" runat="server" Width="300px" CssClass="inputCss"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFV1" runat="server" ErrorMessage="请输入品牌名称！" ControlToValidate="TbName"></asp:RequiredFieldValidator>
                    </td>
               </tr>  
               <tr>          
                    <th>图片：</th>
                    <td>
                        <yk:FileUpload runat="server" ID="ImgUrl" DirectoryUrl="Userfiles/Brand/" />
                    </td>
               </tr>             
               <tr>          
                    <th>排序：</th>
                    <td>
                        <asp:TextBox ID="TbOrderBy" runat="server" Width="100px" CssClass="inputCss"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFV2" runat="server" ErrorMessage="请输入排序！" ControlToValidate="TbOrderBy"></asp:RequiredFieldValidator>
                    </td>
               </tr>             
                <tr>   
                     <th>推荐到首页：</th>
                     <td>
                         <asp:CheckBox ID="CheckBoxVouch" runat="server" Text="推荐" />                                     
                    </td>
                 </tr>  
                 <tr>   
                     <th>是否隐藏：</th>
                     <td>
                         <asp:CheckBox ID="CheckBoxHidden" runat="server" Text="隐藏" />                                     
                    </td>
                 </tr>
                 <tr>
                        <th>描述</th>                     
                        <td>
                             <asp:TextBox ID="TbDesc" runat="server" Width="90%" TextMode="MultiLine" Rows="6" CssClass="inputCss"></asp:TextBox>                         
                        </td>
                 </tr>
            </table>  
        </div> 
        <div class="SubmitClass">
            <asp:Button ID="BtnSave" runat="server" Text=" 保存 " CssClass="buttonCss"  OnClick="BtnSave_Click"/>
                        <input type="button" value=" 取消 " class="buttonCss" id="cancleCss" onclick="closeLayer()"  />
        </div> 
        <div runat="Server" id="MessageDiv">            
        </div> 
    </form>
</body>
</html>
