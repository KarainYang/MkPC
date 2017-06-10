<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsMenu.ascx.cs" Inherits="Controls_NewsMenu" %>
<%@ Import Namespace="YK.Common" %>

<div class="MemberMenu">
    <h2><span>信息中心</span></h2>
    <div class="Box">    
            <ul>
                <yk:Repeater runat="server" ID="RepList">
                    <ItemTemplate>
                        <li>
                            <a href="<%# CommonClass.AppPath+"info/News.aspx?code="+Eval("code") %>">
                                <%# Eval("Name")%>
                            </a>
                        </li>
                    </ItemTemplate>
                </yk:Repeater>
            </ul>
    </div>
</div>
