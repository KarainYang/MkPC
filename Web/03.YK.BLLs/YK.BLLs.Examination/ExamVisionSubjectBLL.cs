using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using System.Linq;
using YK.Interfaces.Examination;
using YK.Models.Examination;
using YK.BLL.Common;

namespace YK.BLLs.Examination
{
    /// <summary>
    /// 检查-视力-题目
    /// </summary>
    public class ExamVisionSubjectBLL : BaseBLL<ExamVisionSubject>, IExamVisionSubject
    {
    }
}
