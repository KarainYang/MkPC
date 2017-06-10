using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using YK.Interface;
using System.Reflection;
using YK.Interface.Systems;
using YK.BLL.Systems;

namespace YK.Service
{
    /// <summary>
    /// 系统管理服务
    /// </summary>
    public static class SysService
    {       
        /// <summary>
        /// 项目管理服务
        /// </summary>
        public static ISysOrganizations SysOrganizations
        {
            get
            {
                return new SysOrganizationsBLL();
            }
        }
    }
}
