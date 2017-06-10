<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>
<%@ Import Namespace="YK.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta name="Author" content="">
    <title>网上商店</title>

    <link href="style/red/home.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Scripts/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="Scripts/pngimg.js"></script>
    <script language="javascript" type="text/javascript">
        var navId = 1;
    </script>
</head>
<body class="bgbody">
    <form id="form1" runat="server">
    <!--Hearer-->
    <yk:Top runat="server"></yk:Top>
    <!--Hearer End-->
<div class="Contain">
    <!--Left-->
    <div class="Sidebar">
        <!--商品分类-->
        <yk:ProCategory runat="server" IsHome="true"></yk:ProCategory>
        <!--商品分类End-->
                
        <div class="space"></div>
        
        <!--热销品牌-->
        <yk:ProBrand runat="server"></yk:ProBrand>
        <!--热销品牌End-->
                
        <div class="space"></div>
        
        <!--商品点评-->
        <yk:ProHotNew runat="server"></yk:ProHotNew>
        <!--商品点评End-->
        
        <!--广告-->
       <%-- <div class="ad_space"><img src="style/red/images/temp/pic15.jpg" width="210" height="94" /></div>--%>
        <!--广告End-->
    </div>
    <!--Left End-->
    <!--Mid-->
    <div class="Maincontent">
    <!--幻灯片广告-->
    <div class="SlideShow">
        <yk:Adver ID="Adver1" runat="server" Code="home0001" />
        <div style=" clear:both;"></div>
    </div>
    
    <!--幻灯片广告End-->
    <!--推荐商品-->
        <div class="Wrap_Recommend" id="AutoTable1">
            <h3><span><a href="product/Products.aspx?mark=2">更多>></a></span><b>推荐商品</b></h3>
            <h2>
            <span>1</span>
            <span>2</span>
            <span>3</span>
            <span>4</span>
            </h2>
            <div name="AutoContent" class="Box">
              <!--1-->
              <div>
              <ul>
                  <asp:Repeater ID="RepVouchList" runat="server">
                       <ItemTemplate>
                            <li>
                                <h5><a href="product/Product.aspx?id=<%# Eval("id") %>" title="<%# Eval("ProName") %>" target="_blank"><%# Eval("ProName").SubstringStr(15)%></a></h5>
                                <div class="picture">
                                    <a href="product/product.aspx?id=<%# Eval("id") %>" target="_blank">
                                        <img src="<%# Eval("ImgUrl") %>"  onerror="this.src='<%= YK.Common.CommonClass.AppPath %>style/red/images/nopic.jpg';"/>
                                    </a>
                                </div>
                                <div class="txt"><%# Eval("Introduction").SubstringStr(30)%></div>
                                <div class="price"><span>市场价：</span><s>￥<%# Eval("MarketPrice")%></s></div>
                                <div class="price2"><span>销售价：</span><font>￥<%# Eval("SalesPrice")%></font></div>
                            </li> 
                       </ItemTemplate>
                  </asp:Repeater>                
              </ul>
              </div>
              <!--1End-->
              <!--2-->
              <div style="display:none;">
              <ul>
                  <asp:Repeater ID="RepVouchList2" runat="server">
                       <ItemTemplate>
                            <li>
                                <h5><a href="product/product.aspx?id=<%# Eval("id") %>" title="<%# Eval("ProName") %>"><%# Eval("ProName").SubstringStr(15) %></a></h5>
                                <div class="picture">
                                    <a href="product/product.aspx?id=<%# Eval("id") %>">
                                        <img src="<%# Eval("ImgUrl") %>"  onerror="this.src='<%= YK.Common.CommonClass.AppPath %>style/red/images/nopic.jpg';"/>
                                    </a>
                                </div>
                                <div class="txt"><%# Eval("Introduction").SubstringStr(30)%></div>
                                <div class="price"><span>市场价：</span><s>￥<%# Eval("MarketPrice")%></s></div>
                                <div class="price2"><span>销售价：</span><font>￥<%# Eval("SalesPrice")%></font></div>
                            </li> 
                       </ItemTemplate>
                  </asp:Repeater>                
              </ul>
              </div>
              <!--2End-->
              <!--3-->
              <div style="display:none;">
              <ul>
                  <asp:Repeater ID="RepVouchList3" runat="server">
                       <ItemTemplate>
                            <li>
                                <h5><a href="product/product.aspx?id=<%# Eval("id") %>" title="<%# Eval("ProName") %>" target="_blank"><%# Eval("ProName").SubstringStr(15)%></a></h5>
                                <div class="picture">
                                    <a href="product/product.aspx?id=<%# Eval("id") %>" target="_blank">
                                        <img src="<%# Eval("ImgUrl") %>"  onerror="this.src='<%= YK.Common.CommonClass.AppPath %>style/red/images/nopic.jpg';"/>
                                    </a>
                                </div>
                                <div class="txt"><%# Eval("Introduction").SubstringStr(30)%></div>
                                <div class="price"><span>市场价：</span><s>￥<%# Eval("MarketPrice")%></s></div>
                                <div class="price2"><span>销售价：</span><font>￥<%# Eval("SalesPrice")%></font></div>
                            </li> 
                       </ItemTemplate>
                  </asp:Repeater>                
              </ul>
              </div>
              <!--3End-->
              <!--4-->
              <div style="display:none;">
              <ul>
                  <asp:Repeater ID="RepVouchList4" runat="server">
                       <ItemTemplate>
                            <li>
                                <h5><a href="product/product.aspx?id=<%# Eval("id") %>" title="<%# Eval("ProName") %>" target="_blank"><%# Eval("ProName").SubstringStr(15)%></a></h5>
                                <div class="picture">
                                    <a href="product/product.aspx?id=<%# Eval("id") %>" target="_blank">
                                        <img src="<%# Eval("ImgUrl") %>"  onerror="this.src='<%= YK.Common.CommonClass.AppPath %>style/red/images/nopic.jpg';"/>
                                    </a>
                                </div>
                                <div class="txt"><%# Eval("Introduction").SubstringStr(30)%></div>
                                <div class="price"><span>市场价：</span><s>￥<%# Eval("MarketPrice")%></s></div>
                                <div class="price2"><span>销售价：</span><font>￥<%# Eval("SalesPrice")%></font></div>
                            </li> 
                       </ItemTemplate>
                  </asp:Repeater>                
              </ul>
              </div>
              <!--4End-->
            </div>
            <div class="BottomEdge"></div>
        </div>
        <!--推荐商品End-->
        
        <div class="space"></div>
        <!--特价专区一-->
        <div class="Wrap_Specials">
            <h3><span><a href="product/Products.aspx?mark=3">更多>></a></span><b>特价专区</b></h3>
            <div class="Box">            
                <ul>
                  <asp:Repeater ID="RepSpecialsOne" runat="server">
                       <ItemTemplate>
                            <li>
                                <h5><a href="product/product.aspx?id=<%# Eval("id") %>" title="<%# Eval("ProName") %>" target="_blank"><%# Eval("ProName").SubstringStr(15)%></a></h5>
                                <div class="picture">
                                    <a href="product/product.aspx?id=<%# Eval("id") %>" target="_blank">
                                        <img src="<%# Eval("ImgUrl") %>"  onerror="this.src='<%= YK.Common.CommonClass.AppPath %>style/red/images/nopic.jpg';"/>
                                    </a>
                                </div>
                                <div class="txt"><%# Eval("Introduction").SubstringStr(30)%></div>
                                <div class="price"><span>市场价：</span><s>￥<%# Eval("MarketPrice")%></s></div>
                                <div class="price2"><span>销售价：</span><font>￥<%# Eval("SalesPrice")%></font></div>
                            </li> 
                       </ItemTemplate>
                  </asp:Repeater>                
              </ul>
            </div>
            <div class="BottomEdge"></div>
        </div>
        <!--特价专区一End-->
        
       
  </div>
  <!--Mid-->
    <!--Right Start-->
  <div class="Rightsidebar">
        <!--商店公告-->
        <yk:ProBulletin runat="server"></yk:ProBulletin>
        <!--商店公告End-->
        
        <!--广告-->
        <div class="ad_space"><img src="style/red/images/temp/pic05.jpg" width="216" height="90" /></div>
        <!--广告End-->
        
        <div class="space"></div>
        
        <!--团购-->
        <yk:ProGroupBuy runat="server"></yk:ProGroupBuy>
        <!--团购End-->
        
        <!--广告-->
        <div class="ad_space"><img src="style/red/images/temp/pic10.jpg" width="216" height="84" /></div>
        <!--广告End-->
    </div>
    <!--Right End-->
  <div class="clear"></div>
</div>

<yk:Repeater runat="server" ID="RepVouchCategory" OnItemDataBound="RepVouchCategory_DataBind">
    <ItemTemplate>
        <%
            num++;
             %>
        <div class="HomeCategory">
            <div class="CategoryList">
                <ul>
                    <li class="c1"><a href="#"><%# Eval("CategoryName") %></a></li>
                    <li><a href="#">手机通讯</a></li>
                    <li><a href="#">数码影像</a></li>
                    <li><a href="#">数码配件</a></li>
                    <li><a href="#">数码配件</a></li>
                </ul>
            </div>
            <yk:CategoryAdver runat="server" ProCategoryId='<%# Eval("id") %>' />     

            <asp:HiddenField runat="server" ID="HiddenFieldCategoryId" Value='<%# Eval("id") %>' />
            <ul>
                <yk:Repeater runat="server" ID="RepProList">
                    <ItemTemplate>
                            <li title="<%# Eval("Introduction") %>">                               
                                <div class="picture">
                                    <a href="product/product.aspx?id=<%# Eval("id") %>" target="_blank">
                                        <img src="<%# Eval("ImgUrl") %>"  onerror="this.src='<%= YK.Common.CommonClass.AppPath %>style/red/images/nopic.jpg';"/>
                                    </a>
                                </div>
                                <div class="txt">
                                    <a href="product/product.aspx?id=<%# Eval("id") %>" target="_blank">
                                        <%# Eval("Introduction").SubstringStr(30)%>
                                    </a>
                                </div>
                                <div class="price2"><span>销售价：</span><font>￥<%# Eval("SalesPrice")%></font></div>
                            </li> 
                    </ItemTemplate>
                </yk:Repeater>
            </ul>   
        </div>
    </ItemTemplate>
</yk:Repeater>

<!--Help-->
<yk:Help runat="server"></yk:Help>
<!--Help End-->
<!--Footer-->
<yk:Bottom runat="server"></yk:Bottom>
<!--Footer End-->
<script type="text/javascript" src="scripts/tab.js"></script>
<script type="text/javascript">
AutoTables("AutoTable1");
</script>
<script type="text/javascript">
	  jQuery(".hideMenu").attr("class","");
</script>
    </form>
</body>
</html>
