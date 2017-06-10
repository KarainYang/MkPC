<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Interesting.aspx.cs" Inherits="member_Interesting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta name="Author" content="梦科商城">
    <title>梦科网络商城系统</title>

    <link href="../style/red/css_member.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/jquery-1.4.2.min.js"></script>
    <script language="javascript" type="text/javascript">
       var submenu= '13'
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
      
      <h3 class="Title">我的关注</h3>
      
      <div class="Main">
      <!--Content Start-->
    <div class="interesting_form">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="mytable">
              <tr class="item">
                <td><input type="checkbox" name="checkbox" id="checkbox" /> 全选</td>
                <td>商品图片</td>
                <td>商品名称</td>
                <td>网友反馈</td>
                <td>单价</td>
                <td>操作</td>
              </tr>
              <tr>
                <td><dt class="checkbox"><input type="checkbox" name="checkbox" id="checkbox" /></dt></td>
                <td><dt class="pro"><a href="#"><img src="../style/red/images/temp/pic20.jpg" /></a></dt>
                </td>
                <td>
                <dt class="name"><a href="#">日立UT37-MX0i7Wooo超薄08系120Hz倍速全高清IPS-屏幕</a></dt>
                <dt class="time">加关注时间：2011-06-30</dt>
                </td>
                <td><dt class="comment">评价：<font>25325人</font></dt></td>
                <td><dt class="money">￥6450.0</dt></td>
                <td>
                <dt class="operate">
                <input type="submit" name="button2" id="button2" value="加入购物车" class="btn_inCar" />
                <a href="#">取消关注</a>
                </dt>
                </td>
              </tr>
              <tr>
                <td><dt class="checkbox"><input type="checkbox" name="checkbox" id="checkbox" /></dt></td>
                <td><dt class="pro"><a href="#"><img src="../style/red/images/temp/pic20.jpg" /></a></dt>
                </td>
                <td>
                <dt class="name"><a href="#">日立UT37-MX0i7Wooo超薄08系120Hz倍速全高清IPS-屏幕</a></dt>
                <dt class="time">加关注时间：2011-06-30</dt>
                </td>
                <td><dt class="comment">评价：<font>25325人</font></dt></td>
                <td><dt class="money">￥6450.0</dt></td>
                <td>
                <dt class="operate">
                <input type="submit" name="button2" id="button2" value="加入购物车" class="btn_inCar" />
                <a href="#">取消关注</a>
                </dt>
                </td>
              </tr>
            </table>
            <div class="whole">
            <input type="checkbox" name="checkbox" id="checkbox" /> 全选
            <input type="submit" name="button2" id="button2" value="加入购物车" class="btn_inCar" />
            <input type="submit" name="button2" id="button2" value="计算总价" class="btn_inTotal" />
            <a href="#">取消关注</a>
            </div>     
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
