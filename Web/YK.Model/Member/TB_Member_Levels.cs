using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
namespace YK.Model
{
    /// <summary> 
    ///会员级别实体
    /// </summary>
    public class TB_Member_Levels
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        /// <summary> 
        ///级别名称
        /// </summary>
        public string LevelName { get; set; }
        /// <summary> 
        ///折扣
        /// </summary>
        public decimal Discount { get; set; }
        /// <summary> 
        ///是否为默认级别
        /// </summary>
        public bool IsDefault { get; set; }
        /// <summary> 
        ///是否启用折扣
        /// </summary>
        public bool IsEnableDis { get; set; }
        /// <summary> 
        ///最低积分
        /// </summary>
        public int MinIntegral { get; set; }
        /// <summary> 
        ///创建时间
        /// </summary>
        public DateTime? AddDate { get; set; }
    }
}
