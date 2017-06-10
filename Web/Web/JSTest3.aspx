<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JSTest3.aspx.cs" Inherits="JSTest3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        span{ color:Red;}
    </style>
    <script src="js/jquery.js" type="text/javascript"></script>
   <%-- <script src="js/Common_Name.js" type="text/javascript"></script>--%>

    <script src="scripts/Validator.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        类别：    <select id="select" GroupName="validation" LabelID="lbselect" title="类别"><option>笔记本</option></select>
        <span id="lbselect"> * </span><br />
        核查手机号码:<input type="text" value="" id="mobile" Title="手机号码"  Validator="手机" GroupName="validation" LabelID="lbMobile"/>
        <span id="lbMobile"> * </span> <br />
        核查邮箱:<input type="text" value="" id="email"  Title="邮箱"  GroupName="validation"  LabelID="lbemail"/>
        <span id="lbemail">*</span><br />
        核查电话号码:<input type="text" value="" id="phone"  Title="电话号码"  GroupName="validation"  LabelID="lbphone"/>
        <span id="lbphone">*</span><br />
        核查传真号码:<input type="text" value="" id="fax"  Title="传真号码"  GroupName="validation"  LabelID="lbfax"/>
        <span id="lbfax">*</span><br />
        <input type="submit" value="测试" onclick="return VerificationForm('validation')" />
    </div>
    </form>
</body>
</html>
