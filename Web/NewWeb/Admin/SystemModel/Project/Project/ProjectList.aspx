<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProjectList.aspx.cs" Inherits="Admin_SystemModel_Project_MyProjectList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="YK.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>我的项目</title>
    <yk:AdminHeader ID="AdminHeader1" runat="server"></yk:AdminHeader>

	<script language="javascript" type="text/javascript">
        //添加
	    function add()
	    {
	        showLayer('添加', 'ProjectView.aspx', 800, 600);
	    }

	    //编辑
	    function update(id)
	    {
	        showLayer('编辑', 'ProjectView.aspx?id=' + id, 800, 600);
	    }

	    //详细
	    function details(id) {
	        showLayer('详细', 'ProjectDetails.aspx?id=' + id, 800, 500);
	    }
	</script>
</head>
<body>
    <form id="form1" runat="server">
            <div  class="navigation">               
               项目管理 > 项目列表
            </div>
            <div  class="topOpration">                               
                <input type="button" class="buttonCss" id="addBtn" value=" 添加 " onclick="add()"></input>
            </div>
            <div  class="topOpration"> 
                关键字：<asp:TextBox ID="TbKey" runat="server" Width="150px" CssClass="inputCss"></asp:TextBox>
                <asp:Button ID="BtnSearch"  runat="server" CssClass="buttonCss"  Text="搜索" OnClick="BtnSearch_Click" />
                导出条数：
                <asp:TextBox ID="TbCount" runat="server"  CssClass="inputCss" Width="50px" Text="20"></asp:TextBox>
                <asp:Button ID="BtnExcel"  runat="server" CssClass="buttonCss"  Text="导出数据" 
                    onclick="BtnExcel_Click"/>
             
            </div>
            <div>
                <asp:Repeater ID="RepList" runat="server" onitemcommand="RepList_ItemCommand">
                    <HeaderTemplate>
                        <table class="gridView">
                             <tr>
                                <th><input type="checkbox" onclick="yk.core.grid.changeCheckBox(this)" /></th>                                
                                <th>项目名称</th>
                                <th>开始时间</th>
                                <th>结束时间</th> 
                                <th> 添加日期</th>
                                <th> 操作</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="CheckBoxChoose" runat="server" />
                                    <asp:HiddenField ID="HiddenFieldID" runat="server" Value='<%# Eval("ID") %>' />
                                </td>                               
                                <td> <%# Eval("Name")%></td>   
                                <td> <%# Eval("StartDate").ToDateTime().ToShortDateString()%></td> 
                                <td> <%# Eval("EndDate").ToDateTime().ToShortDateString()%></td> 
                                <td> <%# Convert.ToDateTime(Eval("AddDate").ToString()).ToString("yyyy-MM-dd") %></td>
                                <td>                                 
                                    <a href="javascript:update(<%# Eval("ID") %>)"><img src="../../../images/edit.gif" title="编辑" class="edit"/></a>
                                    <asp:LinkButton ID="LinkBtnDelete" runat="server" CommandName="delete" CommandArgument='<%# Eval("ID") %>'>删除</asp:LinkButton>
                                    <a href="javascript:details(<%# Eval("ID") %>)">详细</a>
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
    </form>
</body>
</html>

