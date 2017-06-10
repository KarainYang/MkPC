<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CategoryToBrandList.aspx.cs" Inherits="Admin_SystemModel_Product_CategoryBrandList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="YK.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <yk:AdminHeader ID="AdminHeader1" runat="server"></yk:AdminHeader>
    <script language="javascript" type="text/javascript">
        var DG = frameElement.lhgDG;
        DG.addBtn('ok', '确定', ok);
        function ok() {
            $("#<%= BtnSet.ClientID %>").click();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
            <div>
            <table class="listTable">
                 <tr>
                    <th><input type="checkbox" onclick="choose()" /></th>                                
                    <th>名称</th>  
                    <th>是否推荐</th> 
                    <th>排序</th> 
                </tr>
                    <asp:Repeater ID="RepList" runat="server" 
                        onitemdatabound="RepList_ItemDataBound">
                        <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="CheckBoxChoose" runat="server" />
                                        <asp:HiddenField ID="HiddenFieldID" runat="server" Value='<%# Eval("ID") %>' />
                                    </td>                               
                                    <td align="left"> <%# Eval("BrandName")%></td>   
                                    <td><yk:CheckBox runat="server" ID="CheckIsVouch" /></td> 
                                    <td><yk:TextBox runat="server" ID="TbOrderBy"></yk:TextBox></td> 
                                </tr>
                        </ItemTemplate>
                    </asp:Repeater> 
                </table>
            </div>
             
             <div class="bottomSet">  
                 <input type="button" class="buttonCss"  onclick="quanxuan()" value="全选" />
                 <input type="button" class="buttonCss"  onclick="fanxuan()" value="反选" /> 
                 <asp:Button ID="BtnSet" runat="server" Text=" 设置 "  OnClick="ButtonSet_Click" CssClass="buttonCss"/>             
            </div>

            <div runat="Server" id="MessageDiv">            
            </div> 
    </form>
</body>
</html>

