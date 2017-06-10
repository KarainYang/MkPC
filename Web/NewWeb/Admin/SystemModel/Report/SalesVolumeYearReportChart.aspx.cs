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

public partial class Admin_SystemModel_Report_SalesVolumeYearReportChart : BasePage
{
    protected string data = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TbStartDate.Text = DateTime.Now.AddYears(-5).ToString("yyyy");
            TbStopDate.Text = DateTime.Now.ToString("yyyy");
            LoadDataBind();            
        }
    }

    //加载所有信息
    public void LoadDataBind()
    {
        DateTime startDate = Convert.ToDateTime(TbStartDate.Text + "-01-01");
        DateTime stopDate = Convert.ToDateTime(TbStopDate.Text + "-01-01");
        int years = stopDate.Year - startDate.Year + 1;
        for (int i = 0; i < years; i++)
        {
            string start = startDate.AddYears(i).ToShortDateString();
            string stop = startDate.AddYears(i + 1).ToShortDateString();

            List<Expression> expressions = new List<Expression>();

            string cmdText = "select sum(Count) as Count from TB_Order_OrderDetails "
          + " left join TB_Order_Orders on TB_Order_OrderDetails.OrderNumber=TB_Order_Orders.OrderNumber "
          + " and OrderDate>='" + start + "'" + " and OrderDate<'" + stop + "'"
          + " where IsDelete=0  and OrderType=0 group by ProductID,ProName order by sum(Count) desc ";

            List<TB_Order_OrderDetails> list = OrderService.OrderDetailsService.SQLSearch(cmdText);
            data += "[\"" + startDate.AddYears(i).ToString("yyyy") + "\"," + list.Count + "],";
        }

        ReportChart1.data = "[" + data.TrimEnd(',') + "]";
        ReportChart1.count = years;
    }

    //搜索
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        LoadDataBind(); //重新加载
    }
}
