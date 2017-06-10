<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WorkStatementView.aspx.cs" Inherits="Admin_SystemModel_Employee_WorkStatementView" %>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>
<%@ Import Namespace="YK.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
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
         <div class="BodyDiv">         
                 <table class="fromTable">         
                   <tr>          
                        <th>类型：</th>
                        <td>
                            <yk:DropDownList runat="server" ID="DDLType">
                                <asp:ListItem Text="日报" Value="0"></asp:ListItem>
                                <asp:ListItem Text="周报" Value="1"></asp:ListItem>
                                <asp:ListItem Text="月报" Value="2"></asp:ListItem>
                            </yk:DropDownList>
                        </td>
                   </tr> 
                   <tr>          
                        <th>标题：</th>
                        <td>
                            <yk:TextBox ID="TbTitle" runat="server" CssClass="inputCss" 
                                MaxLength="50"  GroupName="Validator" title="标题"  LabelID="LbTitle"></yk:TextBox>
                            <span id="LbTitle">*</span> 
                        </td>
                   </tr> 
                   <tr>
                         <th>汇报日期：</th>
                        <td>
                            <yk:TextBox ID="TbStatementDate" runat="server" Width="150" MaxLength="60" CssClass="inputCss" 
                            onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})"   GroupName="Validator" 
                            title="汇报日期"  LabelID="LbStatementDate"></yk:TextBox>                        
                            <span id="LbStatementDate">*</span>                     
                        </td>
                   </tr> 
                   <tr>          
                        <th>工作总结：</th>
                        <td>
                            <yk:TextBox ID="TbWorkSummary" runat="server" TextMode="MultiLine"  CssClass="inputCss"
                                Width="500px" Height="100px" MaxLength="1000"  GroupName="Validator" 
                                title="工作总结"  LabelID="LbWorkSummary"></yk:TextBox>
                            <span id="LbWorkSummary">*</span> 
                        </td>
                   </tr> 
                   <tr>          
                        <th>工作计划：</th>
                        <td>
                            <yk:TextBox ID="TbWorkPlan" runat="server" TextMode="MultiLine"  CssClass="inputCss"
                                Width="500px" Height="100px" MaxLength="1000"></yk:TextBox>
                        </td>
                   </tr> 
                 </table>
         </div>
                  
        <div class="SubmitClass">
            <asp:Button ID="BtnSave" runat="server" Text=" 保存 " CssClass="buttonCss"  OnClick="BtnSave_Click" OnClientClick="return VerificationForm('Validator')"/>
                     <input type="button" value=" 取消 " class="buttonCss" onclick="closeLayer()"  />
        </div> 
        <div runat="Server" id="MessageDiv">            
        </div> 
    </form>
</body>
</html>
