using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YK.Model;
using System.Data;

namespace YK.Interface
{
    /// <summary>
    /// 商品接口
    /// </summary>
    public interface IProduct_Products: ICommon<TB_Product_Products>
    {
        /// <summary>
        /// 热销商品
        /// </summary>
        /// <param name="count">显示数目</param>
        /// <returns></returns>
        List<TB_Product_Products> HotSalesProduts(int count);

        /// <summary>
        /// 类别热销商品
        /// </summary>
        /// <param name="count">显示数目</param>
        /// <returns></returns>
        List<TB_Product_Products> CategoryHotSalesProduts(int category, int count);
    }
}
