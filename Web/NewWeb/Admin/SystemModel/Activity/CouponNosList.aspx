<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CouponNosList.aspx.cs" Inherits="Admin_AdminModel_Activity_CouponNosList" %>

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
               <a href="CouponList.aspx">优惠券管理</a> > 优惠券列表
            </div>
            <div  class="topOpration">                               
                <asp:Button ID="BtnDelete" runat="server" Text="删除" OnClick="ButtonDelete_Click" CssClass="buttonCss" />                       
                会员：<asp:TextBox ID="TbKey" runat="server" CssClass="inputCss"></asp:TextBox> 
                <asp:Button ID="Button1"  runat="server" CssClass="buttonCss"  Text="发放" OnClick="BtnSend_Click" />
                <yk:Label runat="server" ID="LbTooltip" ForeColor="Red"></yk:Label>
                <asp:Button ID="BtnSearch"  runat="server" CssClass="buttonCss"  Text="搜索" OnClick="BtnSearch_Click" />
            </div>
            <div>
                <asp:Repeater ID="RepList" runat="server">
                    <HeaderTemplate>
                        <table class="gridView">
                             <tr>
                                <th><input type="checkbox" onclick="yk.core.grid.changeCheckBox(this)" /></th>
                                <th>优惠券编号</th>
                                <th>会员</th>
                                <th>是否已使用</th>
                                <th>发放时间</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="CheckBoxChoose" runat="server" />
                                    <asp:HiddenField ID="HiddenFieldID" runat="server" Value='<%# Eval("ID") %>' />
                                </td>
                                <td > <%# Eval("CouponNo")%> </td>
                                <td> <%# Eval("MemberID").GetEntity<YK.Model.TB_Member_Members>().MemberName %></td>  
                                <td> <%# Eval("IsUse")%></td>
                                <td> <%# Eval("SendDate")%></td>
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
                 <input type="button" class="buttonCss"  onclick="quanxuan()" value="全选" />
                 <input type="button" class="buttonCss"  onclick="fanxuan()" value="反选" />
                 <asp:Button ID="ButtonDelete" runat="server" Text="删除" OnClick="ButtonDelete_Click" CssClass="buttonCss"/>               
            </div>
    </form>
</body>
</html>
