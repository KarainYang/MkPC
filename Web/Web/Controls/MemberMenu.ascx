<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MemberMenu.ascx.cs" Inherits="Controls_MemberMenu" %>

<div class="MemberMenu">
    <h2><span>会员中心</span></h2>
    <div class="Box">
    <h3>订单中心</h3>
    <ul>
        <li id="submenuId11"><a href="orders.aspx">我的订单</a></li>
        <li id="submenuId12"><a href="mygroupbuy.aspx">我的团购</a></li>
        <%--<li id="submenuId13"><a href="interesting.aspx">我的关注</a></li>--%>
        <%--<li id="submenuId14"><a href="ReturnGoodOrders.aspx">退款申请</a></li>--%>
        <li id="submenuId15"><a href="ReturnGoodOrders.aspx">返修/退换货</a></li>
    </ul>
    <h3>账户中心</h3>
    <ul>
        <li id="submenuId21"><a href="myprofile.aspx">账户信息</a></li>
        <li id="submenuId22"><a href="myaddress.aspx">地址簿</a></li>
        <li id="submenuId23"><a href="mymoney.aspx">虚拟货币</a></li>
        <li id="submenuId24"><a href="mypoints.aspx">我的积分</a></li>
        <li id="submenuId25"><a href="mycoupon.aspx">优惠券</a></li>
        <li id="submenuId26"><a href="changepwd.aspx">修改密码</a></li>
    </ul>
    <h3>我的信息</h3>
    <ul>
        <%--<li id="submenuId31"><a href="mymess.aspx">站内短信</a></li>--%>
        <li id="submenuId32"><a href="mycomments.aspx">评论信息</a></li>
        <li id="submenuId33"><a href="myquestion.aspx">咨询信息</a></li>
        <li id="submenuId34"><a href="mywishlist.aspx">收藏夹</a></li>
        <li id="submenuId35"><a href="pointslist.aspx">积分换礼品</a></li>
    </ul>
    </div>
</div>
<script language="javascript" type="text/javascript">
try{
 document.getElementById("submenuId" + submenu).className= "acur";
 }catch(ex){}
</script>