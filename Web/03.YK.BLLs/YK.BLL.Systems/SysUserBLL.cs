using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using System.Linq;
using YK.Interface.Systems;
using YK.Model.Systems;

namespace YK.BLL.Systems
{
    /// <summary>
    /// 系统级用户
    /// </summary>
    public class SysUserBLL : BasePageBLL<TB_Sys_User>, ISysUser
    {
        /// <summary>
        /// 检查登录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>       
        public TB_Sys_User CheckLogin(TB_Sys_User entity)
        {
            var list = Search(s => s.UserName == entity.UserName && s.UserPwd == entity.UserPwd);
            TB_Sys_User user = list.Count > 0 ? list.First() : null;
            return user;
        }
    }
}
