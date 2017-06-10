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

public partial class Admin_SystemModel_Employee_WorkStatementView : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDataBind();
        }
    }

    //加载
    public void LoadDataBind()
    {
        int ID = CommonClass.ReturnRequestInt("id", 0);
        if (ID > 0)
        {
            TB_Employee_WorkStatement model = EmployeeService.WorkStatementService.Get(ID);
            if (model.ID.ToInt() > 0)
            {
                ViewState["id"] = model.ID;

                TbTitle.Text = model.Title;
                TbWorkSummary.Text = model.WorkSummary;
                TbWorkPlan.Text = model.WorkPlan;
                DDLType.SelectedValue = model.Type.ToStr();
                TbStatementDate.Text = model.StatementDate.ToShortDateString();
            }
        }
    }


    //保存
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        TB_Employee_WorkStatement model = new TB_Employee_WorkStatement();
        if (ViewState["id"] != null)
        {
            model = EmployeeService.WorkStatementService.Get(ViewState["id"]);
        }
        model.Creater = AdminUserName;

        model.Title = TbTitle.Text.TrimEnd();
        model.Type = DDLType.SelectedValue.ToInt();
        model.WorkPlan = TbWorkPlan.Text;
        model.WorkSummary = TbWorkSummary.Text;
        model.StatementDate = TbStatementDate.Text.ToDateTime();

        model.Creater = AdminUserName;

        if (ViewState["id"] == null)
        {
            if (EmployeeService.WorkStatementService.Insert(model) == 1)
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
            if (EmployeeService.WorkStatementService.Update(model) == 1)
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
