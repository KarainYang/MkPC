<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductList.aspx.cs" Inherits="Admin_SystemModel_Product_ProductList" %>

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
	        showLayer('添加', 'ProductView.aspx', 800, 600);
	    }

	    //编辑
	    function update(id)
	    {
	        showLayer('编辑', 'ProductView.aspx?id=' + id, 800, 600);
	    }
	</script>
</head>
<body>
    <form id="form1" runat="server">
            <div  class="navigation">               
               <a href="ProductList.aspx">商品管理</a> > 商品列表
            </div>
            <div  class="topOpration">                               
                <input type="button" class="buttonCss" id="addBtn" value=" 添加 " onclick="add()"></input>
                <asp:Button ID="BtnDelete" runat="server" Text=" 删除 " OnClick="ButtonDelete_Click" CssClass="buttonCss" />             
                类别：<yk:CategoryMenu runat="server" ID="CategoryId" />
                标签：
                <yk:DropDownList ID="DDLMark" runat="server">
                    <asp:ListItem Value="" Text="==请选择标签=="></asp:ListItem>
                    <asp:ListItem Value="1" Text="折扣专区"></asp:ListItem>
                    <asp:ListItem Value="2" Text="首页推荐商品"></asp:ListItem>
                    <asp:ListItem Value="3" Text="特价专区"></asp:ListItem>
                </yk:DropDownList>                
                关键字：<asp:TextBox ID="TbKey" runat="server" Width="150px" CssClass="inputCss"></asp:TextBox> 
            </div>
            <div  class="topOpration"> 
                添加日期：
                <asp:TextBox ID="TbStartDate" runat="server" Width="100px"  CssClass="inputCss" onclick="WdatePicker()"></asp:TextBox> 
                至
                <asp:TextBox ID="TbStopDate" runat="server" Width="100px"  CssClass="inputCss" onclick="WdatePicker()"></asp:TextBox> 
                <asp:Button ID="BtnSearch"  runat="server" CssClass="buttonCss"  Text="搜索" OnClick="BtnSearch_Click" />
                导出条数：
                <asp:TextBox ID="TbCount" runat="server"  CssClass="inputCss" Width="50px" Text="20"></asp:TextBox>
                <asp:Button ID="BtnExcel"  runat="server" CssClass="buttonCss"  Text="导出数据" 
                    onclick="BtnExcel_Click"/>
             
            </div>
            <div>
                <asp:Repeater ID="RepList" runat="server">
                    <HeaderTemplate>
                        <table class="listTable">
                             <tr>
                                <th><input type="checkbox" onclick="choose()" /></th>                                
                                <th>商品名称</th>
                                <th>类别</th>
                                <th>采购价</th> 
                                <th>市场价</th> 
                                <th>销售价</th>        
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
                                <td align="left"  ondblclick="update(<%# Eval("ID") %>)"> <%# Eval("ProName")%></td>   
                                <td align="left"> <%# Eval("CategoryName")%></td>
                                <td> <%# Eval("PurchasPrice")%></td> 
                                <td> <%# Eval("MarketPrice")%></td> 
                                <td> <%# Eval("SalesPrice")%></td> 
                                <td> <%# Eval("OrderBy")%></td>  
                                <td> <%# Eval("Mark").ToStr().Contains("1")?"折扣专区":"" %> <%# Eval("Mark").ToStr().Contains("2") ? "首页推荐商品" : ""%> <%# Eval("Mark").ToStr().Contains("3") ? "特价专区" : ""%></td>
                                <td> <%# Eval("Creater")%></td>               
                                <td> <%# Convert.ToDateTime(Eval("AddDate").ToString()).ToString("yyyy-MM-dd") %></td>
                                <td>                                 
                                    <a href="javascript:update(<%# Eval("ID") %>)"><img src="../../images/edit.gif" title="编辑" class="edit"/></a>
                                    <a href="PictureList.aspx?pid=<%# Eval("ID") %>">图片</a>
                                    <a href="CommentsList.aspx?pid=<%# Eval("ID") %>">评论</a>
                                    <a href="QuestionsList.aspx?pid=<%# Eval("ID") %>">提问</a>
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
                        <td>
                            <asp:CheckBoxList ID="CheckBoxListMark" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="折扣专区" Value="1"></asp:ListItem>
                                <asp:ListItem Text="首页推荐商品" Value="2"></asp:ListItem>
                                <asp:ListItem Text="特价专区" Value="3"></asp:ListItem>
                            </asp:CheckBoxList>
                        </td>
                        <td>
                            <asp:Button ID="BtnVouchSet" runat="server" Text=" 设置 " OnClick="ButtonVouchSet_Click" CssClass="buttonCss"/>      
                        </td>
                    </tr>
                </table>  
            </div>
    </form>
</body>
</html>

