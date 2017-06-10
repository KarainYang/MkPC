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

public partial class Admin_SystemModel_Order_PaymentView : BasePage
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

        TB_Order_Payment model = OrderService.PaymentService.Get(id);
        if (model.ID > 0)
        {
            TbName.Text = model.PaymentTitle;
            TbOrderBy.Text = model.OrderBy.ToStr();
            TbDesc.Text = model.PaymentNote;
            ViewState["id"] = model.ID;
        }
    }

    //保存
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        TB_Order_Payment model = new TB_Order_Payment();

        if (ViewState["id"] != null)
        {
            model = OrderService.PaymentService.Get(ViewState["id"]);
        }

        model.PaymentTitle = TbName.Text.Trim();
        model.OrderBy = TbOrderBy.Text.ToInt();
        model.PaymentNote = TbDesc.Text;

        IOrder_Payment paymentService = OrderService.PaymentService;
        if (ViewState["id"] == null)
        {
            if (paymentService.Insert(model) == 1)
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
            model.ID = ViewState["id"].ToInt();
            if (paymentService.Update(model) == 1)
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
