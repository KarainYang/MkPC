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
using YK.Services.Examination;
using YK.Models.Examination;

public partial class Admin_SystemModel_Exam_VisionSubjectView : BasePage
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
        DDLModule.DataSource = DataToCacheHelper.GetAllDictionaries().Where(w => w.TypeCode == "04").ToList();
        DDLModule.DataTextField = "Name";
        DDLModule.DataValueField = "Code";
        DDLModule.DataBind();

        int ID = CommonClass.ReturnRequestInt("id", 0);
        if (ID > 0)
        {
            var model = VisionService.ExamVisionSubjectService.Get(ID);
            if (model.ID.ToInt() > 0)
            {
                Picture.Url = model.PicUrl;
                FckDesc.Value = model.Description;
                DDLModule.SelectedValue = model.Type;
                TbName.Text = model.Name;
                TbOrderBy.Text = model.OrderBy.ToStr();
                TbResult.Text = model.Result;

                ViewState["id"] = model.ID;
            }
        }
    }

    //保存
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        ExamVisionSubject model = new ExamVisionSubject();
        if (ViewState["id"] != null)
        {
            model = VisionService.ExamVisionSubjectService.Get(ViewState["id"]);
        }
        model.Type = DDLModule.SelectedValue;
        model.Name = TbName.Text;
        model.Result = TbResult.Text;
        model.OrderBy = TbOrderBy.Text.ToInt();
        model.PicUrl = Picture.Url;
        model.Description = FckDesc.Value;
        model.Creater = AdminUserName;
        model.CreatedOn = DateTime.Now;

        if (ViewState["id"] == null)
        {
            if (VisionService.ExamVisionSubjectService.Insert(model) == 1)
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
            model.ID = ViewState["id"].ToInt();
            if (VisionService.ExamVisionSubjectService.Update(model) == 1)
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
