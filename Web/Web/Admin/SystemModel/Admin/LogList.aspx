﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogList.aspx.cs" Inherits="Admin_AdminModel_Admin_LogList" %>

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
	        showLayer('添加','UserView.aspx',550,260);
	    }
	    
	    //修改
	    function update(id)
	    {
	        showLayer('编辑','UserView.aspx?id='+id,550,260);
	    }
	    
	    //角色设置
	    function roleSet(id)
	    {
	        showLayer('角色设置','UserInRole.aspx?id='+id,550,360);
	    }
	    
	</script>
</head>
<body>
    <form id="form1" runat="server">
           <div  class="navigation">               
               <a href="UserList.aspx">管理员管理</a> > 管理员列表
            </div>
            <div  class="topOpration">                               
                <input type="button" class="buttonCss" id="addBtn" value="添加" onclick="add()"></input>
                <asp:Button ID="BtnDelete" runat="server" Text="删除" OnClick="ButtonDelete_Click" CssClass="buttonCss" />                       
                请输入关键字：<asp:TextBox ID="TbKey" runat="server" Width="255px" CssClass="tbKey"></asp:TextBox> 
                <asp:Button ID="BtnSearch"  runat="server" CssClass="buttonCss"  Text="搜索" OnClick="BtnSearch_Click" />
            </div>
            <div>
                <asp:Repeater ID="RepList" runat="server">
                    <HeaderTemplate>
                        <table class="listTable">
                             <tr>
                                <th><input type="checkbox" onclick="choose()" /></th>
                                <th>操作类型</th>
                                <th>操作者</th>
                                <th> 备注</th>
                                <th> 添加日期</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="CheckBoxChoose" runat="server" />
                                    <asp:HiddenField ID="HiddenFieldID" runat="server" Value='<%# Eval("ID") %>' />
                                </td>
                                <td align="left"> <%# Eval("Type")%></td> 
                                <td align="left"> <%# Eval("Operator")%></td>            
                                <td><%# Eval("Remark")%> </td>
                                <td align="left"> <%# Eval("AddDate") %></td> 
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
            </div>
    </form>
</body>
</html>
