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
using YK.Service;
using YK.Model;

public partial class Controls_ProBulletin : System.Web.UI.UserControl
{
    //商店公告
    public List<TB_Info_News> newsList;
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Expression> express=new List<Expression>();
        express.Add(new Expression("CategoryCode", "=", "0001"));
        newsList = InfoService.NewsService.Search(5, express);
    }
}
