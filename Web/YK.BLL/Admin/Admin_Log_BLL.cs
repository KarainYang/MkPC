using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using YK.Model;
using YK.Interface;
using YK.Common;
using YK.Core;

namespace YK.BLL
{
    /// <summary>
    /// 操作日志业务
    /// </summary>
    public class Admin_Log_BLL : BasePageBLL<TB_Admin_Log>,IAdmin_Log
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        /// <param name="Type">操作类型</param>
        /// <param name="ObjId">操作对象编号</param>
        /// <param name="Remark">备注</param>
        public int Insert(OperationType Type, int ObjId, string Remark)
        {
           return Insert(Type, ObjId, Remark, BasePage.AdminUserName);
        }

        /// <summary>
        /// 操作类型
        /// </summary>
        /// <param name="Type">操作类型</param>
        /// <param name="ObjId">操作对象编号</param>
        /// <param name="Remark">备注</param>
        /// <param name="Operator">操作者</param>
        public int Insert(OperationType Type, int ObjId, string Remark, string Operator)
        {
            TB_Admin_Log log = new TB_Admin_Log();
            log.Operator = Operator;
            log.Type = Type.ToStr();
            log.ObjId = ObjId;
            log.Remark = Remark;
            log.AddDate = DateTime.Now;
            return Insert(log);
        }
    }
}
