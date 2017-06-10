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
using System.IO;

public partial class Zip : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Excel();
    }

    //导出
    public void Excel()
    {

        string[] fileNames = Directory.GetFiles(Server.MapPath("~/App_Data/"));
        string zipPath = Server.MapPath("~/MyZip.zip");
        ZipAgent zipAgent = new ZipAgent();
        zipAgent.funcZipFiles(fileNames, zipPath, 8);

        FileStream fst = new FileStream(zipPath, FileMode.Open, FileAccess.Read);
        byte[] byt = new byte[100000];
        fst.Read(byt, 0, 100000);
        fst.Close();
        fst.Dispose();

        Response.Charset = "UTF-8";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
        Response.ContentType = "application/vnd.ms-excel";

        Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode("MyZip.zip"));
        Response.BinaryWrite(byt);
        Response.Flush();
        Response.End();
    }
}
