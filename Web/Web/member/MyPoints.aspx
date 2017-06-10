<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyPoints.aspx.cs" Inherits="member_MyPoints" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta name="Author" content="梦科商城">
    <title>梦科商城</title>

    <link href="../style/red/css_member.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/jquery-1.4.2.min.js"></script>
    <script src="../Admin/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    
    <script language="javascript" type="text/javascript">
       var submenu= '24'
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
      
      <h3 class="Title">我的积分</h3>
      
      <div class="Main">
      <!--Content Start-->
      <!--Search-->
      <div class="proSearch" style="text-align:right; padding-right:60px;">
      开始时间：<yk:TextBox runat="server" ID="TbStartDate"  onfocus="this.value=''"  Text="请输入时间" onclick="WdatePicker()"></yk:TextBox>
      结束时间：<yk:TextBox runat="server" ID="TbStopDate"  onfocus="this.value=''"  Text="请输入时间" onclick="WdatePicker()"></yk:TextBox>
      <input type="submit" name="button3" id="button3" value="查询" class="search" />
      </div>
      <!--Search End-->
      
        <div class="pointsTotal">您当前的积分：<font><%=member.Integrate%></font>分</div>
        
        <div class="mypoints_form">
            
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="mytable">
              <tr class="item">
                <td>时间</td>
                <td>积分</td>
                <td>详细说明</td>
              </tr>
              <% foreach (YK.Model.TB_Member_Intergral entity in list)
                 { %>
              <tr>
                <td><%= entity.AddDate %></td>
                <td><%= entity.Intergral %></td>
                <td><%= entity.Remark %></td>
              </tr>
              <% } %>
            </table>   
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
