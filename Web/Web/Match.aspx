<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Match.aspx.cs" Inherits="Match" %>
<%@ Register src="Admin/Controls/Match.ascx" tagname="Match" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="Admin/js/jquery.js"></script>
</head>
<body>
    <form id="form1" runat="server">
<table>
	<tr>
    	<th>类别</th>
        <td><uc1:Match ID="Match1" runat="server" TableName="TB_Product_Categorys" FieldName="ID,CategoryName"></uc1:Match></td>
    </tr>
    <tr>
    	<th>产品</th>
        <td><uc1:Match ID="Match2" runat="server" TableName="TB_Product_Products" FieldName="ID,ProName"></uc1:Match>
        </td>
    </tr>
</table>
    </form>
</body>
</html>
