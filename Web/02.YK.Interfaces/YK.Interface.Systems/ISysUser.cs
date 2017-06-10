using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using YK.Model.Systems;
using YK.Interface.Common;

namespace YK.Interface.Systems
{
    /// <summary>
    /// 系统级用户
    /// </summary>
    public interface ISysUser : IBase<TB_Sys_User>
    {
        /// <summary>
        /// 检查登录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>       
        TB_Sys_User CheckLogin(TB_Sys_User user);
    }
}
