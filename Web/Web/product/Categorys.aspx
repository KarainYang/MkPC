<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Categorys.aspx.cs" Inherits="product_Categorys" %>
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
    <script language="javascript" type="text/javascript">
        var navId = 0;
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
    <div class="Current">当前位置：<a href="<%=YK.Common.CommonClass.AppPath+"index.aspx" %>">首页</a> -> <font>所有类别</font></div>
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
            <h5>类别大全</h5>
            <div class="term">
                <ul>
                    <% foreach (TB_Product_Categorys entity in categorysList.Where(c=>c.ParentID==0).OrderBy(c=>c.OrderBy))
                       { %>
                            <li>
                               <dd onclick="window.location='Products.aspx?categoryId=<%=entity.ID %>'" style="width:150px; cursor:pointer" ><%=entity.CategoryName %>：</dd>                            
                            </li>                             
                                
                                <% 
                                    foreach (TB_Product_Categorys entity2 in categorysList.Where(c => c.ParentID == entity.ID).OrderBy(c => c.OrderBy))
                                    {
                                %>
                                    <li>
                                        <dd style="width:138px;">&nbsp;</dd>
                                        <dt style="width:500px; cursor:pointer">
                                                <a href="Products.aspx?categoryId=<%=entity2.ID %>"><%=entity2.CategoryName %>：</a> 
                                                <% 
                                                    foreach (TB_Product_Categorys entity3 in categorysList.Where(c => c.ParentID == entity2.ID).OrderBy(c => c.OrderBy))
                                                    {
                                                %>
                                                <a href="Products.aspx?categoryId=<%=entity3.ID %>"><%=entity3.CategoryName%></a>
                                                <%
                                                    }
                                                         %>
                                                <br />
                                         </dt>
                                    </li> 
                                <%
                                    }
                                 %>                               
                        <%
                        }
                            %>
                </ul>
            </div>
        </div>
        <!--筛选End-->    
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
