using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using YK.Model;

namespace YK.Models.Examination
{
    /// <summary> 
    ///检查-视力-题目
    /// </summary>
    [Table(Name = "Exam_Vision_Subject")]
    public class ExamVisionSubject : CommonProperty
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column(Name = "ID", IsDbGenerated = true, IsPrimaryKey = true)]
        public int ID { get; set; }
        /// <summary> 
        ///类型：1视力检查 2色盲检查 3颜色敏感度 4视力表 5散光测试 
        /// </summary>
        public string Type { get; set; }
        /// <summary> 
        ///名称
        /// </summary>
        public string Name { get; set; }
        /// <summary> 
        ///图片
        /// </summary>
        public string PicUrl { get; set; }
        /// <summary> 
        ///结果
        /// </summary>
        public string Result { get; set; }
        /// <summary> 
        ///排序 
        /// </summary>
        public int OrderBy { get; set; }
        /// <summary> 
        ///说明
        /// </summary>
        public string Description { get; set; }
    }
}
