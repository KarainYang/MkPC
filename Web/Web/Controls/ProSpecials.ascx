<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProSpecials.ascx.cs" Inherits="Controls_ProSpecials" %>
<%@ Import Namespace="YK.Common" %>

<div class="Wrap_Specials">
    <h3><span><a href="#">更多>></a></span><b>今日特价</b></h3>
    <div class="Box">
      <ul>
        <%
            foreach(YK.Model.TB_Product_Products entity in list)
            {
             %>
        <li>
            <h5>
                <a href="<%= CommonClass.AppPath+"product/Product.aspx?id="+ entity.ID %>" title="<%= entity.ProName %>">
                    <%= entity.ProName.SubstringStr(30) %>
                </a>
            </h5>
            <div class="picture">
                <a href="<%= CommonClass.AppPath+"product/Product.aspx?id="+ entity.ID %>">
                    <img src="<%= CommonClass.AppPath+ entity.ImgUrl %>"  onerror="this.src='<%= CommonClass.AppPath %>style/red/images/nopic.jpg';"/>
                </a>
            </div>
            <div class="txt"><%= entity.Introduction.SubstringStr(30) %></div>
            <div class="price"><span>市场价：</span><s>￥<%= entity.MarketPrice %></s></div>
            <div class="price2"><span>销售价：</span><font>￥<%= entity.SalesPrice %></font></div>
            <div class="comment"><a href="<%= CommonClass.AppPath+"product/Product.aspx?id="+ entity.ID %>#comment">已经有<%=GetCoummentCount(entity.ID)%>人评价</a></div>
        </li>
        <%
            }
         %>       
      </ul>
    </div>
    <div class="BottomEdge"></div>
</div>