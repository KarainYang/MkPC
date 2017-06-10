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
    /// 工作流节点表业务
    /// </summary>
    public class WorkFlow_Nodes_BLL : BaseBLL<TB_WorkFlow_Nodes>,IWorkFlow_Nodes
    {
        /// <summary>
        /// 获取状态名称
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public string GetStateName(int state)
        {
            if (state == 0)
            {
                return "未提交";
            }
            TB_WorkFlow_Nodes node = Get(state);
            return node.NextNode == 0 ? node.Name : "待" + node.Name;
        }

        /// <summary>
        /// 获取用户在审批流下面所有的审批节点
        /// </summary>
        /// <param name="mainCode"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public string GetStates(string mainCode,int employeeId)
        {
            Employee_Duty_BLL dutyBll=new Employee_Duty_BLL();
            string dutyIds = dutyBll.GetAllChildDutyStr(employeeId);
            dutyIds = "0," + dutyIds;
            dutyIds = dutyIds.TrimEnd(',');

            string nodeIds="0,";
            var nodelist = Search(s => s.MainCode == mainCode);
            foreach (var item in nodelist)
            {
                nodeIds += item.Id + ",";
            }
            nodeIds = nodeIds.TrimEnd(',');

            List<Expression> expression = new List<Expression>();
            expression.Add(new Expression("NodeID","in",nodeIds));
            expression.Add(new Expression("and (("));
            expression.Add(new Expression("ObjectID", "=", employeeId));
            expression.Add(new Expression("Type", "=", 0));
            expression.Add(new Expression(") or ("));
            expression.Add(new Expression("ObjectID", "in", dutyIds));
            expression.Add(new Expression("Type", "=", 1));
            expression.Add(new Expression("))"));

            WorkFlow_Approval_BLL approvalBLL = new WorkFlow_Approval_BLL();
            List<TB_WorkFlow_Approval> list = approvalBLL.Search(expression);
            string ids = "";
            foreach (var item in list)
            {
                ids += item.NodeID+",";
            }
            ids = ids.TrimEnd(',');
            return ids;
        }
        /// <summary>
        /// 获取工作流的第一个节点
        /// </summary>
        /// <param name="mainCode"></param>
        /// <returns></returns>
        public int GetFirstNode(string mainCode)
        {
            List<Expression> expression = new List<Expression>();
            expression.Add(new Expression("MainCode", "=", mainCode));
            expression.Add(new Expression("PreviousNode", "=", 0));
            var model = Get(expression);
            return model.Id;
        }
    }
}
