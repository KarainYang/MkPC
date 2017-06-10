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
    /// 订单详细业务
    /// </summary>
    public class Order_OrderDetails_BLL : BasePageBLL<TB_Order_OrderDetails>,IOrder_OrderDetails
    {
        /// <summary>
        /// 获取商品的销售数量
        /// </summary>
        /// <param name="orderType">订单类型</param>
        /// <param name="pid">编号</param>
        /// <returns></returns>
        public List<TB_Order_OrderDetails> GetProSalesSum(int orderType, int pid)
        {
            //订单类型为团购，且订单未取消
            string cmdText = "select * from TB_Order_OrderDetails left join TB_Order_Orders "
                + " on TB_Order_OrderDetails.OrderNumber=TB_Order_Orders.OrderNumber "
                + " where IsDelete=0 and ProID=" + pid + " and OrderType=" + orderType;
            return SQLSearch(cmdText);
        }
    }
}
