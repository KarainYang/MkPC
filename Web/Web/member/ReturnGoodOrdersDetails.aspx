<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReturnGoodOrdersDetails.aspx.cs" Inherits="member_ReturnGoodOrdersDetails" %>
<%@ Import Namespace="YK.Common" %>
<%@ Import Namespace="YK.Model" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta name="Autdor" content="梦科商城">
    <title>梦科商城</title>

    <link href="../style/red/css_member.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/jquery-1.4.2.min.js"></script>
    <script language="javascript" type="text/javascript">
       var submenu= '15'
    </script>
    
    <style type="text/css">
	    .tdisA{ font-weight:bold; font-size:15px;}
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
                        <td class="item">订单编号：</td>
                        <td><%=orders.OrderNumber %></td>
                    </tr>                    
                    <tr>
                        <td class="item">订单状态：</td>
                        <td><%= orders.State %></td>
                     </tr>                    
                    <tr>
                        <td class="item">数量：</td>
                        <td><%=orders.Count %></td> 
                    </tr>                    
                    <tr>  
                        <td class="item">总金额：</td>
                        <td><%=orders.TotalAmount %></td>  
                    </tr>
                    <tr>
                        <td class="item">订单备注：</td>
                        <td><%=orders.Remark %>&nbsp;</td>
                    </tr>
               </table>               
        </div>

        <div class="orders_form" id="AutoTable1">        
            <div class="Box" name="AutoContent">
                <!--1-->
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="mytable">
                  <tr class="item">
                    <td>商品名称</td>   
                    <td>图片</td>                  
                    <td>单价</td>
                    <td>商品数量</td>
                    <td>金额</td>
                  </tr>
                  <asp:Repeater runat="server" ID="RepList">
                        <ItemTemplate>
                            <tr>                                     
                                <td> 
                                    <a href="<%# CommonClass.AppPath + "Product/Product.aspx?id=" + Eval("ProID") %>" target="_blank">
                                        <%# Eval("ProName")%>
                                    </a>
                                </td>  
                                <td>
                                    <a href="../product/product.aspx?id=<%# Eval("ProID") %>" target="_blank" title="<%# Eval("ProName") %>">
                                        <img src="<%# CommonClass.AppPath+ Eval("ProID").GetEntity<TB_Product_Products>().ImgUrl %>" />
                                    </a>                           
                                </td>
                                <td> <%# Eval("UnitPrice")%></td> 
                                <td> <%# Eval("Quantity")%></td>                                 
                                <td>                                 
                                    <%# Eval("Quantity").ToInt() * Eval("UnitPrice").ToDecimal()%>
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
