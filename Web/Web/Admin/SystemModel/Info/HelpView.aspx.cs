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
using YK.Service;
using YK.Interface;
using YK.Common;

public partial class Admin_SystemModel_Info_HelpView : BasePage
{
    public int classID;
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
        DDLCategory.DataSource = InfoService.HelpCategoryService.Search();
        DDLCategory.DataTextField = "Name";
        DDLCategory.DataValueField = "ID";
        DDLCategory.DataBind();

        int ID = CommonClass.ReturnRequestInt("id", 0);        
        if (ID> 0)
        {
            TB_Info_Help model = InfoService.HelpService.Get(ID);
            TbName.Text = model.Title;
            CheckBoxIsHidden.Checked = model.IsHIdden;
            FckRemark.Value = model.Remark;

            ViewState["id"] = model.ID;
        }
    }

    //保存
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        TB_Info_Help model = new TB_Info_Help();
        if(ViewState["id"] != null)
        {
            model = InfoService.HelpService.Get(ViewState["id"]);
        }
        model.CategoryId = DDLCategory.SelectedValue.ToInt();
        model.Title = TbName.Text;
        model.Remark = FckRemark.Value;
        model.IsHIdden = CheckBoxIsHidden.Checked;
        model.Creater = AdminUserName;

        IInfo_Help Help = InfoService.HelpService;
        if (ViewState["id"] == null)
        {
            model.AddDate = DateTime.Now;
            if (Help.Insert(model) == 1)
            {
                //操作日志
                AdminService.LogService.Insert(OperationType.用户操作, 0, "帮助中心添加" + model.Title);

                MessageDiv.InnerHtml = CommonClass.Reload("数据添加成功");
            }
            else
            {
                MessageDiv.InnerHtml = CommonClass.Alert("数据添加失败");
            }
        }
        else
        {
            if (Help.Update(model) == 1)
            {
                //操作日志
                AdminService.LogService.Insert(OperationType.用户操作, 0, "帮助中心修改" + model.Title);

                MessageDiv.InnerHtml = CommonClass.Reload("数据修改成功");
            }
            else
            {
                MessageDiv.InnerHtml = CommonClass.Alert("数据修改失败");
            }

        }
    }    
}
