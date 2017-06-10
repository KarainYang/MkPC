<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ActivityDetails.aspx.cs"
    Inherits="Activity_ActivityDetails" %>

<%@ Import Namespace="YK.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta name="Author" content="">
    <title>网上商店</title>
    <link href="../style/red/css_groupbuy.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="../Scripts/pngimg.js"></script>
</head>
<body class="bgbody" onload="document.getElementById('navProduct').className='acur'">
    <form id="form1" runat="server">
    <!--Hearer-->
    <yk:Top runat="server" />
    <!--Hearer End-->
    <div class="Contain">
        <!--商品分类-->
        <yk:ProCategory runat="server" />
        <!--商品分类End-->
        <div class="Current">
            当前位置：<a href="<%=YK.Common.CommonClass.AppPath+"index.aspx" %>">首页</a> -> <a href="ActivityList.aspx">
                促销活动</a> ->  <font><%=entity.Name %></font></div>
        <!--Right Start-->
        <div class="Maincontent">
            <div class="Wrap_GroupBuyList">
                <h2 class="GroupBuy_tab"><span class="show"><a>活动详细</a> </span></h2>
                <div class="Wrap_GroupBuyList_cont">
                    <div class="Wrap_Group">
                        <!--今日团购 start-->
                        <div class="Wrap_GroupBuyTop">
                        </div>
                        <div class="Wrap_GroupBuyBox">
                            <div class="GroupBuy_Name">
                                <%=entity.Name %>
                            </div>
                            <div class="GroupBuy_txt">
                                <%=entity.Description %>                          
                            </div>
                        </div>
                        <div class="Wrap_GroupBuyBottom">
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--Right End-->
        <div class="clear">
        </div>
    </div>
    <!--Help-->
    <yk:Help runat="server" />
    <!--Help End-->
    <!--Footer-->
    <yk:Bottom runat="server" />
    <!--Footer End-->
    </form>
</body>
</html>
