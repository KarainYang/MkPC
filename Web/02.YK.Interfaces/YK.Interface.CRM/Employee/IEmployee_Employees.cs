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
    /// 员工接口
    /// </summary>
    public interface IEmployee_Employees: IBase<TB_Employee_Employees>
    {
       /// <summary>
        /// 获取所有下级员工（级别是通过职位来分的）
        /// </summary>
        /// <param name="employeeId">员工编号</param>
        /// <returns></returns>
        List<TB_Employee_Employees> GetAllChildEmployee(int employeeId);

        /// <summary>
        /// 获取所有下级员工的编号（级别是通过职位来分的）
        /// </summary>
        /// <param name="employeeId">员工编号</param>
        /// <returns></returns>
        string GetAllChildEmployeeIds(int employeeId);
    }
}
