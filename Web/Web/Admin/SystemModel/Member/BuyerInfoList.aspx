<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BuyerInfoList.aspx.cs" Inherits="Admin_AdminModel_Member_BuyerInfoList" %>

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
           <div  class="navigation">               
               <a href="MemberList.aspx">会员管理</a> > 会员收货人信息管理
            </div>
            <div  class="topOpration">                               
                请输入关键字：<asp:TextBox ID="TbKey" runat="server" Width="255px" CssClass="inputCss"></asp:TextBox> 
                <asp:Button ID="BtnSearch"  runat="server" CssClass="buttonCss"  Text="搜索" OnClick="BtnSearch_Click" />
            </div>
            <div>
                <asp:Repeater ID="RepList" runat="server">
                    <HeaderTemplate>
                        <table class="listTable">
                             <tr>
                                <th>收货人</th>
                                <th>地址</th>
                                <th>手机号</th>
                                <th>邮箱</th>                                
                                <th>邮政编码</th>
                                <th>电话</th>
                                <th>传真</th>
                                <th>地区</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                            <tr>
                                <td> <%# Eval("BuyerName")%> </td> 
                                <td> <%# Eval("Address")%></td>  
                                <td> <%# Eval("Mobile")%></td>
                                <td> <%# Eval("Email")%></td>                               
                                <td> <%# Eval("PostalCode")%></td>
                               <td> <%# Eval("Phone")%></td>
                               <td> <%# Eval("Fax")%></td>
                               <td> <%# Eval("Zone")%></td>
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
