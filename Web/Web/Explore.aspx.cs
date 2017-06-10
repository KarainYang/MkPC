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

public partial class Explore : System.Web.UI.Page
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
        DriveInfo[] drive = DriveInfo.GetDrives();
        foreach (DriveInfo driveInfo in drive)
        {
            //判断是否为固定磁盘
            if (driveInfo.DriveType == DriveType.Fixed)
            {
                DDLDriveInfo.Items.Add(new ListItem(driveInfo.Name, driveInfo.Name));
            }
        }

        //记录查询路径
        ViewState["url"] = DDLDriveInfo.SelectedItem.Text;

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
        columns.ColumnName = "DireName";
        DataColumn columns2 = new DataColumn();
        columns2.ColumnName = "DireUrl";
        dt.Columns.Add(columns);
        dt.Columns.Add(columns2);

        DirectoryInfo directory = new DirectoryInfo(ViewState["url"].ToString());
        //遍历文件夹
        foreach (DirectoryInfo dire in directory.GetDirectories())
        {
            //添加行
            DataRow dr = dt.NewRow();
            dr[0] = dire.Name;
            dr[1] = dire.FullName;
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
        columns.ColumnName = "FileName";
        DataColumn columns2 = new DataColumn();
        columns2.ColumnName = "FileUrl";
        DataColumn columns3 = new DataColumn();
        columns3.ColumnName = "Suffix";
        dt.Columns.Add(columns);
        dt.Columns.Add(columns2);
        dt.Columns.Add(columns3);

        DirectoryInfo dire = new DirectoryInfo(ViewState["url"].ToString());
        FileInfo[] files = dire.GetFiles();
        foreach (FileInfo f in files)
        {            
            //添加行
            DataRow dr = dt.NewRow();
            dr[0] = f.Name;
            dr[1] = f.FullName;
            dr[2] = f.Name.Split('.')[f.Name.Split('.').Length - 1];
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

        //修改文件
        if (e.CommandName == "update")
        {
            string path = ViewState["url"].ToString();
            string NewName = ((TextBox)e.Item.FindControl("TbNewName")).Text;
            string oldPath = path + "/" + e.CommandArgument;//旧名称
            string[] str=e.CommandArgument.ToString().Split('.');
            string suff = str[str.Length-1];//后缀
            string newPath = path + "/" + NewName+"."+suff;//新名称
            File.Move(oldPath, newPath);
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
            Directory.Delete(e.CommandArgument.ToString(),true);
        }

        //修改文件夹
        if (e.CommandName == "update")
        {
            string path= ViewState["url"].ToString();
            string NewName=((TextBox)e.Item.FindControl("TbNewName")).Text;
            string oldPath = path + "/"+e.CommandArgument;//旧目录
            string newPath = path + "/" + NewName;//新目录
            Directory.Move(oldPath,newPath);
        }       

        //绑定文件夹
        GetDirectorys();

        //绑定文件
        GetFiles();
    }

    //获取磁盘文件信息
    protected void BtnSelect_Click(object sender, EventArgs e)
    {
        ViewState["url"] = DDLDriveInfo.SelectedValue;

        //绑定子文件夹
        GetDirectorys();
        GetFiles();
    }

    protected void BtnCreate_Click(object sender, EventArgs e)
    {
        if (TbNewDirec.Text!="")
        {
            string direc = TbNewDirec.Text;
            if (!Directory.Exists(ViewState["url"] + "/" + direc))
            {
                Directory.CreateDirectory(ViewState["url"]+"/"+direc);
            }
        }

        if (TbNewFile.Text != "")
        {
            string file = TbNewFile.Text;
            if (!File.Exists(ViewState["url"] + "/" + file))
            {
               FileStream fs= File.Create(ViewState["url"] + "/" + file);
               fs.Close();
            }
        }

        //绑定子文件夹
        GetDirectorys();
        GetFiles();
    }
}
