<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExcelFieldsView.aspx.cs" Inherits="Admin_AdminModel_System_ExcelFieldsView" %>

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
                        <asp:DropDownList ID="DDLModel" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RFV1" runat="server" ErrorMessage="请选择模块！" ControlToValidate="DDLModel"></asp:RequiredFieldValidator>
                    </td>
               </tr>
               <tr>          
                    <th>字段名称：</th>
                    <td>
                        <asp:TextBox ID="TbFieldName" runat="server" Width="300px" CssClass="inputCss"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFV2" runat="server" ErrorMessage="请输入字段名称！" ControlToValidate="TbFieldName"></asp:RequiredFieldValidator>
                    </td>
               </tr>
               <tr>          
                    <th>中文名称：</th>
                    <td>
                        <asp:TextBox ID="TbChineseName" runat="server" Width="300px" CssClass="inputCss"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入中文名称！" ControlToValidate="TbChineseName"></asp:RequiredFieldValidator>
                    </td>
               </tr>
               <tr>          
                    <th>类型：</th>
                    <td>
                        <asp:CheckBox runat="server" ID="CbExport" />导出
                        <asp:CheckBox runat="server" ID="CbImport" />导入                   
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