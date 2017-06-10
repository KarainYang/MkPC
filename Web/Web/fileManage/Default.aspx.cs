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
using System.IO;

public partial class fileManage_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadDataBind();
        }       
    }

    //初始化加载
    public void LoadDataBind()
    {
        //获取电脑上的磁盘
        //DriveInfo[] drive = DriveInfo.GetDrives();
        //foreach (DriveInfo driveInfo in drive)
        //{
        //    //判断是否为固定磁盘
        //    if (driveInfo.DriveType == DriveType.Fixed)
        //    {
        //        DDLDriveInfo.Items.Add(new ListItem(driveInfo.Name, driveInfo.Name));
        //    }
        //}

        //记录查询路径
        ViewState["url"] = Server.MapPath("~/Userfiles/");//DDLDriveInfo.SelectedItem.Text;

        //绑定文件夹
        GetDirectorys();

        //绑定文件
        GetFiles();
       
    }

    //获取文件夹
    public void GetDirectorys()
    {
        //创建表
        DataTable dt = new DataTable("Info");

        //添加列
        DataColumn columns = new DataColumn();
        columns.ColumnName = "FileUrl";
        dt.Columns.Add(columns);

        string[] directory = Directory.GetDirectories(ViewState["url"].ToString());
        //遍历文件夹
        foreach (string str in directory)
        {
            //添加行
            DataRow dr = dt.NewRow();
            dr[0] = str;
            dt.Rows.Add(dr);
        }

        // 绑定
        RepDirectory.DataSource = dt;
        RepDirectory.DataBind();

        //添加事件
        foreach (RepeaterItem rep in RepDirectory.Items)
        {
            LinkButton linkbtn = (LinkButton)rep.FindControl("LinkBtnDelete");
            linkbtn.Attributes.Add("onclick", "return confirm('请谨慎删除文件，确认删除该文件夹吗？')");
        }
    }

    //获取文件
    public void GetFiles()
    {
        //创建表
        DataTable dt = new DataTable("Info");

        //添加列
        DataColumn columns = new DataColumn();
        columns.ColumnName = "FileUrl";
        dt.Columns.Add(columns);

        DirectoryInfo dire = new DirectoryInfo(ViewState["url"].ToString());
        FileInfo[] files = dire.GetFiles();
        foreach (FileInfo f in files)
        {
            //添加行
            DataRow dr = dt.NewRow();
            dr[0] = f.FullName;
            dt.Rows.Add(dr);
        }

        // 绑定
        RepFiles.DataSource = dt;
        RepFiles.DataBind();

        //添加事件
        foreach (RepeaterItem rep in RepFiles.Items)
        {
            LinkButton linkbtn = (LinkButton)rep.FindControl("LinkBtnDelete");
            linkbtn.Attributes.Add("onclick", "return confirm('请谨慎删除文件，确认删除该文件夹吗？')");
        }
    }

    //文件夹操作
    protected void RepFiles_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //删除文件
        if (e.CommandName == "delete")
        {
            //绑定子文件夹
            File.Delete(e.CommandArgument.ToString());
        }

        //绑定文件夹
        GetDirectorys();

        //绑定文件
        GetFiles();

    }    

    //文件操作
    protected void RepDirectory_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //查询文件及文件夹
        if(e.CommandName=="select")
        {
            ViewState["url"] = e.CommandArgument.ToString();

            //绑定子文件夹
            GetDirectorys();

            //绑定子文件
            GetFiles();
        }

        //删除文件夹
        if (e.CommandName == "delete")
        {
            //绑定子文件夹
            Directory.Delete(e.CommandArgument.ToString());
        }

        //绑定文件夹
        GetDirectorys();

        //绑定文件
        GetFiles();
    }

    ////获取磁盘文件信息
    //protected void BtnSelect_Click(object sender, EventArgs e)
    //{
    //    ViewState["url"] = DDLDriveInfo.SelectedValue;

    //    //绑定子文件夹
    //    GetDirectorys();
    //    GetFiles();
    //}
}
