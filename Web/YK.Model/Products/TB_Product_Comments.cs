using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
namespace YK.Model
{
    /// <summary> 
    ///商品评论实体
    /// </summary>
    public class TB_Product_Comments
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
        ///内容
        /// </summary>
        public string ComContent { get; set; }
        /// <summary> 
        ///评论类型，例如：好，中，差
        /// </summary>
        public int ComType { get; set; }
        /// <summary> 
        ///添加时间
        /// </summary>
        public DateTime? AddDate { get; set; }
    }
}
