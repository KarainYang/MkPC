<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Map.aspx.cs" Inherits="Map" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
          <object id="FlashID" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" width="800" height="500">
                 <param name="movie" value="media/map.swf?id=media/link.txt" />
                 <param name="quality" value="high" />
                 <param name="wmode" value="opaque" />
                 <param name="swfversion" value="8.0.35.0" />
                 <!-- 此 param 标签提示使用 Flash Player 6.0 r65 和更高版本的用户下载最新版本的 Flash Player。如果您不想让用户看到该提示，请将其删除。 -->
                 <param name="expressinstall" value="media/expressInstall.swf" />
                 <!-- 下一个对象标签用于非 IE 浏览器。所以使用 IECC 将其从 IE 隐藏。 -->
                 <!--[if !IE]>-->
                 <object type="application/x-shockwave-flash" data="media/map.swf?id=media/link.txt" width="800" height="500">
                   <!--<![endif]-->
                   <param name="quality" value="high" />
                   <param name="wmode" value="opaque" />
                   <param name="swfversion" value="8.0.35.0" />
                   <param name="expressinstall" value="media/expressInstall.swf" />
                   <!-- 浏览器将以下替代内容显示给使用 Flash Player 6.0 和更低版本的用户。 -->
                   <div>
                     <h4>此页面上的内容需要较新版本的 Adobe Flash Player。</h4>
                     <p><a href="http://www.adobe.com/go/getflashplayer"><img src="http://www.adobe.com/images/shared/download_buttons/get_flash_player.gif"
                      alt="获取 Adobe Flash Player" width="112" height="33" /></a></p>
                   </div>
                   <!--[if !IE]>-->
                 </object>
                 <!--<![endif]-->
               </object>
    </form>
</body>
</html>
