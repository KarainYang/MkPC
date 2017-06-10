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
    ///检查-视力-结果
    /// </summary>
    [Table(Name = "Exam_Vision_Result")]
    public class ExamVisionResult : CommonProperty
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column(Name = "ID", IsDbGenerated = true, IsPrimaryKey = true)]
        public int ID { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary> 
        ///模块1视力检查 2听力检测 3血压测量 4心率测量 5肺活量测量 6呼吸频率测量 7血氧测量 8心理检测
        /// </summary>
        public string Module { get; set; }

        /// <summary> 
        ///类型
        ///--类型：1视力检查（1视力检查 2色盲检查 3颜色敏感度 4视力表 5散光测试）
        ///--类型：2听力检测（1默认）
        ///--类型：3血压测量（1手机测量 2血压计测量 3手动输入）
        ///--类型：4心率测量（1手机测量 2心率仪测量 3手动输入）
        ///--类型：5肺活量测量（1手机测量 2手动输入）
        ///--类型：6呼吸频率测量（1光电测量 2话筒测量 3手动输入）
        ///--类型：7血氧测量（1手机测量 2血氧仪测量 3手动输入）
        ///--类型：8心理检测（1情绪 2抑郁症 3自闭症）
        /// </summary>
        public string Type { get; set; }

        /// <summary> 
        ///结果
        /// </summary>
        public string Result { get; set; }
    }
}
