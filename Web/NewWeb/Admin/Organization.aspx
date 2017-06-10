<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Organization.aspx.cs" Inherits="Admin_Organization" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>综合管理系统</title>
    <link type="text/css" href="css/Yk.Core.css" rel="Stylesheet" />
    <script language="javascript" type="text/javascript">
        var menuList = '{"ID":"001","ResourceName":"系统管理","ParentID":0,"Url":"",'
                        + 'ChildTree:['
                            + '{"ID":"00101","ResourceName":"租户管理","ParentID":453,"Url":"SystemModel/Sys/OrganizationList.aspx"}'
                        + ']'
                     + '}';
        var entityList = eval('[' + menuList + ']');
    </script>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/yk.core.common.js"></script>
    <script type="text/javascript" src="js/yk.core.layer.js"></script>
</head>
<body>
    <div id="parentMenu" class="parentMenu">
    </div>
    <div id="childMenu" class="childMenu">
    </div>
    <div class="titlesDiv">
        <div id="titles" class="titles"></div>
        <div style="clear: both;"></div>
    </div>
    <div id="contentDivs">
    </div>
    <script type="text/javascript">
        yk.core.layer.add("租户管理", "SystemModel/Sys/OrganizationList.aspx", "00101");
    </script>
</body>
</html>