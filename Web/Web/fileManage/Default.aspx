<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="fileManage_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>资源管理</title>
    <link href="../Admin/css/Style.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="Text/javascript" src="../admin/js/jquery.js"></script>
    <script language="javascript" type="Text/javascript" src="../admin/js/tbcolor.js"></script> 
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>  
           <table class="fromTable" width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <tdcolspan="3" align="center">
                        资源管理器：
                      <%--  <asp:DropDownList ID="DDLDriveInfo" runat="server"></asp:DropDownList>
                        <asp:Button ID="BtnSelect" runat="server" Text=" 查 询 " OnClick="BtnSelect_Click" />--%>
                        <input type="button" value=" 返 回 " onclick="history.go(-1)" />

                    </td>
                </tr>   
                 <tr>
                    <td colspan="3" align="center" style="font-weight:bolder; font-size:16px; color:Red;">文件夹列表</td>
                </tr>      
            <asp:repeater runat="server" ID="RepDirectory" OnItemCommand="RepDirectory_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td>
                            文件夹：<%# Eval("FileUrl") %>
                        </td>
                        <td>
                            <asp:LinkButton ID="LinkBtnSelect" runat="server" CommandName="select" CommandArgument='<%# Eval("FileUrl") %>'>查询子文件夹</asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton ID="LinkBtnDelete" runat="server" CommandName="delete" CommandArgument='<%# Eval("FileUrl") %>'>删除该文件夹</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:repeater>
                <tr>
                    <td colspan="3" align="center" style="font-weight:bolder; font-size:16px; color:Red;">文件列表</td>
                </tr>
             <asp:repeater runat="server" ID="RepFiles" OnItemCommand="RepFiles_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td colspan="2">
                            文件：<%# Eval("FileUrl") %><%--<img src="<%# Eval("FileUrl") %>" width="50px" />--%>
                        </td>
                        <td>
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
