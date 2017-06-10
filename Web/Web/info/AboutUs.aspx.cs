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
using YK.Common;

public partial class info_AboutUs : System.Web.UI.Page
{
    protected TB_Info_Page page;
    protected List<TB_Info_Page> pages;
    protected void Page_Load(object sender, EventArgs e)
    {
        pages = InfoService.PageService.Search();

        List<Expression> expression = new List<Expression>();
        expression.Add(new Expression("Code","=",CommonClass.ReturnRequestStr("code")));
        page = InfoService.PageService.Get(expression);
    }    
}
