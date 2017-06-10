<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="product_List" %>
<%@ Import Namespace="YK.Common" %>
<%@ Import Namespace="YK.Model" %>
<%@ Import Namespace="System.Linq" %>

 <!--商品-->
<div class="Wrap_proList">
    <div class="Box"> 
        <ul id="prolist" class="list"> 
            <asp:Repeater ID="RepList" runat="server">
               <ItemTemplate>
                    <li>
                        <h5><a href="Product.aspx?id=<%# Eval("id") %>" title="<%# Eval("ProName") %>" target="_blank"><%# Eval("ProName").SubstringStr(15) %></a></h5>
                        <div class="icon"><img src="../style/red/images/icon_qiang.png" /></div>
                        <div class="picture">
                            <a href="product.aspx?id=<%# Eval("id") %>" target="_blank">
                                <img src="../<%# Eval("ImgUrl") %>"  onerror="this.src='<%= YK.Common.CommonClass.AppPath %>style/red/images/nopic.jpg';"/>
                            </a>
                        </div>
                        <div class="txt"><%# Eval("Introduction").SubstringStr(30)%></div>
                        <div class="price"><span>市场价：</span><s>￥<%# Eval("MarketPrice")%></s></div>
                        <div class="price2"><span>销售价：</span><font>￥<%# Eval("SalesPrice")%></font></div>
                        <div class="comment"><a href="#">已经有0人评价</a></div>
                        <div class="operate">                                    
                            <%--<asp:LinkButton runat="server" ID="LinkBtnBuy" CssClass="a_buy" ToolTip="购买" CommandName="buy" CommandArgument='<%# Eval("id") %>' OnClientClick="yk.checkLogin()==true?alert('购买成功'):alert('购买失败');return yk.checkLogin()" ></asp:LinkButton>
                            <asp:LinkButton runat="server" ID="LinkBtnFavorites" CssClass="a_favorites" ToolTip="收藏" CommandName="favorites" CommandArgument='<%# Eval("id") %>'  OnClientClick="yk.checkLogin()==true?alert('收藏成功'):alert('收藏失败');return yk.checkLogin();"></asp:LinkButton>
                            <asp:LinkButton runat="server" ID="LinkBtnBalance" CssClass="a_balance" ToolTip="对比" CommandName="balance" CommandArgument='<%# Eval("id") %>'  OnClientClick="return yk.checkLogin()"></asp:LinkButton>
                        --%>
                        </div>
                    </li> 
               </ItemTemplate>
            </asp:Repeater>                
        </ul>
    </div>
    <div class="BottomEdge"></div>
</div>
<!--商品End-->
        
<!--Page-->
<div class="Pages" runat="server" id="Pages">
    
</div>
<!--Page-->  