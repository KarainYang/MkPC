<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyAddress.aspx.cs" Inherits="member_MyAddress" %>

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
       var submenu= '22'
    </script>
    
    <script src="../Admin/js/jquery.js" type="text/javascript"></script>  
    <script src="../js/ValidatorForm.js" type="text/javascript"></script>
    
    <script language="javascript" type="text/javascript">
        function ValidatiorForm() {
            var b = true;
            if (ValidatorForm.NotNullValidator("<%=TbRealName.ClientID%>") == false) {
                b = false;
                document.getElementById("spRealName").innerHTML = "请填写真实姓名";
            }
            else {
                document.getElementById("spRealName").innerHTML = "";
            }
            if (ValidatorForm.NotNullValidator("<%=TbAddress.ClientID%>") == false) {
                b = false;
                document.getElementById("spAddress").innerHTML = "请填写联系地址";
            }
            else {
                document.getElementById("spAddress").innerHTML = "";
            }
            
            if (ValidatorForm.NotNullValidator("<%=TbEmail.ClientID%>") == false) {
                b = false;
                document.getElementById("spEmail").innerHTML = "请填写邮箱地址";
            }
            else {
                document.getElementById("spEmail").innerHTML = "";
            }

            if (ValidatorForm.NotNullValidator("<%=TbMobile.ClientID%>") == false) {
                b = false;
                document.getElementById("spMobile").innerHTML = "请填写手机信息";
            }
            else {
                document.getElementById("spMobile").innerHTML = "";
            }

            return b;
        }
    </script>
    <style type="text/css">
        .style1
        {
            height: 39px;
        }
    </style>
</head>

<body class="bgbody">
    <form id="form1" runat="server">
    <!--Hearer-->
<yk:Top  runat="server" />
<!--Hearer End-->
<div class="Contain">
    <!--商品分类-->

    <yk:ProCategory runat="server" />
    <!--商品分类End-->
    <div class="Current">当前位置：<a href="<%=YK.Common.CommonClass.AppPath+"index.aspx" %>">首页</a> > <font>会员中心</font></div>
    <!--Left-->
    <div class="Sidebar">
        <!--Menu-->
        <yk:MemberMenu runat="server" />
        <!--MenuEnd-->               
    </div>
    <!--Left End-->
    <!--Right Start--> 
    <div class="Maincontent">  
      
      <h3 class="Title">地址簿</h3>
      
      <div class="Main">
      <!--Start-->
      <div class="myaddress_form">        
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="mytable">
            <tr>
              <td class="item">收货人姓名：</td>
              <td>
                <yk:TextBox runat="server" ID="TbRealName" class="text"></yk:TextBox><em id="spRealName">*</em>
               </td>
            </tr>
            <tr>
              <td class="item">地区：</td>
              <td>
                    <yk:Address runat="server" ID="Address" />
              </td>
            </tr>
            <tr>
              <td class="item">联系地址：</td>
              <td>
                <yk:TextBox runat="server" ID="TbAddress"  class="text" style="width:250px;"></yk:TextBox>
                <em  id="spAddress">*</em></td>
            </tr>
            <tr>
              <td class="item">邮箱：</td>
              <td>
                    <yk:TextBox runat="server" ID="TbEmail"  class="text" style="width:250px;"></yk:TextBox>
                    <em  id="spEmail">*</em>
              </td>
            </tr>
            <tr>
              <td class="item">邮编：</td>
              <td>
                <yk:TextBox runat="server" ID="TbPosted"  class="text" style="width:110px;"></yk:TextBox>
                <em>*</em></td>
            </tr>
            <tr>
              <td class="item">移动电话：</td>
              <td>
                <yk:TextBox runat="server" ID="TbMobile"  class="text" style="width:110px;"></yk:TextBox>
                <input type="submit" name="button3" id="button3" value="手机验证" class="btn_MobileVerify" />
                <em  id="spMobile">*</em></td>
            </tr>
            <tr>
              <td class="item">固定电话：</td>
              <td>
                <yk:TextBox runat="server" ID="TbPhone"  class="text" style="width:60px;"></yk:TextBox>
                -
                <yk:TextBox runat="server" ID="TbPhone2"  class="text" style="width:100px;"></yk:TextBox>                
                -
                <yk:TextBox runat="server" ID="TbPhone3"  class="text" style="width:60px;"></yk:TextBox>
                <span>区号-电话号码-分机</span></td>
            </tr>            
        </table>
        <div class="btnDiv">
            <yk:Button runat="server" ID="BtnSubmit" Text="保 存" class="button" OnClick="BtnSubmit_Click" OnClientClick="return ValidatiorForm()"/>
            <yk:Label runat="server" ID="LbTooltip" ForeColor="Red"></yk:Label>
        </div>        
         
          <h4>已保存的有效地址</h4>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="address">
                <tr class="item">
                <td>收货人</td>
                <td>所在地区</td>
                <td>街道地址</td>
                <td>邮编</td>
                <td>电话/手机</td>
                <td>邮箱</td>
                <td> 操作</td>
              </tr>
              <yk:Repeater runat="server" ID="RepList" OnItemCommand="RepList_ItemCommand">
                    <ItemTemplate>
                        <tr><%--  class="Now"--%>
                            <td><%# Eval("BuyerName")%></td>
                            <td><%# Eval("Zone").ToString().Split('|')[1]%></td>
                            <td><dt class="add"><%# Eval("Address")%></dt></td>
                            <td><%# Eval("PostalCode")%></td>
                            <td><%# Eval("Mobile")%> / <%# Eval("Phone")%></td>
                            <td><%# Eval("Email")%></td>
                            <td><dt class="operate"><a href="MyAddress.aspx?id=<%# Eval("ID")%>">修改</a> | <asp:LinkButton ID="LinkBtnDelete" runat="server" CommandArgument='<%# Eval("ID")%>' CommandName="delete">删除</asp:LinkButton></dt></td>
                          </tr>
                    </ItemTemplate>
              </yk:Repeater>                                             
            </table>
            <dl class="tips">最多保存10个有效地址</dl>        
      </div>
      <!--End-->
      </div>
      <div class="BottomEdge"></div> 
    </div>     
  <!--Right End-->
  <div class="clear"></div>
</div>

<!--Footer-->
<yk:Bottom runat="server" />
<!--Footer End-->
<script>
$(".address tr:odd").addClass("tdColor");
								 
$(".address tr:even").addClass("tdBgColor"); 
	$(".address tr").mouseover(function(){
								$(this).addClass("tdMoveColor");		
										})	
	$(".address tr").mouseout(function(){
								  $(this).removeClass("tdMoveColor");	
								$(this).addClass("tdColor");		
										})	
</script>
    </form>
</body>
</html>
