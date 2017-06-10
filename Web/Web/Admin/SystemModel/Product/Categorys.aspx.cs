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

public partial class Admin_SystemModel_Product_Categorys : BasePage
{
    protected int cid = 0;
    protected int num = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDataBind();
        }
    }

    protected void LoadDataBind()
    {
        cid = CommonClass.ReturnRequestInt("cid");
        num = CommonClass.ReturnRequestInt("num");
        if (num <= 3)
        {
            num++;
        }
        List<Expression> express = new List<Expression>() { 
                        new Expression("ParentID","=",cid.ToStr())
                    };
        RepList.DataSource = ProductService.CategoryService.Search(express).OrderBy(c => c.OrderBy);
        RepList.DataBind();
    }

    //删除
    protected void ButtonDelete_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem ri in RepList.Items)
        {
            CheckBox cb = ((CheckBox)ri.FindControl("CheckBoxChoose"));
            string ID = ((HiddenField)ri.FindControl("HiddenFieldID")).Value;
            if (cb.Checked == true)
            {
                List<Expression> express = new List<Expression>() { 
                        new Expression("ID","=",ID)
                    };
                TB_Product_Categorys model = ProductService.CategoryService.Get(express);
                model.IsDelete = true;
                ProductService.CategoryService.Update(model, express);
            }
        }
        Response.Write("<script>window.location='" + Request.Url.ToString() + "';</script>");
    }

    //状态设置
    protected void DDLVouchSet_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem ri in RepList.Items)
        {
            CheckBox cb = ((CheckBox)ri.FindControl("CheckBoxChoose"));
            string ID = ((HiddenField)ri.FindControl("HiddenFieldID")).Value;
            if (cb.Checked == true)
            {
                List<Expression> express = new List<Expression>() { 
                        new Expression("ID","=",ID)
                    };
                TB_Product_Categorys model = ProductService.CategoryService.Get(express);
                model.VouchType = DDLVouchSet.SelectedValue.ToInt();
                ProductService.CategoryService.Update(model, express);
            }
        }
        Response.Write("<script>window.location='" + Request.Url.ToString() + "';</script>");
    }

    //显示设置
    protected void DDLIsHiddenSet_Click(object sender, EventArgs e)
    {

        foreach (RepeaterItem ri in RepList.Items)
        {
            CheckBox cb = ((CheckBox)ri.FindControl("CheckBoxChoose"));
            string ID = ((HiddenField)ri.FindControl("HiddenFieldID")).Value;
            if (cb.Checked == true)
            {
                List<Expression> express = new List<Expression>() { 
                        new Expression("ID","=",ID)
                    };
                TB_Product_Categorys model = ProductService.CategoryService.Get(express);
                model.IsHidden = CheckBoxIsHiddenSet.Checked;
                ProductService.CategoryService.Update(model, express);
            }
        }
        Response.Write("<script>window.location='" + Request.Url.ToString() + "';</script>");
    }
}
