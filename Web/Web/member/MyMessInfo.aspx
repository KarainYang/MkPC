<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyMessInfo.aspx.cs" Inherits="member_MyMessInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta name="Author" content="梦科商城">
    <title>梦科商城</title>

    <link href="../style/red/css_member.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/jquery-1.4.2.min.js"></script>
    <script language="javascript" type="text/javascript">
       var submenu= '31'
    </script>
</head>

<body class="bgbody">
    <form id="form1" runat="server">
    <!--Hearer-->
<yk:Top runat="server" />
<!--Hearer End-->
<div class="Contain">
    <!--商品分类-->
    <yk:ProCategory runat="server" />
    <!--商品分类End-->
    <div class="Current">当前位置：<a href="<%=YK.Common.CommonClass.AppPath+"index.aspx" %>">首页</a> > <font>会员中心</font></div>
    <!--Left-->
    <div class="Sidebar">
        <!--Menu-->
        <yk:MemberMenu runat="server" />
        <!--MenuEnd-->               
    </div>
    <!--Left End-->
    <!--Right Start--> 
    <div class="Maincontent">  
      
      <h3 class="Title">站内短信</h3>
      
      <div class="Main">
      <!--Content Start-->
        
        <div class="messinfo">
            <ul class="txt">
            <li><em>主题：</em><b>苗立杰砍22分中国女篮首胜 将争世锦赛第13名</b></li>
            <li><em>发送人：</em>乐网</li>
            <li><em>发送时间：</em>2011-08-09</li>
            <li><em>短信内容：</em></li>
            </ul>
            <div class="info">
            <p>纤美轻薄高亮光彩造型，，以高光无痕注塑的环保理念，融入您的家居，更贴近高品位的您，个性而不张扬，简洁而不失气质</p>
            <p>50多年来，长虹致力于产品可靠性系统工程的研究，并首将军事航空的可靠性技术导入电视产品中，并邀请知名军事专家主持，通过严酷的实验测试保证电视在各类使用环境及使用习惯下经得起折磨。</p>
            </div>  
            <div class="back"><a href="javascript:history.back();">返回</a></div>
        </div> 

      <!--Content End-->     
      </div>
      <div class="BottomEdge"></div> 
    </div>      
  <!--Right End-->
  <div class="clear"></div>
</div>

<!--Footer-->
<yk:Bottom runat="server" />
<!--Footer End-->
    </form>
</body>
</html>
