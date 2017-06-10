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

public partial class Admin_SystemModel_Project_TaskHandle : BasePage
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
        TB_Project_Task model = ProjectService.TaskService.Get(ID);
        ViewState["id"] = model.ID;

        DDLStatus.SelectedValue = model.State.ToStr();
        TbReason.Text = model.Reason;
        TbProgress.Text = model.Progress.ToStr();
    }


    //保存
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        TB_Project_Task model = ProjectService.TaskService.Get(ViewState["id"]);
        model.State = DDLStatus.SelectedValue.ToInt();
        model.Reason = TbReason.Text;
        model.Progress = TbProgress.Text.ToInt();

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
