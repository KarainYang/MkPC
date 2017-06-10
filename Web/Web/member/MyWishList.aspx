<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyWishList.aspx.cs" Inherits="member_MyWishList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta name="Author" content="梦科商城">
    <title>梦科商城</title>

    <link href="../style/red/css_member.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/jquery-1.4.2.min.js"></script>
    <script language="javascript" type="text/javascript">
       var submenu= '34'
    </script>
</head>

<body class="bgbody">
    <form id="form1" runat="server">
    <!--Hearer-->
<yk:Top runat="server" />
<!--Hearer End-->
<div class="Contain">
    <!--商品分类-->
    <yk:ProCategory runat="server" />
    <!--商品分类End-->
    <div class="Current">当前位置：<a href="<%=YK.Common.CommonClass.AppPath+"index.aspx" %>">首页</a> > <font>会员中心</font></div>
    <!--Left-->
    <div class="Sidebar">
        <!--Menu-->
        <yk:MemberMenu runat="server" />
        <!--MenuEnd-->               
    </div>
    <!--Left End-->
    <!--Right Start--> 
    <div class="Maincontent">  
      
      <h3 class="Title">收藏夹</h3>
      
      <div class="Main">
      <!--Content Start-->
        
        <div class="mywishlist_form">
            
            <div class="interesting_form">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="mytable">
              <tr class="item">
                <td><input type="checkbox" onclick="checkAll(this.checked)" /> 全选</td>
                <td>商品图片</td>
                <td>商品名称</td>
                <td>收藏时间</td>
                <td>单价</td>
              </tr>
              <tr>
              <% foreach(YK.Model.TB_Product_Products entity in prolist){ %>
                <td><dt class="checkbox"><input type="checkbox" name="pid" value="<%=entity.ID %>" /></dt></td>
                <td>
                    <dt class="pro">
                        <a href="<%= YK.Common.CommonClass.AppPath+ "product/product.aspx?id="+entity.ID %>">
                            <img src="<%= YK.Common.CommonClass.AppPath+ entity.ImgUrl %>" />
                        </a>
                    </dt>
                </td>
                <td>
                    <dt class="name">
                        <a href="<%= YK.Common.CommonClass.AppPath+ "product/product.aspx?id="+entity.ID %>">
                            <%=entity.ProName %>
                        </a>
                    </dt>                
                </td>
                <td>
                    <dt class="time"><%=entity.AddDate %></dt>
                </td>
                <td><dt class="money">￥<%=entity.SalesPrice %></dt></td>
              </tr>   
              <% } %>           
            </table>
            <script language="javascript" type="text/javascript">
                function checkAll(obj) {
                    $("input[name='pid']").each(function () {
                        this.checked = obj;
                    })
                }
            </script>
            <div class="whole">
                <yk:Button runat="server" ID="BtnAddCart" CssClass="btn_inCar"  Text="加入购物车" OnClick="BtnAddCart_Click" />
                <yk:Button runat="server" ID="BtnDelete" CssClass="btn_inTotal"  Text="删 除" OnClick="BtnDelete_Click" />
            </div>     
    </div>
 
    <!--Page-->
        <div class="Pages">
            <div class="page_total">目前在第<span><%=AspNetPager1.CurrentPageIndex %></span>页，共有<span><%=AspNetPager1.PageCount %></span>页，共有<span><%=AspNetPager1.RecordCount %></span>条记录</div>
            <div class="page_num">
                <yk:AspNetPager runat="server" ID="AspNetPager1" PageSize="3" NumericButtonCount="3" ShowPageIndexBox="Always"
                    SubmitButtonText=" 确定 " SubmitButtonClass="button" PageIndexBoxClass="text"
                    PrevPageText="上一页" NextPageText="下一页" FirstPageText="首页" LastPageText="末页" 
                    onpagechanging="AspNetPager1_PageChanging"></yk:AspNetPager>   
            </div>               
                    
        </div>
        <!--Page-->  

        </div> 
       
      <!--Content End-->     
      </div>
      <div class="BottomEdge"></div> 
    </div>      
  <!--Right End-->
  <div class="clear"></div>
</div>

<!--Footer-->
<yk:Bottom runat="server" />
<!--Footer End-->
    </form>
</body>
</html>
