using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YK.Model.CRM;
using System.Data;
using YK.Interface.Common;

namespace YK.Interface.CRM
{
    /// <summary>
    /// 加班接口
    /// </summary>
    public interface IEmployee_Overtime: IBase<TB_Employee_Overtime>
    {
       /// <summary>
        /// 获取下级人员的所有加班
        /// </summary>
        /// <param name="employeeId">员工编号</param>
        /// <param name="childID">搜索员工编号</param>
        /// <param name="PageSize">页面大小</param>
        /// <param name="PageIndex">分页码</param>
        /// <param name="recordCount">查询总数</param>
        /// <returns></returns>
        List<TB_Employee_Overtime> GetChildOvertime(int employeeId, int childID, int pageSize, int pageIndex, ref int recordCount);
    }
}
