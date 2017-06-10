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

public partial class Admin_SystemModel_Activity_ActivityView : BasePage
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
        int id = CommonClass.ReturnRequestInt("id", 0);        
        if ( id > 0)
        {
            TB_Activity_Activity model = ActivityService.ActivitysService.Get(id);
            TbName.Text = model.Name;
            RBLType.SelectedValue = model.Type.ToStr();
            if (model.IsSetDate)
            {
                TbStartDate.Text = model.StartDate.ToShortDateString();
                TbStopDate.Text = model.EndDate.ToShortDateString();
            }
            CheckBoxIsSetDate.Checked = model.IsSetDate;
            FckDescription.Value = model.Description;
            CheckBoxIsEnable.Checked = model.IsEnable;
            TbIntegral.Text = model.Integral.ToStr();
            TbDiscount.Text = model.Discount.ToStr();
            TbDeductibleAmount.Text = model.DeductibleAmount.ToStr();
            CheckBoxCouponIsSetDate.Checked = model.CouponIsSetDate;
            TbCouponStartDate.Text = model.CouponStartDate.ToStr();
            TbCouponEndDate.Text = model.CouponEndDate.ToStr();
            TbAmount.Text = model.Amount.ToStr();
            ViewState["id"] = model.ID;

            if (CheckBoxIsSetDate.Checked)
            {
                startDate.Visible = true;
                stopDate.Visible = true;
            }

            if (CheckBoxCouponIsSetDate.Checked)
            {
                TrCouponStartDate.Visible = true;
                TrCouponEndDate.Visible = true;
            }

            //设置显示行
            SetTr();
        }
    }

    //保存
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        //是否通过
        bool isTrue = true;

        if (TbAmount.Text.ToDecimal() <= 0)
        {

            LbAmount.Text = "请输入金额！";
            isTrue = false;
        }
        if (CheckBoxIsSetDate.Checked == true)
        {
            LbStartDate.Text = "";
            LbStopDate.Text = "";

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
        
        //类型
        switch (RBLType.SelectedValue.ToInt())
        {
            case 2:
                if (TbIntegral.Text.ToInt() == 0)
                {
                    LbIntegral.Text = "积分输入错误，必须位数字且大于0！";
                    isTrue = false;
                }
                break;
            case 3:
                if (TbDiscount.Text.ToInt() == 0 || TbDiscount.Text.ToInt() >= 10)
                {
                    LbDiscount.Text = "折扣输入错误，必须在0-10之间！";
                    isTrue = false;
                }

                break;
            case 4:
                if (TbDeductibleAmount.Text.ToDecimal() <= 0)
                {
                    LbDeductibleAmount.Text = "请选择输入优惠券抵扣金额！";
                    isTrue = false;
                }
                if (CheckBoxCouponIsSetDate.Checked)
                {
                    LbCouponStartDate.Text = "";
                    LbCouponEndDate.Text = "";

                    if (string.IsNullOrEmpty(TbCouponStartDate.Text))
                    {
                        LbCouponStartDate.Text = "请输入优惠开始使用时间";
                        isTrue = false;
                    }

                    if (string.IsNullOrEmpty(TbCouponEndDate.Text))
                    {
                        LbCouponEndDate.Text = "请输入优惠券结束使用时间";
                        isTrue = false;
                    }
                }

                break;
            case 5:
                if (TbDiscount.Text.ToInt() == 0)
                {
                    LbDiscount.Text = "减扣金额输入错误，必须为数字且大于0！";
                    isTrue = false;
                }
                break;
        }

        if (isTrue == false)
        {
            return;
        }

        TB_Activity_Activity model = new TB_Activity_Activity();
        if (ViewState["id"] != null)
        {
            model=ActivityService.ActivitysService.Get(ViewState["id"]);
        }
        model.Name = TbName.Text;
        model.Type = RBLType.SelectedValue.ToInt();        
        model.IsSetDate = CheckBoxIsSetDate.Checked;
        if (model.IsSetDate)
        { 
            model.StartDate = TbStartDate.Text.ToDateTime();
            model.EndDate = TbStopDate.Text.ToDateTime();
        }
        model.CouponIsSetDate = CheckBoxCouponIsSetDate.Checked;
        if (model.CouponIsSetDate)
        {
            model.CouponStartDate = TbCouponStartDate.Text.ToDateTime();
            model.CouponEndDate = TbCouponEndDate.Text.ToDateTime();
        }
        model.Integral = TbIntegral.Text.ToInt();
        model.Discount = TbDiscount.Text.ToDecimal();
        model.DeductibleAmount = TbDeductibleAmount.Text.ToDecimal();
        model.Description = FckDescription.Value;
        model.IsEnable = CheckBoxIsEnable.Checked; 
        model.Amount = TbAmount.Text.ToDecimal();
        model.Creater = AdminUserName;

        IActivity_Activity Activitys = ActivityService.ActivitysService;
        if (ViewState["id"] == null)
        {
            model.AddDate = DateTime.Now;
            if (Activitys.Insert(model) == 1)
            {
                //操作日志
                AdminService.LogService.Insert(OperationType.用户操作, 0, "促销活动" + model.Name);
                MessageDiv.InnerHtml = CommonClass.Reload("数据添加成功");
            }
            else
            {
                MessageDiv.InnerHtml = CommonClass.Alert("数据添加失败");
            }
        }
        else
        {
            if (Activitys.Update(model) == 1)
            {
                //操作日志
                AdminService.LogService.Insert(OperationType.用户操作, 0, "促销活动" + model.Name);
                MessageDiv.InnerHtml = CommonClass.Reload("数据修改成功");
            }
            else
            {
                MessageDiv.InnerHtml = CommonClass.Alert("数据修改失败");
            }

        }
    }

    //类型
    protected void RBLType_SelectedIndexChanged(object sender, EventArgs e)
    {
        tr2.Visible = false;
        tr3.Visible = false;
        tbCoupon.Visible = false;

        SetTr();
    }

    //设置显示行
    private void SetTr()
    {
        switch (RBLType.SelectedValue.ToInt())
        {
            case 2:
                tr2.Visible = true;
                break;
            case 3:
                LitTooltip.Text = "折扣：";
                tr3.Visible = true;
                break;
            case 4:
                tbCoupon.Visible = true;                
                break;
            case 5:
                LitTooltip.Text = "减扣金额：";
                tr3.Visible = true;
                break;
        }
    }

    //设置日期
    protected void CheckBoxIsSetDate_CheckedChanged(object sender, EventArgs e)
    {
        startDate.Visible = CheckBoxIsSetDate.Checked;
        stopDate.Visible = CheckBoxIsSetDate.Checked;
    }

    //设置优惠券有效期
    protected void CheckBoxCouponIsSetDate_CheckedChanged(object sender, EventArgs e)
    {
        TrCouponStartDate.Visible = CheckBoxCouponIsSetDate.Checked;
        TrCouponEndDate.Visible = CheckBoxCouponIsSetDate.Checked;
    }
}
