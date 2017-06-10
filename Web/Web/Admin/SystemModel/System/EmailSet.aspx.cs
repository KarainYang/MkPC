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

public partial class Admin_WebSet_EmailSet : System.Web.UI.Page
{
    //文件路径
    protected string fileUrl = HttpContext.Current.Server.MapPath("~/App_Data/WebSet/EmailSet.xml");
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            EmailSet model = MyXmlSerializer<EmailSet>.Get(fileUrl);
            RadioBtnOpenOrClose.SelectedValue = model.openOrcloseWeb.ToString();
            TbEmialName.Text = model.EmailName;
            TbEmailPwd.Text = model.EmailPwd;
            TbSMTPAddress.Text = model.SMTP;
            TbPort.Text = model.Port;
        }          
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        #region
        EmailSet model = new EmailSet();
        model.openOrcloseWeb = RadioBtnOpenOrClose.SelectedValue.ToInt();
        model.EmailName = TbEmialName.Text.TrimEnd();
        model.EmailPwd = TbEmailPwd.Text.TrimEnd();
        model.SMTP = TbSMTPAddress.Text.TrimEnd();
        model.Port = TbPort.Text.TrimEnd();
        MyXmlSerializer<EmailSet>.Set(model, fileUrl);
        MessageDiv.InnerHtml = YK.Common.CommonClass.Alert("数据修改成功！");
        #endregion
    }
}
