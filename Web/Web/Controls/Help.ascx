<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Help.ascx.cs" Inherits="Controls_Help" %>
<%@ Import Namespace="YK.Common" %>

<div class="Footer_Help">
    <ul>
        <yk:Repeater runat="server" ID="RepHelp" OnItemDataBound="RepHelp_ItemDataBind">
            <ItemTemplate>
                 <li><em><%# Eval("Name")%><asp:HiddenField runat="server" ID="CateogryId" Value='<%# Eval("ID") %>' /></em>
                    <yk:Repeater runat="server" ID="RepList">
                        <ItemTemplate>
                            <a href='<%# CommonClass.AppPath+"info/Help.aspx?id="+Eval("id") %>'>
                                <%# Eval("Title")%>
                            </a>
                        </ItemTemplate>
                    </yk:Repeater>
                </li>   
            </ItemTemplate>
        </yk:Repeater>
    </ul>
</div>
<div class="Footer_link">
    <ul>
        <yk:Repeater runat="server" ID="RepLinks">
            <ItemTemplate>
                <li><a href="<%# Eval("Url") %>" target="_blank"><img src="<%# CommonClass.AppPath+Eval("ImgUrl") %>"></a></li>
            </ItemTemplate>
        </yk:Repeater>
    </ul>
</div>