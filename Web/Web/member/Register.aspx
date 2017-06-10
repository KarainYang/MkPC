<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="member_Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta name="Author" content="梦科商城">
    <title>梦科商城</title>
    <link href="../style/red/css_member.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../Scripts/jquery-1.4.2.min.js"></script>

    <script src="../js/ValidatorForm.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
        function ValidatiorForm()
        {
            var b=true;
            var memberName=$("#<%=TbMemberName.ClientID%>").val();
            var memberPwd=$("#<%=TbMemberPwd.ClientID%>").val();
            var confirmPwd=$("#<%=TbConfirmPwd.ClientID%>").val();
            
            if(ValidatorForm.NotNullValidator("<%=TbMemberName.ClientID%>")==false||memberName.length<5||memberName.length>20)
            {
                b=false;
                document.getElementById("name").className="tips ared";
            }
            else
            {
                document.getElementById("name").className="tips";
            }
            if(ValidatorForm.NotNullValidator("<%=TbMemberPwd.ClientID%>")==false||memberPwd.length<6||memberPwd.length>20)
            {
                b=false;
                document.getElementById("pwd").className="tips ared";
            }
            else
            {
                document.getElementById("pwd").className="tips";
            }
            if(ValidatorForm.NotNullValidator("<%=TbConfirmPwd.ClientID%>")==false)
            {                
                b=false;
                document.getElementById("confirmpwd").className="tips ared";
            }
            else
            {
                if(memberPwd!=confirmPwd)
                {
                    b=false;
                    document.getElementById("confirmpwd").className="tips ared";
                    document.getElementById("confirmpwd").innerHTML="两次密码不一致";
                }
                else
                {
                    document.getElementById("confirmpwd").className="tips";
                    document.getElementById("confirmpwd").innerHTML="";
                }
            }
            
            if(ValidatorForm.NotNullValidator("<%=TbEmail.ClientID%>")==false||ValidatorForm.Email("<%=TbEmail.ClientID%>")==false)
            {
                b=false;
                document.getElementById("email").className="tips ared";
            }
            else
            {
                document.getElementById("email").className="tips";
            }
            
            if(ValidatorForm.NotNullValidator("<%=TbVerifyCode.ClientID%>")==false)
            {
                b=false;
                document.getElementById("<%=LbCode.ClientID%>").className="tips ared";
            }
            else
            {
                document.getElementById("<%=LbCode.ClientID%>").className="tips";
            }
            if (document.getElementById("checkbox").checked == false) {
                b = false;
                alert("请先阅读并同意《梦科商城的交易条款》和《服务条款》");
            }
            return b;
        }
    </script>
</head>
<body class="bgbody">
    <form id="form1" runat="server">
    <!--Hearer-->
    <div class="other_Header">
        <yk:Top runat="server" />
    </div>
    <!--Hearer End-->
    <div class="Contain_Register">
        <h3>
            <b>注册新用户</b><span>我已经注册，现在就<a href="login.aspx">登录</a></span></h3>
        <div class="Box">
            <h4>
                <font>个人用户</font> 欢迎注册!</h4>
            <table border="0" cellspacing="0" cellpadding="0" class="table">
                <tr>
                    <td class="name">
                        输入用户名：
                    </td>
                    <td>
                        <yk:TextBox runat="server" ID="TbMemberName" CssClass="text" onmouseover="this.className='text2';"
                            onmouseout="this.className='text';" Style="width: 246px;"></yk:TextBox><font class="tips" id="name"><em>*</em> 5-20个字符(包括小写字母、数字、下划线)。</font>
                    </td>
                </tr>
                <tr>
                    <td class="name">
                        输入密码：
                    </td>
                    <td>
                        <yk:TextBox runat="server" ID="TbMemberPwd" TextMode="Password" CssClass="text" onmouseover="this.className='text2';"
                            onmouseout="this.className='text';" Style="width: 246px;"></yk:TextBox><font class="tips" id="pwd"><em>*</em> 6-20个字符组成，使用英文字母加数字或符号的组合密码，不能单独使用英文字母、数字或符号作为您的密码。</font>
                    </td>
                </tr>
                <tr>
                    <td class="name">
                        重复输入密码：
                    </td>
                    <td>
                        <yk:TextBox runat="server" ID="TbConfirmPwd" TextMode="Password" CssClass="text" onmouseover="this.className='text2';"
                            onmouseout="this.className='text';" Style="width: 246px;"></yk:TextBox><font class="tips" id="confirmpwd"><em>*</em> 输入重复密码。</font>
                    </td>
                </tr>
                <tr>
                    <td class="name">
                        输入邮箱：
                    </td>
                    <td>
                        <yk:TextBox runat="server" ID="TbEmail" CssClass="text" onmouseover="this.className='text2';"
                            onmouseout="this.className='text';" Style="width: 246px;"></yk:TextBox><font class="tips" id="email"><em>*</em> 请输入您常用的邮箱，方便日后找回密码。</font>
                    </td>
                </tr>
                <tr>
                    <td class="name">
                        输入验证码：
                    </td>
                    <td>
                        <yk:TextBox runat="server" ID="TbVerifyCode" CssClass="text" onmouseover="this.className='text2';"
                            onmouseout="this.className='text';" Style="width: 90px;"></yk:TextBox>
                        <img src="VerifyCode.aspx" width="60px" height="20px" onclick="this.src+='?'" title="看不清楚，换一张" style="cursor:pointer;"/>
                        <font class="tips"> <em>*</em> <asp:Label ID="LbCode" runat="server" Text="验证码必填" CssClass="tips"></asp:Label></font>
                        
                    </td>
                </tr>
            </table>
            <dl class="txt">
                <input type="checkbox" name="checkbox" id="checkbox" />
                我已阅读并同意 <a href="<%=YK.Common.CommonClass.AppPath %>info/AboutUs.aspx?code=10005">《梦科商城的交易条款》</a>
                和<a href="<%=YK.Common.CommonClass.AppPath %>info/AboutUs.aspx?code=10006">《服务条款》</a>
            </dl>
            <div class="btnDiv">
                <yk:Button runat="server" ID="BtnSubmit" class="button_submit" 
                    OnClientClick="return ValidatiorForm()" onclick="BtnSubmit_Click" />

                    <asp:Label ID="LbTooltip" runat="server" Text="" ForeColor="Red"></asp:Label>
            </div>
        </div>
    </div>
    <!--Footer-->
    <yk:Bottom runat="server" />
    <!--Footer End-->
    </form>
</body>
</html>
