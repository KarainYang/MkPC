﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GroupList.aspx.cs" Inherits="Admin_SystemModel_Product_GroupList" %>

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
	        showLayer('添加', 'GroupView.aspx', 800, 500);
	    }

	    //编辑
	    function update(id)
	    {
	        showLayer('编辑', 'GroupView.aspx?id=' + id, 800, 500);
	    }
	</script>
</head>
<body>
    <form id="form1" runat="server">
            <div  class="navigation">               
               <a href="ProductList.aspx">团购管理</a> > 团购列表
            </div>
            <div  class="topOpration">                               
                <input type="button" class="buttonCss" id="addBtn" value=" 添加 " onclick="add()"></input>
                <asp:Button ID="BtnDelete" runat="server" Text=" 删除 " OnClick="ButtonDelete_Click" CssClass="buttonCss" />             
            </div>
            <div>
                <asp:Repeater ID="RepList" runat="server">
                    <HeaderTemplate>
                        <table class="listTable">
                             <tr>
                                <th><input type="checkbox" onclick="choose()" /></th>                                
                                <th>团购名称</th>
                                <th>开始时间</th>
                                <th>结束时间</th> 
                                <th>售价</th> 
                                <th>团购价</th>        
                                <th>排序</th>   
                                <th>推荐类型</th>                           
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
                                <td align="left"> <%# Eval("GroupName")%></td>
                                <td> <%# Eval("StartDate")%></td> 
                                <td> <%# Eval("StopDate")%></td> 
                                <td> <%# Eval("Price")%></td>
                                <td> <%# Eval("GroupPrice")%></td> 
                                <td> <%# Eval("OrderBy")%></td>  
                                <td> <%# DDLVouchType.Items[Eval("VouchType").ToInt()].Text %></td>
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
                 <asp:DropDownList ID="DDLVouchType" runat="server">
                    <asp:ListItem Text="不推荐" Value="0"></asp:ListItem>
                    <asp:ListItem Text="推荐" Value="1"></asp:ListItem>
                </asp:DropDownList>
                 <asp:Button ID="BtnVouchSet" runat="server" Text=" 设置 " OnClick="ButtonVouchSet_Click" CssClass="buttonCss"/>                  
            </div>
    </form>
</body>
</html>
