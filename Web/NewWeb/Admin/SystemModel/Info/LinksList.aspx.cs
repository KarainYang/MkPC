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

public partial class Admin_SystemModel_Info_LinksList : BasePage
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
        express.Add(new Expression("Title","like",TbKey.Text));

        RepList.DataSource = InfoService.LinksService.Search
            (pageSize, pageIndex,express,"AddDate desc",ref recordCount);
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
                InfoService.LinksService.Delete(ID);
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
                TB_Info_Links model = InfoService.LinksService.Get(ID);
                model.IsHIdden = CkIsHidden.Checked;
                InfoService.LinksService.Update(model);
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
