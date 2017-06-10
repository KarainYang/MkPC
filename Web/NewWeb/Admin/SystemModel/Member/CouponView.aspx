<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CouponView.aspx.cs" Inherits="Admin_AdminModel_Member_CouponView" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <yk:AdminHeader ID="AdminHeader1" runat="server"></yk:AdminHeader>
</head>
<body>
    <form id="form1" runat="server">
        <div class="BodyDiv"> 
             <table class="fromTable">
                    <tr>          
                        <th>优惠券名称：</th>
                        <td>
                            <asp:TextBox ID="TbTitle" runat="server"  CssClass="inputCss" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFV1" runat="server" ErrorMessage="请输入优惠券名称！" ControlToValidate="TbTitle"></asp:RequiredFieldValidator>
                        </td>
                   </tr> 
                   <tr>
                         <th>抵扣金额：</th>
                        <td>
                            <asp:TextBox ID="TbAmount" runat="server"  MaxLength="60" CssClass="inputCss"></asp:TextBox> 
                            <asp:Label ID="LbAmount" runat="server" Text=""></asp:Label>                       
                        </td>
                   </tr> 
                   <tr>
                        <th>
                            是否设置时间：
                        </th>
                        <td>
                            <asp:CheckBox ID="CheckBoxIsSetDate" runat="server" Text="设置" 
                                oncheckedchanged="CheckBoxIsSetDate_CheckedChanged" AutoPostBack="true" />
                        </td>
                    </tr>
                    <tr visible="false" runat="server" id="startDate">
                        <th>
                            开始时间：
                        </th>
                        <td>
                            <asp:TextBox ID="TbStartDate" runat="server" CssClass="inputCss" onclick="WdatePicker()"></asp:TextBox>
                            <asp:Label ID="LbStartDate" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr visible="false" runat="server" id="stopDate">
                        <th>
                            结束时间：
                        </th>
                        <td>
                            <asp:TextBox ID="TbStopDate" runat="server" CssClass="inputCss" onclick="WdatePicker()"></asp:TextBox>
                            <asp:Label ID="LbStopDate" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table> 
            </div>   
            <div class="SubmitClass">
           
                <asp:Button ID="BtnSave" runat="server" Text=" 保存 " CssClass="buttonCss"  OnClick="BtnSave_Click"/>
                         <input type="button" value=" 取消 " class="buttonCss" id="cancleCss" onclick="closeLayer()"  />
            </div>
            <div runat="Server" id="MessageDiv">            
            </div> 
    </form>
</body>
</html>