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

public partial class Admin_AdminModel_System_AdverPicView : BasePage
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
        int id = CommonClass.ReturnRequestInt("id", 0);        
        if(id>0)
        {
            TB_System_AdverPic model = SystemService.AdverPicService.Get(id);
            if(model!=null)
            {
                TbName.Text = model.Name;
                PicUrl.Url = model.PicUrl;
                TbLinkUrl.Text = model.LinkUrl;
                CheckIsHidden.Checked = model.IsHidden;
                TbOrderBy.Text = model.OrderBy.ToStr();
                ViewState["id"] = model.ID;
            }            
        }
    }

    //保存
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        TB_System_AdverPic model = new TB_System_AdverPic();
        if (ViewState["id"] != null)
        {
            model = SystemService.AdverPicService.Get(ViewState["id"]);
        }
        else
        {
            model.AdverId = Request["adverId"].ToInt();
        }
        model.Name = TbName.Text.Trim();
        model.PicUrl = PicUrl.Url;
        model.LinkUrl = TbLinkUrl.Text;
        model.IsHidden = CheckIsHidden.Checked;
        model.OrderBy = TbOrderBy.Text.ToInt();
        model.Creater = AdminUserName;
        model.AddDate = DateTime.Now;
        ISystem_AdverPic adverPic = SystemService.AdverPicService;
        if (ViewState["id"] == null)
        {
            if (adverPic.Insert(model) == 1)
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
            if (adverPic.Update(model) == 1)
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
