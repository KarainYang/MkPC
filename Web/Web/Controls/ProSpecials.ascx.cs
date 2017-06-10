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

using YK.Common;
using YK.Service;
using YK.Model;

public partial class Controls_ProSpecials : System.Web.UI.UserControl
{
    public List<TB_Product_Products> list;
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Expression> express = new List<Expression>();
        express.Add(new Expression("IsDelete", "=", "0"));
        express.Add(new Expression("Mark", "like", "3"));

        list=ProductService.ProductsService.Search(2, express);
    }

    protected int GetCoummentCount(int pid)
    {
        List<Expression> express = new List<Expression>();
        express.Add(new Expression("ProductID", "=", pid.ToStr()));
        return ProductService.CommentsService.Search(express).Count;
    }
}
