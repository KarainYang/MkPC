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

public partial class Admin_SystemModel_Info_LinksView : BasePage
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
            TB_Info_Links model = InfoService.LinksService.Get(ID);
            TbTitle.Text = model.Title;
            CheckBoxIsHidden.Checked = model.IsHIdden;
            ImgUrl.Url = model.ImgUrl;
            TbLinkUrl.Text = model.Url;
            ViewState["id"] = model.ID;
        }
    }

    //保存
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        TB_Info_Links model = new TB_Info_Links();
        if (ViewState["id"] != null)
        {
            model = InfoService.LinksService.Get(ViewState["id"]);
        }
        model.Title = TbTitle.Text;
        model.ImgUrl = ImgUrl.Url;
        model.Url = TbLinkUrl.Text;
        model.IsHIdden = CheckBoxIsHidden.Checked;
        model.Creater = AdminUserName;

        IInfo_Links Links = InfoService.LinksService;
        if (ViewState["id"] == null)
        {
            model.AddDate = DateTime.Now;
            if (Links.Insert(model) == 1)
            {
                //操作日志
                AdminService.LogService.Insert(OperationType.用户操作, 0, "添加友情连接" + model.Title);

                MessageDiv.InnerHtml = CommonClass.Reload("数据添加成功");
            }
            else
            {
                MessageDiv.InnerHtml = CommonClass.Alert("数据添加失败");
            }
        }
        else
        {
            if (Links.Update(model) == 1)
            {
                //操作日志
                AdminService.LogService.Insert(OperationType.用户操作, 0, "修改友情连接" + model.Title);

                MessageDiv.InnerHtml = CommonClass.Reload("数据修改成功");
            }
            else
            {
                MessageDiv.InnerHtml = CommonClass.Alert("数据修改失败");
            }

        }
    }    
}
