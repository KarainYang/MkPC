using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using YK.Model.CRM;
using YK.Interface.CRM;
using YK.BLL.Common;
using YK.Model;

namespace YK.BLL.CRM
{
    /// <summary>
    /// 缺陷管理业务
    /// </summary>
    public class Project_Bug_BLL : BaseBLL<TB_Project_Bug>,IProject_Bug
    {
        /// <summary>
        /// 获取下级人员的所有缺陷
        /// </summary>
        /// <param name="employeeId">员工编号</param>
        /// <param name="PageSize">页面大小</param>
        /// <param name="PageIndex">分页码</param>
        /// <param name="recordCount">查询总数</param>
        /// <returns></returns>
        public List<TB_Project_Bug> GetChildUserBug(int employeeId, int pageSize, int pageIndex, ref int recordCount)
        {
            Employee_Employees_BLL duty = new Employee_Employees_BLL();
            string employeeIds = duty.GetAllChildEmployeeIds(employeeId);

            List<Expression> expression = new List<Expression>();
            expression.Add(new Expression("EmployeeID", "in", employeeIds));

            return Search(pageSize, pageIndex, expression, "ID desc,AddDate desc", ref recordCount);
        }
    }
}
