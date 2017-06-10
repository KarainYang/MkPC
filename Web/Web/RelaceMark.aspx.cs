using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.IO;

public partial class RelaceMark : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnGet_Click(object sender, EventArgs e)
    {
        string result = GetPageCode(txtUrl.Text, "gb2312");

        YK.Common.RelaceMarkHelper replace = new YK.Common.RelaceMarkHelper();
        var list = replace.GetMarks("img", result);
        foreach (var str in list)
        {
            ShowInfo.InnerHtml += "<img src=\"" + replace.GetPropertyVal("img", str, "src") + "\"/><br/>";
        }
    }

    public void GetHtml()
    {
        string strurl = txtUrl.Text.ToString(); //欲获取的网页地址 要  http://
        WebClient myWebClient = new WebClient(); //创建WebClient实例myWebClient

        //获取或设置用于对向 Internet 资源的请求进行身份验证的网络凭据。
        myWebClient.Credentials = CredentialCache.DefaultCredentials;

        //从资源下载数据并返回字节数组。（加@是因为网址中间有"/"符号）
        byte[] pagedata = myWebClient.DownloadData(@strurl);
        string result = Encoding.Default.GetString(pagedata); //如果获取网站页面采用的是GB2312，则使用这句 
        //string result = Encoding.UTF8.GetString(pagedata); //如果获取网站页面采用的是UTF-8，则使用这句 

        YK.Common.RelaceMarkHelper replace = new YK.Common.RelaceMarkHelper();
        var list = replace.GetMarks("img", result);
        foreach (var str in list)
        {
            ShowInfo.InnerHtml += "<img src=\"" + replace.GetPropertyVal("img", str, "src") + "\"/><br/>";
        }
    }

    //获取指定页面的源代码
    public String GetPageCode(String PageURL, String Charset)
    {
        try
        {
            //存放目标网页的html
            String strHtml = "";
            //连接到目标网页
            HttpWebRequest wreq = (HttpWebRequest)WebRequest.Create(PageURL);

            //wreq.Headers.Add("VIA", "gotest");
            //wreq.Headers.Add(HttpRequestHeader.UserAgent, "ddd");

            // wreq.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/4.0 (compatible; MSIE 6.0; " + "Windows NT 5.2; .NET CLR {0}");
            //wreq.Headers.Add(HttpResponseHeader.Upgrade, "MozillaTTTT");
            //wreq.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla");


            //wreq.Headers.Add("User-Agent", "winnnnnnnnnnnnn");
            //wreq.Headers.Add("X_FORWARDED_FOR", "10.0.0.1"); //发送X_FORWARDED_FOR头(若是用取源IP的方式，可以用这个来造假IP,对日志的记录无效)   
            //wreq.Headers.Add(HttpRequestHeader.UserAgent, "MIME类型");
            //wreq.Headers.Add("HTTP_USER_AGENT","111");

            //wreq.Timeout = 30000; //设置连接超时时间                

            //wreq.Headers.Set("Pragma", "no-cache");  //不要缓存

            //wreq.Headers.Set(HttpRequestHeader.UserAgent, @"Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; Alexa Toolbar)");

            //wreq.UserAgent = "From lvwp Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; Alexa Toolbar)";
            //wreq.Headers.Add("Translate: f");
            //wreq.Headers.Set("HTTP_REFERER","www.tvsou.com");
            //wreq.Headers.Add("HTTP_REFERER", "www.tvsou.com");
            wreq.Referer = "http://tjtv.enorth.com.cn/jmsj/ws.htm"; //设置HTTP_REFERER
            wreq.Headers.Add("X_FORWARDED_FOR", "101.0.0.11"); //发送X_FORWARDED_FOR头(若是用取源IP的方式，可以用这个来造假IP,对日志的记录无效)  

            wreq.Method = "Get";
            wreq.KeepAlive = true;
            wreq.ContentType = "application/x-www-form-urlencoded";
            wreq.AllowAutoRedirect = true;
            wreq.Accept = "image/gif,   image/x-xbitmap,   image/jpeg,   image/pjpeg,   application/x-shockwave-flash,   application/vnd.ms-excel,   application/vnd.ms-powerpoint,   application/msword,   */*";
            wreq.UserAgent = "Mozilla/4.0   (compatible;   MSIE   6.0;   Windows   NT   5.1;   SV1;   .NET   CLR   1.1.4322)";

            CookieContainer cookieCon = new CookieContainer();
            wreq.CookieContainer = cookieCon;

            HttpWebResponse wresp = (HttpWebResponse)wreq.GetResponse();



            //9tvtest

            //采用流读取，并确定编码方式
            Stream s = wresp.GetResponseStream();
            StreamReader objReader = new StreamReader(s, System.Text.Encoding.GetEncoding(Charset));

            string strLine = "";
            //读取
            while (strLine != null)
            {
                strLine = objReader.ReadLine();
                if (strLine != null)
                {
                    strHtml += strLine.Trim();
                }
            }
            strHtml = strHtml.Replace("<br />", "\r\n");

            return strHtml;
        }
        catch (Exception n)	//遇到错误，打印错误
        {
            return n.Message;
        }
    }
}