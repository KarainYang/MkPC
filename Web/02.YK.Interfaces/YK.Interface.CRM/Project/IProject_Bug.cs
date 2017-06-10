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
    /// 缺陷管理接口
    /// </summary>
    public interface IProject_Bug: IBase<TB_Project_Bug>
    {
       /// <summary>
        /// 获取下级人员的所有缺陷
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="PageSize">页面大小</param>
        /// <param name="PageIndex">分页码</param>
        /// <param name="recordCount">查询总数</param>
        /// <returns></returns>
        List<TB_Project_Bug> GetChildUserBug(int userId, int pageSize, int pageIndex, ref int recordCount);
    }
}
