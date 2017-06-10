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
using YK.Common;
using YK.Model;

public partial class Controls_Help : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RepHelp.DataSource = InfoService.HelpCategoryService.Search(4);
        RepHelp.DataBind();

        List<Expression> expression = new List<Expression>();
        expression.Add(new Expression("IsHIdden", "=", "0"));
        RepLinks.DataSource=InfoService.LinksService.Search(10);
        RepLinks.DataBind();
    }

    protected void RepHelp_ItemDataBind(object sender, RepeaterItemEventArgs e)
    {
        string cid = ((HiddenField)e.Item.FindControl("CateogryId")).Value;
        Repeater rep = (Repeater)e.Item.FindControl("RepList");

        List<Expression> expression = new List<Expression>();
        expression.Add(new Expression("CategoryId","=",cid));

        rep.DataSource = InfoService.HelpService.Search(4, expression);
        rep.DataBind();
    }
}
