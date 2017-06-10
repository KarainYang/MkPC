using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net;
using System.Web.Mail;
using YK.Model;
using YK.Common;

/// <summary>
///EmailSend 的摘要说明
/// </summary>
public class EmailSend
{
    public EmailSend()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //


         //邮箱  POP3 服务器（端口110） SMTP 服务器（端口25） 
         // 188.com  pop3.188.com smtp.188.com 
         // 163.com  pop3.163.com smtp.163.com 
         // 126.com pop3.126.com smtp.126.com 
         // netease.com pop.netease.com smtp.netease.com 
         // yeah.net pop.yeah.net smtp.yeah.net 

    }

    /// <summary>
    /// 126邮件发送
    /// </summary>
    /// <param name="EmailList">邮件列表，以分号“;”隔开</param>
    /// <param name="title">标题</param>
    /// <param name="sendContent">发送内容</param>
    public static void MailSend(string EmailList,string title,string sendContent)
    {
        string fileUrl = HttpContext.Current.Server.MapPath("~/App_Data/WebSet/EmailSet.xml");
        EmailSet es = MyXmlSerializer<EmailSet>.Get(fileUrl);        
        try
        {
            MailMessage objMailMessage= new MailMessage();
            // 创建邮件消息 
            objMailMessage.From = es.EmailName;//源邮件地址 
            objMailMessage.To = EmailList;//目的邮件地址，也就是发给我哈 
            objMailMessage.Subject = title;//发送邮件的标题 
            objMailMessage.Body = sendContent;//发送邮件的内容 
            objMailMessage.BodyFormat = MailFormat.Html;

            // 创建一个附件对象 
            //MailAttachment objMailAttachmentobjMailAttachment = new MailAttachment("");//发送邮件的附件 --"d:\\test.txt"
            //objMailMessage.Attachments.Add(objMailAttachment);//将附件附加到邮件消息对象中 

            //接着利用sina的SMTP来发送邮件，需要使用Microsoft .NET Framework SDK v1.1和它以上的版本 
            //基本权限 
            objMailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
            //用户名 
            objMailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", es.EmailName);
            //密码 
            objMailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", es.EmailPwd);
            //如果没有上述三行代码，则出现如下错误提示：服务器拒绝了一个或多个收件人地址。服务器响应为: 554 : Client host rejected: Access denied 
            //SMTP地址 
            SmtpMail.SmtpServer = es.SMTP;
            //开始发送邮件 
            SmtpMail.Send(objMailMessage);
        }
        catch(Exception ex)
        {
            //写入日志
            TxtFileHelper.AppendLogTxt(ex.Message);
        }
    }
}
