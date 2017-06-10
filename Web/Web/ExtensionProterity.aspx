<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExtensionProterity.aspx.cs" Inherits="ExtensionProterity" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <yk:TextBox runat="server" ID="TbName" LabelID="LbelTitle" GroupName="Validator" Validator="数字"></yk:TextBox>
    </div>
    </form>
</body>
</html>
