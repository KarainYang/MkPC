<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TaskHandle.aspx.cs" Inherits="Admin_SystemModel_Project_TaskHandle" %>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>
<%@ Import Namespace="YK.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>任务处理</title>
    <yk:AdminHeader ID="AdminHeader1" runat="server"></yk:AdminHeader>
    
    <script language="javascript" type="text/javascript">
        function changeDDL(val) {
            document.getElementById("trProgress").style.display = "none";
            document.getElementById("trReason").style.display = "none";
            document.getElementById("<%=TbProgress.ClientID %>").value = "0";

            switch (val) {
                case "1":
                    document.getElementById("trProgress").style.display = "table-row";
                    break;
                case "2":
                    document.getElementById("<%=TbProgress.ClientID %>").value = "100";
                    break;
                case "3":                    
                    document.getElementById("trReason").style.display = "table-row";
                    break;
            }
        } 
        
        //核查
        function checkForm()
        {
            clearText();
            
            var b=true;
            var status = document.getElementById("<%=DDLStatus.ClientID %>").value;
            if (status == 0)
            {
                document.getElementById("LbStatus").innerHTML = "请选择处理状态";
                b=false;
            }

            if (status == 3)
            {
                var reason = document.getElementById("<%=TbReason.ClientID %>").value;
                if(reason=="")
                {
                    document.getElementById("LbReason").innerHTML = "请输入拒绝原因";
                    b=false;
                }
            }

            if (status == 1) {
                var reason = document.getElementById("<%=TbProgress.ClientID %>").value;
                if (reason == "") {
                    document.getElementById("LbProgress").innerHTML = "请输入进度";
                    b = false;
                }
            }
            
            return b;
        }
        //清除文本
        function clearText()
        {
            document.getElementById("LbStatus").innerHTML = "";
            document.getElementById("LbReason").innerHTML = "";
            document.getElementById("LbProgress").innerHTML = "";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">         
         <div class="BodyDiv">         
                 <table class="fromTable">    
                    <tr>
                         <th>处理状态：</th>
                        <td>
                            <yk:DropDownList runat="server" ID="DDLStatus" onchange="changeDDL(this.value)" onblur="checkForm()">
                                <asp:ListItem Text="未处理" Value="0"></asp:ListItem>
                                <asp:ListItem Text="处理中" Value="1"></asp:ListItem>
                                <asp:ListItem Text="已处理" Value="2"></asp:ListItem>
                                <asp:ListItem Text="拒绝" Value="3"></asp:ListItem>
                            </yk:DropDownList>                                       
                            <span id="LbStatus">*</span> 
                        </td>
                   </tr> 
                   <tr id="trProgress" style=" display:none;">
                         <th>进度：</th>
                        <td>
                            <yk:TextBox runat="server" ID="TbProgress"></yk:TextBox> %                                       
                            <span id="LbProgress">*</span> 
                        </td>
                   </tr>    
                   <tr id="trReason" style=" display:none;">
                         <th>拒绝原因：</th>
                        <td>
                            <yk:TextBox runat="server" ID="TbReason"  TextMode="MultiLine" Width="360px" Height="100px" onblur="checkForm()"></yk:TextBox>                                       
                            <span id="LbReason">*</span> 
                        </td>
                   </tr>                   
                 </table>
         </div>
                  
        <div class="SubmitClass">
            <asp:Button ID="BtnSave" runat="server" Text=" 保存 " CssClass="buttonCss"  OnClick="BtnSave_Click" OnClientClick="return checkForm()"/>
                     <input type="button" value=" 取消 " class="buttonCss" id="cancleCss" onclick="closeLayer()"  />
        </div> 
        <div runat="Server" id="MessageDiv">            
        </div> 
    </form>
</body>
</html>
