<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VisionSubjectList.aspx.cs" Inherits="Admin_SystemModel_Exam_VisionSubject" %>

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
	        showLayer('添加', 'VisionSubjectView.aspx', 800, 600);
	    }

	    //编辑
	    function update(id)
	    {
	        showLayer('编辑', 'VisionSubjectView.aspx?id=' + id, 800, 600);
	    }

	    function showLayerCallback()
	    {

	    }
	</script>
</head>
<body>
    <form id="form1" runat="server">
            <div  class="navigation">               
               <a href="ProductList.aspx">智能体检</a> > 原理说明
            </div>
            <div  class="topOpration">                               
                <input type="button" class="buttonCss" id="addBtn" value=" 添加 " onclick="add()"></input>

                <yk:DropDownList runat="server" ID="DDLModule"></yk:DropDownList>
                <asp:Button ID="BtnSearch"  runat="server" CssClass="buttonCss"  Text="搜索" OnClick="BtnSearch_Click" />
            </div>
            <div>
                <asp:Repeater ID="RepList" runat="server">
                    <HeaderTemplate>
                        <table class="gridView">
                             <tr>
                                <th><input type="checkbox" onclick="yk.core.grid.changeCheckBox(this)" /></th>                                
                                <th>类型</th>  
                                 <th>名称</th>      
                                <th>创建者</th>
                                <th>添加日期</th>
                                <th>编辑</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                            <tr ondblclick="update(<%# Eval("ID") %>)">
                                <td class="TdSerial">
                                    <asp:CheckBox ID="CheckBoxChoose" runat="server" />
                                    <asp:HiddenField ID="HiddenFieldID" runat="server" Value='<%# Eval("ID") %>' />
                                </td>                               
                                <td> <%# DataToCacheHelper.GetAllDictionaries().Where(w=>w.Code==Eval("Type").ToStr() && w.TypeCode=="04").First().Name %></td>   
                                <td> <%# Eval("Name")%></td>   
                                <td> <%# Eval("Creater")%></td>               
                                <td class="TdDate" format="yyyy-MM-dd "> <%# Convert.ToDateTime(Eval("CreatedOn").ToString()).ToString("yyyy-MM-dd") %></td>
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

