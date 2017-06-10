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

public partial class Admin_AdminModel_Member_CouponView : BasePage
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
        TB_Member_Coupon model = new TB_Member_Coupon();
        int id = CommonClass.ReturnRequestInt("id", 0);        
        if (id > 0)
        {
            model = MemberService.CouponService.Get(id);
            TbTitle.Text = model.Title;
            TbAmount.Text = model.Amount.ToStr();
            CheckBoxIsSetDate.Checked = model.IsSetDate;
            if(model.IsSetDate)
            {
                startDate.Visible = true;
                stopDate.Visible = true;
            }
            TbStartDate.Text = model.StartDate.ToShortDateString();
            TbStopDate.Text = model.StopDate.ToShortDateString();
            ViewState["id"] = model.ID;
        }
    }

    //设置日期
    protected void CheckBoxIsSetDate_CheckedChanged(object sender, EventArgs e)
    {
        startDate.Visible = CheckBoxIsSetDate.Checked;
        stopDate.Visible = CheckBoxIsSetDate.Checked;
    }

    //保存
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        bool isTrue = true;
        if (CheckBoxIsSetDate.Checked == true)
        {
            LbAmount.Text = "";
            LbStartDate.Text = "";
            LbStopDate.Text = "";

            if (TbAmount.Text.ToDecimal() <= 0)
            {
                LbAmount.Text = "请正确输入抵扣金额！";
                isTrue = false;
            }
            if (TbStartDate.Text == string.Empty)
            {
                LbStartDate.Text = "请输入开始时间！";
                isTrue = false;
            }
            if (TbStopDate.Text == string.Empty)
            {
                LbStopDate.Text = "请输入结束时间！";
                isTrue = false;
            }
        }

        if (isTrue == false)
        {
            return;
        }
        TB_Member_Coupon model = new TB_Member_Coupon();
        if (ViewState["id"] != null)
        {
            model = MemberService.CouponService.Get(ViewState["id"]);
        }
        model.Title = TbTitle.Text;
        model.Amount = TbAmount.Text.ToDecimal();
        model.StartDate = Convert.ToDateTime(TbStartDate.Text);
        model.StopDate = Convert.ToDateTime(TbStopDate.Text);
        model.AddDate = DateTime.Now;

        IMember_Coupon members = MemberService.CouponService;
        if (ViewState["id"] == null)
        {
            if (members.Insert(model) == 1)
            {
                //操作日志
                AdminService.LogService.Insert(OperationType.用户操作, AdminUserID, "添加优惠券" + model.Title);

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
                AdminService.LogService.Insert(OperationType.用户操作, AdminUserID, "修改优惠券" + model.Title);

                MessageDiv.InnerHtml = CommonClass.Reload("数据修改成功");
            }
            else
            {
                MessageDiv.InnerHtml = CommonClass.Alert("数据修改失败");
            }

        }
    }
}
