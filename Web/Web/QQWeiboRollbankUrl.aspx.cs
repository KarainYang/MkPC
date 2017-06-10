using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QWeiboSDK;
using System.Net;
using System.IO;
using System.Text;

public partial class QQWeiboRollbankUrl : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Verify"] = Request["oauth_verifier"];
        Session["oauth_token"] = Request["oauth_token"];
        Session["openid"] = Request["openid"];
        Session["openkey"] = Request["openkey"];

        Response.Write("<script>alert('授权成功');window.close();</script>");
    }
}