<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LevelList.aspx.cs" Inherits="Admin_AdminModel_Member_LevelList" %>

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
	        showLayer('添加', 'LevelView.aspx', 500, 300);
	    }
	    
	    //修改
	    function update(id)
	    {
	        showLayer('编辑', 'LevelView.aspx?id=' + id, 500, 300);
	    }
	    
	</script>
</head>
<body>
    <form id="form1" runat="server">
           <div  class="navigation">               
               <a href="LevelList.aspx">会员级别</a> > 优惠券列表
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
                        <table class="listTable">
                             <tr>
                                <th><input type="checkbox" onclick="choose()" /></th>
                                <th>级别名称</th>
                                <th>折扣</th>
                                <th>是否默认级别</th>
                                <th>是否启用折扣</th>
                                <th>最低积分</th>
                                <th>添加时间</th>
                                <th> 编辑</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="CheckBoxChoose" runat="server" />
                                    <asp:HiddenField ID="HiddenFieldID" runat="server" Value='<%# Eval("ID") %>' />
                                </td>
                                <td align="left"> <%# Eval("LevelName")%> </td>
                                <td> <%# Eval("Discount")%></td>     
                                <td> <%# Eval("IsDefault").ToBoolStr() %></td>
                                <td> <%# Eval("IsEnableDis").ToBoolStr()%></td>
                                <td> <%# Eval("MinIntegral")%></td>
                                <td> <%# Convert.ToDateTime(Eval("AddDate").ToString()).ToString("yyyy-MM-dd") %></td>
                                <td>
                                    <a href="javascript:update(<%# Eval("ID") %>)"><img src="<%=CommonClass.AppPath %>Admin/images/edit.gif" title="编辑" class="edit"/></a>
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
            </div>
    </form>
</body>
</html>
