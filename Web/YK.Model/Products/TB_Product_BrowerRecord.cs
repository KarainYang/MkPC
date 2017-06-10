using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
namespace YK.Model
{
    /// <summary> 
    ///浏览记录
    /// </summary>
    public class TB_Product_BrowerRecord
    {
        /// <summary> 
        ///商品编号
        /// </summary>
        public int ProId { get; set; }
        /// <summary> 
        ///会员编号
        /// </summary>
        public int MemberId { get; set; }
        /// <summary> 
        ///浏览时间
        /// </summary>
        public DateTime BrowerDate { get; set; }
    }
}
