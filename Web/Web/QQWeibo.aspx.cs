using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QWeiboSDK;
using System.Net;
using System.IO;
using System.Text;

public partial class QQWeibo : System.Web.UI.Page
{

    private string appKey = "801389219";
    private string appSecret = "0fd52e89d1a280ab8f451ae578bf1073";
    private string accessKey = "";//"d149cae8face4ad4adf5d7cd330cf3f6";
    private string accessSecret = "";//"70b90c4fde5bc5af1c10b5475d9b9206";

    private string tokenKey = null;
    private string tokenSecret = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        //oauth_token=51ee257767c3459883dcdf5168bc0eb0&oauth_verifier=331899
        //&openid=6C305E49E0E03D87502838FB3408AC44&openkey=94289F1550B3F29B8C6574F507385F8E

        if (!IsPostBack)
        {
            if (ViewState["tokenKey"] == null || ViewState["tokenSecret"] == null)
            {
                GetRequestToken(appKey, appSecret);
                ViewState["tokenKey"] = tokenKey;
                ViewState["tokenSecret"] = tokenSecret;
                Response.Write("<script>window.open('http://open.t.qq.com/cgi-bin/authorize?oauth_token=" + tokenKey + "');</script>");
            }
        }
        else
        {
            tokenKey=ViewState["tokenKey"].ToString();
            tokenSecret = ViewState["tokenSecret"].ToString();
        }
    }


    private bool GetRequestToken(string customKey, string customSecret)
    {
        string url = "https://open.t.qq.com/cgi-bin/request_token";
        List<QWeiboSDK.Parameter> parameters = new List<QWeiboSDK.Parameter>();
        OauthKey oauthKey = new OauthKey();
        oauthKey.customKey = customKey;
        oauthKey.customSecret = customSecret;
        oauthKey.callbackUrl = "http://localhost:2067/Web/QQWeiboRollbankUrl.aspx";// "http://shopping.51mke.com/QQWeiboRollbankUrl.aspx";

        QWeiboRequest request = new QWeiboRequest();
        return ParseToken(request.SyncRequest(url, "GET", oauthKey, parameters, null));
    }

    private bool GetAccessToken(string customKey, string customSecret, string requestToken, string requestTokenSecrect, string verify)
    {
        string url = "https://open.t.qq.com/cgi-bin/access_token";
        List<QWeiboSDK.Parameter> parameters = new List<QWeiboSDK.Parameter>();
        OauthKey oauthKey = new OauthKey();
        oauthKey.customKey = customKey;
        oauthKey.customSecret = customSecret;
        oauthKey.tokenKey = requestToken;
        oauthKey.tokenSecret = requestTokenSecrect;
        oauthKey.verify = verify;

        QWeiboRequest request = new QWeiboRequest();
        return ParseToken(request.SyncRequest(url, "GET", oauthKey, parameters, null));
    }

    protected void BtnSend_Click(object sender, EventArgs e)
    {
        GetAccessToken(appKey, appSecret, tokenKey, tokenSecret, Session["Verify"].ToString());

        accessKey = tokenKey;
        accessSecret = tokenSecret;

        OauthKey oauthKey = new OauthKey();
        oauthKey.customKey = appKey;
        oauthKey.customSecret = appSecret;
        oauthKey.tokenKey = accessKey;
        oauthKey.tokenSecret = accessSecret;

        t twit = new t(oauthKey, "json");

        string ret = twit.add_pic(TbText.Text, "127.0.0.1", "", "", Server.MapPath("~/"+Pic.Url));
        Response.Write(ret);
    }
  
    private bool ParseToken(string response)
    {
        if (string.IsNullOrEmpty(response))
        {
            return false;
        }

        string[] tokenArray = response.Split('&');

        if (tokenArray.Length < 2)
        {
            return false;
        }

        string strTokenKey = tokenArray[0];
        string strTokenSecrect = tokenArray[1];

        string[] token1 = strTokenKey.Split('=');
        if (token1.Length < 2)
        {
            return false;
        }
        tokenKey = token1[1];

        string[] token2 = strTokenSecrect.Split('=');
        if (token2.Length < 2)
        {
            return false;
        }
        tokenSecret = token2[1];

        return true;
    }

    //    授权方式：	oAuth2.0授权 选择其它授权方式
    //获取粉丝
    public void GetMyFenSi()
    {
        string access_token = "cb62cb49b85629f29c2f33d3ce13dc81";
        string s = Session["oauth_token"].ToString();
        string openid = Session["openid"].ToString();
        string openkey = Session["openkey"].ToString();	

        string para="reqnum=20&mode=0&startindex=0&install=0&"
            +"sex=0&format=xml&access_token="+access_token+"&"
            + "oauth_consumer_key=" + appKey + "&openid=" + openid + "&"
            +"oauth_version=2.a&clientip="+Request.UserHostAddress+"&scope=all&appfrom=php-sdk2.0beta&"
            +"seqid=1374547282&serverip=183.60.10.172";

        byte[] postBytes = Encoding.GetEncoding("utf-8").GetBytes(para);

        HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://open.t.qq.com/api/friends/fanslist_name");
        req.Method = "post";
        req.ContentType = "application/x-www-form-urlencoded";
        req.ContentLength = postBytes.Length;

        using (Stream reqStream = req.GetRequestStream())
        {
            reqStream.Write(postBytes, 0, postBytes.Length);
        }
   
        using (WebResponse wr = req.GetResponse())
        {
            //在这里对接收到的页面内容进行处理   
            StreamReader sr = new StreamReader(wr.GetResponseStream());
            string data = sr.ReadToEnd().Trim();
            WeiBo weibo= YK.Common.JsonHelper.ParseFormByJson<WeiBo>(data);
            GridView1.DataSource = weibo.data.info;
            GridView1.DataBind();
        }
    }

    protected void BtnGetFenSi_Click(object sender, EventArgs e)
    {
        GetMyFenSi();
    }

    //获取听众
    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        GetAccessToken(appKey, appSecret, tokenKey, tokenSecret, Session["Verify"].ToString());

        accessKey = tokenKey;
        accessSecret = tokenSecret;

        OauthKey oauthKey = new OauthKey();
        oauthKey.customKey = appKey;
        oauthKey.customSecret = appSecret;
        oauthKey.tokenKey = accessKey;
        oauthKey.tokenSecret = accessSecret;

        friends friends = new friends(oauthKey, "json");
        string data = friends.fanslist(10, 0);

        Audience weibo = YK.Common.JsonHelper.ParseFormByJson<Audience>(data);
        GridView1.DataSource = weibo.data.info;
        GridView1.DataBind();
    }
}

public class WeiBo
{
    public data data { get; set; }
    public int errcode{get;set;}
    public string msg{get;set;}
    public string ret { get; set; }
    public string seqid { get; set; }
}

public class data
{
    public int curnum{get;set;}
    public int hasnext{get;set;}
    public List<info> info { get; set; }
    public int nextstartpos{get;set;}
}

public class info
{
    public string name{get;set;}
    public string openid{get;set;}
    public string releaname { get; set; }
}

//听众
public class Audience
{
    public data2 data { get; set; }
    public int errcode { get; set; }
    public string msg { get; set; }
    public int ret { get; set; }
    public string seqid { get; set; }
}

public class data2
{
    public int curnum { get; set; }
    public int hasnext { get; set; }
    public List<info2> info { get; set; }
    public int nextstartpos { get; set; }
    public string timestamp { get; set; }
}

public class info2
{
    public string city_code { get; set; }
    public string country_code { get; set; }
    public string fansnum { get; set; }
    public string head { get; set; }
    public string https_head { get; set; }
    public string idolnum { get; set; }
    public string isfans { get; set; }
    public string isidol { get; set; }
    public string isrealname { get; set; }
    public string isvip { get; set; }
    public string location { get; set; }
    public string name { get; set; }
    public string nick { get; set; }

    public string openid { get; set; }
    public string province_code { get; set; }
    public string sex { get; set; }

    public List<tag> tag { get; set; }
    public List<tweet> tweet { get; set; }
}

public class tag
{
    public string id{ get;set;}
    public string name{ get;set;}
}

public class tweet
{
    public string from { get; set; }
    public string id { get; set; }
    public string text { get; set; }
    public string timestamp { get; set; }
}