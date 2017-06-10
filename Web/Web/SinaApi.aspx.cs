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

public partial class SinaApi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string username = "871339677@qq.com";
        string password = "871339677";
        string usernamePassword = username + ":" + password;

        string url = "http://api.t.sina.com.cn/statuses/update.json";
        string news_title = "VS2010网剧合集：讲述程序员的爱情故事";
        int news_id = 62747;
        string t_news = string.Format("{0}，http://news.cnblogs.com/n/{1}/", news_title, news_id);
        string data = "source=3854961754&status=" + System.Web.HttpUtility.UrlEncode(t_news);

        System.Net.WebRequest webRequest = System.Net.WebRequest.Create(url);
        System.Net.HttpWebRequest httpRequest = webRequest as System.Net.HttpWebRequest;

        System.Net.CredentialCache myCache = new System.Net.CredentialCache();
        myCache.Add(new Uri(url), "Basic", new System.Net.NetworkCredential(username, password));
        httpRequest.Credentials = myCache;
        httpRequest.Headers.Add("Authorization", "Basic " +
        Convert.ToBase64String(new System.Text.ASCIIEncoding().GetBytes(usernamePassword)));


        httpRequest.Method = "POST";
        httpRequest.ContentType = "application/x-www-form-urlencoded";
        System.Text.Encoding encoding = System.Text.Encoding.ASCII;
        byte[] bytesToPost = encoding.GetBytes(data);
        httpRequest.ContentLength = bytesToPost.Length;
        System.IO.Stream requestStream = httpRequest.GetRequestStream();
        requestStream.Write(bytesToPost, 0, bytesToPost.Length);
        requestStream.Close();

        System.Net.WebResponse wr = httpRequest.GetResponse();
        System.IO.Stream receiveStream = wr.GetResponseStream();
        using (System.IO.StreamReader reader = new System.IO.StreamReader(receiveStream, System.Text.Encoding.UTF8))
        {
            string responseContent = reader.ReadToEnd();
            Response.Write(responseContent);
        }
        
    }
}
