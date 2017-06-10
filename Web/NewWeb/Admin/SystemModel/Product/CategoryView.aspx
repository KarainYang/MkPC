<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CategoryView.aspx.cs" Inherits="Admin_SystemModel_Product_CategoryView" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="YK.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <yk:AdminHeader ID="AdminHeader1" runat="server"></yk:AdminHeader>
    
</head>
<body>
    <form id="form1" runat="server">
            <div>
                <yk:CategoryView runat="server"></yk:CategoryView>
            </div>             
    </form>
</body>
</html>

