<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GroupBuyDetails.aspx.cs"
    Inherits="promotion_GroupBuyDetails" %>

<%@ Import Namespace="YK.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta name="Author" content="">
    <title>网上商店</title>
    <link href="../style/red/css_groupbuy.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="../Scripts/pngimg.js"></script>
    <script language="javascript">
        var navId = 3;
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
            当前位置：<a href="<%=YK.Common.CommonClass.AppPath+"index.aspx" %>">首页</a> -> <a href="GroupBuy.aspx">
                团购</a> -> <a href="#"><%=entity.GroupName %></a> ->  <font><%=entity.GroupName %></font></div>
        <!--Right Start-->
        <div class="Maincontent">
            <div class="Wrap_GroupBuyList">
                <h2 class="GroupBuy_tab"></h2>
                <div class="Wrap_GroupBuyList_cont">
                    <div class="Wrap_Group">
                        <!--今日团购 start-->
                        <div class="Wrap_GroupBuyTop">
                        </div>
                        <div class="Wrap_GroupBuyBox">
                            <div class="GroupBuy_Name">
                                <%=entity.GroupName %>
                            </div>
                            <div class="GroupBuyInfo">
                                <div class="GroupBuy_operate">
                                    <div class="GroupBuyBox">
                                        <h1>
                                            <span><%=entity.GroupPrice %></span>
                                            
                                            <asp:Button ID="BtnGroup" runat="server" Text="" CssClass="GroupBuy_endbtn" OnClick="BtnGroup_Click" />
                                        </h1>
                                        <h2>
                                            <span>原价<br /><s>￥<%=entity.Price %></s></span>
                                            <span>折扣<br /><b><%=entity.Price==0?0:(entity.GroupPrice*10/entity.Price).ToDecimal(1) %>折</b></span>
                                            <span>节省<br /><b>￥<%=entity.Price-entity.GroupPrice %></b></span></h2>
                                    </div>
                                    <div class="GroupBuyTime">
                                        <h1>
                                            距离团购结束还有</h1>
                                        <input name="GroupBuyInfoNew1$hidTime" type="hidden" id="GroupBuyInfoNew1_hidTime"
                                            value="<%=entity.StopDate %>" />
                                        <h2 id="spanRemainder">
                                        </h2>
                                    </div>
                                    <div class="GroupBuyNum">
                                        <h1>
                                            <span><%=GetProSum(entity.ID)%></span>人已购买</h1>
                                        <h2>
                                            仅有<span>10</span>个名额，欲购从速！</h2>
                                    </div>
                                </div>
                                <div class="GroupBuy_imgBox">
                                    <img src="<%=YK.Common.CommonClass.AppPath+entity.ImgUrl %>"  onerror="this.src='/UploadFiles/template/nopic.gif'" /></div>
                                <div class="clear">
                                </div>
                            </div>
                            <script type="text/javascript">
                                $.fn.timeLeft = function () {

                                    return this.each(function () {

                                        var val = this.value;
                                        val = val.replace(/-/g, "/");
                                        var endtime = new Date(val);

                                        var nowtime = new Date();
                                        var leftSecond = parseInt((endtime.getTime() - nowtime.getTime()) / 1000);

                                        var _d = parseInt(leftSecond / 3600 / 24);
                                        var _h = parseInt((leftSecond / 3600) % 24);
                                        var _m = parseInt((leftSecond / 60) % 60);
                                        var _s = parseInt(leftSecond % 60);

                                        _h = _h < 10 ? ("0" + _h) : _h.toString();
                                        _m = _m < 10 ? ("0" + _m) : _m.toString();
                                        _s = _s < 10 ? ("0" + _s) : _s.toString();

                                        var fmt = "剩余时间：<span>" + _d + "</span>天<span>" + _h + "</span>小时<span>" + _m + "</span>分钟<span>"+_s+"</span>秒";

                                        $("#spanRemainder").html(fmt);

                                        if (leftSecond <= 0) {   //抢购已结束
                                            var inner = "已结束";
                                            $("#spanRemainder").html(inner);
                                            $("#GroupBuyInfoNew1_btnBuy").hide();
                                            $("#GroupBuyInfoNew1_btnUnbuy").show();
                                            clearInterval(sh);
                                        }

                                    });
                                }

                                fresh();
                                var sh;
                                sh = setInterval(fresh, 1000);

                                function fresh() {
                                    $("#GroupBuyInfoNew1_hidTime").timeLeft();
                                }
                            </script>
                            <div class="GroupBuy_txt">
                                <%=entity.GroupDesc %>                          
                            </div>
                        </div>
                        <div class="Wrap_GroupBuyBottom">
                        </div>
                    </div>
                </div>
            </div>
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
    </form>
</body>
</html>
