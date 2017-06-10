<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalesRankingReportChart.aspx.cs" Inherits="Admin_SystemModel_Report_SalesRankingReportChart" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>无标题页</title>
    <yk:AdminHeader ID="AdminHeader1" runat="server"></yk:AdminHeader>
</head>
<body>
    <form id="form1" runat="server">
            <div  class="navigation">               
               商品浏览记录 > 商品销售排行图形报表
            </div>
            <div  class="topOpration"> 
                <script language="javascript" type="text/javascript">
                    function changeType(i) {
                        $("#<%=TbDate.ClientID %>").css("display", "none");
                        $("#<%=TbMonthDate.ClientID %>").css("display", "none");
                        $("#<%=TbYearDate.ClientID %>").css("display", "none");

                        switch (i) {
                            case "1":
                                $("#<%=TbDate.ClientID %>").css("display", "block");
                                break;
                            case "2":
                                $("#<%=TbMonthDate.ClientID %>").css("display", "block");
                                break;
                            case "3":
                                $("#<%=TbYearDate.ClientID %>").css("display", "block");
                                break;
                        }
                    }
                </script> 
                <table>
                    <tr>
                        <td>
                            <yk:DropDownList runat="server" ID="DDLType" onchange="changeType(this.value)">
                                <asp:ListItem Value="1" Text="日图形报表"></asp:ListItem>
                                <asp:ListItem Value="2" Text="月图形报表"></asp:ListItem>
                                <asp:ListItem Value="3" Text="年图形报表"></asp:ListItem>
                            </yk:DropDownList>    
                        </td>
                        <td>日期：</td>
                        <td>                             
                            <asp:TextBox ID="TbDate" runat="server" Width="255px" CssClass="inputCss" Text="" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox> 
                            <asp:TextBox ID="TbMonthDate" runat="server" Width="255px" CssClass="inputCss" Text="" onclick="WdatePicker({dateFmt:'yyyy-MM'})" style=" display:none;"></asp:TextBox> 
                            <asp:TextBox ID="TbYearDate" runat="server" Width="255px" CssClass="inputCss" Text="" onclick="WdatePicker({dateFmt:'yyyy'})" style=" display:none;"></asp:TextBox> 
                        </td>
                        <td>提取前<asp:TextBox ID="TbNumber" runat="server" Width="60px" CssClass="inputCss" Text=""></asp:TextBox> 名 </td>
                        <td>
                            <asp:Button ID="BtnSearch"  runat="server" CssClass="buttonCss"  Text="搜索" OnClick="BtnSearch_Click" />
                        </td>
                    </tr>
                </table>  
                <script language="javascript" type="text/javascript">
                        $("#<%=TbDate.ClientID %>").css("display", "none");
                        $("#<%=TbMonthDate.ClientID %>").css("display", "none");
                        $("#<%=TbYearDate.ClientID %>").css("display", "none");

                        switch ($("#<%=DDLType.ClientID %>").val()) {
                            case "1":
                                $("#<%=TbDate.ClientID %>").css("display", "block");
                                break;
                            case "2":
                                $("#<%=TbMonthDate.ClientID %>").css("display", "block");
                                break;
                            case "3":
                                $("#<%=TbYearDate.ClientID %>").css("display", "block");
                                break;
                        }
                </script> 
            </div>       
            <div align="center">    
                <yk:ReportChart runat="server" id="ReportChart1"  title="商品日销量排行"></yk:ReportChart>
            </div> 
    </form>
</body>
</html>

