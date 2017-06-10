<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExcelModelView.aspx.cs" Inherits="Admin_AdminModel_System_ExcelModelView" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <yk:AdminHeader ID="AdminHeader1" runat="server"></yk:AdminHeader>
</head>
<body>
    <form id="form1" runat="server">
        <div class="BodyDiv"> 
            <div  class="navigation">  
             </div>
             <table class="fromTable">
                    <tr>          
                        <th>模块名称：</th>
                        <td>
                            <asp:TextBox ID="TbModelName" runat="server" Width="300px" CssClass="inputCss"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFV1" runat="server" ErrorMessage="请输入模块名称！" ControlToValidate="TbModelName"></asp:RequiredFieldValidator>
                        </td>
                   </tr>
                   <tr>          
                        <th>对应表名：</th>
                        <td>
                            <asp:TextBox ID="TbTableName" runat="server" Width="300px" CssClass="inputCss"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFV2" runat="server" ErrorMessage="请输入对应表名！" ControlToValidate="TbTableName"></asp:RequiredFieldValidator>
                        </td>
                   </tr>
                   <tr>
                         <th>排序：</th>
                        <td>
                            <asp:TextBox ID="TbOrderBy" runat="server" Width="300px" MaxLength="60" CssClass="inputCss"></asp:TextBox>                        
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