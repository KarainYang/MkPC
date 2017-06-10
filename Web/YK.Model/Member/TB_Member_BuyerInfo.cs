using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
namespace YK.Model
{
    /// <summary> 
    ///收货人历史信息实体
    /// </summary>
    public class TB_Member_BuyerInfo
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
        ///收货人
        /// </summary>
        public string BuyerName { get; set; }
        /// <summary> 
        ///地址
        /// </summary>
        public string Address { get; set; }
        /// <summary> 
        ///邮政编码
        /// </summary>
        public string PostalCode { get; set; }
        /// <summary> 
        ///电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary> 
        ///传真
        /// </summary>
        public string Fax { get; set; }
        /// <summary> 
        ///手机号
        /// </summary>
        public string Mobile { get; set; }
        /// <summary> 
        ///邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary> 
        ///地区
        /// </summary>
        public string Zone { get; set; }
    }
}
