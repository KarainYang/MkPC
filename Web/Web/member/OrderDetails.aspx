<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderDetails.aspx.cs" Inherits="member_OrderDetails" %>
<%@ Import Namespace="YK.Common" %>
<%@ Import Namespace="YK.Model" %>
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
    
    <style type="text/css">
	    .thisA{ font-weight:bold; font-size:15px;}
	</style>
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
    <div class="Current">当前位置：<a href="../index.aspx">首页</a> > <font>会员中心</font></div>
    <!--Left-->
    <div class="Sidebar">
        <!--Menu-->
        <yk:MemberMenu runat="server" />
        <!--MenuEnd-->               
    </div>
    <!--Left End-->
    <!--Right Start--> 
    <div class="Maincontent">  
      
      <h3 class="Title">退换货操作</h3>
      
      <div class="Main">
      <!--Content Start-->
       <div class="myaddress_form">     
            <table   border="0" cellspacing="0" cellpadding="0" class="mytable" >
                     <tr>  
                        <td class="item">订单编号：</th>
                        <td><%=orders.OrderNumber %></td>
                        <td class="item">下单日期：</th>
                        <td><%=orders.OrderDate %></td>
                    </tr>
                    <tr>
                        <td class="item">订单状态：</th>
                        <td><%= Dictionaries.GetDictionariesTitle(DictionariesEnum.订单状态,orders.OrderStateID) %></td>
                        <td class="item">会员：</th>
                        <td><%= orders.MemberID.GetEntity<YK.Model.TB_Member_Members>().MemberName %>&nbsp;</td>
                     </tr>
                    <tr>
                        <td class="item">商品总数：</th>
                        <td><%=orders.ProCount %></td>
                        <td class="item">积分：</th>
                        <td><%=orders.Integral %></td>  
                    </tr>
                    <tr>
                        <td class="item">订单总金额：</th>
                        <td><%=orders.MoneySum %></td>
                        <td class="item">运费：</th>
                        <td><%=orders.Freight %></td>
                    </tr>
                    <tr>
                        <td class="item">支付方式：</th>
                        <td colspan="3"><%= Dictionaries.GetDictionariesTitle(DictionariesEnum.支付方式, distribution.PaymentID) %></td>
                    </tr>
                    <tr>
                        <td class="item">活动描述：</th>
                        <td colspan="3"><%=orders.ActivityDesc %>&nbsp;</td>     
                    </tr>
                    <tr>
                        <td class="item">订单备注：</th>
                        <td colspan="3"><%=orders.Remark %>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="item">是否开发票：</th>
                        <td><%=orders.IsInvoice==0?"否":"是" %></td>
                        <td class="item">发票类型：</th>
                        <td><%= orders.InvoiceType %></td>
                    </tr>
                    <tr>
                        <td class="item">发票抬头：</th>
                        <td><%=orders.InvoiceLookUp %></td>
                        <td class="item">公司名称：</th>
                        <td><%=orders.CompanyName %>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="item">发票内容：</th>
                        <td colspan="3"><%=orders.InvoiceValue %>&nbsp;</td>
                    </tr>
                     <tr>  
                        <td class="item">收货人：</th>
                        <td>  <%=distribution.BuyerName %>&nbsp;</td>
                        <td class="item">配送方式：</th>
                        <td> <%= Dictionaries.GetDictionariesTitle(DictionariesEnum.配送方式, distribution.ConsignmentID )%></td>
                     </tr>
                     <tr> 
                        <td class="item">送货时间：</th>
                        <td colspan="3">&nbsp; <%= distribution.RepceiptDateType%></td>
                     </tr>
                     <tr> 
                        <td class="item">自提时间：</th>
                        <td>&nbsp; <%=distribution.MentionDate%></td>
                        <td class="item">邮箱：</th>
                        <td><%=distribution.Email%>&nbsp;</td> 
                    </tr>
                    <tr>
                        <td class="item">公司名称：</th>
                        <td><%=distribution.CompanyName%>&nbsp;</td>
                        <td class="item">地址：</th>
                        <td><%=distribution.Address%>&nbsp;</td>
                    </tr>
                     <tr> 
                        <td class="item">手机、电话：</th>
                        <td><%=distribution.Mobile%>、<%=distribution.Phone%>&nbsp;</td>
                        <td class="item">邮编：</th>
                        <td><%=distribution.PostalCode%>&nbsp;</td>
                    </tr>
               </table>               
        </div>

        <div class="orders_form" id="AutoTable1">        
            <div class="Box" name="AutoContent">
                <!--1-->
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="mytable">
                  <tr class="item">
                    <td>商品名称</td>
                    <td>商品图片</td>                    
                    <td>单价</td>
                    <td>商品数量</td>
                    <td>金额</td>
                  </tr>
                  <asp:Repeater runat="server" ID="RepList">
                        <ItemTemplate>
                            <tr>                                     
                                <td> 
                                    <a href="<%# CommonClass.AppPath + "Product/Product.aspx?id=" + Eval("ProductID") %>" target="_blank">
                                        <%# Eval("ProName")%>
                                    </a>
                                </td>  
                                <td>     
                                    <a href="../product/product.aspx?id=<%# Eval("ProductID") %>" target="_blank" title="<%# Eval("ProName") %>">
                                        <img src="<%# CommonClass.AppPath+ Eval("ProductID").GetEntity<TB_Product_Products>().ImgUrl %>" width="60px" />
                                    </a>
                                </td>
                                <td> <%# Eval("Price")%></td> 
                                <td> <%# Eval("Count")%></td>                                 
                                <td>                                 
                                    <%# Eval("Count").ToInt() * Eval("Price").ToDecimal()%>
                                </td>
                            </tr>
                    </ItemTemplate>
                  </asp:Repeater>
                </table>
                <!--1End-->        
          </div>
        </div>
      <div class="BottomEdge"></div> 
    </div>  
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
