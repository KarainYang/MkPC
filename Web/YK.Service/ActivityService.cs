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
    /// 促销活动模块操作类
    /// </summary>
    public static class ActivityService
    {       
        /// <summary>
        /// 促销活动服务
        /// </summary>
        public static IActivity_Activity ActivitysService
        {
            get
            {
                return new Activity_Activity_BLL();
            }
        }

        /// <summary>
        /// 优惠券发放服务
        /// </summary>
        public static IActivity_CouponNos CouponNosService
        {
            get
            {
                return new Activity_CouponNos_BLL();
            }
        }  
    }
}
