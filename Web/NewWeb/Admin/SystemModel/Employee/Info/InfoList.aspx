<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InfoList.aspx.cs" Inherits="Admin_SystemModel_Employee_Info_InfoList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="YK.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <yk:AdminHeader ID="AdminHeader1" runat="server"></yk:AdminHeader>

	<script language="javascript" type="text/javascript">
        //添加
	    function add()
	    {
	        showLayer('添加', 'InfoView.aspx', 900, 600);
	    }

	    //编辑
	    function update(id)
	    {
	        showLayer('编辑', 'InfoView.aspx?id=' + id, 900, 600);
	    }

	    //详细
	    function details(id) {
	        showLayer('详细', 'InfoDetails.aspx?id=' + id, 900, 600);
	    }
	</script>
</head>
<body>
    <form id="form1" runat="server">
            <div  class="navigation">               
               信息管理 > 信息列表
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
                                <th>标题</th>                               
                                <th>创建者</th>                                 
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
                                <td> <%# Eval("Title")%></td> 
                                <td> <%# Eval("Creater")%></td>
                                <td> <%# Eval("AddDate").ToString() %></td>
                                <td>                                 
                                    <a href="javascript:update(<%# Eval("ID") %>)"><img src="../../../images/edit.gif" title="编辑" class="edit"/></a>
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
             
             <div class="bottomSet">  
                <table>
                    <tr>
                        <td>
                            <input type="button" class="buttonCss"  onclick="quanxuan()" value="全选" />
                             <input type="button" class="buttonCss"  onclick="fanxuan()" value="反选" />
                             <asp:Button ID="ButtonDelete" runat="server" Text="删除" OnClick="ButtonDelete_Click" CssClass="buttonCss"/> 
                        </td>                        
                    </tr>
                </table>  
            </div>
    </form>
</body>
</html>

