﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalesVolumeMonthReportChart.aspx.cs" Inherits="Admin_SystemModel_Report_SalesVolumeMonthReportChart" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>无标题页</title>
    <yk:AdminHeader ID="AdminHeader1" runat="server"></yk:AdminHeader>
</head>
<body>
    <form id="form1" runat="server">
            <div  class="navigation">               
               商品销量 > 商品销量月图形报表
            </div>
            <div  class="navigation">   
                <style type="text/css">
                    .current{font-weight:bold; font-size:16px;}
                </style>            
               <a href="SalesVolumeDaysReportChart.aspx">日图形报表</a> | 
               <a href="javascript:void(0)" class="current">月度图形报表</a> | 
               <a href="SalesVolumeYearReportChart.aspx">年度图形报表</a>
            </div>
            <div  class="topOpration">                                         
                开始时间：<asp:TextBox ID="TbStartDate" runat="server" Width="255px" CssClass="inputCss" Text="" onclick="WdatePicker({dateFmt:'yyyy-MM'})"></asp:TextBox> 
                结束时间：<asp:TextBox ID="TbStopDate" runat="server" Width="255px" CssClass="inputCss" Text="" onclick="WdatePicker({dateFmt:'yyyy-MM'})"></asp:TextBox> 
                <asp:Button ID="BtnSearch"  runat="server" CssClass="buttonCss"  Text="搜索" OnClick="BtnSearch_Click" />
            </div>            
            <yk:ReportChart runat="server" id="ReportChart1"  title="月度访问量"></yk:ReportChart>
    </form>
</body>
</html>
