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

public partial class Admin_SystemModel_Info_HotSearchView : BasePage
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
            TB_Info_HotSearch model = InfoService.HotSearchService.Get(ID);
            TbTitle.Text = model.KeyWord;
            TbCount.Text = model.ClickCount.ToStr();
            TbOrderBy.Text = model.OrderBy.ToStr();
            ViewState["id"] = model.ID;
        }
    }

    //保存
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        TB_Info_HotSearch model = new TB_Info_HotSearch();
        if (ViewState["id"] != null)
        {
            model = InfoService.HotSearchService.Get(ViewState["id"]);
        }
        model.KeyWord = TbTitle.Text;
        model.ClickCount = TbCount.Text.ToInt();
        model.OrderBy = TbOrderBy.Text.ToInt();
        model.Creater = AdminUserName;

        IInfo_HotSearch HotSearch = InfoService.HotSearchService;
        if (ViewState["id"] == null)
        {
            model.AddDate = DateTime.Now;
            if (HotSearch.Insert(model) == 1)
            {
                //操作日志
                AdminService.LogService.Insert(OperationType.用户操作, 0, "添加热门搜索" + model.KeyWord);

                MessageDiv.InnerHtml = CommonClass.Reload("数据添加成功");
            }
            else
            {
                MessageDiv.InnerHtml = CommonClass.Alert("数据添加失败");
            }
        }
        else
        {
            if (HotSearch.Update(model) == 1)
            {
                //操作日志
                AdminService.LogService.Insert(OperationType.用户操作, 0, "修改热门搜索" + model.KeyWord);

                MessageDiv.InnerHtml = CommonClass.Reload("数据修改成功");
            }
            else
            {
                MessageDiv.InnerHtml = CommonClass.Alert("数据修改失败");
            }

        }
    }    
}
