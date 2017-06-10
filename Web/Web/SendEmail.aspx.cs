using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Web.Mail;
using System.Text.RegularExpressions;

public partial class SendEmail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("MD5 - my name is yankun --> : " + GetMD5("my name is yankun")+"<br/>");

        string url = "<a href=\"http://www.baidu.com\">百度</a>";
        MatchCollection mcR2 = Regex.Matches(url, "(?<=a.+?href=\").+?(?=\")", RegexOptions.IgnoreCase);
        Match mR2 = mcR2[0];
        string str= mR2.Value;

        string reg = @"<a[^>]*href=(""(?<href>[^""]*)""|'(?<href>[^']*)'|(?<href>[^\s>]*))[^>]*>(?<text>[\s\S]*?)</a>";
        MatchCollection mc1 = Regex.Matches(url,reg,RegexOptions.IgnoreCase | RegexOptions.Compiled);
        string href = mc1[0].Groups["href"].Value;// 这里取到了#
        string text = mc1[0].Groups["text"].Value;// 这是text内容,就是<a>这里的内容</a>

        Response.Write(str + "<br/>");
        Response.Write(href + "<br/>");
        Response.Write(text + "<br/>");
    }

    /// <summary>
    /// MD5加密
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public string GetMD5(string str)
    {
        System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] byt, bytHash;
        byt = System.Text.Encoding.UTF8.GetBytes(str);
        bytHash = md5.ComputeHash(byt);
        md5.Clear();
        string sTemp = "";
        for (int i = 0; i < bytHash.Length; i++)
        {
            sTemp += bytHash[i].ToString("x").PadLeft(2, '0');
        }
        return sTemp;
    }   

    /// <summary>
    /// 126邮件发送
    /// </summary>
    /// <param name="EmailList">邮件列表</param>
    /// <param name="title">标题</param>
    /// <param name="sendContent">发送内容</param>
    public void MailSend(string EmailList, string title, string sendContent)
    {
        //try
        //{
            MailMessage objMailMessage = new MailMessage();
            MailAttachment objMailAttachment;
            // 创建一个附件对象 
           // objMailAttachment = new MailAttachment("");//发送邮件的附件 --"d:\\test.txt"
            // 创建邮件消息 
            objMailMessage.From = TbUserName.Text.Trim();// "yankun19871116@126.com";//源邮件地址 
            objMailMessage.To = "";//目的邮件地址，也就是发给我哈 
            objMailMessage.Subject = title;//发送邮件的标题 
            objMailMessage.Body = sendContent;//发送邮件的内容 
            objMailMessage.BodyFormat = MailFormat.Html;
            //objMailMessage.Attachments.Add(objMailAttachment);//将附件附加到邮件消息对象中 
            //接着利用sina的SMTP来发送邮件，需要使用Microsoft .NET Framework SDK v1.1和它以上的版本 
            //基本权限 
            objMailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
            //用户名 
            objMailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", TbUserName.Text.Trim());
            //密码 
            objMailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", TbPwd.Text.Trim());
            //如果没有上述三行代码，则出现如下错误提示：服务器拒绝了一个或多个收件人地址。服务器响应为: 554 : Client host rejected: Access denied 
            //SMTP地址 
            SmtpMail.SmtpServer =DDLType.SelectedValue;
            //开始发送邮件 
            string[] str = EmailList.Split(new char[] { ',' });
            foreach (string s in str)
            {
                //目的邮箱
                objMailMessage.To = s;
                //开始发送邮件 
                SmtpMail.Send(objMailMessage);
            }
        //}
        //catch (Exception ex)
        //{

        //}

    }
    protected void BtnSend_Click(object sender, EventArgs e)
    {
        MailSend(TbAddress.Text.Trim(),TbTitle.Text,FCKeditor1.Value.Trim());
    }
}