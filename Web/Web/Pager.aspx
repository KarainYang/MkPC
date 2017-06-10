<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pager.aspx.cs" Inherits="Pager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>

    <script src="scripts/yk.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <th>名称</th>
                    <th>价格</th>
                    <th>日期</th>
                </tr>
                <%
                    foreach(var item in list)
                    {
                     %>
                 <tr>
                     <td><%=item.ProName %></td>
                     <td><%=item.SalesPrice %></td>
                     <td><%=item.AddDate %></td>
                 </tr>
                <%
                    }
                 %>
            </table>
        </div>
        <div runat="server" id="PagerDiv"></div>
    </form>
</body>
</html>
