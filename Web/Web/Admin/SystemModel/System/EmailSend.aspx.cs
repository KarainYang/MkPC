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
using YK.Model;
using YK.Common;

public partial class Admin_WebSet_EmailSend : System.Web.UI.Page
{
    //文件路径
    protected string fileUrl = HttpContext.Current.Server.MapPath("~/App_Data/WebSet/EmailSet.xml");
    protected void Page_Load(object sender, EventArgs e)
    {
             
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        EmailHelper.SendEmail(TbTitle.Text, FckContent.Value, TbEmailAddress.Text, "");

        MessageDiv.InnerHtml = CommonClass.Alert("邮件发送成功", Request.Url.ToStr());
    }
}
