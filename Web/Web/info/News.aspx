<%@ Page Language="C#" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="info_News" %>

<%@ Import Namespace="YK.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta name="Author" content="">
    <title>梦科网络商城系统</title>
    <script type="text/javascript" src="../Scripts/jquery-1.4.2.min.js"></script>
    <link href="../style/red/css_member.css" rel="stylesheet" type="text/css" />
</head>

<body class="bgbody">
    <form id="form1" runat="server">
    <!--Hearer-->
        <yk:Top ID="Top1" runat="server" />
    <!--Hearer End-->
<div class="Contain">
    <!--商品分类-->
    <yk:ProCategory ID="ProCategory1" runat="server" />
    <!--商品分类End-->
    <div class="Current">当前位置：<a href="<%=YK.Common.CommonClass.AppPath+"index.aspx" %>">首页</a> > <font>信息中心</font></div>
    <!--Left-->
    <div class="Sidebar">
        <!--Menu-->
        <yk:NewsMenu ID="NewsMenu1" runat="server" />
        <!--MenuEnd-->               
    </div>
    <!--Left End-->
    <!--Right Start--> 
    <div class="Maincontent">
      <div class="Main" style="border:1px solid #F5F5F5; padding:10px;">
      <!--Content Start-->
              <ul>
                <yk:Repeater runat="server" ID="RepList">
                    <ItemTemplate>
                        <li><a href="NewsDetails.aspx?id=<%# Eval("ID") %>"><%# Eval("Title") %></a></li>
                    </ItemTemplate>
                </yk:Repeater>
              </ul>
              
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
      <!--Content End-->    
      </div>
      <div class="BottomEdge"></div>        
  </div>     
  <!--Right End-->
  <div class="clear"></div>
</div>

<!--Footer-->
    <yk:Bottom ID="Bottom1" runat="server" />
<!--Footer End-->
    </form>
</body>
</html>