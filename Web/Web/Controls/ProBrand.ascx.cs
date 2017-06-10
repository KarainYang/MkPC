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

public partial class Controls_ProBrand : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RepBrand.DataSource = ProductService.BrandsService.GetHotSalesBrands(6);
        RepBrand.DataBind();

    }
}
