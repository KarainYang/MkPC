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
    /// 员工业务
    /// </summary>
    public class Employee_Employees_BLL : BaseBLL<TB_Employee_Employees>,IEmployee_Employees
    {
        /// <summary>
        /// 获取所有下级员工（级别是通过职位来分的）
        /// </summary>
        /// <param name="employeeId">员工编号</param>
        /// <returns></returns>
        public List<TB_Employee_Employees> GetAllChildEmployee(int employeeId)
        {
            Employee_Duty_BLL dutyDal = new Employee_Duty_BLL();
            string dutyIds = dutyDal.GetAllChildDutyStr(employeeId);

            Employee_Departments_BLL departmentsDal = new Employee_Departments_BLL();
            string departments = departmentsDal.GetAllChildDepartmentsStr(employeeId);

            dutyIds = dutyIds == "" ? "0" : dutyIds;

            departments = departments == "" ? "0" : departments;

            List<Expression> expression = new List<Expression>();
            expression.Add(new Expression("DutyID", "in", dutyIds));
            expression.Add(new Expression("DepartmentID", "in", departments));

            return Search(expression);
        }

        /// <summary>
        /// 获取所有下级员工的编号（级别是通过职位来分的）
        /// </summary>
        /// <param name="employeeId">员工编号</param>
        /// <returns></returns>
        public string GetAllChildEmployeeIds(int employeeId)
        {
            var empList = GetAllChildEmployee(employeeId);
            string empIds = "";
            foreach (var item in empList)
            {
                empIds += item.ID + ",";
            }
            empIds = empIds.TrimEnd(',');

            return empIds;
        }
    }
}
