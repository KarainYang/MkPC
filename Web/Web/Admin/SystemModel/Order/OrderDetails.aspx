<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderDetails.aspx.cs" Inherits="Admin_SystemModel_Order_OrderDetails" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="YK.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <yk:AdminHeader ID="AdminHeader1" runat="server"></yk:AdminHeader>
</head>
<body>
    <form id="form1" runat="server">
            <div>
                <table class="fromTable">
                     <tr>  
                        <th>订单编号：</th>
                        <td><%=orders.OrderNumber %></td>
                        <th>下单日期：</th>
                        <td><%=orders.OrderDate %></td>
                    </tr>
                    <tr>
                        <th>订单状态：</th>
                        <td><%= Dictionaries.GetDictionariesTitle(DictionariesEnum.订单状态,orders.OrderStateID) %></td>
                        <th>会员：</th>
                        <td><%= orders.MemberID.GetEntity<YK.Model.TB_Member_Members>().MemberName %>&nbsp;</td>
                     </tr>
                    <tr>
                        <th>商品总数：</th>
                        <td><%=orders.ProCount %></td>
                        <th>积分：</th>
                        <td><%=orders.Integral %></td>  
                    </tr>
                    <tr>
                        <th>订单总金额：</th>
                        <td><%=orders.MoneySum %></td>
                        <th>运费：</th>
                        <td><%=orders.Freight %></td>
                    </tr>
                    <tr>
                        <th>支付方式：</th>
                        <td colspan="3"><%= Dictionaries.GetDictionariesTitle(DictionariesEnum.支付方式, distribution.PaymentID) %></td>
                    </tr>
                    <tr>
                        <th>活动描述：</th>
                        <td colspan="3"><%=orders.ActivityDesc %>&nbsp;</td>     
                    </tr>
                    <tr>
                        <th>订单备注：</th>
                        <td colspan="3"><%=orders.Remark %>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="4">&nbsp;</td>
                    </tr>
                    <tr>
                        <th>是否开发票：</th>
                        <td><%=orders.IsInvoice==0?"否":"是" %></td>
                        <th>发票类型：</th>
                        <td><%= orders.InvoiceType %></td>
                    </tr>
                    <tr>
                        <th>发票抬头：</th>
                        <td><%=orders.InvoiceLookUp %></td>
                        <th>公司名称：</th>
                        <td><%=orders.CompanyName %>&nbsp;</td>
                    </tr>
                    <tr>
                        <th>发票内容：</th>
                        <td colspan="3"><%=orders.InvoiceValue %>&nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td colspan="4">&nbsp;</td>
                    </tr>
                     <tr>  
                        <th>收货人：</th>
                        <td>  <%=distribution.BuyerName %>&nbsp;</td>
                        <th>配送方式：</th>
                        <td> <%= Dictionaries.GetDictionariesTitle(DictionariesEnum.配送方式, distribution.ConsignmentID )%></td>
                     </tr>
                     <tr> 
                        <th>送货时间：</th>
                        <td colspan="3">&nbsp; <%= distribution.RepceiptDateType%></td>
                     </tr>
                     <tr> 
                        <th>自提时间：</th>
                        <td>&nbsp; <%=distribution.MentionDate%></td>
                        <th>邮箱：</th>
                        <td><%=distribution.Email%>&nbsp;</td> 
                    </tr>
                    <tr>
                        <th>公司名称：</th>
                        <td><%=distribution.CompanyName%>&nbsp;</td>
                        <th>地址：</th>
                        <td><%=distribution.Address%>&nbsp;</td>
                    </tr>
                     <tr> 
                        <th>手机、电话：</th>
                        <td><%=distribution.Mobile%>、<%=distribution.Phone%>&nbsp;</td>
                        <th>邮编：</th>
                        <td><%=distribution.PostalCode%>&nbsp;</td>
                    </tr>
               </table>
                <asp:Repeater ID="RepList" runat="server">
                    <HeaderTemplate>
                        <table class="listTable">
                             <tr>
                                <th>商品编号</th>
                                <th>商品名称</th>
                                <th>商品价格</th>
                                <th>数量</th>
                                <th>小计</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                            <tr>                                     
                                <td> <%# Eval("proNumber")%></td>   
                                <td> 
                                    <a href="<%# CommonClass.AppPath + "Product/Product.aspx?id=" + Eval("ProductID") %>" target="_blank">
                                        <%# Eval("ProName")%>
                                    </a>
                                </td>  
                                <td> <%# Eval("Price")%></td> 
                                <td> <%# Eval("Count")%></td>                                 
                                <td>                                 
                                    <%# Eval("Count").ToInt() * Eval("Price").ToDecimal()%>
                                </td>
                            </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
    </form>
</body>
</html>

