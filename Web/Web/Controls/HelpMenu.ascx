<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HelpMenu.ascx.cs" Inherits="Controls_HelpMenu" %>
<%@ Import Namespace="YK.Common" %>

<div class="MemberMenu">
    <h2><span>帮助中心</span></h2>
    <div class="Box">    
        <yk:Repeater runat="server" ID="RepHelp" OnItemDataBound="RepHelp_ItemDataBind">
            <ItemTemplate>
                <h3>
                      <%# Eval("Name")%><asp:HiddenField runat="server" ID="CateogryId" Value='<%# Eval("ID") %>' />
                </h3>
                <ul>
                    <yk:Repeater runat="server" ID="RepList">
                        <ItemTemplate>
                            <li>
                                <a href="<%# CommonClass.AppPath+"info/Help.aspx?id="+Eval("id") %>">
                                    <%# Eval("Title")%>
                                </a>
                            </li>
                        </ItemTemplate>
                    </yk:Repeater>
                </ul>
            </ItemTemplate>
        </yk:Repeater>
    </div>
</div>
