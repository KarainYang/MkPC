<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShoppingCart3.aspx.cs" Inherits="order_ShoppingCart3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta name="Author" content="">
    <title>梦科商城</title>

    <link href="../style/red/css_cart.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/jquery-1.4.2.min.js"></script>
</head>

<body class="bgbody">
    <form id="form1" runat="server">
    <!--Hearer-->
    <div class="other_Header">
        <yk:Top runat="server" />
    </div>
    <!--Hearer End-->

    <div class="Contain">
        <div class="myorder"></div>
        <h3 class="Title">成功提交订单 </h3>
        <div class="mainbox">
        <!--Content Start-->    
            <div class="shoppingcart_step"><span class="step03"></span></div>
            
            <div class="Success">
                <h5>您的订单号：<%= Request.QueryString["OrderNumber"]%></h5>
                <p>您的订单已经完成，您可以在会员中心里查看到该订单的状态，谢谢！<br />
                 咨询热线：<font>020-26372737</font></p>
                 <input id="Button1" type="button" value=""  class="btn_Shopping" onClick="location.href='<%=YK.Common.CommonClass.AppPath+"index.aspx" %>'" onfocus="this.blur()"/>
                 <input id="Button2" type="button" value="" class="btn_Member"  onClick="location.href='<%=YK.Common.CommonClass.AppPath+"member/index.aspx" %>'" onfocus="this.blur()"/>
            </div>
        
        <!--Content End-->     
        </div>
        <div class="BottomEdge"></div>
    </div>

<!--Footer-->
    <yk:Bottom runat="server" />
<!--Footer End-->
    </form>
    <script language="javascript">
        window.open('<%=YK.Common.CommonClass.AppPath + "Alipay/default.aspx"%>');
    </script>
</body>
</html>
