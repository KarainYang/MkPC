<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WorkStatementDetails.aspx.cs" Inherits="Admin_SystemModel_Employee_WorkStatementDetails" %>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>
<%@ Import Namespace="YK.Common" %>
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
                            <yk:DropDownList runat="server" ID="DDLType" Visible="false">
                                <asp:ListItem Text="日报" Value="0"></asp:ListItem>
                                <asp:ListItem Text="周报" Value="1"></asp:ListItem>
                                <asp:ListItem Text="月报" Value="2"></asp:ListItem>
                            </yk:DropDownList>

                            <%= DDLType.Items[model.Type].Text %>
                        </td>
                   </tr> 
                   <tr>          
                        <th>标题：</th>
                        <td>
                            <%= model.Title %>
                        </td>
                   </tr> 
                   <tr>
                         <th>汇报日期：</th>
                        <td>
                            <%=model.StatementDate.ToShortDateString() %>                    
                        </td>
                   </tr> 
                   <tr>          
                        <th>工作总结：</th>
                        <td>
                            <%=model.WorkSummary %>
                        </td>
                   </tr> 
                   <tr>          
                        <th>工作计划：</th>
                        <td>
                            <%=model.WorkPlan %>
                        </td>
                   </tr> 
                 </table>
         </div>
    </form>
</body>
</html>
