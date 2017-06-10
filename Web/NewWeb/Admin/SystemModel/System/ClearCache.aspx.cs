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
using System.IO;
using System.Collections.Generic;

using YK.Common;
using System.ComponentModel;

public partial class Admin_WebSet_ClearCache : System.Web.UI.Page
{
    public IDictionary<string, string> idc = new Dictionary<string, string>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            idc = DescriptionAttributeHelper.GetEnumDescriptions<DataToCacheHelper.CacheNames>();
        }  

        
        string name=Request["name"];
        if (!string.IsNullOrEmpty(name))
        {
            CachesHelper.RemoveCache(name);
            MessageDiv.InnerHtml = CommonClass.Alert("清理成功");
        }

        
    }

    public string GetEnumDescription<TEnum>(object value)
    {
        return "";

        //Type enumType = typeof(TEnum);
        //if (!enumType.IsEnum)
        //{
        //    throw new ArgumentException("enumItem requires a Enum ");
        //}
        //var name = Enum.GetName(enumType, Convert.ToInt32(value));
        //if (name == null)
        //    return string.Empty;
        //object[] objs = enumType.GetField(name).GetCustomAttributes(typeof(DescriptionAttribute), false);
        //if (objs == null || objs.Length == 0)
        //{
        //    return string.Empty;
        //}
        //else
        //{
        //    DescriptionAttribute attr = objs[0] as DescriptionAttribute;
        //    return attr.Description;
        //}
    }
}
