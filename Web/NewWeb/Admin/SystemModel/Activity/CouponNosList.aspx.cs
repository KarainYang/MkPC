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
using YK.Common;
using YK.Service;

public partial class Admin_AdminModel_Activity_CouponNosList : BasePage
{
  
    protected void Page_Load(object sender, EventArgs e)
    {
        ButtonDelete.Attributes.Add("onclick", "return confirm('确认删除这条信息吗？')");
        if (!IsPostBack)
        {            
            ViewState["PageIndex"] = 1;
            ViewState["search"] = "";

            LoadDataBind();
        }
    }

    //加载所有信息
    public void LoadDataBind()
    {     
        int recordCount = 0;
        string key = ViewState["search"].ToString();
        int pageIndex = Convert.ToInt32(ViewState["PageIndex"]);
        int pageSize = AspNetPager1.PageSize;
        int activityID = CommonClass.ReturnRequestInt("activityID", 0);

        List<Expression> express = new List<Expression>();
        express.Add(new Expression("ActivityID", "=", activityID.ToStr()));

        RepList.DataSource = ActivityService.CouponNosService.Search
            (pageSize, pageIndex, express, "SendDate desc", ref recordCount);
        RepList.DataBind();
        AspNetPager1.RecordCount = recordCount;
    }

    //删除
    protected void ButtonDelete_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem ri in RepList.Items)
        {
            CheckBox cb = ((CheckBox)ri.FindControl("CheckBoxChoose"));
            int ID = Convert.ToInt32(((HiddenField)ri.FindControl("HiddenFieldID")).Value);
            if (cb.Checked == true)
            {
                ActivityService.CouponNosService.Delete(ID);
            }
        }
        //重新加载
        LoadDataBind();
    }

    //搜索
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        ViewState["search"] = TbKey.Text.Trim();
        ViewState["PageIndex"] = 1;
        AspNetPager1.CurrentPageIndex = 1;
        LoadDataBind(); //重新加载
        
    }

    //搜索
    protected void BtnSend_Click(object sender, EventArgs e)
    {
        List<Expression> express = new List<Expression>();
        express.Add(new Expression("MemberName", "=", TbKey.Text));
        TB_Member_Members member = MemberService.MembersService.Get(express);
        if (member.ID > 0)
        {
            LbTooltip.Text = "";

            TB_Activity_CouponNos entity = new TB_Activity_CouponNos();
            entity.MemberID = member.ID;
            entity.ActivityID = CommonClass.ReturnRequestInt("activityID", 0);
            entity.IsUse = false;
            entity.SendDate = DateTime.Now;
            entity.CouponNo = System.Guid.NewGuid().ToStr();
            ActivityService.CouponNosService.Insert(entity);
            LoadDataBind(); //重新加载
        }
        else
        {
            LbTooltip.Text = "当前会员不存在！";
        }
    }

    //分页
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        ViewState["PageIndex"] = e.NewPageIndex;
        LoadDataBind();
    }
}
