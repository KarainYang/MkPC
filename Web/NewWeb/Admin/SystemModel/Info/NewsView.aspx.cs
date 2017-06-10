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

public partial class Admin_SystemModel_Info_NewsView : BasePage
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
        DDLCategory.DataSource = InfoService.NewsCategoryService.Search();
        DDLCategory.DataTextField = "Name";
        DDLCategory.DataValueField = "ID";
        DDLCategory.DataBind();

        int ID = CommonClass.ReturnRequestInt("id", 0);        
        if ( ID > 0)
        {
            TB_Info_News model = InfoService.NewsService.Get(ID);
            DDLCategory.SelectedValue = model.CategoryId.ToStr();
            TbName.Text = model.Title;
            CheckBoxIsHidden.Checked = model.IsHIdden;
            FckRemark.Value = model.Remark;
            CheckBoxIsVouch.Checked = model.IsVouch;
            ViewState["id"] = model.ID;
        }
    }

    //保存
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        TB_Info_News model = new TB_Info_News();
        if (ViewState["id"] != null)
        {
            model = InfoService.NewsService.Get(ViewState["id"]);
        }
        model.CategoryId = DDLCategory.SelectedValue.ToInt();
        model.Title = TbName.Text;
        model.CategoryCode = InfoService.NewsCategoryService.Get(DDLCategory.SelectedValue).Code;
        model.Remark = FckRemark.Value;
        model.IsHIdden = CheckBoxIsHidden.Checked;
        model.IsVouch = CheckBoxIsVouch.Checked;
        model.Creater = AdminUserName;

        IInfo_News News = InfoService.NewsService;
        if (ViewState["id"] == null)
        {
            model.AddDate = DateTime.Now;
            if (News.Insert(model) == 1)
            {
                //操作日志
                AdminService.LogService.Insert(OperationType.用户操作, 0, "添加新闻" + model.Title);

                MessageDiv.InnerHtml = CommonClass.Reload("数据添加成功");
            }
            else
            {
                MessageDiv.InnerHtml = CommonClass.Alert("数据添加失败");
            }
        }
        else
        {
            if (News.Update(model) == 1)
            {
                //操作日志
                AdminService.LogService.Insert(OperationType.用户操作, 0, "修改新闻" + model.Title);

                MessageDiv.InnerHtml = CommonClass.Reload("数据修改成功");
            }
            else
            {
                MessageDiv.InnerHtml = CommonClass.Alert("数据修改失败");
            }

        }
    }    
}
