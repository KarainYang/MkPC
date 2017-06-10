using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YK.Common;
using YK.Model.Organization;

namespace YK.Service.Common
{
    /// <summary>
    /// 基类
    /// </summary>
    public class ServiceBase
    {
        /// <summary>
        /// 是否登陆成功
        /// </summary>
        public bool IsLoginSucess { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="entity"></param>
        public ServiceBase(Guid OrganizationId,string UserName, string UserPwd)
        {
            //检查登陆
            CheckLogin(OrganizationId,UserName, UserPwd);
        }
        /// <summary>
        /// 检查登陆
        /// </summary>
        /// <param name="entity"></param>
        private void CheckLogin(Guid OrganizationId, string UserName, string UserPwd)
        {
            TB_Org_User user = new TB_Org_User();
            user.OrganizationId = OrganizationId.ToString();
            user.UserName = UserName;
            user.UserPwd = UserPwd;

            var usrBll = AssemblyHelper.CreateObject<YK.Interface.Organization.IOrgUser>();
            var result = usrBll.CheckUserLogin(user);
            IsLoginSucess = result == null ? false : true;
        }
    }
}
