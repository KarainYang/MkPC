<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderList.aspx.cs" Inherits="Admin_SystemModel_Order_OrderList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="YK.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <yk:AdminHeader ID="AdminHeader1" runat="server"></yk:AdminHeader>	
	<script language="javascript">
	    function details(id) {
	        showLayer('订单详细', 'OrderDetails.aspx?id=' + id, 800, 600);
	    }
	    function audit(id,state) {
	        showLayer('客服审核', 'Audit.aspx?id='+id+"&state="+state, 800, 600);
	    }
	    function financeAudit(id) {
	        showLayer('财务审核', 'FinanceAudit.aspx?id=' + id, 800, 600);
	    }
    </script>
	<style type="text/css">
	    .thisA{ font-weight:bold; font-size:16px;}
	</style>
</head>
<body>
    <form id="form1" runat="server">
            <div  class="navigation">               
               订单管理 > 订单列表
            </div>
            <div  class="topOpration">                                         
                <a href="OrderList.aspx?state=0&next=1" id="a0">审核</a> | 
                <a href="OrderList.aspx?state=1&next=2" id="a1">待备货</a> | 
                <a href="OrderList.aspx?state=2&next=3" id="a2">待发货</a> | 
                <a href="OrderList.aspx?state=3&next=4" id="a3">待签收</a> | 
                <a href="OrderList.aspx?state=4&next=5" id="a4">财务确认</a> | 
                <a href="OrderList.aspx?state=5&next=6" id="a5">完成订单</a> | 
                <a href="OrderList.aspx?state=6" id="a6">已完成订单</a> | 
                
                <script language="javascript" type="text/javascript">
                    var num = '<%= Request["state"] %>';
                    if (num != '') {
                        document.getElementById("a" + num).className = "thisA";
                    }
	            </script>
            </div>
            <div  class="topOpration"> 
                下单日期：<yk:TextBox runat="server" ID="TbStartDate" onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" CssClass="inputCss"></yk:TextBox> 至
                <yk:TextBox runat="server" ID="TbEndDate" onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" CssClass="inputCss"></yk:TextBox>
                <yk:Button runat="server" ID="BtnSearch"  class="buttonCss"  onclick="BtnSearch_Click" Text=" 搜 索 " />
            </div>
            <div>
                <asp:Repeater ID="RepList" runat="server" onitemcommand="RepList_ItemCommand">
                    <HeaderTemplate>
                        <table class="listTable">
                             <tr>
                                <th><input type="checkbox" onclick="choose()" /></th>   
                                <th>会员</td>  
                                <th>订单类型</th>                           
                                <th>订单编号</th>   
                                <th>订单日期</th>   
                                <th>商品数量</th>    
                                <th>订单总额</th>                       
                                <th>订单状态</th>   
                                <th>审核状态</th>                               
                                <th> 编辑</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="CheckBoxChoose" runat="server" />
                                    <asp:HiddenField ID="HiddenFieldID" runat="server" Value='<%# Eval("ID") %>' />
                                </td>      
                                <td> <%# Eval("MemberID").GetEntity<YK.Model.TB_Member_Members>().MemberName %></td>   
                                <td> <%# Eval("OrderType").ToInt()==0?"普通":"团购" %></td>                                   
                                <td> <%# Eval("OrderNumber")%></td>   
                                <td> <%# Eval("OrderDate")%></td>  
                                <td> <%# Eval("ProCount")%></td> 
                                <td> <%# Eval("MoneySum")%></td>  
                                <td> <%# Dictionaries.GetDictionariesTitle(DictionariesEnum.订单状态, Eval("OrderStateID").ToInt())%></td> 
                                <td> <%# Eval("IsPassing").ToInt() == 0 ? "未审核" : Eval("IsPassing").ToInt() == 1 ? "审核通过" : "审核不通过"%></td>                                             
                                <td>                                 
                                    <a href="javascript:details(<%# Eval("ID") %>)">详细</a>

                                    <%
                                        string state = Request["state"];

                                        if (state == "0")
                                        {
                                         %>
                                         <a href="javascript:audit(<%# Eval("ID") %>,1)">审核</a>
                                    <%
                                        }
                                         %>
                                <%
                                    if (state == "1")
                                    {
                                %>
                                <a href="javascript:audit(<%# Eval("ID") %>,2)">备货</a>
                                <%
                                    }
                                     %>
                                <%
                                    if (state == "2")
                                    {
                                %>
                                    <a href="javascript:audit(<%# Eval("ID") %>,3)">发货</a>
                                <%
                                    }
                                     %>
                                <%
                                    if (state == "3")
                                    {
                                %>
                                    <a href="javascript:audit(<%# Eval("ID") %>,4)">签收</a>
                                <%
                                    }
                                     %>
                                <%
                                    if (Request["state"] == "4")
                                    {
                                         %>
                                         <a href="javascript:financeAudit(<%# Eval("ID") %>)">财务审核</a>
                                <%
                                    }
                                         %>
                                <%
                                    if (state == "5")
                                    {
                                %>
                                <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Complete" CommandArgument='<%# Eval("ID") %>' 
                                    OnClientClick="return confirm('确认完成订单吗？');">完成订单</asp:LinkButton>
                                <%
                                    }
                                     %>
                              <%
                                  if (state != "6") 
                                  {
                                %> 
                                <asp:LinkButton ID="LinkBtnDelete" runat="server" CommandName="delete" CommandArgument='<%# Eval("ID") %>' OnClientClick="return confirm('确认取消此订单吗？');">取消</asp:LinkButton>
                                <%
                                  }
                                    %>                                    
                                    
                                </td>
                            </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging" PageSize="20">
            </webdiyer:AspNetPager>
            
            <div class="bottomSet"> 
                    
                
            </div>
    </form>
</body>
</html>

