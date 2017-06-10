<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InfoDetails.aspx.cs" Inherits="Admin_SystemModel_Employee_Info_InfoDetails" %>

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
        <br/>         
        <div class="BodyDiv" style=" width:90%; margin:auto; line-height:20px;">         
                 <div style=" font-weight:bold; font-size:16px; text-align:center;">
                    <%=model.Title %>
                 </div>
                 <div style="text-align:center;">
                    发布时间：<%=model.AddDate %>  
                    发布人：<%=model.Creater %>
                 </div>
                 <div>
                      <%= model.Remark %>
                 </div>
         </div> 
    </form>
</body>
</html>
