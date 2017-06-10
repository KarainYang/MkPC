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
    /// 体检原理
    /// </summary>
    public class BasicService 
    {
        /// <summary>
        /// 检查-视力-题目
        /// </summary>
        public static IExamPrinciple ExamPrincipleService
        {
            get {
                return new ExamPrincipleBLL();
            }
        }

    }
}
