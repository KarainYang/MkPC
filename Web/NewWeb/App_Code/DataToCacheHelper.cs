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
using YK.Model;
using YK.Service;
using YK.Common;
using System.ComponentModel;

public class DataToCacheHelper
{
    public enum CacheNames 
    { 
        /// <summary>
        /// 首页推荐
        /// </summary>
        [Description("首页推荐")]
        IndexVouch, 
        /// <summary>
        /// 商品类别
        /// </summary>
        [Description("商品类别")]
        ProductCategorys, 
        /// <summary>
        /// 帮助中心类别
        /// </summary>
        [Description("帮助中心类别")]
        HelpCategorys,
        /// <summary>
        /// 所有权限资源信息
        /// </summary>
        [Description("所有权限资源")]
        AllResources,
        /// <summary>
        /// 所有数据字典信息
        /// </summary>
        [Description("所有数据字典信息")]
        AllDictionaries
    }

    /// <summary>
    /// 获取商品类别
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    public static List<TB_Product_Categorys> GetProductCategory()
    {        
        List<TB_Product_Categorys> list=new List<TB_Product_Categorys>();
        if (CachesHelper.GetCache(CacheNames.ProductCategorys.ToStr()) != null)
        {
            list = (List<TB_Product_Categorys>)CachesHelper.GetCache(CacheNames.ProductCategorys.ToStr());
        }
        else
        {
            List<Expression> express = new List<Expression>();
            express.Add(new Expression("IsDelete", "=", "0"));
            express.Add(new Expression("IsHidden", "=", "0"));
            list = ProductService.CategoryService.Search(express, "OrderBy asc");
            CachesHelper.AddCache(CacheNames.ProductCategorys.ToStr(), list, null);
        }        
        return list;
    }

    /// <summary>
    /// 获取首页商品推荐
    /// </summary>
    /// <returns></returns>
    public static List<List<TB_Product_Products>> GetIndexVouchProducts()
    {

        List<List<TB_Product_Products>> list = new List<List<TB_Product_Products>>();
        if (CachesHelper.GetCache(CacheNames.IndexVouch.ToStr()) != null)
        {
            list = (List<List<TB_Product_Products>>)CachesHelper.GetCache(CacheNames.IndexVouch.ToStr());
        }
        else
        {
            List<Expression> express = new List<Expression>();
            express.Add(new Expression("Mark", "=", "2"));
            express.Add(new Expression("IsDelete", "=", "0"));
            int recordCount = 0;
            list.Add(ProductService.ProductsService.Search(6, 1, express, ref recordCount));
            list.Add(ProductService.ProductsService.Search(6, 2, express, ref recordCount));
            list.Add(ProductService.ProductsService.Search(6, 3, express, ref recordCount));
            list.Add(ProductService.ProductsService.Search(6, 4, express, ref recordCount));
            CachesHelper.AddCache(CacheNames.IndexVouch.ToStr(), list, null);
        }
        return list;
    }

    /// <summary>
    /// 获取所有权限资源
    /// </summary>
    /// <returns></returns>
    public static List<TB_Admin_Resources> GetPermission()
    {
        List<TB_Admin_Resources> list = new List<TB_Admin_Resources>();
        if (CachesHelper.GetCache(CacheNames.AllResources.ToStr()) != null)
        {
            list = (List<TB_Admin_Resources>)CachesHelper.GetCache(CacheNames.AllResources.ToStr());
        }
        else
        {
            list=AdminService.ResourcesService.Search().OrderBy(r => r.OrderBy).ToList();
            CachesHelper.AddCache(CacheNames.AllResources.ToStr(), list,null);
        }
        return list;
    }

    /// <summary>
    /// 所有数据字典信息
    /// </summary>
    /// <returns></returns>
    public static List<TB_System_Dictionary> GetAllDictionaries()
    {
        List<TB_System_Dictionary> list = new List<TB_System_Dictionary>();
        if (CachesHelper.GetCache(CacheNames.AllDictionaries.ToStr()) != null)
        {
            list = (List<TB_System_Dictionary>)CachesHelper.GetCache(CacheNames.AllDictionaries.ToStr());
        }
        else
        {
            list = SystemService.DictionaryService.Search().OrderBy(r => r.OrderBy).ToList();
            CachesHelper.AddCache(CacheNames.AllDictionaries.ToStr(), list, null);
        }
        return list;
    }
}
