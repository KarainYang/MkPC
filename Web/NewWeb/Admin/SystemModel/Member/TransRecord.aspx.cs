using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

using YK.Model;
using YK.Common;
using YK.Service;

public partial class Admin_AdminModel_Member_TransRecord : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {            
            ViewState["PageIndex"] = 1;
            ViewState["search"] = "";

            LoadDataBind();
        }
    }

    //加载所有信息
    public void LoadDataBind()
    {     
        int recordCount = 0;
        string key = ViewState["search"].ToString();
        int pageIndex = Convert.ToInt32(ViewState["PageIndex"]);
        int pageSize = AspNetPager1.PageSize;
        string memberID = CommonClass.ReturnRequestStr("memberID");

        List<Expression> express = new List<Expression>();
        express.Add(new Expression("MemberID", "=", memberID));
        express.Add(new Expression("Remark", "like", TbKey.Text));

        RepList.DataSource = MemberService.TransRecordService.Search
            (pageSize, pageIndex, express, "AddDate desc", ref recordCount);
        RepList.DataBind();
        AspNetPager1.RecordCount = recordCount;
    }

    //搜索
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        ViewState["search"] = TbKey.Text.Trim();
        ViewState["PageIndex"] = 1;
        AspNetPager1.CurrentPageIndex = 1;
        LoadDataBind(); //重新加载
        
    }

    //分页
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        ViewState["PageIndex"] = e.NewPageIndex;
        LoadDataBind();
    }
}
