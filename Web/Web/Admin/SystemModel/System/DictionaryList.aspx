<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DictionaryList.aspx.cs" Inherits="Admin_AdminModel_System_DictionaryList" %>

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
	        showLayer('添加', 'DictionaryView.aspx?typeCode=<%=Request["TypeCode"] %>', 550, 260);
	    }
	    
	    //修改
	    function update(id)
	    {
	        showLayer('编辑', 'DictionaryView.aspx?id=' + id, 550, 260);
	    }
	    
	</script>
</head>
<body>
    <form id="form1" runat="server">
           <div  class="navigation">               
               系统管理 > <%= Request["TypeCode"] == null ? "" : Request["TypeCode"].GetEntity<YK.Model.TB_System_DictionaryType>("Code").Name + " >"%> 数据字典列表
            </div>
            <div  class="topOpration">                               
                <input type="button" class="buttonCss" id="addBtn" value="添加" onclick="add()"></input>
                <asp:Button ID="BtnDelete" runat="server" Text="删除" OnClick="ButtonDelete_Click" CssClass="buttonCss" />  
            </div>
            <div>
                <asp:Repeater ID="RepList" runat="server">
                    <HeaderTemplate>
                        <table class="listTable">
                             <tr>
                                <th><input type="checkbox" onclick="choose()" /></th>
                                <th>标识</th>
                                <th>名称</th>
                                <th>排序</th>
                                <th>创建者</th>
                                <th> 添加日期</th>
                                <th> 编辑</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                            <tr ondblclick="update(<%# Eval("ID") %>)">
                                <td>
                                    <asp:CheckBox ID="CheckBoxChoose" runat="server" />
                                    <asp:HiddenField ID="HiddenFieldID" runat="server" Value='<%# Eval("ID") %>' />
                                </td>
                                <td> <%# Eval("Code")%></td>
                                <td> 
                                    <%# Eval("Name") %>
                                </td>
                                <td> <%# Eval("OrderBy")%></td>
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
    </form>
</body>
</html>
