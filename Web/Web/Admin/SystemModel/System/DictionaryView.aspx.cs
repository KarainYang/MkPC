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

public partial class Admin_AdminModel_System_DictionaryView : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadDataBind();            
        }
    }

    //加载
    public void LoadDataBind()
    {
         DDLModel.DataSource= SystemService.DictionaryTypeService.Search();
         DDLModel.DataTextField = "Name";
         DDLModel.DataValueField = "Code";
         DDLModel.DataBind();

         if (!string.IsNullOrEmpty(Request["typeCode"]))
         {
             DDLModel.SelectedValue = Request["typeCode"];
         }

        int id = CommonClass.ReturnRequestInt("id", 0);        
        if(id>0)
        {
            TB_System_Dictionary model = SystemService.DictionaryService.Get(id);
            if(model!=null)
            {
                DDLModel.SelectedValue = model.TypeCode.ToStr();
                TbName.Text = model.Name;
                TbCode.Text = model.Code;
                TbRemark.Text = model.Remark;
                TbOrderBy.Text = model.OrderBy.ToStr();
                ViewState["id"] = model.ID;
            }            
        }
    }

    //保存
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        TB_System_Dictionary model = new TB_System_Dictionary();

        if (ViewState["id"] != null)
        {
            model = SystemService.DictionaryService.Get(ViewState["id"]);
            if (model.Code != TbCode.Text.TrimEnd())
            {
                List<Expression> express = new List<Expression>();
                express.Add(new Expression("Code", "=", TbCode.Text.TrimEnd()));
                var list = SystemService.DictionaryService.Search(express);
                if (list.Count > 0)
                {
                    MessageDiv.InnerHtml = CommonClass.Alert("当前标识已存在，请重新输入");
                    return;
                }
            }
        }
        else
        {
            List<Expression> express = new List<Expression>();
            express.Add(new Expression("Code", "=", TbCode.Text.TrimEnd()));
            var list = SystemService.DictionaryService.Search(express);
            if (list.Count > 0)
            {
                MessageDiv.InnerHtml = CommonClass.Alert("当前标识已存在，请重新输入");
                return;
            }
        }

        model.TypeCode = DDLModel.SelectedValue;
        model.Name = TbName.Text.Trim();
        model.Code = TbCode.Text;
        model.Remark = TbRemark.Text;
        model.OrderBy = TbOrderBy.Text.ToInt();
        model.Creater = AdminUserName;
        model.AddDate = DateTime.Now;
        ISystem_Dictionary Dictionary = SystemService.DictionaryService;
        if (ViewState["id"] == null)
        {
            if (Dictionary.Insert(model) == 1)
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
            if (Dictionary.Update(model) == 1)
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
