using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
namespace YK.Model
{
    /// <summary> 
    ///会员实体
    /// </summary>
    public class TB_Member_Members
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        /// <summary> 
        ///用户名
        /// </summary>
        public string MemberName { get; set; }
        /// <summary> 
        ///密码
        /// </summary>
        public string MemberPwd { get; set; }
        /// <summary> 
        ///会员级别编号
        /// </summary>
        public int LevelID { get; set; }
        /// <summary> 
        ///真实姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary> 
        ///呢称
        /// </summary>
        public string ChengNi { get; set; }
        /// <summary> 
        ///性别
        /// </summary>
        public int Sex { get; set; }
        /// <summary> 
        ///年龄
        /// </summary>
        public int Age { get; set; }
        /// <summary> 
        ///生日
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary> 
        ///照片
        /// </summary>
        public string PhotoUrl { get; set; }
        /// <summary> 
        ///爱好
        /// </summary>
        public string Lover { get; set; }
        /// <summary> 
        ///公司名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary> 
        ///电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary> 
        ///手机号
        /// </summary>
        public string Mobile { get; set; }
        /// <summary> 
        ///QQ号
        /// </summary>
        public string QQ { get; set; }
        /// <summary> 
        ///MSN
        /// </summary>
        public string MSN { get; set; }
        /// <summary> 
        ///邮编
        /// </summary>
        public string PostCode { get; set; }
        /// <summary> 
        ///邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary> 
        ///所在城市
        /// </summary>
        public string City { get; set; }
        /// <summary> 
        ///地址
        /// </summary>
        public string Address { get; set; }
        /// <summary> 
        ///账户金额
        /// </summary>
        public decimal AccountMoney { get; set; }
        /// <summary> 
        ///积分
        /// </summary>
        public int Integrate { get; set; }
        /// <summary> 
        ///最后登录时间
        /// </summary>
        public DateTime LastLoginTime { get; set; }
        /// <summary> 
        ///最后登录IP
        /// </summary>
        public string LastLoginIP { get; set; }
        /// <summary> 
        ///是否冻结，0为开通，1为冻结
        /// </summary>
        public int IsFreeze { get; set; }
        /// <summary> 
        ///备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 添加日期
        /// </summary>
        public DateTime? AddDate { get; set; }
    }
}
