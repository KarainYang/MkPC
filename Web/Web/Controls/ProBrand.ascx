<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProBrand.ascx.cs" Inherits="Controls_ProBrand" %>

<div class="Wrap_Brand">
    <h3><span><a href="<%= YK.Common.CommonClass.AppPath+"product/Brands.aspx"%>">更多>></a></span><b>热销品牌</b></h3>
    <div class="Box">
      <ul>
        <asp:Repeater runat="server" ID="RepBrand">
            <ItemTemplate>
                <li>
                    <a href="<%# YK.Common.CommonClass.AppPath+"product/products.aspx?brandId="+Eval("ID") %>" title="<%# Eval("BrandName") %>">
                        <img src="<%#  Eval("PicUrl") %>" onerror="this.src='<%= YK.Common.CommonClass.AppPath %>style/red/images/nopic.jpg';" width="85px" height="47px" />
                    </a>
                </li>
            </ItemTemplate>
        </asp:Repeater>
      </ul>
    </div>
    <div class="BottomEdge"></div>
</div>