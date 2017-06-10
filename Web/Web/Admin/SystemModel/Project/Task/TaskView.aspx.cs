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
using YK.Interface;
using YK.Service;
using YK.Common;
using YK.Model.CRM;

public partial class Admin_SystemModel_Project_TaskView : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindEmployee();
            BindProject();
            LoadDataBind();
        }
    }

    /// <summary>
    /// 绑定员工
    /// </summary>
    public void BindEmployee()
    {
        List<Expression> expression = new List<Expression>();
        expression.Add(new Expression("IsDelete", "=", 0));

        List<TB_Admin_User> list = AdminService.UserService.Search(expression);
        DDLHandler.DataSource = list.OrderBy(u => u.UserName);
        DDLHandler.DataTextField = "UserName";
        DDLHandler.DataValueField = "ID";
        DDLHandler.DataBind();
    }

    /// <summary>
    /// 绑定项目
    /// </summary>
    public void BindProject()
    {
        List<TB_Project_Projects> list = ProjectService.ProjectsService.Search();
        DDLProject.DataSource = list.OrderBy(u => u.Name);
        DDLProject.DataTextField = "Name";
        DDLProject.DataValueField = "ID";
        DDLProject.DataBind();
    }

    //加载
    public void LoadDataBind()
    {
        int ID = CommonClass.ReturnRequestInt("id", 0);
        if (ID > 0)
        {
            TB_Project_Task model = ProjectService.TaskService.Get(ID);
            if (model.ID.ToInt() > 0)
            {
                ViewState["id"] = model.ID;

                TbName.Text = model.Name;
                TbStartDate.Text = model.StartDate.ToShortDateString();
                TbEndDate.Text = model.EndDate.ToShortDateString();
                FckDesc.Value = model.Remark;
                DDLHandler.SelectedValue = model.Handler.ToStr();
                DDLProject.SelectedValue = model.ProjectID.ToStr();
            }
        }
    }


    //保存
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        TB_Project_Task model = new TB_Project_Task();
        if (ViewState["id"] != null)
        {
            model = ProjectService.TaskService.Get(ViewState["id"]);
        }
        model.Name = TbName.Text;
        model.StartDate = TbStartDate.Text.ToDateTime();
        model.EndDate = TbEndDate.Text.ToDateTime();
        model.Remark = FckDesc.Value;
        model.Handler = DDLHandler.SelectedValue.ToInt();
        model.ProjectID = DDLProject.SelectedValue.ToInt();

        if (ViewState["id"] == null)
        {
            if (ProjectService.TaskService.Insert(model) == 1)
            {
                MessageDiv.InnerHtml = CommonClass.Reload("数据添加成功");
            }
            else
            {
                MessageDiv.InnerHtml = CommonClass.Alert("数据添加失败");
            }
        }
        else
        {
            if (ProjectService.TaskService.Update(model) == 1)
            {

                MessageDiv.InnerHtml = CommonClass.Reload("数据修改成功");
            }
            else
            {
                MessageDiv.InnerHtml = CommonClass.Alert("数据修改失败");
            }
        }
    }
    
}
