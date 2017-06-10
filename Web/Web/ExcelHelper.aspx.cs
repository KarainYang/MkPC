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

using YK.Model;
using YK.Service;

public partial class ExcelHelp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int index = 1;
        IEnumerable enumerable = AdminService.UserService.Search().Select(u => new
        {
            id = index++,
            name = u.UserName,
            pwd = u.UserPwd,
            date = u.AddDate
        }).ToList();

        var templateFileName = Server.MapPath("~/template.xls");
        var excelHelper = new ExcelHelper(3, 0, templateFileName);

        var workbook = excelHelper.CreateExcel(enumerable);
        var ms = new MemoryStream();
        workbook.Write(ms);

        Response.Charset = "UTF-8";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
        Response.ContentType = "application/vnd.ms-excel";

        string fileName = "会员信息列表.xls";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode(fileName));
        Response.BinaryWrite(ms.GetBuffer());
        Response.Flush();
        Response.End();
    }
}
