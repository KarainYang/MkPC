<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CategorysTree.aspx.cs" Inherits="Admin_SystemModel_Product_CategorysTree" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="YK.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <yk:AdminHeader ID="AdminHeader1" runat="server"></yk:AdminHeader>

    <script language="javascript" type="text/javascript">
        //添加
	    function add()
	    {
	        showLayer('添加', 'CategoryView.aspx', 600, 350);
	    }

	    //编辑
	    function update(id)
	    {
	        showLayer('编辑', 'CategoryView.aspx?id=' + id, 600, 350);
	    }

	    //品牌设置
	    function BrandsSet(cid) {
	        showLayer('品牌设置', 'CategoryToBrandList.aspx?cid=' + cid, 600, 350);
	    }

	    //属性设置
	    function PropertiesSet(cid) {
	        showLayer('属性设置', 'PropertieList.aspx?categoryId=' + cid, 600, 350);
	    }

	    //广告设置
	    function CategoryAdverSet(cid) {
	        showLayer('广告设置', 'CategoryAdverView.aspx?categoryId=' + cid, 600, 350);
	    }        
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="navigation">
        <a href="Categorys.aspx">商品类别管理</a> > 类别列表 
    </div>
    <div class="topOpration">
        <input type="button" class="buttonCss" id="addBtn" value=" 添加 " onclick="add()"></input>
        <a href="javascript:history.go(-1)">返回上一级</a>
    </div>
    <div>
        <asp:Repeater ID="RepList" runat="server">
            <HeaderTemplate>
                <table class="listTable">
                    <tr>
                        <th>
                            <input type="checkbox" onclick="choose()" />
                        </th>
                        <th>
                            名称
                        </th>
                        <th>
                            类型
                        </th>
                        <th>
                            排序
                        </th>
                        <th>
                            状态
                        </th>
                        <th>
                            显示
                        </th>
                        <th>
                            添加日期
                        </th>
                        <th>
                            操作
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="parent_<%# Eval("ParentID") %>" tid="<%# Eval("ID") %>"">
                    <td>
                        <asp:CheckBox ID="CheckBoxChoose" runat="server" />
                        <asp:HiddenField ID="HiddenFieldID" runat="server" Value='<%# Eval("ID") %>' />
                    </td>
                    <td align="left">
                        <%# Eval("CategoryName") %>
                    </td>
                    <td>
                        <%# Eval("TypeID").ToInt()==0?"普通":"团购" %>
                    </td>
                    <td>
                        <%# Eval("OrderBy") %>
                    </td>
                    <td>
                        <%# DDLVouchSet.Items[Eval("VouchType").ToInt()].Text %>
                    </td>
                    <td>
                        <%# Eval("IsHidden").ToIsHidden() %>
                    </td>
                    <td>
                        <%# Convert.ToDateTime(Eval("AddDate").ToString()).ToShortDateString() %>
                    </td>
                    <td>
                        <a href='javascript:update(<%# Eval("ID") %>)'>
                            <img src="<%=CommonClass.AppPath   %>Admin/images/edit.gif" style="border: 0px;"
                                title="编辑" />
                        </a>                       
                        <a href='javascript:BrandsSet(<%# Eval("ID") %>)'>品牌设置 </a>
                        <a href='PropertieList.aspx?categoryId=<%# Eval("ID") %>'>属性设置 </a>                         
                        <%# Eval("ParentId").ToInt() == 0 ? "<a href='javascript:CategoryAdverSet(" + Eval("ID") + ")'>广告设置 </a>" : ""%>
                        <%# 
                            Eval("ID").GetEntity<YK.Model.TB_System_Adver>("ProCategoryId").ID > 0 ?
                                                        "<a href='../System/AdverPicList.aspx?adverId=" + Eval("ID").GetEntity<YK.Model.TB_System_Adver>("ProCategoryId").ID + "'>广告图片管理 </a>" : ""
                        %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <div class="bottomSet">
            <input type="button" value=" 全 选 " class="buttonCss" onclick="quanxuan()" />
            <input type="button" value=" 反 选 " class="buttonCss" onclick="fanxuan()" />
            <asp:Button ID="ButtonDelete" runat="server" Text="删除" OnClick="ButtonDelete_Click"
                CssClass="buttonCss" />
            <span>推荐设置：
                <asp:DropDownList ID="DDLVouchSet" runat="server">
                    <asp:ListItem Text="不推荐" Value="0"></asp:ListItem>
                    <asp:ListItem Text="推荐" Value="1"></asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="BtnVouchSet" runat="server" Text=" 设 置 " OnClick="DDLVouchSet_Click"
                    CssClass="buttonCss" />
            </span>是否隐藏：
            <asp:CheckBox ID="CheckBoxIsHiddenSet" runat="server" BackColor="White" />
            <asp:Button ID="BtnHiddenSet" runat="server" Text=" 设 置 " OnClick="DDLIsHiddenSet_Click"
                CssClass="buttonCss" />
        </div>
    </div>
    </form>
</body>
</html>
