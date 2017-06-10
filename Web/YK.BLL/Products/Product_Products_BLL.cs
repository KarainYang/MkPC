using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using YK.Model;
using YK.Interface;
using YK.Common;
using YK.Core;

namespace YK.BLL
{
    /// <summary>
    /// 商品业务
    /// </summary>
    public class Product_Products_BLL : BasePageBLL<TB_Product_Products>,IProduct_Products
    {
        /// <summary>
        /// 热销商品
        /// </summary>
        /// <param name="count">显示数目</param>
        /// <returns></returns>
        public List<TB_Product_Products> HotSalesProduts(int count)
        {
            //订单类型为普通，且订单未取消
            string cmdText = "select * from TB_Product_Products where ID in "
                + "(select top " + count + " ProductID from TB_Order_OrderDetails left join TB_Order_Orders "
                +"on TB_Order_OrderDetails.OrderNumber=TB_Order_Orders.OrderNumber "
                + "where IsDelete=0  and OrderType=0 group by ProductID order by sum(Count) desc )";
            return SQLSearch(cmdText);
        }

        /// <summary>
        /// 类别热销商品
        /// </summary>
        /// <param name="count">显示数目</param>
        /// <returns></returns>
        public List<TB_Product_Products> CategoryHotSalesProduts(int category, int count)
        {
            string cmdText = "select * from TB_Product_Products " +
            "(" +
                "select top " + count + " ProductID " +
                "from TB_Order_OrderDetails left join TB_Order_Orders " +
                "on TB_Order_OrderDetails.OrderNumber=TB_Order_Orders.OrderNumber " +
                "left join TB_Product_Products " +
                "on TB_Order_OrderDetails.ProductID=TB_Product_Products.ID " +
                "where TB_Order_Orders.IsDelete=0  and OrderType=0 and CategoryID in (" + category + ") " +
                "group by ProductID order by sum(Count) desc" +
            ")";
            return SQLSearch(cmdText);
        }
    }
}
