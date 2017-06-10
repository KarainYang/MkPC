<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TaskView.aspx.cs" Inherits="Admin_SystemModel_Project_TaskView" %>

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
                         <th>所属项目：</th>
                        <td>
                            <yk:DropDownList runat="server" ID="DDLProject" GroupName="Validator" 
                            title="所属项目"  LabelID="LbProject"></yk:DropDownList>                                       
                            <span id="LbProject">*</span> 
                        </td>
                   </tr>     
                   <tr>          
                        <th>任务名称：</th>
                        <td>
                            <yk:TextBox ID="TbName" runat="server"  Width="300px" GroupName="Validator" CssClass="inputCss"
                            title="名称" LabelID="LbName"></yk:TextBox>
                            <span id="LbName">*</span> 
                        </td>
                   </tr>                 
                   <tr>
                         <th>任务开始时间：</th>
                        <td>
                            <yk:TextBox ID="TbStartDate" runat="server" Width="150" MaxLength="60" CssClass="inputCss" 
                            onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"   GroupName="Validator" 
                            title="任务开始时间"  LabelID="LbDate"></yk:TextBox>                        
                            <span id="LbDate">*</span>                     
                        </td>
                   </tr> 
                   <tr>
                         <th>任务结束时间：</th>
                        <td>
                            <yk:TextBox ID="TbEndDate" runat="server" Width="150" MaxLength="60" CssClass="inputCss" 
                            onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" GroupName="Validator" 
                            title="任务结束时间"  LabelID="LbEndDate"></yk:TextBox>                                           
                            <span id="LbEndDate">*</span> 
                        </td>
                   </tr> 
                   <tr>
                         <th>任务处理人：</th>
                        <td>
                            <yk:DropDownList runat="server" ID="DDLHandler" GroupName="Validator" 
                            title="任务处理人"  LabelID="LbHandler"></yk:DropDownList>                                       
                            <span id="LbHandler">*</span> 
                        </td>
                   </tr> 
                   <tr>
                         <th>描述：</th>
                        <td>
                            <yk:FCKeditor ID="FckDesc" runat="server" Height="300px">
                            </yk:FCKeditor>    
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
