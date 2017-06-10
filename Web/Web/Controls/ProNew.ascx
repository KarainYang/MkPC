<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProNew.ascx.cs" Inherits="Controls_ProNew" %>
<%@ Import Namespace="YK.Model" %>
<%@ Import Namespace="YK.Common" %>

<div class="Wrap_New">
    <h3><span><a href="#">更多>></a></span><b>新品</b></h3>
    <div class="Box">
      <ul>
      
            <% 
               foreach (TB_Product_Products product in productList)
               { 
               %>
                    <li>
                        <h5>
                            <a href="<%= CommonClass.AppPath+"product/Product.aspx?id="+product.ID %>" title="<%=product.ProName %>">
                                <%=product.ProName.SubstringStr(20) %>
                            </a>
                        </h5>
                        <div class="picture">
                            <a href="<%= CommonClass.AppPath+"product/Product.aspx?id="+product.ID %>">
                                <img src="<%= CommonClass.AppPath+product.ImgUrl %>" onerror="this.src='<%= YK.Common.CommonClass.AppPath %>style/red/images/nopic.jpg';"/>
                            </a>
                        </div>
                        <div class="price"><span>市场价：</span><s>￥<%=product.MarketPrice %></s></div>
                        <div class="price2"><span>销售价：</span><font>￥<%=product.SalesPrice %></font></div>
                    </li> 
               <%
               }
                 %>
      </ul>
    </div>
    <div class="BottomEdge"></div>
</div>