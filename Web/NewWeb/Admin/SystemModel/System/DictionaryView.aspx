﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DictionaryView.aspx.cs" Inherits="Admin_AdminModel_System_DictionaryView" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <yk:AdminHeader ID="AdminHeader1" runat="server"></yk:AdminHeader>
</head>
<body>
    <form id="form1" runat="server">
         <table class="fromTable" >
                <tr style=" display:none;">          
                    <th>类型：</th>
                    <td>
                        <asp:DropDownList ID="DDLModel" runat="server">
                        </asp:DropDownList>
                    </td>
               </tr>
               <tr>          
                    <th>名称：</th>
                    <td>
                        <asp:TextBox ID="TbName" runat="server" Width="300px" CssClass="inputCss"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入名称！" ControlToValidate="TbName"></asp:RequiredFieldValidator>
                    </td>
               </tr>
               <tr>          
                    <th>标识：</th>
                    <td>
                        <asp:TextBox ID="TbCode" runat="server" CssClass="inputCss"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFV2" runat="server" ErrorMessage="请输入标识！" ControlToValidate="TbCode"></asp:RequiredFieldValidator>
                    </td>
               </tr>
              <tr>          
                    <th>备注：</th>
                    <td>
                        <asp:TextBox ID="TbRemark" runat="server" Width="90%" TextMode="MultiLine" Rows="3" CssClass="inputCss"></asp:TextBox>
                    </td>
               </tr>
               <tr>
                     <th>排序：</th>
                    <td>
                        <asp:TextBox ID="TbOrderBy" runat="server" MaxLength="60" CssClass="inputCss"></asp:TextBox>                        
                    </td>
               </tr>
            </table>    
            <div class="SubmitClass">
           
                <asp:Button ID="BtnSave" runat="server" Text=" 保存 " CssClass="buttonCss"  OnClick="BtnSave_Click"/>
                         <input type="button" value=" 取消 " class="buttonCss" id="cancleCss" onclick="closeLayer()"  />
            </div>
            <div runat="Server" id="MessageDiv">            
            </div> 
    </form>
</body>
</html>