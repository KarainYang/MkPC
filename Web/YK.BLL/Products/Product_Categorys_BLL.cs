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
    /// 商品类别业务
    /// </summary>
    public class Product_Categorys_BLL : BasePageBLL<TB_Product_Categorys>,IProduct_Categorys
    {
        /// <summary>
        /// 获取当前类别下的所有类别
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public string GetCategoryList(int categoryId)
        {
            TB_Product_Categorys entity = Get(categoryId);
            string categoryIdStr = categoryId.ToStr() + ",";

            List<Expression> express = new List<Expression>();
            express.Add(new Expression("ParentId", "=", categoryId.ToStr()));
            List<TB_Product_Categorys> list = Search(express);
            if (list.Count > 0)
            {
                foreach (TB_Product_Categorys model in list)
                {
                    categoryIdStr += GetCategoryList(model.ID) + ",";
                }
            }
            return categoryIdStr.Trim(',');
        }

    }
}
