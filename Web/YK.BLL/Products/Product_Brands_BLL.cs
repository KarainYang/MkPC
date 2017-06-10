using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using YK.Model;
using YK.Interface;
using YK.Common;

namespace YK.BLL
{
    /// <summary>
    /// 商品品牌业务
    /// </summary>
    public class Product_Brands_BLL : BasePageBLL<TB_Product_Brands>,IProduct_Brands
    {
        /// <summary>
        /// 获取类别对应的推荐品牌，在类别下拉中显示
        /// </summary>
        /// <param name="categoryId">类别编号</param>
        /// <returns></returns>
        public List<TB_Product_Brands> GetCategoryVouchBrands(int categoryId)
        {
            string cmdText = "select * from TB_Product_Brands where id in (select BrandId from TB_Product_CategoryBrand where CategoryId=" + categoryId + " and VouchType=1)";
            return SQLSearch(cmdText);
        }

        /// <summary>
        /// 获取所有的的推荐品牌
        /// </summary>
        /// <param name="categoryId">类别编号</param>
        /// <returns></returns>
        public List<TB_Product_Brands> GetAllVouchBrands(int categoryId)
        {
            string cmdText = "select * from TB_Product_Brands where id in (select BrandId from TB_Product_CategoryBrand where VouchType=1)";
            return SQLSearch(cmdText);
        }

        /// <summary>
        /// 获取类别对应的品牌
        /// </summary>
        /// <param name="categoryId">类别编号</param>
        /// <returns></returns>
        public List<TB_Product_Brands> GetCategoryBrands(int categoryId)
        {
            string cmdText = "select * from TB_Product_Brands where id in (select BrandId from TB_Product_CategoryBrand where CategoryId=" + categoryId + ")";
            return SQLSearch(cmdText);
        }

        /// <summary>
        /// 获取热销品牌
        /// </summary>
        /// <param name="count">显示数目</param>
        /// <returns></returns>
        public List<TB_Product_Brands> GetHotSalesBrands(int count)
        { 
            string cmdText = "select * from TB_Product_Brands where id in "
                +"(select top "+count+" BrandID from TB_Order_OrderDetails d "
                +"left join TB_Order_Orders o on d.OrderNumber=o.OrderNumber "
                +"left join TB_Product_Products p on p.ID=d.ProductID  "
                +"where o.IsDelete=0 and OrderType=0 group by BrandID order by sum(Count) desc)";
            return SQLSearch(cmdText);
        }
    }
}
