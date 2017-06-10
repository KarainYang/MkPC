using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using System.Linq;
using YK.Interface.Organization;
using YK.Model.Organization;

namespace YK.BLL.Organization
{
    /// <summary>
    /// 组织用户
    /// </summary>
    public class OrgUserBLL : BasePageBLL<TB_Org_User>, IOrgUser
    {
        /// <summary>
        /// 核查登陆
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public TB_Org_User CheckUserLogin(TB_Org_User entity)
        {
           var list = Search(s => s.OrganizationId == entity.OrganizationId
                && s.UserName == entity.UserName
                && entity.UserPwd == entity.UserPwd
                && entity.State == 0
                );
           return list.Count > 0 ? list.First() : null;
        }
    }
}
