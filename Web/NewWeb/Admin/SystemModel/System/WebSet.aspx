<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="WebSet.aspx.cs" Inherits="Admin_WebSet_WebSet" %>
<%@ Import Namespace="YK.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <yk:AdminHeader ID="AdminHeader1" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="navigation">
           网站信息设置
        </div>
         <table class="fromTable">
               <tr style="display:none;">
                    <th>网站开关：</th>
                    <td>
                        <asp:RadioButtonList ID="RadioBtnOpenOrClose" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="开启" Value="0"></asp:ListItem>
                            <asp:ListItem Text="关闭" Value="1"></asp:ListItem>
                        </asp:RadioButtonList>                      
                    </td>
               </tr>
               <tr>
                    <th>网站网址：</th>
                    <td colspan="3">
                        <asp:TextBox ID="TbWebSite" runat="server" Width="300px"></asp:TextBox>
                    </td>
               </tr>
                <tr>
                   <th>网站名称：</th>
                   <td><asp:TextBox ID="TbWebName" runat="server" Width="300px"></asp:TextBox></td>
               </tr>
               <tr>
                   <th>公司邮箱：</th>
                   <td>
                        <asp:TextBox ID="TbMail" runat="server"></asp:TextBox>
                   </td>
               </tr>              
               <tr>
                    <th>公司地址：</th>
                    <td><asp:TextBox ID="TbAddress" runat="server" Width="300px"></asp:TextBox></td>
               </tr>
               <tr>
                     <th>公司邮编：</th>
                    <td><asp:TextBox ID="TbZipCode" runat="server"></asp:TextBox></td>                     
               </tr>
               <tr>
                    <th>公司电话：</th>
                    <td><asp:TextBox ID="TbPhone" runat="server"></asp:TextBox></td>
               </tr>
               <tr>
                    <th>传真：</th>
                    <td><asp:TextBox ID="TbFax" runat="server"></asp:TextBox></td>
               </tr>
               <tr> 
                     <th>公司版权：</th>
                    <td><asp:TextBox ID="TbCopyright" runat="server"   TextMode="MultiLine"  Rows="3"  Width="600px"></asp:TextBox></td>
               </tr>
                 <tr style="display:none;">
                    <th>是否允许复制网页：</th>
                    <td>
                        <asp:RadioButtonList ID="RadioBtnDuplicateWebpage" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="允许" Value="0"></asp:ListItem>
                            <asp:ListItem Text="不允许" Value="1"></asp:ListItem>
                        </asp:RadioButtonList>       
                    </td>
              </tr>
               <tr>
                     <th>ICP备案号：</th>
                    <td><asp:TextBox ID="TbIcp" runat="server"  TextMode="MultiLine"  Rows="3"  Width="600px"></asp:TextBox></td>
               </tr>               
                <tr>
                    <th>网站关键字：</th>
                    <td><asp:TextBox ID="TbKeyWord" runat="server" TextMode="MultiLine" Rows="3"  Width="600px"></asp:TextBox></td>
               </tr>
                 <tr>
                    <th>网站描述：</th>
                    <td><asp:TextBox ID="TbDescirption" runat="server" TextMode="MultiLine" Rows="3"  Width="600px"></asp:TextBox></td>
               </tr>
               <tr>
                    <th>TQ代码：</th>
                    <td><asp:TextBox ID="TbTQ" runat="server" TextMode="MultiLine" Rows="3"  Width="600px"></asp:TextBox></td>
               </tr>                
            </table>   
            
            
            <table class="fromTable">
               <tr>
                    <th>水印类型：</th>
                    <td>
                        <asp:RadioButtonList ID="RadioWaterMarkType" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="无" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="文字" Value="0"></asp:ListItem>
                            <asp:ListItem Text="图片" Value="1"></asp:ListItem>
                        </asp:RadioButtonList>                      
                    </td>
               </tr>
               <tr>
                    <th>水印文字：</th>
                    <td colspan="3">
                        <asp:TextBox ID="TbWaterMarkTxt" runat="server" Width="300px"></asp:TextBox>
                    </td>
               </tr>
               <tr>
                    <th>水印图片：</th>
                    <td colspan="3">
                        <yk:FileUpload runat="server" ID="WaterMarkPic" IsWaterMark="false" />
                    </td>
               </tr>
                <tr>
                   <th>水平对齐：</th>
                   <td>
                        <asp:RadioButtonList ID="RadioHorizontal" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="居左" Value="left"></asp:ListItem>
                            <asp:ListItem Text="居中" Value="center"></asp:ListItem>
                            <asp:ListItem Text="居右" Value="right"></asp:ListItem>
                        </asp:RadioButtonList>  
                   </td>
               </tr>
               <tr>
                   <th>垂直对齐：</th>
                   <td>
                        <asp:RadioButtonList ID="RadioVertical" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="居上" Value="left"></asp:ListItem>
                            <asp:ListItem Text="居中" Value="middle"></asp:ListItem>
                            <asp:ListItem Text="居下" Value="right"></asp:ListItem>
                        </asp:RadioButtonList>  
                   </td>
               </tr>
               <tr>
                     <td></td>
                    <td align="left">
                         <asp:Button ID="BtnSave" runat="server" CssClass="buttonCss" Text="  保 存  " OnClick="BtnSave_Click"/>                    
                    </td>
                </tr>
           </table> 
            <div runat="Server" id="MessageDiv"></div> 
    </form>
</body>
</html>