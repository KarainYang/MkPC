using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using YK.BLL.CRM;
using YK.Interface.CRM;

namespace YK.Service
{
    /// <summary>
    /// 员工信息管理系统操作类
    /// </summary>
    public static class EmployeeService
    {       
        /// <summary>
        /// 工作报告服务
        /// </summary>
        public static IEmployee_WorkStatement WorkStatementService
        {
            get
            {
                return new Employee_WorkStatement_BLL();
            }
        }

        /// <summary>
        /// 信息类别服务
        /// </summary>
        public static IEmployee_InfoCategory InfoCategoryService
        {
            get
            {
                return new Employee_InfoCategory_BLL();
            }
        }

        /// <summary>
        /// 信息服务
        /// </summary>
        public static IEmployee_Info InfoService
        {
            get
            {
                return new Employee_Info_BLL();
            }
        }
    }
}
