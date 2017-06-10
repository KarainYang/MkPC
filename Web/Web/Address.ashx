<%@ WebHandler Language="C#" Class="Address" %>

using System;
using System.Web;
using YK.Common;
using System.Web.Services;

public class Address : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        int type = CommonClass.ReturnRequestInt("type",1);
        switch(type)
        {
            case 1:
                Province();
                break;
            case 2:
                City();
                break;
            case 3:
                Area();
                break;
        }
        
    }
    public void Province()
    {
        string msg = AddressHelper.GetProvince("");
        HttpContext.Current.Response.Write(msg);
    }
    public void City()
    {
        string code = CommonClass.ReturnRequestStr("code");
        HttpContext.Current.Response.Write(AddressHelper.GetCity(code));
    }
    public void Area()
    {
        string code = CommonClass.ReturnRequestStr("code");
        HttpContext.Current.Response.Write(AddressHelper.GetArea(code));
    }
    
    public bool IsReusable {
        get {
            return false;
        }
    }

}