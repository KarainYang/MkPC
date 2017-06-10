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
    /// 工作流节点表接口
    /// </summary>
    public interface IWorkFlow_Nodes: IBase<TB_WorkFlow_Nodes>
    {
        /// <summary>
        /// 获取状态名称
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        string GetStateName(int state);
         /// <summary>
        /// 获取用户在审批流下面所有的审批节点
        /// </summary>
        /// <param name="mainCode"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        string GetStates(string mainCode, int employeeId);
        /// <summary>
        /// 获取工作流的第一个节点
        /// </summary>
        /// <param name="mainCode"></param>
        /// <returns></returns>
        int GetFirstNode(string mainCode);
    }
}
