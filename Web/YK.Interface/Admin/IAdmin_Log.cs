using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YK.Model;
using System.Data;
using YK.Common;

namespace YK.Interface
{
    /// <summary>
    /// 操作日志接口
    /// </summary>
    public interface IAdmin_Log : ICommon<TB_Admin_Log>
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        /// <param name="Type">操作类型</param>
        /// <param name="ObjId">操作对象编号</param>
        /// <param name="Remark">备注</param>
        int Insert(OperationType Type, int ObjId, string Remark);

        /// <summary>
        /// 操作类型
        /// </summary>
        /// <param name="Type">操作类型</param>
        /// <param name="ObjId">操作对象编号</param>
        /// <param name="Remark">备注</param>
        /// <param name="Operator">操作者</param>
        int Insert(OperationType Type, int ObjId, string Remark, string Operator);
    }
}
