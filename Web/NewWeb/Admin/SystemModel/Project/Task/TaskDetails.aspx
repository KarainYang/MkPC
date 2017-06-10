<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TaskDetails.aspx.cs" Inherits="Admin_SystemModel_Project_TaskDetails" %>

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
                         <th>所属项目：</th>
                        <td>
                            <%= model.ProjectID.GetEntity<YK.Model.CRM.TB_Project_Projects>().Name %>
                        </td>
                   </tr>     
                   <tr>          
                        <th>缺陷名称：</th>
                        <td>
                            <%= model.Name %>
                        </td>
                   </tr> 
                   <tr>          
                        <th>状态：</th>
                        <td>
                            <%= TaskCommon.GetStateStr(model.State) %>
                        </td>
                   </tr> 
                   <tr>
                         <th>描述：</th>
                        <td>
                            <%= model.Remark %>
                        </td>
                   </tr>
                 </table>
         </div>
    </form>
</body>
</html>
