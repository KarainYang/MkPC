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

public partial class Controls_Adver : System.Web.UI.UserControl
{
    public TB_System_Adver adver = new TB_System_Adver();
    public List<TB_System_AdverPic> picList = new List<TB_System_AdverPic>();

    /// <summary>
    /// 标识
    /// </summary>
    public string Code { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        List<Expression> expression = new List<Expression>();
        expression.Add(new Expression("Code", "=", Code));

        adver = SystemService.AdverService.Get(expression);

        List<Expression> expression2 = new List<Expression>();
        expression2.Add(new Expression("AdverId", "=", adver.ID));

        picList = SystemService.AdverPicService.Search(expression2);
    }
}
