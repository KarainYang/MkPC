<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClearCache.aspx.cs" Inherits="Admin_WebSet_ClearCache" %>
<%@ Import Namespace="YK.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <yk:AdminHeader ID="AdminHeader1" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="navigation">
           清理缓存
        </div>
         <table class="listTable">          
               <tr>
                    <th>缓存名称</th>
                    <th>操作</th>
               </tr>
               <%
                   foreach (var item in idc)
                   {                       
                    %>
               <tr>
                     <td><%=item.Value %></td>
                    <td><a href="?name=<%=item.Key %>">清除</a></td>                     
               </tr>   
               <% 
                   } %>           
            </table>    
            <div runat="Server" id="MessageDiv"></div> 
    </form>
</body>
</html>