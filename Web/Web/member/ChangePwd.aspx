<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePwd.aspx.cs" Inherits="member_ChangePwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta name="Author" content="">
    <title>梦科网络商城系统</title>

    <link href="../style/red/css_member.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/jquery-1.4.2.min.js"></script>
    
    <script language="javascript" type="text/javascript">
       var submenu= '26'
    </script>
    
    <script src="../js/ValidatorForm.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
    
        function ValidatiorForm()
        {
            var b=true;
            var OldPwd=$("#<%=TbOldPwd.ClientID%>").val();
            var NewPwd=$("#<%=TbNewPwd.ClientID%>").val();
            var ConfirmPwd=$("#<%=TbConfirmPwd.ClientID%>").val();
            var Code=$("#<%=TbVerifyCode.ClientID%>").val();
            
            if(OldPwd=="")
            {
                b=false;
                $("#<%=LbOldPwd.ClientID%>").html("旧密码不能为空");
            }
            else
            {
                $("#<%=LbOldPwd.ClientID%>").html("");
            }
            
            if(NewPwd==""||NewPwd.length<6||NewPwd.length>20)
            {
                b=false;
                $("#<%=LbNewPwd.ClientID%>").html("新密码不能为空，且密码必须是6-20位字符");
            }
            else
            {
                $("#<%=LbNewPwd.ClientID%>").html("");
            }
            
            if(ConfirmPwd=="")
            {                
                b=false;
                $("#<%=LbConfirmPwd.ClientID%>").html("确认密码不能为空");
            }
            else
            {
                if(NewPwd!=ConfirmPwd)
                {
                    b=false;
                    document.getElementById("<%=LbConfirmPwd.ClientID%>").innerHTML="两次密码不一致";
                }
                else
                {
                    document.getElementById("<%=LbConfirmPwd.ClientID%>").innerHTML="";
                }
            }
                       
            if(Code=="")
            {
                b=false;
                document.getElementById("<%=LbCode.ClientID%>").innerHTML="验证码不能为空";
            }
            else
            {
                document.getElementById("<%=LbCode.ClientID%>").innerHTML="";
            }
            
            return b;
        }
    </script>
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
      
      <h3 class="Title">修改密码</h3>
      
      <div class="Main">
      <!--Content Start-->
      <div class="changepwd_form">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="mytable">
          <tr>
            <td class="item"><em>*</em>旧密码：</td>
            <td>
              <yk:TextBox runat="server" ID="TbOldPwd" CssClass="text"></yk:TextBox>
              <yk:Label runat="server" ID="LbOldPwd" Text="" ForeColor="Red"></yk:Label>
            </td>
          </tr>
          <tr>
            <td class="item"><em>*</em>新密码：</td>
            <td>
              <yk:TextBox runat="server" ID="TbNewPwd" CssClass="text"></yk:TextBox>
              <yk:Label runat="server" ID="LbNewPwd" Text="新密码不能为空，且密码必须是6-20位字符"  ForeColor="Red"></yk:Label>
            </td>
          </tr>
          <tr>
            <td class="item"><em>*</em>重复新密码：</td>
            <td>           
              <yk:TextBox runat="server" ID="TbConfirmPwd" CssClass="text"></yk:TextBox>
              <yk:Label runat="server" ID="LbConfirmPwd" Text="密码必须是6-20位字符"  ForeColor="Red"></yk:Label>
            </td>
          </tr>
          <tr>
            <td class="item">验证码：</td>
            <td>
              <yk:TextBox runat="server" ID="TbVerifyCode" CssClass="text" Width="90px"></yk:TextBox>
              <img src="VerifyCode.aspx" width="60px" height="20px" onclick="this.src+='?'" title="看不清楚，换一张" style="cursor:pointer;"/>
              <yk:Label runat="server" ID="LbCode" Text="验证码不能为空"  ForeColor="Red"></yk:Label>
            </td>
          </tr>
          <tr>
            <td class="item"></td>
            <td>
                <yk:Button runat="server" ID="BtnSubmit" class="button" onfocus="this.blur()" Text="修改密码"
                    OnClientClick="return ValidatiorForm()"  OnClick="BtnSubmit_Click"  />
                    <yk:Label runat="server" ID="LbTooltip" Text=""  ForeColor="Red"></yk:Label>
            </td>
          </tr>
        </table>
      </div>
      <!--Content End--> 
    
      </div>
      <div class="BottomEdge"></div> 
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
