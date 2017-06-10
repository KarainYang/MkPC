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
    /// 职位业务
    /// </summary>
    public class Employee_Duty_BLL : BaseBLL<TB_Employee_Duty>,IEmployee_Duty
    {
        List<TB_Employee_Duty> list=new List<TB_Employee_Duty>();

        List<TB_Employee_Duty> twolist = new List<TB_Employee_Duty>();

        /// <summary>
        /// 获取所有下级职位的实体
        /// </summary>
        /// <param name="employeeId">员工编号</param>
        /// <returns></returns>
        public List<TB_Employee_Duty> GetAllChildDuty(int employeeId)
        { 
            string cmdText="select * from TB_Employee_Duty where ParentID=(select DutyID from TB_Employee_Employees"
                + " where ID=" + employeeId + ")";

            list = SQLSearch(cmdText);

            foreach (var item in list)
            {
                GetChildDuty(item.ID);
            }

            list.AddRange(twolist);

            return list;
        }

        /// <summary>
        /// 获取所有下级职位的编号
        /// </summary>
        /// <param name="employeeId">员工编号</param>
        /// <returns></returns>
        public string GetAllChildDutyStr(int employeeId)
        {
            GetAllChildDuty(employeeId);

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
        private void GetChildDuty(int parentID)
        { 
            List<Expression> expression=new List<Expression>();
            expression.Add(new Expression("ParentID","=",parentID));
            var childList = Search(expression);

            if (childList.Count > 0)
            {
                foreach (var item in childList)
                {
                    twolist.Add(item);

                    GetChildDuty(item.ID);
                }
            }
        }
    }
}
