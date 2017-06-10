<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyMoney.aspx.cs" Inherits="member_MyMoney" %>

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
       var submenu= '23'
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
      
      <h3 class="Title">虚拟货币</h3>
      
      <div class="Main">
      <!--Content Start-->
      <div class="moneyTotal">
      当前您的账号余额：<font>￥<%= member.AccountMoney %></font> 锁定余额：<font>￥<%= member.AccountMoney %></font> 账号状态：<font>有效</font>
      </div>

      <div class="mymoney_form" id="AutoTable1">
        <h2 class="tab">
            <span><b>近三个月记录 </b></span>
            <span><b>三个月前记录</b></span>
        </h2>
        <div class="Box" name="AutoContent">
            <!--1-->
            <div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="mytable">
              <tr class="item">
                <td>时间</td>
                <td>存入</td>
                <td>支出</td>
                <td>备注</td>
              </tr>
              <%
                  foreach (YK.Model.TB_Member_TransRecord entity in list)
                  {
                   %>  
                  <tr>
                    <td class="time"><dt><%=entity.AddDate %></dt></td>
                    <td class="money"><dt><%=entity.TransType==0?("￥"+entity.Amount.ToString()):"" %></dt></td>
                    <td class="money"><dt><%=entity.TransType==1?("￥"+entity.Amount.ToString()):"" %></dt></td>
                    <td class="remark"><dt><%=entity.Remark %></dt></td>
                  </tr>
              <%
                  }
                   %>          
            </table>
            <!--Page-->
            <div class="Pages">
                <div class="page_total">目前在第<span><%=AspNetPager1.CurrentPageIndex %></span>页，共有<span><%=AspNetPager1.PageCount %></span>页，共有<span><%=AspNetPager1.RecordCount %></span>条记录</div>
                <div class="page_num">
                    <yk:AspNetPager runat="server" ID="AspNetPager1" PageSize="10" NumericButtonCount="3" ShowPageIndexBox="Always"
                        SubmitButtonText=" 确定 " SubmitButtonClass="button" PageIndexBoxClass="text"
                        PrevPageText="上一页" NextPageText="下一页" FirstPageText="首页" LastPageText="末页" 
                        onpagechanging="AspNetPager1_PageChanging"></yk:AspNetPager>   
                </div>               
                    
            </div>
            <!--Page-->
            </div>
            <!--1End-->
            <!--2-->
            <div style="display:none;">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="mytable">
              <tr class="item">
                <td>时间</td>
                <td>存入</td>
                <td>支出</td>
                <td>备注</td>
              </tr>
              <tr>
                <td><dt class="time">2011-01-11</dt></td>
                <td><dt class="money">￥640.0</dt></td>
                <td><dt class="money">￥645220.0</dt></td>
                <td><dt class="remark">无</dt></td>
              </tr>
              <tr>
                <td><dt class="time">2011-01-11</dt></td>
                <td><dt class="money">￥6450.0</dt></td>
                <td><dt class="money">￥650.0</dt></td>
                <td><dt class="remark">无</dt></td>
              </tr>
              <tr>
                <td><dt class="time">2011-01-11</dt></td>
                <td><dt class="money">￥6450.0</dt></td>
                <td><dt class="money">￥6450.0</dt></td>
                <td><dt class="remark">无</dt></td>
              </tr>
              <tr>
                <td><dt class="time">2011-01-11</dt></td>
                <td><dt class="money">￥6450.0</dt></td>
                <td><dt class="money">￥6450.0</dt></td>
                <td><dt class="remark">无</dt></td>
              </tr>              
            </table>
            <!--Page-->
            <div class="Pages">
                <div class="page_total">目前在第<span>1</span>页，共有<span>2</span>页，共有<span>15</span>条记录</div>
                <div class="page_num">
                    <a href="#">首页</a>
                  <a href="#">上一页</a>
                  <a href="#">下一页</a>
                    <a href="#">尾页</a>
                </div>
                <div class="page_goto">
                <input type="text" name="textfield2" id="textfield2" class="text" />
                <input type="submit" name="button2" id="button2" value="GO" class="button" />
                </div>
            </div>
            <!--Page-->
            </div>
            <!--2End-->            
        </div>
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
<script type="text/javascript" src="../scripts/tab.js"></script>
<script type="text/javascript">
AutoTables("AutoTable1");
</script>
    </form>
</body>
</html>
