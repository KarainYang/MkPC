<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdverList.aspx.cs" Inherits="Admin_AdminModel_System_AdverList" %>

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
	        showLayer('添加', 'AdverView.aspx', 550, 350);
	    }
	    
	    //修改
	    function update(id)
	    {
	        showLayer('编辑', 'AdverView.aspx?id=' + id, 550, 350);
	    }
	    
	</script>    
</head>
<body>
    <form id="form1" runat="server">
           <div  class="navigation">               
               系统管理 > 广告列表
            </div>
            <div  class="topOpration">                               
                <input type="button" class="buttonCss" id="addBtn" value="添加" onclick="add()"></input>
                <asp:Button ID="BtnDelete" runat="server" Text="删除" OnClick="ButtonDelete_Click" CssClass="buttonCss" />  
                类别：
                <yk:DropDownList runat="server" ID="DDLCategory"></yk:DropDownList>
                名称：<asp:TextBox ID="TbKey" runat="server" Width="255px" CssClass="inputCss"></asp:TextBox> 
                广告类型:<asp:DropDownList ID="DDLAdverType" runat="server">
                            <asp:ListItem Text="==请选择==" Value=""></asp:ListItem>
                            <asp:ListItem Text="单图片" Value="0"></asp:ListItem>
                            <asp:ListItem Text="图片切换【图片点击】" Value="1"></asp:ListItem>
                            <asp:ListItem Text="图片切换【数字点击】" Value="2"></asp:ListItem>
                         </asp:DropDownList>
                <asp:Button ID="BtnSearch"  runat="server" CssClass="buttonCss"  Text="搜索" OnClick="BtnSearch_Click" />
            </div>
            
            <div>
                <asp:Repeater ID="RepList" runat="server">
                    <HeaderTemplate>
                        <table class="listTable">
                             <tr>
                                <th><input type="checkbox" onclick="choose()" /></th>
                                <th>广告类型</th>               
                                <th>名称</th>
                                <th>标识</th>   
                                <th>宽度</th>     
                                <th>高度</th>                          
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
                                <td><%# DDLAdverType.Items[Eval("AdverType").ToInt()+1].Text %></td>
                                <td><%# Eval("Name") %></td>
                                <td> <%# Eval("Code")%></td>      
                                <td> <%# Eval("PicWidth")%></td> 
                                <td> <%# Eval("PicHeight")%></td>                           
                                <td> <%# Eval("OrderBy")%></td>
                                <td> <%# Eval("Creater") %></td>               
                                <td> <%# Convert.ToDateTime(Eval("AddDate").ToString()).ToString("yyyy-MM-dd") %></td>
                                <td>
                                    <a href="javascript:update(<%# Eval("ID") %>)"><img src="<%=CommonClass.AppPath %>Admin/images/edit.gif" title="编辑" class="edit"/></a>
                                    <a href="AdverPicList.aspx?adverId=<%# Eval("ID") %>">图片管理</a>
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
