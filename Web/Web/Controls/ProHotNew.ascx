<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProHotNew.ascx.cs" Inherits="Controls_ProHotNew" %>
<%@ Import Namespace="YK.Model" %>
<%@ Import Namespace="YK.Common" %>

<div class="Wrap_HotNew">
    <h3><span><a href="#">更多>></a></span><b>热卖新品</b></h3>
    <div class="Box">
      <ul>
            <% 
                int i=0;
               foreach (TB_Product_Products product in productList)
               { 
                   i++;
               %>
                <li>
                        <h5>
                            <em><%=i %></em>
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
<script type="text/javascript">
$(".Wrap_HotNew li").each(function(){
    $(this).attr("class","show");
//    if($(this).index() <= 2){
//        $(this).attr("class","show");
//    } else {
//        $(this).attr("class","hide");

//    }
});
</script>