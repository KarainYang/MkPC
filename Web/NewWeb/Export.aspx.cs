using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YK.Common;

public partial class Export : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ExportExcel();
        ExportZip();
    }
    public void ExportExcel()
    {
        PerformanceHelper ph = new PerformanceHelper();
        ph.Start("取数时间");
        var list = YK.Service.AdminService.LogService.Search();
        ph.Stop();
        ph.Start("导出时间");
        var teamplatePath = Server.MapPath("~/老客户列表.xlsx");
        var savePath1 = Server.MapPath("~/products1.xlsx");
        var savePath2 = Server.MapPath("~/products2.xlsx");
        var savePath3 = Server.MapPath("~/products3.xlsx");
        var savePath4 = Server.MapPath("~/products4.xlsx");
        var savePath5 = Server.MapPath("~/products5.xlsx");
        var savePath6 = Server.MapPath("~/products6.xlsx");

        YK.Common.Excel.ExcelHelper helper = new YK.Common.Excel.ExcelHelper();
        helper.DataRowStart = 2;
        helper.DataColumnStart = 0;

        helper.Export(list.Skip(20000 * 0).Take(20000), teamplatePath, savePath1);
        helper.Export(list.Skip(20000 * 1).Take(20000), teamplatePath, savePath2);
        helper.Export(list.Skip(20000 * 2).Take(20000), teamplatePath, savePath3);
        helper.Export(list.Skip(20000 * 3).Take(20000), teamplatePath, savePath4);
        helper.Export(list.Skip(20000 * 4).Take(20000), teamplatePath, savePath5);
        helper.Export(list.Skip(20000 * 5).Take(20000), teamplatePath, savePath6);

        ph.Stop();
    }
    public void ExportZip()
    {
        string[] fileNames = new string[]{
            Server.MapPath("~/products1.xlsx"),
            Server.MapPath("~/products2.xlsx"),
            Server.MapPath("~/products3.xlsx"),
            Server.MapPath("~/products4.xlsx"),
            Server.MapPath("~/products5.xlsx"),
            Server.MapPath("~/products6.xlsx")
        };
        string zipPath = Server.MapPath("~/MyZip.zip");
        ZipAgent zipAgent = new ZipAgent();
        zipAgent.funcZipFiles(fileNames, zipPath, 8);

        Response.Redirect("MyZip.zip");

        //FileStream fst = new FileStream(zipPath, FileMode.Open, FileAccess.Read);
        //byte[] byt = new byte[100000000];
        //fst.Read(byt, 0, 100000000);
        //fst.Close();
        //fst.Dispose();

        //Response.Charset = "UTF-8";
        //Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
        //Response.ContentType = "application/vnd.ms-excel";

        //Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode("MyZip.zip"));
        //Response.BinaryWrite(byt);
        //Response.Flush();
        //Response.End();
    }


    #region 多线程
    protected List<YK.Model.TB_Admin_Log> list ;
    protected void Page_Load2(object sender, EventArgs e)
    {
        list = YK.Service.AdminService.LogService.Search();

        PerformanceHelper ph = new PerformanceHelper();
        ph.Start("取数时间");
        Thread t1 = new Thread(new ParameterizedThreadStart(ExportExcel));
        Thread t2 = new Thread(new ParameterizedThreadStart(ExportExcel));
        Thread t3 = new Thread(new ParameterizedThreadStart(ExportExcel));
        Thread t4 = new Thread(new ParameterizedThreadStart(ExportExcel));
        Thread t5 = new Thread(new ParameterizedThreadStart(ExportExcel));
        Thread t6 = new Thread(new ParameterizedThreadStart(ExportExcel));
        t1.Start(1);
        t2.Start(2);
        t3.Start(3);
        t4.Start(4);
        t5.Start(5);
        t6.Start(6);
        ph.Stop();

        Thread.Sleep(60000);
        ExportZip();
    }
    public void ExportExcel(object obj)
    {
        int i = Convert.ToInt32(obj);
        var teamplatePath = Server.MapPath("~/老客户列表.xlsx");
        var savePath = Server.MapPath("~/products" + i + ".xlsx");

        YK.Common.Excel.ExcelHelper helper = new YK.Common.Excel.ExcelHelper();
        helper.DataRowStart = 2;
        helper.DataColumnStart = 0;
        helper.Export(list.Skip(20000 * (i - 1)).Take(20000), teamplatePath, savePath);
    }
    #endregion
}