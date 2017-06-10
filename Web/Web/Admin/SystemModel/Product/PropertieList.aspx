<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PropertieList.aspx.cs" Inherits="Admin_SystemModel_Product_PropertieList" %>

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
	        showLayer('添加', 'PropertiesView.aspx?categoryId=<%=Request["categoryId"] %>', 500, 300);
	    }

	    //编辑
	    function update(id)
	    {
	        showLayer('编辑', 'PropertiesView.aspx?id=' + id +"&categoryId=<%=Request["categoryId"] %>", 500, 300);
	    }
	</script>
</head>
<body>
    <form id="form1" runat="server">
            <div  class="navigation">               
               商品属性 > 属性列表
            </div>
            <div  class="topOpration">                               
                <input type="button" class="buttonCss" id="addBtn" value=" 添加 " onclick="add()"></input>
                <asp:Button ID="BtnDelete" runat="server" Text=" 删除 " OnClick="ButtonDelete_Click" CssClass="buttonCss" />   
                <%
                    //当从类别管理进入属性时，隐藏类别搜索的功能
                    if (string.IsNullOrEmpty(Request["categoryId"]))
                    {
                     %>  
                <yk:ProductCategory runat="server" ID="ProductCategory" IsValidatior="false"></yk:ProductCategory>
                <asp:Button ID="BtnSearch"  runat="server" CssClass="buttonCss"  Text="搜索" OnClick="BtnSearch_Click" />

                <%
                    }
                     %>
                <yk:DropDownList ID="DDLPropType" runat="server" Visible="false">
                    <asp:ListItem Text="文本框" Value="0"></asp:ListItem>
                    <asp:ListItem Text="下拉框" Value="1"></asp:ListItem>
                    <asp:ListItem Text="复选框" Value="2"></asp:ListItem>
                    <asp:ListItem Text="单选框" Value="3"></asp:ListItem>
                </yk:DropDownList>        
            </div>
            <div>
                <asp:Repeater ID="RepList" runat="server">
                    <HeaderTemplate>
                        <table class="listTable">
                             <tr>
                                <th><input type="checkbox" onclick="choose()" /></th>                                
                                <th>属性名称</th>
                                <th>属性类型</th>
                                <th>属性值</th> 
                                <th>排序</th>                                                          
                                <th>创建者</th>
                                <th> 添加日期</th>
                                <th> 编辑</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="CheckBoxChoose" runat="server" />
                                    <asp:HiddenField ID="HiddenFieldID" runat="server" Value='<%# Eval("ID") %>' />
                                </td>                               
                                <td align="left"  ondblclick="update(<%# Eval("ID") %>)"> <%# Eval("PropName")%></td>   
                                <td> <%# DDLPropType.Items[Eval("PropType").ToInt()].Text%></td> 
                                <td> <%# Eval("PropValue")%>&nbsp;</td> 
                                <td> <%# Eval("OrderBy")%></td>  
                                <td> <%# Eval("Creater")%></td>               
                                <td> <%# Convert.ToDateTime(Eval("AddDate").ToString()).ToString("yyyy-MM-dd") %></td>
                                <td>                                 
                                    <a href="javascript:update(<%# Eval("ID") %>)"><img src="../../images/edit.gif" title="编辑" class="edit"/></a>
                                </td>
                            </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging" PageSize="15">
            </webdiyer:AspNetPager>
             
             <div class="bottomSet">  
                 <input type="button" class="buttonCss"  onclick="quanxuan()" value="全选" />
                 <input type="button" class="buttonCss"  onclick="fanxuan()" value="反选" />
                 <asp:Button ID="ButtonDelete" runat="server" Text="删除" OnClick="ButtonDelete_Click" CssClass="buttonCss"/>                         
            </div>
    </form>
</body>
</html>

