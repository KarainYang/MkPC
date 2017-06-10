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

using YK.Service;
using YK.Model;
using YK.Common;

public partial class member_MyAddress : MemberBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadDataBind();
        }
    }

    public void LoadDataBind()
    {
        List<Expression> expression=new List<Expression>();
        expression.Add(new Expression("MemberID","=",MemberID.ToStr()));
        RepList.DataSource= MemberService.BuyerInfoService.Search(expression);
        RepList.DataBind();

        int id=Request.QueryString["id"].ToInt();
        if (id > 0)
        {
            TB_Member_BuyerInfo entity = MemberService.BuyerInfoService.Get(id);
            if (entity.ID > 0)
            {
                TbRealName.Text = entity.BuyerName;
                TbEmail.Text = entity.Email;
                TbPosted.Text = entity.PostalCode;
                TbMobile.Text = entity.Mobile;
                string[] zone = entity.Zone.Split('|');
                Address.Value = zone[0];
                TbAddress.Text = entity.Address;
                if(entity.Phone!="--")
                {
                    string[] phone=entity.Phone.Split('-');
                    switch(phone.Length)
                    {
                        case 1:
                            TbPhone.Text = phone[0];
                            break;
                        case 2:
                            TbPhone.Text = phone[0];
                            TbPhone2.Text = phone[1];
                            break;
                        case 3:
                            TbPhone.Text = phone[0];
                            TbPhone2.Text = phone[1];
                            TbPhone3.Text = phone[2];
                            break;
                    }
                }
                ViewState["id"] = entity.ID;
            }
        }
    }
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        if (ViewState["id"] == null)
        {
            if (RepList.Items.Count >= 10)
            {
                LbTooltip.Text = "最多保存10个有效地址";
            }
        }

        TB_Member_BuyerInfo entity = new TB_Member_BuyerInfo();
        entity.MemberID = MemberID;
        entity.BuyerName = TbRealName.Text.Trim();
        entity.Email = TbEmail.Text;
        entity.PostalCode = TbPosted.Text.Trim();
        entity.Mobile = TbMobile.Text.Trim();
        entity.Zone = Address.Value + "|" + Address.Text;
        entity.Address = TbAddress.Text.Trim();
        entity.Phone = TbPhone.Text.Trim() + "-" + TbPhone2.Text.Trim() + "-" + TbPhone3.Text.Trim();
        if (ViewState["id"] == null)
        {
            MemberService.BuyerInfoService.Insert(entity);
        }
        else
        {
            entity.ID = ViewState["id"].ToInt();
            MemberService.BuyerInfoService.Update(entity);
        }

        Response.Redirect(Request.Url.ToStr());
        
    }

    protected void RepList_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        int id = e.CommandArgument.ToInt();
        if (e.CommandName == "delete")
        {
            MemberService.BuyerInfoService.Delete(id);
        }
        LoadDataBind();
    }
}
