using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Web;
using System.Data;

namespace YK.Model
{
    public class GetLangs
    {
        private static string LangXml = "~/App_Data/Langs.xml";

        /// ��ȡ����
        public static string GetLangsCode()
        {
            string _langCode;
            string _url = System.Web.HttpContext.Current.Request.Url.ToString().ToLower();
            if (_url.Contains("/cn/"))
                _langCode = "cn";
            else if (_url.Contains("/ft/"))
                _langCode = "ft";
            else if (_url.Contains("/en/"))
                _langCode = "en";
            else
                _langCode = GetXmlLangsCode();
            //System.Web.HttpContext.Current.Response.Write(_langCode);
            return _langCode;
        }

        //��ȡ�����б�
        public static DataSet GetLangsList()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(HttpContext.Current.Server.MapPath(LangXml));
            return ds;
        }

        /// <summary>
        /// ��ȡXML��ǰ����
        /// </summary>
        /// <returns></returns>
        private static string GetXmlLangsCode()
        {
            #region
            string _lang = string.Empty;
            //��ȡXML�ĵ�����
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(System.Web.HttpContext.Current.Server.MapPath(LangXml));
            //��ȡ�ڵ��б�
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("root").ChildNodes;
            //ѭ�������ڵ�
            foreach (XmlNode xn in nodeList)
            {
                //Ԫ�ض���
                XmlElement xe = (XmlElement)xn;
                if (xe.ChildNodes[2].InnerText == "1")
                    _lang = xe.ChildNodes[0].InnerText;
            }
            return _lang;
            #endregion
        }


        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="langCode"></param>
        /// <returns></returns>
        public void UpdateLangs(string langCode)
        {
            #region
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(System.Web.HttpContext.Current.Server.MapPath(LangXml));
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("root").ChildNodes;
            foreach (XmlNode xn in nodeList)
            {
                XmlElement xe = (XmlElement)xn;
                if (xe.ChildNodes[0].InnerText == langCode)
                    xe.ChildNodes[2].InnerText = "1";
                else
                    xe.ChildNodes[2].InnerText = "0";
            }
            xmlDoc.Save(System.Web.HttpContext.Current.Server.MapPath(LangXml));
            #endregion
        }
    }
}
