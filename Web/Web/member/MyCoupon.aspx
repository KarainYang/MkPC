<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyCoupon.aspx.cs" Inherits="member_MyCoupon" %>
<%@ Import Namespace="YK.Model" %>
<%@ Import Namespace="YK.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta name="Author" content="">
    <title>梦科商城</title>

    <link href="../style/red/css_member.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/jquery-1.4.2.min.js"></script>
    <script language="javascript" type="text/javascript">
       var submenu= '25'
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
      
      <h3 class="Title">优惠券</h3>
      
      <div class="Main">
      <!--Content Start-->
        <div class="mycoupon_form">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="mytable">
              <tr class="item">
                <td>优惠券号码</td>
                <td>抵扣金额</td>
                <td>有效期</td>
                <td>发放时间</td>
                <td>状态</td>
              </tr>
              <%
                  foreach (TB_Activity_CouponNos entity in list)
                  {
                      TB_Activity_Activity activity = YK.Service.ActivityService.ActivitysService.Get(entity.ActivityID);
                   %>
                  <tr>
                    <td><%=entity.CouponNo %><font> <%= activity.CouponIsSetDate==true?(activity.CouponEndDate<DateTime.Now?"(过期)":(activity.CouponStartDate>DateTime.Now?"(未到使用时间)":"")):"不限时" %></font></td>
                    <td><%=activity.DeductibleAmount%>(元)</td>
                    <td><%=activity.CouponStartDate.ToLongDateString() %> 至 <%= activity.CouponEndDate.ToLongDateString() %></td>
                    <td><%=entity.SendDate %></td>
                    <td><%=entity.IsUse==false?"未使用":"已使用" %></td>
                  </tr>
              <%
                   }
               %>
            </table>   
        </div> 
      <!--Page-->
        <div class="Pages">
            <div class="page_total">目前在第<span><%=AspNetPager1.CurrentPageIndex %></span>页，共有<span><%=AspNetPager1.PageCount %></span>页，共有<span><%=AspNetPager1.RecordCount %></span>条记录</div>
            <div class="page_num">
                <yk:AspNetPager runat="server" ID="AspNetPager1" PageSize="3" NumericButtonCount="3" ShowPageIndexBox="Always"
                    SubmitButtonText=" 确定 " SubmitButtonClass="button" PageIndexBoxClass="text"
                    PrevPageText="上一页" NextPageText="下一页" FirstPageText="首页" LastPageText="末页" 
                    onpagechanging="AspNetPager1_PageChanging"></yk:AspNetPager>   
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
