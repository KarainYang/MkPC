<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="member_Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta name="Author" content="">
    <title>梦科网络商城系统</title>

    <link href="../style/red/css_member.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="../scripts/ScrollPic.js"></script>
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
    <div class="Current">当前位置：<a href="<%=YK.Common.CommonClass.AppPath+"index.aspx" %>">首页</a> > <font>会员中心</font></div>
    <!--Left-->
    <div class="Sidebar">
        <!--Menu-->
        <yk:MemberMenu runat="server" />
        <!--MenuEnd-->               
    </div>
    <!--Left End-->
    <!--Right Start--> 
    <div class="Maincontent">

      <div class="Main">
      <!--Content Start-->
      <!-- 信息提示-->
      <div class="member_tips">
        <div class="tips">
          <h5><font>yylurex</font>,欢迎您！上一次登录时间：2011-06-30 12：11:46</h5>
          <div class="safe">
              账户安全：
              <input type="submit" name="button2" id="button2" value="手机验证" class="btn_1" />
              <input type="submit" name="button2" id="button2" value="邮箱验证" class="btn_1" />
              <input type="submit" name="button2" id="button2" value="注册用户" class="btn_2" />
          </div>
          <table width="100%" border="0" cellspacing="0" cellpadding="0" class="mytable">
          <tr>
                <td>订单提醒：<span>待处理订单(0)　　待评价商品(0)</span></td>
                <td>账户余额：<span>￥0.00</span></td>
                <td>优惠劵：<span><font>0</font>张</span></td>
              </tr>
              <tr>
                <td>我的消息：<span>短信息(0)　　咨询回复(0)</span></td>
                <td>我的积分：<span><font>10</font>分</span></td>
                <td>&nbsp;</td>
              </tr>
            </table>
            </div>
            
            <div class="bulletin">
                <h3>公 告</h3>
                <ul>
                    <li><a href="#">富士3D相机W3新品上市！</a></li> 
                    <li><a href="#">索尼55EX710新品到货！.</a></li> 
                    <li><a href="#">3D电视潮流王者... </a></li>
                    <li><a href="#">松下新品65S20C到货！...</a></li>
                </ul>
            </div>
        </div>
      <!--信息提示End-->
      
      <!--产品01-->
      <div id="AutoTable1">
          <h2 class="tabIndex">
          <span><b>您关注的商品</b></span>
          <span><b>今日团购</b></span>
          </h2>
          <div name="AutoContent" class="memberPro_attention">
          <!--您关注的商品-->
          <div>
          <div id="LeftArr2" class="LeftArrow"></div>
          <div id="ISL_Cont_2">
          <ul>
                <li>
                    <h5><a href="product.shtml">50寸等离子电视</a></h5>
                    <div class="picture"><a href="product.shtml"><img src="../style/red/images/temp/pic20.jpg" /></a></div>
                    <div class="price">市场价：<s>￥7999</s><br />销售价：<font>￥4700.00</font></div>
                </li>
                <li>
                <h5><a href="product.shtml">电视机特/PDP</a></h5>
                    <div class="picture"><a href="product.shtml"><img src="../style/red/images/temp/pic21.jpg" /></a></div>
                    <div class="price">市场价：<s>￥7999</s><br />销售价：<font>￥4700.00</font></div>
                </li>
                <li>
                <h5><a href="product.shtml">50寸等离子电视</a></h5>
                    <div class="picture"><a href="product.shtml"><img src="../style/red/images/temp/pic22.jpg" /></a></div>
                    <div class="price">市场价：<s>￥7999</s><br />销售价：<font>￥4700.00</font></div>
                </li>
                <li>
                <h5><a href="product.shtml">50寸等离子电视</a></h5>
                    <div class="picture"><a href="product.shtml"><img src="../style/red/images/temp/pic23.jpg" /></a></div>
                    <div class="price">市场价：<s>￥7999</s><br />销售价：<font>￥4700.00</font></div>
                </li>
            </ul>
            </div>
            <div id="RightArr2" class="RightArrow"></div>
          </div>
			<script language="javascript" type="text/javascript">
				<!--//--><![CDATA[//><!--
				var scrollPic_01 = new ScrollPic();
				scrollPic_01.scrollContId   = "ISL_Cont_2"; //内容容器ID
				scrollPic_01.arrLeftId      = "LeftArr2";//左箭头ID
				scrollPic_01.arrRightId     = "RightArr2"; //右箭头ID

				scrollPic_01.frameWidth     = 770;//显示框宽度
				scrollPic_01.pageWidth      = 190; //翻页宽度

				scrollPic_01.speed          = 10; //移动速度(单位毫秒，越小越快)
				scrollPic_01.space          = 10; //每次移动像素(单位px，越大越快)
				scrollPic_01.autoPlay       = false; //自动播放
				scrollPic_01.autoPlayTime   = 3; //自动播放间隔时间(秒)

				scrollPic_01.initialize(); //初始化
									
				//--><!]]>
			</script>
          <!--您关注的商品End-->
          <!--今日团购-->
          <div style="display:none;">
          <div id="LeftArr3" class="LeftArrow"></div>
          <div id="ISL_Cont_3">
          <ul>
                <li>
                    <h5><a href="product.shtml">等离子电视</a></h5>
                    <div class="picture"><a href="product.shtml"><img src="../style/red/images/temp/pic22.jpg" /></a></div>
                    <div class="price">市场价：<s>￥7999</s><br />团购价：<font>￥4700.00</font></div>
                </li>
                <li>
                <h5><a href="product.shtml">50寸等离子电视</a></h5>
                    <div class="picture"><a href="product.shtml"><img src="../style/red/images/temp/pic20.jpg" /></a></div>
                    <div class="price">市场价：<s>￥7999</s><br />团购价：<font>￥4700.00</font></div>
                </li>
                <li>
                <h5><a href="product.shtml">50寸等离子电视</a></h5>
                    <div class="picture"><a href="product.shtml"><img src="../style/red/images/temp/pic21.jpg" /></a></div>
                    <div class="price">市场价：<s>￥7999</s><br />团购价：<font>￥4700.00</font></div>
                </li>
                <li>
                <h5><a href="product.shtml">50寸等离子电视</a></h5>
                    <div class="picture"><a href="product.shtml"><img src="../style/red/images/temp/pic23.jpg" /></a></div>
                    <div class="price">市场价：<s>￥7999</s><br />团购价：<font>￥4700.00</font></div>
                </li>
            </ul>
            </div>
            <div id="RightArr3" class="RightArrow"></div>
          </div>
          <script language="javascript" type="text/javascript">
				<!--//--><![CDATA[//><!--
				var scrollPic_03 = new ScrollPic();
				scrollPic_03.scrollContId   = "ISL_Cont_3"; //内容容器ID
				scrollPic_03.arrLeftId      = "LeftArr3";//左箭头ID
				scrollPic_03.arrRightId     = "RightArr3"; //右箭头ID

				scrollPic_03.frameWidth     = 770;//显示框宽度
				scrollPic_03.pageWidth      = 190; //翻页宽度

				scrollPic_03.speed          = 10; //移动速度(单位毫秒，越小越快)
				scrollPic_03.space          = 10; //每次移动像素(单位px，越大越快)
				scrollPic_03.autoPlay       = false; //自动播放
				scrollPic_03.autoPlayTime   = 3; //自动播放间隔时间(秒)

				scrollPic_03.initialize(); //初始化
									
				//--><!]]>
			</script>
          <!--今日团购End-->
          </div>
      </div>
      <!--产品01End-->
      
      <!--产品01-->
      <div id="AutoTable2">
          <h2 class="tabIndex">
          <span><b>近一个月订单</b></span>
          <span><b>今日团购</b></span>
          </h2>
          <div name="AutoContent" class="memberPro_history">
          <!--近一个月订单-->
          <div>
          <ul>
                <li>
                    <h5><a href="product.shtml">50寸等离子电视</a></h5>
                    <div class="picture"><a href="product.shtml"><img src="../style/red/images/temp/pic20.jpg" /></a></div>
                    <div class="txt"><span class="select">Wooo超薄08系列</span>120Hz倍速全高清IPS-屏幕</div>
                </li>
                <li>
                <h5><a href="product.shtml">电视机特/PDP</a></h5>
                    <div class="picture"><a href="product.shtml"><img src="../style/red/images/temp/pic21.jpg" /></a></div>
                    <div class="txt"><span class="select">Wooo超薄08系列</span>120Hz倍速全高清IPS-屏幕</div>
                </li>
                <li>
                <h5><a href="product.shtml">50寸等离子电视</a></h5>
                    <div class="picture"><a href="product.shtml"><img src="../style/red/images/temp/pic22.jpg" /></a></div>
                    <div class="txt"><span class="select">Wooo超薄08系列</span>120Hz倍速全高清IPS-屏幕</div>
                </li>
                <li>
                <h5><a href="product.shtml">50寸等离子电视</a></h5>
                    <div class="picture"><a href="product.shtml"><img src="../style/red/images/temp/pic23.jpg" /></a></div>
                    <div class="txt"><span class="select">Wooo超薄08系列</span>120Hz倍速全高清IPS-屏幕</div>
                </li>
            </ul>
          </div>
          <!--近一个月订单End-->
          <!--待评价商品-->
          <div style="display:none;">
          <ul>
                <li>
                    <h5><a href="product.shtml">等离子电视</a></h5>
                    <div class="picture"><a href="product.shtml"><img src="../style/red/images/temp/pic22.jpg" /></a></div>
                    <div class="txt"><span class="select">Wooo超薄08系列</span>120Hz倍速全高清IPS-屏幕</div>
                </li>
                <li>
                <h5><a href="product.shtml">50寸等离子电视</a></h5>
                    <div class="picture"><a href="product.shtml"><img src="../style/red/images/temp/pic20.jpg" /></a></div>
                    <div class="txt"><span class="select">Wooo超薄08系列</span>120Hz倍速全高清IPS-屏幕</div>
                </li>
                <li>
                <h5><a href="product.shtml">50寸等离子电视</a></h5>
                    <div class="picture"><a href="product.shtml"><img src="../style/red/images/temp/pic21.jpg" /></a></div>
                    <div class="txt"><span class="select">Wooo超薄08系列</span>120Hz倍速全高清IPS-屏幕</div>
                </li>
                <li>
                <h5><a href="product.shtml">50寸等离子电视</a></h5>
                    <div class="picture"><a href="product.shtml"><img src="../style/red/images/temp/pic23.jpg" /></a></div>
                    <div class="txt"><span class="select">Wooo超薄08系列</span>120Hz倍速全高清IPS-屏幕</div>
                </li>
            </ul>
          </div>
          <!--待评价商品End-->
          </div>
      </div>
      <!--产品02End-->
        
      <!--Content End-->    
      </div>
      <div class="BottomEdge"></div>        
  </div>     
  <!--Right End-->
  <div class="clear"></div>
</div>

<!--Footer-->
    <yk:Bottom runat="server" />
<!--Footer End-->
<script type="text/javascript" src="../scripts/tab.js"></script>
<script type="text/javascript">
AutoTables("AutoTable1");
AutoTables("AutoTable2");
</script>
    </form>
</body>
</html>
