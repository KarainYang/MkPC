<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberList.aspx.cs" Inherits="Admin_AdminModel_Member_MemberList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="YK.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <yk:AdminHeader ID="AdminHeader1" runat="server"></yk:AdminHeader>
	
	<script language="javascript" type="text/javascript">
        //添加
	    function add()
	    {
	        showLayer('添加', 'MemberView.aspx', 550, 380);
	    }
	    
	    //修改
	    function update(id)
	    {
	        showLayer('编辑', 'MemberView.aspx?id=' + id,550, 380);
	    }
	    
	    //角色设置
	    function roleSet(id)
	    {
	        showLayer('角色设置','UserInRole.aspx?id='+id,550,360);
	    }
	    
	</script>
</head>
<body>
    <form id="form1" runat="server">
           <div  class="navigation">               
               <a href="MemberList.aspx">会员管理</a> > 会员列表
            </div>
            <div  class="topOpration">                               
                <input type="button" class="buttonCss" id="addBtn" value="添加" onclick="add()"></input>
                <asp:Button ID="BtnDelete" runat="server" Text="删除" OnClick="ButtonDelete_Click" CssClass="buttonCss" />                       
                请输入关键字：<asp:TextBox ID="TbKey" runat="server" Width="255px" CssClass="inputCss"></asp:TextBox> 
                <asp:Button ID="BtnSearch"  runat="server" CssClass="buttonCss"  Text="搜索" OnClick="BtnSearch_Click" />
            </div>
            <div>
                <asp:Repeater ID="RepList" runat="server">
                    <HeaderTemplate>
                        <table class="gridView">
                             <tr>
                                <th><input type="checkbox" onclick="yk.core.grid.changeCheckBox(this)" /></th>
                                <th>用户名</th>
                                <th>性别</th>
                                <th>会员级别</th>
                                <th>真实姓名</th>
                                <th>手机号</th>
                                <th>所在城市</th>
                                <th>账户金额</th>
                                <th>最后登录时间</th>
                                <th>是否开通</th>
                                <th> 注册时间</th>
                                <th> 操作</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="CheckBoxChoose" runat="server" />
                                    <asp:HiddenField ID="HiddenFieldID" runat="server" Value='<%# Eval("ID") %>' />
                                </td>
                                <td > <%# Eval("MemberName")%> </td>
                                <td> <%# Eval("Sex").ToInt()==0?"男":"女" %></td>     
                                <td> <%# Eval("LevelID") %></td>  
                                <td> <%# Eval("RealName") %></td>    
                                <td> <%# Eval("Mobile") %></td>   
                                <td> <%# Eval("City") %></td>
                                <td> <%# Eval("AccountMoney") %></td>
                                <td> <%# Eval("LastLoginTime") %></td>
                                <td> <%# Eval("IsFreeze").ToBoolStr() %></td>
                                <td> <%# Convert.ToDateTime(Eval("AddDate").ToString()).ToString("yyyy-MM-dd") %></td>
                                <td>
                                    <a href="javascript:update(<%# Eval("ID") %>)"><img src="<%=CommonClass.AppPath %>Admin/images/edit.gif" title="编辑" class="edit"/></a>
                                    <a href="BuyerInfoList.aspx?memberID=<%# Eval("ID") %>">收货人信息</a>
                                    <a href="TransRecord.aspx?memberID=<%# Eval("ID") %>">交易记录</a>
                                    <a href="IntergralRecord.aspx?memberID=<%# Eval("ID") %>">积分记录</a>
                                    <a href="MemberCouponNosList.aspx?memberID=<%# Eval("ID") %>">优惠券</a>
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
                 <input type="button" class="buttonCss"  onclick="quanxuan()" value="全选" />
                 <input type="button" class="buttonCss"  onclick="fanxuan()" value="反选" />
                 <asp:Button ID="ButtonDelete" runat="server" Text="删除" OnClick="ButtonDelete_Click" CssClass="buttonCss"/>
                状态设置：
                <asp:DropDownList ID="DDLState" runat="server">
                    <asp:ListItem Text="开通" Value="0"></asp:ListItem>
                    <asp:ListItem Text="冻结" Value="1"></asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="BtnStateSet" runat="server" Text="设置" OnClick="BtnStateSet_Click" CssClass="buttonCss"/>
            </div>
    </form>
</body>
</html>
