using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using YK.Model;
using YK.Common;
using YK.Service;

public partial class Admin_SystemModel_Report_SalesRankingReportChart : BasePage
{
    protected string data = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportChart1.xTitle = "商品名称";
        ReportChart1.yTitle = "销量";

        if (!IsPostBack)
        {            
            TbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            TbMonthDate.Text = DateTime.Now.ToString("yyyy-MM");
            TbYearDate.Text = DateTime.Now.Year.ToStr();
            LoadDataBind();            
        }
    }

    //加载所有信息
    public void LoadDataBind()
    {
        string start = ""; 
        string stop = "";

        switch (DDLType.SelectedValue)
        {
            case "1":
                DateTime date = Convert.ToDateTime(TbDate.Text);
                start = date.ToShortDateString();
                stop = date.AddDays(1).ToShortDateString();
                ReportChart1.title = "商品日销量排行";
                break;
            case "2":
                date = Convert.ToDateTime(TbMonthDate.Text);
                start = date.ToShortDateString();
                stop = date.AddMonths(1).ToShortDateString();
                ReportChart1.title = "商品月销量排行";
                break;
            case "3":
                date = Convert.ToDateTime(TbYearDate.Text + "-01-01");
                start = date.ToShortDateString();
                stop = date.AddYears(1).ToShortDateString();
                ReportChart1.title = "商品年销量排行";
                break;
        }

        string cmdText = "select top " + TbNumber.Text.ToInt() + " ProductID,ProName,sum(Count) as Count from TB_Order_OrderDetails "
            + " left join TB_Order_Orders on TB_Order_OrderDetails.OrderNumber=TB_Order_Orders.OrderNumber "
            + " and OrderDate>='" + start + "'" + " and OrderDate<'" + stop +"'"
            + " where IsDelete=0  and OrderType=0 group by ProductID,ProName order by sum(Count) desc ";
        List<TB_Order_OrderDetails> list = OrderService.OrderDetailsService.SQLSearch(cmdText);
        foreach (TB_Order_OrderDetails item in list)
        {
            data += "[\"" + item.ProName.SubstringStr(20) + "\"," + item.Count + "],";
        }

        ReportChart1.data = "[" + data.TrimEnd(',') + "]";
        ReportChart1.count = list.Count + 5;//6为设定增加的倍数
    }

    //搜索
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        LoadDataBind(); //重新加载
    }
}
