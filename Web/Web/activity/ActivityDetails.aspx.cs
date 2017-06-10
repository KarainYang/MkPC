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

public partial class Activity_ActivityDetails : System.Web.UI.Page
{
    public TB_Activity_Activity entity;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int id = CommonClass.ReturnRequestInt("id",0);
            entity = ActivityService.ActivitysService.Get(id);
        }
    }
}
