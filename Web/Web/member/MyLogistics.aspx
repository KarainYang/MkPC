<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyLogistics.aspx.cs" Inherits="member_MyLogistics" %>

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
       var submenu= '11'
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
      
      <h3 class="Title">查看物流</h3>
      
      <div class="Main">
      <!--Start-->
      <div class="mylogistics_form">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="mytable">
            <tr>
              <td class="item">发货方式：</td>
              <td>支付宝即时到账接口</td>
            </tr>
            <tr>
              <td class="item">物流编号：</td>
              <td>201107101633403900</td>
            </tr>
            <tr>
              <td class="item">物流公司：</td>
              <td>圆通快递</td>
            </tr>
            <tr>
              <td class="item">运单号码：</td>
              <td> 618170852732</td>
            </tr>
            <tr>
              <td valign="top" class="item">物流追踪：</td>
              <td>
                <div class="statement"><span>以下信息由圆通快递提供，如有疑问请咨询圆通速递</span></div>
                  <h5>处理时间<span>物流状态</span></h5>
                  <div class="speed">
                    <ul>
                    <li>2011-06-20 21:02:17 上海市宝山区 揽收扫描</li>
                    <li>2011-06-20 21:26:51 上海市宝山区 装件入车扫描</li>
                    <li>2011-06-20 22:26:47 上海分拨中心 下车扫描</li>
                    <li>2011-06-22 17:11:16 广州分拨中心 拆包扫描</li>
                    <li>2011-06-22 22:40:08 广州分拨中心 装件入车扫描</li>
                    <li>2011-06-23 08:16:22 广东广州天河工业园 下车扫描</li>
                    <li>2011-06-23 08:34:26 广东广州天河工业园 派件扫描</li>
                    <li class="end">2011-07-29 12:24:01 广东广州天河工业园 正常签收录入扫描</li>
                    </ul>
                  </div>
              </td>
            </tr>
            
          </table>
          <div class="btnDiv"><input type="button" name="button2" id="button2" value="返 回" class="button" onClick="location.href='javascript:history.back();'" onfocus="this.blur()" /></div>
          <h4>交易订单详情</h4> 
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="myPro">
              <tr class="item">
                <td>订单编号：86434872592372 创建时间：2011-07-26 20:31</td>
                <td></td>
              </tr>
              <tr>
                <td class="list">
                <ul>
                    <li>
                        <div class="picture"><a href="#"><img src="../style/red/images/temp/pic20.jpg" /></a></div>
                        <h5><a href="#">2个包邮迷你USB风扇 纯金属结构usb小风扇迷你风扇 笔记本 纯金属结构usb小风扇迷散热风</a></h5>
                        <dl><span>20.00×1</span>颜色: 黑色铝叶</dl>
                    </li>
                    <li>
                        <div class="picture"><a href="#"><img src="../style/red/images/temp/pic22.jpg" /></a></div>
                        <h5><a href="#">2个包邮迷你USB风扇 纯金属结构usb小风扇迷你风扇 笔记本 纯金属结构usb小风扇迷散热风</a></h5>
                        <dl><span>20.00×1</span>颜色: 黑色铝叶</dl>
                    </li>
                </ul>
                </td>
                <td><dt class="message">我的留言： 绿色铝叶 黑色铝叶</dt></td>
              </tr>
            </table>
      </div>
      <!--End-->
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
