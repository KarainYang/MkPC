using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
namespace YK.Model
{
    /// <summary> 
    ///商品收藏实体
    /// </summary>
    public class TB_Product_Collection
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
        ///商品编号
        /// </summary>
        public int ProductID { get; set; }
        /// <summary> 
        ///路径
        /// </summary>
        public string Url { get; set; }
        /// <summary> 
        ///添加时间
        /// </summary>
        public DateTime? AddDate { get; set; }
    }
}
