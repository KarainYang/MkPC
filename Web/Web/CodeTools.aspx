<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CodeTools.aspx.cs" Inherits="CodeTools" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <style>
        /*表单样式*/
        .fromTable {border:1px solid #CBE2F4;line-height:20px;margin-bottom:10px;font-size:12px;}
        .fromTable td {border-bottom:1px solid #CBE2F4;border-left:1px solid #CBE2F4;padding-left:10px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table  class="fromTable" class="fromTable" border="0" cellpadding="0" cellspacing="0"  width="300px">
                <tr>
                    <td></td>
                    <td>表名</td>
                    <td>描述</td>
                </tr>
                <asp:Repeater runat="server" ID="RepTables">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <yk:CheckBox runat="server" ID="ChkTable" />
                                <asp:HiddenField runat="server" ID="HiddenName" Value='<%# Eval("name")%>' />
                            </td>
                            <td><%# Eval("name")%></td>
                            <td><asp:TextBox ID="TbDesc" runat="server"></asp:TextBox></td>                                        
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <asp:Button ID="BtnGenerationCheckTable" runat="server" Text="生成所选数据表文件" 
                onclick="BtnGenerationCheckTable_Click" />
            <table>
                <tr>
                    <td valign="top">
                        <table  class="fromTable" border="0" cellpadding="0" cellspacing="0" width="400px">
                            <tr>
                                <td>服务器地址：</td>
                                <td>
                                    <asp:TextBox ID="TbIpAdd" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>用户名：</td>
                                <td>
                                    <asp:TextBox ID="TbUser" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>密码：</td>
                                <td>
                                    <asp:TextBox ID="TbPwd" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="BtnLink" runat="server" Text=" 连接 " OnClick="BtnLink_Click" />
                                    <asp:Label ID="LbTooltip" runat="server" Text="" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                       </table>

                        <table  class="fromTable" class="fromTable" border="0" cellpadding="0" cellspacing="0"  width="400px">
                            <tr>
                                <td>数据库：</td>
                                <td>
                                    <asp:DropDownList ID="DDLDataBase" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDLDataBase_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>数据表：</td>
                                <td>
                                    <asp:DropDownList ID="DDLDataTable" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDLDataTable_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>描述：</td>
                                <td>
                                    <asp:TextBox ID="TbModelName" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>生成文件：</td>
                                <td>
                                    <asp:DropDownList ID="DDLGenerationFile" runat="server">
                                        <asp:ListItem Text="全部" Value="全部" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="实体文件" Value="实体文件"></asp:ListItem>
                                        <asp:ListItem Text="接口文件" Value="接口文件"></asp:ListItem>
                                        <asp:ListItem Text="业务文件" Value="业务文件"></asp:ListItem>                            
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="BtnRealse" runat="server" Text=" 生成 " OnClick="BtnRealse_Click" />
                                </td>
                            </tr>              
                        </table>
                    </td>
                    <td valign="top">
                        <table  class="fromTable" class="fromTable" border="0" cellpadding="0" cellspacing="0"  width="300px">
                            <tr>
                                <td>字段</td><td>字段名称</td><td>类型</td>
                            </tr>
                            <asp:Repeater runat="server" ID="RepColumns">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("ColumnsName")%></td><td><%# Eval("ColumnDesc")%></td><td><%# Eval("ColumnsType")%></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </td>
                    <td valign="top">
                        <table  class="fromTable" class="fromTable" border="0" cellpadding="0" cellspacing="0"  width="300px">
                            <tr>
                                <td>表名</td>
                            </tr>
                            <asp:Repeater runat="server" ID="RepDataTable">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("name")%></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </td>
                </tr>
            </table>
            
        </div>
    </form>
</body>
</html>
