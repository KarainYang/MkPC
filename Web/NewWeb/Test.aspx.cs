using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime startTime = Convert.ToDateTime("2013-01-01 12:12:12");
        Response.Write(Convert.ToDateTime(startTime.ToShortTimeString()).ToString());

        YK.Model.TB_Info_News news = new YK.Model.TB_Info_News();
        news.Title = "isBackId";
        Response.Write("ID:" + YK.Service.InfoService.NewsService.Insert(news, true));
    }
}