<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BrowerRecord.aspx.cs" Inherits="Admin_SystemModel_Report_BrowerRecord" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="YK.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <yk:AdminHeader ID="AdminHeader1" runat="server"></yk:AdminHeader>
	
	<style type="text/css">
	    .thisA{ font-weight:bold; font-size:16px;}
	</style>
</head>
<body>
    <form id="form1" runat="server">
            <div  class="navigation">               
               商品浏览记录 > 浏览列表
            </div>
            <div>
                <asp:Repeater ID="RepList" runat="server">
                    <HeaderTemplate>
                        <table class="gridView">
                             <tr>
                                <th>会员</th>  
                                <th>商品</th>                           
                                <th>浏览时间</th>   
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                            <tr>  
                                <td> <%# Eval("MemberID").GetEntity<YK.Model.TB_Member_Members>().MemberName %></td>   
                                <td > <%# Eval("ProId").GetEntity<YK.Model.TB_Product_Products>().ProName %></td>                                   
                                <td> <%# Eval("BrowerDate") %></td>   
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

