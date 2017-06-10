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
using YK.Model;
using YK.Interface;
using YK.Service;
using YK.Common;
using YK.Model.CRM;

public partial class Admin_SystemModel_Project_TaskDetails : BasePage
{
    protected TB_Project_Task model = new TB_Project_Task();

    protected void Page_Load(object sender, EventArgs e)
    {
        int ID = CommonClass.ReturnRequestInt("id", 0);
        model = ProjectService.TaskService.Get(ID);
    } 
}
