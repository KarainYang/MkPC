<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProGroupBuy.ascx.cs" Inherits="Controls_ProGroupBuy" %>
<%@ Import Namespace="YK.Common" %>
<div class="Wrap_GroupBuy">
    <h3><span><a href="groupbuy/GroupBuy.aspx">更多>></a></span><b>团购</b></h3>
    <div class="Box">
      <%--<dl class="time">剩余<b>8661</b>小时<b>38</b>分<b>42</b>秒</dl>--%>
        <ul>
            <%
                foreach(YK.Model.TB_Product_Group entity in groupBuyList)
                {
                 %>                 
                 <li>
                  <h5><a href="groupbuy/GroupBuyDetails.aspx?id=<%=entity.ID %>" title="<%=entity.GroupName %>"><%=entity.GroupName.SubstringStr(15) %></a></h5>
                    <div class="buyPrice">
                    <font>
                        ￥<%=entity.GroupPrice %>
                        (<%=entity.Price==0 ? 0:(entity.GroupPrice / entity.Price).ToDecimal(2)*10 %>折)
                    </font>
                        <a href="groupbuy/GroupBuyDetails.aspx?id=<%=entity.ID %>" class="join"></a>
                    </div>
                    <div class="picture">
                        <a href="groupbuy/GroupBuyDetails.aspx?id=<%=entity.ID %>">
                            <img src="<%=entity.ImgUrl %>"  onerror="this.src='<%= YK.Common.CommonClass.AppPath %>style/red/images/nopic.jpg';"/>
                        </a>
                    </div>
                    <div class="txt"><%=entity.GroupName.SubstringStr(15) %></div> 
                    <div class="price"><span>市场价：</span><font>￥<%=entity.Price %></font></div>
                </li> 
            <%
                }
                     %>
        </ul>
    </div>
    <div class="BottomEdge"></div>
</div>