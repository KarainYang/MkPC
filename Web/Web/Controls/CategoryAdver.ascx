<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CategoryAdver.ascx.cs" Inherits="Controls_HomeCategoryAdver" %>
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
            .YFocus<%=ProCategoryId%>{position:relative;z-index:4;margin:0px auto;width:<%=adver.PicWidth %>;height:<%=adver.PicHeight %>;overflow:hidden; float:left;}
            .YImage<%=ProCategoryId%>,.YImage<%=ProCategoryId%> .YPhotos<%=ProCategoryId%>{margin:0 auto;overflow:hidden;width:<%=adver.PicWidth %>;padding:0; }
            .YImage<%=ProCategoryId%>{position:relative;z-index:5;}
            .YImage<%=ProCategoryId%>,.YPhotos<%=ProCategoryId%> img{width:<%=adver.PicWidth %>;height:<%=adver.PicHeight %>;}
            .YPhotos<%=ProCategoryId%>{position:absolute;top:0;left:0;z-index:6;overflow:hidden;}
            .YPhotos<%=ProCategoryId%> img{ float:left;clear:both;}
            .YFocus<%=ProCategoryId%> .YSamples<%=ProCategoryId%>{position:absolute;z-index:7;width:<%=adver.PicWidth %>;height:45px;overflow:hidden;bottom:0px;left:0px;background-color:#BAB5AE;opacity:.7;-moz-opacity:.7;filter:alpha(opacity=70);padding:0;}
            .YSamples<%=ProCategoryId%> a:link,.YSamples<%=ProCategoryId%> a:visited,.YSamples<%=ProCategoryId%> a:hover{position:relative;z-index:8;float:left;margin:5px 5px 8px 5px;display:inline;width:50px;height:43px;text-decoration:none;overflow:hidden;}
            .YSamples<%=ProCategoryId%> a img{border:2px solid #FFF;width:40px;height:30px;opacity:.4;-moz-opacity:.4;filter:alpha(opacity=40);}
            .YSamples<%=ProCategoryId%> a:hover img,.YSamples<%=ProCategoryId%> img.current{opacity:1;-moz-opacity:1;filter:alpha(opacity=100);}
        </style>
        <div class="YFocus<%=ProCategoryId%>">
             <div class="YImage<%=ProCategoryId%>">
                  <p id="YPhotos<%=ProCategoryId%>" class="YPhotos<%=ProCategoryId%>">
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
             <p id="YSamples<%=ProCategoryId%>" class="YSamples<%=ProCategoryId%>">
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
                    tabs: YAO.getEl('YSamples<%=ProCategoryId%>').getElementsByTagName('img'),
                    contents: YAO.getEl('YPhotos<%=ProCategoryId%>').getElementsByTagName('img'),
                    auto: true,
                    scroll: true,
                    scrollId: 'YPhotos<%=ProCategoryId%>'
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
            #YSlide<%=ProCategoryId%>{position:relative;z-index:1;margin:0 auto;width:<%=adver.PicWidth %>;height:<%=adver.PicHeight %>;padding:0px;border:0px solid #B0BEC7;overflow:hidden; float:left;}
            #YSlide<%=ProCategoryId%> .YSample<%=ProCategoryId%>{margin:0 auto;overflow:hidden;padding:0;}
            #YSlide<%=ProCategoryId%> .YSample<%=ProCategoryId%>,#YSlide<%=ProCategoryId%> .YSample<%=ProCategoryId%> img{width:<%=adver.PicWidth %>;height:<%=adver.PicHeight %>;}
            #YSlide<%=ProCategoryId%> #jSIndex<%=ProCategoryId%>{position:absolute;z-index:6;top:<%= (adver.PicHeight.ToLower().Replace("px","").ToDecimal()-42) %>px;left:4px;width:<%=adver.PicWidth %>;text-align:right;height:30px;line-height:30px;overflow:hidden;padding:0;}
            #jSIndex<%=ProCategoryId%> a{color:Red; background-color:white;}
            #jSIndex<%=ProCategoryId%> a:link,#jSIndex<%=ProCategoryId%> a:visited,#jSIndex<%=ProCategoryId%> a:hover{position:relative;z-index:6;padding:0px 3px;border:1px solid red;color:red;margin-right:0px;text-decoration:none;font-size:14px;}
            #jSIndex<%=ProCategoryId%> a:hover,#jSIndex<%=ProCategoryId%> a.current:link,#jSIndex<%=ProCategoryId%> a.current:visited,#jSIndex<%=ProCategoryId%> a.current:hover{background-color:red;color:White;}
        </style>
            <div id="YSlide<%=ProCategoryId%>">
                  <%
                        foreach (var item in picList)
                        {
                          %>
                   
                    <p class="YSample<%=ProCategoryId%>">
                        <a href="<%=item.LinkUrl %>" target="_blank">
                            <img src="<%=YK.Common.CommonClass.AppPath +item.PicUrl %>" />
                        </a>
                    </p>
                    <%
                        }
                         %>                              
                  <p id="jSIndex<%=ProCategoryId%>">
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
                        tabs: YAO.getEl('jSIndex<%=ProCategoryId%>').getElementsByTagName('a'),
                        contents: YAO.getElByClassName('YSample<%=ProCategoryId%>', 'p', 'YSlide<%=ProCategoryId%>'),
                        defaultIndex: 1,
                        auto: true,
                        fadeUp: true
                    });
                })();               
          </script>
<%
    }
     %>