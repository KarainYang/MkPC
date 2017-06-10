using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YK.Model;
using YK.Service;

public partial class Adver : System.Web.UI.Page
{
    public TB_System_Adver adver = new TB_System_Adver();
    public List<TB_System_AdverPic> picList = new List<TB_System_AdverPic>();

    protected void Page_Load(object sender, EventArgs e)
    {
        List<Expression> expression = new List<Expression>();
        expression.Add(new Expression("Code", "=", "00001"));

        adver = SystemService.AdverService.Get(expression);

        List<Expression> expression2 = new List<Expression>();
        expression2.Add(new Expression("AdverId", "=", adver.ID.ToString()));

        picList = SystemService.AdverPicService.Search(expression2);
    }
}