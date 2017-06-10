<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AllWorkStatementList.aspx.cs" Inherits="Admin_SystemModel_Employee_AllWorkStatementList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="YK.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>所有工作报告</title>
    <yk:AdminHeader ID="AdminHeader1" runat="server"></yk:AdminHeader>

	<script language="javascript" type="text/javascript">
	    //详细
	    function details(id) {
	        showLayer('详细', 'WorkStatementDetails.aspx?id=' + id, 800, 500);
	    }
	</script>
</head>
<body>
    <form id="form1" runat="server">
            <div  class="navigation">               
               工作报告管理 > 工作报告列表
            </div>
            <div  class="topOpration"> 
                管理员：
                <yk:DropDownList runat="server" ID="DDLUsers">
                </yk:DropDownList>
                <yk:DropDownList runat="server" ID="DDLType">
                    <asp:ListItem Text="日报" Value="0"></asp:ListItem>
                    <asp:ListItem Text="周报" Value="1"></asp:ListItem>
                    <asp:ListItem Text="月报" Value="2"></asp:ListItem>
                </yk:DropDownList>
                <asp:Button ID="BtnSearch"  runat="server" CssClass="buttonCss"  Text="搜索" OnClick="BtnSearch_Click" />
            </div>
            <div>
                <asp:Repeater ID="RepList" runat="server">
                    <HeaderTemplate>
                        <table class="gridView">
                             <tr>
                                <th><input type="checkbox" onclick="yk.core.grid.changeCheckBox(this)" /></th>
                                <th>类型</th> 
                                <th>标题</th>  
                                <th>报告日期</th>
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
                                <td> <%# DDLType.Items[Eval("Type").ToInt()].Text %></td>                           
                                <td> <%# Eval("Title")%></td> 
                                <td> <%# Eval("StatementDate")%></td>
                                <td> <%# Eval("Creater") %></td>
                                <td> <%# Eval("AddDate") %></td>
                                <td>                                 
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

