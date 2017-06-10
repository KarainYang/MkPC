using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using YK.Interface;
using System.Reflection;
using YK.BLL;

namespace YK.Service
{
    /// <summary>
    /// 订单模块操作类
    /// </summary>
    public static class OrderService
    {       
        /// <summary>
        /// 订单服务
        /// </summary>
        public static IOrder_Orders OrdersService
        {
            get
            {
                return new Order_Orders_BLL();
            }
        }

        /// <summary>
        /// 订单详细服务
        /// </summary>
        public static IOrder_OrderDetails OrderDetailsService
        {
            get
            {
                return new Order_OrderDetails_BLL();
            }
        }

        /// <summary>
        /// 订单状态服务
        /// </summary>
        public static IOrder_OrderState OrderStateService
        {
            get
            {
                return new Order_OrderState_BLL();
            }
        }

        /// <summary>
        /// 送货方式服务
        /// </summary>
        public static IOrder_Consigument ConsigumentService
        {
            get
            {
                return new Order_Consigument_BLL();
            }
        }

        /// <summary>
        /// 付款方式服务
        /// </summary>
        public static IOrder_Payment PaymentService
        {
            get
            {
                return new Order_Payment_BLL();
            }
        }

        /// <summary>
        /// 退货订单服务
        /// </summary>
        public static IReturnGood_Order ReturnGoodOrderService
        {
            get
            {
                return new ReturnGood_Order_BLL();
            }
        }

        /// <summary>
        /// 退货订单详细服务
        /// </summary>
        public static IReturnGood_OrderDetails ReturnGoodOrderDetailsService
        {
            get
            {
                return new ReturnGood_OrderDetails_BLL();
            }
        }
        
        /// <summary>
        /// 订单配送信息服务
        /// </summary>
        public static IOrder_Distribution DistributionService
        {
            get
            {
                return new Order_Distribution_BLL();
            }
        }  
    }
}
