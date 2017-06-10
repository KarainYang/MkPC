<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShoppingCart2.aspx.cs" Inherits="order_ShoppingCart2" %>
<%@ Import Namespace="YK.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta name="Author" content="">
    <title>梦科商城</title>

    <link href="../style/red/css_cart.css" rel="stylesheet" type="text/css" />
     <script src="../scripts/jquery.js" type="text/javascript"></script>  
     <script src="../js/ValidatorForm.js" type="text/javascript"></script>
     <%--验证--%>
    <script type="text/javascript">
        //指定控件进行验证
        function checkForm() {            
            $("#spName").html("");
            $("#spProvince").html("");
            $("#spAddress").html("");
            $("#spMobile").html("");
            $("#spMentionDate").html("");
            $("#spCompayName").html("");
            $("#spInvoiceType").html("");
        
            var b = true;
            if (ValidatorForm.NotNullValidator("<%=TbName.ClientID %>") == false) 
            {
                openBuyinfo();
                $("#spName").html("请输入收货人姓名").css("color","red");
                b= false;
            }
            if (ValidatorForm.NotNullValidator("Address_TbText") == false) 
            {
                openBuyinfo();
                $("#spProvince").html("请选择省、市、区").css("color","red");
                b= false;
            }
            if (ValidatorForm.NotNullValidator("<%=TbAddress.ClientID %>") == false) 
            {
                openBuyinfo();
                $("#spAddress").html("请输入收货人地址").css("color","red");
                b= false;
            }
            if (ValidatorForm.Mobile("<%=TbMobile.ClientID %>") == false) 
            {
                openBuyinfo();
                $("#spMobile").html("请输入手机号码").css("color","red");
                b = false;
            }

            if ($("input[name='<%=RadioBtnPaymentList.ClientID %>']:checked ").val() == undefined) {
                $("#spPayment").html("请选择支付方式").css("color", "red");
                b = false;
            }

            //选择配送方式
            if ($("#<%=DDLConsigument.ClientID %>").val() == "") {
                openPay();
                $("#spConsigument").html("请选择配送方式").css("color", "red");
            }
            //3为上面自提，需要输入自提时间
            if ($("#<%=DDLConsigument.ClientID %>").val() == "3")
            {
                if (ValidatorForm.NotNullValidator("<%=TbMentionDate.ClientID %>") == false) 
                {
                    openPay();
                    $("#spMentionDate").html("请输入自提时间").css("color","red");
                    b = false;
                }
            }     
            //是否开具发票
            if ($("input[name='<%=RadioBtnIsInvoice.ClientID %>']:checked ").val() == "1")
            { 
                if ($("input[name='<%=RadioBtnInvoiceType.ClientID %>']:checked").val() != undefined)
                {
                    if ($("input[name='<%=RadioButtonListInvoiceLookUp.ClientID %>']:checked").val() =="公司")
                    {
                        if (ValidatorForm.NotNullValidator("<%=TbCompanyName.ClientID %>") == false) 
                        {
                            openInvoice();
                            $("#spCompayName").html("请输入公司名称").css("color","red");
                            b = false;
                        }
                        
                    }
                }
                else 
                {
                    openInvoice();
                    $("#spInvoiceType").html("请选择发票类型").css("color","red");
                    b = false;
                }
            }
            
            return b;
        }
    </script>
    <%--收货人信息--%>
    <script type="text/javascript">
        //收货人信息展开
        function openBuyinfo() {
            document.getElementById('addressListPanel').style.display = 'none'; 
            document.getElementById('consignee_addr').style.display = 'block';
        }
        
        //收货人信息关闭
        function closeBuyinfo()
        {
            document.getElementById('addressListPanel').style.display='block';
            document.getElementById('consignee_addr').style.display='none';
            
            $("#info1").html($("#<%=TbName.ClientID %>").val());
            $("#info2").html($("#Address_TbText").val());
            $("#info3").html($("#<%=TbAddress.ClientID %>").val());
            $("#info4").html($("#<%=TbMobile.ClientID %>").val());
            $("#info5").html($("#<%=TbPhone.ClientID %>").val());
            $("#info6").html($("#<%=TbEmail.ClientID %>").val());
            $("#info7").html($("#<%=TbPostedCode.ClientID %>").val());
        }
    </script>
    <%--支付方式--%>
    <script type="text/javascript">
        //支付方式展开
        function openPay() {
            document.getElementById('PayListPanel').style.display = 'none';
            document.getElementById('PayboxPanel').style.display = 'block';
        }
        
        //支付方式关闭
        function closePay()
        {
            document.getElementById('PayListPanel').style.display='block';
            document.getElementById('PayboxPanel').style.display='none';
            
            $("#Pay1").html($("#<%=DDLConsigument.ClientID %>").find('option:selected').text());
            $("#Pay2").html($("#<%=DDLRepceiptDateType.ClientID %>").val());
            $("#Pay3").html($("#<%=TbMentionDate.ClientID %>").val());

            //3为上面自提，需要输入自提时间
            //选择配送方式
            if ($("#<%=DDLConsigument.ClientID %>").val() == "") {
                $("#MentionDateTxt2").css("display", "none");
                $("#MentionDateTxt1").css("display", "none");
            }
            else {
                if ($("#<%=DDLConsigument.ClientID %>").val() == "3") {
                    $("#MentionDateTxt2").css("display", "block");
                    $("#MentionDateTxt1").css("display", "none");
                }
                else {
                    $("#MentionDateTxt2").css("display", "none");
                    $("#MentionDateTxt1").css("display", "block");
                }
            }   
        }
      </script>
    <%--发票信息--%>
    <script type="text/javascript">  
        //发票信息展开
        function openInvoice() {
            document.getElementById('InvoiceListPanel').style.display = 'none';
            document.getElementById('InvoiceboxPanel').style.display = 'block';
        }

        //发票信息关闭
        function closeInvoice()
        {
            document.getElementById('InvoiceListPanel').style.display='block';
            document.getElementById('InvoiceboxPanel').style.display='none';
            
            $("#invoiceTxt1").css("display","none");
            $("#invoiceTxt2").css("display","none");
            $("#invoiceTxt3").css("display","none");
            $("#invoiceTxt4").css("display","none");
            
            //是否开具发票
            if($("input[name='<%=RadioBtnIsInvoice.ClientID %>']:checked").val()=="0")
            {                
                $("#Invoice1").html("否");
                $("#TbInvoice").css("display","none");
            }
            else
            {
                $("#invoiceTxt1").css("display","block");
                $("#invoiceTxt2").css("display","block");                
                if ($("input[name='<%=RadioButtonListInvoiceLookUp.ClientID %>']:checked").val() =="公司")
                { 
                    $("#invoiceTxt3").css("display","block");
                }                
                $("#invoiceTxt4").css("display","block");
                
                $("#Invoice1").html("是");
                $("#Invoice2").html($("input[name='<%=RadioBtnInvoiceType.ClientID %>']:checked").val());
                $("#Invoice3").html($("input[name='<%=RadioBtnInvoiceType.ClientID %>']:checked").val()); 
                $("#Invoice3").html($("input[name='<%=RadioButtonListInvoiceLookUp.ClientID %>']:checked").val()); 
                $("#Invoice4").html($("#<%=TbCompanyName.ClientID %>").val());  
                $("#Invoice5").html($("input[name='<%=RadioBtnInvoiceValue.ClientID %>']:checked").val());  
            }            
        }
    </script>

    <script type="text/javascript">     
        //选择配送方式
        function changePayment(obj) {
            
            if(obj.value=="3") {
                $("#TrMentionDate").css("display","table-row");
                $("#TrRepceiptDate").css("display","none");
            }
            else
            {
                $("#TrMentionDate").css("display","none");
                $("#TrRepceiptDate").css("display","table-row");
            }
        }
        //是否开具发票
        function changeIsInvoice(val)
        {
            if($("input[name='<%=RadioBtnIsInvoice.ClientID %>']:checked").val()=="1")
            {
                $("#TbInvoice").css("display","block");                
            }
            else
            {
                $("#TbInvoice").css("display","none");
            }
        }
        
        //选择发票抬头changeRadioButtonListInvoiceLookUp
        function changeInvoiceLookUp()
        {
            if($("input[name='<%=RadioButtonListInvoiceLookUp.ClientID %>']:checked").val()=="公司")
            {
                $("#TrCompanyName").css("display","table-row");                
            }
            else
            {
                $("#TrCompanyName").css("display","none");
            }
        }
    </script>
</head>

<body class="bgbody">
    <form id="form1" runat="server">
    <!--Hearer-->
<div class="other_Header">
    <yk:Top runat="server" />
</div>
<!--Hearer End-->

<div class="Contain">
    <div class="myorder"></div>
    <h3 class="Title">填写核对底单信息</h3>
    <div class="mainbox">
    <!--Content Start-->
    
    <div class="shoppingcart_step"><span class="step02"></span></div>
    

        <!--收货人信息-->
        <div class="Consignee">    
        
        <!--显示信息-->
          <div id="addressListPanel">
            <h3 class="TitleName">收货人信息<span><a href="javascript:void(0)" onclick="openBuyinfo()">[修改]</a></span></h3>
              <ul class="show_txt">
              <li><em>收货人姓名：</em>&nbsp;<span id="info1"></span></li>
              <li><em>省 份：</em>&nbsp;<span id="info2"></span></li>
              <li><em>地 址：</em>&nbsp;<span id="info3"></span></li>
              <li><em>手机号码：</em>&nbsp;<span id="info4"></span></li>
              <li><em>固定电话：</em>&nbsp;<span id="info5"></span></li>
              <li><em>电子邮件：</em>&nbsp;<span id="info6"></span></li>
              <li><em>邮 编：</em>&nbsp;<span id="info7"></span></li>
          </ul>
          </div>
          <!--显示信息End-->
          <!--隐藏信息-->
            <div class="HideDiv" id="consignee_addr">
            <h3 class="TitleName">收货人信息<span><a href="javascript:void(0)" onclick="closeBuyinfo()">[关闭]</a></span></h3>
            <div class="HideBox">
            <!--常用地址-->
            <div class="add_Common" id="add_Commonbox">
                <h4>常用地址</h4>
                <ul>
                    <li><span><a href="#">删除</a></span><input type="radio" name="radio" id="radio" value="radio" />广东广州市天河区</li>
                    <li><span><a href="#">删除</a></span><input type="radio" name="radio" id="radio" value="radio" />云南玉溪市华宁县122d</li>
                </ul>
            </div>
            <!--常用地址End-->
            <!--添加地址-->
            <table border="0" cellspacing="0" cellpadding="0" class="mytable">
              <tr>
                <td class="item"><em>*</em>收货人姓名：</td>
                <td>
                    <yk:TextBox ID="TbName" runat="server" CssClass="input" ToolTip="收货人姓名" GroupName="Validation" LabelID="spName"></yk:TextBox>
                    <span id="spName"></span>
                </td>
              </tr>
              <tr>
                <td class="item"><em>*</em>省　　份：</td>
                <td>
                    <table>
                        <tr>
                            <td>
                                <yk:Address runat="server" ID="Address" />
                                <span id="spProvince"></span>
                            </td>
                            <td><span>注:标“*”的为支持货到付款的地区</span></td>
                        </tr>
                    </table>   
                </td>
              </tr>
              <tr>
                <td class="item"><em>*</em>地　　址：</td>
                <td>
                    <yk:TextBox ID="TbAddress" runat="server" CssClass="input" ToolTip="地址" GroupName="Validation" LabelID="spAddress"></yk:TextBox>
                    <span id="spAddress"></span>
                </td>
              </tr>
              <tr>
                <td class="item"><em>*</em>手机号码：</td>
                <td>
                    <yk:TextBox ID="TbMobile" runat="server" CssClass="input" GroupName="Validation" ToolTip="手机号码" LabelID="spMobile" Validator="手机"></yk:TextBox>
                    <span id="spMobile"></span>
                    或者 固定电话：
                    <yk:TextBox ID="TbPhone" runat="server" CssClass="input"></yk:TextBox>
                    <span>用于接收发货通知短信及送货前确认</span>
                </td>
              </tr>
              <tr>
                <td class="item">电子邮件：</td>
                <td>
                    <yk:TextBox ID="TbEmail" runat="server" CssClass="input"></yk:TextBox>
                    <span>用来接收订单提醒邮件，便于您及时了解订单状态</span>
                </td>
              </tr>
              <tr>
                <td class="item">邮政编码：</td>
                <td>
                    <yk:TextBox ID="TbPostedCode" runat="server" CssClass="input"></yk:TextBox>
                    <span>有助于快速确定送货地址</span>
                </td>
              </tr>
              <tr>
                <td colspan="2"><yk:CheckBox runat="server" ID="IsSaveAddressInfo" />保存收货人信息</td>
              </tr>
              <%--<tr>
                <td>&nbsp;</td>
                <td>
                <dt><a href="javascript:void(0)" onclick="document.getElementById('add_Commonbox').style.display='block';">添加到常用地址</a></dt>
                <dt><input type="submit" name="button2" id="button2" value="保存收货人信息" class="btn_save" onfocus="this.blur()"/></dt>
                </td>
              </tr>--%>
            </table>
            <!--添加地址End-->
            </div>
            </div>  
            <!--隐藏信息End-->                  
            </div>
            <!--收货人信息End-->
            
            <!--支付方式-->
            <div class="Payment">
            <h3 class="TitleName">支付方式 <span id="spPayment"></span> </h3>
                <ul>                    
                    <asp:RadioButtonList runat="server" ID="RadioBtnPaymentList">
                    </asp:RadioButtonList>                  
                </ul>
            </div>
            <!--支付方式End-->
            
            <!--配送方式-->
            <div class="Delivery">
                <!--显示配送信息-->
                <div id="PayListPanel">
                    <h3 class="TitleName">配送方式<span><a href="javascript:void(0)" onclick="openPay()">[修改]</a></span></h3>
                    <ul class="txt_show">
                        <li><em>配送方式：</em>&nbsp;<span id="Pay1"></span> </li>
                        <li id="MentionDateTxt1" style="display:none;"><em>送货日期：</em>&nbsp;<span id="Pay2"></span> </li>
                        <li id="MentionDateTxt2" style="display:none;"><em>自提时间：</em>&nbsp;<span id="Pay3"></span> </li>
                    </ul>
                </div>
                <!--显示配送信息End-->
                <!--隐藏配送信息-->
                <div class="HideDiv" id="PayboxPanel">
                    <h3 class="TitleName">配送方式<span><a href="javascript:void(0)" onclick="closePay()">[关闭]</a></span></h3>
                    <div class="HideBox">
                    <table border="0" cellspacing="0" cellpadding="0" class="mytable">
                      <tr>
                        <td class="item">配送方式：</td>
                        <td>
                            <asp:DropDownList runat="server" ID="DDLConsigument" onchange="changePayment(this)"></asp:DropDownList>
                            <span id="spConsigument"></span>
                        </td>
                      </tr>
                      <tr style=" display:none;" id="TrRepceiptDate">
                        <td class="item"><em>*</em>送货日期：</td>
                        <td>
                            <asp:DropDownList ID="DDLRepceiptDateType" runat="server"></asp:DropDownList>                        
                        </td>
                      </tr>
                      <tr style=" display:none;" id="TrMentionDate">
                        <td class="item"><em>*</em>自提时间：</td>
                        <td>
                            <yk:TextBox runat="server" ID="TbMentionDate" CssClass="input"></yk:TextBox>
                            <span id="spMentionDate"></span>
                            <span>填写你的期望自提时间</span>
                        </td>
                      </tr>
                      <%--<tr>
                        <td class="item">&nbsp;</td>
                        <td>
                        <input type="submit" name="button2" id="button2" value="门店自提" class="btn_save" onfocus="this.blur()"/>
                        <input type="submit" name="button2" id="button2" value="支付及配送方式" class="btn_save" onfocus="this.blur()"/>
                        </td>
                      </tr>--%>
                    </table>                    
                    </div>
                </div>
                <!--隐藏配送信息-->
             </div>
            <!--配送方式End-->
            
            <!--发票信息-->
            <div class="Invoice">
                <!--显示发票信息-->
                <div id="InvoiceListPanel">
                    <h3 class="TitleName">发票信息<span><a href="javascript:void(0)" onclick="openInvoice()">[修改]</a></span></h3>
                    <ul class="txt_show">
                        <li><em>是否开具发票：</em>&nbsp;<span id="Invoice1">否</span></li>
                        <li id="invoiceTxt1" style="display:none;"><em>发票类型：</em>&nbsp;<span id="Invoice2"></span></li>
                        <li id="invoiceTxt2" style="display:none;"><em>发票抬头：</em>&nbsp;<span id="Invoice3"></span></li>
                        <li id="invoiceTxt3" style="display:none;"><em>单位名称：</em>&nbsp;<span id="Invoice4"></span></li>
                        <li id="invoiceTxt4" style="display:none;"><em>抬头内容：</em>&nbsp;<span id="Invoice5"></span></li>
                     </ul>
                </div>
                <!--显示发票信息End-->
                <!--隐藏发票信息-->
                <div class="HideDiv" id="InvoiceboxPanel">
                    <h3 class="TitleName">发票信息<span><a href="javascript:void(0)" onclick="closeInvoice()">[关闭]</a></span></h3>
                    <div class="HideBox">
                    <table border="0" cellspacing="0" cellpadding="0" class="mytable">
                      <tr>
                        <td class="item"><em>*</em>是否开具发票：</td>
                        <td>
                            <asp:RadioButtonList runat="server" ID="RadioBtnIsInvoice" RepeatDirection="Horizontal" onclick="changeIsInvoice()">
                                <asp:ListItem Text="否" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="是" Value="1"></asp:ListItem>
                            </asp:RadioButtonList>
                            
                        </td>
                      </tr>
                    </table>
                    <table border="0" cellspacing="0" cellpadding="0" class="mytable" id="TbInvoice" style="display:none;">
                      <tr>
                        <td class="item"><em>*</em>发票类型：</td>
                        <td>
                            <table>
                                <tr>
                                    <td><asp:RadioButtonList runat="server" ID="RadioBtnInvoiceType" RepeatDirection="Horizontal"></asp:RadioButtonList></td>
                                    <td><span id="spInvoiceType"></span></td>
                                </tr>
                            </table>                            
                        </td>
                      </tr>
                      <tr>
                        <td class="item"><em>*</em>发票抬头：</td>
                        <td>
                            <asp:RadioButtonList runat="server" ID="RadioButtonListInvoiceLookUp" RepeatDirection="Horizontal" onclick="changeInvoiceLookUp()">
                                <asp:ListItem Value="个人" Text="个人" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="公司" Text="公司"></asp:ListItem>
                            </asp:RadioButtonList>                            
                        </td>
                      </tr>
                      <tr style="display:none;" id="TrCompanyName">
                        <td class="item">单位名称：</td>
                        <td>
                            <yk:TextBox ID="TbCompanyName" runat="server" class="input" style="width:550px;"></yk:TextBox>
                            <span id="spCompayName"></span>
                        </td>
                      </tr>
                      <tr>
                        <td class="item">发票内容：</td>
                        <td>
                            <asp:RadioButtonList runat="server" ID="RadioBtnInvoiceValue" RepeatDirection="Horizontal"></asp:RadioButtonList>
                        </td>
                      </tr>
                      <%--<tr>
                        <td class="item">&nbsp;</td>
                        <td><input type="submit" name="button2" id="button2" value="保存发票信息" class="btn_save" onfocus="this.blur()"/></td>
                      </tr>--%>
                    </table>
                    </div>               
                </div>
                <!--隐藏发票信息End-->
            </div>
            <!---发票信息End-->
            
            <!--订单备注-->
            <div class="Remarks">
                <table border="0" cellspacing="0" cellpadding="0" class="mytable">
                  <tr>
                    <td class="item">订单备注</td>
                    <td>
                        <yk:TextBox ID="TbRemark" runat="server" class="input" style="width:550px;"></yk:TextBox>
                    </td>
                  </tr>                  
                </table>

            </div>
            <!--订单备注End-->
            
            <!--商品清单-->
            <div class="PayProduct">
            <h3 class="TitleName">商品清单</h3>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="mytable">
              <tr class="item">
                <td>商品编号</td>
                <td>图片</td>
                <td>商品名称</td>
                <td>商城价</td>
                <td>商品数量</td>
              </tr>
              <asp:Repeater runat="server" ID="RepList">
                    <ItemTemplate>
                       <tr>
                            <td><%# Eval("proNumber")%></td>
                            <td>
                                <dt class="picture">
                                    <a href="../Product/Product.aspx?id=<%# Eval("ID") %>" target="_parent">
                                        <img src="<%# CommonClass.AppPath+ Eval("img") %>" width="20px" onerror="this.src='<%= YK.Common.CommonClass.AppPath %>style/red/images/nopic.jpg';"/>
                                    </a>
                                </dt>
                             </td>
                            <td>
                                    <a href="../Product/Product.aspx?id=<%# Eval("ID") %>"  class="name" target="_blank">
                                        <%# Eval("name") %>
                                    </a>
                            </td>
                            <td>
                                ￥<%# Eval("price") %>
                            </td>
                            <td><%# Eval("count")%></td>
                       </tr> 
                    </ItemTemplate>
              </asp:Repeater>
            </table>
            </div>
            <!--商品清单End-->
            
            <!--结算信息-->
            <div class="Accounts">
                <h3 class="TitleName">结算信息</h3>
                <div class="txt">
                    <dt>商品金额：5099.00元 + 运费：0.00元 - 优惠券：0.00元 - 礼品卡：0.00元 - 返现：0.00元</dt>
                    <p>(+)使用优惠券抵消部分总额</p>
                    <dl>应付总额：<font>￥<yk:Label runat="server" ID="LbTotalAmount"></yk:Label> 元</font></dl>
                </div>
            </div>
            <!--结算信息-->
            
            <!--优惠信息-->
            <div class="Accounts">
                <h3 class="TitleName">优惠信息</h3>
                <div class="txt">
                    <dt><yk:Label runat="server" ID="LbRemark"></yk:Label></dt>
                </div>
            </div>
            <!--优惠信息-->
            
            <div class="btnDiv">
                <asp:Button ID="BtnSubmitOrder" runat="server" Text="" 
                    CssClass="btn_submitOrder" onclick="BtnSubmitOrder_Click" OnClientClick="return checkForm()"  />                
            </div>
    
    <!--Content End-->     
    </div>
    <div class="BottomEdge"></div>
    </div>

<!--Footer-->
    <yk:Bottom runat="server" />
<!--Footer End-->
    </form>
</body>
</html>
