<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Success.aspx.cs" Inherits="member_Success" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta name="Author" content="梦科商城">
    <title>梦科商城</title>
    <link href="../style/red/css_member.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../Scripts/jquery-1.4.2.min.js"></script>

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
            <b>注册成功</b><span></span></h3>
        <div class="Box">
            <div class="Success">
                <h5>
                    恭喜，注册成功！</h5>
                <p>
                    您登录梦科商城的用户名为：<font><%= Request["userName"]%></font>，您随时可使用此用户名享受便宜又放心的购物乐趣。</p>
                <input id="Button1" type="button" value="" class="btn_Shopping" onclick="location.href='<%=YK.Common.CommonClass.AppPath+"index.aspx" %>'"
                    onfocus="this.blur()" />
                <input id="Button2" type="button" value="" class="btn_Member" onclick="location.href='index.shtml'"
                    onfocus="this.blur()" />
            </div>
        </div>
    </div>
    <!--Footer-->
    <yk:Bottom runat="server" />
    <!--Footer End-->
    </form>
</body>
</html>
