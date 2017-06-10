<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReturnGood.aspx.cs" Inherits="member_ReturnGood" %>
<%@ Import Namespace="YK.Common" %>
<%@ Import Namespace="YK.Model" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta name="Author" content="梦科商城">
    <title>梦科商城</title>

    <link href="../style/red/css_member.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/jquery-1.4.2.min.js"></script>
    <script language="javascript" type="text/javascript">
       var submenu= '11'
    </script>

    <script language="javascript">
        function jia(id) {
            var val = parseInt($("#" + id).val());
            $("#" + id).val(val + 1);

        }
        function jian(id) {
            var val = parseInt($("#" + id).val());
            if (val > 1) {
                $("#" + id).val(val - 1);
            }
        }

        function ValidatiorForm() {
            var value = $('#<%= DDLType.ClientID %>').val();
            var html=$('#<%= DDLType.ClientID %> option:selected').text();

            if (value == "") {
                alert("请选择操作类型");
                return false;
            }

            var i = 0;
            $(".Box input").each(function (index) {
                if (this.type == "checkbox") {
                    if (this.checked == true) {
                        i++;
                    }
                }
            });
            if (i == 0) {
                alert("请选择" + html + "的商品");
                return false;
            }
        }                
    </script>
    
    <style type="text/css">
	    .thisA{ font-weight:bold; font-size:15px;}
	</style>
</head>

<body class="bgbody">
    <form id="form1" runat="server">
    <!--Hearer-->
        <yk:Top runat="server" />
    <!--Hearer End-->
<div class="Contain">
    <!--商品分类-->
    <yk:ProCategory runat="server" />
    <!--商品分类End-->
    <div class="Current">当前位置：<a href="../index.aspx">首页</a> > <font>会员中心</font></div>
    <!--Left-->
    <div class="Sidebar">
        <!--Menu-->
        <yk:MemberMenu runat="server" />
        <!--MenuEnd-->               
    </div>
    <!--Left End-->
    <!--Right Start--> 
    <div class="Maincontent">  
      
      <h3 class="Title">退换货操作</h3>
      
      <div class="Main">
      <!--Content Start-->

             
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="mytable">
                <tr>
                  <td class="item">类型：</td>
                  <td>
                        <yk:DropDownList runat="server" ID="DDLType">
                            <asp:ListItem Text="==请选择==" Value=""></asp:ListItem>
                            <asp:ListItem Text="退货申请" Value="0"></asp:ListItem>
                            <asp:ListItem Text="换货申请" Value="1"></asp:ListItem>
                        </yk:DropDownList>
                  </td>
             </tr>   
             <tr>
                  <td class="item">说明：</td>
                  <td>
                        <yk:FCKeditor runat="server" ID="FCKeditor1" ToolbarSet="Basic" Width="600px"></yk:FCKeditor>
                   </td>
            </tr>   
             <tr>
                   <td colspan="2">
                        <yk:Button runat="server" ID="BtnSubmit" Text="保 存" class="button"   
                            OnClientClick="return ValidatiorForm()" onclick="BtnSubmit_Click"/>
                   </td>
                </tr>   
            </table>
        

        <div class="orders_form" id="AutoTable1">        
            <div class="Box" name="AutoContent">
                <!--1-->
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="mytable">
                  <tr class="item">
                    <td></td>
                    <td>商品名称</td>
                    <td>商品图片</td>
                    <td>商品数量</td>
                    <td>单价</td>
                    <td>金额</td>
                  </tr>
                  <asp:Repeater runat="server" ID="RepList" onitemcommand="RepList_ItemCommand">
                        <ItemTemplate> 
                          <tr>
                            <td>
                                <yk:CheckBox runat="server" ID="ck" />
                                <asp:HiddenField runat="server" ID="PID" Value='<%# Eval("ProductID") %>' />
                            </td>
                            <td style=" width:300px;">
                                <a href="../product/product.aspx?id=<%# Eval("ProductID") %>" target="_blank">
                                    <%# Eval("ProName")%>
                                </a>
                            </td>
                            <td>
                                <dt class="name">
                                    <a href="../product/product.aspx?id=<%# Eval("ProductID") %>" target="_blank" title="<%# Eval("ProName") %>">
                                        <img src="<%# CommonClass.AppPath+ Eval("ProductID").GetEntity<TB_Product_Products>().ImgUrl %>" width="60px" />
                                    </a>
                                </dt>
                            </td>
                            <td> 
                                0 < 值 <= <%# Eval("Count")%>
                                <br />
                                <asp:LinkButton runat="server" CssClass="jia" CommandName="jian" CommandArgument='<%# Eval("Count")%>' >-</asp:LinkButton>
                                    <asp:TextBox runat="server" ID="TbCount" Text='<%# Eval("Count")%>' Width="50px" Enabled="false"></asp:TextBox>
                                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="jian" CommandName="jia" CommandArgument='<%# Eval("Count")%>'>+</asp:LinkButton>
                                <br />
                                <asp:Label runat="server" ID="LbTooltip" ForeColor="Red"></asp:Label>
                            </td>
                            <td>￥<%# Eval("Price")%></td>
                            <td>￥<%# Eval("Total")%></td>
                          </tr>
                    </ItemTemplate>
                  </asp:Repeater>
                </table>
                <!--1End-->        
          </div>
        </div>
      <div class="BottomEdge"></div> 
    </div>  
    </div>  
  <!--Right End-->
  <div class="clear"></div>
</div>

<!--Footer-->
<yk:Bottom runat="server" />
<!--Footer End-->
    </form>
</body>
</html>
