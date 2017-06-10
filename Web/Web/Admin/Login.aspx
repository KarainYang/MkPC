<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Admin_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>管理员登陆</title>
    <link href="css/Login.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div align="Center" id="Wrap">
                
                 <div  id="LoginDiv">                
                    <table id="LoginTable" style="height:150px;">
                            <tr>
                                <td class="left">用户名：</td>
                                <td>
                                    <input type="text" id="TbUserName" runat="server" style="width:160px; font-size:13px;" />      
                                    <asp:RequiredFieldValidator ID="RFVUserName" runat="server" ErrorMessage=" *" ControlToValidate="TbUserName"></asp:RequiredFieldValidator>    
                                </td>                        
                            </tr>                            
                            <tr>
                                <td class="left">密码：</td>
                                <td>
                                    <input type="password" id="TbUserPwd" runat="server" style="width:160px; font-size:13px;"/>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage=" *" ControlToValidate="TbUserPwd"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="left">验证码：</td>
                                <td>
                                    <input type="text" id="TBYanZheng" runat="server" style="width:90px; font-size:13px;" />
                                    <img src="VerifyCode.aspx" width="60px" height="20px" onclick="this.src+='?'" title="看不清楚，换一张" style="cursor:pointer;"/>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:ImageButton ID="BtnLogin" runat="server" OnClick="BtnLogin_Click" ImageUrl="images/Login.jpg" />                                    
                                    <input type="image" src="images/Cancel.jpg" style="border:0px;" onclick="window.location=window.location.href" /> <br />
                                    <asp:Label ID="LbTooltip" runat="server" Text="" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                     </table>        
                      
                </div>  
                      
        </div>
        
        <script language="javascript" type="Text/javascript">
//             var Num="";
//             for(var i=0;i<5;i++)
//             {
//                Num+=Math.round(Math.random()*9);
//             }
//             document.getElementById("sp").innerHTML=Num;             
             
             var win = document.getElementById("Wrap");
            var availWidth = window.screen.availWidth;
            var availHeight = window.screen.availHeight;
            var scrollTop = document.documentElement.scrollTop;
            var scrollLeft = document.documentElement.scrollLeft;
            var height = win.offsetHeight;
            var width = win.offsetWidth;
            var reLeft = scrollLeft + (availWidth - width) / 2;
            var reTop = scrollTop + (availHeight - height) / 2;
            with (win.style) {
                left = reLeft + "px";
                top = reTop + "px";
            }
            
            document.getElementById("Wrap").style.paddingTop=(reTop-100)+"px";
        </script>        
        
    </form>
</body>
</html>
