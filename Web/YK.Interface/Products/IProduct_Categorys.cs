using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YK.Model;
using System.Data;

namespace YK.Interface
{
    /// <summary>
    /// 商品类别接口
    /// </summary>
    public interface IProduct_Categorys: ICommon<TB_Product_Categorys>
    {
       /// <summary>
        /// 获取当前类别下的所有类别
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        string GetCategoryList(int categoryId);
    }
}
