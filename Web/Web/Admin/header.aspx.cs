using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

using YK.Service;
using YK.Common;
using YK.Model;

public partial class Admin_header2 : BasePage
{
    public List<TB_Admin_Resources> resources = new List<TB_Admin_Resources>();

    protected void Page_Load(object sender, EventArgs e)
    {
        PermissionHelpers permission = new PermissionHelpers();
        resources = permission.Permission(true);
    }
}
