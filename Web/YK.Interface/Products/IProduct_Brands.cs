using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YK.Model;
using System.Data;

namespace YK.Interface
{
    /// <summary>
    /// 商品品牌接口
    /// </summary>
    public interface IProduct_Brands: ICommon<TB_Product_Brands>
    {
       /// <summary>
        /// 获取类别对应的推荐品牌，在类别下拉中显示
        /// </summary>
        /// <param name="categoryId">类别编号</param>
        /// <returns></returns>
        List<TB_Product_Brands> GetCategoryVouchBrands(int categoryId);

        /// <summary>
        /// 获取所有的的推荐品牌
        /// </summary>
        /// <param name="categoryId">类别编号</param>
        /// <returns></returns>
        List<TB_Product_Brands> GetAllVouchBrands(int categoryId);

        /// <summary>
        /// 获取类别对应的品牌
        /// </summary>
        /// <param name="categoryId">类别编号</param>
        /// <returns></returns>
        List<TB_Product_Brands> GetCategoryBrands(int categoryId);

        /// <summary>
        /// 获取热销品牌
        /// </summary>
        /// <param name="count">显示数目</param>
        /// <returns></returns>
        List<TB_Product_Brands> GetHotSalesBrands(int count);
    }
}
