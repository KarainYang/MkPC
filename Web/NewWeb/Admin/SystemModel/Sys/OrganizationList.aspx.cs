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
using YK.Model.Systems;

public partial class Admin_AdminModel_Organization_OrganizationList : BasePage
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
        int recordCount = 0;
        string key = ViewState["search"].ToString();
        int pageIndex = Convert.ToInt32(ViewState["PageIndex"]);
        int pageSize = AspNetPager1.PageSize;
        List<Expression> express = new List<Expression>();
        express.Add(new Expression("Name", "like", TbKey.Text));
        RepList.DataSource = SysService.SysOrganizations.Search
            (pageSize, pageIndex, express, "CreatedOn desc", ref recordCount);
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
                SysService.SysOrganizations.Delete(ID);
            }
        }
        //重新加载
        LoadDataBind();
    }

    //状态设置
    protected void BtnStateSet_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem ri in RepList.Items)
        {
            CheckBox cb = ((CheckBox)ri.FindControl("CheckBoxChoose"));
            int ID = Convert.ToInt32(((HiddenField)ri.FindControl("HiddenFieldID")).Value);
            if (cb.Checked == true)
            {
                List<Expression> express = new List<Expression>();
                express.Add(new Expression("ID", "=", ID.ToStr()));

                TB_Sys_Organizations model = SysService.SysOrganizations.Get(express);
                model.State = DDLState.SelectedValue.ToInt();

                SysService.SysOrganizations.Update(model);
            }
        }
        //重新加载
        LoadDataBind();
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
