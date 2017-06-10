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
using YK.Service;
using YK.Common;

public partial class Controls_Top : System.Web.UI.UserControl
{
    protected DataSet cartDs;  
    public string memberName = null;
    protected List<TB_Info_HotSearch> hotSearch = new List<TB_Info_HotSearch>();

    protected void Page_Load(object sender, EventArgs e)
    {
        LoadDataBind();

        hotSearch = InfoService.HotSearchService.Search(3, new List<Expression>(), "OrderBy asc,ClickCount desc,AddDate desc");
    }

    public void LoadDataBind()
    {          
        int count=0;
        decimal amount = 0;

        if (Request.Cookies["MemberInfo"] != null)
        {
            memberName = Request.Cookies["MemberInfo"]["MemberName"];

            cartDs = Cart.GetCart();
            if (cartDs.Tables.Count > 0)
            {
                foreach (DataRow dr in cartDs.Tables[0].Rows)
                {
                    count += dr["count"].ToInt();
                    amount += dr["amount"].ToDecimal();
                }
                RepCart.DataSource = cartDs;
                RepCart.DataBind();
            }
        }

        LbCount.Text = count.ToStr();
        LbAmount.Text = amount.ToStr();
        LbTopCount.Text = count.ToStr();
    }

    protected void RepCart_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int pid=e.CommandArgument.ToInt();
        if (e.CommandName == "delete")
        {
            Cart.RemoveRow(pid);
            LoadDataBind();
        }
    }
}
