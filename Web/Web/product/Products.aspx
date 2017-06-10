<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="product_Products" %>
<%@ Import Namespace="YK.Common" %>
<%@ Import Namespace="YK.Model" %>
<%@ Import Namespace="System.Linq" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta name="Author" content="">
    <title>网上商店</title>

    <link href="../style/red/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="../Scripts/pngimg.js"></script>
    <script type="text/javascript" src="../Scripts/yk.js"></script>
    <script language="javascript" type="text/javascript">
        var navId = <%= CommonClass.ReturnRequestInt("mark") == 1 ? "2" : CommonClass.ReturnRequestInt("mark") == 3?"4":"0"%>;
    </script>
</head>
<body  class="bgbody">
    <form id="form1" runat="server">
    <!--Hearer-->
        <yk:Top runat="server" />
<!--Hearer End-->
<div class="Contain">
    <!--商品分类-->
    <yk:ProCategory runat="server" />
    <!--商品分类End-->
    <div class="Current">当前位置：<a href="<%=YK.Common.CommonClass.AppPath+"index.aspx" %>">首页</a> -> <font>商品浏览</font></div>
    <!--Left-->
    <div class="Sidebar">
        <!--今日特价-->
        <yk:ProSpecials runat="server" />
        <!--今日特价End-->
                
        <div class="space"></div>        
       
        <!--新品-->
        <yk:ProNew runat="server" />
        <!--新品End-->
        
        <div class="space"></div>
        
        <!--热卖新品-->
        <yk:ProHotNew runat="server" />
        <!--热卖新品End-->
        
        <div class="space"></div>
        
        <!--最近浏览过的商品-->
        <yk:ProBrowse runat="server" />
        <!--最近浏览过的商品End-->

    </div>
    <!--Left End-->
    <!--Right Start--> 
    <div class="Maincontent">

        <!--筛选-->
        <div class="ProSelect">
        <h5>商品筛选</h5>
        <div class="term">
            <% string url= Server.UrlDecode(Request.Url.ToString()); %>
            <ul>
                <li>
                    <dd>品　　牌：</dd>
                    <dt>
                    <a href="<%= CommonClass.RemoveUrlParas(url,"brandId") %>" class="<%= Request.QueryString["brandId"]==null?"select":""  %>">全部</a> 
                    <%
                        int brandId=CommonClass.ReturnRequestInt("brandId");                        
                        foreach(TB_Product_Brands entity in brandList)
                        {
                         %>
                        <a href="<%=CommonClass.SetUrlParas(url,"brandId",entity.ID) %>" class="<%= brandId==entity.ID?"select":"" %>"><%=entity.BrandName %></a> 
                    <%
                        }
                     %>
                    </dt>
                </li>               
                <li>
                    <dd>商品价格：</dd>
                    <%
                        string paraList = "";
                        if (Request.QueryString["key"]!=null)
                        {
                            paraList += "key=" + Server.UrlEncode(Request.QueryString["key"].ToStr());
                        }
                        if (Request.QueryString["mark"] != null)
                        {
                            paraList += paraList == "" ? "" : "&";
                            paraList += "mark=" + Server.UrlEncode(Request.QueryString["mark"].ToStr());
                        }
                         %>
                    <dt>
                        <a href="<%= CommonClass.RemoveUrlParas(url,"min,max") %>" class="<%= Request.QueryString["min"]==null?"select":""  %>">全部</a>
                        <a href='<%= CommonClass.SetUrlParas(url,"min,max","0,1000") %>' class='<%= Request.QueryString["min"]=="0"?"select":""  %>'>1000元以下</a> 
                        <a href='<%= CommonClass.SetUrlParas(url,"min,max","1000,2000") %>' class='<%= Request.QueryString["min"]=="1000"?"select":""  %>'>1000-2000元</a> 
                        <a href='<%= CommonClass.SetUrlParas(url,"min,max","2000,3000") %>'  class='<%= Request.QueryString["min"]=="2000"?"select":""  %>'>2000--3000元</a> 
                        <a href='<%= CommonClass.SetUrlParas(url,"min,max","3000,4000") %>' class='<%= Request.QueryString["min"]=="3000"?"select":""  %>'>3000--4000元</a> 
                        <a href='<%= CommonClass.SetUrlParas(url,"min,max","4000,5000") %>' class='<%= Request.QueryString["min"]=="4000"?"select":""  %>'>4000-5000元</a> 
                        <a href='<%= CommonClass.SetUrlParas(url,"min,max","5000,6000") %>' class='<%= Request.QueryString["min"]=="5000"?"select":""  %>'>5000--6000元</a> 
                        <a href='<%= CommonClass.RemoveUrlParas(CommonClass.SetUrlParas(url,"min",6000),"max") %>' class='<%= Request.QueryString["min"]=="6000"?"select":""  %>'>6000元以上</a>
                    </dt>
              </li>
            </ul>
        </div>
        <div class="result">
            查询条件： <font>
            <%= Request.QueryString["key"] %> 
            <%= brandList.Where(b => b.ID == brandId).Count() ==0 ? "" : brandList.Where(b => b.ID == brandId).First().BrandName %> 
            <%= Request.QueryString["min"] != null ? Request.QueryString["min"] + "--" : ""%>
            <%= Request.QueryString["max"] %>
            </font>
        <a href="<%= CommonClass.RemoveUrlParas(url,"min,max,brandId")%>">[ 重置查询条件 ]</a>
        </div>
        </div>
        <!--筛选End-->
        
        <!--排序-->
        <div class="ProSort">
            <h5>搜索结果(<%=AspNetPager1.RecordCount %>)</h5>
            <div class="sort">
                <font>排序：</font>
                <span><b>销量</b></span>
                <span class='<%= Request.QueryString["orderBy"]=="price"?"select":""  %>' onclick="window.location='<%= CommonClass.SetUrlParas(url,"orderBy","price") %>'"><b>价格</b></span>
                <span  class='<%= Request.QueryString["orderBy"]=="date"?"select":""  %>' onclick="window.location='<%= CommonClass.SetUrlParas(url,"orderBy","date") %>'"><b>上架时间</b></span>
                <font>显示方式：</font>
                <a onclick="jQuery('#prolist').attr('class','list')" class="show_list"></a>
                <a onclick="jQuery('#prolist').attr('class','block')" class="show_block"></a>
            </div>
            <div class="page">
                <span>第<%= AspNetPager1.CurrentPageIndex %>页，共<%= AspNetPager1.PageCount %>页</span>
                <yk:AspNetPager runat="server" ID="AspNetPager2" PageSize="12" PrevPageText="上一页" NextPageText="下一页"
                    ShowFirstLast="false" ShowPageIndex="false" onpagechanging="AspNetPager1_PageChanging"></yk:AspNetPager>   
                    <%--<a href="#" class="aprev agray">上一页</a>
                    <a href="#" class="anext">下一页</a>--%>
            </div>
            <script language="javascript">
                $(".page a").each(function(index){
                    if(index==0)
                    {
                        this.className="aprev";
                    }
                    else
                    {
                        this.className="anext";
                    }
                });
            </script>
            <div class="total">共37个商品</div>
        </div>
        <!--排序End-->
            
        <!--商品-->
        <div class="Wrap_proList">
            <div class="Box">             
             <ul id="prolist" class="list">             
                <asp:Repeater ID="RepList" runat="server" onitemcommand="RepList_ItemCommand">
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
                                    <asp:LinkButton runat="server" ID="LinkBtnBuy" CssClass="a_buy" ToolTip="购买" CommandName="buy" CommandArgument='<%# Eval("id") %>' OnClientClick="yk.checkLogin()==true?alert('购买成功'):alert('购买失败');return yk.checkLogin()" ></asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="LinkBtnFavorites" CssClass="a_favorites" ToolTip="收藏" CommandName="favorites" CommandArgument='<%# Eval("id") %>'  OnClientClick="yk.checkLogin()==true?alert('收藏成功'):alert('收藏失败');return yk.checkLogin();"></asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="LinkBtnBalance" CssClass="a_balance" ToolTip="对比" CommandName="balance" CommandArgument='<%# Eval("id") %>'  OnClientClick="return yk.checkLogin()"></asp:LinkButton>
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
        <div class="Pages">
            <div class="page_total">目前在第<span><%=AspNetPager1.CurrentPageIndex %></span>页，共有<span><%=AspNetPager1.PageCount %></span>页，共有<span><%=AspNetPager1.RecordCount %></span>条记录</div>
            <div class="page_num">
                <yk:AspNetPager runat="server" ID="AspNetPager1" PageSize="12" NumericButtonCount="3" ShowPageIndexBox="Always"
                    SubmitButtonText=" 确定 " SubmitButtonClass="button" PageIndexBoxClass="text"
                    PrevPageText="上一页" NextPageText="下一页" FirstPageText="首页" LastPageText="末页" 
                    onpagechanging="AspNetPager1_PageChanging"></yk:AspNetPager>   
            </div>               
                    
        </div>
        <!--Page-->  
  </div>     
  <!--Right End-->
  <div class="clear"></div>
</div>
<!--Help-->
    <yk:Help runat="server" />
<!--Help End-->
<!--Footer-->
    <yk:Bottom runat="server" />
<!--Footer End-->
    </form>
</body>
</html>
