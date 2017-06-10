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

public partial class Admin_SystemModel_Project_ProjectView : BasePage
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
            TB_Project_Projects model = ProjectService.ProjectsService.Get(ID);
            if (model.ID.ToInt() > 0)
            {
                ViewState["id"] = model.ID;

                TbName.Text = model.Name;
                TbStartDate.Text = model.StartDate.ToShortDateString();
                TbEndDate.Text = model.EndDate.ToShortDateString();
                FckDesc.Value = model.Remark;
            }
        }
    }


    object obj = new object();

    //保存
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        lock (obj)
        {
            TB_Project_Projects model = new TB_Project_Projects();
            if (ViewState["id"] != null)
            {
                model = ProjectService.ProjectsService.Get(ViewState["id"]);
            }
            model.Name = TbName.Text;
            model.StartDate = TbStartDate.Text.ToDateTime();
            model.EndDate = TbEndDate.Text.ToDateTime();
            model.Remark = FckDesc.Value;
            
            if (ViewState["id"] == null)
            {
                if (ProjectService.ProjectsService.Insert(model) == 1)
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
                if (ProjectService.ProjectsService.Update(model) == 1)
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
    
}
