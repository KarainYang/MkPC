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
using YK.Common;
using YK.Service;
using YK.Model.CRM;

public partial class Admin_SystemModel_Project_MyProjectList : BasePage
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
        int pageSize = AspNetPager1.PageSize;
        int recordCount = 0;
        int pageIndex = ViewState["PageIndex"].ToInt();

        List<Expression> expression = new List<Expression>();
        expression.Add(new Expression("Name","like",TbKey.Text.Trim()));
        
        List<TB_Project_Projects> list = ProjectService.ProjectsService.Search(pageSize, pageIndex, expression, " Id desc,AddDate desc", ref recordCount);
        RepList.DataSource = list;
        RepList.DataBind();
        AspNetPager1.RecordCount = recordCount;
    }

    //分页
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        ViewState["PageIndex"] = e.NewPageIndex;
        LoadDataBind();
    }

    //搜索
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        ViewState["PageIndex"] = 1;
        AspNetPager1.CurrentPageIndex = 1;
        LoadDataBind(); //重新加载

    }

    protected void BtnExcel_Click(object sender, EventArgs e)
    {
        List<Expression> expression = new List<Expression>();
        expression.Add(new Expression("Name", "like", TbKey.Text.Trim()));
        expression.Add(new Expression("AdminUserID", "=", AdminUserID));

        List<TB_Project_Projects> list = ProjectService.ProjectsService.Search(TbCount.Text.ToInt(), expression);
        YK.Common.ExcelHelper.OutputExcel<TB_Project_Projects>(list, new string[] { "项目名称", "项目编号", "开始时间", "结束", "添加时间" }, new string[] { "Name", "ProjectNo", "StartDate", "EndDate","AddDate" }, this.Page);
    }

    protected void RepList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int id = e.CommandArgument.ToInt();
        if (e.CommandName == "delete")
        {
            ProjectService.ProjectsService.Delete(id);
        }
    }
}
