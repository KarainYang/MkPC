<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PassGroupBuy.aspx.cs" Inherits="promotion_PassGroupBuy" %>
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
    <script language="javascript">
        var navId = 3;
    </script>
</head>
<body  class="bgbody">
    <form id="form1" runat="server">
    <!--Hearer-->
        <yk:Top runat="server" />
<!--Hearer End-->
<div class="Contain">
    <!--商品分类-->
    <yk:ProCategory runat="server" />
    <!--商品分类End-->
    <div class="Current">当前位置：<a href="<%=YK.Common.CommonClass.AppPath+"index.aspx" %>">首页</a> -> <a>团购专区</a></div>
    <!--Right Start--> 
    <div class="Maincontent">
       <!--商品搜索 start-->
<div class="Wrap_Search">
    <div class="search_top">
        <span>商品筛选</span>
    </div>
    <div class="search_box">
        <dl class="select_list">
            <dt><span>商品分类：</span><em id="category_0"><a id="GroupBuyListNew1_lbCategory0" href="<%=CommonClass.RemoveUrlParas(Request.Url.ToStr(), "categoryId")%>">全部</a></em></dt>
            <dd>
                <%
                    foreach(TB_Product_Categorys entity in categoryList)
                    {
                 %>
                 <b id="category_1">
                            <a id="GroupBuyListNew1_repCategory_ctl00_lbCategory" href="groupbuy.aspx?categoryId=<%=entity.ID %>"><%=entity.CategoryName %></a>
                 </b>
                 <%
                    } %>
            </dd>
        </dl>
    </div>
    <script type="text/javascript">$("#category_0").addClass("all");</script>
    <div class="search_bottom"></div>
</div>
<!--商品搜索 end-->



<!--团购列表 start-->
<div class="Wrap_GroupBuyList">
    <h2 class="GroupBuy_tab">
        <span>
            <a id="GroupBuyListNew1_lbShowTypeToday" href="groupbuy.aspx">今日团购</a>
        </span>
        <span class="show">
            <a id="GroupBuyListNew1_lbShowTypePast" href="groupbuy.aspx">往期团购</a>
        </span>
    </h2>
    <div class="Wrap_GroupBuyList_cont">
        <div>
            <!--今日团购 start-->
                <ul class="GroupBuy_List">   
                    <%
                        foreach(TB_Product_Group entity in groupBuyList)
                        {
                    %>
                    <li style="background:url(../style/red/images/groupbuy/buy_boxbg2.gif) no-repeat left top;">
                        <div class="Group_img">
                            <a href="PassGroupBuyDetails.aspx?id=<%=entity.ID %>">
                             <img src="<%=YK.Common.CommonClass.AppPath+entity.ImgUrl %>"  onerror="this.src='<%= YK.Common.CommonClass.AppPath %>style/red/images/nopic.jpg';" />
                            </a>
                        </div>
                        <h2 class="Group_Txt"><%=entity.GroupName %></h2>
                        <input name="GroupBuyListNew1$repList$ctl01$hidTime" type="hidden" id="GroupBuyListNew1_repList_ctl01_hidTime" value="2013-03-21,23:55:40" aa="6928159" />
                        <h3> 
                            <b> <%=entity.GroupPrice %></b> 
                        </h3>
                        <h4>
                            <span id="spanRemainder6928159"></span>
                            已卖出<b><%=GetProSum(entity.ID)%></b>件
                            <span><font>原价：<s>￥<%=entity.Price %></s></font> 
                            <font>节省：<em>￥<%=entity.Price-entity.GroupPrice %></em></font></span>
                        </h4>                                
                    </li>  
                    <%
                        }
                     %>                    
                </ul>
                
            <div class="clear">
            </div>            

            <!--Page-->
            <div class="Pages">
                <div class="page_total">目前在第<span><%=AspNetPager1.CurrentPageIndex %></span>页，共有<span><%=AspNetPager1.PageCount %></span>页，共有<span><%=AspNetPager1.RecordCount %></span>条记录</div>
                <div class="page_num">
                    <yk:AspNetPager runat="server" ID="AspNetPager1" PageSize="9" NumericButtonCount="3" ShowPageIndexBox="Always"
                        SubmitButtonText=" 确定 " SubmitButtonClass="button" PageIndexBoxClass="text"
                        PrevPageText="上一页" NextPageText="下一页" FirstPageText="首页" LastPageText="末页" 
                        onpagechanging="AspNetPager1_PageChanging"></yk:AspNetPager>   
                </div>               
                    
            </div>
            <!--Page-->  
            <!--今日团购 end-->
        </div>
    </div>
</div>
<!--降价商品end-->

        
        
  </div>     
  <!--Right End-->
  <div class="clear"></div>
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
