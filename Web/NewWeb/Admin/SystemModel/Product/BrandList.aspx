<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BrandList.aspx.cs" Inherits="Admin_SystemModel_Product_BrandList" %>

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
	        showLayer('添加', 'BrandView.aspx', 600, 360);
	    }

	    //编辑
	    function update(id)
	    {
	        showLayer('编辑', 'BrandView.aspx?id=' + id, 600, 360);
	    }

	    //品牌所属类别
	    function brandToCategory(brandId) {
	        showLayer('品牌所属类别', 'BrandToCategoryList.aspx?brandId=' + brandId, 600, 360);
	    }
	</script>
</head>
<body>
    <form id="form1" runat="server">
            <div  class="navigation">               
                品牌管理 > 品牌列表
            </div>
            <div  class="topOpration">                               
                <input type="button" class="buttonCss" id="addBtn" value=" 添加 " onclick="add()"></input>
                <asp:Button ID="BtnDelete" runat="server" Text=" 删除 " OnClick="ButtonDelete_Click" CssClass="buttonCss" />             
            </div>
            <div>
                <asp:Repeater ID="RepList" runat="server">
                    <HeaderTemplate>
                        <table class="gridView">
                             <tr>
                                <th><input type="checkbox" onclick="yk.core.grid.changeCheckBox(this)" /></th>                                
                                <th>名称</th>   
                                <th>排序</th>     
                                <th>是否隐藏</th>
                                <th>是否推荐</th>                      
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
                                <td > <%# Eval("BrandName")%></td>   
                                <td> <%# Eval("OrderBy")%></td>  
                                <td> <%# Eval("IsHidden").ToStr().ToLower()=="false"?"否":"是"%></td>  
                                <td> <%# DDLVouchType.Items[Eval("VouchType").ToInt()].Text %></td>  
                                <td> <%# Eval("Creater")%></td>               
                                <td> <%# Convert.ToDateTime(Eval("AddDate").ToString()).ToString("yyyy-MM-dd") %></td>
                                <td>                                 
                                    <a href="javascript:update(<%# Eval("ID") %>)"><img src="../../images/edit.gif" title="编辑" class="edit"/></a>
                                    <a href="javascript:brandToCategory(<%# Eval("ID") %>)">所属类别</a>
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
                 <asp:DropDownList ID="DDLVouchType" runat="server">
                    <asp:ListItem Text="不推荐" Value="0"></asp:ListItem>
                    <asp:ListItem Text="推荐到首页" Value="1"></asp:ListItem>
                </asp:DropDownList>
                 <asp:Button ID="BtnVouchSet" runat="server" Text=" 设置 " OnClick="ButtonVouchSet_Click" CssClass="buttonCss"/>             
            </div>
    </form>
</body>
</html>

