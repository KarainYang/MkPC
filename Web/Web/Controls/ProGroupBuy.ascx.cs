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

public partial class Controls_ProGroupBuy : System.Web.UI.UserControl
{
    public List<TB_Product_Group> groupBuyList;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDataBind(1);
        }
    }

    public void LoadDataBind(int pageIndex)
    {
        List<Expression> express = new List<Expression>();
        express.Add(new Expression("IsDelete", "=", "0"));
        express.Add(new Expression("VouchType", "=", "1"));
        express.Add(new Expression("StartDate", "<=", DateTime.Now.ToShortDateString()));
        express.Add(new Expression("StopDate", ">=", DateTime.Now.ToShortDateString()));
        groupBuyList = ProductService.GroupService.Search(3,express,"OrderBy asc,addDate desc");
    }
}
