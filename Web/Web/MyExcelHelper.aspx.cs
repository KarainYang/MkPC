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
using YK.Common;

public partial class MyExcelHelper : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string path = Server.MapPath("~/Userfiles/Excel/User.xls");
        FileUpload1.SaveAs(path);
        ExcelHelper import=new ExcelHelper();
        import.DataRowStart = 1;
        var list = import.GetEntityList<TB_User>(path);
        var i = 0;
    }

    public class TB_User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public DateTime CreateDate { get; set; }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        var list= YK.Service.AdminService.LogService.Search(10);
        YK.Common.ExcelHelper.OutputExcel<YK.Model.TB_Admin_Log>(list, new string[] { "编号", "类型" },
            new string[] {"ID","Type" }, this.Page);
    }
}
