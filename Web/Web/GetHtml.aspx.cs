using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;//因为用了Encoding类
using System.Net; //因为用了WebClient 类
using System.Text.RegularExpressions;
using System.IO;
using System.Data;

public partial class GetHtml : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strurl = "http://www.ymserve.com"; //欲获取的网页地址 要  http://
        WebClient myWebClient = new WebClient(); //创建WebClient实例myWebClient

        //获取或设置用于对向 Internet 资源的请求进行身份验证的网络凭据。
        myWebClient.Credentials = CredentialCache.DefaultCredentials;

        //从资源下载数据并返回字节数组。（加@是因为网址中间有"/"符号）
        byte[] pagedata = myWebClient.DownloadData(@strurl);
        //string result = Encoding.Default.GetString(pagedata); //如果获取网站页面采用的是GB2312，则使用这句 
        string result = Encoding.UTF8.GetString(pagedata); //如果获取网站页面采用的是UTF-8，则使用这句 
        TbTxt.Text=result; //在WEB页中显示获取的内容

        string html = "<a>hello world..........</a>";
        Regex reg = new Regex(@"<div\s*[^>]*>([\s\S]+?)</div>", RegexOptions.IgnoreCase);

        //Match m = reg.Match(result);
        //while (m.Success)
        //{
        //    string innerHTML = m.Result("$1");
        //    // 得到正则的括号里的内容，就是a的innerHTML
        //    innerHTML = Regex.Replace(innerHTML, @"<[^>]*>", "", RegexOptions.IgnoreCase);
        //    // 替换掉里面的html，只保留文字 
        //    m = m.NextMatch();// 循环匹配html里的下一个结果

        //    TbRegex.Text += innerHTML;
        //}

        int i = 0;
        MatchCollection matchColl = reg.Matches(result);
        foreach(Match enity in matchColl)
        {
            //6为抓取菜单部分，
            //4顶部，右边的部分（交易记录查询 |  卡挂失 |  在线充值 |  余额查询 |  卡密码修改 ）
            //3帮助中心
            //2公会专区
            //1
            if (i == matchColl.Count-2)
            {
                TbRegex.Text = enity.Value;
            }
            i++;
        }
    }


/// <summary>
    /// 获取属性值列表
    /// </summary>
    /// <param name="text">查找的文本</param>
    /// <param name="propertyName">属性名称</param>
    /// <returns></returns>
    protected List<string> GetPropertyVal(string text, string propertyName)
    {
        Regex reg = new Regex((@"(?is)<yk:content[^>]*?$=(['""\s]?)(?<$>[^'""\s]*)\1[^>]*?>").Replace("$", propertyName));
        MatchCollection match = reg.Matches(text);
        List<string> list = new List<string>();
        foreach (Match m in match)
        { 
            list.Add(m.Groups[propertyName].Value);           
        }
        return list;
    }
    /// <summary>
    /// 获取指定的标签列表
    /// </summary>
    /// <param name="text">查找的文本</param>
    /// <returns></returns>
    public List<string> GetMark(string text)
    {        
        Regex reg = new Regex(@"\<yk:content[^>]*?>([\w\W]+?)\/>");
        MatchCollection match = reg.Matches(text);
        List<string> list = new List<string>();
        foreach (Match m in match)
        {
            list.Add(m.Groups[0].Value);
        }
        return list;
    }
}


