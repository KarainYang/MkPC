using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Data;

using YK.Common;
using log4net;

public class aaaa
{
    public DateTime? dt { get; set; }
    public string sss { get; set; }
}

public partial class _Default : System.Web.UI.Page
{
    private readonly ILog _logger = LogManager.GetLogger(typeof(_Default));

    protected void Page_Load(object sender, EventArgs e)
    {
        _logger.Info("hello");

        Response.Write(545646.GetType().Name);
        Response.Write("adfasdfaf".GetType().Name);

        aaaa aa = new aaaa();
        foreach (var prop in aa.GetType().GetProperties())
        {
            Type typex = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
            Response.Write(typex.Name + "<br/>");
        }

        DataSet ds = new YK.Core.SqlHelper().GetDataSet("select top 0 * from dbo.TB_Admin_Resources");
        foreach (DataColumn cn in ds.Tables[0].Columns)
        {
            Response.Write(cn.DataType+"<br/>");
        }

        object[] paras = new object[1] { 1 };
        Type type = Type.GetType("_Default");
        object obj = Activator.CreateInstance(type, null);
        Type[] types = new Type[1];
        for (int i = 0; i < paras.Length; i++)
        {
            types[i] = paras[i].GetType();
        }
        MethodInfo methodInfo = type.GetMethod("GetCount", types);
        Response.Write(methodInfo.Invoke(obj, paras));
        //
        //Response.Write(type.InvokeMember("GetCount", BindingFlags.InvokeMethod, null, obj, paras));

        string name = "家用电器";

        var list2 = YK.Service.ProductService.CategoryService.Search(w => w.CategoryName != name && w.ID > 8);
        
        var list = YK.Service.ProductService.CategoryService.Search(w => w.CategoryName.Like(name));

        List<object> arr = new List<object>() { "家用电器" };
        var list3 = YK.Service.ProductService.CategoryService.Search(w => w.CategoryName.In(arr) && w.ID < 8);
    }

    public int GetCount()
    {
        return 1000;
    }

    public int GetCount(int i)
    {
        return 9000;
    }
}