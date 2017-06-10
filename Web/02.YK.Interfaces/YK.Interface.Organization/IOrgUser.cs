using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using YK.Model.Organization;
using YK.Interface.Common;

namespace YK.Interface.Organization
{
    /// <summary>
    /// 组织用户
    /// </summary>
    public interface IOrgUser : IBase<TB_Org_User>
    {
        /// <summary>
        /// 核查登陆
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TB_Org_User CheckUserLogin(TB_Org_User entity);
    }
}
