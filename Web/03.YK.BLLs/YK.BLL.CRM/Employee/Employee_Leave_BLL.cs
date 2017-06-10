﻿using System;
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
    /// 请假业务
    /// </summary>
    public class Employee_Leave_BLL : BaseBLL<TB_Employee_Leave>,IEmployee_Leave
    {
        /// <summary>
        /// 获取下级人员的所有请假
        /// </summary>
        /// <param name="employeeId">员工编号</param>
        /// <param name="childID">搜索员工编号</param>
        /// <param name="PageSize">页面大小</param>
        /// <param name="PageIndex">分页码</param>
        /// <param name="recordCount">查询总数</param>
        /// <returns></returns>
        public List<TB_Employee_Leave> GetChildLeave(int employeeId,int childID, int pageSize, int pageIndex, ref int recordCount)
        {
            Employee_Employees_BLL duty = new Employee_Employees_BLL();
            string employeeIds = duty.GetAllChildEmployeeIds(employeeId);

            List<Expression> expression = new List<Expression>();
            expression.Add(new Expression("EmployeeID", "in", employeeIds));

            if (childID > 0)
            {
                expression.Add(new Expression("EmployeeID", "=", childID));
            }

            return Search(pageSize, pageIndex, expression, "ID desc,AddDate desc", ref recordCount);
        }
    }
}