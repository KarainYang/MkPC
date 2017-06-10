﻿using System;
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

public partial class Admin_AdminModel_System_AdverList : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BtnDelete.Attributes.Add("onclick", "return confirm('确认删除这条信息吗？')");
        if (!IsPostBack)
        {            
            ViewState["PageIndex"] = 1;
            ViewState["search"] = "";

            LoadCategory();
            LoadDataBind();
        }
    }

    public void LoadCategory()
    {
        DDLCategory.DataSource = SystemService.AdverCategoryService.Search();
        DDLCategory.DataTextField = "Name";
        DDLCategory.DataValueField = "ID";
        DDLCategory.DataBind();

        ListItem li = new ListItem();
        li.Text = "==请选择==";
        li.Value = "";
        DDLCategory.Items.Insert(0,li);
    }

    //加载所有信息
    public void LoadDataBind()
    {     
        int recordCount = 0;
        string key = ViewState["search"].ToString();
        int pageIndex = ViewState["PageIndex"].ToInt();
        int pageSize = AspNetPager1.PageSize;

        List<Expression> express = new List<Expression>();
        express.Add(new Expression("Name", "like", key));
        if (DDLAdverType.SelectedValue != "")
        {
            express.Add(new Expression("AdverType", "=", DDLAdverType.SelectedValue));
        }
        if (DDLCategory.SelectedValue != "")
        {
            express.Add(new Expression("CategoryId", "=", DDLCategory.SelectedValue));
        }
        RepList.DataSource = SystemService.AdverService.Search
            (pageSize, pageIndex,express,"OrderBy asc,AddDate desc",ref recordCount);
        RepList.DataBind();
        AspNetPager1.RecordCount = recordCount;
    }

    //搜索
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        ViewState["PageIndex"] = 1;
        AspNetPager1.CurrentPageIndex = 1;
        LoadDataBind(); //重新加载

    }

    //删除
    protected void ButtonDelete_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem ri in RepList.Items)
        {
            CheckBox cb = ((CheckBox)ri.FindControl("CheckBoxChoose"));
            int ID = Convert.ToInt32(((HiddenField)ri.FindControl("HiddenFieldID")).Value);
            if (cb.Checked == true)
            {
                SystemService.AdverService.Delete(ID);
            }
        }
        //重新加载
        LoadDataBind();
    }

    //分页
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        ViewState["PageIndex"] = e.NewPageIndex;
        LoadDataBind();
    }
}
