using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YK.Common;
using System.Web.Services;

public partial class Address : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string msg = AddressHelper.GetProvince("110000");
        //Response.Write(AddressHelper.GetProvince("110000") + AddressHelper.GetCity("110000") + AddressHelper.GetArea("110100"));
    }

    [WebMethod]
    public static string Province(string id)
    {
        return AddressHelper.GetProvince("");
    }

    [WebMethod]
    public static string City(string id)
    {
        return AddressHelper.GetCity(id);
    }

    [WebMethod]
    public static string Area(string id)
    {
        return AddressHelper.GetArea(id);
    }
}