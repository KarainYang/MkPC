<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Top.ascx.cs" Inherits="Controls_Top" %>
<%@ Import Namespace="YK.Common" %>

<script language="javascript" type="text/javascript">
            function search() {
                var key=$("#tbKey").val()=="请输入商品关键词"?"":$("#tbKey").val();
                window.location = '<%= CommonClass.AppPath+"product/Products.aspx" %>?key=' + escape(key);
            }
        </script>

<div class="Header">
    <div class="Header_welcome">
    <% 
        if(memberName!=null){ 
    %>
        <%=memberName %>您好，欢迎来到梦科网络商城系统！
    <% 
        } 
    %>
   
    </div>    
    <div class="Header_nav">
        <% 
            if(memberName==null){ 
        %>
            <a href="<%=CommonClass.AppPath %>member/login.aspx">请登录</a> | 
            <a href="<%=CommonClass.AppPath %>member/register.aspx">免费注册</a> |             
        <% 
            } 
            else
            {
        %>
            <a href="<%=CommonClass.AppPath %>member/Index.aspx">会员中心</a> | 
            <a href="<%=CommonClass.AppPath %>member/LoginOut.aspx">退出</a> | 
        <% 
            } 
        %>
        <a href="<%=CommonClass.AppPath %>info/help.aspx">帮助中心</a>
    </div>
    
    
    <div class="Top_SLbox" style="clear:both;">
     <div class="Wrap_logo"><a href="<%= CommonClass.AppPath+"index.aspx" %>"><img src="<%= CommonClass.AppPath %>style/red/images/logo.jpg" /></a></div>
     <div class="Top_seacher">
         <table cellpadding="0" cellspacing="0" border="0">
             <tr>
                  <td><input id="tbKey" type="text" class="top_sinput" value="请输入商品关键词" onfocus="this.value=''"/></td>
                  <td><input id="Button1" type="button" value="" class="top_sbtn" onfocus="this.blur()"  onclick="search()"/></td>
             </tr>
         </table>
    </div>
     <div class="Top_tel"><span>服务热线：</span><em style="color:#C80104; font-style:italic;">13829725842</em></div>
  </div>
    
    
    <div class="Header_mainnav">
        <ul>
            <li id="nav1"><a href="<%= CommonClass.AppPath+"index.aspx" %>"><em>首 页</em></a></li>
            <li id="nav2"><a href="<%= CommonClass.AppPath+"product/Products.aspx?mark=1" %>"><em>折扣专区</em></a></li>
            <li id="nav3"><a href="<%= CommonClass.AppPath+"groupbuy/GroupBuy.aspx" %>"><em>团购</em></a></li>
            <li id="nav4"><a href="<%= CommonClass.AppPath+"product/Products.aspx?mark=3" %>"><em>特价专区</em></a></li>
            <li id="nav5"><a href='<%= CommonClass.AppPath+"activity/ActivityList.aspx" %>'><em>促销活动</em></a></li>
        </ul>
        <script language="javascript" type="text/javascript">
            try {
                if (navId > 0) {
                    document.getElementById("nav" + navId).className = "current";
                }
            }
            catch (e) {
            }
        </script>
    </div>    
    <%--搜索模块--%>
    <div class="Header_search" style="display:none;" >
        <input name="textfield" type="text" class="text" id="tbKey" value="请输入商品关键词" onfocus="this.value=''"/>
        <input type="button" name="button" id="button" value="" class="search" onclick="search()" />        
    </div>
    <%--热门关键字--%>
    <div class="Header_keyword" ><font>热门：</font> 
        <%
            foreach(YK.Model.TB_Info_HotSearch entity in hotSearch)
            {
             %>
            <a href="<%=CommonClass.AppPath+"product/products.aspx?key="+ entity.KeyWord %>"><%=entity.KeyWord %></a> | 
        <%
            }
             %>
    </div>
    <% if(memberName!=null){ %>
    <div class="Header_cart">
        <div class="piece">购物车<font><yk:Label runat="server" ID="LbTopCount"></yk:Label></font>件</div>        
        <!--下拉窗-->
        <div class="dropDown">
             <div class="window"><a href="#" class="arrow"></a>                
                <div class="cart">
                <%
                    if(cartDs.Tables.Count==0)
                    {
                 %>
                <div class="tips">
                    您的购物车还是空的，赶紧行动吧！
                    <a href="<%= CommonClass.AppPath+"product/products.aspx" %>">
                        <em>去购物</em>
                    </a>
                </div>
                <% 
                    }
                    else
                    { 
                %>
                <!--弹出窗购物车Start-->
                <div class="txt">
                <ul>
                    <yk:Repeater runat="server" ID="RepCart" onitemcommand="RepCart_ItemCommand">
                        <ItemTemplate>
                             <li>
                                <h5><a href="<%= CommonClass.AppPath %>product/product.aspx?id=<%# Eval("id") %>"><%# Eval("name") %></a></h5>
                                <div class="picture"><a href="#"><img src="<%# CommonClass.AppPath+ Eval("img") %>" /></a></div>            
                                <p>
                                    <b>￥<%# Eval("price") %>×<%# Eval("count") %></b>
                                    <br><asp:LinkButton runat="server" ID="LinkBtnDelete" CommandArgument='<%# Eval("id") %>' CommandName="delete">删除</asp:LinkButton>
                                </p>
                            </li>   
                        </ItemTemplate>
                    </yk:Repeater>
                </ul>
                <dl class="total">共 <b> <yk:Label runat="server" ID="LbCount"></yk:Label></b> 件商品　金额总计：<b>￥<yk:Label runat="server" ID="LbAmount"></yk:Label></b></dl>
                <dl class="pay"><a href="<%= CommonClass.AppPath+"order/ShoppingCart.aspx" %>">去购物车并结算</a></dl>
                </div>
                <!--弹出窗购物车End-->
                <% 
                    } 
                %>
                </div>        
             </div>
        </div>
        <script type="text/javascript">
		        $(".window").bind("mouseover",function(){
			        $(this).children("a").attr("class","arrow");
			        $(this).children(".cart").show();
			
		        }).bind("mouseout",function(){
			        $(this).children(".cart").hide();
			        $(this).children("a").attr("class","arrow");
		        })
        </script>
        <!--下拉窗End-->
        <%
            if(cartDs.Tables.Count>0){
            %>
                <div class="payment">
                    <a href="<%= CommonClass.AppPath+"order/ShoppingCart2.aspx" %>">
                        <em>去结算</em>
                    </a>
                </div>
        <%
            }
         %>
    </div>
    <% } %>
</div>