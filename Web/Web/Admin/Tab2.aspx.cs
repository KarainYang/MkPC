using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YK.Model;
using YK.Common;

public partial class Admin_Tab : System.Web.UI.Page
{
    public string resourcesJson = "";
    public List<TB_Admin_Resources> resources = new List<TB_Admin_Resources>();
    protected void Page_Load(object sender, EventArgs e)
    {
        PermissionHelpers permission = new PermissionHelpers();
        resources = permission.Permission(true);
        resourcesJson = JsonHelper.GetJSON<List<TB_Admin_Resources>>(resources);
    }
}