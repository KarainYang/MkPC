using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;
using System.Text;
using System.IO;
using YK.Model;
using YK.Service;

public partial class GenerateHtml : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void BtnGenerate_Click(object sender, EventArgs e)
    {
        if(TbSourcePath.Text.Trim()!="" && TbGeneratePath.Text.Trim() !="")
        {
            string generatePath=Server.MapPath("~/"+TbGeneratePath.Text.Trim());
            string content= GetPathContent(TbSourcePath.Text.Trim());

            FileStream fs = File.Create(generatePath);
            fs.Close();
            fs.Dispose();

            StreamWriter sw = new StreamWriter(generatePath);
            sw.Write(content);
            sw.Close();
            sw.Dispose();
        }
    }


    protected void BtnConfigGenerate_Click(object sender, EventArgs e)
    {
        string path = Server.MapPath("~/App_Data/HtmlConfig.xml");
        DataSet ds = new DataSet();
        ds.ReadXml(path);
        foreach(DataRow dr in ds.Tables[0].Rows)
        {
            string generatePath=Server.MapPath("~/"+dr["generatePath"].ToString());
            string sourcePath = dr["sourcePath"].ToString();

            string content = GetPathContent(sourcePath);

            FileStream fs = File.Create(generatePath);
            fs.Close();
            fs.Dispose();

            StreamWriter sw = new StreamWriter(generatePath);
            sw.Write(content);
            sw.Close();
            sw.Dispose();
        }
    }

    /// <summary>
    /// 获取指定地址的内容
    /// </summary>
    /// <param name="url"></param>
    protected string GetPathContent(string url)
    {
        url = YK.Common.CommonClass.SiteUrl + url;

        WebClient myWebClient = new WebClient(); //创建WebClient实例myWebClient

        //获取或设置用于对向 Internet 资源的请求进行身份验证的网络凭据。
        myWebClient.Credentials = CredentialCache.DefaultCredentials;

        //从资源下载数据并返回字节数组。（加@是因为网址中间有"/"符号）
        byte[] pagedata = myWebClient.DownloadData(@url);
        return Encoding.Default.GetString(pagedata); //如果获取网站页面采用的是GB2312，则使用这句 
        //return Encoding.UTF8.GetString(pagedata); //如果获取网站页面采用的是UTF-8，则使用这句 
    }

    protected void BtnProDetailsGenerate_Click(object sender, EventArgs e)
    {
        List<TB_Product_Products> list = ProductService.ProductsService.Search();
        foreach (TB_Product_Products entity in list)
        {
            string generatePath = Server.MapPath("~/product/product_" + entity.ID + ".html");
            string sourcePath = "product/product2.aspx?id=" + entity.ID;

            string content = GetPathContent(sourcePath);

            FileStream fs = File.Create(generatePath);
            fs.Close();
            fs.Dispose();

            StreamWriter sw = new StreamWriter(generatePath);
            sw.Write(content);
            sw.Close();
            sw.Dispose();
        }
    }
}