<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="Alipay_default" %>
<%@ Import Namespace="YK.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>֧���� - ����֧�� ��ȫ���٣�</title>
    <link href="images/layout.css" type="text/css" rel="stylesheet">

    <script language="JavaScript">
<!-- 
  //У�������  -->
function CheckForm()
{
	if (document.alipayment.aliorder.value.length == 0) {
		alert("��������Ʒ����.");
		document.alipayment.aliorder.focus();
		return false;
	}
	if (document.alipayment.alimoney.value.length == 0) {
		alert("�����븶����.");
		document.alipayment.alimoney.focus();
		return false;
	}
	var reg	= new RegExp(/^\d*\.?\d{0,2}$/);
	if (! reg.test(document.alipayment.alimoney.value))
	{
        alert("����ȷ���븶����");
		document.alipayment.alimoney.focus();
		return false;
	}
	if (Number(document.alipayment.alimoney.value) < 0.01) {
		alert("����������С��0.01.");
		document.alipayment.alimoney.focus();
		return false;
	}
}  
    </script>

</head>
<body text="#000000" bgcolor="#ffffff" leftmargin="0" topmargin="4">
    <center>
        <table cellspacing="0" cellpadding="0" width="760" border="0">
            <tbody>
                <tr>
                    <td class="title">
                        ֧������ʱ���ʸ������ͨ��</td>
                </tr>
            </tbody>
        </table>
        <br />
        
        <form name="alipayment" onsubmit="return CheckForm();" action="alipayto.aspx" method="post"
            target="_blank">
            <table>
                <tr>
                    <td>
                        <table cellspacing="0" cellpadding="0" width="740" border="0">
                            <tr>
                                <td class="form-left">
                                    �տ��
                                </td>
                                <td class="form-star">
                                    *
                                </td>
                                <td class="form-right" align="left"><%=mainname%></td>
                            </tr>
                            <tr>
                                <td colspan="3" align="center">
                                    <hr width="600" size="2" color="#999999">
                                </td>
                            </tr>
                            <tr style="display:none;">
                                <td class="form-left">
                                    ���⣺
                                </td>
                                <td class="form-star">
                                    *
                                </td>
                                <td class="form-right" align="left"><input size="30" name="aliorder" maxlength="200" runat="server" id="aliorder" value="֧��������"><span>�磺7��5�ն����</span></td>
                            </tr>
                            <tr style="display:none;">
                                <td class="form-left">
                                    �����
                                </td>
                                <td class="form-star">
                                    *</td>
                                <td class="form-right" align="left">
                                    <input maxlength="10" size="30" name="alimoney" onfocus="if(Number(this.value)==0){this.value='';}" value="0.1" runat="server" id="alimoney" />
                                    <span>�磺112.21</span></td>
                            </tr>
                            <tr style="display:none;">
                                <td class="form-left">
                                    ��ע��</td>
                                <td class="form-star">
                                </td>
                                <td class="form-right" align="left">
                                    <textarea name="alibody" rows="2" cols="40" wrap="physical"></textarea><br>
                                    ������ϵ��������ƷҪ�������ȡ�100�����ڣ�</td>
                            </tr>
                            <tr>
                                <td class="form-left">
                                    ֧����ʽ��</td>
                                <td class="form-star">
                                </td>
                                <td class="form-right" align="left">
                                    <table>
                                        <tr>
                                            <td>
                                                <input type="radio" name="pay_bank" value="directPay" checked><img src="images/alipay_1.gif"
                                                    border="0" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <input type="radio" name="pay_bank" value="ICBCB2C" /><img src="images/ICBC_OUT.gif"
                                                    border="0" /></td>
                                            <td>
                                                <input type="radio" name="pay_bank" value="CMB" /><img src="images/CMB_OUT.gif" border="0" /></td>
                                            <td>
                                                <input type="radio" name="pay_bank" value="CCB" /><img src="images/CCB_OUT.gif" border="0" /></td>
                                            <td>
                                                <input type="radio" name="pay_bank" value="BOCB2C"><img src="images/BOC_OUT.gif"
                                                    border="0" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <input type="radio" name="pay_bank" value="ABC" /><img src="images/ABC_OUT.gif" border="0" /></td>
                                            <td>
                                                <input type="radio" name="pay_bank" value="COMM" /><img src="images/COMM_OUT.gif"
                                                    border="0" /></td>
                                            <td>
                                                <input type="radio" name="pay_bank" value="SPDB" /><img src="images/SPDB_OUT.gif"
                                                    border="0" /></td>
                                            <td>
                                                <input type="radio" name="pay_bank" value="GDB"><img src="images/GDB_OUT.gif" border="0" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <input type="radio" name="pay_bank" value="CITIC" /><img src="images/CITIC_OUT.gif"
                                                    border="0" /></td>
                                            <td>
                                                <input type="radio" name="pay_bank" value="CEBBANK" /><img src="images/CEB_OUT.gif"
                                                    border="0" /></td>
                                            <td>
                                                <input type="radio" name="pay_bank" value="CIB" /><img src="images/CIB_OUT.gif" border="0" /></td>
                                            <td>
                                                <input type="radio" name="pay_bank" value="SDB"><img src="images/SDB_OUT.gif" border="0" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <input type="radio" name="pay_bank" value="CMBC" /><img src="images/CMBC_OUT.gif"
                                                    border="0" /></td>
                                            <td>
                                                <input type="radio" name="pay_bank" value="HZCBB2C" /><img src="images/HZCB_OUT.gif"
                                                    border="0" /></td>
                                            <td>
                                                <input type="radio" name="pay_bank" value="SHBANK" /><img src="images/SHBANK_OUT.gif"
                                                    border="0" /></td>
                                            <td>
                                                <input type="radio" name="pay_bank" value="NBBANK "><img src="images/NBBANK_OUT.gif"
                                                    border="0" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <input type="radio" name="pay_bank" value="SPABANK" /><img src="images/SPABANK_OUT.gif"
                                                    border="0" /></td>
                                            <td>
                                                <input type="radio" name="pay_bank" value="BJRCB" /><img src="images/BJRCB_OUT.gif"
                                                    border="0" /></td>
                                            <td>
                                                <input type="radio" name="pay_bank" value="ICBCBTB" /><img src="images/ENV_ICBC_OUT.gif"
                                                    border="0" /></td>
                                            <td>
                                                <input type="radio" name="pay_bank" value="CCBBTB" /><img src="images/ENV_CCB_OUT.gif"
                                                    border="0" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <input type="radio" name="pay_bank" value="SPDBB2B" /><img src="images/ENV_SPDB_OUT.gif"
                                                    border="0" /></td>
                                            <td>
                                                <input type="radio" name="pay_bank" value="ABCBTB" /><img src="images/ENV_ABC_OUT.gif"
                                                    border="0" /></td>
                                            <td>
                                                <input type="radio" name="pay_bank" value="fdb101" /><img src="images/FDB_OUT.gif"
                                                    border="0" /></td>
                                            <td><input type="radio" name="pay_bank" value="PSBC-DEBIT" /><img src="images/PSBC_OUT.gif"
                                                    border="0" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="form-left">
                                </td>
                                <td class="form-star">
                                </td>
                                <td class="form-right">
                                    <input type="image" src="images/button_sure.gif" value="ȷ�϶���" name="nextstep"></td>
                            </tr>
                        </table>
                    </td>
                    <td valign="top" width="205" style="font-size: 12px; font-family: '����'">
                        <span id="glowtext">С��ʿ��</span>
                        <fieldset>
                            <p class="STYLE1">
                                ��ͨ��Ϊ<a href="<%=show_url%>" target="_blank"><strong><%=mainname%></strong></a>�ͻ�ר�ã�����֧�����������֧��ǰ�뱾��վ���һ�¡�</p>
                            <p class="style2">
                                �������<a href="<%=show_url%>" target="_blank"><strong><%=mainname%></strong></a>ȷ�Ϻö����ͻ�����ٸ�������ڿ��ٸ���ͨ����ġ����⡱��������������������ͱ�ע��������Ӧ�Ķ�����Ϣ��</p>
                            <p class="style2 style3">
                                &nbsp;</p>
                        </fieldset>
                    </td>
                </tr>
            </table>
        </form>    
        
        
        <table cellspacing="1" width="760" border="0">
            <tr>
                <td>
                    <font class="note-help">�������������򡱰�ť������ʾ���Ѿ����ܡ�֧��������Э�顱��ͬ�������ҹ������Ʒ��
                        <br>
                        �������β�����������Ʒ��¼���ϣ��������ҵ�˵���ͽ��ܵĸ��ʽ�����ұ���е���Ʒ��Ϣ��ȷ��¼�����Σ� </font>
                </td>
            </tr>
        </table>
        
        <table cellspacing="0" cellpadding="0" width="760" align="center" border="0">
            <tr align="middle">
                <td class="txt12 lh15">
                    <a href="http://china.alibaba.com/" target="_blank">����Ͱ����¹�˾</a> | ֧������Ȩ���� 2004-2012</td>
            </tr>
            <tr align="middle">
                <td class="txt12 lh15">
                    <img alt="֧����ͨ��������Ȩ����ȫ��֤�� " src="images/logo_vbvv.gif" border="0"><br>
                    ֧����ͨ��������Ȩ����ȫ ��֤��
                </td>
            </tr>
        </table>
        
        
        
        <form id="Form1" runat="server">
           <div style=" width:800px; margin:auto;color:Gray; text-align:left; line-height:20px;">
                       <span style="margin:10px; color:red; font-weight:bold;">������ϸ��Ϣ</span>
                        <asp:Repeater runat="server" ID="RepOrderInfo">
                            <ItemTemplate>
                                <table class="ordertable" width="100%" border="1" cellpadding="0" cellspacing="0">
                                   <tr>
                                        <td class="order_title" style="width:100px;" align="right">�����ţ�</td>
                                        <td class="order_title">
                                            &nbsp;<%# Eval("OrderNumber") %>
                                        </td>                   
                                        <td class="order_title" style="width:100px;" align="right">�������ڣ�</td>
                                        <td class="order_title">
                                            &nbsp;<%# Eval("OrderDate") %>
                                        </td>
                                   </tr>
                                   <tr>
                                        <td class="order_title" align="right">����������</td>
                                        <td class="order_title">
                                            &nbsp;<%# Eval("ProCount") %>
                                        </td>                 
                                         <td class="order_title" align="right"> �����ܼۣ�</td>
                                        <td class="order_title">
                                            &nbsp;�� <%# Eval("MoneySum") %>
                                        </td>
                                   </tr>
                                   <tr>
                                       <%--  <td class="order_title" align="right">�û�����</td>
                                        <td class="order_title">
                                           &nbsp;<%# Eval("UserName") %>
                                        </td>--%>
                                         <td class="order_title" align="right">���ʽ��</td>
                                        <td class="order_title" colspan="3">
                                            &nbsp;<%# Eval("PaymentTitle") %>
                                        </td>
                                    </tr>
                                   <tr>
                                          <td class="order_title" align="right">�ͻ���ʽ��</td>
                                        <td class="order_title">
                                            &nbsp;<%# Eval("ConsigumentTitle") %>
                                        </td>
                                         <td class="order_title"  align="right">����״̬��</td>
                                         <td class="order_title">
                                            &nbsp;<%# Eval("OrderStateTitle") %>
                                         </td>                    
                                   </tr>
                                    <tr>
                                         <td class="order_title" align="right">��ϵ�ˣ�</td>
                                        <td class="order_title">
                                           &nbsp;<%# Eval("BuyerName") %>
                                        </td>
                                         <td class="order_title" align="right">��˾���ƣ�</td>
                                        <td class="order_title">
                                            &nbsp;<%# Eval("CompanyName") %>
                                        </td>
                                   </tr>
                                   <tr>
                                          <td class="order_title" align="right">��ַ��</td>
                                        <td class="order_title">
                                            &nbsp;<%# Eval("Address") %>
                                        </td>
                                         <td class="order_title"  align="right">�ʱࣺ</td>
                                         <td class="order_title">
                                            &nbsp;<%# Eval("PostalCode") %>
                                         </td>                    
                                   </tr>
                                    <tr>
                                         <td class="order_title" align="right">�绰��</td>
                                         <td class="order_title">
                                            &nbsp;<%# Eval("Phone") %>
                                         </td>
                                         <td class="order_title" align="right">���棺</td>
                                         <td class="order_title" >
                                            &nbsp;<%# Eval("Fax") %>
                                         </td>
                                   </tr>
                                   <tr>
                                         <td class="order_title" align="right">�ֻ��ţ�</td>
                                         <td class="order_title">
                                            &nbsp;<%# Eval("Mobile") %>
                                         </td>                  
                                        <td class="order_title" align="right">���䣺</td>
                                        <td class="order_title">
                                            &nbsp;<%# Eval("Email") %>
                                        </td>
                                     </tr>
                                     <tr>                     
                                        <td class="order_title" align="right">�ͻ����ԣ�</td>
                                        <td class="order_title" colspan="3">
                                            &nbsp;<%# Eval("BuyerNote") %>
                                        </td>
                                     </tr>
                                </table>    
                            </ItemTemplate>
                        </asp:Repeater>
                        
                        <span style="margin:10px; color:red;font-weight:bold;">������ϸ�б�</span>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="mytable">
                          <tr class="item">
                            <td>��Ʒ���</td>
                            <td>ͼƬ</td>
                            <td>��Ʒ����</td>
                            <td>�̳Ǽ�</td>
                            <td>��Ʒ����</td>
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
                                            ��<%# Eval("price") %>
                                        </td>
                                        <td><%# Eval("count")%></td>
                                   </tr> 
                                </ItemTemplate>
                          </asp:Repeater>
                        </table>
                     <br />
               </div>
        </form> 
</body>
</html>
