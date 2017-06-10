<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ActivityView.aspx.cs" Inherits="Admin_SystemModel_Activity_ActivityView" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <yk:AdminHeader ID="AdminHeader1" runat="server"></yk:AdminHeader>
    
    <script language="javascript" type="text/javascript">
        var DG = frameElement.lhgDG;
        DG.addBtn('ok', '确定', ok);
        function ok() {
            $("#<%= BtnSave.ClientID %>").click();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="fromTable" width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <th style="width: 130px;">
                        活动名称：
                    </th>
                    <td>
                        <asp:TextBox ID="TbName" runat="server" Width="300px" CssClass="inputCss"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFV1" runat="server" ErrorMessage="请输入活动名称！" ControlToValidate="TbName"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <th>
                        活动类型：
                    </th>
                    <td>
                        <asp:RadioButtonList runat="server" ID="RBLType" RepeatDirection="Horizontal" OnSelectedIndexChanged="RBLType_SelectedIndexChanged"
                            AutoPostBack="true">
                            <asp:ListItem Text="满x元免运费" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="满x元送x积分" Value="2"></asp:ListItem>
                            <asp:ListItem Text="满x元打x折" Value="3"></asp:ListItem>
                            <asp:ListItem Text="满x元送优惠券" Value="4"></asp:ListItem>
                            <asp:ListItem Text="满x元减x元" Value="5"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <th>
                        金额：
                    </th>
                    <td>
                        <asp:TextBox ID="TbAmount" runat="server" CssClass="inputCss"></asp:TextBox>
                        <asp:Label ID="LbAmount" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr runat="server" id="tr2" visible="false">
                    <th>
                        积分：
                    </th>
                    <td>
                        <asp:TextBox ID="TbIntegral" runat="server" CssClass="inputCss"></asp:TextBox>
                        <asp:Label ID="LbIntegral" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr runat="server" id="tr3" visible="false">
                    <th>
                        <asp:Literal ID="LitTooltip" runat="server">折扣：</asp:Literal>
                    </th>
                    <td>
                        <asp:TextBox ID="TbDiscount" runat="server" CssClass="inputCss"></asp:TextBox>
                        <asp:Label ID="LbDiscount" runat="server" Text=""></asp:Label>
                    </td>
                </tr>                
                <tr>
                    <th>
                        是否设置活动时间：
                    </th>
                    <td>
                        <asp:CheckBox ID="CheckBoxIsSetDate" runat="server" Text="设置" 
                            oncheckedchanged="CheckBoxIsSetDate_CheckedChanged" AutoPostBack="true" />
                    </td>
                </tr>
                <tr visible="false" runat="server" id="startDate">
                    <th>
                        活动开始时间：
                    </th>
                    <td>
                        <asp:TextBox ID="TbStartDate" runat="server" CssClass="inputCss" onclick="WdatePicker()"></asp:TextBox>
                        <asp:Label ID="LbStartDate" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr visible="false" runat="server" id="stopDate">
                    <th>
                        活动结束时间：
                    </th>
                    <td>
                        <asp:TextBox ID="TbStopDate" runat="server" CssClass="inputCss" onclick="WdatePicker()"></asp:TextBox>
                        <asp:Label ID="LbStopDate" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <table  class="fromTable" width="100%" border="0" cellpadding="0" cellspacing="0" runat="server" id="tbCoupon" visible="false">
                <tr>
                    <td colspan="2" style="font-weight:bold; text-align:center;">优惠券信息设置</td>
                </tr>
                <tr>
                    <th  style="width: 130px;">
                        优惠券抵扣金额：
                    </th>
                    <td>
                        <asp:TextBox ID="TbDeductibleAmount" runat="server" CssClass="inputCss"></asp:TextBox>
                        <asp:Label ID="LbDeductibleAmount" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>
                        是否设置优惠券限时：
                    </th>
                    <td>
                        <asp:CheckBox ID="CheckBoxCouponIsSetDate" runat="server" Text="设置" 
                            oncheckedchanged="CheckBoxCouponIsSetDate_CheckedChanged" AutoPostBack="true" />
                    </td>
                </tr>
                <tr visible="false" runat="server" id="TrCouponStartDate">
                    <th>
                        开始使用时间：
                    </th>
                    <td>
                        <asp:TextBox ID="TbCouponStartDate" runat="server" CssClass="inputCss" onclick="WdatePicker()"></asp:TextBox>
                        <asp:Label ID="LbCouponStartDate" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr visible="false" runat="server" id="TrCouponEndDate">
                    <th>
                        结束时间：
                    </th>
                    <td>
                        <asp:TextBox ID="TbCouponEndDate" runat="server" CssClass="inputCss" onclick="WdatePicker()"></asp:TextBox>
                        <asp:Label ID="LbCouponEndDate" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <table class="fromTable" width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <th style="width: 130px;">
                活动描述：
            </th>
            <td>
                <yk:FCKeditor runat="server" ID="FckDescription" Height="240px" Width="100%">
                </yk:FCKeditor>
            </td>
        </tr>
        <tr>
            <th>
                是否启用：
            </th>
            <td>
                <asp:CheckBox ID="CheckBoxIsEnable" runat="server" Text="启用" />
            </td>
        </tr>
    </table>
    <div class="SubmitClass">
        <asp:Button ID="BtnSave" runat="server" Text=" 保存 " CssClass="buttonCss" OnClick="BtnSave_Click" />
        <input type="button" value=" 清空 " class="buttonCss" onclick="window.location='?';" />
    </div>
    <div runat="Server" id="MessageDiv">
    </div>
    </form>
</body>
</html>
