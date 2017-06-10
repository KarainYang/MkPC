<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebPicture.aspx.cs" Inherits="Admin_WebPicture" %>


<%@ Register src="../../Controls/UploadWebImg.ascx" tagname="UploadWebImg" tagprefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../../css/Style.css" rel="stylesheet" type="text/css" />   
</head>
<body>
    <form id="form1" runat="server">
        <div id="TopTitle">
            修改网站图片
        </div>
         <table class="ordertable" width="100%" border="0" cellpadding="0" cellspacing="0">
               <tr>
                    <th style="width:180px;">首页视频更换：</th>
                    <td>                                             
                        <uc1:UploadWebImg ID="UploadWebImg1" runat="server" Url="~/images/lmzc.swf" /> 大小：347*300 ，视频类型.swf                                      
                    </td> 
                </tr> 
                <tr>
                    <th>会员证书查询左边图片：</th>
                    <td class="order_title">                                             
                        <uc1:UploadWebImg ID="UploadWebImg2" runat="server" Url="~/images/adver03.jpg" /> 大小：347*300 ，视频类型.swf                                      
                    </td> 
                </tr> 
            </table>  
    </form>
</body>
</html>
