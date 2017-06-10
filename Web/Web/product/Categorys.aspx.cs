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

public partial class product_Categorys : System.Web.UI.Page
{
    protected List<TB_Product_Categorys> categorysList = new List<TB_Product_Categorys>();
    protected void Page_Load(object sender, EventArgs e)
    {  
        categorysList = DataToCacheHelper.GetProductCategory();            
    }
}
