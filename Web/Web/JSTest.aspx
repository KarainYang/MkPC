<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JSTest.aspx.cs" Inherits="JSTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/Common.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function MyClass(){}
        MyClass.prototype = {
            MobileCheck: function (obj) {
                alert("这里是核查手机号码！");
                return false;
            },
            EmailCheck: function (obj) {
                alert("这里是核查邮箱！");
                return false;
            },
            PhoneCheck: function (obj) {
                alert("这里是核查电话号码！");
                return false;
            },
            FaxCheck: function (obj) {
                alert("这里是核查传真号码！");
                return false;
            }
        };

        function CheckTest()
        {
            var checkInfo = new MyClass();
            return checkInfo.MobileCheck('');
        }
    </script>
    <script>
        //指定控件进行验证
        function checkForm() {
            if (ValidatorForm.NotNullValidator("mobile", "请输入手机号码！") == false)
                return false;
            if (ValidatorForm.Mobile("mobile", "很抱歉您的手机号码未通过验证！") == false)
                return false;
            if (ValidatorForm.Email("email", "很抱歉您的邮箱未通过验证！") == false)
                 return false;
            if (ValidatorForm.Phone("phone", "很抱歉您的电话号码未通过验证！") == false)
                return false;
            if ( ValidatorForm.Mobile("fax", "很抱歉您的传真号码未通过验证！")== false)
                return false;     
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">

    <div class="allValidator">
        <input type="text" id="mobile"  isRequired="True" validator="手机" title="手机号码" tooltip="请输入手机号码"/>
        <input type="text"  id="phone" isRequired="True" validator="电话" title="电话号码" tooltip="请输入电话号码"/>
        <input type="text"  id="email" isRequired="True" validator="邮箱" title="邮箱" tooltip="请输入邮箱"/>
        <input type="text"  id="fax" isRequired="True" validator="传真" title="传真" tooltip="请输入传真"/>
        <input type="submit" value="提交" onclick="return VerificationForm('allValidator');"/>
    </div>
    

    <div>
        核查手机号码:<input type="text" value="" id="mobile"/>
        核查邮箱:<input type="text" value="" id="email" />
        核查电话号码:<input type="text" value="" id="phone" />
        核查传真号码:<input type="text" value="" id="fax" />
        <input type="submit" value="测试" onclick="return checkForm()" />
    </div>
    </form>
</body>
</html>
