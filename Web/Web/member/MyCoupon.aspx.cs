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

public partial class member_MyCoupon : MemberBasePage
{
    protected List<TB_Activity_CouponNos> list = new List<TB_Activity_CouponNos>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadDataBind(1);
        }
    }

    public void LoadDataBind(int pageIndex)
    { 
        List<Expression> expression=new List<Expression>();
        expression.Add(new Expression("MemberID","=", MemberID.ToStr()));
        int recordCount=0;
        list = ActivityService.CouponNosService.Search(AspNetPager1.PageSize, pageIndex, expression, "SendDate desc", ref recordCount);
    }

    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        LoadDataBind(e.NewPageIndex);
    }
}
