<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminHeader.ascx.cs" Inherits="Admin_Controls_AdminHeader" %>
<%@ Import Namespace="YK.Common" %>

<% 
    string[] arr = Request.Url.ToString().Split('/');
    string thisAddress = Request.Url.ToString().Replace(arr[arr.Length - 1], "");
    %>
<script type="text/javascript">
    var thisAddress = "<%=thisAddress %>";
</script>

<%= "<link href=" + CommonClass.AppPath + "Admin/css/Style.css" + " rel=\"stylesheet\" type=\"text/css\" />"%>

<script language="javascript" type="Text/javascript" src="<%=CommonClass.AppPath %>Admin/js/jquery.js"></script>

<script language="javascript" type="Text/javascript" src="<%=CommonClass.AppPath %>Admin/js/Common.js"></script>

<script type="text/javascript" src="<%=CommonClass.AppPath %>Admin/js/DialogCommon.js"></script>

<script type="text/javascript" src="<%=CommonClass.AppPath %>Admin/My97DatePicker/WdatePicker.js"></script>

