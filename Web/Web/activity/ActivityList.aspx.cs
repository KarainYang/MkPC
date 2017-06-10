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

using YK.Common;
using YK.Service;
using YK.Model;

public partial class Activity_ActivityList : System.Web.UI.Page
{
    public List<TB_Activity_Activity> activityList;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDataBind(1);
        }
    }

    public void LoadDataBind(int pageIndex)
    {
        int recordCount = 0;
        List<Expression> express = new List<Expression>();
        express.Add(new Expression("IsEnable", "=", "1"));
        activityList = ActivityService.ActivitysService.Search(AspNetPager1.PageSize, pageIndex, express, "id desc,addDate desc", ref recordCount);
        AspNetPager1.RecordCount = recordCount;
    }

    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        LoadDataBind(e.NewPageIndex);
    }
}
