using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using YK.Model.CRM;
using YK.Interface.CRM;
using YK.BLL.Common;

namespace YK.BLL.CRM
{
    /// <summary>
    /// 部门业务
    /// </summary>
    public class Employee_Departments_BLL : BaseBLL<TB_Employee_Departments>,IEmployee_Departments
    {
        List<TB_Employee_Departments> list = new List<TB_Employee_Departments>();

        List<TB_Employee_Departments> twolist = new List<TB_Employee_Departments>();

        /// <summary>
        /// 获取所有下级部门的实体
        /// </summary>
        /// <param name="employeeId">员工编号</param>
        /// <returns></returns>
        public List<TB_Employee_Departments> GetAllChildDepartments(int employeeId)
        {
            string cmdText = "select * from TB_Employee_Departments where ID=(select DepartmentID from TB_Employee_Employees"
                + " where ID=" + employeeId + ")";

            list = SQLSearch(cmdText);

            foreach (var item in list)
            {
                GetChildDepartments(item.ID);
            }

            list.AddRange(twolist);

            return list;
        }

        /// <summary>
        /// 获取所有下级部门的编号
        /// </summary>
        /// <param name="employeeId">员工编号</param>
        /// <returns></returns>
        public string GetAllChildDepartmentsStr(int employeeId)
        {
            GetAllChildDepartments(employeeId);

            string arr = "";
            foreach (var item in list)
            {
                arr += item.ID + ",";
            }
            arr = arr.TrimEnd(',');

            return arr;
        }

        /// <summary>
        /// 获取子级
        /// </summary>
        /// <param name="parentID"></param>
        private void GetChildDepartments(int parentID)
        {
            var childList = Search(w => w.ParentID == parentID);

            if (childList.Count > 0)
            {
                foreach (var item in childList)
                {
                    twolist.Add(item);

                    GetChildDepartments(item.ID);
                }
            }
        }
    }
}
