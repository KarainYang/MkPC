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

public partial class Admin_SystemModel_Product_ReplyView : BasePage
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
        int ID = CommonClass.ReturnRequestInt("id", 0);
        if (ID > 0)
        {
            TB_Product_Reply model = ProductService.ReplyService.Get(ID);
            if (model.ID.ToInt() > 0)
            {
                TbContent.Text = model.ComContent;
                ViewState["id"] = model.ID;
            }
        }
    }

    //保存
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        TB_Product_Reply model = new TB_Product_Reply();
        if (ViewState["id"] != null)
        {
            model = ProductService.ReplyService.Get(ViewState["id"]);
        }
        else
        {
            model.QuestionID = Request["qid"].ToInt();
        }
        model.MemberID = AdminUserID;
        model.ComContent = TbContent.Text;
        model.AddDate = DateTime.Now;

        if (ViewState["id"] == null)
        {
            if (ProductService.ReplyService.Insert(model) == 1)
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
            if (ProductService.ReplyService.Update(model) == 1)
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
