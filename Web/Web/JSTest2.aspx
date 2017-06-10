<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JSTest2.aspx.cs" Inherits="JSTest2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        span{ color:Red;}
    </style>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/Common2.js" type="text/javascript"></script>
    <script type="text/javascript">
        //指定控件进行验证
        function checkForm() {
            var b = true;
            if (ValidatorForm.NotNullValidator("mobile", "请输入手机号码！", "lbMobile") == false)
                b= false;
            if (ValidatorForm.Mobile("mobile", "很抱歉您的手机号码未通过验证！", "lbMobile") == false)
                b = false;
            if (ValidatorForm.Email("email", "很抱歉您的邮箱未通过验证！", "lbemail") == false)
                b = false;
            if (ValidatorForm.Phone("phone", "很抱歉您的电话号码未通过验证！", "lbphone") == false)
                b = false;
            if (ValidatorForm.Fax("fax", "很抱歉您的传真号码未通过验证！", "lbfax") == false)
                b = false;
            return b;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        核查手机号码:<input type="text" value="" id="mobile"/><span id="lbMobile"> </span> <br />
        核查邮箱:<input type="text" value="" id="email" /><span id="lbemail"></span><br />
        核查电话号码:<input type="text" value="" id="phone" /><span id="lbphone"></span><br />
        核查传真号码:<input type="text" value="" id="fax" /><span id="lbfax"></span><br />
        <input type="submit" value="测试" onclick="return checkForm()" />
    </div>
    </form>
</body>
</html>
