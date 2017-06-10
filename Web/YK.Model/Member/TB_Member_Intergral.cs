using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
namespace YK.Model
{
    /// <summary> 
    ///会员积分记录实体
    /// </summary>
    public class TB_Member_Intergral
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        /// <summary> 
        ///会员编号
        /// </summary>
        public int MemberID { get; set; }
        /// <summary>
        /// 交易类型,收入或支出
        /// </summary>
        public int TransType { get; set; }
        /// <summary> 
        ///积分
        /// </summary>
        public int Intergral { get; set; }
        /// <summary> 
        ///备注
        /// </summary>
        public int Remark { get; set; }
        /// <summary> 
        ///添加时间
        /// </summary>
        public DateTime? AddDate { get; set; }
    }
}
