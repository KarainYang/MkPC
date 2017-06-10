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
using YK.Common;
using YK.Model;

public partial class Controls_Bottom : System.Web.UI.UserControl
{
    public WebSet webSet = new WebSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        string path = Server.MapPath("~/App_Data/WebSet/WebSet.xml");
        webSet = MyXmlSerializer<WebSet>.Get(path);
    }
}
