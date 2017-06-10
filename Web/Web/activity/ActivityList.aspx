<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ActivityList.aspx.cs" Inherits="Activity_ActivityList" %>

<%@ Import Namespace="YK.Common" %>
<%@ Import Namespace="YK.Model" %>
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
    <script language="javascript" type="text/javascript">
        var navId = 5;
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
        <div class="Current">
            当前位置：<a href="<%=YK.Common.CommonClass.AppPath+"index.aspx" %>">首页</a> -> <a href="javascript:void(0)">
                促销活动</a></div>
        <!--Right Start-->
        <div class="Maincontent">
            <!--团购列表 start-->
            <div class="Wrap_GroupBuyList">
                <h2 class="GroupBuy_tab">
                    <span class="show"><a>优惠活动</a> </span>
                </h2>
                <div class="Wrap_GroupBuyList_cont">
                    <div class="Wrap_proList">
                        <%
                            foreach(TB_Activity_Activity entity in activityList)
                            {
                         %>
                        <div class="Wrap_PromotionBottom"></div>
                        <div class="Wrap_PromotionBox">
                            <div class="Wrap_ProImg">
                                <a href="ActivityDetails.aspx?id=<%=entity.ID %>">
                                    <img src="xxxxxxx" onerror="this.src='<%= YK.Common.CommonClass.AppPath %>style/red/images/nopic.jpg';">
                                </a>
                            </div>
                            <div class="Wrap_ProTxt">
                                <h1>
                                    <a href="ActivityDetails.aspx?id=<%=entity.ID %>"><%=entity.Name %></a></h1>
                                <h2>
                                    活动时间： <%=entity.IsSetDate==false?"不限时":("<span>"+entity.StartDate+"</span>至<span>"+entity.EndDate+"</span>") %>
                                </h2>
                            </div>
                        </div> 
                       <%
                            }
                        %>                  
                        <div class="clear"></div>
                        <!--Page-->
                        <div class="Pages">
                            <div class="page_total">
                                目前在第<span><%=AspNetPager1.CurrentPageIndex %></span>页，共有<span><%=AspNetPager1.PageCount %></span>页，共有<span><%=AspNetPager1.RecordCount %></span>条记录</div>
                            <div class="page_num">
                                <yk:AspNetPager runat="server" ID="AspNetPager1" PageSize="3" NumericButtonCount="3"
                                    ShowPageIndexBox="Always" SubmitButtonText=" 确定 " SubmitButtonClass="button"
                                    PageIndexBoxClass="text" PrevPageText="上一页" NextPageText="下一页" FirstPageText="首页"
                                    LastPageText="末页" OnPageChanging="AspNetPager1_PageChanging">
                                </yk:AspNetPager>
                            </div>
                        </div>
                        <!--Page-->
                    </div>
                </div>
            </div>
            <!--降价商品end-->
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
