<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Admin_Index" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title></title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link type="text/css" rel="stylesheet" href="js/templet/Default/silverStyle.css" />
<script src="js/AmysqlFun.js" type="text/javascript"></script>
<script src="js/AmysqlConfig.js" type="text/javascript"></script>
<script src="js/AmysqlMain.js" type="text/javascript"></script>

<script src="js/PlugIn/PluginManage/AmysqlPluginManage.js" type="text/javascript" charset="UTF-8"></script>
<script src="js/PlugIn/AllTag/AmysqlAllTag.js" type="text/javascript" charset="UTF-8"></script>
<script src="js/PlugIn/NewTag/AmysqlNewTag.js" type="text/javascript" charset="UTF-8"></script>
<script src="js/PlugIn/AmysqlRecoveryTag.js" type="text/javascript" charset="UTF-8"></script>
<script src="js/PlugIn/AmysqlNextTag.js" type="text/javascript" charset="UTF-8"></script>
<script src="js/PlugIn/AmysqlPreviousTag.js" type="text/javascript" charset="UTF-8"></script>
<script src="js/PlugIn/AmysqlCloseTag.js" type="text/javascript" charset="UTF-8"></script>

</head>
<script type="text/javascript">
    // 控制整体加载开始 ***************
    window.onload = function () {
        G("AmysqlContent").src = _ContentUrl;
        _AmysqlContent = window.frames.AmysqlContent;
        _AmysqlLeft = window.frames.AmysqlLeft;
        _AmysqlTag = window.frames.AmysqlTag;
    }

    // 设置默认打开的标签列表
    var _AmysqlTabJson = [{ 'type': 'Normal', 'id': 'AmysqlHome', 'name': '主页界面', 'url': 'main.aspx' }];

    // 设置左栏列表数据
    var _AmysqlLeftListJson = [
        <%=menu %>
    ];

</script>
<frameset rows="58,31,*" cols="*" border="0" framespacing="0">
    <frame  name="header" id="header" scrolling="No" src="header.aspx" frameborder="0" border="0" noresize />
	<frame  name="AmysqlTag" id="AmysqlTag" scrolling="No" frameborder="0" border="0" noresize >    
	<frameset rows="*" cols="223,*" border="0"  framespacing="0">
		<frame  name="AmysqlLeft"  id="AmysqlLeft" frameborder="0" border="0" >
		<frame  scrolling="No" name="AmysqlContent" id="AmysqlContent"  frameborder="0" border="0">
	</frameset>
</frameset>
</HTML>
