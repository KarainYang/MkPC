<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Bottom.ascx.cs" Inherits="Controls_Bottom" %>
<%@ Import Namespace="YK.Common" %>

<div class="Footer">
    <div class="Footer_nav"><a href="<%=CommonClass.AppPath %>index.aspx">首页</a> | 
    <a href="<%=CommonClass.AppPath %>info/help.aspx">帮助中心</a> | 
    <a href="<%=CommonClass.AppPath %>info/AboutUs.aspx?code=10001">关于我们</a> | 
    <a href="<%=CommonClass.AppPath %>info/AboutUs.asp?code=10002">网站地图</a> | 
    <a href="<%=CommonClass.AppPath %>info/AboutUs.asp?code=10003">意见与反馈</a> | 
    <a href="<%=CommonClass.AppPath %>info/AboutUs.aspx?code=10004">招贤纳士</a> | 
    <a href="#">网站联盟</a></div>
    <div class="Footer_copyright">
    <%=webSet.Copyright %><br />
    <%=webSet.ICP %>
    </div>
    <div class="Footer_security">
        <ul>
            <li class="a1">广州网络警察报警平台</li>
            <li class="a2">公共信息安全网络监察</li>
            <li class="a3">经营性网站备案信息</li>
            <li class="a4">不良信息举报中心</li>
            <li class="a5">网上交易保障中心</li>
        </ul>
    </div>
</div>