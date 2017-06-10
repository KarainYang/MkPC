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
using System.Xml;
using YK.Common;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //DataSet ds = new DataSet();
        //ds.ReadXml(Server.MapPath("~/App_Data/cart.xml"));
        //XmlDocument xmldoc = new XmlDocument();
        //xmldoc.Load(Server.MapPath("~/App_Data/cart.xml"));

        //GridView1.DataSource = ds;// Request.Cookies["cart"].Value as DataTable;
        //GridView1.DataBind();

        "1".GetEntityList<YK.Model.TB_Product_Products>("CategoryID");

        string cmdText = "select TB_Product_Categorys.ID,TB_Product_Products.ID from TB_Product_Categorys,TB_Product_Products where TB_Product_Categorys.id = CategoryID";
        DataSet ds2 = YK.Core.SqlHelper.GetDataSet(cmdText);

        GridView1.DataSource = ds2;// YK.Common.CommonClass.DataTableToEntityList<YK.Model.TB_Product_Products>(ds2.Tables[0]);
        GridView1.DataBind();
       
        var list2 = YK.Common.CommonClass.DataTableToEntityList<YK.Model.TB_Product_Categorys>(ds2.Tables[0]);
        GridView2.DataSource = list2;
        GridView2.DataBind();
    }
}
