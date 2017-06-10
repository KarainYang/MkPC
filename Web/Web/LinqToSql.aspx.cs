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
using System.Data.Linq;

using YK.Model;

public partial class LinqToSql : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataContext db = new DataContext(ConfigurationManager.ConnectionStrings["SqlConn"].ToString());
        Table<TB_Admin_User> admin = db.GetTable<TB_Admin_User>();      
    
        var adminList = admin.ToList();
        foreach (TB_Admin_User a in adminList)
        {
            Response.Write(a.UserName);
        }


    }
}
