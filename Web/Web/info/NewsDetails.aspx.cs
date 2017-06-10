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
using YK.Service;

public partial class info_NewsDetails : System.Web.UI.Page
{
    protected TB_Info_News news;

    protected void Page_Load(object sender, EventArgs e)
    {
        int id = YK.Common.CommonClass.ReturnRequestInt("id", 0);
        news = InfoService.NewsService.Get(id);
    }    
}
