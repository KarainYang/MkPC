<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Adver.aspx.cs" Inherits="Adver" %>
<%@ Import Namespace="System.Linq" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"></head>
<style>    
    body,a,img{ margin:0px; padding:0px; border:0px;}
</style>
<body>
<%
    if (adver.AdverType == 0)
    {
        if (picList.Count > 0)
        {
%>
    <a href="<%=picList.First().LinkUrl %>" target="_blank">
        <img src="<%=YK.Common.CommonClass.AppPath +picList.First().PicUrl %>" width="<%=adver.PicWidth %>" height="<%=adver.PicHeight %>" />
    </a>
<%
        }
    }
%>



<%
    if (adver.AdverType == 1)
    {
%>
<script language="javascript" type="text/javascript" src="scripts/ytabs.js"></script>
<style type="Text/css">
    div,p,a,img{margin:0px;padding:0px;}     
    .YFocus{position:relative;z-index:4;margin:0px auto;width:<%=adver.PicWidth %>;height:<%=adver.PicHeight %>;overflow:hidden; float:left;}
    .YImage,.YImage .YPhotos{margin:0 auto;overflow:hidden;width:430px;padding:0; }
    .YImage{position:relative;z-index:5;}
    .YImage,.YPhotos img{width:<%=adver.PicWidth %>;height:<%=adver.PicHeight %>;}
    .YPhotos{position:absolute;top:0;left:0;z-index:6;overflow:hidden;}
    .YPhotos img{ float:left;clear:both;}
    .YFocus .YSamples{position:absolute;z-index:7;width:<%=adver.PicWidth %>;height:45px;overflow:hidden;bottom:0px;left:0px;background-color:#BAB5AE;opacity:.7;-moz-opacity:.7;filter:alpha(opacity=70);padding:0;}
    .YSamples a:link,.YSamples a:visited,.YSamples a:hover{position:relative;z-index:8;float:left;margin:5px 5px 8px 5px;display:inline;width:50px;height:43px;text-decoration:none;overflow:hidden;}
    .YSamples a img{border:2px solid #FFF;width:40px;height:30px;opacity:.4;-moz-opacity:.4;filter:alpha(opacity=40);}
    .YSamples a:hover img,.YSamples img.current{opacity:1;-moz-opacity:1;filter:alpha(opacity=100);}
</style>
<div class="YFocus">
     <div class="YImage">
          <p id="YPhotos" class="YPhotos">
             <%
                foreach (var item in picList)
                {
                  %>
            <a href="<%=item.LinkUrl %>" target="_blank">
                <img src="<%=YK.Common.CommonClass.AppPath +item.PicUrl %>" width="<%=adver.PicWidth %>" height="<%=adver.PicHeight %>" />
            </a>
            <%
                }
                 %>
     </div>
     <p id="YSamples" class="YSamples">
        <%
            foreach (var item in picList)
            {
                %>
            <a href="#1" class="current" title="<%=item.Name %>">
                <img src="<%=YK.Common.CommonClass.AppPath + item.PicUrl %>" width="<%=adver.PicWidth %>" height="<%=adver.PicHeight %>" />
            </a>
        <%
            }
                %>
     </p>
</div>
<script language="javascript" type="text/javascript"> 
<!--
    (function () {
        YAO.YTabs({
            tabs: YAO.getEl('YSamples').getElementsByTagName('img'),
            contents: YAO.getEl('YPhotos').getElementsByTagName('img'),
            auto: true,
            scroll: true,
            scrollId: 'YPhotos'
        });
    })();
//-->
</script>

<%
            }
%>
</body>
</html>