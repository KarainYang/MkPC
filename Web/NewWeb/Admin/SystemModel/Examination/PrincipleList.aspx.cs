﻿using System;
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
using YK.Services.Examination;
using YK.Models.Examination;

public partial class Admin_SystemModel_Exam_PrincipleList : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ButtonDelete.Attributes.Add("onclick", "return confirm('确认删除这条信息吗？')");
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

        List<YK.Models.Examination.ExamPrinciple> list = BasicService.ExamPrincipleService.Search(pageSize, 1, expression, "CreatedOn asc", ref recordCount);
        RepList.DataSource = list; 
        RepList.DataBind();
        AspNetPager1.RecordCount = recordCount;
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
                BasicService.ExamPrincipleService.Delete(ID);
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

    //搜索
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        ViewState["PageIndex"] = 1;
        AspNetPager1.CurrentPageIndex = 1;
        LoadDataBind(); //重新加载

    }
}
