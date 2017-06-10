<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Product2.aspx.cs" Inherits="product_Product2" %>

<%@ Import Namespace="YK.Common" %>
<%@ Import Namespace="YK.Model" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta name="Author" content="">
    <title>梦科商城</title>
    <link href="../style/red/css.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../Scripts/jquery-1.4.2.min.js"></script>

    <script type="text/javascript" src="../scripts/ScrollPic.js"></script>

    <script type="text/javascript" src="../Scripts/pngimg.js"></script>
    <script language="javascript" type="text/javascript">
        var navId = 0;
    </script>
</head>
<body class="bgbody">
    <form id="form1" runat="server">
    <!--Hearer-->
    <yk:Top runat="server" />
    <!--Hearer End-->
    <div class="Contain">
        <!--商品分类-->
        <yk:ProCategory runat="server" />
        <!--商品分类End-->
        <div class="Current">
            当前位置：<a href="<%=YK.Common.CommonClass.AppPath+"index.aspx" %>">首页</a>
            -> 商品 -> <font><%=Product.ProName %></font></div>
        <!--Left-->
        <div class="Sidebar">
            <!--今日特价-->
            <yk:ProSpecials runat="server" />
            <!--今日特价End-->
            <div class="space">
            </div>
            <!--新品-->
            <yk:ProNew runat="server" />
            <!--新品End-->
            <div class="space">
            </div>
            <!--热卖新品-->
            <yk:ProHotNew runat="server" />
            <!--热卖新品End-->
            <div class="space">
            </div>
            <!--最近浏览过的商品-->
            <yk:ProBrowse runat="server" />
            <!--最近浏览过的商品End-->
        </div>
        <!--Left End-->
        <!--Right Start-->
        <div class="Maincontent">
            <!--产品End-->
            <div class="Wrap_ProInfo">
                <h5 class="ProName">
                    <%=Product.ProName %><%--<span class="select"></span>--%></h5>
                <div id="preview">

                    <script type="text/javascript" src="../scripts/base.js"></script>

                    <div class="jqzoom" id="spec-n1">
                        <img class="Img" src="<%= CommonClass.AppPath+Product.PicUrl %>" jqimg="<%= CommonClass.AppPath+Product.PicUrl %>"
                            onerror="this.src='<%= YK.Common.CommonClass.AppPath %>style/red/images/nopic.jpg';" /></div>
                    <div id="spec-n5">
                        <div id="spec-left">
                        </div>
                        <div id="spec-list">
                            <ul class="list-h">
                                <li>
                                    <img src="<%= CommonClass.AppPath+Product.ImgUrl %>">
                                </li>
                                    <%
                                        foreach(TB_Product_Picture entity in picList)
                                        {
                                     %>
                                            <li>
                                                <img src="<%= CommonClass.AppPath+ entity.PicUrl %>">
                                            </li>
                                     <%
                                        }
                                      %>
                            </ul>
                        </div>
                        <div id="spec-right">
                        </div>
                    </div>
                </div>
                <!-- 分享 BEGIN -->
                <div class="ProShare">
                    <div id="ckepop">
                        <table border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    <a href="http://www.jiathis.com/share/" class="jiathis jiathis_txt jtico jtico_jiathis"
                                        target="_blank">分享到：</a>
                                </td>
                                <td>
                                    <a title="分享到新浪微博" class="jiathis_button_tsina">新浪微博</a> <a title="分享到QQ空间" class="jiathis_button_qzone">
                                        QQ空间</a> <a title="分享到开心网" class="jiathis_button_kaixin001">开心网</a> <a title="分享到人人网"
                                            class="jiathis_button_renren">人人网</a>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>

                <script type="text/javascript" src="http://v1.jiathis.com/code/jia.js" charset="utf-8"></script>

                <!-- 分享 END -->
                <div class="ProInfo">
                    <!--价格-->
                    <div class="Price">
                        <ul>
                            <li>
                                <dd>
                                    商品编号：</dd><dt><%=Product.ProNumber %></dt></li>
                            <li>
                                <dd>
                                    市场价格：</dd><dt><s>￥<%=Product.MarketPrice %></s></dt></li>
                            <li>
                                <dd>
                                    销售价格：</dd><dt><font>￥<%=Product.SalesPrice %></font></dt></li>
                            <li>
                                <dd>
                                    批发价格：</dd><dt><font>￥<%=Product.PurchasPrice %></font>(8件起) </dt>
                            </li>                           
                        </ul>
                        <div class="clear">
                        </div>
                    </div>
                    <!--价格End-->
                    <!--参数-->
                    <div class="Parameter">
                        <ul>
                            <li>
                                <dd>
                                    库存状况：</dd>
                                <dt>有货</dt>
                            </li>
                            <li>
                                <dd>
                                    尺寸：</dd>
                                <dt><span class="select">15寸以下</span><span>32寸以下</span></dt>
                            </li>
                            <li>
                                <dd>
                                    颜色：</dd>
                                <dt><span class="select">黑色</span><span>深灰色</span><span>浅灰色</span></dt>
                            </li>
                        </ul>
                        <div class="clear">
                        </div>
                    </div>
                    <!--参数End-->
                    <div class="Amount">
                        <script language="javascript">
                            function jia() {
                                    var val = parseInt($("#<%=TbCount.ClientID %>").val());
                                    $("#<%=TbCount.ClientID %>").val(val+1);

                                }
                                function jian() {
                                    var val = parseInt($("#<%=TbCount.ClientID %>").val());
                                    if (val > 1) {
                                        $("#<%=TbCount.ClientID %>").val(val - 1);
                                    }  
                                }
                        </script>
                        数量：<a href="javascript:jian()" class="jia">-</a>
                        <yk:TextBox runat="server" ID="TbCount" Text="1" Enabled="false"  CssClass="text"></yk:TextBox>
                        <a href="javascript:jia()" class="jian">+</a><br />
                        <input type="submit" name="button2" id="button2" value="" class="btn_advisory" />
                        <yk:Button runat="server" ID="BtnCollection" OnClick="BtnCollection_Click"  class="btn_favorites"/>
                        <asp:Button ID="BtnCart" runat="server" Text="" CssClass="btn_car" OnClick="BtnCart_Click" />
                    </div>
                    <div runat="server" id="MsgBox"></div>
                    <div class="Promotions">
                        <ul>
                            <li><a href="#">购物满99免运费>
                                <li><a href="#">购物满99免运费</a></li>
                                <li><a href="#">邀请好友现金回报</a></li>
                                <li><a href="#">购物满99免运费</a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <!--产品End-->
            <!--相关商品-->
            <div class="Wrap_Related">
                <h3 class="title">
                    <b>相关商品</b></h3>
                <div class="Box">
                    <div id="LeftArr2" class="LeftArrow">
                    </div>
                    <div id="ISL_Cont_2">
                        <ul>
                            <asp:Repeater ID="RepList" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <h5>
                                            <a href="Product.aspx?id=<%# Eval("id") %>" title="<%# Eval("ProName") %>" target="_blank">
                                                <%# Eval("ProName").SubstringStr(15) %></a></h5>
                                        <div class="picture">
                                            <a href="product.aspx?id=<%# Eval("id") %>" target="_blank" title="<%# Eval("ProName") %>">
                                                <img src="../<%# Eval("ImgUrl") %>" onerror="this.src='<%= YK.Common.CommonClass.AppPath %>style/red/images/nopic.jpg';" />
                                            </a>
                                        </div>
                                        <div class="price">
                                            <span>市场价：</span><s>￥<%# Eval("MarketPrice")%></s></div>
                                        <div class="price2">
                                            <span>销售价：</span><font>￥<%# Eval("SalesPrice")%></font></div>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    <div id="RightArr2" class="RightArrow">
                    </div>
                </div>
            </div>

            <script language="javascript" type="text/javascript">
				<!--//--><![CDATA[//><!--
				var scrollPic_01 = new ScrollPic();
				scrollPic_01.scrollContId   = "ISL_Cont_2"; //内容容器ID
				scrollPic_01.arrLeftId      = "LeftArr2";//左箭头ID
				scrollPic_01.arrRightId     = "RightArr2"; //右箭头ID

				scrollPic_01.frameWidth     = 720;//显示框宽度
				scrollPic_01.pageWidth      = 180; //翻页宽度

				scrollPic_01.speed          = 10; //移动速度(单位毫秒，越小越快)
				scrollPic_01.space          = 10; //每次移动像素(单位px，越大越快)
				scrollPic_01.autoPlay       = false; //自动播放
				scrollPic_01.autoPlayTime   = 3; //自动播放间隔时间(秒)

				scrollPic_01.initialize(); //初始化
									
				//--><!]]>
            </script>

            <!--相关商品End-->
            <!--商品介绍-->
            <div class="Wrap_ProDetail">
                <h3 class="title">
                    <b>商品介绍</b></h3>
                <div class="Box">
                    <!--start-->
                    <%= Product.ProDesc %>
                    <!--end-->
                </div>
            </div>
            <!--商品介绍End-->
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <!--商品评论-->
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="Wrap_ProComment" id="comment">
                        <h3 class="title">
                            <b>商品评论</b></h3>
                        <div class="Votes">
                            <ul>
                                <li><span><em style="width: 80%"></em></span>(好评) 94.87% 80票</li>
                                <li><span><em style="width: 20%"></em></span>(中评) 2.56% 5票</li>
                                <li><span><em style="width: 10%"></em></span>(差评) 2.56% 0票</li>
                            </ul>
                            <dd>
                                购买过该商品的用户才能进行评价</dd>
                        </div>
                        <div class="Box">
                            <!--start-->
                            <ul>
                                <asp:Repeater runat="server" ID="RepComments">
                                    <ItemTemplate>
                                        <li>
                                            <dt>
                                                <%# Eval("ComContent")%></dt>
                                            <dl>
                                                <%# Eval("AddDate") %>
                                                会员:<%# Eval("MemberID").GetEntity<YK.Model.TB_Member_Members>().MemberName %></dl>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                            <!--end-->
                        </div>
                        <!--Page-->
                        <div class="Pages">
                            <div class="page_total">
                                目前在第<span><%=AspNetPagerComments.CurrentPageIndex %></span>页，共有<span><%=AspNetPagerComments.PageCount %></span>页，共有<span><%=AspNetPagerComments.RecordCount %></span>条记录
                            </div>
                            <div class="page_num">
                                <yk:AspNetPager runat="server" ID="AspNetPagerComments" PageSize="3" FirstPageText="首页"
                                    LastPageText="末页" ShowPageIndexBox="Always" SubmitButtonClass="button" SubmitButtonText="确定"
                                    CurrentPageButtonClass="select" PageIndexBoxClass="text" OnPageChanging="AspNetPager1_PageChanging"
                                    PrevPageText="上一页" NextPageText="下一页">
                                </yk:AspNetPager>
                            </div>
                        </div>
                        <!--Page-->
                        <% if (AspNetPagerComments.RecordCount == 0)
                           { %>
                        <div class="Nodata">
                            暂无相关评论。</div>
                        <%} %>
                        <!--评论-->
                        <div class="Comment">
                            <h4>
                                发表评论并打分：</h4>
                            <dl>
                                评分： 请针对产品质量与服务进行点评
                                <asp:RadioButtonList runat="server" ID="RadioBtnCommentType" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="好评" Value="0" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="中评" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="差评" Value="2"></asp:ListItem>
                                </asp:RadioButtonList>
                            </dl>
                            <dt>
                                <yk:TextBox runat="server" TextMode="MultiLine" Rows="5" ID="TbComContent"></yk:TextBox>
                            </dt>
                            <% if (memberName != null)
                               { %>
                            <dt>
                                <yk:Button runat="server" ID="BtnComments" Text="提交" class="button_submit" OnClick="BtnComments_Click" />
                                <asp:Label runat="server" ID="LbComments" ForeColor="Red"></asp:Label>
                            </dt>
                            <%}
                               else
                               { %>
                            <dt>[注：250以内]<br />
                                只有购买过该商品的用户才能进行评论并打分。<br />
                                您尚未登录，不能发表评论，请点<a href="../member/Login.aspx">[这里]</a>登录 </dt>
                            <%}%>
                        </div>
                        <!--评论End-->
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <!--商品评论End-->
            <!--商品咨询-->
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="Wrap_Question"  id="question">
                        <h3 class="title">
                            <b>商品咨询</b></h3>
                        <div class="Tips">
                            您可对商品包装、颜色、配送、库存等方面进行咨询，<font>梦科商城</font>有专人进行回复！<br />
                            所有回复仅在当时对提问者有效，其他网友仅供参考！
                        </div>
                        <div class="Box">
                            <!--start-->
                            <ul>
                                <asp:Repeater runat="server" ID="RepQuestions" 
                                    onitemdatabound="RepQuestions_ItemDataBound">
                                    <ItemTemplate>
                                        <li class="Q">
                                            <dl>
                                                <%# Eval("MemberID").GetEntity<YK.Model.TB_Member_Members>().MemberName %>
                                                咨询于
                                                <%# Eval("AddDate") %></dl>
                                            <dd>
                                                咨询内容：</dd>
                                            <dt>
                                                <%# Eval("ComContent")%></dt>
                                        </li>
                                        <asp:HiddenField runat="server" ID="HiddenFieldID" Value='<%# Eval("ID") %>' />
                                        <asp:Repeater runat="server" ID="RepReply">
                                            <ItemTemplate>
                                                <li class="A">
                                                    <dd>
                                                        商城回复：</dd>
                                                    <dt>
                                                        <%# Eval("ComContent")%></dt>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                            <!--end-->
                        </div>
                        <!--Page-->
                        <div class="Pages">
                            <div class="page_total">
                                目前在第<span><%=AspNetPagerQuestions.CurrentPageIndex%></span>页，共有<span><%=AspNetPagerQuestions.PageCount%></span>页，共有<span><%=AspNetPagerQuestions.RecordCount%></span>条记录
                            </div>
                            <div class="page_num">
                                <yk:AspNetPager runat="server" ID="AspNetPagerQuestions" PageSize="3" FirstPageText="首页"
                                    LastPageText="末页" ShowPageIndexBox="Always" SubmitButtonClass="button" SubmitButtonText="确定"
                                    CurrentPageButtonClass="select" PageIndexBoxClass="text" OnPageChanging="AspNetPagerQuestions_PageChanging"
                                    PrevPageText="上一页" NextPageText="下一页">
                                </yk:AspNetPager>
                            </div>
                        </div>
                        <!--Page-->
                        <div class="Nodata">
                            暂无相关咨询。</div>
                        <!--评论-->
                        <div class="Question">
                            <dt>
                                <yk:TextBox runat="server" TextMode="MultiLine" Rows="5" ID="TbQuestionContent"></yk:TextBox>
                            </dt>
                            <% if (memberName != null)
                               { %>
                            <dt>
                                <yk:Button runat="server" ID="BtnQuestion" Text="提交" class="button_submit" OnClick="BtnQeustion_Click" />
                                <asp:Label runat="server" ID="LbQuestion" ForeColor="Red"></asp:Label>
                            </dt>
                            <%}
                               else
                               { %>
                            <dt>[注：250以内]<br />
                                您尚未登录，不能发表咨询评论，请点<a href="../member/Login.aspx">[这里]</a>登录 </dt>
                            <%}%>
                        </div>
                        <!--评论End-->
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <!--商品咨询End-->
        </div>
        <!--Right End-->
        <div class="clear">
        </div>
    </div>
    <!--Help-->
    <yk:Help runat="server" />
    <!--Help End-->
    <!--Footer-->
    <yk:Bottom runat="server" />
    <!--Footer End-->

    <script src="../scripts/p.pshow.js" type="text/javascript"></script>

    </form>
</body>
</html>
