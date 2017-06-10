<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HelpList.aspx.cs" Inherits="Admin_SystemModel_Info_HelpList" %>

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
	        showLayer('添加', 'HelpView.aspx', 900, 530);
	    }
	    
	    //修改
	    function update(id)
	    {
	        showLayer('编辑', 'HelpView.aspx?id=' + id, 900, 530);
	    }	    
	</script>
</head>
<body>
    <form id="form1" runat="server">
           <div  class="navigation">               
                <a href="HelpList.aspx">帮助中心管理</a> > 帮助中心列表
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
                                <th>类别</th>
                                <th>标题</th>
                                <th>是否隐藏</th>
                                <th>创建者</th>
                                <th>创建时间</th>
                                <th>编辑</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="CheckBoxChoose" runat="server" />
                                    <asp:HiddenField ID="HiddenFieldID" runat="server" Value='<%# Eval("ID") %>' />
                                </td>
                                <td align="left"> <%# Eval("CategoryId").GetEntity<YK.Model.TB_Info_HelpCategory>().Name %></td>
                                <td align="left"> <%# Eval("Title")%></td>
                                <td> <%# Eval("IsHIdden").ToBoolStr()%></td>
                                <td> <%# Eval("Creater") %></td>               
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
                是否隐藏：<yk:CheckBox runat="server" ID="CkIsHidden" />
                <asp:Button ID="BtnStateSet" runat="server" Text="设置" OnClick="BtnStateSet_Click" CssClass="buttonCss"/>
            </div>
    </form>
</body>
</html>
