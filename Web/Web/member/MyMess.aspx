<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyMess.aspx.cs" Inherits="member_MyMess" %>

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
        
        <div class="mymess_form">
            
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="mytable">
              <tr class="item">
                <td>主题</td>
                <td>发送人</td>
                <td>发送时间</td>
                <td>状态</td>
              </tr>
              <tr>
                <td class="subject"><a href="mymessinfo.shtml">苗立杰砍22分中国女篮首胜 将争世锦赛第13名</a></td>
                <td>乐网</td>
                <td>2011-08-09</td>
                <td>未读</td>
              </tr>
              <tr>
                <td class="subject"><a href="mymessinfo.shtml">各部门领导分别提出了本部门下半年的经营目标和计划，并就公司下半年经营目标进行了讨论并形成了初步的成果</a></td>
                <td>大小豪华</td>
                <td>2011-08-09</td>
                <td>已读</td>
              </tr>
            </table>   
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
