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
using YK.Service;
using YK.Model;

/// <summary>
///购物车操作类 的摘要说明
/// </summary>
public class Cart
{
    private static string path = HttpContext.Current.Server.MapPath("~/App_Data/Cart/" + System.Web.HttpContext.Current.Request.Cookies["MemberInfo"]["MemberName"].ToStr() + ".xml");


     /// <summary>
    /// 添加普通商品到购物车
    /// </summary>
    /// <param name="proId">商品编号</param>
    /// <param name="count">商品数量</param>
    /// <returns></returns>
    public static bool AddCart(int proId, int count)
    {
        return AddCart(0, proId, count);
    }
    

    /// <summary>
    /// 添加购物车
    /// </summary>
    /// <param name="type">商品类型，0为普通商品，1为团购商品</param>
    /// <param name="proId">商品编号</param>
    /// <param name="count">商品数量</param>
    /// <returns></returns>
    public static bool AddCart(int type,int proId, int count)
    {
        if (!File.Exists(path))
        {
            CreateXMLFile(path);
        }

        decimal marketPrice = 0;

        //获取购物车里面的数据
        TB_Order_OrderDetails model=new TB_Order_OrderDetails();
        switch (type)
        {
            case 0:
                    TB_Product_Products entity = ProductService.ProductsService.Get(proId);
                    model.ProductID = entity.ID;
                    model.ProNumber = entity.ProNumber;
                    model.ProName = entity.ProName;
                    model.Price = entity.SalesPrice;
                    model.Picture = entity.ImgUrl;
                    marketPrice = entity.MarketPrice;
                break;
            case 1:
                    TB_Product_Group entity2 = ProductService.GroupService.Get(proId);
                    model.ProductID = entity2.ID;
                    model.ProName = entity2.GroupName;
                    model.Price = entity2.Price;
                    model.Picture = entity2.ImgUrl;
                break;
            
        }
        
        DataSet ds = new DataSet();
        ds.ReadXml(path);

        if (ds.Tables.Count > 0)
        {
            DataTable dt = ds.Tables[0];
            //当前商品是否存在
            bool isExist = false;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["id"].ToInt() == proId && dr["type"].ToInt() == type)
                {
                    isExist = true;
                    dr["count"] = dr["count"].ToInt() + count;
                    dr["amount"] = model.Price * dr["count"].ToInt();
                }
            }
            //当不存在
            if (isExist == false)
            {
                DataRow dr = dt.NewRow();
                dr["type"] = type.ToStr();
                dr["id"] = model.ProductID;
                dr["proNumber"] = model.ProNumber;
                dr["name"] = model.ProName;
                dr["img"] = model.Picture;
                dr["marketPrice"] = marketPrice;
                dr["count"] = count;
                dr["price"] = model.Price;
                dr["amount"] = model.Price * count;
                dt.Rows.Add(dr);
            }
            //保存到购物车
            ds.WriteXml(path);
        }
        else
        {
            AddProductInfo(type, model, count);
        }
        return true;
    }

    /// <summary>
    /// 获取购物车数据
    /// </summary>
    /// <returns></returns>
    public static DataSet GetCart()
    {
        if (!File.Exists(path))
        {
            CreateXMLFile(path);
        }

        DataSet ds = new DataSet();
        ds.ReadXml(path);
        return ds;
    }

    /// <summary>
    /// 移除行
    /// </summary>
    /// <param name="id">编号</param>
    public static void RemoveRow(int id)
    {
        DataSet ds = GetCart();

        foreach (DataTable dt in ds.Tables)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["id"].ToStr() == id.ToStr())
                {
                    dt.Rows.Remove(dr);
                    break;
                }
            }
        }

        ds.WriteXml(path);
    }

    /// <summary>
    /// 修改数量
    /// </summary>
    /// <param name="id">编号</param>
    /// <param name="count">总数</param>
    public static void UpdateCount(int id, int count)
    {
        DataSet ds = GetCart();

        foreach (DataTable dt in ds.Tables)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["id"].ToStr() == id.ToStr())
                {
                    dr["amount"] = count * dr["price"].ToDecimal();
                    dr["count"] = count;
                }
            }
        }

        ds.WriteXml(path);
    }

    /// <summary>
    /// 创建文件
    /// </summary>
    /// <param name="fileUrl"></param>
    public static void CreateXMLFile(string fileUrl)
    {
        //创建XML文档对象 
        XmlDocument xmldoc = new XmlDocument();
        //创建xml 声明节点 
        XmlNode xmlnode = xmldoc.CreateNode(XmlNodeType.XmlDeclaration, "", "");
        //添加上述创建和 xml声明节点 
        xmldoc.AppendChild(xmlnode);
        //创建xml TB_Products 元素（根节点） 
        XmlElement xmlelem = xmldoc.CreateElement("", "TB_Products", "");

        xmldoc.AppendChild(xmlelem);
        xmldoc.Save(fileUrl);
    }

    /// <summary>
    /// 添加信息
    /// </summary>
    /// <param name="model"></param>
    /// <param name="count"></param>
    public static void AddProductInfo(int type, TB_Order_OrderDetails model, int count)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(path);
        XmlNode xmlnode = doc.SelectSingleNode("TB_Products");
        XmlElement xmlele = doc.CreateElement("ProInfo");

        XmlElement ele0 = doc.CreateElement("type");
        ele0.InnerText = type.ToStr();
        xmlele.AppendChild(ele0);

        XmlElement ele1 = doc.CreateElement("id");
        ele1.InnerText = model.ProductID.ToStr();
        xmlele.AppendChild(ele1);

        XmlElement ele2 = doc.CreateElement("proNumber");
        ele2.InnerText = model.ProNumber;
        xmlele.AppendChild(ele2);

        XmlElement ele7 = doc.CreateElement("name");
        ele7.InnerText = model.ProName;
        xmlele.AppendChild(ele7);

        XmlElement ele6 = doc.CreateElement("img");
        ele6.InnerText = model.Picture;
        xmlele.AppendChild(ele6);

        XmlElement ele8 = doc.CreateElement("marketPrice");
        ele8.InnerText = model.Price.ToStr();
        xmlele.AppendChild(ele8);

        XmlElement ele3 = doc.CreateElement("price");
        ele3.InnerText = model.Price.ToStr();
        xmlele.AppendChild(ele3);

        XmlElement ele4 = doc.CreateElement("count");
        ele4.InnerText = count.ToStr();
        xmlele.AppendChild(ele4);

        XmlElement ele5 = doc.CreateElement("amount");
        ele5.InnerText = (model.Price * count).ToStr();
        xmlele.AppendChild(ele5);

        xmlnode.AppendChild(xmlele);
        doc.Save(path);
    }

    /// <summary>
    /// 清空购物车
    /// </summary>
    public static void ClearCart()
    {
        DataSet ds = GetCart();
        ds.Clear();
        ds.WriteXml(path);
    }

    /// <summary>
    /// 获取购物车总金额
    /// </summary>
    /// <returns></returns>
    public static decimal GetTotalAmount()
    {
        decimal amount=0.00m;

        DataSet ds = Cart.GetCart();
        if (ds.Tables.Count > 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                amount += dr["amount"].ToDecimal();
            }
        }

        return amount;
    }

    /// <summary>
    /// 获取购物车市场价总金额
    /// </summary>
    /// <returns></returns>
    public static decimal GetMarketPriceTotalAmount()
    {
        decimal amount = 0.00m;

        DataSet ds = Cart.GetCart();
        if (ds.Tables.Count > 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                amount += dr["count"].ToDecimal() * dr["marketPrice"].ToDecimal();
            }
        }

        return amount;
    }
}
