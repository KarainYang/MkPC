<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="order_ShoppingCart" %>
<%@ Import Namespace="YK.Common" %>
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
    <h3 class="Title">我的购物车</h3>
    <div class="mainbox">
    <!--Content Start-->
    
    <div class="shoppingcart_step"><span class="step01"></span></div>
    
    <div class="empty" runat="server" id="CartNull" visible="false">
      <h5>您的购物车还是空的，赶紧行动吧！您可以：</h5>
      <p>如果您还未登录，可能导致购物车为空，请<a href="<%=CommonClass.AppPath+"member/Login.aspx" %>">马上登录</a><br />
        如果您已经是会员，马上去<a href="<%=YK.Common.CommonClass.AppPath+"index.aspx" %>">挑选产品</a></p>
    </div>
    <!--购物车商品-->
    <div class="CartProduct" runat="server" id="CartDiv">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="mytable">
      <tr class="item">
        <td>商品编号</td>
        <td>商品图片</td>
        <td>商品名称</td>
        <td>商品价格</td>
        <td>数量</td>
        <td>小计</td>
        <td>操作</td>
      </tr>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server"> 
            <ContentTemplate>                  
                <asp:Repeater ID="RepList" runat="server" onitemcommand="RepList_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("proNumber")%></td>
                            <td>
                                <dt class="picture">
                                    <a href="../Product/Product.aspx?id=<%# Eval("ID") %>">
                                        <img src="<%# CommonClass.AppPath+ Eval("img") %>"  onerror="this.src='<%= YK.Common.CommonClass.AppPath %>style/red/images/nopic.jpg';"/>
                                    </a>
                                </dt>
                            </td>
                            <td>
                                <dt class="name">
                                    <a href="../Product/Product.aspx?id=<%# Eval("ID") %>">
                                        <%# Eval("name") %>
                                    </a>
                                </dt>
                            </td>
                            <td>
                            市场价格：<font>￥<%# Eval("marketPrice")%></font><br />
                            会员价格：<font>￥<%# Eval("price")%></font><br />
                            为您节省：<font>￥<%# Eval("marketPrice").ToDecimal() - Eval("price").ToDecimal()%> </font>
                            </td><% %>
                            <td>
                                <asp:TextBox ID="TbCount" runat="server"  CssClass="text" Text='<%# Eval("count")%>'></asp:TextBox>
                                <asp:LinkButton ID="LinkUpdate" runat="server" CommandName="update" CommandArgument='<%# Eval("id")%>'>更新</asp:LinkButton>
                            </td>
                            <td><font>￥<%# Eval("amount")%></font></td>
                            <td>                
                                <asp:Button ID="BtnDelete" runat="server" Text="删除" CommandName="delete"  class="delete" CommandArgument='<%# Eval("id")%>'/>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>  
           </ContentTemplate>       
        </asp:UpdatePanel>        
    </table>
    
    <div class="Total">购物车商品总价格：<font>￥<%= Cart.GetTotalAmount() %></font> 比市场价格：<font>￥<%= Cart.GetMarketPriceTotalAmount() %></font>节省了：<span>￥<%= Cart.GetMarketPriceTotalAmount() - Cart.GetTotalAmount()%></span></div>
    </div>
    <!--购物车商品End-->
    
    <div class="btnDiv">
    <input type="button" name="button2" id="button2" value="继续购物" class="btn1" onfocus="this.blur()" onclick="window.location='<%=CommonClass.AppPath %>'"/>
    <asp:Button ID="BtnClear" runat="server" Text="清空购物车"  CssClass="btn2" 
            onfocus="this.blur()" onclick="BtnClear_Click"/>
    <input type="button" name="button2" id="button2" value="结算中心" class="btn1" onclick="location.href='ShoppingCart2.aspx'" onfocus="this.blur()"/>
    </div>
    
    
    <!--Content End-->     
    </div>
    <div class="BottomEdge"></div>
    </div>

<!--Footer-->
<yk:Bottom runat="server" />
<!--Footer End-->
    </form>
</body>
</html>
