using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using YK.Interface;
using System.Reflection;
using YK.BLL.CRM;
using YK.Interface.CRM;

namespace YK.Service
{
    /// <summary>
    /// 项目模块操作类
    /// </summary>
    public static class ProjectService
    {       
        /// <summary>
        /// 项目管理服务
        /// </summary>
        public static IProject_Projects ProjectsService
        {
            get
            {
                return new Project_Projects_BLL();
            }
        }

        /// <summary>
        /// 任务管理服务
        /// </summary>
        public static IProject_Task TaskService
        {
            get
            {
                return new Project_Task_BLL();
            }
        }
    }
}
