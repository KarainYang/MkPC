<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProCategory.ascx.cs" Inherits="Controls_ProCategory" %>

<div class="Wrap_Category">
    <h2><span class="Arrow"><a></a></span><b>商品分类</b></h2>
    <div class="hideMenu">
        <div class="Box" <%= IsHome?"style='height:288px;'":""%> >
            <asp:Repeater runat="server" ID="RepCategory" onitemdatabound="RepCategory_ItemDataBound">
                <ItemTemplate>
                    <div class="item">
                        <h3><a href="<%# YK.Common.CommonClass.AppPath+"product/products.aspx?categoryId="+Eval("ID") %>"><%# Eval("CategoryName") %></a></h3>
                        <!--Start-->
                        <div class="hideDiv">
                            <div class="close">
                            </div>
                            <div class="subitem">
                                <asp:HiddenField runat="server" ID="HiddenFieldID" Value='<%# Eval("ID") %>' />
                                <asp:Repeater runat="server" ID="RepChildCategory" onitemdatabound="RepChildCategory_ItemDataBound">
                                    <ItemTemplate>
                                        <dl>
                                            <dt><a href="<%# YK.Common.CommonClass.AppPath+"product/products.aspx?categoryId="+Eval("ID") %>"><%# Eval("CategoryName") %></a></dt>
                                            <dd>                                                
                                                <asp:HiddenField runat="server" ID="HiddenFieldID" Value='<%# Eval("ID") %>' />
                                                <asp:Repeater runat="server" ID="RepChildCategory">
                                                    <ItemTemplate>
                                                        <em><a href="<%# YK.Common.CommonClass.AppPath+"product/products.aspx?categoryId="+Eval("ID") %>">
                                                        <%# Eval("CategoryName") %></a></em>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                           </dd>
                                        </dl>
                                    </ItemTemplate>
                                </asp:Repeater> 
                            </div>
                            <!--R Start-->
                            <div class="fr">
                                <div class="brands">
                                    <h4>
                                        推荐品牌</h4>
                                    <dl>
                                        <asp:Repeater runat="server" ID="RepBrands">
                                            <ItemTemplate>
                                                <em><a href="<%# YK.Common.CommonClass.AppPath+"product/products.aspx?brandId="+Eval("ID") %>"><%# Eval("BrandName")%></a></em>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </dl>
                                </div>
                                <div class="promotion">
                                    <h4>
                                        促销活动</h4>
                                    <ul>
                                        <li><a href="#">买相机开学返券~返现~返惊喜！</a></li>
                                        <li><a href="#">现在入网联通沃3G，iPad2、Nano、话费、充值卡、京券大放送！</a></li>
                                    </ul>
                                </div>
                            </div>
                            <!--R End-->
                        </div>
                        <!--End-->
                    </div>
                </ItemTemplate>
            </asp:Repeater>                        
        </div>
        <div class="BottomEdge">
            <a href="<%=YK.Common.CommonClass.AppPath + "product/Categorys.aspx"%>">全部商品分类>></a></div>
    </div>
</div>

<script type="text/javascript">
		$(".Wrap_Category .item").bind("mouseover",function(){
			$(this).find("a").attr("class","show");
			$(this).find(".hideDiv").show();
			
		})
		$(".Wrap_Category .item").bind("mouseleave",function(){
			$(this).find(".hideDiv").hide();
			$(this).find("a").attr("class","");
		})
		$(".close").bind("click",function(){
			$(this).parent().hide();
			$(this).parent().parent().find("a").attr("class","");
										  })
		
</script>

<script type="text/javascript">
	  jQuery(".Wrap_Category .Arrow").bind("mouseover",function(){
		  jQuery(".hideMenu").show();       
	  })
	  jQuery(".Wrap_Category").bind("mouseleave",function(){
		  jQuery(".hideMenu").hide();
	  })
</script>

