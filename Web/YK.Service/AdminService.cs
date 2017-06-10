using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using YK.Interface;
using System.Reflection;
using YK.BLL;

namespace YK.Service
{
    /// <summary>
    /// 管理员模块操作类
    /// </summary>
    public static class AdminService
    {       
        /// <summary>
        /// 管理员服务
        /// </summary>
        public static IAdmin_User UserService
        {
            get
            {
                return new Admin_User_BLL();
            }
        }

        /// <summary>
        /// 角色服务
        /// </summary>
        public static IAdmin_Roles RoleService
        {
            get
            {
                return new Admin_Roles_BLL();
            }
        }

        /// <summary>
        /// 管理员角色服务
        /// </summary>
        public static IAdmin_UserInRole UserInRoleService
        {
            get
            {
                return new Admin_UserInRole_BLL();
            }
        }

        /// <summary>
        /// 资源服务
        /// </summary>
        public static IAdmin_Resources ResourcesService
        {
            get
            {
                return new Admin_Resources_BLL();
            }
        }

        /// <summary>
        /// 角色资源服务
        /// </summary>
        public static IAdmin_RoleInResources RoleInResourcesService
        {
            get
            {
                return new Admin_RoleInResources_BLL();
            }
        }

        /// <summary>
        /// 操作日志
        /// </summary>
        public static IAdmin_Log LogService
        {
            get
            {
                return new Admin_Log_BLL();
            }
        }   
    }
}
