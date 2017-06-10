<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProBulletin.ascx.cs" Inherits="Controls_ProBulletin" %>
<%@ Import Namespace="YK.Model" %>
<%@ Import Namespace="YK.Common" %>

<div class="Wrap_Bulletin">
    <h3><span><a href="<%=CommonClass.AppPath+"info/News.aspx?code=0001"%>">更多>></a></span><b>商店公告</b></h3>
    <div class="Box">
        <ul>
            <%               
                foreach (TB_Info_News news in newsList)
                {
                %>
                <li><a href="<%= CommonClass.AppPath+"info/NewsDetails.aspx?id="+news.ID%>" title="<%=news.Title %>"><%=news.Title.SubstringStr(15)%></a></li> 
            <%           
                }
                 %>
        </ul>
    </div>
    <div class="BottomEdge"></div>
</div>