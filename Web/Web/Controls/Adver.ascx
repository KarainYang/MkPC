<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Adver.ascx.cs" Inherits="Controls_Adver" %>
<%@ Import Namespace="YK.Common" %>
<style>    
    body,a,img{ margin:0px; padding:0px; border:0px;}
</style>
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
        <script language="javascript" type="text/javascript" src="<%= YK.Common.CommonClass.AppPath %>scripts/ytabs.js"></script>
        <style type="Text/css">
            div,p,a,img{margin:0px;padding:0px;}     
            .YFocus<%=Code%>{position:relative;z-index:4;margin:0px auto;width:<%=adver.PicWidth %>;height:<%=adver.PicHeight %>;overflow:hidden; }
            .YImage<%=Code%>,.YImage<%=Code%> .YPhotos<%=Code%>{margin:0 auto;overflow:hidden;width:<%=adver.PicWidth %>;padding:0; }
            .YImage<%=Code%>{position:relative;z-index:5;}
            .YImage<%=Code%>,.YPhotos<%=Code%> img{width:<%=adver.PicWidth %>;height:<%=adver.PicHeight %>;}
            .YPhotos<%=Code%>{position:absolute;top:0;left:0;z-index:6;overflow:hidden;}
            .YPhotos<%=Code%> img{ float:left;clear:both;}
            .YFocus<%=Code%> .YSamples<%=Code%>{position:absolute;z-index:7;width:<%=adver.PicWidth %>;height:45px;overflow:hidden;bottom:0px;left:0px;background-color:#BAB5AE;opacity:.7;-moz-opacity:.7;filter:alpha(opacity=70);padding:0;}
            .YSamples<%=Code%> a:link,.YSamples<%=Code%> a:visited,.YSamples<%=Code%> a:hover{position:relative;z-index:8;float:left;margin:5px 5px 8px 5px;display:inline;width:50px;height:43px;text-decoration:none;overflow:hidden;}
            .YSamples<%=Code%> a img{border:2px solid #FFF;width:40px;height:30px;opacity:.4;-moz-opacity:.4;filter:alpha(opacity=40);}
            .YSamples<%=Code%> a:hover img,.YSamples<%=Code%> img.current{opacity:1;-moz-opacity:1;filter:alpha(opacity=100);}
        </style>
        <div class="YFocus<%=Code%>">
             <div class="YImage<%=Code%>">
                  <p id="YPhotos<%=Code%>" class="YPhotos<%=Code%>">
                     <%
                        foreach (var item in picList)
                        {
                          %>
                    <a href="<%=item.LinkUrl %>" target="_blank">
                        <img src="<%=YK.Common.CommonClass.AppPath +item.PicUrl %>" />
                    </a>
                    <%
                        }
                         %>
                    </p>
             </div>
             <p id="YSamples<%=Code%>" class="YSamples<%=Code%>">
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
                    tabs: YAO.getEl('YSamples<%=Code%>').getElementsByTagName('img'),
                    contents: YAO.getEl('YPhotos<%=Code%>').getElementsByTagName('img'),
                    auto: true,
                    scroll: true,
                    scrollId: 'YPhotos<%=Code%>'
                });
            })();
        //-->
        </script>

<%
     }
    if (adver.AdverType == 2)
    {
%>
        <style>
            #YSlide<%=Code%>{position:relative;z-index:1;margin:0 auto;width:<%=adver.PicWidth %>;height:<%=adver.PicHeight %>;padding:0px;border:0px solid #B0BEC7;overflow:hidden;}
            #YSlide<%=Code%> .YSample<%=Code%>{margin:0 auto;overflow:hidden;padding:0;}
            #YSlide<%=Code%> .YSample<%=Code%>,#YSlide<%=Code%> .YSample<%=Code%> img{width:<%=adver.PicWidth %>;height:<%=adver.PicHeight %>;}
            #YSlide<%=Code%> #jSIndex<%=Code%>{position:absolute;z-index:6;top:<%= (adver.PicHeight.ToLower().Replace("px","").ToDecimal()-42) %>px;left:4px;width:<%=adver.PicWidth %>;text-align:right;height:30px;line-height:30px;overflow:hidden;padding:0;}
            #jSIndex<%=Code%> a{color:Red; background-color:white;}
            #jSIndex<%=Code%> a:link,#jSIndex<%=Code%> a:visited,#jSIndex<%=Code%> a:hover{position:relative;z-index:6;padding:0px 3px;border:1px solid red;color:red;margin-right:0px;text-decoration:none;font-size:14px;}
            #jSIndex<%=Code%> a:hover,#jSIndex<%=Code%> a.current:link,#jSIndex<%=Code%> a.current:visited,#jSIndex<%=Code%> a.current:hover{background-color:red;color:White;}
        </style>
            <div id="YSlide<%=Code%>">
                  <%
                        foreach (var item in picList)
                        {
                          %>
                   
                    <p class="YSample<%=Code%>">
                        <a href="<%=item.LinkUrl %>" target="_blank">
                            <img src="<%=YK.Common.CommonClass.AppPath +item.PicUrl %>" />
                        </a>
                    </p>
                    <%
                        }
                         %>                              
                  <p id="jSIndex<%=Code%>">
                      <%
                            for (int i = 1; i <= picList.Count; i++)
                            {
                           %>
                            <%
                                if (i == 1)
                                {
                                %>
                                <a href="#1" class="current">1</a>
                            <%
                                }
                                else
                                {
                                    %>
                                <a href="#1"><%= i %></a>
                             <% 
                                 } 
                                 %>
                     <%
                            }
                        %>
                        &nbsp;
                  </p>
            </div>
            <script language="javascript" type="text/javascript" src="<%= YK.Common.CommonClass.AppPath %>scripts/ytabs.js"></script>
            <script language="javascript" type="text/javascript">
                (function () {
                    YAO.YTabs({
                        tabs: YAO.getEl('jSIndex<%=Code%>').getElementsByTagName('a'),
                        contents: YAO.getElByClassName('YSample<%=Code%>', 'p', 'YSlide<%=Code%>'),
                        defaultIndex: 1,
                        auto: true,
                        fadeUp: true
                    });
                })();               
          </script>
<%
    }
     %>