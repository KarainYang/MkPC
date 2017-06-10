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

public partial class Admin_SystemModel_Report_BrowerRecordReport : BasePage
{
    protected string data = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TbStartDate.Text = DateTime.Now.AddDays(-6).ToString("yyyy-MM-dd");
            TbStopDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            LoadDataBind();            
        }
    }

    //加载所有信息
    public void LoadDataBind()
    {
        DateTime startDate = Convert.ToDateTime(TbStartDate.Text);
        DateTime stopDate = Convert.ToDateTime(TbStopDate.Text);
        int days = (stopDate - startDate).Days;
        for (int i = 0; i < days; i++)
        {
            string date = startDate.AddDays(i).ToShortDateString();

            List<Expression> expressions = new List<Expression>();
            expressions.Add(new Expression("BrowerDate", ">=", startDate.AddDays(i).ToShortDateString()));
            expressions.Add(new Expression("BrowerDate", "<", startDate.AddDays(i + 1).ToShortDateString()));
            int count = ProductService.BrowerRecordService.Search(expressions).Count;

            data += "[\"" + date + "\"," + count + "],";
        }

        ReportChart1.data = "[" + data.TrimEnd(',') + "]";
        ReportChart1.count = days;
    }

    //搜索
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        LoadDataBind(); //重新加载
    }
}
