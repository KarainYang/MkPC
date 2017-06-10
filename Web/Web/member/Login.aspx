<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="member_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta name="Author" content="">
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
            
            if(ValidatorForm.NotNullValidator("<%=TbMemberName.ClientID%>")==false||memberName.length<5||memberName.length>20)
            {
                b=false;
                document.getElementById("name").innerHTML="用户名不能为空";
            }
            else
            {
                document.getElementById("name").innerHTML="";
            }
            if(ValidatorForm.NotNullValidator("<%=TbMemberPwd.ClientID%>")==false||memberPwd.length<6||memberPwd.length>20)
            {
                b=false;
                document.getElementById("pwd").innerHTML="密码不能为空";
            }
            else
            {
                document.getElementById("pwd").innerHTML="";
            }   
            
            if(ValidatorForm.NotNullValidator("<%=TbVerifyCode.ClientID%>")==false)
            {
                b=false;
                document.getElementById("<%=LbCode.ClientID%>").innerHTML="请输入验证码";
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
    <div class="other_Header">
        <yk:Top runat="server" />
    </div>
    <!--Hearer End-->
    <div class="Contain_Login">
        <h3>
            <b>用户登录</b><span></span></h3>
        <div class="Box">
            <div class="login_box">
                <table border="0" cellspacing="0" cellpadding="0" class="table">
                    <tr>
                        <td class="name">
                            输入用户名：
                        </td>
                        <td>
                            <yk:TextBox runat="server" ID="TbMemberName" CssClass="text" onmouseover="this.className='text2';"
                                onmouseout="this.className='text';" Style="width: 246px;"></yk:TextBox>
                            <span id="name" style="color:Red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="name">
                            输入密码：
                        </td>
                        <td>
                            <yk:TextBox runat="server" ID="TbMemberPwd" TextMode="Password" CssClass="text" onmouseover="this.className='text2';"
                                onmouseout="this.className='text';" Style="width: 246px;"></yk:TextBox>
                            <span id="pwd" style="color:Red;">*</span> <a href="#">忘记密码?</a>
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
                            <asp:Label ID="LbCode" runat="server" Text="*" CssClass="tips" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <yk:Button runat="server" ID="BtnSubmit" class="button_login" onfocus="this.blur()"
                                OnClientClick="return ValidatiorForm()" OnClick="BtnSubmit_Click" />
                             
                             <asp:Label ID="LbTooltip" runat="server" Text="*" CssClass="tips" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
                <dl class="txt">
                    使用合作网站账号登录梦科商城：</dl>
                <!-- 分享 BEGIN -->
                <div class="share">
                    <div id="ckepop">
                        <table border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    <a title="分享到新浪微博" class="jiathis_button_tsina">新浪微博</a> <a title="分享到QQ空间" class="jiathis_button_qzone">
                                        QQ空间</a> <a title="分享到开心网" class="jiathis_button_kaixin001">开心网</a> <a title="分享到人人网"
                                            class="jiathis_button_renren">人人网</a>
                                </td>
                                <td>
                                    <a href="http://www.jiathis.com/share/" class="jiathis jiathis_txt jtico jtico_jiathis"
                                        target="_blank">更多>></a>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>

                <script type="text/javascript" src="http://v1.jiathis.com/code/jia.js" charset="utf-8"></script>

                <!-- 分享 END -->
            </div>
            <div class="register_box">
                <b>还不是商店用户？</b><br />
                现在免费注册成为商店用户，便能立刻享受便宜又放心的购物乐趣。
                <input type="button" name="button2" id="button2" value="" class="button_register"
                    onclick="location.href='Register.aspx'" onfocus="this.blur()" />
            </div>
        </div>
    </div>
    <!--Footer-->
    <yk:Bottom runat="server" />
    <!--Footer End-->
    </form>
</body>
</html>
