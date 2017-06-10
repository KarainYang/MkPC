using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Text;

namespace YK.Common
{
    /// <summary>
    ///翼风短信接口 的摘要说明
    /// </summary>
    public class MSMSend
    {
        private static string url = "http://n.020sms.com/MSMSEND.ewing";//发送的地址
        private static string code = "zengkunqiang";//企业代码
        private static string userName = "zengkunqiang";//用户名
        private static string userPwd = "123456";//密码
        private static string para = "";//参数

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="mobileList">手机号列表，以“,”号隔开</param>
        /// <param name="sendContent">发送内容</param>
        /// <returns></returns>
        public static bool Send(string mobileList, string sendContent)
        {
            para = "ECODE=" + code + "&USERNAME=" + userName
            + "&PASSWORD=" + userPwd + "&MOBILE=" + mobileList + "&CONTENT=" + sendContent;

            byte[] postBytes = Encoding.GetEncoding("utf-8").GetBytes(para);

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = postBytes.Length;

            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(postBytes, 0, postBytes.Length);
            }
            bool b = false;
            using (WebResponse wr = req.GetResponse())
            {
                //在这里对接收到的页面内容进行处理   
                StreamReader sr = new StreamReader(wr.GetResponseStream());
                string data = sr.ReadToEnd().Trim();
                b = data == "1";
            }
            return b;
        }

        public static void SendMsg1(string mobileList, string sendContent)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<form id='sub' method='post' action='" + url + "'>");
            sb.Append("<input type='hidden' value='" + code + "' name='ECODE'/>");//企业代码
            sb.Append("<input type='hidden' value='" + userName + "' name='USERNAME'/>");//用户名
            sb.Append("<input type='hidden' value='" + userPwd + "' name='PASSWORD'/>");//密码
            sb.Append("<input type='hidden' value='' name='EXTNO'/>");//
            sb.Append("<input type='hidden' value='" + mobileList + "' name='MOBILE'/>");
            sb.Append("<input type='hidden' value='" + sendContent + "' name='CONTENT'/>");//发送的信息
            sb.Append("<input type='hidden' value='1234567' name='SEQ'/>");
            sb.Append("<input type='hidden' value='' name='SENDTIME'/>");
            sb.Append("</form>");
            sb.Append("<script>");
            sb.Append("sub.submit();");
            sb.Append("</script>");
            HttpContext.Current.Response.Write(sb.ToString());
        }
    }
}
