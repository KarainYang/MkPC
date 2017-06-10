using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using System.Linq;
using YK.Interfaces.Examination;
using YK.BLLs.Examination;

namespace YK.Services.Examination
{
    /// <summary>
    /// 视力检查
    /// </summary>
    public class VisionService 
    {
        /// <summary>
        /// 检查-视力-题目
        /// </summary>
        public static IExamVisionSubject ExamVisionSubjectService
        {
            get {
                return new ExamVisionSubjectBLL();
            }
        }

        /// <summary>
        /// 检查-视力-结果
        /// </summary>
        public static IExamVisionResult ExamVisionResultService
        {
            get
            {
                return new ExamVisionResultBLL();
            }
        }
    }
}
