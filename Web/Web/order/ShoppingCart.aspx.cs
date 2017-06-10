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
using YK.Common;

public partial class order_ShoppingCart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDataBind();
        }
    }

    public void LoadDataBind()
    {
        DataSet ds = Cart.GetCart();
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                RepList.DataSource = ds;
                RepList.DataBind();
            }
            else
            {
                CartDiv.Visible = false;
                CartNull.Visible = true;
            }
        }
    }

    protected void RepList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int id = e.CommandArgument.ToInt();

        if (e.CommandName == "delete")
        {
            Cart.RemoveRow(id);
        }

        if (e.CommandName == "update")
        {
            int count = ((TextBox)e.Item.FindControl("TbCount")).Text.ToInt();
            Cart.UpdateCount(id, count);
        }

        LoadDataBind();
    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Cart.ClearCart();
        LoadDataBind();
    }
}
