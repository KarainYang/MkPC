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
using YK.Service;

using YK.Model;
using YK.Interface;
using System.Xml;
using YK.Common;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    public enum FieldType
    {
        None,
        Text,
        MultipleText,
        MultipleHtmlText,
        ListBox,
        Number,
        Money,
        DateTime,
        Link,
        Bool,
        Picture,
        File,
        Color,
        Area,
        PassWord,
        Label,
        Video
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Write(ExtensionMethod.ToFloat(10.32145,2));
        //YK.Service.System_Model_Factory<TB_System_Model_BLL>.SystemModelDelete(2);
       
        //ISystem_Model modelService =YK.Service.FactoryObjectService.SystemModelService();
        //TB_System_Model model = new TB_System_Model();
        //model.ID = 1;
        //model = modelService.Get(model);

        //Response.Write(model.GetType().Name);


        //XmlDocument xmldoc = new XmlDocument();
        //string xmlUrl = System.Web.HttpContext.Current.Server.MapPath("~/Config/Config.xml");
        //xmldoc.Load(xmlUrl);

        //XmlNodeList nodelist = xmldoc.SelectSingleNode("Models").ChildNodes;
        //foreach (XmlNode node in nodelist)
        //{
        //    XmlElement ele = (XmlElement)node;
        //    //if (ele.ChildNodes[0].InnerText.Trim() == entity.GetType().Name)
        //    //{}
        //    Response.Write(ele.ChildNodes[1].InnerText);

        //}

        //EmailSend.Mail126Send("871339677@qq.com","", "颜锟测试邮件");
        //EmailHelper.SendEmail( "颜锟测试邮件", "颜锟测试邮件","871339677@qq.com");
        //MSMSend.Send("13829725842","123456");
        //MSMSend.SendMsg1("13829725842", "123456");

        FieldType fieldType = (FieldType)Enum.Parse(typeof(FieldType), "2");

        Response.Write(fieldType);

        OprationXML();

    }
   

    protected void OprationXML()
    {
        string date = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
        Random rand = new Random();
        string filename = date + rand.Next(1000000, 9999999) + ".xml";
        string fileUrl = Server.MapPath("~/App_Data/" + filename);
        if (!File.Exists(fileUrl))
        {
            CreateXMLFile(fileUrl);
        }
        AddProductInfo(fileUrl);
    }
    //创建文件
    public void CreateXMLFile(string fileUrl)
    {
        //XmlDocument xmldoc = new XmlDocument();
        //XmlDeclaration declar = xmldoc.CreateXmlDeclaration("1.0","utf-8",null);
        //XmlElement ele = xmldoc.CreateElement("TB_Products");
        //xmldoc.AppendChild(ele);
        //xmldoc.Save(fileUrl);

        //创建XML文档对象 
        XmlDocument xmldoc = new XmlDocument();
        //创建xml 声明节点 
        XmlNode xmlnode = xmldoc.CreateNode(XmlNodeType.XmlDeclaration, "", "");
        //添加上述创建和 xml声明节点 
        xmldoc.AppendChild(xmlnode);
        //创建xml dbGuest 元素（根节点） 
        XmlElement xmlelem = xmldoc.CreateElement("", "TB_Products", "");

        xmldoc.AppendChild(xmlelem);
        xmldoc.Save(fileUrl);
    }

    //添加信息
    public void AddProductInfo(string fileUrl)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(fileUrl);
        XmlNode xmlnode = doc.SelectSingleNode("TB_Products");
        XmlElement xmlele = doc.CreateElement("ProInfo");
        XmlElement ele1 = doc.CreateElement("ID");
        ele1.InnerText = "1";
        xmlele.AppendChild(ele1);
        XmlElement ele2 = doc.CreateElement("ProName");
        ele2.InnerText = "产品";
        xmlele.AppendChild(ele2);
        XmlElement ele3 = doc.CreateElement("Price");
        ele3.InnerText = "100";
        xmlele.AppendChild(ele3);
        XmlElement ele4 = doc.CreateElement("Count");
        ele4.InnerText = "1000";
        xmlele.AppendChild(ele4);
        XmlElement ele5 = doc.CreateElement("SumPrice");
        ele5.InnerText = "100000";
        xmlele.AppendChild(ele5);
        XmlElement ele6 = doc.CreateElement("ImgUrl");
        ele6.InnerText = "Url";
        xmlele.AppendChild(ele6);
        xmlnode.AppendChild(xmlele);
        doc.Save(fileUrl);
    }
}
