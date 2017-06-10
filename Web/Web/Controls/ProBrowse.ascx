<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProBrowse.ascx.cs" Inherits="Controls_ProBrowse" %>
<%@ Import Namespace="YK.Model" %>
<div class="Wrap_Browse">
    <h3><%--<span><a href="#">清空>></a></span>--%><b>最近浏览过的商品</b></h3>
    <div class="Box">
      <ul>
        <%
            foreach (TB_Product_Products entity in productList)
            {
             %>
        <li>
            <h5><a href="<%= YK.Common.CommonClass.AppPath+"product/product.aspx?id="+entity.ID %>" title="<%= entity.ProName %>"><%= entity.ProName %></a></h5>
            <div class="picture">
                <a href="<%= YK.Common.CommonClass.AppPath+"product/product.aspx?id="+entity.ID %>">
                    <img src="<%= YK.Common.CommonClass.AppPath+entity.ImgUrl %>"  onerror="this.src='<%= YK.Common.CommonClass.AppPath %>style/red/images/nopic.jpg';"/>
                </a>
            </div>
        </li>
        <%
            }
         %>
      </ul>
    </div>
    <div class="BottomEdge"></div>
</div>