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
using YK.Service;

public partial class info_Help : System.Web.UI.Page
{
    protected TB_Info_Help help;

    protected void Page_Load(object sender, EventArgs e)
    {
        int id = YK.Common.CommonClass.ReturnRequestInt("id", 0);
        if (id > 0)
        {
            help = InfoService.HelpService.Get(id);
        }
        else
        {
            List<TB_Info_Help> list = InfoService.HelpService.Search(1);
            help = list.Count > 0 ? list.First() : new TB_Info_Help();
        }
    }    
}
