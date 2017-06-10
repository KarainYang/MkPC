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

public partial class Admin_WebSet_WebSet : System.Web.UI.Page
{
    //文件路径
    protected string fileUrl = HttpContext.Current.Server.MapPath("~/App_Data/WebSet/WebSet.xml");
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        { 
            WebSet model = MyXmlSerializer<WebSet>.Get(fileUrl);
            RadioBtnOpenOrClose.SelectedValue = model.openOrcloseWeb.ToString();
            TbWebSite.Text = model.Website;
            TbWebName.Text = model.WebName;
            TbMail.Text = model.Email;
            TbAddress.Text = model.Address;
            TbZipCode.Text = model.ZipCode;
            TbPhone.Text = model.Phone;
            TbCopyright.Text = model.Copyright;
            RadioBtnDuplicateWebpage.SelectedValue = model.DuplicateWebpage;
            TbIcp.Text = model.ICP;
            TbKeyWord.Text = model.KeyWord;
            TbDescirption.Text = model.Description;
            TbFax.Text = model.Fax;
            TbTQ.Text = model.TQ;

            RadioWaterMarkType.SelectedValue = model.WaterMarkType.ToStr();
            TbWaterMarkTxt.Text = model.WaterMarkTxt;
            WaterMarkPic.Url = model.WaterMarkPicUrl;
            RadioHorizontal.SelectedValue = model.WaterMarkHorizontal;
            RadioVertical.SelectedValue = model.WaterMarkVertical;
        }          
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        #region
        WebSet model = new WebSet();
        model.openOrcloseWeb = RadioBtnOpenOrClose.SelectedValue.ToInt();
        model.Website = TbWebSite.Text;
        model.WebName = TbWebName.Text;
        model.Email = TbMail.Text;
        model.Address = TbAddress.Text;
        model.ZipCode = TbZipCode.Text;
        model.Phone = TbPhone.Text;
        model.Copyright = TbCopyright.Text;
        model.DuplicateWebpage = RadioBtnDuplicateWebpage.SelectedValue;
        model.ICP = TbIcp.Text;
        model.KeyWord = TbKeyWord.Text;
        model.Description = TbDescirption.Text;
        model.Fax = TbFax.Text;
        model.TQ = TbTQ.Text;

        model.WaterMarkType = RadioWaterMarkType.SelectedValue.ToInt();
        model.WaterMarkTxt = TbWaterMarkTxt.Text;
        model.WaterMarkPicUrl = WaterMarkPic.Url;
        model.WaterMarkHorizontal = RadioHorizontal.SelectedValue;
        model.WaterMarkVertical = RadioVertical.SelectedValue;

        MyXmlSerializer<WebSet>.Set(model,fileUrl);
        MessageDiv.InnerHtml = YK.Common.CommonClass.Alert("数据修改成功！");
        #endregion
    }
}
