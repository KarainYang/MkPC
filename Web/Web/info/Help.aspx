<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Help.aspx.cs" Inherits="info_Help" %>

<%@ Import Namespace="YK.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta name="Author" content="">
    <title>梦科网络商城系统</title>
    <script type="text/javascript" src="../Scripts/jquery-1.4.2.min.js"></script>
    <link href="../style/red/css_member.css" rel="stylesheet" type="text/css" />
</head>

<body class="bgbody">
    <form id="form1" runat="server">
    <!--Hearer-->
        <yk:Top ID="Top1" runat="server" />
    <!--Hearer End-->
<div class="Contain">
    <!--商品分类-->
    <yk:ProCategory ID="ProCategory1" runat="server" />
    <!--商品分类End-->
    <div class="Current">当前位置：<a href="<%=YK.Common.CommonClass.AppPath+"index.aspx" %>">首页</a> > <font>帮助中心</font></div>
    <!--Left-->
    <div class="Sidebar">
        <!--Menu-->
        <yk:HelpMenu ID="HelpMenu1" runat="server" />
        <!--MenuEnd-->               
    </div>
    <!--Left End-->
    <!--Right Start--> 
    <div class="Maincontent">

      <div class="Main" style="border:1px solid #F5F5F5; padding:10px;">
      <!--Content Start-->
          <div style="line-height:30px; font-weight:bold; font-size:20px;"><%= help.Title %></font></h2></div>
          <div class="safe">
              <%= help.Remark %>  
        </div>
      <!--信息提示End-->      
      <!--Content End-->    
      </div>
      <div class="BottomEdge"></div>        
  </div>     
  <!--Right End-->
  <div class="clear"></div>
</div>

<!--Footer-->
    <yk:Bottom ID="Bottom1" runat="server" />
<!--Footer End-->
    </form>
</body>
</html>