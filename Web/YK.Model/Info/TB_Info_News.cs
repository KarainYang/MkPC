using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
namespace YK.Model
{
    /// <summary> 
    ///新闻
    /// </summary>
    public class TB_Info_News
    {
        /// <summary> 
        ///编号
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        /// <summary> 
        ///类别编号
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary> 
        ///标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 类别标识
        /// </summary>
        public string CategoryCode { get; set; }
        /// <summary> 
        ///活动描述
        /// </summary>
        public string Description { get; set; }
        /// <summary> 
        ///备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary> 
        ///是否隐藏
        /// </summary>
        public bool IsHIdden { get; set; }
        /// <summary> 
        ///是否推荐
        /// </summary>
        public bool IsVouch { get; set; }
        /// <summary> 
        ///创建者
        /// </summary>
        public string Creater { get; set; }
        /// <summary> 
        ///添加日期
        /// </summary>
        public DateTime? AddDate { get; set; }
    }
}
