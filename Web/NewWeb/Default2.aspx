<%@ Page Language="C#" AutoEventWireup="true" Inherits="product" %>
<%@ Import Namespace="YK.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div><asp:Button ID="BtnDelete" runat="server" Text=" 删除 " OnClick="ButtonDelete_Click" CssClass="buttonCss" /> 
     <asp:Repeater ID="RepList" runat="server">
                    <HeaderTemplate>
                        <table class="gridView">
                             <tr>
                                <th><input type="checkbox" onclick="yk.core.grid.changeCheckBox(this)" /></th>                                
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
                                <td   ondblclick="update(<%# Eval("ID") %>)"> <%# Eval("ProName")%></td>   
                                <td > <%# Eval("CategoryName")%></td>
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
    </form>
</body>
</html>
