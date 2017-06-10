<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeleteList.aspx.cs" Inherits="Admin_SystemModel_Order_DeleteList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="YK.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <yk:AdminHeader ID="AdminHeader1" runat="server"></yk:AdminHeader>

	<script language="javascript" type="text/javascript">
	</script>
</head>
<body>
    <form id="form1" runat="server">
            <div  class="navigation">               
               订单管理 > 订单列表
            </div>
            <div  class="topOpration">
                <a href="DeleteList.aspx?state=0">申请中</a> | 
                <a href="DeleteList.aspx?state=1">已审核</a> | 
                <a href="DeleteList.aspx?state=2">备货</a> | 
                <a href="DeleteList.aspx?state=3">发货</a> | 
                <a href="DeleteList.aspx?state=4">待签收</a> | 
                <a href="DeleteList.aspx?state=5">财务确认</a> | 
                <a href="DeleteList.aspx?state=6">完成订单</a> 
            </div>
            <div  class="topOpration"> 
                下单日期：<yk:TextBox runat="server" ID="TbStartDate" onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" CssClass="inputCss"></yk:TextBox> 至
                <yk:TextBox runat="server" ID="TbEndDate" onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" CssClass="inputCss"></yk:TextBox>
                <yk:Button runat="server" ID="BtnSearch"  class="buttonCss"  onclick="BtnSearch_Click" Text=" 搜 索 " />                
            </div>
            <div>
                <asp:Repeater ID="RepList" runat="server">
                    <HeaderTemplate>
                        <table class="gridView">
                             <tr>
                                <th><input type="checkbox" onclick="yk.core.grid.changeCheckBox(this)" /></td>     
                                <th>订单类型</th>                           
                                <th>订单编号</th>   
                                <th>订单日期</th>   
                                <th>商品数量</th>    
                                <th>订单总额</th>                       
                                <th>订单状态</th>
                                <th> 编辑</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="CheckBoxChoose" runat="server" />
                                    <asp:HiddenField ID="HiddenFieldID" runat="server" Value='<%# Eval("ID") %>' />
                                </td>      
                                <td> <%# Eval("OrderType").ToInt()==0?"普通":"团购" %></td>                                   
                                <td> <%# Eval("OrderNumber")%></td>   
                                <td> <%# Eval("OrderDate")%></td>  
                                <td> <%# Eval("ProCount")%></td> 
                                <td> <%# Eval("MoneySum")%></td>  
                                <td> <%# Dictionaries.GetDictionariesTitle(DictionariesEnum.订单状态, Eval("OrderStateID").ToInt())%></td>                                            
                                <td>                                 
                                    <a href="OrderDetails.aspx?id=<%# Eval("ID") %>">详细</a>
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
    </form>
</body>
</html>

