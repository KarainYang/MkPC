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

public partial class Admin_SystemModel_Project_TaskList : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ButtonDelete.Attributes.Add("onclick", "return confirm('确认删除这条信息吗？')");
        if (!IsPostBack)
        {
            LoadProjects();

            ViewState["PageIndex"] = 1;
            ViewState["search"] = "";
            LoadDataBind();
        }
    }

    public void LoadProjects()
    {
        DDLProjects.DataSource = ProjectService.ProjectsService.Search().OrderByDescending(p => p.AddDate);
        DDLProjects.DataTextField = "Name";
        DDLProjects.DataValueField = "ID";
        DDLProjects.DataBind();

        ListItem li = new ListItem();
        li.Text = "==请选择==";
        li.Value = "";
        DDLProjects.Items.Insert(0, li);
    }

    //加载所有信息
    public void LoadDataBind()
    {
        int pageSize = AspNetPager1.PageSize;
        int recordCount = 0;
        int pageIndex = ViewState["PageIndex"].ToInt();

        List<Expression> expression = new List<Expression>();
        expression.Add(new Expression("Name","like",TbKey.Text.Trim()));
        expression.Add(new Expression("AdminUserID", "=", AdminUserID));

        if (DDLProjects.SelectedValue != "")
        {
            expression.Add(new Expression("ProjectID", "=", DDLProjects.SelectedValue));
        }
        
        List<TB_Project_Task> list = ProjectService.TaskService.Search(pageSize, pageIndex, expression, " Id desc,AddDate desc", ref recordCount);
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
                ProjectService.TaskService.Delete(ID);
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

    protected void BtnExcel_Click(object sender, EventArgs e)
    {
        List<Expression> expression = new List<Expression>();
        expression.Add(new Expression("Name", "like", TbKey.Text.Trim()));
        expression.Add(new Expression("AdminUserID", "=", AdminUserID));

        List<TB_Project_Task> list = ProjectService.TaskService.Search(TbCount.Text.ToInt(), expression);
        YK.Common.ExcelHelper.OutputExcel<TB_Project_Task>(list, new string[] { "任务名称", "开始时间", "结束时间", "添加时间" }, new string[] { "Name", "StartDate", "EndDate","AddDate" }, this.Page);
    }
}


