using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace YK.Common
{
    class HttpWebRequestHelper
    {
        /// <summary>
        /// get 数据
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string Get(string url)
        {
            string responseData = null;

            HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = "GET";
            webRequest.ServicePoint.Expect100Continue = false;
            webRequest.Timeout = 20000;

            StreamReader responseReader = null;
            try
            {
                responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                responseData = responseReader.ReadToEnd();
            }
            catch
            {
            }
            finally
            {
                webRequest.GetResponse().GetResponseStream().Close();
                responseReader.Close();
                responseReader = null;
                webRequest = null;
            }
            return responseData;
        }

        /// <summary>
        /// post 数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public string Post(string url, string data)
        {
            byte[] postBytes = Encoding.GetEncoding("utf-8").GetBytes(data);
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = postBytes.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(postBytes, 0, postBytes.Length);
            }
            string bakData = "";
            using (WebResponse wr = req.GetResponse())
            {
                //在这里对接收到的页面内容进行处理   
                StreamReader sr = new StreamReader(wr.GetResponseStream());
                bakData = sr.ReadToEnd().Trim();
            }
            return bakData;
        }

        /// <summary>  
        /// 上传多媒体文件,返回 MediaId  
        /// </summary>  
        /// <param name="Type"></param>  
        /// <param name="filepath">本地服务器的地址</param>  
        /// <returns></returns>  
        public string PostFile(string Type, string filepath)
        {
            string url = "http://file.api.weixin.qq.com/cgi-bin/media/upload?access_token=xxxx&type=" + Type;
            string result = "";
            WebClient myWebClient = new WebClient();
            myWebClient.Credentials = CredentialCache.DefaultCredentials;
            try
            {
                byte[] responseArray = myWebClient.UploadFile(url, "POST", filepath);
                result = System.Text.Encoding.Default.GetString(responseArray, 0, responseArray.Length);
                Object _mode = JsonHelper.Deserialize<Object>(result);
            }
            catch (Exception ex)
            {
                result = "Error:" + ex.Message;
            }
            return result;
        }
    }
}
