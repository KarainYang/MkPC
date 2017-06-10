<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ActivityList.aspx.cs" Inherits="Admin_SystemModel_Activity_ActivityList" %>

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
	        showLayer('添加', 'ActivityView.aspx', 900, 530);
	    }
	    
	    //修改
	    function update(id)
	    {
	        showLayer('编辑', 'ActivityView.aspx?id=' + id, 900, 530);
	    }

	    //优惠券管理
	    function setCounpon(activityId) {
	        showLayer('优惠券管理', 'CouponNosList.aspx?activityId=' + activityId, 800, 500);
	    }   
	</script>
</head>
<body>
    <form id="form1" runat="server">
           <div  class="navigation">               
               <a href="ActivityList.aspx">活动管理</a> > 活动列表
            </div>
            <div  class="topOpration">                               
                <input type="button" class="buttonCss" id="addBtn" value="添加" onclick="add()"></input>
                <asp:Button ID="BtnDelete" runat="server" Text="删除" OnClick="ButtonDelete_Click" CssClass="buttonCss" />                       
                请输入关键字：<asp:TextBox ID="TbKey" runat="server" Width="255px" CssClass="inputCss"></asp:TextBox> 
                <asp:Button ID="BtnSearch"  runat="server" CssClass="buttonCss"  Text="搜索" OnClick="BtnSearch_Click" />

                <asp:DropDownList runat="server" ID="DDLType" Visible="false">
                    <asp:ListItem Text="满x元免运费" Value="1" onchange="changeType(this.value)"></asp:ListItem>
                    <asp:ListItem Text="满x元送x积分" Value="2" onchange="changeType(this.value)"></asp:ListItem>
                    <asp:ListItem Text="满x元打x折" Value="3" onchange="changeType(this.value)"></asp:ListItem>
                    <asp:ListItem Text="满x元送优惠券" Value="4" onchange="changeType(this.value)"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div>
                <asp:Repeater ID="RepList" runat="server">
                    <HeaderTemplate>
                        <table class="listTable">
                             <tr>
                                <th><input type="checkbox" onclick="choose()" /></th>
                                <th>名称</th>
                                <th>类型</th>
                                <th>金额</th>
                                <th>是否设置时间</th>
                                <th>是否启用</th>
                                <th>创建者</th>
                                <th>创建时间</th>
                                <th>操作</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="CheckBoxChoose" runat="server" />
                                    <asp:HiddenField ID="HiddenFieldID" runat="server" Value='<%# Eval("ID") %>' />
                                </td>
                                <td align="left"> <%# Eval("Name")%></td>
                                <td> <%# DDLType.Items[Eval("Type").ToInt()-1].Text%></td>
                                <td> <%# Eval("Amount")%></td>
                                <td> <%# Eval("IsSetDate").ToBoolStr() %></td>
                                <td> <%# Eval("IsEnable").ToBoolStr()%></td>
                                <td> <%# Eval("Creater") %></td>               
                                <td> <%# Convert.ToDateTime(Eval("AddDate").ToString()).ToString("yyyy-MM-dd") %></td>
                                <td>
                                    <a href="javascript:update(<%# Eval("ID") %>)" title="编辑"><img src="<%=CommonClass.AppPath %>Admin/images/edit.gif" title="编辑" class="edit"/></a>

                                    <%# Eval("Type").ToInt() == 4 ? "<a href=\"javascript:setCounpon(" + Eval("ID") + ")\">优惠券管理</a>" : ""%>
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
                是否启用：
                <asp:DropDownList ID="DDLIsEnable" runat="server">
                    <asp:ListItem Text="不启用" Value="0"></asp:ListItem>
                    <asp:ListItem Text="启用" Value="1"></asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="BtnStateSet" runat="server" Text="设置" OnClick="BtnStateSet_Click" CssClass="buttonCss"/>
            </div>
    </form>
</body>
</html>
