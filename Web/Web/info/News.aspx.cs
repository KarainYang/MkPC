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

public partial class info_News : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadDataBind(1);
        }
    }

    public void LoadDataBind(int pageIndex)
    {
        string code = YK.Common.CommonClass.ReturnRequestStr("code");
        List<Expression> express = new List<Expression>();
        express.Add(new Expression("IsHIdden", "=", "0"));
        if(!string.IsNullOrEmpty(code))
        {
            express.Add(new Expression("CategoryCode", "=", code));
        }

        int recordCount=0;
        RepList.DataSource = InfoService.NewsService.Search(AspNetPager1.PageSize, pageIndex, express, ref recordCount);
        RepList.DataBind();
        AspNetPager1.RecordCount = recordCount;
    }

    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        LoadDataBind(e.NewPageIndex);
    }
}
