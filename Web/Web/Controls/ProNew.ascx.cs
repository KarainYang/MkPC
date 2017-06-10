﻿using System;
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

public partial class Controls_ProNew : System.Web.UI.UserControl
{
    protected List<TB_Product_Products> productList;

    protected void Page_Load(object sender, EventArgs e)
    {
        //新品
        List<Expression> express = new List<Expression>();
        express.Add(new Expression("IsDelete","=","0"));

        productList = ProductService.ProductsService.Search(3, express, " AddDate desc");
    }
}