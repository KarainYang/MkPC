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
using System.Xml;

using YK.Common;

public enum DictionariesEnum { 订单状态, 支付方式, 配送方式, 配送时间, 发票类型, 发票内容 }

/// <summary>
/// 字典实体
/// </summary>
public class DictionariesEntity
{
    /// <summary>
    /// 编号
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// 标题
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string Remark { get; set; }
}

/// <summary>
///购物车操作类 的摘要说明
/// </summary>
public class Dictionaries
{
    private static string path = HttpContext.Current.Server.MapPath("~/App_Data/Dictionaries.xml");

    /// <summary>
    /// 获取字典信息
    /// </summary>
    /// <param name="dictionarie">枚举</param>
    public static List<DictionariesEntity> GetDictionaries(DictionariesEnum dictionarie)
    {
        XmlDocument xmldoc = new XmlDocument();
        xmldoc.Load(path);
        XmlNodeList xnl = xmldoc.SelectSingleNode("Dictionaries").ChildNodes;
        List<DictionariesEntity> list = new List<DictionariesEntity>();
        foreach (XmlNode xn in xnl)
        {
            if(xn.Attributes["name"].Value==dictionarie.ToStr())
            {
                XmlNodeList childList = xn.ChildNodes;
                foreach(XmlNode xn2 in childList)
                {
                    DictionariesEntity entity = new DictionariesEntity();                    
                    entity.ID = xn2.Attributes["ID"].Value.ToInt();
                    entity.Title = xn2.InnerText;
                    entity.Remark = xn2.Attributes["Remark"].Value;
                    list.Add(entity);
                }
            }
        }
        return list;
    }

    /// <summary>
    /// 获取字典信息名称
    /// </summary>
    /// <param name="dictionarie"></param>
    /// <returns></returns>
    public static string GetDictionariesTitle(DictionariesEnum dictionarie, int id)
    {
        XmlDocument xmldoc = new XmlDocument();
        xmldoc.Load(path);
        XmlNodeList xnl = xmldoc.SelectSingleNode("Dictionaries").ChildNodes;
        string title = "";
        foreach (XmlNode xn in xnl)
        {
            if (xn.Attributes["name"].Value == dictionarie.ToStr())
            {
                XmlNodeList childList = xn.ChildNodes;
                foreach (XmlNode xn2 in childList)
                {
                    if(xn2.Attributes["ID"].Value.ToInt()==id)
                    {
                        title = xn2.InnerText;
                    }
                }
            }
        }
        return title;
    }
}
