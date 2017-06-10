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

public partial class Admin_AdminModel_System_ExcelFieldsView : BasePage
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
         DDLModel.DataSource= SystemService.ExcelModelService.Search();
         DDLModel.DataTextField = "ModelName";
         DDLModel.DataValueField = "ID";
         DDLModel.DataBind();

        int id = CommonClass.ReturnRequestInt("id", 0);        
        if(id>0)
        {
            TB_Excel_Fields model = SystemService.ExcelFieldsService.Get(id);
            if(model!=null)
            {
                DDLModel.SelectedValue = model.ModelID.ToStr();
                TbFieldName.Text = model.FieldName;
                TbChineseName.Text = model.ChineseName;
                TbOrderBy.Text = model.OrderBy.ToStr();
                CbExport.Checked = model.Type.Contains("0") ? true : false;
                CbImport.Checked = model.Type.Contains("1") ? true : false;
                ViewState["id"] = model.ID;
            }            
        }
    }

    //保存
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        TB_Excel_Fields model = new TB_Excel_Fields();
        if (ViewState["id"] != null)
        {
            model = SystemService.ExcelFieldsService.Get(ViewState["id"]);
        }

        model.ModelID = DDLModel.SelectedValue.ToInt();
        model.FieldName = TbFieldName.Text.Trim();
        model.ChineseName = TbChineseName.Text;
        model.Type = ((CbExport.Checked ? "0," : "") + (CbImport.Checked ? "1," : "")).TrimEnd(',');
        model.OrderBy = TbOrderBy.Text.ToInt();
        model.Creater = AdminUserName;
        model.AddDate = DateTime.Now;
        IExcel_Fields Excel = SystemService.ExcelFieldsService;
        if (ViewState["id"] == null)
        {
            if (Excel.Insert(model) == 1)
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
            if (Excel.Update(model) == 1)
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
