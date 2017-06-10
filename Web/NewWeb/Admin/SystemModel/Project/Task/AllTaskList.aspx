<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AllTaskList.aspx.cs" Inherits="Admin_SystemModel_Project_AllTaskList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="YK.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>我处理的任务</title>
    <yk:AdminHeader ID="AdminHeader1" runat="server"></yk:AdminHeader>

	<script language="javascript" type="text/javascript">
	    //详细
	    function details(id) {
	        showLayer('详细', 'TaskDetails.aspx?id=' + id, 800, 500);
	    }
	</script>
</head>
<body>
    <form id="form1" runat="server">
            <div  class="navigation">               
               任务管理 > 任务列表
            </div>
            <div  class="topOpration"> 
                项目：
                <yk:DropDownList runat="server" ID="DDLProjects">                   
                </yk:DropDownList>
                任务名称：<asp:TextBox ID="TbKey" runat="server" Width="150px" CssClass="inputCss"></asp:TextBox>
                <asp:Button ID="BtnSearch"  runat="server" CssClass="buttonCss"  Text="搜索" OnClick="BtnSearch_Click" />
                导出条数：
                <asp:TextBox ID="TbCount" runat="server"  CssClass="inputCss" Width="50px" Text="20"></asp:TextBox>
                <asp:Button ID="BtnExcel"  runat="server" CssClass="buttonCss"  Text="导出数据" 
                    onclick="BtnExcel_Click"/>
             
            </div>
            <div>
                <asp:Repeater ID="RepList" runat="server">
                    <HeaderTemplate>
                        <table class="gridView">
                             <tr>
                                <th><input type="checkbox" onclick="yk.core.grid.changeCheckBox(this)" /></th>                                
                                <th>任务名称</th>
                                <th>开始时间</th>
                                <th>结束时间</th>
                                <th>处理</th> 
                                <th>进度</th>
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
                                <td> <%# Eval("StartDate")%></td> 
                                <td> <%# Eval("EndDate")%></td> 
                                <td> <%# TaskCommon.GetStateStr(Eval("State").ToInt())%></td> 
                                <td> <%# Eval("Progress")%> % </td> 
                                <td> <%# Convert.ToDateTime(Eval("AddDate").ToString()).ToString("yyyy-MM-dd") %></td>
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

