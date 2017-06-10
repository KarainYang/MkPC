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

public partial class Admin_AdminModel_Member_LevelView : BasePage
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
        TB_Member_Levels model = new TB_Member_Levels();
        int id = CommonClass.ReturnRequestInt("id", 0);        
        if ( id > 0)
        {
            model = MemberService.LevelsService.Get(id);
            TbTitle.Text = model.LevelName;
            TbDiscount.Text = model.Discount.ToStr();
            CheckIsDefault.Checked = model.IsDefault;
            CheckIsEnableDis.Checked = model.IsEnableDis;
            TbMinIntegral.Text = model.MinIntegral.ToStr();
            ViewState["id"] = model.ID;
        }
    }

    //保存
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        TB_Member_Levels model = new TB_Member_Levels();
        if (ViewState["id"] != null)
        {
            model = MemberService.LevelsService.Get(ViewState["id"]);
        }
        model.LevelName = TbTitle.Text;
        model.Discount = TbDiscount.Text.ToDecimal();
        model.IsDefault = CheckIsDefault.Checked;
        model.IsEnableDis = CheckIsEnableDis.Checked;
        model.MinIntegral = TbMinIntegral.Text.ToInt();
        model.AddDate = DateTime.Now;

        IMember_Levels members = MemberService.LevelsService;
        if (ViewState["id"] == null)
        {
            if (members.Insert(model) == 1)
            {
                //操作日志
                AdminService.LogService.Insert(OperationType.用户操作, AdminUserID, "添加会员级别" + model.LevelName);

                MessageDiv.InnerHtml = CommonClass.Reload("数据添加成功");
            }
            else
            {
                MessageDiv.InnerHtml = CommonClass.Alert("数据添加失败");
            }
        }
        else
        {
            if (members.Update(model) == 1)
            {
                //操作日志
                AdminService.LogService.Insert(OperationType.用户操作, AdminUserID, "修改会员级别" + model.LevelName);

                MessageDiv.InnerHtml = CommonClass.Reload("数据修改成功");
            }
            else
            {
                MessageDiv.InnerHtml = CommonClass.Alert("数据修改失败");
            }

        }
    }
}
