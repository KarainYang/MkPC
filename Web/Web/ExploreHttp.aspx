<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExploreHttp.aspx.cs" Inherits="ExploreHttp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>资源管理</title>
    <link href="Admin/css/Style.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="Text/javascript" src="admin/js/jquery.js"></script>
    <script language="javascript" type="Text/javascript" src="admin/js/tbcolor.js"></script> 
    <style type="text/css">
      a
      {
        text-decoration:none;
      }
      a:hover
      {
        text-decoration:underline;
        color:red;
      }
      .inputCss{ border:0px; border-bottom:1px solid gray;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>  
           <table class="fromTable" width="100%" border="0" cellpadding="0" cellspacing="0">                
                 <tr>
                    <td   colspan="4" align="center" style="font-weight:bolder; font-size:16px; color:Red;">文件夹列表</td>
                </tr>  
                <tr>
                    <td   colspan="4" align="center" style="color:Red;">
                        新建： 
                        文件夹 <asp:TextBox ID="TbNewDirec" runat="server"></asp:TextBox>
                        文件 <asp:TextBox ID="TbNewFile" runat="server"></asp:TextBox>
                        <asp:Button ID="BtnCreate" runat="server" Text=" 新 建 " 
                            onclick="BtnCreate_Click" />
                    </td>
                </tr>   
                <tr>
                        <td  >
                            名称
                        </td>
                        <td  >
                            修改名称
                        </td>
                        <td  >
                            路径
                        </td>
                        <td>
                            操作
                        </td>
                    </tr>  
            <asp:repeater runat="server" ID="RepDirectory" OnItemCommand="RepDirectory_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td>
                           <asp:LinkButton ID="LinkBtnSelect" runat="server" CommandName="select" CommandArgument='<%# Eval("DireUrl") %>'>
                                <img src="ico/dire.jpg" /> <%# Eval("DireName") %>
                           </asp:LinkButton>
                        </td>
                        <td>
                            <asp:TextBox ID="TbNewName" runat="server" CssClass="inputCss"></asp:TextBox>
                           <asp:LinkButton ID="LinkBtnUpdate" runat="server" CommandName="update" CommandArgument='<%# Eval("DireName") %>'>
                               修改
                           </asp:LinkButton>
                        </td>
                        <td  >                            
                               <%# Eval("DireUrl") %>                            
                        </td>
                        <td  >
                            <asp:LinkButton ID="LinkBtnDelete" runat="server" CommandName="delete" CommandArgument='<%# Eval("DireUrl") %>'>删除该文件夹</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:repeater>
                <tr>
                    <td   colspan="4" align="center" style="font-weight:bolder; font-size:16px; color:Red;">文件列表</td>
                </tr>
             <asp:repeater runat="server" ID="RepFiles" OnItemCommand="RepFiles_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td>
                            <img src="ico/<%# Eval("Suffix") %>.jpg" onerror="this.src='ico/bak.jpg'" /> 
                            <a href="<%# Eval("FileUrl") %>" target="_blank"><%# Eval("FileName") %></a>
                        </td>
                        <td>
                            <asp:TextBox ID="TbNewName" runat="server" CssClass="inputCss"></asp:TextBox>
                           <asp:LinkButton ID="LinkBtnUpdate" runat="server" CommandName="update" CommandArgument='<%# Eval("FileName") %>'>
                                修改
                           </asp:LinkButton>
                        </td>
                        <td>
                            <%# Eval("FileUrl") %>
                        </td>
                        <td  >
                            <asp:LinkButton ID="LinkBtnDelete" runat="server" CommandName="delete" CommandArgument='<%# Eval("FileUrl") %>'>删除该文件</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:repeater>
            </table>
        </div>
    </form>
</body>
</html>
