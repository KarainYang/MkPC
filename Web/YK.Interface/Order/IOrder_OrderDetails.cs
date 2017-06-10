using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YK.Model;
using System.Data;

namespace YK.Interface
{
    /// <summary>
    /// 订单详细接口
    /// </summary>
    public interface IOrder_OrderDetails: ICommon<TB_Order_OrderDetails>
    {
        /// <summary>
        /// 获取商品的销售数量
        /// </summary>
        /// <param name="orderType">订单类型</param>
        /// <param name="pid">编号</param>
        /// <returns></returns>
        List<TB_Order_OrderDetails> GetProSalesSum(int orderType, int pid);
    }
}
