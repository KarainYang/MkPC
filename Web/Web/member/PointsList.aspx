<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PointsList.aspx.cs" Inherits="member_PointsList" %>

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
       var submenu= '35'
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
      
      <h3 class="Title">积分换礼品</h3>
      
      <div class="Main">
      <!--Content Start-->
        
        <div class="pointslist_form">
            
            
        </div> 
      <!--Page-->
        <div class="Pages">
            <div class="page_total">目前在第<span>1</span>页，共有<span>2</span>页，共有<span>15</span>条记录</div>
            <div class="page_num">
                <a href="#">首页</a>
              <a href="#">上一页</a>
              <a href="#">下一页</a>
                <a href="#">尾页</a>
            </div>
            <div class="page_goto">
            <input type="text" name="textfield2" id="textfield2" class="text" />
            <input type="submit" name="button2" id="button2" value="GO" class="button" />
            </div>
        </div>
      <!--Page-->
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
