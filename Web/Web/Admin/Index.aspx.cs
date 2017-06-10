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
using YK.Common;
using YK.Model;

public partial class Admin_Index : BasePage
{
    protected string menu = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        PermissionHelpers permission = new PermissionHelpers();
        List<TB_Admin_Resources> list = permission.Permission(true);
        
        foreach(TB_Admin_Resources entity in list)
        {
            menu += "{ 'id': '" + entity.ID + "', 'name': '" + entity.ResourceName + "', 'url': '" + entity.Url + "', 'IcoClass': 'ico_database', 'open': true,";
            if (entity.ChildTree.Count > 0)
            {
                menu += "'ChildItem': [";
                foreach (TB_Admin_Resources entity2 in entity.ChildTree)
                {
                    menu += "{ 'id': '" + entity2.ID + "', 'name': '" + entity2.ResourceName + "', 'url': '" + entity2.Url + "','IcoClass': 'ico_tabel', 'ChildItem': null },";
                }

                menu = menu.TrimEnd(',');
                menu += "]},";
            }
            else
            {
                menu += "'ChildItem':null },";
            }
        }

        menu = menu.TrimEnd(',');
    }
}
