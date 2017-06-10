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
    ///体检原理
    /// </summary>
    [Table(Name = "Exam_Principle")]
    public class ExamPrinciple : CommonProperty
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column(Name = "ID", IsDbGenerated = true, IsPrimaryKey = true)]
        public int ID { get; set; }
        /// <summary> 
        ///名称
        /// </summary>
        public string Name { get; set; }
        /// <summary> 
        ///模块1视力检查 2听力检测 3血压测量 4心率测量 5肺活量测量 6呼吸频率测量 7血氧测量 8心理检测
        /// </summary>
        public string Module { get; set; }
        /// <summary> 
        ///图片
        /// </summary>
        public string PicUrl { get; set; }
        /// <summary> 
        ///说明
        /// </summary>
        public string Description { get; set; }
    }
}
