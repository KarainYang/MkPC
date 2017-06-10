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
    /// 办公用品申请接口
    /// </summary>
    public interface IEmployee_OfficeSupplies: IBase<TB_Employee_OfficeSupplies>
    {
       /// <summary>
        /// 获取下级人员的所有办公用品申请
        /// </summary>
        /// <param name="employeeId">员工编号</param>
        /// <param name="childID">搜索员工编号</param>
        /// <param name="PageSize">页面大小</param>
        /// <param name="PageIndex">分页码</param>
        /// <param name="recordCount">查询总数</param>
        /// <returns></returns>
        List<TB_Employee_OfficeSupplies> GetChildOfficeSupplies(int employeeId, int childID, int pageSize, int pageIndex, ref int recordCount);
    }
}
