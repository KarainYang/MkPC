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

public partial class Admin_SystemModel_Employee_AllWorkStatementList : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadUsers();
            ViewState["PageIndex"] = 1;
            ViewState["search"] = "";
            LoadDataBind();
        }
    }

    public void LoadUsers()
    {
        DDLUsers.DataSource = AdminService.UserService.Search();
        DDLUsers.DataTextField = "UserName";
        DDLUsers.DataValueField = "ID";
        DDLUsers.DataBind();

        ListItem li = new ListItem();
        li.Text = "==请选择==";
        li.Value = "";
        DDLUsers.Items.Insert(0, li);
    }

    //加载所有信息
    public void LoadDataBind()
    {
        int pageSize = AspNetPager1.PageSize;
        int recordCount = 0;
        int pageIndex = ViewState["PageIndex"].ToInt();
        List<Expression> express = new List<Expression>();
        express.Add(new Expression("Type", "=", DDLType.SelectedValue));

        if (DDLUsers.SelectedValue != "")
        {
            express.Add(new Expression("AdminUserID", "=", DDLUsers.SelectedValue));
        }

        List<TB_Employee_WorkStatement> list = EmployeeService.WorkStatementService.Search(pageSize, pageIndex,express, ref recordCount);
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

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        LoadDataBind();
    }
}
