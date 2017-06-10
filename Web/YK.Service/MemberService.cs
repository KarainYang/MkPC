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
    /// 会员模块操作类
    /// </summary>
    public static class MemberService
    {       
        /// <summary>
        /// 会员服务
        /// </summary>
        public static IMember_Members MembersService
        {
            get
            {
                return new Member_Members_BLL();
            }
        }

        /// <summary>
        /// 会员级别服务
        /// </summary>
        public static IMember_Levels LevelsService
        {
            get
            {
                return new Member_Levels_BLL();
            }
        }

        /// <summary>
        /// 优惠券服务
        /// </summary>
        public static IMember_Coupon CouponService
        {
            get
            {
                return new Member_Coupon_BLL();
            }
        }

        /// <summary>
        /// 优惠券发放服务
        /// </summary>
        public static IMember_CouponNos CouponNosService
        {
            get
            {
                return new Member_CouponNos_BLL();
            }
        }

        /// <summary>
        /// 收货人信息服务
        /// </summary>
        public static IMember_BuyerInfo BuyerInfoService
        {
            get
            {
                return new Member_BuyerInfo_BLL();
            }
        }

        /// <summary>
        /// 交易记录服务
        /// </summary>
        public static IMember_TransRecord TransRecordService
        {
            get
            {
                return new Member_TransRecord_BLL();
            }
        }

        /// <summary>
        /// 积分交易服务
        /// </summary>
        public static IMember_Intergral IntergralService
        {
            get
            {
                return new Member_Intergral_BLL();
            }
        }

    }
}
