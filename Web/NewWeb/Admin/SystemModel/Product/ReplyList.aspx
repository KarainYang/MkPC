<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReplyList.aspx.cs" Inherits="Admin_SystemModel_Product_ReplyList" %>

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
	        showLayer('添加', 'ReplyView.aspx?qid='+ <%=Request["qid"] %>, 500, 200);
	    }

	    //编辑
	    function update(id)
	    {
	        showLayer('编辑', 'ReplyView.aspx?id='+ id, 500, 200);
	    }
	</script>
</head>
<body>
    <form id="form1" runat="server">
            <div  class="navigation">               
               <a href="ProductList.aspx">商品列表</a> > <%=product.ProName %> > <a href="QuestionsList.aspx?pid=<%=Request["pid"] %>">提问列表</a> > 回复列表
            </div>
            <div  class="topOpration">              
                 <input type="button" class="buttonCss" id="addBtn" value=" 添加 " onclick="add()"></input>                 
                 <input type="button" class="buttonCss"  onclick="quanxuan()" value="全选" />
                 <input type="button" class="buttonCss"  onclick="fanxuan()" value="反选" />
                 <asp:Button ID="ButtonDelete" runat="server" Text="删除" OnClick="ButtonDelete_Click" CssClass="buttonCss"/>                               
            </div>
            <div>
                <asp:Repeater ID="RepList" runat="server">
                    <HeaderTemplate>
                        <table class="gridView">
                             <tr>
                                <th><input type="checkbox" onclick="yk.core.grid.changeCheckBox(this)" /></th>                                
                                <th>会员</th>
                                <th>内容</th>                                                          
                                <th> 评论日期</th>
                                <th> 操作</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="CheckBoxChoose" runat="server" />
                                    <asp:HiddenField ID="HiddenFieldID" runat="server" Value='<%# Eval("ID") %>' />
                                </td>                               
                                <td><%# Eval("MemberID").GetEntity<YK.Model.TB_Admin_User>().UserName %></td> 
                                <td> <%# Eval("ComContent")%></td>           
                                <td> <%# Eval("AddDate").ToString() %></td>   
                                <td><a href="javascript:update(<%# Eval("ID") %>)"><img src="../../images/edit.gif" title="编辑" class="edit"/></a></td>                            
                            </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging" PageSize="15">
            </webdiyer:AspNetPager>
             
             
    </form>
</body>
</html>

