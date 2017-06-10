<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyGroupBuy.aspx.cs" Inherits="member_MyGroupBy" %>
<%@ Import Namespace="YK.Common" %>
<%@ Import Namespace="YK.Model" %>

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
       var submenu= '12'
    </script>
</head>

<body class="bgbody">
    <form id="form1" runat="server">
    <!--Hearer-->
    <yk:Top runat="server" />
    <!--Hearer End-->
<div class="Contain">
    <!--商品分类-->
    <yk:ProCategory  runat="server" />
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
      
      <h3 class="Title">我的团购</h3>
      
      <div class="Main">
      <!--Content Start-->
      <!--Search-->
      <div class="proSearch">
          <input name="textfield3" type="text" id="TbKey" runat="server" value="订单编号" onfocus="this.value=''" class="text" />
          <asp:Button ID="BtnSubmit" runat="server" Text="查询" CssClass="search" 
              onclick="BtnSubmit_Click" />
      </div>
      <!--Search End-->
    <div class="orders_form" id="AutoTable1">
        <h2 class="tab">
            <span><b><a href="Orders.aspx?state=0" id="a0">申请中</a> </b></span>
            <span><b><a href="Orders.aspx?state=1" id="a1">已审核</a></b></span>
            <span><b><a href="Orders.aspx?state=2" id="a2">备货</a></b></span>
            <span><b><a href="Orders.aspx?state=3" id="a3">发货</a></b></span>
            <span><b><a href="Orders.aspx?state=4" id="a4">待签收</a></b></span>
            <span><b><a href="Orders.aspx?state=5" id="a5">财务确认</a></b></span>
            <span><b><a href="Orders.aspx?state=6" id="a6">完成订单</a></b></span>
            <span><b><a href="Orders.aspx?state=7" id="a7">已取消</a></b></span>
                
            <script language="javascript" type="text/javascript">
                var num = '<%= Request["state"].ToInt() %>';
                document.getElementById("a" + num).className = "thisA";
            </script>
        </h2>
        <div class="Box" name="AutoContent">
            <!--1-->
            <div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="mytable">
              <tr class="item">
                <td>订单编号</td>
                <td>订单商品</td>
                <td>收货人</td>
                <td>订单金额</td>
                <td>下单时间</td>
                <td>订单状态</td>
                <td>操作</td>
              </tr>
              <asp:Repeater runat="server" ID="RepList" onitemdatabound="RepList_ItemDataBound">
                    <ItemTemplate> 
                      <tr>
                        <td><dt class="number"><%# Eval("OrderNumber") %></dt></td>
                        <td class="pro">
                            <asp:HiddenField ID="HiddenFieldOrderNumber" runat="server" Value='<%# Eval("OrderNumber") %>' />
                            <ul>
                                <asp:Repeater runat="server" ID="RepDetails">
                                    <ItemTemplate>
                                        <li><a href="../product/product.aspx?id=<%# Eval("ProID") %>" target="_blank"><img src="<%# CommonClass.AppPath+ Eval("ProID").GetEntity<TB_Product_Products>().ImgUrl %>" /></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </td>
                        <td><dt class="name"><%# Eval("OrderNumber").GetEntity<YK.Model.TB_Order_Distribution>("OrderNumber").BuyerName %></dt></td>
                        <td><dt class="money">￥<%# Eval("MoneySum") %><br />
                            <%# Dictionaries.GetDictionariesTitle(DictionariesEnum.支付方式, Eval("OrderNumber").GetEntity<TB_Order_Distribution>("OrderNumber").PaymentID) %></dt></td>
                        <td><dt class="time"><%# Eval("OrderDate")%></dt></td>
                        <td><dt class="status">
                            <%# Dictionaries.GetDictionariesTitle(DictionariesEnum.订单状态, Eval("OrderStateID").ToInt() )%>
                        <td>
                        <dt class="operate">
                        <a href="#">查看详细</a>
                        <a href="mylogistics.shtml">查看物流</a>
                        <a href="#">退换货</a>
                        </dt>
                        </td>
                      </tr>
                </ItemTemplate>
              </asp:Repeater>
            </table>
            </div>
            <!--1End-->          
      </div>
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
