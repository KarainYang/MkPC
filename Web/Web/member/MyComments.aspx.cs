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
using YK.Common;

public partial class member_MyComments : MemberBasePage
{
    protected List<TB_Product_Comments> list = new List<TB_Product_Comments>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDataBind(1);
        }
    }

    public void LoadDataBind(int pageIndex)
    {
        List<Expression> expression = new List<Expression>();
        expression.Add(new Expression("MemberID", "=", MemberID.ToStr()));

        int recordCount = 0;
        list = ProductService.CommentsService.Search(AspNetPager1.PageSize, pageIndex, expression, " addDate desc", ref recordCount);
        AspNetPager1.RecordCount = recordCount;
    }

    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        LoadDataBind(e.NewPageIndex);
    }
}
